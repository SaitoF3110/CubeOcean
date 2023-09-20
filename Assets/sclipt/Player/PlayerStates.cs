using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    // 基本パラメータ
    float _helth = 100;
    float _maxHelth = 100;
    int _speed = 1;
    public int _attack = 10;
    public int _diffence = 0;
    //計算用
    public float _hpIncrease;
    float _invincibleTime = 1;
    bool _invincible = false;
    float _time;
    void Start()
    {
        
    }

    void Update()
    {
        if(!_invincible && _hpIncrease < 0)//ダメージを受けた時、無敵オン＆無敵タイム計測開始
        {
            //無敵じゃない時しかダメージを受けない
            _helth += _hpIncrease;
            _invincible = true;
            _time = 0.1f;
        }
        if( _time != 0 )//タイムが0以外の時、計測。
        {
            _time += Time.deltaTime;
            if( _time > _invincibleTime + 0.1f )//無敵時間が過ぎたら無敵解除＆タイムリセット
            {
                _invincible = false;
                _time = 0;
            }

        }
        _hpIncrease = 0;//毎回ダメージ＆ヒール量リセット

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
