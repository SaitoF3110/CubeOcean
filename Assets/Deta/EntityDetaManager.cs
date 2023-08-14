using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/EntityDeta")]
public class EntityDetaManager : ScriptableObject
{
    /// <summary>�G���e�B�e�BID</summary>
    public int _entityID;
    /// <summary>�G���e�B�e�B��</summary>
    public string _name;
    /// <summary>�G�ł���</summary>
    public bool _isEnemy;
    /// <summary>�U����</summary>
    public int _attack;
    /// <summary>�h���</summary>
    public int _deffence;
    /// <summary>�̗�</summary>
    public int _hp;
    /// <summary>�n�ʂɂ���G��</summary>
    public bool _isGround;
}
