using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

    const string HIGHSCORE_KEY = "highscore";
    const string LASTSCORE_KEY = "lastscore";
    const string TUTORIAL = "tutorial";


    // Highscore
    public static void SetHighscore(float value)
    {
        if (value >= 0)
            PlayerPrefs.SetFloat(HIGHSCORE_KEY, value);
    }

    public static float GetHighscore()
    {
        return PlayerPrefs.GetFloat(HIGHSCORE_KEY, 0);
    }

    public static void SetLastscore(float value)
    {
        if (value >= 0)
            PlayerPrefs.SetFloat(HIGHSCORE_KEY, value);
    }

    public static float GetLastscore()
    {
        return PlayerPrefs.GetFloat(HIGHSCORE_KEY, 0);
    }

    public static void SetTutorial(bool value)
    {
        if (value)
        {
            PlayerPrefs.SetInt(TUTORIAL, 1);
        }
        else
        {
            PlayerPrefs.SetInt(TUTORIAL, 0);
        }
    }

    public static bool GetTutorial()
    {
        if(PlayerPrefs.GetInt(TUTORIAL, 1) == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }




}
