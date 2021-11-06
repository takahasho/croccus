using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1_Controller : Character
{
    [SerializeField] GameObject Player;
    private Transform PlayerPos;

    protected override void Awake()
    {
        base.Awake();
        RWard = new Vector3(-0.7f, 0.7f, 1);
        LWard = new Vector3( 0.7f, 0.7f, 1);
    }

    protected override void Start()
    {
        base.Start();
        PlayerPos = Player.GetComponent<Transform>();
    }

    void Update()
    {
        anim.SetBool("isWalking", moveStart);

        if (moveStart)
        {
            if (PlayerPos.position.x - transform.position.x > 1)
            {
                transform.localScale = RWard;
                transform.Translate(runPower, 0, 0);
            }
            else if (PlayerPos.position.x - transform.position.x < -1)
            {
                transform.localScale = LWard;
                transform.Translate(-runPower, 0, 0);
            }
        }
    }
}
