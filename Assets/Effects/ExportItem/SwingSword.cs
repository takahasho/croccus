using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 通常攻撃用の剣オブジェクトにアタッチ

// 剣撃コントロールクラス[通常攻撃用]
public class SwingSword : MonoBehaviour
{
    [SerializeField] Effect lightAttackEffect;

    public void Swing()
    {
        lightAttackEffect.Play();
    }
}
