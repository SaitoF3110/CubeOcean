using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/EntityDeta")]
public class EntityDetaManager : ScriptableObject
{
    /// <summary>ƒGƒ“ƒeƒBƒeƒBID</summary>
    public int _entityID;
    /// <summary>“G‚Å‚ ‚é</summary>
    public bool _isEnemy;
    /// <summary>UŒ‚—Í</summary>
    public int _attack;
    /// <summary>–hŒä—Í</summary>
    public int _deffence;
    /// <summary>‘Ì—Í</summary>
    public int _hp;
    /// <summary>’n–Ê‚É‚¢‚é“G‚©</summary>
    public bool _isGround;
}
