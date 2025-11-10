using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetourVilleScript : MonoBehaviour
{
    private bool InCollider = false;
    private GameObject Player;

    [SerializeField]
    GameObject IndicRetourVille;

    private void Awake()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (InCollider)
        {
            IndicRetourVille.SetActive(true);
            if (Input.GetMouseButton(0))
            {
                PlayerPrefs.SetInt("bscene", 1);
                SceneManager.LoadScene("Ville");
            }
        }
        else if (!InCollider)
        {
            IndicRetourVille.SetActive(false);
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
