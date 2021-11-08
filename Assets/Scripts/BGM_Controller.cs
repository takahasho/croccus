using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_Controller : MonoBehaviour
{
    TransitionBGM bgm;
    private void Start()
    {
        bgm = GetComponent<TransitionBGM>();
    }

    void FixedUpdate()
    {
        // 音量演出
        if (bgm.endTransition == 0)
            bgm.StageStart();
        if (bgm.endTransition == 2)
            bgm.StageEnd();

    }
}
