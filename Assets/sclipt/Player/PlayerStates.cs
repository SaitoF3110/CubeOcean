using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    // Start is called before the first frame update
    float _helth = 100;
    float _maxHelth = 100;
    int _speed = 1;
    int _attack = 10;
    float _hpIncrease;
    float _invincibleTime = 1;
    float _time;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _helth += _hpIncrease;
        _hpIncrease = 0;

        if (_helth > _maxHelth)
        {
            _maxHelth = _helth;
        }
        else if(_helth < 0)
        {
            _helth = 0;
        }
        GameObject _bar = GameObject.FindWithTag("HpBar");
        HPBarController _hpBar = _bar.GetComponent<HPBarController>();
        if(_hpBar != null)
        {
            _hpBar._plyerHp = _helth;
            _hpBar._plyerMaxHp = _maxHelth;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _hpIncrease = -10;
        }
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
