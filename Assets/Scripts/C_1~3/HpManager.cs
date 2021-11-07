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
	[SerializeField] ParticleSystem[] particles = new ParticleSystem[2];

	Character player;
	Character bCharacter;
	GameObject boss;

	
	private const float endLine = 0.0001f;		// HPの下限
	private  int maxHp;                         // 自身のHP最大値



    void Start()
	{
		player = GameObject.FindWithTag("Player").GetComponent<Character>();
		boss = GameObject.FindWithTag("BOSS");
		bCharacter = boss.GetComponent<Character>();

		maxHp = GetComponent<Character>().GetMaxHp();



    }

    /// <summary>
    /// 受けたダメージ分、HPバーのインクを減らす
    /// </summary>
    public void Damage(int hitDamage)
    {
		hpBar.fillAmount -= (float)hitDamage / maxHp;

		if (hpBar.fillAmount <= endLine)
        {
			// --- ToDo キャラクターの敗北処理 ---
			Global.isImpossible = true;     // 全キャラクター移動不可

			// 全キャラクターアニメーション停止
			Destroy(bCharacter.GetAnimator());
			Destroy( player.GetAnimator());

			// 全パーティクルシステム停止
			for (int i = 0; i < particles.Length; i++)
				particles[i].Stop();

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
