using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class ItemContoller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject _se;
    AfterFactingManager _facAM;
    void Start()
    {
        _facAM = GameObject.FindObjectOfType<AfterFactingManager>();
        _facAM.AfterFactingTurn += AfterFactingItem;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject _playerObj = GameObject.FindWithTag("Player");
        this.transform.rotation = _playerObj.transform.rotation;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
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
}
