namespace KPO_DZ_1_Library.Alive.Animals;

public abstract class Animal : Alive, IAnimal
{
    public string Name { get; set; }
    
    public Animal(string name, int food, string healthStatus) : base(food, healthStatus)
    {
        Name = name;
    }

    public override string ToString()
    {
        return $"Имя: {Name}\nКол-во еды в сутки:{Food}\nСостояние здоровья: {HealthStatus}";
    }
}