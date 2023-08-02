using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactingManager : MonoBehaviour
{
    event Action<Facting, bool> _onFactingTurn;

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
        Debug.Log(GetFacting());
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
    }
    Facting GetFacting()
    {
        if (this.transform.rotation.y == 0)
        {
            return Facting.MinusZ;
        }
        else
        {
            return Facting.PlusZ;
        }
    }
}
