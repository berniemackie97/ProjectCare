namespace ProjectCare.Scripts.Resources.Inventory;

using Godot;

[GlobalClass]
public partial class ItemDef : Resource
{
    [Export] public int Id { get; set; }
    [Export] public string DisplayName;
    [Export] public string ResourcePath;
    [Export] public Texture2D Icon;
    [Export] public bool Stackable = true;
    [Export] public int StackSize = 99;
    [Export] public Script UseMainScript;
    [Export] public Script UseAltScript;

}