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
        /// <summary>毒状態</summary>
        Poisoned,
        /// <summary>麻痺状態</summary>
        Paralyzed,
        /// <summary>鈍化状態</summary>
        Slowed,
        /// <summary>防御低下状態</summary>
        DefenseDecreased,
    }
    public enum Buff
    {
        None,
        /// <summary>リジェネ状態</summary>
        Regenerating,
        /// <summary>攻撃強化状態</summary>
        Strenth,
        /// <summary>防御強化状態</summary>
        Resistance,
    }
}
