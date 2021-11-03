
using UnityEngine;
using System.Threading;

// 名前区間：My Engine
namespace MyEngine
{
	public enum Button
	{
		X = 1, 
		Y, A, B, L1, R1, L2, R2, L3, R3, BACK, START, GUIDE,
		LENGTH,
	}

	/// <summary>
	/// DInput to XInput 対照クラス
	/// </summary>
	public static class MInput
	{
		/* ----------------------------------------------

		 [ クラス使用例 ]

		 if (Input.GetKeyDown(Button.X))
			{
				Debug.Log("X");
			}

		 ------------------------------------------------- */

		// ボタンネーム
		private static readonly string[] Buttons = new string[]
		{
			"joystick button 0",
			"joystick button 1",
			"joystick button 2",
			"joystick button 3",
			"joystick button 4",
			"joystick button 5",
			"joystick button 6",
			"joystick button 7",
			"joystick button 8",
			"joystick button 9",
			"joystick button 10",
			"joystick button 11",
			"joystick button 12",
			"joystick button 13",
		};


		/// <summary>
		/// 入力したボタンをコンソールに表示
		/// </summary>
		public static void OperationCheck()
		{
			for (uint i = 0; i < Buttons.Length; i++)
			{
				if (Input.GetKeyDown(Buttons[i]))
					Debug.Log((Button)i + 1);

				Thread.Sleep(1);
			}
		}


		// 変換関数 ===================================================

		static string GetButtonName(Button type) { return Buttons[GetNumOf(type)]; }
		static int GetNumOf(Button type) { return (int)type; }
	}
}