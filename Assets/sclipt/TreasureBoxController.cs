using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TreasureBoxController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] _items;
    [SerializeField] GameObject _se;
    GameObject _item;
    AfterFactingManager _facAM;
    bool _open = false;
    bool _isX;//X方向を向いている
    void Start()
    {
        _facAM = GameObject.FindObjectOfType<AfterFactingManager>();
        _facAM.AfterFactingTurn += AfterFactingBox;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject _playerObj = GameObject.FindWithTag("Player");
        this.transform.rotation = _playerObj.transform.rotation;
        if (_open)
        {
            for (int i = 0; i < _items.Length; i++)
            {
                int rnd = Random.Range(-100, 100);
                int rndY = Random.Range(200, 300);
                _item = Instantiate(_items[i], this.transform.position, this.transform.rotation) as GameObject;
                Rigidbody rb = _item.GetComponent<Rigidbody>();
                if(this.transform.rotation .eulerAngles.y == 0 || this.transform.rotation.eulerAngles.y == 180)
                {
                    rb.AddForce(new Vector3(rnd, rndY, 0));
                }
                else
                {
                    rb.AddForce(new Vector3(0, rndY, rnd));
                }
                
            }
            Instantiate(_se);
            _facAM.AfterFactingTurn -= AfterFactingBox;
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerAttack")
        {
            _open = true;
        }
    }
    void AfterFactingBox(AfterFactingManager.AfFacting afFacting)
    {
        GameObject child = transform.GetChild(0).gameObject;
        GameObject _playerObj = GameObject.FindWithTag("Player");
        float distancex = _playerObj.transform.position.x - this.transform.position.x;
        float distancez = _playerObj.transform.position.z - this.transform.position.z;
        if (afFacting == AfterFactingManager.AfFacting.MinusX || afFacting == AfterFactingManager.AfFacting.PlusX)
        {
            if (distancex * distancex > 1.5)
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
}
