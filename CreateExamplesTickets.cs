using System.Resources;

namespace TrainTickets;

public class CreateExamplesTickets
{
    static readonly Random _random = new Random();
    private bool Temp()
    {
        string path = Path.Combine($"{Environment.CurrentDirectory}", "tickets3.csv");
        string resInfo = string.Empty;
        for (int i = 0; i < 10; i++)
        {
            int price = 1000 * i + 1000;
            int seatNumber = _random.Next(1,100);
            int trainNumb = _random.Next(1, 100);
            int carriageNumb = _random.Next(1, 20);
            string from = "Владивосток";
            string to = "Москва";
            DateTime depTime = DateTime.Now;
            DateTime arrTime = DateTime.Now.AddHours(_random.Next(2, 24));
            string type = "Купе";
            string bookingStatus = "Забронирован";
            string name = "Петров";
            string lastName = "Василий";
            string patronymic = "Евгеньевич";
            string info = $"{lastName};{name};{patronymic};{from};{to};{bookingStatus};{type};{trainNumb};" +
                             $"{carriageNumb};{seatNumber};{depTime};{arrTime};{price}\r\n";
            resInfo += info;
        }
        File.WriteAllText(path,resInfo);
        Console.WriteLine(path);
        
        return true;
    }
    
    internal bool CreateTickets()
    {
        Temp();
        
        return true;
    }
}