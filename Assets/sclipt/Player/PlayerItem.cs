using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerItem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ItemDetaManager manager;
    Dictionary<ItemDetaManager, int> _itemDictionary = new Dictionary<ItemDetaManager, int>();
    void Start()
    {
        _itemDictionary[manager] = 1;
        //_itemDictionary.Add(manager, 4);
        //_itemDictionary.Add(manager, 2);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!_itemDictionary.ContainsKey(manager))
            {
                _itemDictionary.Add(manager, 1);
            }
            else
            {
                _itemDictionary[manager] += 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            foreach (KeyValuePair<ItemDetaManager, int> item in _itemDictionary)
            {
                Debug.Log("キーは" + item.Key + "です。  バリューは" + item.Value + "です。");
            }
        }

    }
}
