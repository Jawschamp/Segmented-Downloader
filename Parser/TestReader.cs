using System;
using System.Net.Http;
using System.Threading.Tasks;

class SegmentedDownloaderParser
{
    public static async Task<string> segmented_HTTP_request_parse(string seg_url)
    {
        var client = new HttpClient();
        var result = await client.GetStringAsync(seg_url);

        Console.WriteLine(result);
        return seg_url;
    }

    public static async Task<int> get_number_of_segments()
    {
        // Not tested
        string segs = segmented_HTTP_request_parse();
        int len = segs.Length - 9;
        string remove_usless_data = segs.Remove(len);
        int number_of_segments = Convert.ToInt32(remove_usless_data.Split("seg-")[1]);
        return number_of_segments;
    }
}
