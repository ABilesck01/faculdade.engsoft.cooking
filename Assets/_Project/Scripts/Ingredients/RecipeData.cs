using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Assets/New recipe")]
public class RecipeData : ScriptableObject
{
    [SerializeField] private List<BaseIngredient> inputIngredients;
    [Space] 
    [SerializeField] private BaseIngredient outputItem;

    public List<BaseIngredient> InputIngredients
    {
        get => inputIngredients;
    }

    public BaseIngredient OutputItem
    {
        get => outputItem;
        set => outputItem = value;
    }
}
