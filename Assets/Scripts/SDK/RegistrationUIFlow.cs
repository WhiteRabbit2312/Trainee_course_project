using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System;

public class RegistrationUIFlow : MonoBehaviour
{
    [HideInInspector] public string Email;
    [HideInInspector] public string Password;
    [SerializeField] private TMP_InputField _emailField;
    [SerializeField] private TMP_InputField _passwordField;
    [SerializeField] private TMP_InputField _verifyPasswordField;

    public State CurrentState
    {
        get;
        private set;
    }

    public static Action<State> OnStateChanged;//

    private void Awake()
    {
        _emailField.onValueChanged.AddListener(ValueChanged);
        _passwordField.onValueChanged.AddListener(ValueChanged);
        _verifyPasswordField.onValueChanged.AddListener(ValueChanged);

        ComputeState();
    }

    private void ValueChanged(string _)
    {
        ComputeState();
    }

    private void ComputeState()
    {
        if (string.IsNullOrEmpty(_emailField.text))
        {
            Email = _emailField.text;
            SetState(State.EnterEmail);
        }

        else if (string.IsNullOrEmpty(_passwordField.text))
        {
            Password = _passwordField.text;
            SetState(State.EnterPassword);
        }

        else if (_passwordField.text != _verifyPasswordField.text)
        {
            SetState(State.PasswordDontMatch);
        }

        else
        {
            SetState(State.Ok);
        }
    }

    private void SetState(State state)
    {
        CurrentState = state;
        OnStateChanged?.Invoke(state);
    }

    public enum State
    {
        EnterEmail,
        EnterPassword,
        PasswordDontMatch,
        Ok
    }
}
