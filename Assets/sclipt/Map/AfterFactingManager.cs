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
    /// 回転した後の状態
    /// AfFactingは向き
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
        /// <summary>プレイヤーから見てx軸プラス方向にカメラ</summary>
        PlusX,
        /// <summary>プレイヤーから見てz軸プラス方向にカメラ</summary>
        PlusZ,
        /// <summary>プレイヤーから見てx軸マイナス方向にカメラ</summary>
        MinusX,
        /// <summary>プレイヤーから見てz軸マイナス方向にカメラ</summary>
        MinusZ,
    }
}
