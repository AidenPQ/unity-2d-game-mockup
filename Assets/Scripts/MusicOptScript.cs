using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class MusicOptScript : MonoBehaviour
{
    float music = 1f;
    int nbreCliques = 0;

    [SerializeField]
    GameObject mutebutton, mus50Button, mus100button;

    [SerializeField]
    Animator mute, mus50, mus100;
    

    bool mut = false, ms5 = false, ms10 = false;

    private void Awake()
    {
        Debug.Log("test");
        if (PlayerPrefs.HasKey("music"))
        {
            music = PlayerPrefs.GetFloat("music");
        }
        
    }
    private void Start()
    {
        Debug.Log(music);
        nbreCliques = 0;
        if(music == 0f)
        {
            mut = true;
            mute.SetBool("Press1", true);
            nbreCliques = 1;
        }
        else if (music == 0.5f)
        {
            ms5 = true;
            mus50.SetBool("Press1", true);
            nbreCliques = 1;
        }
        else if (music == 1f)
        {
            Debug.Log("test");
            ms10 = true;
            mus100.SetBool("Press1", true);
            nbreCliques = 1;
        }
    }


    public float getMusic()
    {
        return music;
    }

    public void Mute()
    {
        nbreCliques++;
        if(nbreCliques == 1)
        {
            music = 0f;
            mute.SetBool("Press1", true);
            mut = true;
        }
        else if(nbreCliques == 2 && mut)
        {
            nbreCliques = 0;
            mute.SetBool("Press1", false);
            DeselectClickedButton(mutebutton);
            DefaultMusic();
            mut = false;
        }
        else if(nbreCliques == 2 && !mut)
        {
            nbreCliques = 1;
            mute.SetBool("Press1", true);
            if (ms5)
            {
                mus50.SetBool("Press1", false);
            }
            else if (ms10)
            {
                mus100.SetBool("Press1", false);
            }
            mut = true;
            ms10 = false;
            ms5 = false;
            music = 0f;
        }
        
    }


    public void Music50()
    {
        nbreCliques++;
        if (nbreCliques == 1)
        {
            music = 0.5f;
            mus50.SetBool("Press1", true);
            ms5 = true;
        }
        else if (nbreCliques == 2 && ms5)
        {
            nbreCliques = 0;
            mus50.SetBool("Press1", false);
            DeselectClickedButton(mus50Button);
            DefaultMusic();
            ms5 = false;
        }
        else if (nbreCliques == 2 && !ms5)
        {
            nbreCliques = 1;
            mus50.SetBool("Press1", true);
            if (mut)
            {
                mute.SetBool("Press1", false);
            }
            else if (ms10)
            {
                mus100.SetBool("Press1", false);
            }
            ms5 = true;
            mut = false;
            ms10 = false;
            music = 0.5f;
        }
        
    }

    public void Music100()
    {
        nbreCliques++;
        if (nbreCliques == 1)
        {
            music = 1f;
            mus100.SetBool("Press1", true);
            ms10 = true;
        }
        else if (nbreCliques == 2 && ms10)
        {
            nbreCliques = 0;
            mus100.SetBool("Press1", false);
            DeselectClickedButton(mus100button);
            DefaultMusic();
            ms10 = false;
        }
        else if (nbreCliques == 2 && !ms10)
        {
            nbreCliques = 1;
            mus100.SetBool("Press1", true);
            if (mut)
            {
                mute.SetBool("Press1", false);
            }
            else if (ms5)
            {
                mus50.SetBool("Press1", false);
            }
            ms5 = false;
            mut = false;
            ms10 = true;
            music = 1f;
        }

    }

    IEnumerator ModifAnim(Animator anim, bool x)
    {
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("Return", x);

    }

    private void DeselectClickedButton(GameObject button)
    {
        if (EventSystem.current.currentSelectedGameObject == button)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
       
    }

  

    private void DefaultMusic()
    {
        music = 1f;
    }

}
