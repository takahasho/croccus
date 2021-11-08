
#define UNDER_CONSTRUCTION

using UnityEngine;

// 作成中...

// エフェクトコントロール用のエンプティオブジェクトにアタッチ

// エフェクトコントロールクラス
public class EffectController : MonoBehaviour
{
    // エフェクト
    [SerializeField] Effect damageEffect;
    [SerializeField] Effect lightAttackEffect;
    [SerializeField] Effect strongAttackEffect;

#if !UNDER_CONSTRUCTION

    [SerializeField] Effect trailEffect;
#endif


    private void Update()
    {
        // TODO : テストコード
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Damage();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            StrongAttack();
        }

#if !UNDER_CONSTRUCTION

        if (Input.GetKeyDown(KeyCode.W))
        {
            LightAttack();
        }

      
            if (Input.GetKeyDown(KeyCode.R))
        {
            Trail();
        }

#endif

    }

    /// <summary>
    /// ダメージエフェクトを再生
    /// </summary>
    public void Damage() { damageEffect.Play(); }

    /// <summary>
    /// 弱攻撃エフェクトを再生
    /// </summary>
    public void LightAttack() { lightAttackEffect.Play(); }

    /// <summary>
    /// 強攻撃エフェクトを再生
    /// </summary>
    public void StrongAttack() { strongAttackEffect.Play(); }


#if !UNDER_CONSTRUCTION

 
     /// <summary>
    /// トレイルエフェクトを再生
    /// </summary>
    public void Trail() { trailEffect.Play(); }

#endif

}
