using Godot;
using ProjectCare.Scripts;
using ProjectCare.Scripts.GameState;

namespace ProjectCare.UI;

public partial class UIController : Node
{
    private Control _inventory;
    private Control _storeUI;
    private bool _inventoryOpen;
    private bool _storeOpen;

    public override void _Ready()
    {

        setupInventory();
        SetupStoreUI();

        foreach (StoreInteractive store in GetTree().GetNodesInGroup("Stores"))
        {
            store.StoreOpened += OnStoreOpened;
        }
        
    }

    public override void _Input(InputEvent e)
    {
        if (Input.IsActionJustPressed("ui_inventory"))
            ToggleInventory();
    }

    private void ToggleInventory()
    {
        if (_inventory == null || _storeOpen) return;
        _inventoryOpen = !_inventoryOpen;
        _inventory.Visible = _inventoryOpen;
        GD.Print(_inventoryOpen ? "Inventory opened" : "Inventory closed");
    }

    private void setupInventory()
    {
        _inventory = GetNodeOrNull<Control>("../Inventory");
        _inventory.Visible = false;
    }

    private void SetupStoreUI()
    {
        _storeUI = GetNodeOrNull<Control>("../StoreUI");
        if (_storeUI != null)
            _storeUI.Visible = false;
    }
    
    private void OnStoreOpened(StoreInventory store, Pet pet)
    {
        GD.Print("Store opened");
        if (_inventory == null) GD.Print("FUuuck");
        OpenStore(store);
        GD.Print($"Store opened for {pet.Name}");
    }
    
    public void OpenStore(Control storeNode)
    {
        _storeUI = storeNode;
        _inventoryOpen = true;
        _inventory.Visible = true;
        _storeUI.Visible = true;
        _storeOpen = true;
        GD.Print("Store opened");
    }

    public void CloseStore()
    {
        if (_storeUI == null) return;
        _storeUI.Visible = false;
        _storeOpen = false;
        GD.Print("Store closed");
    }
    
    
}