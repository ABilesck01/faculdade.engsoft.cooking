using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHands : MonoBehaviour
{
    [SerializeField] private Transform handsPosition;
    [SerializeField] private float interactionRadius;
    [SerializeField] private LayerMask interactionLayer;
    [SerializeField] private Transform gfxPoint;
    [Space] 
    [SerializeField] private BaseIngredient ingredientInHand;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Interact();
        }
    }

    
    /// <summary>
    /// Get near interaction object and call its interact
    /// </summary>
    private void Interact()
    {
        Collider[] alloc = new Collider[1];
        int interaction = Physics.OverlapSphereNonAlloc(handsPosition.position, interactionRadius, alloc, interactionLayer);
        
        if(interaction <= 0) return;

        if (alloc[0].TryGetComponent(out IInteractable interactable))
        {
            interactable.Interact(this);
        }

    }

    
    /// <summary>
    /// Sets a new ingredient in hand and updates gfx
    /// </summary>
    /// <param name="ingredient"> new ingredient to set</param>
    public void SetItemInHand(BaseIngredient ingredient)
    {
        ClearGfx();
        
        ingredientInHand = ingredient;
        
        if(ingredientInHand == null) return;

        if (ingredientInHand.IngredientGraphic == null) return;

        Instantiate(ingredientInHand.IngredientGraphic, gfxPoint);
    }

    private void ClearGfx()
    {
        foreach (Transform child in gfxPoint)
        {
            Destroy(child.gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(!handsPosition) return;
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(handsPosition.position, interactionRadius);
    }
}
