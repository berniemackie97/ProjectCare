using ProjectCare.Scripts.Resources.Inventory;

namespace ProjectCare.Scripts.Interfaces;

public interface IInventorySystem
{

    int AddItem(ItemDef itemDef, int amountToAdd);


}