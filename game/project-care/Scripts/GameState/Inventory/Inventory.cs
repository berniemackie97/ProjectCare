using System.Collections.Generic;
using Godot;
using ProjectCare.Scripts.Enums;
using ProjectCare.Scripts.Resources.Inventory;

namespace ProjectCare.Scripts.GameState;

public partial class Inventory : Control
{

    private GridContainer _gridContainer;
    [Export] private PackedScene inventoryButtonScene;
    [Export] public int Capacity { get; set; } = 18;

    private List<ItemSlot> _slots = new();
    public override void _Ready()
    {
        _gridContainer = GetNode<GridContainer>("NinePatchRect/Grid");
        populateSlots();
        populateButtons();
        setupInitialItems();
    }

    private void setupInitialItems()
    {
        Add(GameDB.Instance.GetById(0), 10);
    }

    private void populateButtons()
    {
        for (int i = 0; i < Capacity; i++)
        {
            InventoryButton currentInventoryButton = inventoryButtonScene.Instantiate<InventoryButton>();
            _gridContainer.AddChild(currentInventoryButton);
            UpdateButton(i);
        }
    }

    private void populateSlots()
    {
        for (int i = 0; i < Capacity; i++)
        {
            _slots.Add(new ItemSlot());
        }
    }

    public int Add(ItemDef itemDef, int amount = 1) {
        
        if (itemDef == null || amount <= 0) return amount;

        for (int i = 0; i < _slots.Count && amount > 0; i++) {
            amount = _slots[i].TryAddToExistingSlot(itemDef, amount);
            UpdateButton(i);
        }

        for (int i = 0; i < _slots.Count && amount > 0; i++) {
            amount = _slots[i].FillEmpty(itemDef, amount);
            UpdateButton(i);
        }

        return amount;
    }

    public void UpdateButton(int index)
    {
        InventoryButton button = getButtonInGrid(index);
        ItemSlot itemSlot = _slots[index];

        if (itemSlot.Id == -1 || itemSlot.Count == 0)
        {
            button.clear();
            return;
        }

        ItemDef itemDef = itemSlot.GetItemDef();
        button.SetIcon(itemDef?.Icon);
        button.SetCount(itemSlot.Count);
    }

    private InventoryButton getButtonInGrid(int index) => _gridContainer.GetChild<InventoryButton>(index);

    public void _on_add_button_button_down()
    {
        
    }

    public override void _Process(double delta)
    {
        
    }
    
    
}