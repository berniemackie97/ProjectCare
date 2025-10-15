namespace ProjectCare.Scripts.Interfaces;

public interface IStoreSystem
{
    int GetPrice(int itemId);
    int GetStock(int itemId);
    int RemoveStock(int itemId, int amount);
}