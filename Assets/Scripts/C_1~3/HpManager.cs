
using UnityEngine;
using UnityEngine.UI;

// HP管理クラス
public class HpManager : MonoBehaviour
{
	[SerializeField] Image hpBar;				// HPバー
	private const float endLine = 0.0001f;		// HPの下限
	private int maxHp;							// 自身のHP最大値

	void Start()
	{

	}

	/// <summary>
	/// 受けたダメージ分、HPバーのインクを減らす
	/// </summary>
	public void Damage(int hitDamage)
    {
		hpBar.fillAmount -= (float)hitDamage / maxHp;

		if (hpBar.fillAmount <= endLine)
        {
			// ToDo キャラクターの敗北処理
        }
	}
}
