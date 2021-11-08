using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// エフェクトオブジェクトにアタッチ

// エフェクト表示クラス
public class Effect : MonoBehaviour
{
    [SerializeField] Transform target = null;       // エフェクト再生位置

    // パーティクルシステム
    private readonly List<ParticleSystem> particles = new List<ParticleSystem>();    

    private WaitForSeconds wait;                    // エフェクト停止までの待ち時間
   
    private void Start()
    {
        // ターゲットがあればターゲットの位置に合わせる
        if (target != null)
            transform.position = target.position;

        for (int i = 0; i < transform.childCount; i++)
        {
            particles.Add(transform.GetChild(i).GetComponent<ParticleSystem>());
        }

        wait = new WaitForSeconds(particles[0].main.duration);
    }

    /// <summary>
    /// エフェクトを一度だけ再生
    /// </summary>
    public void Play()
    {
        //if (!particles[0].isPlaying)
        //    StartCoroutine(PlayEffect());
    }

    /// <summary>
    /// エフェクトを停止
    /// </summary>
    public void Stop()
    {
        foreach (ParticleSystem particle in particles)
            particle.Stop();
    }

    /// <summary>
    /// 再生しきったらパーティクルシステムを停止する
    /// </summary>
    private IEnumerator PlayEffect()
    {
        foreach (ParticleSystem particle in particles)
            particle.Play();

        yield return wait;

        Stop();
    }

    /// <summary>
	/// パーティクルシステムの主要なプロパティをコンソールに表示する
	/// </summary>
	static public void CheckProperties(ParticleSystem particle)
    {
        ParticleSystem.MainModule main = particle.main;

        Debug.Log(
            "パーティクルシステム名：" + particle.name +
            "パーティクルの表示時間：" + main.duration + "秒\n" +
            "ループ：" + main.loop + "\n");
        Debug.Log(
            "パーティクルシステムは" + (particle.isPlaying ? "再生中" : "停止中") + "です\n");
    }
}
