using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRecipe : MonoBehaviour
{
    public RecipeDataManager _recipeData;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var _children = this.GetComponentsInChildren<Transform>(true);
        foreach (var child in _children)
        {
            if (child.name == "RecipeFrameBottan1")
            {
                UIItem _item = child.GetComponent<UIItem>();
                _item._itemData = _recipeData._requiredItems[0];
            }
            else if (child.name == "RecipeFrameBottan2")
            {
                UIItem _item = child.GetComponent<UIItem>();
                _item._itemData = _recipeData._requiredItems[1];
            }
            else if (child.name == "RecipeFrameBottan3")
            {
                UIItem _item = child.GetComponent<UIItem>();
                _item._itemData = _recipeData._requiredItems[2];
            }
            else if (child.name == "RecipeFrameBottanCrafted")
            {
                UIItem _item = child.GetComponent<UIItem>();
                _item._itemData = _recipeData._craftedItem;
                _item._recipeData = _recipeData;
            }
        }
    }

}
