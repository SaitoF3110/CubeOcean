using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactingManager : MonoBehaviour
{
    event Action<Facting, bool> _onFactingTurn;
    /// <summary>
    /// 回転する前の状態
    /// Factingは向き　boolはtrue =ShiftTurn(上から見て時計回り)falseはその逆
    /// </summary>
    public Action<Facting, bool> FactingTurn
    {
        get { return _onFactingTurn; }
        set { _onFactingTurn = value; }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerController playerscript = GetComponent<PlayerController>();
        int _rotY = (int)this.transform.localEulerAngles.y;
        if (playerscript._rotation)
        {
            //Debug.Log(GetFacting(_rotY));
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _onFactingTurn(GetFacting(_rotY), true);
            }
            else
            {
                _onFactingTurn(GetFacting(_rotY), false);
            }
            playerscript._rotation = false;
        }


            
    }
    public Facting GetFacting(int _transRY)
    {
        
        if (_transRY < 10 || _transRY > 350)
        {
            return Facting.MinusZ;
        }
        else if (_transRY < 280 && _transRY > 260)
        {
            return Facting.PlusX;
        }
        else if(_transRY < 190 && _transRY > 170)
        {
            return Facting.PlusZ;
        }
        else if (_transRY < 100 && _transRY > 80)
        {
            return Facting.MinusX;
        }
        else
        {
            return Facting.None;
        }
    }
    public enum Facting
    {
        /// <summary>プレイヤーから見てx軸プラス方向にカメラ</summary>
        PlusX,
        /// <summary>プレイヤーから見てz軸プラス方向にカメラ</summary>
        PlusZ,
        /// <summary>プレイヤーから見てx軸マイナス方向にカメラ</summary>
        MinusX,
        /// <summary>プレイヤーから見てz軸マイナス方向にカメラ</summary>
        MinusZ,

        None,
    }
}
