using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    public ItemDataManager _itemData;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var _children = this.GetComponentsInChildren<Transform>(true);
        foreach (var child in _children)
        {
            if(child.name == "ItemImage")
            {
                Image _img = child.GetComponent<Image>();
                _img.sprite = _itemData._itemImage;
            }
            if (child.name == "ItemText")
            {
                Text _text = child.GetComponent<Text>();
                _text.text = _itemData._itemName;
            }
        }
    }
}
