using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TitleDirector : MonoBehaviour
{
    float counter = 0;
    bool button = false;
    [SerializeField] int time = 1200;
    [SerializeField] GameObject black;
    void Start()
    {
        counter = 0;
        button = false;
     
    }
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            button = true;
        }
        if (button)
        {
            counter++;
            black.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, counter * 0.001f);
            if (counter >= time)
                SceneManager.LoadScene("StageOne");
        }
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
