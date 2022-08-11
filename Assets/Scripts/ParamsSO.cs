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

    // MyScriptableObject���ۑ����Ă���ꏊ�̃p�X
    public const string PATH = "ParamsSO";

    // MyScriptableObject�̎���
    private static ParamsSO _entity;
    public static ParamsSO Entity
    {
        get
        {
            // ���A�N�Z�X���Ƀ��[�h����
            if (_entity == null)
            {
                _entity = Resources.Load<ParamsSO>(PATH);

                // ���[�h�o���Ȃ������ꍇ�̓G���[���O��\��
                if (_entity == null)
                {
                    Debug.LogError(PATH + " not found");
                }
            }

            return _entity;
        }
    }
}
