using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionBGM : MonoBehaviour
{
	[SerializeField] float startTransitionV = 0.0035f;  // 音量 [遷移値]
	[SerializeField] float endTransitionV = 0.0035f;    // 音量 [遷移値]
	[SerializeField] float maxV  = 1.0f;				// 音量 [最大値]
	
	[System.NonSerialized] public int endTransition = 0; // トランジション終了フラグ
	
	private AudioSource audioSouce;
	private float volume;                               // 音量 [初期値]
	private const float minV = -0.01f;                  // 音量 [最小値]

	private void Awake()
	{
		audioSouce = GetComponent<AudioSource>();
	}

	/// <summary>
	/// 次の音量遷移フェードへ移行する
	/// </summary>
	public void NextTransition()
	{
		endTransition = 2;
	}

	/// <summary>
	/// 音量を徐々に下げる
	/// </summary>
	public void StageEnd()
	{
		if (audioSouce.volume < minV)
		{
			endTransition = 3;
		}

		audioSouce.volume -= endTransitionV;
	}


	/// <summary>
	/// 音量を徐々に上げる
	/// </summary>
	public void StageStart()
	{
		if (audioSouce.volume >= maxV)
		{
			audioSouce.volume = maxV;
			endTransition = 1;
		}

		audioSouce.volume += startTransitionV;
	}
}
