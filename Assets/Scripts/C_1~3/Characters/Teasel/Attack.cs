
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
    [SerializeField] Animator targtAnim;

    private AudioSource audioSource;

    private int attackPawer;            // 攻撃力
    private string targetTag;           // ターゲットタグ

    int damage;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        targetTag = target.tag;
        damage = Animator.StringToHash("damage");

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
        if (collision.gameObject.CompareTag(targetTag))
        {
            targetHp.Damage(attackPawer);  // HPを減らす
            targtAnim.SetTrigger(damage);
        }
    }
    /// <summary>
    /// 効果音を一度だけ鳴らす
    /// </summary>
    public void PlaySE()
    {
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(audioSource.clip);
    }
    public void PlaySE_Repeat()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

    public string GetTargetTag { get; }
    public Attack.Type AttackType { get; }
}