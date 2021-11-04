using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSensor : MonoBehaviour
{
    [SerializeField] GameObject Attack;
    int Counter;
    void Update()
    {
        if (Attack.activeSelf == true)
            Counter++;
        if (Counter >= 570)
        {
            Attack.SetActive(false);
            Counter = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player")
            Attack.SetActive(true);
    }
}
