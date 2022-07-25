using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour  // Restarts level from UI
{
    Button myButton;

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
