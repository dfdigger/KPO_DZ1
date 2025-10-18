namespace KPO_DZ_1_Library.Zoo;
using Alive.Animals;
using VetClinic;
using Inventory;

public interface IZoo
{
    public List<IAnimal> Animals { get;  set; }
    public int AmountOfAnimals { get; }
    public IVetClinic Clinic { get; set; }
    public IInventory Inventory { get; set; }
    
    // Добавляет животного в баланс зоопарка, если оно одобрено ветеринарной клиникой
    public bool TryAddNewAnimal(IAnimal animal);
    // Количество вещей инвенторя зоопарка
    public int GetNumberOfInventory();

    public void PrintAllAnimals();

}