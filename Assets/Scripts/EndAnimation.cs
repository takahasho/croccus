using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnimation : MonoBehaviour
{
    [SerializeField] AttackController attackCon;
    [SerializeField] B1_Controller bCon;

    public void SetMoveStatus()
    {
        bCon.SetMoveStatus(true);
    }

    public void ReSetCoolTime()
    {
        attackCon.ReSetCoolTime();
    }
}
