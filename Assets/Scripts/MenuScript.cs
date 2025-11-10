using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("load", 0);
        PlayerPrefs.SetInt("bscene", 0);
        PlayerPrefs.SetInt("origin", 0);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Ville");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    public void loadGame()
    {
        if (PlayerPrefs.HasKey("sceneSave"))
        {
            PlayerPrefs.SetInt("load", 1);
            SceneManager.LoadScene(PlayerPrefs.GetString("sceneSave"));
        }
        else
        {
            PlayGame();
        }
 
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
}
