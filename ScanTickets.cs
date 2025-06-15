using System.Collections.Concurrent;

namespace TrainTickets;

public class ScanTickets
{
    internal bool ScanTicket(out ConcurrentBag<Ticket> bagOfTickets)
    {
        bagOfTickets = [];
        FileInfo[] files;
        try { files = new DirectoryInfo(Environment.CurrentDirectory).GetFiles("*.csv"); }
        catch (Exception ex)
        {
            Console.WriteLine($"Возникла ошибка при получении списка csv файлов в директории: {ex.Message}");
            return false;
        }
        foreach (var file in files)
        {
            var data = File.ReadLines(file.FullName);
            foreach (var row in data)
            {
                var info = row.Split(";");
                var ticket = new Ticket(Convert.ToInt32(info[12]),Convert.ToInt32(info[9]), 
                    Convert.ToInt32(info[7]), Convert.ToInt32(info[8]), info[3], info[4], 
                    Convert.ToDateTime(info[10]).ToUniversalTime(), Convert.ToDateTime(info[11]).ToUniversalTime(), info[6],info[5], 
                    info[1], info[0], info[2]);
                bagOfTickets.Add(ticket);
            }
            
        }

        return true;
    }
}