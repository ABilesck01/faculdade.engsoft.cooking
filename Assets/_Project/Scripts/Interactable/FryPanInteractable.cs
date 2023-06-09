using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FryPanInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform gfx;
    [SerializeField] private Slider progressSlider;

    private FryIngredient _currentIngredient;
    private bool _isFryingIngredient = false;
    private float _currentTime = 0;
    private BaseIngredient output;
    
    private void Start()
    {
        progressSlider.gameObject.SetActive(false);
    }

    public void Interact(PlayerHands player)
    {

        if (output != null)
        {
            player.SetItemInHand(output);
            output = null;
            ClearGfx();
            _currentTime = 0;
        }
        
        if(player.GetIngredientInHand == null) return;
        
        if (player.GetIngredientInHand is not FryIngredient) return;

        _currentIngredient = player.GetIngredientInHand as FryIngredient;

        player.SetItemInHand(null); //clear the item in players hand

        _isFryingIngredient = true;
        progressSlider.value = 0;
        progressSlider.maxValue = _currentIngredient.FrySpeed;
        progressSlider.gameObject.SetActive(true);
        ClearGfx();
        
        Instantiate(_currentIngredient.IngredientGraphic, gfx);
    }

    private void Update()
    {
        if(!_isFryingIngredient) return;

        _currentTime += Time.deltaTime;
        progressSlider.value = _currentTime;
        if (_currentTime >= _currentIngredient.FrySpeed)
        {
            ClearGfx();
            progressSlider.gameObject.SetActive(false);
            _isFryingIngredient = false;
            output = _currentIngredient.OutputIngredient;
            Instantiate(_currentIngredient.OutputIngredient.IngredientGraphic, gfx);
        }

    }

    private void ClearGfx()
    {
        foreach (Transform child in gfx)
        {
            Destroy(child.gameObject);
        }
    }
}
