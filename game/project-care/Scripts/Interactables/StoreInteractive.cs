using System.Collections.Generic;
using ProjectCare.Scripts.GameState;
using ProjectCare.Scripts.Resources;
namespace ProjectCare.Scripts;
using Godot;

public partial class StoreInteractive : Interactable
{
    [Signal]
    public delegate void StoreOpenedEventHandler(Godot.Collections.Array<StoreEntry> catalog, Pet pet);

    [Export] public Godot.Collections.Array<StoreEntry> Catalog { get; set; }

    public override string Prompt => "Press E to open store";

    public override void _Ready()
    {
        AddToGroup("Stores");
    }

    public override void Interact(Pet pet)
    {
        base.Interact(pet);
        GD.Print("Opening store, entries=", Catalog?.Count ?? 0);
        EmitSignal(SignalName.StoreOpened, Catalog, pet);
    }
}