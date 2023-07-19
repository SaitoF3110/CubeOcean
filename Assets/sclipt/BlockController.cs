using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BlockController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ObjectType _type = ObjectType.Block;

    public abstract void WhenRotate();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {

        }
    }
    enum ObjectType
    {
        /// <summary>Cube�A�j��\�u���b�N�A�A�C�e���u���b�N</summary>
        Block,
        /// <summary>�ǂɂ��Ă�^�C�v�̃I�u�W�F�N�g</summary>
        Sprite,
    }
}
