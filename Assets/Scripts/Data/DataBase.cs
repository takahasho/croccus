
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create DataBase")]
public class DataBase : ScriptableObject
{
    [SerializeField] List<CharacterData> characterList = new List<CharacterData>();

    public List<CharacterData> GetDatasList()
    {
        if (characterList != null)
            return characterList;

        return null;
    }
}
