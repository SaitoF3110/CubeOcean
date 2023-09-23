using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/RecipeDeta")]
public class RecipeDataManager : ScriptableObject
{
    public ItemDataManager[] _requiredItems;
    public ItemDataManager _craftedItem;
}
