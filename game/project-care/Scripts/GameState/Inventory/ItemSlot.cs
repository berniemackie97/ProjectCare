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
    
    
}