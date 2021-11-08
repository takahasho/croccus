using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quite : MonoBehaviour
{
	[SerializeField] ChangeScene changeScene;
	[SerializeField] TransitionBGM transitionBGM;
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			transitionBGM.NextTransition();
			changeScene.LoadNewScene(Scenes.QuiteGame);
		}

	}
}