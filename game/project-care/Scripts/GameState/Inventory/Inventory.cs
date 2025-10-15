using System.Collections.Generic;
using Godot;
using ProjectCare.Scripts.Enums;
using ProjectCare.Scripts.Interfaces;
using ProjectCare.Scripts.Resources.Inventory;
using ProjectCare.UI;

namespace ProjectCare.Scripts.GameState;

public partial class Inventory : AbstractGrid, IInventorySystem
{
    
    [Export] public int Capacity { get; set; } = 18;

    private List<ItemSlot> _slots = new();
    
    public override void _Ready()
    {
        PopulateSlots();
        PopulateButtons();
        setupInitialItems();
    }
    private void setupInitialItems()
    {
        AddItem(GameDB.Instance.GetById(0), 10);
        AddItem(GameDB.Instance.GetById(1), 15);
        RemoveItem(1, 5);
    }

    protected override void PopulateButtons()
    {
        for (int i = 0; i < Capacity; i++)
        {
            GD.Print("Added Button");
            InventoryButton currentInventoryButton = ButtonScene.Instantiate<InventoryButton>();
            currentInventoryButton.Init(this, i);
            GridContainer.AddChild(currentInventoryButton);
            UpdateButton(i);
        }
    }
    
    public override void OnSlotPressed(int index)
    {
        GD.Print($"Slot {index} pressed");
        selectedSlotIndex = index;
    }

    private void PopulateSlots()
    {
        for (int i = 0; i < Capacity; i++)
        {
            _slots.Add(new ItemSlot());
        }
    }

    public int AddItem(ItemDef itemDef, int amount) {
        
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
    
    public int RemoveItem(int itemId, int amount)
    {
        if (amount <= 0) return amount;

        for (int i = 0; i < _slots.Count && amount > 0; i++)
        {
            var s = _slots[i];
            if (s.Id != itemId || s.Count == 0) continue;

            int take = Mathf.Min(s.Count, amount);
            s.Count -= take;
            amount  -= take;

            if (s.Count == 0) { s.Id = -1; }
            UpdateButton(i);
        }

        return amount;
    }
    public int RemoveItem(ItemDef def, int amount) => def == null ? amount : RemoveItem(def.Id, amount);

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

    private InventoryButton getButtonInGrid(int index) => GridContainer.GetChild<InventoryButton>(index);

    public ItemSlot getSlotAtIndex()
    {
        if (selectedSlotIndex == null) return null;
        return _slots[selectedSlotIndex.Value];
    }
    
    public void _on_add_button_button_down()
    {
        
    }

    public override void _Process(double delta)
    {
        
    }
    
    
}