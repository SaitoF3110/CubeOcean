using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    // Start is called before the first frame update
    int _helth = 10;
    int _maxHelth = 10;
    int _speed = 1;
    int _attack = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public enum DeBuff
    {
        None,
        /// <summary>�ŏ��</summary>
        Poisoned,
        /// <summary>��჏��</summary>
        Paralyzed,
        /// <summary>�݉����</summary>
        Slowed,
        /// <summary>�h��ቺ���</summary>
        DefenseDecreased,
    }
    public enum Buff
    {
        None,
        /// <summary>���W�F�l���</summary>
        Regenerating,
        /// <summary>�U���������</summary>
        Strenth,
        /// <summary>�h�䋭�����</summary>
        Resistance,
    }
}
