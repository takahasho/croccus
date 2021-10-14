using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Controller : MonoBehaviour
{
    private Animator anim = null;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //  左が押された場合
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector3(-5, 5, 1);
            anim.SetBool("run", true);
        }
        //  右が押された場合
        else if(Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = new Vector3(5, 5, 1);
            anim.SetBool("run", true);
        }
        //  それ以外
        else
        {
            anim.SetBool("run", false);
        }
        //  ジャンプ
        if (Input.GetButton("Fire1"))
        {
            anim.SetBool("jump", true);
            anim.SetBool("run", false);
        }
        else
        {
            anim.SetBool("jump", false);
        }
        //  アタック
        if (Input.GetButton("Fire2"))
        {
            anim.SetBool("attack", true);
            anim.SetBool("run", false);
        }
        else
        {
            anim.SetBool("attack", false);
        }
        //  しゃがみ
        if (Input.GetAxis("Vertical") < 0)
        {
            anim.SetBool("down", true);
            anim.SetBool("run", false);
        }
        else
        {
            anim.SetBool("down", false);
        }
    }
}
