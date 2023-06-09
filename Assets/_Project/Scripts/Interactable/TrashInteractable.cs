using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashInteractable : MonoBehaviour, IInteractable
{
    public void Interact(PlayerHands player)
    {
        player.SetItemInHand(null);
    }
}
