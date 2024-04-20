using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase;
using Firebase.Database;
using Firebase.Auth;
using System;
public class User : MonoBehaviour
{
    private FirebaseUser _firebaseUser;

    private string userID;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        RegistrationButton.OnUserRegistered += CreateUser;
        RegistrationButton.OnWriteNewUser += WriteNewUser;
    }

    private void CreateUser()
    {
        _firebaseUser = FirebaseAuth.DefaultInstance.CurrentUser;
        userID = _firebaseUser.UserId;
    }

    private void WriteNewUser(string name)
    {
        DatabaseReference.Instance.Reference.Child("User").Child(_firebaseUser.UserId).Child("name").SetValueAsync(name);
    }

    public void GetDataButton()
    {
        StartCoroutine(GetUserHighscoreCoroutine());
    }

    private IEnumerator GetUserHighscoreCoroutine()
    {
        var task = DatabaseReference.Instance.Reference.Child("User").GetValueAsync();


        yield return new WaitUntil(() => task.IsCompleted);

        if (task.IsFaulted || task.IsCanceled)
        {
            Debug.LogError("Error when getting highscore");
        }
        else
        {
            DataSnapshot snapshot = task.Result;

            Debug.Log("Result: " + snapshot);
            foreach(var item in snapshot.Children)
            {
                Debug.Log(item.Child("name").Value);
            }
        }

    }
}