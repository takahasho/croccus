using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// キャラクターの子オブジェクトにアタッチ



// 攻撃制御クラス
public class Attack : MonoBehaviour
{
    // 攻撃タイプ
    public enum Type
    {
        LIGHT_ATTACK,
        STRONG_ATTACK,
    }

    [SerializeField] Type attckType;        // 攻撃タイプ
    [SerializeField] Collider2D target;     // 攻撃対象
    [SerializeField] HpManager targetHp;    // ターゲットHP
    

    public Collider2D col2D;
    public Animator anim;
    private AudioSource audioSource;

    private int attackPawer;

    private void Awake()
    {
        col2D = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        switch (attckType)
        {
            case Type.LIGHT_ATTACK:
                attackPawer = transform.root.gameObject.GetComponent<Character>().GetLAttack();
                break;

            case Type.STRONG_ATTACK:
                attackPawer = transform.root.gameObject.GetComponent<Character>().GetSAttack();
                break;

            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ターゲットと接触したら
        if (collision.tag == target.tag)
            targetHp.Damage(attackPawer);  // HPを減らす
    }
    /// <summary>
    /// 効果音を一度だけ鳴らす
    /// </summary>
    public void PlaySE()
    {
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(audioSource.clip);
    }

    public Collider2D GetTarget() { return target; }
}
