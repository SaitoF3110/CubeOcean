using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static FactingManager;

public class AfterFactingManager : MonoBehaviour
{
    // Start is called before the first frame update
    FactingManager _facM;
    event Action<AfFacting> _onAfterFactingTurn;
    /// <summary>
    /// ��]������̏��
    /// AfFacting�͌���
    /// </summary>
    public Action<AfFacting> AfterFactingTurn
    {
        get { return _onAfterFactingTurn; }
        set { _onAfterFactingTurn = value; }
    }
    void Start()
    {
        _facM = GameObject.FindObjectOfType<FactingManager>();
        _facM.FactingTurn += AfterFacting;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void AfterFacting(FactingManager.Facting _fact, bool _turn)
    {
        if (!_turn)
        {
            if(_fact == FactingManager.Facting.MinusZ)
            {
                _onAfterFactingTurn(AfFacting.PlusX);
            }
            else if (_fact == FactingManager.Facting.PlusX)
            {
                _onAfterFactingTurn(AfFacting.PlusZ);
            }
            else if (_fact == FactingManager.Facting.PlusZ)
            {
                _onAfterFactingTurn(AfFacting.MinusX);
            }
            else
            {
                _onAfterFactingTurn(AfFacting.MinusZ);
            }
        }
        else
        {
            if (_fact == FactingManager.Facting.MinusZ)
            {
                _onAfterFactingTurn(AfFacting.MinusX);
            }
            else if (_fact == FactingManager.Facting.PlusX)
            {
                _onAfterFactingTurn(AfFacting.MinusZ);
            }
            else if (_fact == FactingManager.Facting.PlusZ)
            {
                _onAfterFactingTurn(AfFacting.PlusX);
            }
            else
            {
                _onAfterFactingTurn(AfFacting.PlusZ);
            }
        }
    }
    public enum AfFacting
    {
        /// <summary>�v���C���[���猩��x���v���X�����ɃJ����</summary>
        PlusX,
        /// <summary>�v���C���[���猩��z���v���X�����ɃJ����</summary>
        PlusZ,
        /// <summary>�v���C���[���猩��x���}�C�i�X�����ɃJ����</summary>
        MinusX,
        /// <summary>�v���C���[���猩��z���}�C�i�X�����ɃJ����</summary>
        MinusZ,
    }
}
