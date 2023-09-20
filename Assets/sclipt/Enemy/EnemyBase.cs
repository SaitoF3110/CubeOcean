using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] EntityDataManager _data;
    [SerializeField] GameObject[] _dropItem;
    [SerializeField] GameObject _deathEffect;
    float _hp;
    float _maxhp;
    int _attack;
    int _difence;
    // Start is called before the first frame update
    void Start()
    {
        //初期値取得
        _hp = _data._hp;
        _maxhp = _hp;
        _attack = _data._attack;
        _difence = _data._deffence;

    }

    // Update is called once per frame
    void Update()
    {
        if(_hp <= 0)
        {
            for (int i = 0; i < _dropItem.Length; i++)
            {
                GameObject _item;
                int rnd = Random.Range(-100, 100);
                int rndY = Random.Range(200, 300);
                _item = Instantiate(_dropItem[i], this.transform.position, this.transform.rotation) as GameObject;
                Rigidbody rb = _item.GetComponent<Rigidbody>();
                if (this.transform.rotation.eulerAngles.y == 0 || this.transform.rotation.eulerAngles.y == 180)
                {
                    rb.AddForce(new Vector3(rnd, rndY, 0));
                }
                else
                {
                    rb.AddForce(new Vector3(0, rndY, rnd));
                }

            }
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")//プレイヤーに接触でダメージを与える
        {
            PlayerStates _player = collision.gameObject.GetComponent<PlayerStates>();
            _player._hpIncrease -= _attack;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerAttack")//プレイヤーの攻撃でダメージを受ける
        {
            GameObject _obj = GameObject.FindWithTag("Player");
            PlayerStates _player = _obj.GetComponent<PlayerStates>();
            _hp -= _player._attack;
        }
    }
}
