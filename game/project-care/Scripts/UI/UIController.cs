using Godot;
namespace ProjectCare.UI;

public partial class UIController : Node
{
    private Control _inventory;
    private bool _open;

    public override void _Ready()
    {

        setupInventory();
        
    }

    public override void _Input(InputEvent e)
    {
        if (Input.IsActionJustPressed("ui_inventory"))
            ToggleInventory();
    }

    private void ToggleInventory()
    {
        if (_inventory == null) return;
        _open = !_open;
        _inventory.Visible = _open;
        GD.Print(_open ? "Inventory opened" : "Inventory closed");
    }

    private void setupInventory()
    {
        _inventory = GetNodeOrNull<Control>("../Inventory");
        _inventory.Visible = false;
    }
    
}