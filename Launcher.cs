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
    
    internal static int Main(string[] argc)
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
}