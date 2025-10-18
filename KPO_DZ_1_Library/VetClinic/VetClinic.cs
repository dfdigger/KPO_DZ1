using KPO_DZ_1_Library.Alive.Animals;

namespace KPO_DZ_1_Library.VetClinic;

public class VetClinic : IVetClinic
{
    public string Name { get; set; }
    
    public VetClinic(string name)
    {
        Name = name;
    }

    public bool CheckAnimal(IAnimal animal)
    {
        if (animal.HealthStatus == "Healthy")
        {
            return true;
        }
        return false;
    }
    
    public string InfoAboutAnimal(IAnimal animal)
    {
        return animal.ToString();
    }
}