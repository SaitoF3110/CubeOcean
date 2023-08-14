using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/EntityDeta")]
public class EntityDetaManager : ScriptableObject
{
    /// <summary>エンティティID</summary>
    public int _entityID;
    /// <summary>エンティティ名</summary>
    public string _name;
    /// <summary>敵である</summary>
    public bool _isEnemy;
    /// <summary>攻撃力</summary>
    public int _attack;
    /// <summary>防御力</summary>
    public int _deffence;
    /// <summary>体力</summary>
    public int _hp;
    /// <summary>地面にいる敵か</summary>
    public bool _isGround;
}
