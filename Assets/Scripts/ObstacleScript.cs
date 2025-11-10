using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField] Animator GameO;
    [SerializeField] GameObject RespawnButton;

    [SerializeField] GameObject Key;

    private GameObject Player;

    private void Awake()
    {
        Player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Key.SetActive(false);
            Player.GetComponent<PlayerController>().speed = 0f;
            GameO.SetBool("GameOver", true);
            Player.GetComponent<PlayerController>().IsDeath = true;
            StartCoroutine(ApparitionButton());
        }
    }

    public void Respawn()
    {
        if (PlayerPrefs.HasKey("sceneSave"))
        {
            PlayerPrefs.SetInt("load", 1);
            SceneManager.LoadScene(PlayerPrefs.GetString("sceneSave"));
        }
        else
        {
            SceneManager.LoadScene("Ville");
        }
    }

    IEnumerator ApparitionButton()
    {
        yield return new WaitForSeconds(2.5f);
        RespawnButton.SetActive(true);
    }
}
