using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyEngine;

public class P_Controller : Character
{
    [SerializeField] Attack attackObj;
    [SerializeField] float jumpPower = 600f;

    Vector2 newPos = new Vector2();

    // キャッシュ用変数
    private int run = Animator.StringToHash("run");
    private int jump = Animator.StringToHash("jump");
    private int squat = Animator.StringToHash("squat");
    private int attack = Animator.StringToHash("attack");
    private int damage = Animator.StringToHash("damage");

    private string horizontal = "Horizontal";
    private string Vertical = "Vertical";

    private string W_BOTTOM = "W_BOTTOM";
    private string B_WEPON = "B_WEPON";

    protected override void Awake()
    {
        base.Awake();
        RWard = new Vector3(-5.0f, 5.0f, 1.0f);
        LWard = new Vector3(5.0f, 5.0f, 1.0f);
        moveStart = true;
    }

    protected override void Start()
    {
        base.Start();
        hpManager = GetComponent<HpManager>();
    }

    private void FixedUpdate()
    {
        //  ジャンプ
        if (Input.GetKey(Button.CROSS) && !jumping && anim.GetBool(squat) == false)
        {
            rb2.AddForce(Vector2.up * jumpPower);
            jumping = true;

            anim.SetBool(jump, true);
            anim.SetBool(run, false);

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!Global.isImpossible)
        {
            if (moveStart)
            {
                if (anim.GetBool(damage) == false)
                {
                    
                    //  左が押された場合

                    if (Input.GetAxis(horizontal) < 0)
                    {
                        transform.localScale = RWard;
                        if (!jumping)
                            anim.SetBool(run, true);
                    }
                    //  右が押された場合
                    else if (Input.GetAxis(horizontal) > 0)
                    {
                        transform.localScale = LWard;
                        if (!jumping)
                            anim.SetBool(run, true);
                    }
                    //  それ以外
                    else
                    {
                        anim.SetBool(run, false);
                    }


                    //  アタック
                    if (Input.GetKey(Button.CIRCLE) && !jumping && anim.GetBool(squat) == false)
                    {
                        anim.SetBool(attack, true);
                        anim.SetBool(run, false);
                    }
                    else
                    {
                        anim.SetBool(attack, false);
                    }

                    //  しゃがみ
                    if (Input.GetAxis(Vertical) == -1 && !jumping)
                    {
                        anim.SetBool(squat, true);
                        anim.SetBool(run, false);
                    }
                    else
                    {
                        anim.SetBool(squat, false);
                    }
                    if (anim.GetBool(squat) == false && anim.GetBool(attack) == false)
                    {
                        newPos.x = Input.GetAxis(horizontal) * runPower;
                        rb2.position += newPos;
                    }
                }
            }
        }
    }

    private void PlaySE()
    {
        attackObj.PlaySE_Repeat();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(W_BOTTOM))
        {
            anim.SetBool(jump, false);
            jumping = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 武器とあたったらダメージ時のアニメーションを再生
        if (collision.gameObject.CompareTag(B_WEPON))
        {
            moveStart = false;
        }
    }
    public void Move()
    {
        moveStart = true;
    }
}

