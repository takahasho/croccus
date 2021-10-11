using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Global;

// シーンリスト
public enum Scenes
{
    Title = 0,
    StageOne,
    StageTwo,
    StageThree,


    Ending,
}


// シーン遷移クラス
public class ChangeScene : MonoBehaviour
{
    [SerializeField] float transitionTime = 1f;
    [SerializeField] private Animator transition;


    private static int beforeSceneIndex = Common.EXC;           // ひとつ前にプレイしていたシーン
    public static int MaxSceneNum = Common.EXC;                 // シーン総数


    public float GetTransitionTime { get { return transitionTime; } }

   
    private void Update()
    {
        // テスト $$$
        if (Input.GetKeyDown(KeyCode.S))
            LoadNewScene();     // 次のシーンへ

        if (Input.GetKeyDown(KeyCode.A))
            LoadBeforeScene();     // ビルドインデックスひとつ前のシーンへ

        if (Input.GetKeyDown(KeyCode.W))
            LoadNowScene();     // 現在のシーンをリロード

        if (Input.GetKeyDown(KeyCode.Z))
            LoadNewScene(Scenes.StageThree);     // 指定シーンへ(シーン3)

    }

    /// <summary>
    /// 前のシーンに戻る
    /// </summary>
    public void Return()
    {
        // デバッグ
        if (beforeSceneIndex == Common.EXC || beforeSceneIndex > SceneManager.sceneCount)
        {
            Debug.Log("例外値を算出\n");
            Debug.Log("インデックスが正しい値ではありません");
            return;
        }

        StartCoroutine(Load(beforeSceneIndex));
    }

    /// <summary>
    /// アクティブなシーンを記録
    /// </summary>
    public void Record()
    {
        beforeSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    /// <summary>
    /// 現在のシーンを再読み込み
    /// </summary>
    public void LoadNowScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// 引数あり：指定シーンを読み込む
    /// </summary>
    public void LoadNewScene(Scenes nextScene) 
    {
        StartCoroutine(Load((int)nextScene));
    }

    /// <summary>
    /// 引数なし：ビルドインデックス + 1を読み込む
    /// </summary>
    public void LoadNewScene()
    {
        int buildIndx = SceneManager.GetActiveScene().buildIndex;

        StartCoroutine(Load(buildIndx + 1));
    }

    /// <summary>
    /// 引数なし：ビルドインデックス - 1を読み込む
    /// </summary>
    public void LoadBeforeScene()
    {
        int buildIndx = SceneManager.GetActiveScene().buildIndex;

        StartCoroutine(Load(buildIndx - 1));
    }

    private IEnumerator Load(int buildIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(buildIndex);
    }
}
