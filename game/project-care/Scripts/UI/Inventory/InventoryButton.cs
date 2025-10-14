using Godot;
 using ProjectCare.Scripts.Enums;
 using ProjectCare.Scripts.Resources.Inventory;
 
 namespace ProjectCare.Scripts.GameState;
 
 public partial class InventoryButton : Button
 {
 
     [Export] private TextureRect icon;
     [Export] private Label quantityLabel; 
     [Export] private Sprite2D SlotIcon;
     private Inventory _inventory;
     private int _index;

     public void Init(Inventory inventory, int index)
     {
         _inventory = inventory;
         _index = index;
         Pressed += OnPressed;
     }

     private void OnPressed()
     {
         _inventory.OnSlotPressed(_index);
     }

     public override void _Process(double delta)
     {
         bool isSelected = _index == _inventory.selectedSlot;
         this.setSelected(isSelected);
     }
 
     public void SetIcon(Texture2D icon) => this.icon.Texture = icon;
     public void SetCount(int newCount)
     {
         SetBadge(newCount > 1 ? newCount.ToString() : "");
     }

     public void setSelected(bool isVisible)
     {
         int frame = isVisible ? 1 : 0;
         this.SlotIcon.Frame = frame;
     }
     
     public void SetBadge(string text)
     {
         quantityLabel.Text = text ?? "";
     }
 
     public void clear()
     {
         this.SetIcon(null);
         this.SetCount(0);
     }
     
     
 
 
 }