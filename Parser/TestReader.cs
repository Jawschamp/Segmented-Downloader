using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SegmentedDownloader
{
    public class SegmentParser
    {
        public int SegCount { get; private set; }



        public async Task SegmentURIRequester(string segment_url)
        {
            var Client = new HttpClient();
            var request = await Client.GetAsync(segment_url);
            var response_status_code = request.StatusCode;
            await SegmentSegNumParse(segment_url: segment_url);
            //return response;
        }


        public async Task<int> SegmentSegNumParse(string segment_url)
        {
            int len = segment_url.Length - 9;
            string remove_useless_data = segment_url.Remove(len);
            int num_of_segs = Convert.ToInt32(remove_useless_data.Split("seg-")[1]);
            Console.WriteLine(remove_useless_data);
            Console.WriteLine(num_of_segs);
            return num_of_segs;
        }


        public async Task<string> SegmentURIAlgorithm(string segment_url)
        {
            // feed SegmentURIRequester the segment_url that needs to be parsed
            // The first step is to request it 100 times per return of HTTP: 200 
            // Note: evetually have a time algorithm that is able to reasoabbly 
            // request the closest (highest segment count without getting a HTTP: 404)
            await SegmentURIRequester(segment_url: segment_url);
            return null;
        }

    }
}
