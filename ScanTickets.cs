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
            var data = File.ReadLines(file.FullName).ToList();
            data.RemoveAt(0);
            foreach (var row in data)
            {
                var info = row.Split(";").ToList();
                Ticket ticket;
                try
                {
                    var lastName = info[0];
                    var name = info[1];
                    var patronymic = info[2];
                    var passportSeries = Convert.ToInt32(info[3]);
                    var passportNumber = Convert.ToInt32(info[4]);
                    var inn = Convert.ToInt64(info[5]);
                    var from = info[6];
                    var to = info[7];
                    var status = info[8];
                    var type = info[9];
                    var trainNumb = Convert.ToInt32(info[10]);
                    var carriageNumb = Convert.ToInt32(info[11]);
                    var seatNumb = Convert.ToInt32(info[12]);
                    var depTime = Convert.ToDateTime(info[13]).ToUniversalTime();
                    var arrTime = Convert.ToDateTime(info[14]).ToUniversalTime();
                    var price = Convert.ToInt32(info[15]);

                    ticket = new Ticket(lastName, name, patronymic, passportSeries, passportNumber, inn, from, to,
                        status, type, trainNumb, carriageNumb, seatNumb, depTime, arrTime, price);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Возникла ошибка при считывании данных из файла со строкой" +
                                      $"({data.IndexOf(row) + 1}): {ex.Message}");
                    continue;
                }

                bagOfTickets.Add(ticket);
            }
            
        }

        return true;
    }
}