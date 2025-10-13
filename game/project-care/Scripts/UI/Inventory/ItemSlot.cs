using System.Collections.Generic;
using Godot;
using ProjectCare.Scripts.Resources.Inventory;

namespace ProjectCare.Scripts.GameState;

public class ItemSlot
{
    
    public int? Id = -1;
    public int Count = 0;
    
    

    public ItemDef GetItemDef()
    {
        return GameDB.Instance.GetById(Id.Value);
    }

    public bool IsCorrectItem(int itemId) => this.Id == itemId;
    public bool IsFull (int stackSize) => this.Count >= stackSize;
    public bool IsEmpty() => Id == -1 || Count == 0;

    public int GetAllowedAddAmount(ItemDef itemDef, int amount) => Mathf.Min(itemDef.StackSize - Count, amount);

    public int TryAddToExistingSlot(ItemDef def, int amount)
    {
        if (!IsCorrectItem(def.Id) || IsFull(def.StackSize)) return amount;
        int canAdd = GetAllowedAddAmount(def, amount);
        Count += canAdd;
        return amount - canAdd;
    }
    
    public int FillEmpty(ItemDef itemDef, int amount)
    {
        if (!IsEmpty()) return amount;
        int toPlace = Mathf.Min(itemDef.StackSize, amount);
        Id = itemDef.Id;
        Count = toPlace;
        return amount - toPlace;
    }
    
    public void Clear()
    {
        Id = -1;
        Count = 0;
    }



}