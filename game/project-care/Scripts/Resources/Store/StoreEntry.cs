using Godot;
using ProjectCare.Scripts.Resources.Inventory;

namespace ProjectCare.Scripts.Resources;

[GlobalClass]
public partial class StoreEntry : Resource {
    [Export] public ItemDef Item;
    [Export] public int Price;
    [Export] public int Stock;

}