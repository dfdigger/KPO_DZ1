namespace KPO_DZ_1_Library.Alive;

public class Alive : IAlive
{
    public int Food { get; set; }
    public string HealthStatus { get; set; }

    public Alive(int food, string healthStatus)
    {
        Food = food;
        HealthStatus = healthStatus;
    }
}