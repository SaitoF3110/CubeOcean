using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactingManager : MonoBehaviour
{
    event Action<Facting, bool> _onFactingTurn;
    /// <summary>
    /// ��]����O�̏��
    /// Facting�͌����@bool��true =ShiftTurn(�ォ�猩�Ď��v���)false�͂��̋t
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
        /// <summary>�v���C���[���猩��x���v���X�����ɃJ����</summary>
        PlusX,
        /// <summary>�v���C���[���猩��z���v���X�����ɃJ����</summary>
        PlusZ,
        /// <summary>�v���C���[���猩��x���}�C�i�X�����ɃJ����</summary>
        MinusX,
        /// <summary>�v���C���[���猩��z���}�C�i�X�����ɃJ����</summary>
        MinusZ,

        None,
    }
}
