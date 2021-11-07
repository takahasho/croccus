
using UnityEngine;
using MyEngine;

public class TitleDirector : MonoBehaviour
{
    [SerializeField] ChangeScene changeScene;
    [SerializeField] TransitionBGM transitionBGM;

    private SE se;
    private const int gameStart = 0;        // 効果音を指定
    private const int cancel = 1;           // 効果音を指定


    private void Awake()
    {
        se = GetComponent<SE>();
    }

    void Update()
    {
        //    if (Input.GetButton("Fire1"))
        //        SceneManager.LoadScene("C_Select");

        if (Input.GetKeyDown(Button.START))
        {
            transitionBGM.NextTransition();
            se.PlaySE(gameStart);
            se.isImpossible = true;
            changeScene.LoadNewScene(Scenes.StageOne);
        }
        if (Input.GetKeyDown(Button.BACK))
        {
            transitionBGM.NextTransition();
            se.PlaySE(cancel);
            changeScene.LoadNewScene(Scenes.QuiteGame);
        }
    }
}
