using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>今向いている方向のメソッドが呼び出される。</summary>
interface IFacting
{
    /// <summary>プレイヤーから見てx軸プラス方向にカメラ</summary>
    void PlusX();
    /// <summary>プレイヤーから見てz軸プラス方向にカメラ</summary>
    void PlusZ();
    /// <summary>プレイヤーから見てx軸マイナス方向にカメラ</summary>
    void MinusX();
    /// <summary>プレイヤーから見てz軸マイナス方向にカメラ</summary>
    void MinusZ();
}
