using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] GameObject lAttack;
    [SerializeField] GameObject sAttack;
    [SerializeField] float maxCoolTime = 7f;     // 次の攻撃までの待ち時間
    [SerializeField] B1_Controller bCon;
    Animator LAnim;
    Animator SAnim;

    Transform player;
    Transform boss;
    float distance = 0.0f;

    float coolTimeCounter = 0.0f;       // 待機時間をカウント
    bool attackStart = false;           // 攻撃開始フラグ

    // キャッシュ用
    int onAttack;       

    void Start()
    {
        LAnim = lAttack.GetComponent<Animator>();
        SAnim = sAttack.GetComponent<Animator>();
        onAttack = Animator.StringToHash("onAttack");


        player = GameObject.FindWithTag("Player").transform;
        boss = GameObject.FindWithTag("BOSS").transform;

    }
    private void FixedUpdate()
    {
        coolTimeCounter += Time.deltaTime;

        distance = Vector3.Distance(player.position, boss.position);
    }

    void Update()
    {
        if (attackStart)
        {
            if (coolTimeCounter >= maxCoolTime)
            {
                bCon.SetMoveStatus(true);

                if (distance <= 10 && distance >= 6)
                {
                    attackStart = false;
                    bCon.SetMoveStatus(true);
                    LAnim.SetTrigger(onAttack);
                }
                else if (distance < 6 && distance >= 0)
                {
                    attackStart = false;
                    bCon.SetMoveStatus(false);
                    SAnim.SetTrigger(onAttack);
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
