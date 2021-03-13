using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{

    [SerializeField] AmmoSlot[] ammoSlots;

    
    [System.Serializable]
    private class AmmoSlot
    {
        
        public Ammotype ammoType;
        public int ammoAmount;
    }
    public float GetCurrentAmmo(Ammotype ammotype)
    {
        return GetAmmoSlot(ammotype).ammoAmount;
    }

   
    public void ReduceCurrentAmmo(Ammotype ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount--;
    }
    public void IncreaseCurrentAmmo(Ammotype ammoType, int ammoAmount)
    {
        GetAmmoSlot(ammoType).ammoAmount += ammoAmount;
    }

    private AmmoSlot GetAmmoSlot(Ammotype ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }

}
