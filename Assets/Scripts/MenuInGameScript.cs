using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInGameScript : MonoBehaviour
{
    public GameObject panelMenu;
    bool affiche = false;
    public GameObject Player;
    public GameObject GameSaveTxt;


  
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("origin") == 1)
        {
            Player = GameObject.Find("Player");
            panelMenu.SetActive(true);
            affiche = true;
            Time.timeScale = 0;
        }
        else
        {
            panelMenu.SetActive(false);
            Player = GameObject.Find("Player");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Player.GetComponent<PlayerController>().IsDeath)
        {
            affiche = false;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                affiche = !affiche;
                panelMenu.SetActive(affiche);

                if (affiche)
                {
                    Time.timeScale = 0;
                }
                else
                {
                    GameSaveTxt.SetActive(false);
                    Time.timeScale = 1;
                }
            }
        }
    }

    public void Resume()
    {
        affiche = false;
        Time.timeScale = 1;
        panelMenu.SetActive(affiche);
    }

    public void Save()
    {
        
        PlayerPrefs.SetString("sceneSave", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetFloat("posx", Player.transform.position.x);
        PlayerPrefs.SetFloat("posy", Player.transform.position.y);
        PlayerPrefs.SetFloat("posz", Player.transform.position.z);
        if (Player.GetComponent<PlayerController>().haveKey)
        {
            PlayerPrefs.SetInt("havekey", 1);
        }
        else
        {
            PlayerPrefs.SetInt("havekey", 0);
        }
        GameSaveTxt.SetActive(true);
        
    }



    public void ReturnTitle()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void Options()
    {
        SaveBetweenScene();
        Time.timeScale = 1;
        PlayerPrefs.SetInt("origin", 1);
        SceneManager.LoadScene("Options");
    }

    public void SaveBetweenScene()
    {
        PlayerPrefs.SetInt("bscene", 1);
        PlayerPrefs.SetFloat("x", Player.transform.position.x);
        PlayerPrefs.SetFloat("y", Player.transform.position.y);
        PlayerPrefs.SetFloat("z", Player.transform.position.z);
        PlayerPrefs.SetString("TransScene", SceneManager.GetActiveScene().name);
        if (Player.GetComponent<PlayerController>().haveKey)
        {
            PlayerPrefs.SetInt("hvky", 1);
        }
        else
        {
            PlayerPrefs.SetInt("hvky", 0);
        }
    }
}
