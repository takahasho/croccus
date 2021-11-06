using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyEngine;

public class SE : MonoBehaviour
{
    [SerializeField] List<AudioClip> clips = new List<AudioClip>();
    [System.NonSerialized] public AudioSource audioSource;

    /// <summary>
    /// true：ミュート中
    /// </summary>
    public bool isImpossible = false;       

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// SEを再生する
    /// </summary>
    public void PlaySE(int audioNumber)
    {
        if (!audioSource.isPlaying && !isImpossible)
            audioSource.PlayOneShot(clips[audioNumber]);
    }
}
