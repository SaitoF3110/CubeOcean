using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/EquipmentDeta")]
public class EquipmentDetaManager : ScriptableObject
{
    //ƒAƒCƒeƒ€ID‚É‚Â‚¢‚Ä
    //5000`5999 Accessory
    //6000`6999 Wepon

    /// <summary>ƒAƒCƒeƒ€ID</summary>
    public int _itemId;
    /// <summary>y•Šízí—Ş</summary>
    public WeponType _weponType;
    /// <summary>y•ŠízUŒ‚—Íy‘•üzUŒ‚—Íã‚ª‚è’l</summary>
    public int _attack;
    /// <summary>y•Šízy‘•üz‘Ì—Íã‚ª‚è’l</summary>
    public int _hp;
    /// <summary>y•Šízy‘•üz–hŒä—Íã‚ª‚è’l</summary>
    public int _defence;
    /// <summary>y•Šízy‘•üzƒoƒt</summary>
    public PlayerStates.Buff _Buff;
    /// <summary>y•Šízy‘•üz“ÁêŒø‰Ê‚ª‚ ‚é</summary>
    public bool _isSpecial;


    public enum WeponType
    {
        /// <summary>–³‚µ</summary>
        None,
        /// <summary>Œ•</summary>
        Sword,
        /// <summary>•€</summary>
        Axe,
        /// <summary>‹|</summary>
        Bow,
        /// <summary>’ZŒ•</summary>
        ShortSword,
    }
}
