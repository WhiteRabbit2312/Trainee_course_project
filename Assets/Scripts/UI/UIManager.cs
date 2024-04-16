using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainPanel; 
    [SerializeField] private GameObject _gameOverPanel; 
    [SerializeField] private GameObject _inGamePanel; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        _mainPanel.SetActive(false);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
