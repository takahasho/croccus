
using UnityEngine;

//  キャラクターリスト
public enum Type
{
    PLAYER = 0,
    TEASEL,
    SCABIOSA,
    SHION,
}

[CreateAssetMenu(menuName = "MyScriptable/Create CharacterDate")]
public class CharacterData : ScriptableObject
{
    /// <summary> キャラクタータイプ </summary>
    public Type Type;

    /// <summary> HP最大値 </summary>
    public int  MaxHp;

    /// <summary> 攻撃力[弱攻撃] </summary>
    public int  LightAttack;

    /// <summary> 攻撃力[強攻撃] </summary>
    public int  StrongAttack;
}
