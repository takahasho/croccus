using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleDirector : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButton("Fire1"))
            SceneManager.LoadScene("C_Select");
        if (Input.GetButton("Fire2"))
        {
            //  終了
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}
