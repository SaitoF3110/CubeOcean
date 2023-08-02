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
        /// <summary>�v���C���[���猩��x���v���X�����ɃJ����</summary>
        PlusX,
        /// <summary>�v���C���[���猩��z���v���X�����ɃJ����</summary>
        PlusZ,
        /// <summary>�v���C���[���猩��x���}�C�i�X�����ɃJ����</summary>
        MinusX,
        /// <summary>�v���C���[���猩��z���}�C�i�X�����ɃJ����</summary>
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
