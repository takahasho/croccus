using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ボスにアタッチ

// エンカウント処理を行うクラス
public class Encounter : MonoBehaviour
{
    [SerializeField] GameObject LightAttack;
    [SerializeField] BoxCollider2D oneEdge = null;      // 初期値でTrigger:Tureにする壁
    [SerializeField] GameObject encounterPos = null;    // エンカウントを感知するオブジェクト

    private AttackController attackCon;
    private Transform boss;                             // ボスの座標

    private B1_Controller b1Con;
    private Animator bossAnim;                          // ボスのアニメーター

    private void Awake()
    {
        boss = gameObject.transform;
        b1Con = GetComponent<B1_Controller>();
        bossAnim = GetComponent<Animator>();

        bossAnim.enabled = false;
    }

    void Start()
    {
        Transform root = this.transform.root.gameObject.transform;
        // AttackControllerを入手
        for (int i = 0; i < root.childCount; i++)
        {
            AttackController attackCon = root.GetChild(i).GetComponent<AttackController>();
            if (attackCon != null)
                this.attackCon = attackCon;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // エンカウンターポジションとプレイヤーが衝突したら
        if (collision.tag == "Player")
        {
            bossAnim.enabled = true;
            Destroy(encounterPos);          // エンカウントポジションオブジェクトを削除
            b1Con.Walk();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "WALL")
        {
            LightAttack.SetActive(true);
            oneEdge.isTrigger = false;      // 壁を感知
            attackCon.LAttackStart();        // 攻撃開始
            Resources.UnloadUnusedAssets();
            System.GC.Collect();
            Destroy(this);                  // クラス：Encounter を削除
        }
    }
}
