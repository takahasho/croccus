using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] GameObject lAttack;
    [SerializeField] GameObject sAttack;
    [SerializeField] float maxCoolTime = 7f;     // 次の攻撃までの待ち時間

    Animator LAnim;
    Animator SAnim;
    Attack attack;

    Transform player;
    Transform boss;
    float distance = 0.0f;

    float coolTimeCounter = 0.0f;       // 待機時間をカウント
    bool attackStart = false;           // 攻撃開始フラグ


    void Start()
    {
        LAnim = lAttack.GetComponent<Animator>();
        SAnim = sAttack.GetComponent<Animator>();

        player = GameObject.FindWithTag("Player").transform;
        boss = GameObject.FindWithTag("BOSS").transform;

        attack = sAttack.GetComponent<Attack>();
    }
    private void FixedUpdate()
    {
        coolTimeCounter += Time.deltaTime;

    }

    void Update()
    {

        distance = Vector3.Distance(player.position, boss.position);

        if (attackStart)
        {
            if (coolTimeCounter >= maxCoolTime)
            {
                if (distance <= 10 && distance >= 6)
                {
                    attackStart = false;
                    LAnim.enabled = true;
                }
                else if (distance <= 6 && distance >= 0)
                {
                    attackStart = false;
                    //if (attack.GetIsAnimationEnd())
                    SAnim.enabled = true;
                }
            }
        }
    }

    public void LAttackStart()
    {
        attackStart = true;
    }

    public void ReSetCoolTime()
    {
        coolTimeCounter = 0.0f;
        attackStart = true;
    }


}
