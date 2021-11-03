using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1_Controller : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] float runPower = 0.005f;
    Transform PlayerPos;

    bool moveStart = false;                 // 移動フラグ

    // Start is called before the first frame update
    void Start()
    {
        PlayerPos=Player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveStart)
        {
            if (PlayerPos.position.x - transform.position.x > 1)
            {
                transform.localScale = new Vector3(-0.7f, 0.7f, 1);
                transform.Translate(runPower, 0, 0);
            }
            else if (PlayerPos.position.x - transform.position.x < -1)
            {
                transform.localScale = new Vector3(0.7f, 0.7f, 1);
                transform.Translate(-runPower, 0, 0);
            }
        }
    }

    // ゲッター/セッター
    public bool GetMoveStart() { return moveStart; }
    public void SetMoveStart(bool flag) { moveStart = flag; }
}
