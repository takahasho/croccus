using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyEngine;

public class P_Controller : Character
{
    [SerializeField] float jumpPower = 600f;
    [SerializeField] GameObject AttackBox;

    protected override void Awake()
    {
        base.Awake();
        RWard = new Vector3(-5.0f, 5.0f, 1.0f);
        LWard = new Vector3(5.0f, 5.0f, 1.0f);
    }

    protected override void Start()
    {
        base.Start();
        AttackBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //  左が押された場合
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = RWard;
            if (!isGrouneded)
                anim.SetBool("run", true);
        }
        //  右が押された場合
        else if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = LWard;
            if (!isGrouneded)
                anim.SetBool("run", true);
        }
        //  それ以外
        else
        {
            anim.SetBool("run", false);
        }



        //  ジャンプ
        if (Input.GetKey(Button.CROSS) && !isGrouneded)
        {
            rb2.AddForce(Vector2.up * jumpPower);
            isGrouneded = true;
            anim.SetBool("jump", true);
            anim.SetBool("run", false);
        }
            
        //  アタック
        if (Input.GetKey(Button.CIRCLE)&&!isGrouneded)
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
        if (Input.GetAxis("Vertical") == -1)
        {
            anim.SetBool("down", true);
            anim.SetBool("run", false);
        }
        else
        {
            anim.SetBool("down", false);
        }
        if (anim.GetBool("down") == false && anim.GetBool("attack") == false)
            rb2.position += new Vector2(Input.GetAxis("Horizontal") * runPower, 0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == ("W_BOTTOM"))
        {
            anim.SetBool("jump", false);
            isGrouneded = false;
        }
    }
}

