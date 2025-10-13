using Godot;
 using ProjectCare.Scripts.Enums;
 using ProjectCare.Scripts.Resources.Inventory;
 
 namespace ProjectCare.Scripts.GameState;
 
 public partial class InventoryButton : Button
 {
 
     private TextureRect icon;
     private Label quantityLabel;
 
     public override void _Ready()
     {
         icon = GetNode<TextureRect>("TextureRect");
         quantityLabel = GetNode<Label>("Label");
     }
 
     public void SetIcon(Texture2D icon) => this.icon.Texture = icon;
     public void SetCount(int newCount)
     {
         SetBadge(newCount > 1 ? newCount.ToString() : "");
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