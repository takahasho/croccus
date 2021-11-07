using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SampleScript : MonoBehaviour
{

    [SerializeField] GameObject obj;
    Animator anim;

    private void Start()
    {
        anim = obj.GetComponent<Animator>();
    }

}
