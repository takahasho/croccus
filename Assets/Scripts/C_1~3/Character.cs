using System.Collections.Generic;
using UnityEngine;
using MyEngine;

// キャラクター基底クラス
public class Character : MonoBehaviour
{
	[SerializeField] protected float runPower = 0.02f;	// 移動速度
	[SerializeField] Type type;                         // キャラクタータイプ
	
	protected Animator anim;
	protected BoxCollider2D col2D;
	protected Rigidbody2D rb2;
	protected SpriteRenderer render;
	protected HpManager hpManager;

	/// <summary>
	/// HP最大値
	/// </summary>
	private int	  maxHp;
	/// <summary>
	/// 攻撃力[弱攻撃]
	/// </summary>
	private int	  lightAttack;
	/// <summary>
	/// 攻撃力[強攻撃] 
	/// </summary>
	private int	  strongAttack;

	protected bool jumping = false;		    // 接地判定
	public bool moveStart = false;          // 移動フラグ


	// フリップ用ベクトル
	protected Vector3 RWard;
	protected Vector3 LWard;
	
	// コンストラクター
	protected virtual void Awake()
	{
		anim	= GetComponent<Animator>();
		col2D	= GetComponent<BoxCollider2D>();
		rb2		= GetComponent<Rigidbody2D>();
		render	= GetComponent<SpriteRenderer>();
		hpManager =  GetComponent<HpManager>();
	}

	protected virtual void Start()
	{
		// キャラクターデータを取得
		CharacterData characterData = CGenerator.Instance().Spawn(type);
		maxHp = characterData.MaxHp;
		lightAttack = characterData.LightAttack;
		strongAttack = characterData.StrongAttack;
	}


	// ゲッター
	public float GetRunPower() { return runPower; }
	public int GetMaxHp ()  { return maxHp; }
	public int GetLAttack() { return lightAttack; }
	public int GetSAttack() { return strongAttack; }
	public Animator GetAnimator() { return anim; }
}
