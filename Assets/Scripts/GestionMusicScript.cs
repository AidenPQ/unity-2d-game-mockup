using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionMusicScript : MonoBehaviour
{
    private float music = 1f;
    private AudioSource ad;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("music"))
        {
            music = PlayerPrefs.GetFloat("music");
        }
        ad = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ad.volume = music;
    }
}
