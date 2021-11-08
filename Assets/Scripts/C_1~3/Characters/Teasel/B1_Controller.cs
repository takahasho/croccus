using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1_Controller : Character
{
    [SerializeField] GameObject Player;
    [SerializeField] Animator[] bWeponAnim = new Animator[2];               // 武器オブジェクト
    [SerializeField] AudioSource[] bWeponAnimAudio = new AudioSource[2];    // 武器オーディオ
    private Transform PlayerPos;

    private int walk = Animator.StringToHash("walk");
    private int damage = Animator.StringToHash("damage");

    protected override void Awake()
    {
        base.Awake();
        RWard = new Vector3(-0.7f, 0.7f, 1);
        LWard = new Vector3(0.7f, 0.7f, 1);

    }

    protected override void Start()
    {
        base.Start();
        PlayerPos = Player.GetComponent<Transform>();
    }

    private void Update()
    {
        if (!Global.isImpossible)
        {
            if (moveStart)
            {
                if (PlayerPos.position.x - transform.position.x > 1)
                {
                    anim.SetBool(walk, true);
                    transform.localScale = RWard;
                    transform.Translate(runPower, 0, 0);
                }
                else if (PlayerPos.position.x - transform.position.x < -1)
                {
                    anim.SetBool(walk, true);
                    transform.localScale = LWard;
                    transform.Translate(-runPower, 0, 0);
                }
            }
            else
            {
                anim.SetBool(walk, false);
            }
        }
    }

    // 移動開始
    public void Walk()
    {
        moveStart = true;
    }
    public void SetMoveStatus(bool status)
    {
        moveStart = status;
    }

    public void Defeat()
    {
        for (int i = 0; i < bWeponAnim.Length; i++)
        {
            bWeponAnim[i].enabled = false;
            bWeponAnimAudio[i].enabled = false;
            anim.enabled = false;
        }
    }
}
