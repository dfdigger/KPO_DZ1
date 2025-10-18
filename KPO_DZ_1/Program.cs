// Щербаков Денис БПИ249-2 КПО ДЗ1

using KPO_DZ_1_Library.Alive.Animals;
using KPO_DZ_1_Library.VetClinic;
using KPO_DZ_1_Library.Zoo;
using KPO_DZ_1_Library.Zoo.Inventory;
using Microsoft.Extensions.DependencyInjection;

namespace KPO_DZ_1;

class Program
{
    static void Main()
    {
        Console.Write("Введите название зоопарка: ");
        string zooName = Console.ReadLine() ?? "Безымянный зоопарк";

        Console.Write("Введите название ветеринарной клиники: ");
        string clinicName = Console.ReadLine() ?? "Безымянная клиника";
        
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection, zooName, clinicName);
        var serviceProvider = serviceCollection.BuildServiceProvider();

        var zoo = serviceProvider.GetRequiredService<IZoo>();

        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        bool exit = false;

        while (!exit)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в систему учета животных зоопарка");
                Console.WriteLine("Введите данные животного:");

                Console.Write("Имя: ");
                string name = Console.ReadLine() ?? "Безымянное";
                Console.Write("Подтип(Monkey/Rabbit/Tiger/Wolf): ");
                string? podtype = Console.ReadLine();
                int food = ReadInt("Количество потребляемой еды в сутки (кг): ");
                Console.Write("Состояние здоровья (Healthy/Bad): ");
                string? health = Console.ReadLine();

                IAnimal animal = podtype switch
                {
                    "Monkey" => new Monkey(name, food, health),
                    "Rabbit" => new Rabbit(name, food, health),
                    "Tiger" => new Tiger(name, food, health),
                    "Wolf" => new Wolf(name, food, health),
                    _ => throw new InvalidDataException()
                };

                bool added = zoo.TryAddNewAnimal(animal);
                Console.WriteLine();

                if (added)
                    Console.WriteLine($"Животное '{animal.Name}' успешно добавлено в зоопарк!");
                else
                    Console.WriteLine($"Животное '{animal.Name}' не прошло ветеринарную проверку");

                zoo.PrintAllAnimals();
            }
            catch (Exception)
            {
                Console.WriteLine("Неверный формат входных данных");
            }

            Console.WriteLine(
                    "\nНажмите ESC чтобы добавить еще одно животное, или любую другую клавишу для выхода...");
            var key = Console.ReadKey(intercept: true);

            if (key.Key != ConsoleKey.Escape)
                exit = true;
        }
    }
    
    static void ConfigureServices(ServiceCollection services, string zooName, string clinicName)
    {
        services.AddSingleton(new List<IAnimal>());
        services.AddSingleton<IInventory>(new Inventory());
        services.AddSingleton<IVetClinic>(new VetClinic(clinicName));
        services.AddSingleton<IZoo>(provider =>
        {
            var animals = provider.GetRequiredService<List<IAnimal>>();
            var clinic = provider.GetRequiredService<IVetClinic>();
            var inventory = provider.GetRequiredService<IInventory>();
            return new Zoo(zooName, animals, clinic, inventory);
        });
    }
    
    static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int value))
                return value;
            Console.WriteLine("Некорректный ввод. Попробуйте снова\n");
        }
    }
}