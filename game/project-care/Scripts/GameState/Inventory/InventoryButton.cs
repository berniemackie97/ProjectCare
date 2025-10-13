using Godot;
using ProjectCare.Scripts.Enums;

namespace ProjectCare.Scripts.GameState;

public partial class InventoryButton : Button
{

    private TextureRect icon;
    private Label quantityLabel;
    private int index;
    private Item inventoryItem;

    public override void _Ready()
    {
        icon = GetNode<TextureRect>("TextureRect");
        quantityLabel = GetNode<Label>("Label");

    }

    public override void _Process(double delta)
    {
        
    }

    public void UpdateItem(Item item, int index)
    {
        this.index = index;
        inventoryItem = item;
    }
    
    
}