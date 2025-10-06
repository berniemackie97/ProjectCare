using ProjectCare.Scripts.Interfaces;
namespace ProjectCare.Scripts;
using Godot;
using System.Collections.Generic;
using System.Linq;


public partial class Interactor : Node2D
{
    [Export] public NodePath InteractZonePath { get; set; }
    private Area2D _zone;
    private readonly HashSet<IInteractable> _inRange = new();

    public override void _Ready()
    {
        _zone = GetNode<Area2D>(InteractZonePath);
        _zone.Monitoring = true; 
        _zone.Monitorable = true;

        _zone.AreaEntered += area => { if (area is IInteractable interactable) _inRange.Add(interactable); };
        _zone.AreaExited  += area => { if (area is IInteractable interactable) _inRange.Remove(interactable); };

    }

    public override void _Process(double delta)
    {
        if (!Input.IsActionJustPressed("interact")) return;

        Pet pet = GetParent<Pet>();
        IInteractable target = ClosestValidInteractable(pet);
        target?.Interact(pet);
    }

    private IInteractable ClosestValidInteractable(Pet pet)
    {
        return _inRange
            .Where(interactable => interactable.CanInteract(pet) && interactable is Node2D)
            .OrderBy(interactable => ((Node2D)interactable).GlobalPosition.DistanceTo(pet.GlobalPosition))
            .FirstOrDefault();
    }
    
}