
using UnityEngine;

public class OnQuiteScene : MonoBehaviour
{
	private void Update()
	{
		//  終了
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif

	}
}
