using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private bool InCollider = false;
    private GameObject Player;
    private AudioSource ads;

    [SerializeField]
    GameObject Indic;

    private void Awake()
    {
        ads = GetComponent<AudioSource>();
        Player = GameObject.Find("Player");
        if (Player.GetComponent<PlayerController>().haveKey)
        {
            Destroy(this.gameObject);
            Indic.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<PlayerController>().haveKey)
        {
            Destroy(this.gameObject);
        }
        if (InCollider)
        {
            Indic.SetActive(true);
            if (Input.GetKeyDown(KeyCode.B))
            {
                Indic.SetActive(false);
                ads.Play();
                Destroy(this.gameObject, 1f);
            }
        }
        
        else if (!InCollider)
        {
            Indic.SetActive(false);
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

    private void OnDestroy()
    {
        Player.GetComponent<PlayerController>().haveKey = true;
        if (Player.GetComponent<PlayerController>().haveKey)
        {
            PlayerPrefs.SetInt("hvky", 1);
        }
        else
        {
            PlayerPrefs.SetInt("hvky", 0);
        }
        Indic.SetActive(false);
    }
}
