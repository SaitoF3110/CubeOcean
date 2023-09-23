using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBottanClick : MonoBehaviour
{
    [SerializeField] AudioClip[] _audioClips;
    AudioSource _audio;
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenItemDetail()
    {
        UIItem _item = GetComponent<UIItem>();
        GameObject _itemDetail = GameObject.Find("ItemDetail");
        UIItemDetail _detail = _itemDetail.GetComponent<UIItemDetail>();
        _detail._itemData = _item._itemData;
        _audio.PlayOneShot(_audioClips[0]);
    }
}
