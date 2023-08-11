using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ItemDeta")]
public class ItemDetaManager : ScriptableObject
{
    //アイテムIDについて
    //0～999 Food
    //1000～1999 Ingredient
    //2000～2999 Material
    //3000～3999 Recipe
    //4000～4999 Tool
    //5000～5999 Accessory
    //6000～6999 Wepon
    //7000～7999 Special
    //10000 Money
    //10001～ 追加要素

    /// <summary>アイテムID</summary>
    public int _itemId;
    /// <summary>アイテム名</summary>
    public string _itemName;
    /// <summary>アイテム説明文</summary>
    public string _itemDescription;
    /// <summary>アイテム画像</summary>
    public Sprite _itemImage;
    /// <summary>アイテムタイプ</summary>
    public ItemType _itemType;
    /// <summary>【食材】バフ</summary>
    public PlayerStates.Buff _asFoodBuff;
    /// <summary>【食材】そのままで食べられるか</summary>
    public bool _canEatBeforCook = false;
    /// <summary>【レシピ】開放するレシピID</summary>
    public int _recipeID;
    
    public enum ItemType
    {
        /// <summary>食料</summary>
        Food,
        /// <summary>食材</summary>
        Ingredient,
        /// <summary>素材</summary>
        Material,
        /// <summary>レシピ</summary>
        Recipe,
        /// <summary>道具</summary>
        Tool,
        /// <summary>装飾</summary>
        Accessory,
        /// <summary>武器</summary>
        Wepon,
        /// <summary>特殊</summary>
        Special,
        /// <summary>金銭</summary>
        Money,
    }

}
