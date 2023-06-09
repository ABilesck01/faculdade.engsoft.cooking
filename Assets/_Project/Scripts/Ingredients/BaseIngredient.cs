using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Assets/New base ingredient")]
public class BaseIngredient : ScriptableObject
{
    [SerializeField] private string ingredientName;
    [SerializeField] private GameObject ingredientGraphic;

    public string IngredientName
    {
        get => ingredientName;
        set => ingredientName = value;
    }

    public GameObject IngredientGraphic
    {
        get => ingredientGraphic;
        set => ingredientGraphic = value;
    }
}
