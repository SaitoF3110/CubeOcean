using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/EquipmentDeta")]
public class EquipmentDetaManager : ScriptableObject
{
    //アイテムIDについて
    //5000〜5999 Accessory
    //6000〜6999 Wepon

    /// <summary>アイテムID</summary>
    public int _itemId;
    /// <summary>【武器】種類</summary>
    public WeponType _weponType;
    /// <summary>【武器】攻撃力【装飾】攻撃力上がり値</summary>
    public int _attack;
    /// <summary>【武器】【装飾】体力上がり値</summary>
    public int _hp;
    /// <summary>【武器】【装飾】防御力上がり値</summary>
    public int _defence;
    /// <summary>【武器】【装飾】バフ</summary>
    public PlayerStates.Buff _Buff;
    /// <summary>【武器】【装飾】特殊効果がある</summary>
    public bool _isSpecial;


    public enum WeponType
    {
        /// <summary>無し</summary>
        None,
        /// <summary>剣</summary>
        Sword,
        /// <summary>斧</summary>
        Axe,
        /// <summary>弓</summary>
        Bow,
        /// <summary>短剣</summary>
        ShortSword,
    }
}
