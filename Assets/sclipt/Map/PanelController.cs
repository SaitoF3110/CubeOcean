using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject _panelPX;//プレイヤーから見てプラスX方向のパネル
    [SerializeField] GameObject _panelPZ;//プレイヤーから見てプラスZ方向のパネル
    [SerializeField] GameObject _panelMX;//プレイヤーから見てマイナスX方向のパネル
    [SerializeField] GameObject _panelMZ;//プレイヤーから見てマイナスX方向のパネル
    FactingManager _facM;
    void Start()
    {
        _facM = GameObject.FindObjectOfType<FactingManager>();
        _facM.FactingTurn += PlayerFactingPanel;
    }
    void PlayerFactingPanel(FactingManager.Facting _fact, bool _turn)
    {
        
    }
    // Update is called once per frame
    void ColorControll(GameObject _panel,bool _inOut)
    {
        if(_inOut)
            _panel.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        else
            _panel.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
    }
}

