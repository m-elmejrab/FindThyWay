using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadLevelButton : MonoBehaviour
{
    [SerializeField] int levelToLoadIndex;
    Button myButton;
    // Start is called before the first frame update
    void Start()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(LoadLevelClicked);
    }

    private void LoadLevelClicked()
    {
        GameManager.instance.LoadLevel(levelToLoadIndex);
    }

}
