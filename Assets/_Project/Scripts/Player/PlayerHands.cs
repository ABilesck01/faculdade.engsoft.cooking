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

    private void Interact()
    {
        var interactions = Physics.OverlapSphere()
    }
}
