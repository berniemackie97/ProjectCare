namespace ProjectCare.Scripts;

using Godot;
using ProjectCare.Scripts.Enums;

public partial class WellInteractive : Interactable
{
	[Export] public float HydrationAmount { get; set; } = 20f;

	public override string Prompt => "Press E to drink";

	public override void Interact(Pet pet)
	{
		base.Interact(pet);
		pet.DoTaskBoost(TaskType.Hydrate, HydrationAmount);
		GD.Print("Pet drank from well.");
	}
}
