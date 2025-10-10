namespace ProjectCare.Scripts.UI;

using Godot;

public partial class UIController : Node
{
    private Control _inventory;
    private bool _inventoryOpen = false;

    public override void _Ready()
    {
        _inventory = GetNode<Control>("../Inventory");
        _inventory.Visible = false;
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (Input.IsActionJustPressed("ui_inventory"))
        {
            ToggleInventory();
        }
    }

    private void ToggleInventory()
    {
        _inventoryOpen = !_inventoryOpen;
        _inventory.Visible = _inventoryOpen;

        GetTree().Paused = _inventoryOpen;
        if (_inventoryOpen)
            _inventory.GrabFocus();
    }
}