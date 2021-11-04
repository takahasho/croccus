
using UnityEngine;

// キャラクター基底クラス
public class Character : MonoBehaviour
{
	[SerializeField] CharacterData data;        // キャラクターデータ[ScriptableObject]
	[SerializeField] float runPower;			// 移動速度

	protected Animator anim;
	protected BoxCollider2D col2D;
	protected Rigidbody2D rb2;

	private int	  maxHp;
	private int	  lightAttack;
	private int	  strongAttack;

	protected bool isGrouneded = false;     // 接地判定

	// コンストラクター
	protected virtual void Awake()
    {
		anim = GetComponent<Animator>();
		col2D = GetComponent<BoxCollider2D>();
		rb2 = GetComponent<Rigidbody2D>();

		// キャラクターデータを取得
		maxHp = data.MaxHp;
		lightAttack = data.LightAttack;
		strongAttack = data.StrongAttack;
	}

	/// <summary>
	/// HPが0になった時の処理
	/// </summary>
	protected virtual void Defeated()
    {


    }

	// ゲッター
	private float GetRunPower() { return runPower; }            
	private int GetMaxHp ()  { return maxHp; }
	private int GetLAttack() { return lightAttack; }
	private int GetSAttack() { return strongAttack; }
}
