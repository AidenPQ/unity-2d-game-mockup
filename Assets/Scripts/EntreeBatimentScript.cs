using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntreeBatimentScript : MonoBehaviour
{
    private bool InCollider = false;
    private GameObject Player;
    private AudioSource ads;

    [SerializeField]
    GameObject IndicEntreeBat;

    [SerializeField]
    GameObject OHNo;

    private void Awake()
    {
        Player = GameObject.Find("Player");
        ads = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if (InCollider)
        {
            IndicEntreeBat.SetActive(true);
            IndicEntreeBat.transform.position = Camera.main.WorldToScreenPoint(Player.transform.position);
            if (Input.GetKeyDown(KeyCode.Space) && Player.GetComponent<PlayerController>().haveKey)
            {
                SaveBetweenScene();
                SceneManager.LoadScene("InterieurBatiment");
            }
            else if(Input.GetKeyDown(KeyCode.Space) && !Player.GetComponent<PlayerController>().haveKey)
            {
                OHNo.SetActive(true);
                ads.Play();
                StartCoroutine(Desactive());
            }
        }

        else if (!InCollider)
        {
            IndicEntreeBat.SetActive(false);
        }
    }

    IEnumerator Desactive()
    {
        yield return new WaitForSeconds(2f);
        OHNo.SetActive(false);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
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
