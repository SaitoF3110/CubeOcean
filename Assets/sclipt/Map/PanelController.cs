using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class PanelController : MonoBehaviour
{
    //下の順番通り
    [SerializeField] bool[] _bools = new bool[4];
    [SerializeField] GameObject[] _objects = new GameObject[4];

    [SerializeField] GameObject _panelPX;//プレイヤーから見てプラスX方向のパネル  0
    [SerializeField] GameObject _panelPZ;//プレイヤーから見てプラスZ方向のパネル  1
    [SerializeField] GameObject _panelMX;//プレイヤーから見てマイナスX方向のパネル  2
    [SerializeField] GameObject _panelMZ;//プレイヤーから見てマイナスX方向のパネる  3
    FactingManager _facM;
    GameObject _inObj;
    bool _fadeIn = false;
    float _alpha = 0;
    float _outAlpha;
    void Start()
    {
        _facM = GameObject.FindObjectOfType<FactingManager>();
        _facM.FactingTurn += PlayerFactingPanel;
    }
    private void FixedUpdate()
    {
        int _index = Array.IndexOf(_objects, _inObj);
        Debug.Log(_index);
        if (_index != -1)
        {
            if (_fadeIn && _bools[_index])
            {

                if (_alpha <= 1)
                {
                    _alpha += 0.05f;
                    _inObj.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, _alpha);
                }
                else
                {
                    _alpha = 0;
                    _outAlpha = 1;
                    _fadeIn = false;
                }

            }
        }
        Fix();

    }
    void PlayerFactingPanel(FactingManager.Facting _fact, bool _turn)
    {
        GameObject _playerObj = GameObject.FindWithTag("Player");
        Vector3 _fixdTrans;
        //プレイヤーの位置修正
        if (_fact == FactingManager.Facting.PlusZ || _fact == FactingManager.Facting.MinusZ)
        {
            float _fixValue;
            if (this.transform.position.x >= 0) { _fixValue = 0.45f; } else { _fixValue = -0.45f; }
            _fixdTrans = new Vector3(_playerObj.transform.position.x + _fixValue, _playerObj.transform.position.y, _playerObj.transform.position.z);
        }
        else
        {
            float _fixValue;
            if (this.transform.position.z >= 0) { _fixValue = 0.45f; } else { _fixValue = -0.45f; }
            _fixdTrans = new Vector3(_playerObj.transform.position.x, _playerObj.transform.position.y, _playerObj.transform.position.z + _fixValue);
        }
        if(this.transform.position.x == (int)_fixdTrans.x && _fact == FactingManager.Facting.PlusZ|| this.transform.position.x == (int)_fixdTrans.x && _fact == FactingManager.Facting.MinusZ || this.transform.position.z == (int)_fixdTrans.z && _fact == FactingManager.Facting.MinusX || this.transform.position.z == (int)_fixdTrans.z && _fact == FactingManager.Facting.PlusX)
        {
            _inObj = FactGameObject(_fact, _turn);
            _fadeIn = true;
        }
        else
        {
            _inObj = null;
            Fix();
        }
        
        NoWall();
        
    }
    // Update is called once per frame
    void ColorControll(GameObject _panel,bool _inOut)
    {
        if(_inOut)
            _panel.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        else
            _panel.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);

    }
    void Fix()
    {
        if (_outAlpha >= 0)
        {
            _outAlpha -= 0.05f;
            for(int i = 0; i < 4; i++)
            {
                if (_inObj != _objects[i])
                    _objects[i].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, _outAlpha);
            }
        }
        if(_inObj == null)
        {
            for (int i = 0; i < 4; i++)
            {
                _objects[i].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            }
        }
    }
    void NoWall()
    {
        for(int i = 0; i < 4; i++)
        {
            if (!_bools[i])
            {

            }
        }
    }
    GameObject FactGameObject(FactingManager.Facting _fact, bool _turn)
    {
        if(!_turn)
        {
            if (_fact == FactingManager.Facting.MinusZ)
                return _objects[2];
            else if (_fact == FactingManager.Facting.MinusX)
                return _objects[1];
            else if (_fact == FactingManager.Facting.PlusZ)
                return _objects[0];
            else
                return _objects[3];
        }
        else
        {
            if (_fact == FactingManager.Facting.MinusZ)
                return _objects[0];
            else if (_fact == FactingManager.Facting.MinusX)
                return _objects[3];
            else if (_fact == FactingManager.Facting.PlusZ)
                return _objects[2];
            else
                return _objects[1];
        }
    }
}

