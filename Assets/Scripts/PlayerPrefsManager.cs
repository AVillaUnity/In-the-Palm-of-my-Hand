using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

    const string HIGHSCORE_KEY = "highscore";
    const string LASTSCORE_KEY = "lastscore";
    const string TUTORIAL = "tutorial";


    #region Highscore
    public static void SetHighscore(int value)
    {
        if (value >= 0)
            PlayerPrefs.SetInt(HIGHSCORE_KEY, value);
    }

    public static int GetHighscore()
    {
        return PlayerPrefs.GetInt(HIGHSCORE_KEY, 0);
    }
    #endregion
    #region LastScore
    public static void SetLastscore(int value)
    {
        if (value >= 0)
            PlayerPrefs.SetInt(LASTSCORE_KEY, value);
    }

    public static float GetLastscore()
    {
        return PlayerPrefs.GetInt(LASTSCORE_KEY, 0);
    }
    #endregion
    #region Tutorial
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
    #endregion 




}
