namespace ProjectCare.Scripts.Resources;

using Godot;

[GlobalClass]
public partial class StoreResource : Resource
{
    [Export]
    public Godot.Collections.Array<StoreEntry> Items { get; set; } = new();
    
}