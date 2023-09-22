using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerItem : MonoBehaviour
{
    // Start is called before the first frame update
    public Dictionary<ItemDataManager, int> _itemDictionary = new Dictionary<ItemDataManager, int>();
    public List<ItemDataManager> _getItemList = new List<ItemDataManager>();
    void Start()
    {
        //_itemDictionary[manager] = 1;
        //_itemDictionary.Add(manager, 4);
        //_itemDictionary.Add(manager, 2);
    }
    
    // Update is called once per frame
    void Update()
    {
        if(_getItemList.Count > 0)
        {
            Debug.Log(_getItemList[0]);
            if (!_itemDictionary.ContainsKey(_getItemList[0]))//無かったら新しく追加。同時にUI用のリストにも追加。
            {
                _itemDictionary.Add(_getItemList[0], 1);
                GameObject _uiList = GameObject.Find("Items");
                UIItemManager _uiItemM = _uiList.GetComponent<UIItemManager>();
                
                _uiItemM._itemData.Add(_getItemList[0]);
            }
            else//すでに同じアイテムがあったら数値だけ足す
            {
                _itemDictionary[_getItemList[0]] += 1;
                
            }
            _getItemList.Remove(_getItemList[0]);
        }

        //インベントリ確認
        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (KeyValuePair<ItemDataManager, int> item in _itemDictionary)
            {
                Debug.Log( item.Key + "を" + item.Value + "個所持");
            }
        }

    }
}
