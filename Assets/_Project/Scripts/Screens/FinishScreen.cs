using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishScreen : MonoBehaviour
{
    [SerializeField] private Button btnRepeat;
    [Space] 
    [SerializeField] private GameObject screen;

    private void Start()
    {
        btnRepeat.onClick.AddListener(BtnRepeatClick);
    }

    private void BtnRepeatClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OpenScreen()
    {
        screen.SetActive(true);
    }
    
    public void CloseScreen()
    {
        screen.SetActive(false);
    }
}
