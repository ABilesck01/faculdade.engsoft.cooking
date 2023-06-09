using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private FinishScreen finishScreen;

    [SerializeField] private List<BaseIngredient> acceptableItems = new List<BaseIngredient>();

    public void Interact(PlayerHands player)
    {
        if(acceptableItems.Contains(player.GetIngredientInHand))
            finishScreen.OpenScreen();
    }
}
