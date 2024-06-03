using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI pearText;


    private void Start()
    {
        pearText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdatePearText(PlayerInventory playerInventory)
    {
        pearText.text = playerInventory.NumberOfPears.ToString();
    }
}
