namespace ProjectCare.Scripts;
using Godot;

public partial class BarrelInteractive : Interactable
{
    //TODO add a godot array or something to store a random item (or none)
    public override string Prompt => "Press E to rummage";

    public override void Interact(Pet pet)
    {
        base.Interact(pet);
        GD.Print("Nothing here!");

        //TODO handle interacting with bucket
        
    }
    
    
}