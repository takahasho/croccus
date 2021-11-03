using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ボスにアタッチ

// エンカウント処理を行うクラス
public class Encounter : MonoBehaviour
{
    [SerializeField] BoxCollider2D oneEdge = null;      // 初期値でTrigger:Tureにする壁
    [SerializeField] GameObject encounterPos = null;    // エンカウントを感知するオブジェクト
    Transform boss;                                     // ボスの座標

    private B1_Controller b1Con;
    private Animator anim;                              // ボスのアニメーター

    void Start()
    {
        boss = gameObject.transform;
        b1Con = GetComponent<B1_Controller>();
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // エンカウンターポジションとプレイヤーが衝突したら
        if (collision.tag == "Player")
        {
            anim.enabled = true;
            Destroy(encounterPos.GetComponent<BoxCollider2D>());
            b1Con.SetMoveStart(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "WALL")
        {
            oneEdge.isTrigger = false;      // 壁を感知
            Destroy(encounterPos);          // エンカウントポジションオブジェクトを削除
            Destroy(this);                  // クラス：Encounter を削除
        }
    }
}
