using Godot;
using Godot.Collections;
using ProjectCare.Scripts.Resources.Inventory;

namespace ProjectCare.Scripts.GameState;

public partial class GameDB : Node
{
    
    public static GameDB Instance { get; private set; }

    [Export] public Array<ItemDef> Items;
    
    private Dictionary<int, ItemDef> _map = new();

    public override void _Ready()
    {
        Instance = this;
        foreach (ItemDef itemDef in Items)
        {
            if (itemDef != null) _map[itemDef.Id] = itemDef;
        }
    }

    public ItemDef GetById(int id)
    {
        if (_map.TryGetValue(id, out var itemDef)) return itemDef;
        return null;
    }

}