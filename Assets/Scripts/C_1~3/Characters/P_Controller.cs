using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyEngine;

public class P_Controller : MonoBehaviour
{
    private Animator anim = null;
    bool jumpCheck = false;
    [SerializeField] float jumpPower = 600f;
    [SerializeField] float runPower = 0.02f;
    [SerializeField] GameObject AttackBox;
    Rigidbody2D rb2;

    // Start is called before the first frame update
    void Start()
    {
        AttackBox.SetActive(false);
        anim = GetComponent<Animator>();
        rb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //  左が押された場合
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector3(-5, 5, 1);
            if (!jumpCheck)
                anim.SetBool("run", true);
        }
        //  右が押された場合
        else if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = new Vector3(5, 5, 1);
            if (!jumpCheck)
                anim.SetBool("run", true);
        }
        //  それ以外
        else
        {
            anim.SetBool("run", false);
        }



        //  ジャンプ
        if (Input.GetButton("Fire1") && !jumpCheck)
        {
            this.rb2.AddForce(Vector2.up * jumpPower);
            jumpCheck = true;
            anim.SetBool("jump", true);
            anim.SetBool("run", false);
        }
            
        //  アタック
        if (Input.GetButton("Fire2")&&!jumpCheck)
        {
            AttackBox.SetActive(true);
            anim.SetBool("attack", true);
            anim.SetBool("run", false);
        }
        else
        {
            AttackBox.SetActive(false);
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
        if (anim.GetBool("down") == false && anim.GetBool("attack") == false)
            this.rb2.position += new Vector2(Input.GetAxis("Horizontal") * runPower, 0);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == ("W_BOTTOM"))
        {
            anim.SetBool("jump", false);
            jumpCheck = false;
        }
    }
}

