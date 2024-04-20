using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LogInButton : MonoBehaviour
{
    [SerializeField] private TMP_InputField _emailField;
    [SerializeField] private TMP_InputField _passwordField;

    public static Action OnUserLogedIn;
    private Coroutine _registrationCoroutine;
    [SerializeField] private Button _logInButton;
    [SerializeField] private RegistrationUIFlow _registrationFlow;
    // Start is called before the first frame update


    private void Reset()
    {
        _registrationFlow = FindObjectOfType<RegistrationUIFlow>();
        _logInButton = GetComponent<Button>();
    }

    void Start()
    {
        RegistrationUIFlow.OnStateChanged += HandleRegistrationStateChanged;
        _logInButton.onClick.AddListener(HandRegistrationStateClicked);
        UpdateInteractable();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateInteractable()
    {
        _logInButton.interactable =
            _registrationFlow.CurrentState == RegistrationUIFlow.State.Ok
            && _registrationCoroutine == null;
    }

    private void HandleRegistrationStateChanged(RegistrationUIFlow.State registrationState)
    {
        UpdateInteractable();
    }

    private void HandRegistrationStateClicked()
    {
        _registrationCoroutine = StartCoroutine(routine: LogOutUser(_emailField.text, _passwordField.text));
        UpdateInteractable();
    }

    private IEnumerator LogOutUser(string email, string password)
    {
        var auth = FireManager.Instance.Auth;

        var logOutTask = auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.AuthResult result = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                result.User.DisplayName, result.User.UserId);
        });

        yield return new WaitUntil(predicate: () => logOutTask.IsCompleted);

        _registrationCoroutine = null;
        UpdateInteractable();
        OnUserLogedIn?.Invoke();
    }

}
