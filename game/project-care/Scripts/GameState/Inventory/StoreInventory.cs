using System.Collections.Generic;
using Godot;
using ProjectCare.Scripts.Interfaces;
using ProjectCare.Scripts.Resources.Inventory;

namespace ProjectCare.Scripts.GameState;

public partial class StoreInventory : Control
{

    [Export] private PackedScene inventoryButtonScene;
    private GridContainer _grid;

    private readonly List<(int ItemId, int Price)> _catalog = new();

    public override void _Ready()
    {
        _grid = GetNode<GridContainer>("NinePatchRect/Grid");
        _catalog.Add((0, 10));
        _catalog.Add((1, 25));
        
        PopulateButtons();
        
    }

    private void PopulateButtons()
    {
        foreach ((int ItemId, int Price) entry in _catalog)
        {
            int itemId = entry.ItemId;
            int price  = entry.Price;

            InventoryButton btn = inventoryButtonScene.Instantiate<InventoryButton>();
            _grid.AddChild(btn);

            ItemDef def = GameDB.Instance.GetById(itemId);
            btn.SetIcon(def?.Icon);
            btn.SetBadge($"${price}");
        }
    }




}