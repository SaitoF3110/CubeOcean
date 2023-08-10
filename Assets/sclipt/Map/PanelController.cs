using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PanelController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject _panelPX;//プレイヤーから見てプラスX方向のパネル
    [SerializeField] GameObject _panelPZ;//プレイヤーから見てプラスZ方向のパネル
    [SerializeField] GameObject _panelMX;//プレイヤーから見てマイナスX方向のパネル
    [SerializeField] GameObject _panelMZ;//プレイヤーから見てマイナスX方向のパネル
    FactingManager _facM;
    GameObject _inObj;
    GameObject _outObj;
    bool _fadeIn = false;
    bool _out = false;
    float _time;
    float _alpha = 0;
    void Start()
    {
        _facM = GameObject.FindObjectOfType<FactingManager>();
        _facM.FactingTurn += PlayerFactingPanel;
    }
    private void FixedUpdate()
    {
        if (_fadeIn)
        {
            Fix();
            _inObj.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
        }
        
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
        if(this.transform.position.x == (int)_fixdTrans.x && this.transform.position.z == (int)_fixdTrans.z)
        {
            _inObj = FactGameObject(_fact, _turn);
            _fadeIn = true;
        }
        else
        {
            _inObj = null;
            Fix();
        }
        

        
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
        if (_inObj != _panelPZ)
            _panelPZ.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        if (_inObj != _panelPX)
            _panelPX.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        if (_inObj != _panelMZ)
            _panelMZ.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        if (_inObj != _panelMX)
            _panelMX.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        if(_inObj ==null)
        {
            _panelPZ.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            _panelPX.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            _panelMZ.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            _panelMX.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        }
    }
    GameObject FactGameObject(FactingManager.Facting _fact, bool _turn)
    {
        if(!_turn)
        {
            if (_fact == FactingManager.Facting.MinusZ)
                return _panelMX;
            else if (_fact == FactingManager.Facting.MinusX)
                return _panelPZ;
            else if (_fact == FactingManager.Facting.PlusZ)
                return _panelPX;
            else
                return _panelMZ;
        }
        else
        {
            if (_fact == FactingManager.Facting.MinusZ)
                return _panelPX;
            else if (_fact == FactingManager.Facting.MinusX)
                return _panelMZ;
            else if (_fact == FactingManager.Facting.PlusZ)
                return _panelMX;
            else
                return _panelPZ;
        }
    }
}

