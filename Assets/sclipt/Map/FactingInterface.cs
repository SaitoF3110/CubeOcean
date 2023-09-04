using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactingInterface : MonoBehaviour
{
    // Start is called before the first frame update
    int _fact = 0;//PX,PZ,MX,MZÇÃèáî‘
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Facting()
    {
        var objects = FindObjectsOfType<GameObject>();
        int _playerTrans = (int)GameObject.FindWithTag("Player").transform.rotation.y;
        foreach (var obj in objects)
        {
            IFacting i = obj.GetComponent<IFacting>();
            if (GetFacting(_playerTrans) == 0)
            {
                i?.PlusX();
            }
            else if (GetFacting(_playerTrans) == 1)
            {
                i?.PlusZ();
            }
            else if (GetFacting(_playerTrans) == 2)
            {
                i?.MinusX();
            }
            else if (GetFacting(_playerTrans) == 3)
            {
                i?.MinusZ();
            }

        }
    }

    int GetFacting(int _trans)
    {
        if (_trans < 10 || _trans > 350)
        {
            return 3;
        }
        else if (_trans < 280 && _trans > 260)
        {
            return 0;
        }
        else if (_trans < 190 && _trans > 170)
        {
            return 1;
        }
        else if (_trans < 100 && _trans > 80)
        {
            return 2;
        }
        else
        {
            return 99;
        }
    }
}
