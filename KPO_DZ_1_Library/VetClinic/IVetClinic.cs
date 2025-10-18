namespace KPO_DZ_1_Library.VetClinic;
using Alive.Animals;

public interface IVetClinic
{
    // Проверка состояния здоровья животного
    public bool CheckAnimal(IAnimal animal);
    // Получение информации о животном
    public string InfoAboutAnimal(IAnimal animal);
}