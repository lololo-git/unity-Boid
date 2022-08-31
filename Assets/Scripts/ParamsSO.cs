using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ParamsSO : ScriptableObject
{
    [Header("Game Score")]
    public int score;

    // Hack to acces SO easily
    // Copied from https://kan-kikuchi.hatenablog.com/entry/ScriptableObject_Entity

    // MyScriptableObjectが保存してある場所のパス
    public const string PATH = "ParamsSO";

    // MyScriptableObjectの実体
    private static ParamsSO _entity;

    public static ParamsSO Entity
    {
        get
        {
            // 初アクセス時にロードする
            if (_entity == null)
            {
                _entity = Resources.Load<ParamsSO>(PATH);

                // ロード出来なかった場合はエラーログを表示
                if (_entity == null)
                {
                    Debug.LogError(PATH + " not found");
                }
            }

            return _entity;
        }
    }
}