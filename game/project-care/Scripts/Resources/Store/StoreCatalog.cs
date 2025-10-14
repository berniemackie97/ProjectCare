using Godot;

namespace ProjectCare.Scripts.Resources;


[GlobalClass]
public partial class StoreCatalog : Resource {
    [Export] public Godot.Collections.Array<StoreEntry> Items;
}