using System.Collections.Generic;
using Godot;
using ProjectCare.Scripts.Interfaces;
using ProjectCare.Scripts.Resources;
using ProjectCare.Scripts.Resources.Inventory;
using ProjectCare.UI;

namespace ProjectCare.Scripts.GameState;

public partial class StoreInventory : AbstractGrid
{

    private readonly List<StoreEntry> _catalog = new();

    protected override void PopulateButtons()
    {
        for (int i = 0; i < _catalog.Count; i++)
        {

            StoreEntry entry = _catalog[i];
            
            if (entry == null || entry.Item == null) continue;

            InventoryButton btn = ButtonScene.Instantiate<InventoryButton>();
            btn.Init(this, i);
            GridContainer.AddChild(btn);

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

    public override void OnSlotPressed(int index)
    {
        selectedSlotIndex = index;
        
    }
    
    
    private void Refresh()
    {
        foreach (Node n in GridContainer.GetChildren()) n.QueueFree();
        PopulateButtons();
    }
    
    
    
    




}