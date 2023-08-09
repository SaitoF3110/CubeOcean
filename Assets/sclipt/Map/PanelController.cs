using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject _panelPX;//�v���C���[���猩�ăv���XX�����̃p�l��
    [SerializeField] GameObject _panelPZ;//�v���C���[���猩�ăv���XZ�����̃p�l��
    [SerializeField] GameObject _panelMX;//�v���C���[���猩�ă}�C�i�XX�����̃p�l��
    [SerializeField] GameObject _panelMZ;//�v���C���[���猩�ă}�C�i�XX�����̃p�l��
    FactingManager _facM;
    void Start()
    {
        _facM = GameObject.FindObjectOfType<FactingManager>();
        _facM.FactingTurn += PlayerFactingPanel;
    }
    void PlayerFactingPanel(FactingManager.Facting _fact, bool _turn)
    {
        GameObject _playerObj = GameObject.FindWithTag("Player");
        float _fixdTrans;
        //�v���C���[�̈ʒu�C��
        if (_fact == FactingManager.Facting.PlusZ || _fact == FactingManager.Facting.MinusZ)
        {
            float _fixValue;
            if (this.transform.position.x >= 0) { _fixValue = 0.45f; } else { _fixValue = -0.45f; }
            _fixdTrans = _playerObj.transform.position.x + _fixValue;
        }
        else
        {
            float _fixValue;
            if (this.transform.position.z >= 0) { _fixValue = 0.45f; } else { _fixValue = -0.45f; }
            _fixdTrans = _playerObj.transform.position.z + _fixValue;
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
    void Fade(bool _in)
    {
        if(_in)
        {

        }
    }
}

