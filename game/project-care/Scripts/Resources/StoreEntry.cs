namespace ProjectCare.Scripts.Resources;
using Godot;


[GlobalClass]
public partial class StoreEntry : Resource
{
    [Export] public string ItemId { get; set; } = "";
    [Export] public int Price { get; set; } = 0;
    [Export] public int MaxStock { get; set; } = 20;
    
}