using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using Firebase;
using UnityEngine.Events;
using System;


public class FireManager : MonoBehaviour
{
    private static FireManager _instance;

    public static FireManager Instance
    {
        get
        {
            return _instance;
        }
    }


    private FirebaseAuth _auth;

    public FirebaseAuth Auth
    {
        get;
        set;
        /*{
            if(_auth == null)
            {
                
            }

            return _auth;
        }*/
    }
    /*
    private FirebaseApp _app;

    public FirebaseApp App
    {
        get
        {
            if(_app == null)
            {
                _app = FirebaseApp.DefaultInstance;
            }

            return _app;
        }
    }*/

    public static Action OnFirebaseInitialized;//

    private void Awake()
    {
        _auth = FirebaseAuth.DefaultInstance;



        Auth = _auth;

        if (_instance == null)
        {
            //DontDestroyOnLoad(gameObject);
            _instance = this;
            /*var dependencyResult = await FirebaseApp.CheckAndFixDependenciesAsync();
            if(dependencyResult == DependencyStatus.Available)
            {
                _app = FirebaseApp.DefaultInstance;
                OnFirebaseInitialized.Invoke();
            }

            else
            {
                Debug.LogError("Failed to initialize");
            }*/
        }
        /*
        else
        {
            Debug.LogError("An instance already exist");
        }*/
    }

   

    private void OnDestroy()
    {
        _auth = null;
        //_app = null;

        if(_instance == this)
        {
            _instance = null;
        }
    }
}
