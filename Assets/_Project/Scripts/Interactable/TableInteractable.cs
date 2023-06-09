using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class TableInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] [CanBeNull] private List<RecipeData> recipeDataList = new List<RecipeData>();
    [SerializeField] private Transform gfx;
    [Space] 
    [SerializeField] private Vector2 minMaxX;
    [SerializeField] private Vector2 minMaxY;
    
    private List<BaseIngredient> inputItems;
    private BaseIngredient output;
    
    public void Interact(PlayerHands player)
    {
        if (player.GetIngredientInHand is null && output is not null)
        {
            ResetGfx();
            player.SetItemInHand(output);
            output = null;
            return;
        }

        if (player.GetIngredientInHand is not null && output is not null)
        {
            if (inputItems == null)
                inputItems = new List<BaseIngredient>();
        
            inputItems.Add(output);
            output = null;
        }

        if(player.GetIngredientInHand is null && output is null) return;
        

        if (inputItems == null)
            inputItems = new List<BaseIngredient>();
        
        inputItems.Add(player.GetIngredientInHand);
        
        if (CheckAllRecipes())
        {
            ResetGfx();
            Instantiate(output.IngredientGraphic, gfx);
        }
        else
        {
            UpdateGfx(player.GetIngredientInHand.IngredientGraphic);
        }
        player.SetItemInHand(null);
        
    }

    private void ResetGfx()
    {
        foreach (Transform child in gfx)
        {
            Destroy(child.gameObject);
        }
    }
    
    private void UpdateGfx(GameObject newGfx)
    {
        var item = Instantiate(newGfx, gfx).transform;
        item.localPosition += new Vector3(
        Random.Range(minMaxX.x, minMaxX.y),
        0,
        Random.Range(minMaxY.x, minMaxY.y)
            );
    }

    private bool CheckAllRecipes()
    {
        if (recipeDataList is null) return false;
        
        foreach (RecipeData data in recipeDataList)
        {
            if(Craft(data))
                return true;
        }

        return false;
    }
    
    private bool Craft(RecipeData recipe)
    {
        List<BaseIngredient> cloneList = new List<BaseIngredient>();
        recipe.InputIngredients.ForEach(item => cloneList.Add(item));
        
        foreach (BaseIngredient item in inputItems)
        {
            if (cloneList.Contains(item))
            {
                cloneList.Remove(item);
            }
        }

        if (cloneList.Count == 0)
        {
            inputItems.Clear();
            output = recipe.OutputItem;
            return true;
            //player.HoldItem(chosenRecipe.outputItem);
        }
        
        return false;
    }
}
