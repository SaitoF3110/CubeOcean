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
        /// <summary>“Åó‘Ô</summary>
        Poisoned,
        /// <summary>–ƒáƒó‘Ô</summary>
        Paralyzed,
        /// <summary>“İ‰»ó‘Ô</summary>
        Slowed,
        /// <summary>–hŒä’á‰ºó‘Ô</summary>
        DefenseDecreased,
    }
    public enum Buff
    {
        None,
        /// <summary>ƒŠƒWƒFƒló‘Ô</summary>
        Regenerating,
        /// <summary>UŒ‚‹­‰»ó‘Ô</summary>
        Strenth,
        /// <summary>–hŒä‹­‰»ó‘Ô</summary>
        Resistance,
    }
}
