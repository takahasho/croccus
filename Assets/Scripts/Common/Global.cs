﻿
#if DUMMY
#undef DUMMY
#endif




public static class Global
{
	// グローバル定数 ===================================================

	public const int NULL = 0;

	/// <summary> 例外値 </summary>
	public const int EXC = -1;


	// グローバル変数 ===================================================

	/// <summary> true：入力不可 </summary>
	public static bool isImpossible = true;    



}

#region デバッグクラスを制御する

#if !DEBUG_MODE
public static class Debug
{ 
// 拡張部 -----------------------------------------------------------------------------------------------

	// DEBUG_MODEを定義している場合のみ、デバッグログを表示する処理 
	// (リリース時にデバッグログの処理をさせないために作成)
	// DUMMYは未定義とする

	[Conditional("DUMMY")] public static void Assert(bool condition, string message, Object context) { }
	[Conditional("DUMMY")] public static void Assert(bool condition, object message, Object context) { }
	[Conditional("DUMMY")] public static void Assert(bool condition, string message) { }
	[Conditional("DUMMY")] public static void Assert(bool condition, object message) { }
	[Conditional("DUMMY")] public static void Assert(bool condition, Object context) { }
	[Conditional("DUMMY")] public static void Assert(bool condition) { }
	[Conditional("DUMMY")] public static void Assert(bool condition, string format, params object[] args) { }
	[Conditional("DUMMY")] public static void AssertFormat(bool condition, string format, params object[] args) { }
	[Conditional("DUMMY")] public static void AssertFormat(bool condition, Object context, string format, params object[] args) { }
	[Conditional("DUMMY")] public static void Break() { }
	[Conditional("DUMMY")] public static void ClearDeveloperConsole() { }
	[Conditional("DUMMY")] public static void DebugBreak() { }
	[Conditional("DUMMY")] public static void DrawLine(Vector3 start, Vector3 end, Color color, float duration, bool depthTest) { }
	[Conditional("DUMMY")] public static void DrawLine(Vector3 start, Vector3 end, Color color, float duration) { }
	[Conditional("DUMMY")] public static void DrawLine(Vector3 start, Vector3 end) { }
	[Conditional("DUMMY")] public static void DrawLine(Vector3 start, Vector3 end, Color color) { }
	[Conditional("DUMMY")] public static void DrawRay(Vector3 start, Vector3 dir, Color color, float duration) { }
	[Conditional("DUMMY")] public static void DrawRay(Vector3 start, Vector3 dir, Color color, float duration, bool depthTest) { }
	[Conditional("DUMMY")] public static void DrawRay(Vector3 start, Vector3 dir) { }
	[Conditional("DUMMY")] public static void DrawRay(Vector3 start, Vector3 dir, Color color) { }
	[Conditional("DUMMY")] public static void Log(object message) { }
	[Conditional("DUMMY")] public static void Log(object message, Object context) { }
	[Conditional("DUMMY")] public static void LogAssertion(object message, Object context) { }
	[Conditional("DUMMY")] public static void LogAssertion(object message) { }
	[Conditional("DUMMY")] public static void LogAssertionFormat(Object context, string format, params object[] args) { }
	[Conditional("DUMMY")] public static void LogAssertionFormat(string format, params object[] args) { }
	[Conditional("DUMMY")] public static void LogError(object message, Object context) { }
	[Conditional("DUMMY")] public static void LogError(object message) { }
	[Conditional("DUMMY")] public static void LogErrorFormat(string format, params object[] args) { }
	[Conditional("DUMMY")] public static void LogErrorFormat(Object context, string format, params object[] args) { }
	[Conditional("DUMMY")] public static void LogException(System.Exception exception, Object context) { }
	[Conditional("DUMMY")] public static void LogException(System.Exception exception) { }
	[Conditional("DUMMY")] public static void LogFormat(Object context, string format, params object[] args) { }
	[Conditional("DUMMY")] public static void LogFormat(string format, params object[] args) { }
	[Conditional("DUMMY")] public static void LogWarning(object message) { }
	[Conditional("DUMMY")] public static void LogWarning(object message, Object context) { }
	[Conditional("DUMMY")] public static void LogWarningFormat(string format, params object[] args) { }
	[Conditional("DUMMY")] public static void LogWarningFormat(Object context, string format, params object[] args) { }
}
#endif
#endregion