using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RegistrationButton : MonoBehaviour
{
    [SerializeField] private TMP_InputField _emailField;
    [SerializeField] private TMP_InputField _passwordField;

    [SerializeField] private RegistrationUIFlow _registrationFlow;
    [SerializeField] private Button _registrationButton;

    public static Action OnUserRegistered;
    public static Action<string> OnWriteNewUser;

    private Coroutine _registrationCoroutine;

    //public UnityEvent OnUserRegistered;
    //public UnityEvent OnUserRegistrationFailed;

    private void Reset()
    {
        _registrationFlow = FindObjectOfType<RegistrationUIFlow>();
        _registrationButton = GetComponent<Button>();
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        RegistrationUIFlow.OnStateChanged += HandleRegistrationStateChanged;
        //_registrationFlow.OnStateChanged.AddListener(HandleRegistrationStateChanged);
        _registrationButton.onClick.AddListener(HandRegistrationStateClicked);

        UpdateInteractable();
    }

    private void OnDestroy()
    {
        RegistrationUIFlow.OnStateChanged -= HandleRegistrationStateChanged;
        //_registrationFlow.OnStateChanged.RemoveListener(HandleRegistrationStateChanged);
        _registrationButton.onClick.RemoveListener(HandRegistrationStateClicked);
    }

    private void UpdateInteractable()
    {
        _registrationButton.interactable =
            _registrationFlow.CurrentState == RegistrationUIFlow.State.Ok
            && _registrationCoroutine == null;
    }

    private void HandleRegistrationStateChanged(RegistrationUIFlow.State registrationState)
    {
        UpdateInteractable();
    }

    private void HandRegistrationStateClicked()
    {
        _registrationCoroutine = StartCoroutine(routine: RegisterUser(_emailField.text, _passwordField.text));
        UpdateInteractable();
    }

    private IEnumerator RegisterUser(string email, string password)
    {
        Debug.Log("Email: " + email);
        Debug.Log("Password: " + password);

        var auth = FireManager.Instance.Auth;
        var registerTask = auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.AuthResult result = task.Result;
            UnityEngine.Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                result.User.DisplayName, result.User.UserId);
        });

        yield return new WaitUntil(predicate: () => registerTask.IsCompleted);

        _registrationCoroutine = null;
        UpdateInteractable();
        OnUserRegistered?.Invoke();
        OnWriteNewUser?.Invoke("NameUser");
    }
}
