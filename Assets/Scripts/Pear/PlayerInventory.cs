using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory: MonoBehaviour
{
    public int NumberOfPears { get; private set; }

    public UnityEvent<PlayerInventory> OnPearCollected;

    public void PearCollected()
    {
        NumberOfPears++;
        OnPearCollected.Invoke(this);
    }
}