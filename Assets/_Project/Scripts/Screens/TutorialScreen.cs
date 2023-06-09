using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScreen : MonoBehaviour
{
    [SerializeField] private Button btnPlay;
    [SerializeField] private GameObject screen;
    
    void Start()
    {
        btnPlay.onClick.AddListener(BtnPlayClick);
        OpenScreen();
    }

    private void BtnPlayClick()
    {
        Time.timeScale = 1f;
        screen.SetActive(false);
    }

    private void OpenScreen()
    {
        screen.SetActive(true);
        Time.timeScale = 0f;
        
    }
}
