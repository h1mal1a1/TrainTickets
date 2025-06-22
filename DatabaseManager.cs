using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore;

namespace TrainTickets;

public class DatabaseManager
{
    private readonly TrainTicketsDbContext.AppDbContext _dbContext = new();
    private readonly ConcurrentBag<TrainTicketsDbContext.Registration> _tickets;
    internal DatabaseManager(ConcurrentBag<TrainTicketsDbContext.Registration> tickets) => _tickets = tickets;

    internal bool TryOpenConnection()
    {
        try
        {
            _dbContext.Database.OpenConnection();

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Не получилось открыть соединение с БД, по причине: {ex.Message}");
            return false;
        }

        Console.WriteLine($"Соединение с БД открыто. Статус: {_dbContext.Database.CanConnect()}");
        return true;
    }

    private void AddNewBookingStatuses()
    {
        var uniqValues = _tickets
            .Select(ticket => ticket.BookingStatuse)
            .DistinctBy(type => type.BookingName);
        var existingValues = _dbContext.BookingStatuses
            .Select(t => t.BookingName);
        var newValues = uniqValues
            .Where(cl => !existingValues.Contains(cl.BookingName)).ToList();
        if (newValues.Count != 0)
            _dbContext.BookingStatuses.AddRange(newValues);
    }

    private void UpdateBookingStatusesInTickets()
    {
        foreach (var ticket in _tickets)
        {
            var status = ticket.BookingStatuse;
            var existingStatus = _dbContext.BookingStatuses
                .FirstOrDefault(s => s.BookingName == status.BookingName);
            if (existingStatus != null)
                ticket.BookingStatuse = existingStatus;
            else
                Console.WriteLine($"В бд нету значения status:{status.BookingName}");
        }


    }

    private void AddNewLastNames()
    {
        var uniqValues = _tickets
            .Select(ticket => ticket.User.LastName)
            .DistinctBy(type => type.LastName);
        var existingValues = _dbContext.LastNames
            .Select(t => t.LastName);
        var newValues = uniqValues
            .Where(cl => !existingValues.Contains(cl.LastName)).ToList();
        if (newValues.Count != 0)
            _dbContext.LastNames.AddRange(newValues);
    }

    private void UpdateLastNamesInTickets()
    {
        foreach (var ticket in _tickets)
        {
            var lastName = ticket.User.LastName;
            var existingLastName = _dbContext.LastNames
                .FirstOrDefault(s => s.LastName == lastName.LastName);
            if (existingLastName != null)
            {
                ticket.User.LastName = existingLastName;
                ticket.User.IdLastName = existingLastName.IdLastName;
            }
            else
                Console.WriteLine($"В бд нету значения lastName:{lastName.LastName}");
        }
    }

    private void AddNewNames()
    {
        var uniqValues = _tickets
            .Select(ticket => ticket.User.Name)
            .DistinctBy(type => type.Name);
        var existingValues = _dbContext.Names
            .Select(t => t.Name);
        var newValues = uniqValues
            .Where(cl => !existingValues.Contains(cl.Name)).ToList();
        if (newValues.Count != 0)
            _dbContext.Names.AddRange(newValues);
    }

    private void UpdateNamesInTickets()
    {
        foreach (var ticket in _tickets)
        {
            var name = ticket.User.Name;
            var existingName = _dbContext.Names
                .FirstOrDefault(s => s.Name == name.Name);
            if (existingName != null)
            {
                ticket.User.Name = existingName;
                ticket.User.IdName = existingName.IdName;
            }
            else
                Console.WriteLine($"В бд нету значения Name:{name.Name}");
        }
    }

    private void AddNewPatronymics()
    {
        var uniqValues = _tickets
            .Select(ticket => ticket.User.Patronymic)
            .DistinctBy(type => type.Name);
        var existingValues = _dbContext.Patronymics
            .Select(t => t.Name);
        var newValues = uniqValues
            .Where(cl => !existingValues.Contains(cl.Name)).ToList();
        if (newValues.Count != 0)
            _dbContext.Patronymics.AddRange(newValues);
    }

    private void UpdatePatronymicsInTickets()
    {
        foreach (var ticket in _tickets)
        {
            var patronymic = ticket.User.Patronymic;
            var existingPatronymic = _dbContext.Patronymics
                .FirstOrDefault(s => s.Name == patronymic.Name);
            if (existingPatronymic != null)
            {
                ticket.User.Patronymic = existingPatronymic;
                ticket.User.IdPatronymic = existingPatronymic.IdPatronymic;
            }
            else
                Console.WriteLine($"В бд нету значения Patronymic:{patronymic.Name}");
        }
    }

    private void AddNewClassTypes()
    {
        var uniqValues = _tickets
            .Select(ticket => ticket.ClassType)
            .DistinctBy(type => type.TypeName);
        var existingValues = _dbContext.ClassTypes
            .Select(t => t.TypeName);
        var newValues = uniqValues
            .Where(cl => !existingValues.Contains(cl.TypeName)).ToList();
        if (newValues.Count != 0)
            _dbContext.ClassTypes.AddRange(newValues);
    }

    private void UpdateClassTypesInTickets()
    {
        foreach (var ticket in _tickets)
        {
            var classType = ticket.ClassType;
            var existingClassType = _dbContext.ClassTypes
                .FirstOrDefault(s => s.TypeName == classType.TypeName);
            if (existingClassType != null)
                ticket.ClassType = existingClassType;
            else
                Console.WriteLine($"В бд нету значения ClassType:{classType.TypeName}");
        }
    }

    private void AddNewArrivalStations()
    {
        var uniqValues = _tickets
            .Select(ticket => ticket.ArrivalStation)
            .DistinctBy(type => type.StationName);
        var existingValues = _dbContext.Stations
            .Select(t => t.StationName);
        var newValues = uniqValues
            .Where(cl => !existingValues.Contains(cl.StationName)).ToList();
        if (newValues.Count != 0)
            _dbContext.Stations.AddRange(newValues);
    }

    private void UpdateArrivalStations()
    {
        foreach (var ticket in _tickets)
        {
            var arrivalStation = ticket.ArrivalStation;
            var existingStation = _dbContext.Stations
                .FirstOrDefault(s => s.StationName == arrivalStation.StationName);
            if (existingStation != null)
                ticket.ArrivalStation = existingStation;
            else
                Console.WriteLine($"В бд нету значения ArrivalStation:{arrivalStation.StationName}");
        }
    }

    private void AddNewDepartureStations()
    {
        var uniqValues = _tickets
            .Select(ticket => ticket.DepartureStation)
            .DistinctBy(type => type.StationName);
        var existingValues = _dbContext.Stations
            .Select(t => t.StationName);
        var newValues = uniqValues
            .Where(cl => !existingValues.Contains(cl.StationName)).ToList();
        if (newValues.Count != 0)
            _dbContext.Stations.AddRange(newValues);
    }

    private void UpdateDepartureStations()
    {
        foreach (var ticket in _tickets)
        {
            var departureStation = ticket.DepartureStation;
            var existingStation = _dbContext.Stations
                .FirstOrDefault(s => s.StationName == departureStation.StationName);
            if (existingStation != null)
                ticket.DepartureStation = existingStation;
            else
                Console.WriteLine($"В бд нету значения DepartureStation:{departureStation.StationName}");
        }
    }

    private void AddNewStations()
    {
        var allStations = _tickets
            .Select(t => t.DepartureStation)
            .Concat(_tickets.Select(t => t.ArrivalStation))
            .DistinctBy(s => s.StationName)
            .ToList();
        foreach (var station in allStations.Where(station
                     => !_dbContext.Stations.Any(s => s.StationName == station.StationName)))
            _dbContext.Stations.Add(station);
    }

    private void AddNewUsers()
    {
        var uniqValues = _tickets
            .Select(ticket => ticket.User)
            .DistinctBy(user => new {user.PassportSeries, user.PassportNumber, user.INN});
        var existingValues = _dbContext.Users
            .Select(user => new { user.PassportSeries, user.PassportNumber, user.INN })
            .AsEnumerable()// Переключаемся на клиентскую оценку
            .Select(x=>(x.PassportSeries,x.PassportNumber,x.INN))// переводим в ValueTuple
            .ToHashSet();
        List<TrainTicketsDbContext.Users> newValues;
        try
        {
            newValues = uniqValues
                .Where(cl => !existingValues.Contains((cl.PassportSeries, cl.PassportNumber, cl.INN))).ToList();

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Возникла ошибка при получении не содержащихся в БД пользователей: {ex.Message}");
            return;
        }
        if (newValues.Count != 0)
            _dbContext.Users.AddRange(newValues);
    }

private void AddNewUsersParameters()
    {
        AddNewPatronymics();
        AddNewNames();
        AddNewLastNames();
    }

    private void UpdateUsers()
    {
        foreach (var ticket in _tickets)
        {
            var user = ticket.User;
            var existingUser = _dbContext.Users
                .FirstOrDefault(existUser => existUser.PassportNumber == user.PassportNumber &&
                                             existUser.PassportSeries == user.PassportSeries &&
                                             existUser.INN == user.INN);
            if (existingUser != null)
                ticket.User = existingUser;
            else
                Console.WriteLine($"В бд нету значения пользователя с данными(" +
                                  $"{user.PassportSeries}{user.PassportNumber},{user.INN})");
        }
    }
    private void UpdateUsersParameters()
    {
        UpdatePatronymicsInTickets();
        UpdateNamesInTickets();
        UpdateLastNamesInTickets();
    }

    private void AddNewParameters()
    {
        AddNewClassTypes();
        AddNewBookingStatuses();
        AddNewStations();
        AddNewUsersParameters();
        AddNewUsers();
        _dbContext.SaveChanges();
    }
    private void UpdateParameters()
    {
        UpdateClassTypesInTickets();
        UpdateBookingStatusesInTickets();
        UpdateDepartureStations();
        UpdateArrivalStations();
        UpdateUsersParameters();
        UpdateUsers();
    }
    
    internal bool InsertNewValues()
    {
        AddNewParameters();
        UpdateParameters();
        
        try
        {
            _dbContext.AddRange(_tickets);
            _dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"При добавлении данных произошла ошибка: {ex.Message}");
            if(ex.InnerException != null)
                Console.WriteLine($"Inner ex: {ex.InnerException.Message}");
        }
        
        
        return true;
    }
}