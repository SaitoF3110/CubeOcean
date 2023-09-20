using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class ItemContoller : MonoBehaviour, IPause
{
    // Start is called before the first frame update
    [SerializeField] GameObject _se;
    [SerializeField] ItemDataManager _itemData;
    AfterFactingManager _facAM;
    Vector3 _velocity;
    Rigidbody _rb;
    void Start()
    {
        _facAM = GameObject.FindObjectOfType<AfterFactingManager>();
        _facAM.AfterFactingTurn += AfterFactingItem;
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //常にプレイヤーの位置を取得
        GameObject _playerObj = GameObject.FindWithTag("Player");
        this.transform.rotation = _playerObj.transform.rotation;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")//プレイヤーに触れたらデータを渡して自身を破棄
        {
            GameObject _obj = (GameObject)other.gameObject;
            PlayerItem _playerItem = _obj.GetComponent<PlayerItem>();
            if(_playerItem != null && _itemData != null)
            {
                _playerItem._getItemList.Add(_itemData);//プレイヤーのゲットアイテムリストに追加
            }
            _facAM.AfterFactingTurn -= AfterFactingItem;
            Instantiate(_se);
            Destroy(this.gameObject);
        }
    }
    void AfterFactingItem(AfterFactingManager.AfFacting afFacting)
    {
        GameObject child = transform.GetChild(0).gameObject;
        GameObject _playerObj = GameObject.FindWithTag("Player");
        float distancex = _playerObj.transform.position.x - this.transform.position.x;
        float distancez = _playerObj.transform.position.z - this.transform.position.z;

        //描画処理　プレイヤーと同じ軸にいたら表示　近かったら半透明　遠かったら非表示
        if(afFacting == AfterFactingManager.AfFacting.MinusX || afFacting == AfterFactingManager.AfFacting.PlusX)
        {
            if(distancex * distancex > 1.5)
            {
                child.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            }
            else if (distancex * distancex > 0.36)
            {
                child.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
            }
            else
            {
                child.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            }

        }
        else
        {
            if (distancez * distancez > 1.5)
            {
                child.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            }
            else if (distancez * distancez > 0.36)
            {
                child.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
            }
            else
            {
                child.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            }

        }
    }
    public void Pause()
    {
        _velocity = _rb.velocity;
        _rb.Sleep();
    }
    public void Resume()
    {
        _rb.WakeUp();
        _rb.velocity = _velocity;
    }
}
