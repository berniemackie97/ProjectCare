using ProjectCare.Scripts.Resources;
namespace ProjectCare.Scripts;
using Godot;

public partial class StoreInteractive : Interactable
{
    [Export] public StoreResource StoreData { get; set; }

    public override string Prompt => "Press E to open store";

    public override void Interact(Pet pet)
    {
        base.Interact(pet);
        GD.Print("Opening store");

        //TODO Add an emit signal for a store ui to open
        
    }
    
}