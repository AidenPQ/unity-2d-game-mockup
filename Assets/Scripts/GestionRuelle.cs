using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionRuelle : MonoBehaviour
{
    private bool InCollider = false;

    [SerializeField]
    private GameObject Indic;

    private RectTransform Essai;
    private GameObject Player;

    private void Awake()
    {
        Essai = Indic.GetComponent<RectTransform>();
        Player = GameObject.Find("Player");
    }


    private void Update()
    {
        if (InCollider)
        {
            Indic.SetActive(true);
            Indic.transform.position = Camera.main.WorldToScreenPoint(Player.transform.position);
            /*Debug.Log("Test");*/
            if (Input.GetMouseButton(0))
            {
                SaveBetweenScene();
                SceneManager.LoadScene("Ruelle");
            }
            
        }
        else if (!InCollider)
        {
            Indic.SetActive(false);
        }

       
    }

    public void SaveBetweenScene()
    {
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            InCollider = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            InCollider = false;
        }
    }


}
