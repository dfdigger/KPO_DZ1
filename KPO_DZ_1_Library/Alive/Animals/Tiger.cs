namespace KPO_DZ_1_Library.Alive.Animals;

public class Tiger : Predator
{
    public string PodType { get; set; } = "Tiger";
    
    public Tiger(string name, int food, string healthStatus) : base(name, food, healthStatus){}
    
    public override string ToString()
    {
        return $"Имя: {Name}\nТип: {Type}\nПодтип: {PodType}\nКол-во еды в сутки: {Food}\nСостояние здоровья: {HealthStatus}";
    }
}