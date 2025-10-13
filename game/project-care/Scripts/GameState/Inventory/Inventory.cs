using Godot;

namespace ProjectCare.Scripts.GameState;

public partial class Inventory : Control
{

    private GridContainer _gridContainer;
    private PackedScene inventoryButton;
    [Export] private string itemButtonPath = "res://Scenes/Inventory/inventory_button.tscn";
    [Export] public int Capacity { get; set; } = 24;
    public override void _Ready()
    {
        _gridContainer = GetNode<GridContainer>("NinePatchRect/Grid");
        inventoryButton = ResourceLoader.Load<PackedScene>(itemButtonPath);
        populateButtons();
    }

    private void populateButtons()
    {
        for (int i = 0; i < Capacity; i++)
        {
            InventoryButton currentInventoryButton = inventoryButton.Instantiate<InventoryButton>();
            _gridContainer.AddChild(currentInventoryButton);
        }
    }

    public override void _Process(double delta)
    {
        
    }
    
    
}