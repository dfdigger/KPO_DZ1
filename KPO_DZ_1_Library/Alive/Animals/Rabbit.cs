namespace KPO_DZ_1_Library.Alive.Animals;

public class Rabbit : Herbo
{
    public string PodType { get; set; } = "Rabbit";
    
    public Rabbit(string name, int food, string healthStatus) : base(name, food, healthStatus){}
    
    public override string ToString()
    {
        return $"Имя: {Name}\nТип: {Type}\nПодтип: {PodType}\nКол-во еды в сутки: {Food}\nСостояние здоровья: {HealthStatus}";
    }
}