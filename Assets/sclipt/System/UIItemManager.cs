using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIItemManager : MonoBehaviour, IPause
{
    [SerializeField] GameObject _itemFrame;
    public List<ItemDataManager> _itemData = new List<ItemDataManager>();//プレイヤーの持つアイテムの種類リスト
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Pause()
    {
        GameObject _player = GameObject.FindWithTag("Player");
        PlayerItem _pl = _player.GetComponent<PlayerItem>();
        for (int i = 0;i < _itemData.Count;i++)
        {
            int _transX;
            if (i % 3 == 1)
            {
                _transX = 10;
            }
            else if (i % 3 == 2)
            {
                _transX = 94;
            }
            else
            {
                _transX = -74;
            }
            GameObject _frame = Instantiate(_itemFrame, this.transform.position, transform.rotation, this.gameObject.transform) as GameObject;
            _frame.transform.localPosition = new Vector3(_transX, i / 3 * -85 + 135, 0);
            UIItem _ui = _frame.GetComponent<UIItem>();
            _ui._itemData = _itemData[i];
        }
    }
    public void Resume()
    {
        foreach (Transform child in this.gameObject.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
