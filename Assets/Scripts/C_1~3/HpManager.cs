using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// キャラクターにアタッチ

// HP管理クラス
public class HpManager : MonoBehaviour
{
	[SerializeField] Image hpBar;		// HPバー

	const float endLine = 0.0001f;		// HPの下限


	void Start()
	{
	}

	public void Damage(float damage)
    {
		hpBar.fillAmount -= damage;

		if (hpBar.fillAmount <= endLine)
        {
			// ToDo キャラクターのデストラクターを呼ぶ
        }
	}
}
