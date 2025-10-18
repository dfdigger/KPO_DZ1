namespace KPO_DZ_1_Library.Alive;

public interface IAlive
{
    public int Food { get; set; }
    public string HealthStatus { get; set; }
    
    // Информация о количестве еды, потребляемой в сутки
    public int HowMuchFood()
    {
        return Food;
    }
}