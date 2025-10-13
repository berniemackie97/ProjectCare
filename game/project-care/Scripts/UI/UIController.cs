using Godot;
using ProjectCare.Scripts;
using ProjectCare.Scripts.Enums;
using ProjectCare.Scripts.GameState;
using ProjectCare.Scripts.Resources;

namespace ProjectCare.UI;

public partial class UIController : Node
{
    
    [Export] private Control InventoryUI;
    [Export] private Control StoreUI;
    
    private bool _inventoryOpen;
    private bool _storeOpen;
    
    

    public override void _Ready()
    {
        
        foreach (StoreInteractive store in GetTree().GetNodesInGroup("Stores"))
        {
            store.StoreOpened += OnStoreOpened;
        }
        HideAll();
        setUIState(UIState.Default);
        
    }

    public override void _Input(InputEvent e)
    {
        if (Input.IsActionJustPressed("ui_inventory"))
            ToggleInventory();
    }

    private void ToggleInventory()
    {
        if (!_inventoryOpen)
        {
            setUIState(UIState.Inventory);
        } else
        {
            setUIState(UIState.Default);
        }
    }
    
    private void OnStoreOpened(Godot.Collections.Array<StoreEntry> catalog, Pet pet)
    {
        StoreInventory ui = StoreUI as StoreInventory;
        ui.SetCatalog(catalog);
        setUIState(UIState.Store);
    }
    
    private void HideAll()
    {
        if (InventoryUI != null)
        {
            InventoryUI.Visible = false;
            _inventoryOpen = false;
        }

        if (StoreUI != null)
        {
            StoreUI.Visible = false;
            _storeOpen = false;
        }
    }

    public void setUIState(UIState newState)
    {
        HideAll();
        
        switch (newState)
        {
            case UIState.Default :
                return;
            case UIState.Inventory :
                InventoryUI.Visible = true;
                _inventoryOpen = true;
                break;
            case UIState.Store :
                InventoryUI.Visible = true;
                _inventoryOpen = true;
                StoreUI.Visible = true;
                _storeOpen = true;
                break;
            default:
                return;
        }
    }
    
    
}