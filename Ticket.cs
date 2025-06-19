using Npgsql.Replication.PgOutput;

namespace TrainTickets;

public class Ticket
{
    private readonly int _price;
    private readonly int _seatNumber;
    private readonly int _trainNumb;
    private readonly int _carriageNumb;
    private readonly string _from;
    private readonly string _to;
    private readonly DateTime _depTime;
    private readonly DateTime _arrTime;
    private readonly DateTime _dateReg;
    private readonly string _type;
    private readonly string _bookingStatus;
    private readonly string _name;
    private readonly string _lastName;
    private readonly string _patronymic;
    

    internal Ticket(int price, int seatNumber, int trainNumber, int carriageNumb, string from, string to,
        DateTime depTime, DateTime arrTime, string type, string bookingStatus, string name, string lastName,
        string patronymic)
    {
        _price = price;
        _seatNumber = seatNumber;
        _trainNumb = trainNumber;
        _carriageNumb = carriageNumb;
        _from = from;
        _to = to;
        _depTime = depTime;
        _arrTime = arrTime;
        _type = type;
        _bookingStatus = bookingStatus;
        _name = name;
        _lastName = lastName;
        _patronymic = patronymic;
        _dateReg = DateTime.UtcNow;
    }

    internal void ConvertToRegistrationTicket(out TrainTicketsDbContext.Registration registrationTicket)
    {
        try
        {
            registrationTicket = new TrainTicketsDbContext.Registration
            {
                TrainNumber = _trainNumb,
                DepartureTime = _depTime,
                ArrivalTime = _arrTime,
                DateRegistration = _dateReg,
                CarriageNumber = _carriageNumb,
                SeatNumber = _seatNumber,
                Price = _price,
                ClassType = new TrainTicketsDbContext.ClassTypes { TypeName = _type },
                User = new TrainTicketsDbContext.Users
                {
                    Name = new TrainTicketsDbContext.Names { Name = _name },
                    LastName = new TrainTicketsDbContext.LastNames { LastName = _lastName },
                    Patronymic = new TrainTicketsDbContext.Patronymics { Name = _patronymic },
                    DateRegistration = _dateReg
                },
                BookingStatuse = new TrainTicketsDbContext.BookingStatuses { BookingName = _bookingStatus },
                DepartureStation = new TrainTicketsDbContext.Stations { StationName = _from },
                ArrivalStation = new TrainTicketsDbContext.Stations { StationName = _to }
            };
        }
        catch (Exception ex)
        {
            throw new Exception($"{ex.Message}");
        }
    }
}