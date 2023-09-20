using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    // ��{�p�����[�^
    float _helth = 100;
    float _maxHelth = 100;
    int _speed = 1;
    public int _attack = 10;
    public int _diffence = 0;
    //�v�Z�p
    public float _hpIncrease;
    float _invincibleTime = 1;
    bool _invincible = false;
    float _time;
    void Start()
    {
        
    }

    void Update()
    {
        if(!_invincible && _hpIncrease < 0)//�_���[�W���󂯂����A���G�I�������G�^�C���v���J�n
        {
            //���G����Ȃ��������_���[�W���󂯂Ȃ�
            _helth += _hpIncrease;
            _invincible = true;
            _time = 0.1f;
        }
        if( _time != 0 )//�^�C����0�ȊO�̎��A�v���B
        {
            _time += Time.deltaTime;
            if( _time > _invincibleTime + 0.1f )//���G���Ԃ��߂����疳�G�������^�C�����Z�b�g
            {
                _invincible = false;
                _time = 0;
            }

        }
        _hpIncrease = 0;//����_���[�W���q�[���ʃ��Z�b�g

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
