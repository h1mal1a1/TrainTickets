using System.Resources;
using System.Text;

namespace TrainTickets;

internal class PassengerTicket(
    string name,
    string lastname,
    string patronymic,
    string from,
    string to,
    string type,
    string bookingStatus,
    int passportSeries,
    int passportNumber,
    long inn,
    int trainNumber,
    int carriageNumb,
    int seatNumber,
    DateTime depTime,
    DateTime arrTime,
    int price)
{
    internal string ResultInfoAboutUser() => $"{lastname};{name};{patronymic};{passportSeries};{passportNumber};" +
                                             $"{inn};{from};{to};{bookingStatus};{type};{trainNumber};" +
                                             $"{carriageNumb};{seatNumber};{depTime};{arrTime};{price}\r\n";
}

public class CreateExamplesTickets
{
    private static readonly Random rnd = new();

    private readonly List<string> _stations =
    [
        "Москва", "Санкт-Петербург", "Новосибирск", "Екатеринбург", "Казань", "Нижний Новгород",
        "Челябинск", "Самара", "Омск", "Уфа"
    ];

    private readonly List<string> _types = ["Плацкарт", "Купе", "СВ", "Общий", "Вагон-ресторан"];

    private readonly List<string> _statuses =
        ["Куплен", "Резерв", "Отменен", "Возвращен", "Заблокирован", "Обменен", "Выкуплен"];

    private readonly List<string> _russianNames =
    [
        "Александр", "Мария", "Дмитрий", "Екатерина", "Иван", "Ольга", "Сергей", "Татьяна",
        "Андрей", "Наталья", "Алексей", "Светлана", "Владимир", "Юлия", "Николай"
    ];

    private readonly List<string> _russianSurnames =
    [

        "Иванов", "Петров", "Смирнов", "Кузнецов", "Попов", "Соколов", "Михайлов",
        "Новиков", "Фёдоров", "Морозов", "Васильев", "Романов", "Тихонов", "Григорьев", "Лебедев"
    ];

    private readonly List<string> _russianPatronymics =
    [
        "Александрович", "Дмитриевич", "Иванович", "Сергеевич", "Владимирович", "Петрович", "Андреевич",
        "Михайлович", "Николаевич", "Олегович", "Юрьевич", "Борисович", "Геннадиевич", "Васильевич", "Романович"
    ];

    // private bool FirstPassanger(PassangerTicket passangerTicket)
    // {
    //     var path = Path.Combine($"{Environment.CurrentDirectory}", "tickets3.csv");
    //     var resInfo = string.Empty;
    //     for (int i = 0; i < 10; i++)
    //     {
    //         int price = 1000 * i + 1000;
    //         int seatNumber = Random.Next(1,100);
    //         int trainNumb = Random.Next(1, 100);
    //         int carriageNumb = Random.Next(1, 20);
    //         //string from = "Владивосток";
    //         //string to = "Москва";
    //         DateTime depTime = DateTime.Now;
    //         DateTime arrTime = DateTime.Now.AddHours(Random.Next(2, 24));
    //         //string type = "Купе";
    //         //string bookingStatus = "Забронирован";
    //         //string name = "Петров";
    //         //string lastName = "Василий";
    //         //string patronymic = "Евгеньевич";
    //         //int passportSeries = 4618;
    //         //int passportNumber = 951332;
    //         //long inn = 123456789012;
    //         resInfo += passangerTicket.ResultInfoAboutUser();
    //     }
    //     File.WriteAllText(path,resInfo);
    //     Console.WriteLine(path);
    //     
    //     return true;
    // }
    private void CreateLstTickets(int countTickets, out List<PassengerTicket> tickets)
    {
        tickets = [];
        for (var i = 0; i < countTickets; i++)
        {
            var name = _russianNames[rnd.Next(_russianNames.Count)];
            var lastName = _russianSurnames[rnd.Next(_russianSurnames.Count)];
            var patronymic = _russianPatronymics[rnd.Next(_russianPatronymics.Count)];
            var from = _stations[rnd.Next(_stations.Count)];
            string to;
            do
            {
                to = _stations[rnd.Next(_stations.Count)];
            } while (to == from); // чтобы пункт прибытия не совпадал с отправлением

            var type = _types[rnd.Next(_types.Count)];
            var status = _statuses[rnd.Next(_statuses.Count)];

            var passportSeries = rnd.Next(1000, 9999);
            var passportNumber = rnd.Next(100000, 999999);
            var inn = long.Parse(Enumerable.Repeat(0, 12)
                .Select(_ => rnd.Next(0, 10).ToString())
                .Aggregate((a, b) => a + b));

            var trainNumber = rnd.Next(1, 1000);
            var carriageNumb = rnd.Next(1, 20);
            var seatNumber = rnd.Next(1, 54);

            var now = DateTime.Now;
            var depTime = now.AddDays(rnd.Next(1, 30)).AddHours(rnd.Next(0, 24)).AddMinutes(rnd.Next(0, 60));
            var arrTime = depTime.AddHours(rnd.Next(1, 24));
            var price = rnd.Next(500, 10000);

            var ticket = new PassengerTicket(
                name, lastName, patronymic, from, to, type, status,
                passportSeries, passportNumber, inn,
                trainNumber, carriageNumb, seatNumber,
                depTime, arrTime, price
            );

            tickets.Add(ticket);
        }
    }

    private static void CreateCsvFile(List<PassengerTicket> tickets)
    {
        var pathToFile = Path.Combine(Environment.CurrentDirectory, $"{DateTime.Now:yyyyMMdd_HHmm}.csv");

        using (var writer = new StreamWriter(pathToFile, false, Encoding.UTF8))
        {
            writer.WriteLine("Фамилия;Имя;Отчество;Серия_паспорта;Номер_паспорта;" +
                             "ИНН;Откуда;Куда;Статус;Тип;Номер_поезда;" +
                             "Вагон;Место;Время_отправления;Время_прибытия;Цена");
        }

        using (var writer = new StreamWriter(pathToFile, true, Encoding.UTF8))
        {
            foreach (var ticket in tickets)
                writer.Write(ticket.ResultInfoAboutUser());
        }
    }

    internal bool CreateTickets()
    {
        CreateLstTickets(100, out var tickets);
        CreateCsvFile(tickets);

        return true;
    }
}