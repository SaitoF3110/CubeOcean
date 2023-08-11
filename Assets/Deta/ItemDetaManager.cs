using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ItemDeta")]
public class ItemDetaManager : ScriptableObject
{
    /// <summary>�A�C�e��ID</summary>
    public int _itemId;
    /// <summary>�A�C�e����</summary>
    public string _itemName;
    /// <summary>�A�C�e��������</summary>
    public string _itemDescription;
    /// <summary>�A�C�e���摜</summary>
    public Sprite _itemImage;
}
