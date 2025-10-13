using System.Collections.Generic;
using Godot;
using ProjectCare.Scripts.Interfaces;
using ProjectCare.Scripts.Resources;
using ProjectCare.Scripts.Resources.Inventory;

namespace ProjectCare.Scripts.GameState;

public partial class StoreInventory : Control
{

    [Export] private PackedScene inventoryButtonScene;
    private GridContainer _grid;

    private readonly List<StoreEntry> _catalog = new();

    public override void _Ready()
    {
        _grid = GetNode<GridContainer>("NinePatchRect/Grid");
        PopulateButtons();
    }

    private void PopulateButtons()
    {
        foreach (StoreEntry entry in _catalog)
        {
            if (entry == null || entry.Item == null) continue;

            InventoryButton btn = inventoryButtonScene.Instantiate<InventoryButton>();
            _grid.AddChild(btn);

            btn.SetIcon(entry.Item.Icon);
            btn.SetBadge("$" + entry.Price.ToString());
        }
    }
    
    public void SetCatalog(IEnumerable<StoreEntry> entries)
    {
        _catalog.Clear();
        if (entries != null)
            foreach (StoreEntry e in entries)
                if (e != null && e.Item != null) _catalog.Add(e);

        Refresh();
    }
    
    
    private void Refresh()
    {
        foreach (Node n in _grid.GetChildren()) n.QueueFree();

        foreach (StoreEntry entry in _catalog)
        {
            InventoryButton btn = inventoryButtonScene.Instantiate<InventoryButton>();
            _grid.AddChild(btn);
            btn.SetIcon(entry.Item.Icon);
            btn.SetBadge("$" + entry.Price.ToString());
        }
    }
    
    
    
    




}