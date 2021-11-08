using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// キャラクターにアタッチ

// HP管理クラス
public class HpManager : MonoBehaviour
{
	[SerializeField] Image hpBar;               // HPバー
	[SerializeField] Type type;
	[SerializeField] ChangeScene levelloader;
	[SerializeField] B1_Controller b1Con;
	[SerializeField] TransitionBGM transitionBGM;

	Character player;
	GameObject boss;

	
	private const float endLine = 0.0001f;		// HPの下限
	private  int maxHp;                         // 自身のHP最大値



    void Start()
	{
		player = GameObject.FindWithTag("Player").GetComponent<Character>();
		boss = GameObject.FindWithTag("BOSS");

		maxHp = GetComponent<Character>().GetMaxHp();
	}

    /// <summary>
    /// 受けたダメージ分、HPバーのインクを減らす
    /// </summary>
    public void Damage(int hitDamage)
    {
		//effectCon.Damage();
		hpBar.fillAmount -= (float)hitDamage / maxHp;

		if (hpBar.fillAmount <= endLine)
        {
			// --- ToDo キャラクターの敗北処理 ---
			Global.isImpossible = true;     // 全キャラクター移動不可

			// 全キャラクターアニメーション停止
			player.GetAnimator().enabled = false;
			b1Con.Defeat();

			transitionBGM.NextTransition();

			switch (type)
            {
				case Type.PLAYER:
					levelloader.LoadNewScene(Scenes.GameOver);
					break;

				case Type.TEASEL:
					levelloader.LoadNewScene(Scenes.Ending);
					break;
			}

		}
	}

}
