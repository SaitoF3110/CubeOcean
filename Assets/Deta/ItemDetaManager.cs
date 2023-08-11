using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ItemDeta")]
public class ItemDetaManager : ScriptableObject
{
    /// <summary>アイテムID</summary>
    public int _itemId;
    /// <summary>アイテム名</summary>
    public string _itemName;
    /// <summary>アイテム説明文</summary>
    public string _itemDescription;
    /// <summary>アイテム画像</summary>
    public Sprite _itemImage;
}
