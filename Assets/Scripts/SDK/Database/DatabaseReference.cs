using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Auth;

public class DatabaseReference : MonoBehaviour
{
    private static DatabaseReference _instance;

    public static DatabaseReference Instance
    {
        get
        {
            return _instance;
        }
    }

    private Firebase.Database.DatabaseReference reference;

    public Firebase.Database.DatabaseReference Reference
    {
        get;
        set;
        
    }

    void Awake()
    {

        DontDestroyOnLoad(this);

        reference = FirebaseDatabase.DefaultInstance.RootReference;
        Reference = reference;

        if (_instance == null)
        {
            
            _instance = this;
            
        }
    }
}
