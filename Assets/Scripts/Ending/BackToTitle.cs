using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToTitle : MonoBehaviour
{
    [SerializeField] ChangeScene levelloader;


    private void Update()
    {
        if (!Global.isImpossible)
        {
            if (Input.anyKeyDown)
            {
                levelloader.LoadNewScene(Scenes.Title);
                Global.isImpossible = false;
            }
        }
    }

}
