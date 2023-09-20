using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerItem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ItemDataManager manager;
    Dictionary<ItemDataManager, int> _itemDictionary = new Dictionary<ItemDataManager, int>();
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

        if(_getItemList.Count > 0)
        {
            if (!_itemDictionary.ContainsKey(_getItemList[0]))//���łɓ����A�C�e�����������琔�l��������
            {
                _itemDictionary.Add(_getItemList[0], 1);
            }
            else//����������V�����ǉ�
            {
                _itemDictionary[_getItemList[0]] += 1;
            }
            _getItemList.Remove(_getItemList[0]);
        }

        //�C���x���g���m�F
        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (KeyValuePair<ItemDataManager, int> item in _itemDictionary)
            {
                Debug.Log( item.Key + "��" + item.Value + "����");
            }
        }

    }
}
