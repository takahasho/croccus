using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1_Controller : MonoBehaviour
{
    [SerializeField] GameObject Player;
    Transform PlayerPos, BosPos;
    Rigidbody2D rb2;
    [SerializeField] float runPower = 0.005f;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPos=Player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPos.position.x - transform.position.x > 0)
        {
            transform.localScale = new Vector3(-0.7f, 0.7f, 1);
            transform.Translate(runPower, 0, 0);
        }else
        {
            transform.localScale = new Vector3(0.7f, 0.7f, 1);
            transform.Translate(-runPower, 0, 0);
        }
    }
}
