using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    Button myButton;
    // Start is called before the first frame update
    void Start()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(RestartLevelClicked);
    }

    private void RestartLevelClicked()
    {
        SoundManager.instance.PlayClickSound();

        GameManager.instance.RestartLevel();
    }
}
