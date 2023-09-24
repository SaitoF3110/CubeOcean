using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Unity.VisualScripting.Metadata;

public class UIItem : MonoBehaviour
{
    [SerializeField] GameObject _numberText;
    [SerializeField] AudioClip _craftSE;
    [SerializeField] AudioClip _canNotCraft;
    public ItemDataManager _itemData;
    public RecipeDataManager _recipeData;
    AudioSource _audio;
    void Start()
    {
        _audio = GetComponent<AudioSource>();
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
    public void NumberBox()
    {
        //プレイヤーのアイテムリストにアクセス
        GameObject _player = GameObject.FindWithTag("Player");
        PlayerItem _pl = _player.GetComponent<PlayerItem>();
        Text _text = _numberText.GetComponent<Text>();
        if(!_pl._itemDictionary.ContainsKey(_itemData))
        {
            _text.text = "所持数　0";
        }
        else
        {
            _text.text = "所持数　" + _pl._itemDictionary[_itemData].ToString();
        }
    }
    public void ItemCraft()
    {
        bool _canCraft = true;
        GameObject _player = GameObject.FindWithTag("Player");
        PlayerItem _pl = _player.GetComponent<PlayerItem>();
        foreach (var _req in _recipeData._requiredItems)
        {
            if (_pl._itemDictionary[_req] == 0)
            {
                _audio.PlayOneShot(_canNotCraft);
                _canCraft = false;
                break;
            }
        }
        if (_canCraft)
        {
            foreach (var _req in _recipeData._requiredItems)
            {
                _pl._itemDictionary[_req] -= 1;
            }
            _pl._getItemList.Add(_itemData);
            _audio.PlayOneShot(_craftSE);
            //UI画面を再描画
            NumberBox();
        }
    }
}
