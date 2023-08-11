using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ItemDeta")]
public class ItemDetaManager : ScriptableObject
{
    //�A�C�e��ID�ɂ���
    //0�`999 Food
    //1000�`1999 Ingredient
    //2000�`2999 Material
    //3000�`3999 Recipe
    //4000�`4999 Tool
    //5000�`5999 Accessory
    //6000�`6999 Wepon
    //7000�`7999 Special
    //10000 Money
    //10001�` �ǉ��v�f

    /// <summary>�A�C�e��ID</summary>
    public int _itemId;
    /// <summary>�A�C�e����</summary>
    public string _itemName;
    /// <summary>�A�C�e��������</summary>
    public string _itemDescription;
    /// <summary>�A�C�e���摜</summary>
    public Sprite _itemImage;
    /// <summary>�A�C�e���^�C�v</summary>
    public ItemType _itemType;
    /// <summary>�y�H�ށz�o�t</summary>
    public PlayerStates.Buff _asFoodBuff;
    /// <summary>�y�H�ށz���̂܂܂ŐH�ׂ��邩</summary>
    public bool _canEatBeforCook = false;
    /// <summary>�y���V�s�z�J�����郌�V�sID</summary>
    public int _recipeID;
    
    public enum ItemType
    {
        /// <summary>�H��</summary>
        Food,
        /// <summary>�H��</summary>
        Ingredient,
        /// <summary>�f��</summary>
        Material,
        /// <summary>���V�s</summary>
        Recipe,
        /// <summary>����</summary>
        Tool,
        /// <summary>����</summary>
        Accessory,
        /// <summary>����</summary>
        Wepon,
        /// <summary>����</summary>
        Special,
        /// <summary>���K</summary>
        Money,
    }

}
