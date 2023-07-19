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
        /// <summary>Cube、破壊可能ブロック、アイテムブロック</summary>
        Block,
        /// <summary>壁についてるタイプのオブジェクト</summary>
        Sprite,
    }
}
