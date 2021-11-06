using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGenerator: MonoBehaviour
{
    [SerializeField] DataBase dataBase = null;

    #region シングルトンインスタンス

    private static CGenerator instance;
    private CGenerator() { }
    public static CGenerator Instance() { return instance; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion

    /// <summary>
    /// キャラクターデータを取得
    /// </summary>
    /// <param name="type">キャラクタータイプ</param>
    public CharacterData Spawn(Type type)
    {
        // キャラクターのパラメーターを取得
        List<CharacterData> lists = dataBase.GetDatasList();

        for (int i = 0; i < lists.Count; i++)
        {
            if (type == lists[i].Type)
            {
                for (int j = i + 1; j < lists.Count; j++)
                {
                    if (type == lists[j].Type)
                    {
                        Debug.LogError("キャラクターが重複しています");
                        return null;
                    }
                }
                return lists[i];
            }
        }

        Debug.LogError("キャラクターが見つかりませんでした");
        return null;
    }
}
