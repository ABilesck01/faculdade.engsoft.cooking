using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookIngredient : MonoBehaviour
{
    [SerializeField] private float cookSpeed;
    [SerializeField] private BaseIngredient outputIngredient;

    public float CookSpeed
    {
        get => cookSpeed;
        set => cookSpeed = value;
    }

    public BaseIngredient OutputIngredient
    {
        get => outputIngredient;
        set => outputIngredient = value;
    }
}
