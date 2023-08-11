using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/EquipmentDeta")]
public class EquipmentDetaManager : ScriptableObject
{
    //�A�C�e��ID�ɂ���
    //5000�`5999 Accessory
    //6000�`6999 Wepon

    /// <summary>�A�C�e��ID</summary>
    public int _itemId;
    /// <summary>�y����z���</summary>
    public WeponType _weponType;
    /// <summary>�y����z�U���́y�����z�U���͏オ��l</summary>
    public int _attack;
    /// <summary>�y����z�y�����z�̗͏オ��l</summary>
    public int _hp;
    /// <summary>�y����z�y�����z�h��͏オ��l</summary>
    public int _defence;


    public enum WeponType
    {
        /// <summary>����</summary>
        None,
        /// <summary>��</summary>
        Sword,
        /// <summary>��</summary>
        Axe,
        /// <summary>�|</summary>
        Bow,
        /// <summary>�Z��</summary>
        ShortSword,
    }
}
