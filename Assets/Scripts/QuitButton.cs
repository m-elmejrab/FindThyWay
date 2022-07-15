using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour //Quits the game from UI
{
    Button myButton;
    void Start()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(QuitButtonClicked);
    }

    private void QuitButtonClicked()
    {
        SoundManager.instance.PlayClickSound();

        Application.Quit();
    }


}
