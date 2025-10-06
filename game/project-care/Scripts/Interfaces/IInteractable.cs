namespace ProjectCare.Scripts.Interfaces

{
    public interface IInteractable
    {
        bool CanInteract(Pet pet);
        void Interact(Pet pet);
        string Prompt { get; }
        
    }
}