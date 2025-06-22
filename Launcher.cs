using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore;

namespace TrainTickets;

public class Launcher
{
    private static void ConvertFromTicketToRegistration(ConcurrentBag<Ticket> tickets, 
        out ConcurrentBag<TrainTicketsDbContext.Registration> registrationTickets)
    {
        ConcurrentBag<TrainTicketsDbContext.Registration> bagOfRegTickets = [];
        tickets.AsParallel().WithDegreeOfParallelism(Environment.ProcessorCount).ForAll(ticket =>
        {
            TrainTicketsDbContext.Registration regTicket;
            try
            {
                ticket.ConvertToRegistrationTicket(out regTicket);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникла ошибка при конвертации из Ticket to RegistrationTicket: {ex.Message}");
                return;
            }

            bagOfRegTickets.Add(regTicket);
        });
        registrationTickets = bagOfRegTickets;
    }

    private static void CreateFileWithTickets()
    {
        CreateExamplesTickets ct = new();
        ct.CreateTickets();
    }

    private static int ReadNewTicketsAndInsertToDatabase()
    {
        ScanTickets st = new();
        var intermediateStage = st.ScanTicket(out var tickets);
        if (!intermediateStage) return -1;
        
        ConvertFromTicketToRegistration(tickets, out var regTickets);
        if (!intermediateStage) return -1;
        
        DatabaseManager dbManager = new(regTickets);
        intermediateStage = dbManager.TryOpenConnection();
        if (!intermediateStage) return -1;
        intermediateStage = dbManager.InsertNewValues();
        if (!intermediateStage) return -1;
        return 1;
    }

    private static int SomeTestWithS3()
    {
        S3Manager s3 = new("minioadmin", "minioadmin", "http://192.168.1.102:9000");
        s3.Tests().Wait();
        return 1;
    }
    
    internal static int Main(string[] argc)
    {
        const int variants = 2;
        switch (variants)
        {
            case 1:
                CreateFileWithTickets();
                return 1;
            case 2:
                return ReadNewTicketsAndInsertToDatabase(); 
                break;
            case 3:
                return SomeTestWithS3();
                break;
            default:
                break;
        }
        return 1;
    }
}