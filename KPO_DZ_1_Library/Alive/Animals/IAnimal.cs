namespace KPO_DZ_1_Library.Alive.Animals;

public interface IAnimal : IAlive
{
    public string Name { get; set; }
    public string ToString();
}