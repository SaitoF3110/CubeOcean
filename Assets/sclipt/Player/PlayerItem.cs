using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    // Start is called before the first frame update
    public Dictionary<ItemDataManager, int> _itemDictionary = new Dictionary<ItemDataManager, int>();
    public List<ItemDataManager> _getItemList = new List<ItemDataManager>();
    [SerializeField] ItemDataManager _bomb;
    [SerializeField] GameObject _bombPrefab;
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
            if (!_itemDictionary.ContainsKey(_getItemList[0]))//����������V�����ǉ��B������UI�p�̃��X�g�ɂ��ǉ��B
            {
                _itemDictionary.Add(_getItemList[0], 1);
                GameObject _uiList = GameObject.Find("Items");
                UIItemManager _uiItemM = _uiList.GetComponent<UIItemManager>();
                
                _uiItemM._itemData.Add(_getItemList[0]);
            }
            else//���łɓ����A�C�e�����������琔�l��������
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
                //Debug.Log( item.Key + "��" + item.Value + "����");
            }
        }
        //���e����
        if (_itemDictionary.ContainsKey(_bomb))
        {
            if (_itemDictionary[_bomb] > 0)
            {
                if (Input.GetKeyDown(KeyCode.B))
                {
                    Vector3 _trans = new Vector3((int)this.transform.position.x, (int)this.transform.position.y, (int)this.transform.position.z);
                    Instantiate(_bombPrefab, _trans, this.transform.rotation);
                    _itemDictionary[_bomb] -= 1;
                }
            }
        }
    }
}
