using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRecipeController : MonoBehaviour,IPause
{
    [SerializeField] GameObject _recipeFrame;
    [SerializeField] List<RecipeDataManager> _recipeData = new List<RecipeDataManager>();//未開放レシピのリスト
    public List<RecipeDataManager> _playerRecipeData = new List<RecipeDataManager>();//プレイヤーが持っているレシピのリスト
    GameObject _player;
    PlayerItem _pl;
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _pl = _player.GetComponent<PlayerItem>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Pause()
    {
        for (int i = 0; _recipeData.Count > i; i++)//全ての未開放レシピを検索
        {
            List<bool> _itemBools = new List<bool>();//レシピごとにアイテムの有無を格納
            for (int j = 0; j < _recipeData[i]._requiredItems.Length; j++)//レシピ内の必要アイテムがあるかどうか
            {               
                foreach (KeyValuePair<ItemDataManager, int> item in _pl._itemDictionary)//アイテムリスト内全検索
                {
                    if (item.Key == _recipeData[i]._requiredItems[j])//アイテムがあったらboolsに追加
                    {
                        _itemBools.Add(true);
                        break;
                    }
                }
            }
            if( _itemBools.Count == _recipeData[i]._requiredItems.Length)//数が一致していたらレシピ開放
            {
                _playerRecipeData.Add(_recipeData[i]);
                _recipeData.Remove(_recipeData[i]);
                break;
            }
        }
        //レシピUI描画
        for (int i = 0; _playerRecipeData.Count > i; i++)
        {
            GameObject _frame = Instantiate(_recipeFrame, this.transform.position, transform.rotation, this.gameObject.transform) as GameObject;
            _frame.transform.localPosition = new Vector3(169, i * -110, 0);
            UIRecipe _ui = _frame.GetComponent<UIRecipe>();
            _ui._recipeData = _playerRecipeData[i];
        }
    }
    public void Resume()
    {
        
    }
}
