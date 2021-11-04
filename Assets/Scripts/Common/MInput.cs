
using UnityEngine;
using System.Threading;

// 名前区間：My Engine
namespace MyEngine
{
    /// <summary>
    /// DInput to XInput 対照クラス
    /// </summary>
    public static class Button
    {
		/* ----------------------------------------------

		[ クラス使用例 ]

		if (Input.GetKeyDown(Button.X))
        {
            Debug.Log("X");
        }

		------------------------------------------------- */

		#region ボタンネーム[DInput]
		public const string joystick = "joystick button ";
		public const string X		  = joystick + "0";
		public const string Y		  = joystick + "1";
		public const string A		  = joystick + "2";
		public const string B		  = joystick + "3";
		public const string L1		  = joystick + "4";
		public const string R1		  = joystick + "5";
		public const string L2		  = joystick + "6";
		public const string R2		  = joystick + "7";
		public const string L3		  = joystick + "8";
		public const string R3		  = joystick + "9";
		public const string BACK	  = joystick + "10";
		public const string START	  = joystick + "11";
		public const string GUIDE	  = joystick + "12";
		#endregion

	}

	/// <summary>
	/// MyInput デバッグクラス
	/// </summary>
	public static class MInput
	{
		// ボタンネーム[DInput]
		private static readonly string[] DButtons = new string[]
		{
			Button.X,		Button.Y,		Button.A,		Button.B, 
			Button.L1,		Button.R1,		Button.L2,		Button.R2,		Button.L3,		Button.R3,
			Button.BACK,	Button.START,	Button.GUIDE,
		};

		// ボタンネーム[XInput]
		private static readonly string[] XButtons = new string[]
		{
			"X", "Y","A", "B", "L1", "R1", "L2", "R2", "L3", "R3", "BACK", "START", "GUIDE",
		};


		/// <summary>
		/// 入力したボタンをコンソールに表示[XInput]
		/// </summary>
		public static void OperationCheckX()
		{
			for (uint i = 0; i < DButtons.Length; i++)
			{
				if (Input.GetKeyDown(DButtons[i]))
				{
					Debug.Log(XButtons[i]);
				}
                Thread.Sleep(1);
			}
		}
		/// <summary>
		/// 入力したボタンをコンソールに表示[DInput][Unity]
		/// </summary>
		public static void OperationCheckDU()
		{
			for (uint i = 0; i < DButtons.Length; i++)
			{
				if (Input.GetKeyDown(DButtons[i]))
					Debug.Log(DButtons[i]);

				Thread.Sleep(1);
			}
		}
		/// <summary>
		/// 入力したボタンをコンソールに表示[DInput][Elecom]
		/// </summary>
		public static void OperationCheckDE()
		{
			for (uint i = 0; i < DButtons.Length; i++)
			{
				if (Input.GetKeyDown(DButtons[i]))
					Debug.Log("Button"+ (i + 1));

				Thread.Sleep(1);
			}
		}
	}
}