using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemDetail : MonoBehaviour
{
    public ItemDataManager _itemData;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_itemData != null)
        {
            var _children = this.GetComponentsInChildren<Transform>(true);
            foreach (var child in _children)
            {
                if (child.name == "ItemImage")//�A�C�e���摜
                {
                    Image _img = child.GetComponent<Image>();
                    _img.sprite = _itemData._itemImage;
                }
                if (child.name == "ItemName")//�A�C�e����
                {
                    Text _text = child.GetComponent<Text>();
                    _text.text = _itemData._itemName;
                }
                if (child.name == "ItemNumber")//�A�C�e��������
                {
                    //�v���C���[�̃A�C�e�����X�g�ɃA�N�Z�X
                    GameObject _player = GameObject.FindWithTag("Player");
                    PlayerItem _pl = _player.GetComponent<PlayerItem>();
                    Text _text = child.GetComponent<Text>();
                    _text.text = "�������@" + _pl._itemDictionary[_itemData].ToString();
                }
                if (child.name == "ItemMemo")//�A�C�e��������
                {
                    Text _text = child.GetComponent<Text>();
                    _text.text = "";//�e�L�X�g������
                    for (int i = 0; i < _itemData._itemDescription.Length; i++)
                    {
                        _text.text += _itemData._itemDescription[i] + "\n";
                    }
                }
            }
        }
    }
}
