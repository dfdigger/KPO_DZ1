namespace KPO_DZ_1_Library.Alive.Animals;

public abstract class Omni : Animal
{
    public string Type { get; set; } = "Omni";
    protected Omni(string name, int food, string healthStatus) : base(name, food, healthStatus){}

    public override string ToString()
    {
        return $"Имя: {Name}\nТип: {Type}\nКол-во еды в сутки:{Food}\nСостояние здоровья: {HealthStatus}";
    }
}