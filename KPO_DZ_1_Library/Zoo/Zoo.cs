namespace KPO_DZ_1_Library.Zoo;
using Alive.Animals;
using VetClinic;
using Inventory;

public class Zoo : IZoo
{
    public string Name { get; set; }
    public List<IAnimal> Animals { get; set; }
    public int AmountOfAnimals => Animals.Count;
    public IVetClinic Clinic { get; set; }
    public IInventory Inventory { get; set; }

    public Zoo(string name, List<IAnimal> animals, IVetClinic clinic, IInventory inventory)
    {
        Name = name;
        Animals = animals;
        Clinic = clinic;
        Inventory = inventory;
    }

    public bool TryAddNewAnimal(IAnimal animal)
    {
        if (Clinic.CheckAnimal(animal))
        {
            Animals.Add(animal);
            return true;
        }

        return false;
    }

    public int GetNumberOfInventory()
    {
        return Inventory.Number;
    }

    public void PrintAllAnimals()
    {
        Console.WriteLine($"Список животных зоопарка {Name}:\n");
        if (AmountOfAnimals == 0)
        {
            Console.WriteLine("Пока нет животных.");
            return;
        }

        int id = 1;
        foreach (IAnimal animal in Animals)
        {
            Console.WriteLine($"{id++}.");
            Console.WriteLine(animal);
            Console.WriteLine("\n");
        }
    }
}