using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StoryText : MonoBehaviour
{
	protected string[] SetSentence(Scenes scene)
	{
		switch (scene)
		{
			case Scenes.StageOne:	return stageOneSentence;
			case Scenes.StageTwo:	return stageTwoSentence;
			case Scenes.StageThree: return stageThereeSentence;
			case Scenes.Ending:		return stageEndingSentence;
			default:				return null;
		}
	}

	private string[] stageOneSentence =
	{
		
	};

	private string[] stageTwoSentence =
	{

	};

	private string[] stageThereeSentence =
	{

	};

	protected string[] stageEndingSentence =
	{

	};

}
