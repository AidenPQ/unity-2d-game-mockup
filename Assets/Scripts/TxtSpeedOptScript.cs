using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TxtSpeedOptScript : MonoBehaviour
{
    float txtspd = 0.3f;
    int nbreCliques = 0;

    [SerializeField]
    GameObject slowbutton , normalbutton , fastbutton ;

    [SerializeField]
    Animator slow, normal, fast;


    bool mut = false, ms5 = false, ms10 = false;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("txtspd"))
        {
            txtspd = PlayerPrefs.GetFloat("txtspd");
        }
    }
    private void Start()
    {
        nbreCliques = 0;
        if (txtspd == 0.5f)
        {
            mut = true;
            slow.SetBool("Press3", true);
            nbreCliques = 1;
        }
        else if (txtspd == 0.3f)
        {
            ms5 = true;
            normal.SetBool("Press3", true);
            nbreCliques = 1;
        }
        else if (txtspd == 0.1f)
        {
            ms10 = true;
            fast.SetBool("Press3", true);
            nbreCliques = 1;
        }
    }


    public float getTxtspd()
    {
        return txtspd;
    }

    public void Slow()
    {
        nbreCliques++;
        if (nbreCliques == 1)
        {
            txtspd = 0.5f;
            slow.SetBool("Press3", true);
            mut = true;
        }
        else if (nbreCliques == 2 && mut)
        {
            nbreCliques = 0;
            slow.SetBool("Press3", false);
            DeselectClickedButton(slowbutton );
            DefaultTxtspd();
            mut = false;
        }
        else if (nbreCliques == 2 && !mut)
        {
            nbreCliques = 1;
            slow.SetBool("Press3", true);
            if (ms5)
            {
                normal.SetBool("Press3", false);
            }
            else if (ms10)
            {
                fast.SetBool("Press3", false);
            }
            mut = true;
            ms10 = false;
            ms5 = false;
            txtspd = 0.5f;
        }

    }


    public void Normal()
    {
        nbreCliques++;
        if (nbreCliques == 1)
        {
            txtspd = 0.3f;
            normal.SetBool("Press3", true);
            ms5 = true;
        }
        else if (nbreCliques == 2 && ms5)
        {
            nbreCliques = 0;
            normal.SetBool("Press3", false);
            DeselectClickedButton(normalbutton );
            DefaultTxtspd();
            ms5 = false;
        }
        else if (nbreCliques == 2 && !ms5)
        {
            nbreCliques = 1;
            normal.SetBool("Press3", true);
            if (mut)
            {
                slow.SetBool("Press3", false);
            }
            else if (ms10)
            {
                fast.SetBool("Press3", false);
            }
            ms5 = true;
            mut = false;
            ms10 = false;
            txtspd = 0.3f;
        }

    }

    public void Fast()
    {
        nbreCliques++;
        if (nbreCliques == 1)
        {
            txtspd = 0.1f;
            fast.SetBool("Press3", true);
            ms10 = true;
        }
        else if (nbreCliques == 2 && ms10)
        {
            nbreCliques = 0;
            fast.SetBool("Press3", false);
            DeselectClickedButton(fastbutton );
            DefaultTxtspd();
            ms10 = false;
        }
        else if (nbreCliques == 2 && !ms10)
        {
            nbreCliques = 1;
            fast.SetBool("Press3", true);
            if (mut)
            {
                slow.SetBool("Press3", false);
            }
            else if (ms5)
            {
                normal.SetBool("Press3", false);
            }
            ms5 = false;
            mut = false;
            ms10 = true;
            txtspd = 0.1f;
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



    private void DefaultTxtspd()
    {
        txtspd = 0.3f;
    }
}
