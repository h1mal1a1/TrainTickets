using System.Collections.Concurrent;
using Amazon.S3;
using Amazon.S3.Model;

namespace TrainTickets;

public class S3Manager
{
    private readonly AmazonS3Client _client;

    public S3Manager(string login, string password, string urlS3)
    {
        try
        {
            var config = new AmazonS3Config()
            {
                ServiceURL  = urlS3
            };
            _client = new AmazonS3Client(login, password, config);
        }
        catch (Exception ex)
        {
            throw new Exception($"Возникла ошибка при создании client S3: {ex.Message}");
        }
    }
    private async Task<ConcurrentBag<string>?> GetFilenamesFromBucket(string bucketName)
    {
        ConcurrentBag<string> filenamesInBucket;
        ListObjectsRequest req = new() { BucketName = bucketName };
        ListObjectsResponse resp;
        try
        {
            resp = await _client.ListObjectsAsync(req);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Возникла ошибка при получении списка объектов в бакете: {ex.Message}");
            return null;
        }
        
        try
        {
            Console.WriteLine(resp.S3Objects.Count);
            filenamesInBucket = new ConcurrentBag<string>(resp.S3Objects.Select(o => o.Key));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Вознилка ошибка при создании ConcurentBag из списка объектов: {ex.Message}");
            return null;
        }

        return filenamesInBucket;
    }

    private async Task<List<string>?> GetNameBuckets()
    {
        ListBucketsResponse resp;
        try { resp = await _client.ListBucketsAsync(); }
        catch (Exception ex)
        {
            Console.WriteLine($"Возникла ошибка при получении имен бакетов: {ex.Message}");
            return null;
        }

        List<string> listOfNameBuckets;
        try
        {
            listOfNameBuckets = [..resp.Buckets.Select(b => b.BucketName)];
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Возникла ошибка при создании списка с именами бакетов: {ex.Message}");
            return null;
        }
        
        return listOfNameBuckets;
    }
    internal async Task<int> Tests()
    {
        var lstNamesBuckets = await GetNameBuckets();
        if (lstNamesBuckets == null) return -1;
        foreach (var name in lstNamesBuckets)
        {
            var bagOfFilenamesFromBucket = await GetFilenamesFromBucket(name);
            if(bagOfFilenamesFromBucket == null) continue;
            Console.WriteLine($"Bucket name: {name}\r\nFiles in bucket:{string.Join(',', bagOfFilenamesFromBucket)}");
        }

        return 1;
    }
}