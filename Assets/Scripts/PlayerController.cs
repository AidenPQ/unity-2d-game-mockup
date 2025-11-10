using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerController : MonoBehaviour
{
    public bool haveKey = false;
    public bool trapDesactivate = false;
    public bool IsDeath = false;

     private Animator anim;

    public float speed = 2f;

    [SerializeField] Image KeyPossess;

    [SerializeField] Sprite TheKey;

    [SerializeField] Sprite NoKey;

    private bool lookRight = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
        if(PlayerPrefs.GetInt("load") == 1)
        {
            float x = PlayerPrefs.GetFloat("posx");
            float y = PlayerPrefs.GetFloat("posy");
            float z = PlayerPrefs.GetFloat("posz");
            if(PlayerPrefs.GetInt("havekey") == 1)
            {
                haveKey = true;
            }
            else
            {
                haveKey = false;
            }
            transform.position = new Vector3(x, y, z);
            PlayerPrefs.SetInt("load", 0);
        }
        else if(PlayerPrefs.GetInt("origin") == 1 || PlayerPrefs.GetInt("bscene") == 1)
        {
            float x = PlayerPrefs.GetFloat("x");
            float y = PlayerPrefs.GetFloat("y");
            float z = PlayerPrefs.GetFloat("z");
            if (PlayerPrefs.GetInt("hvky") == 1)
            {
                haveKey = true;
            }
            else
            {
                haveKey = false;
            }
            transform.position = new Vector3(x, y, z);
            PlayerPrefs.SetInt("origin", 0);
            PlayerPrefs.SetInt("bscene", 0);
        }
    }



    // Update is called once per frame
    void Update()
    {
        
        if (haveKey)
        {
            KeyPossess.sprite = TheKey;
        }
        else if (!haveKey)
        {
            KeyPossess.sprite = NoKey;
        }

        if (IsDeath)
        {
            speed = 0f;
        }

        float move = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * speed * move * Time.deltaTime);
        anim.SetFloat("speed", Mathf.Abs(move));
        if(move > 0 && !lookRight)
        {
            Flip();
        }
        else if(move < 0 && lookRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        lookRight = !lookRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


}
