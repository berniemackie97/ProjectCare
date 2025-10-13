using ProjectCare.Scripts.Resources.Inventory;

namespace ProjectCare.Scripts.Resources;
using Godot;


[GlobalClass]
public partial class StoreItem : Resource
{
    [Export] public ItemDef Item;
    [Export] public int Price { get; set; } = 0;
    [Export] public int MaxStock { get; set; } = -1;
    
    
    
}