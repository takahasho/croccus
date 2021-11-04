using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// シーンリスト
public enum Scenes
{
	Title = 0,
	StageOne,
	StageTwo,
	StageThree,
	GameOver,

	Ending,
}

// シーン遷移クラス
public class ChangeScene : MonoBehaviour
{
	[SerializeField] float transitionTime = 1.5f;
	[SerializeField] private Animator anim;
	[SerializeField] bool isGameOver = false;       // true：ゲームオーバーシーン

	private static int beforeSceneIndex;           // ひとつ前にプレイしていたシーン
	private static int MaxSceneNum;                // シーン総数

	// ゲームオーバーシーンのフェードアウト時間
	private const float TransitionTime_GameOver = 0.5f;


	public float TransitionTime { get;}

	// ゲーム起動時に一度だけ実行する
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void StartUp()
	{
		beforeSceneIndex = Global.EXC;								// 例外値を設定
		MaxSceneNum = SceneManager.sceneCountInBuildSettings;		// シーン総数を記録
	}
	private void Start()
	{
		// ゲームオーバーシーンでのフェードアウト時間：0.5f
		if (isGameOver)
		{
			transitionTime = TransitionTime_GameOver;
			anim.SetBool("isGameOver", true);
		}
	}

#if DEBUG_MODE
    void Update()
	{
		// 
		// ToDo テストコード
		if (Input.GetKeyDown(KeyCode.F1))
			LoadNewScene();                     // 次のシーンへ

		if (Input.GetKeyDown(KeyCode.F2))
			LoadBackScene();                    // 前のシーンへ

		if (Input.GetKeyDown(KeyCode.F3))
		    LoadNowScene();						// 現在のシーンをリロード

		if (Input.GetKeyDown(KeyCode.F4))
			LoadNewScene(Scenes.StageThree);    // 指定シーンへ (シーン3)


		if (Input.GetKeyDown(KeyCode.F5))       // アクティブなシーンを int型 で記録
			Record();

		if (Input.GetKeyDown(KeyCode.F6))
			Return();                           // 直前にアクティブだったシーンへ戻る
	}
#endif

	// フェードアニメーションを制御
	private IEnumerator Load(int buildIndex)
	{
		anim.SetTrigger("Start");
		yield return new WaitForSeconds(transitionTime);
		SceneManager.LoadScene(buildIndex);
	}

	/// <summary>
	/// 直前にアクティブだったシーンへ戻る
	/// </summary>
	public void Return()
	{
        if (beforeSceneIndex <= Global.EXC || beforeSceneIndex > MaxSceneNum)
        {
            Debug.LogError("例外値を算出\nインデックスが正しい値ではありません");
            return;
        }

        StartCoroutine(Load(beforeSceneIndex));
	}

	/// <summary>
	/// アクティブなシーンを int型 で記録
	/// </summary>
	public void Record()
	{
		beforeSceneIndex = SceneManager.GetActiveScene().buildIndex;

		Debug.Log("ビルドインデックス[ " + beforeSceneIndex + " ]を記録しました");	
	}

	/// <summary>
	/// 現在のシーンを再読み込み
	/// </summary>
	public void LoadNowScene()
	{
		StartCoroutine(Load(SceneManager.GetActiveScene().buildIndex));
	}

	/// <summary>
	/// 引数あり：指定シーンを読み込む
	/// </summary>
	public void LoadNewScene(Scenes nextScene) 
	{
		StartCoroutine(Load((int)nextScene));
	}

	/// <summary>
	/// 引数なし：　ビルドインデックス + 1を読み込む
	/// 最後のシーンで呼ばれたら最初のシーンに戻る
	/// </summary>
	public void LoadNewScene()
	{
		int buildIndx = SceneManager.GetActiveScene().buildIndex;

		// 最後のシーンで関数が呼ばれたら
		if (buildIndx == MaxSceneNum - 1)
		{
			// 最初のシーン(タイトル)へ遷移
			StartCoroutine(Load(0));    return;
		}

		StartCoroutine(Load(buildIndx + 1));
	}

	/// <summary>
	/// ビルドインデックス - 1を読み込む
	/// </summary>
	public void LoadBackScene()
	{
		int buildIndx = SceneManager.GetActiveScene().buildIndex;

		// 最初のシーンで呼ばれたら
		if (buildIndx == 0)
		{
			Debug.LogError("例外値を算出\n現在のシーンはビルドインデックス：0 です");
			return;
		}

		StartCoroutine(Load(buildIndx - 1));
	}
}