using Godot;

namespace ProjectCare.UI;


public abstract partial class AbstractGrid : Control
{
    [Export] public PackedScene ButtonScene { get; set; }
    [Export] public GridContainer GridContainer { get; set; }

    public int? selectedSlotIndex;

    protected abstract void PopulateButtons();

    public abstract void OnSlotPressed(int index);








}