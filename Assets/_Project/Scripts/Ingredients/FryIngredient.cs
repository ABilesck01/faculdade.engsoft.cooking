using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Assets/Fry ingredient")]
public class FryIngredient : BaseIngredient
{
    [SerializeField] private float frySpeed;
    [SerializeField] private BaseIngredient outputIngredient;

    public float FrySpeed
    {
        get => frySpeed;
        set => frySpeed = value;
    }

    public BaseIngredient OutputIngredient
    {
        get => outputIngredient;
        set => outputIngredient = value;
    }
}
