using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveDeleteOptScript : MonoBehaviour
{
    float music, txtspd, sfx;
    int origin;
    
    void Start()
    {
        origin = PlayerPrefs.GetInt("origin");
    }

    public void SaveAndReturn()
    {
        music = GetComponent<MusicOptScript>().getMusic();
        txtspd = GetComponent<TxtSpeedOptScript>().getTxtspd();
        sfx = GetComponent<MusicSfxOptScript>().getMusic();
        PlayerPrefs.SetFloat("music", music);
        PlayerPrefs.SetFloat("sfx", sfx);
        PlayerPrefs.SetFloat("txtspd", txtspd);

        if(origin == 0)
        {
            SceneManager.LoadScene("Menu");
        }
        else if(origin == 1)
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("TransScene"));
        }
    }

 
}
