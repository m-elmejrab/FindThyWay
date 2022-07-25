using UnityEngine;
using UnityEngine.UI;

public class LoadLevelButton : MonoBehaviour //Loads a certain level from UI selection
{
    [SerializeField] int levelToLoadIndex;
    Button myButton;

    void Start()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(LoadLevelClicked);
    }

    private void LoadLevelClicked()
    {
        SoundManager.instance.PlayClickSound();
        GameManager.instance.LoadLevel(levelToLoadIndex);
    }

}
