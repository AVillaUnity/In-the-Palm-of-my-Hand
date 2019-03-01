using UnityEngine;
using UnityEngine.UI;

public class TutorialToggle : MonoBehaviour
{
    public Toggle toggle;

    private void Start()
    {
        toggle.isOn = PlayerPrefsManager.GetTutorial();
    }

    public void Toggle()
    {
        PlayerPrefsManager.SetTutorial(toggle.isOn);
    }
}
