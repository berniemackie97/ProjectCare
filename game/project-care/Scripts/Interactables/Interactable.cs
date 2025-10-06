using ProjectCare.Scripts.Interfaces;
namespace ProjectCare.Scripts;
using Godot;
public partial class Interactable : Area2D, IInteractable
{
    [Export] public float CooldownSeconds { get; set; } = 1.0f;
    private double _cooldownExpiresAt;

    public virtual string Prompt => "Press E";

    public virtual bool CanInteract(Pet pet)
    {
        return Time.GetTicksMsec() / 1000.0 >= _cooldownExpiresAt;
    }

    public virtual void Interact(Pet pet)
    {
        if (!CanInteract(pet)) return;
        _cooldownExpiresAt = Time.GetTicksMsec() / 1000.0 + CooldownSeconds;
        GD.Print($"{Name} was interacted with.");
    }
}