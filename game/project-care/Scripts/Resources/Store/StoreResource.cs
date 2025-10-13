namespace ProjectCare.Scripts.Resources;

using Godot;

[GlobalClass]
public partial class StoreResource : Resource
{
    [Export]
    public Godot.Collections.Array<StoreItem> Items { get; set; } = new();
    
}