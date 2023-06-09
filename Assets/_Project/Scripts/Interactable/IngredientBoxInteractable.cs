using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientBoxInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private BaseIngredient ingredient;
    [SerializeField] private Transform gfx;

    private void Start()
    {
        if(gfx)
            Instantiate(ingredient.IngredientGraphic, gfx);
    }

    public void Interact(PlayerHands player)
    {
        if(player.GetIngredientInHand != null) return;
        
        player.SetItemInHand(ingredient);
    }
}
