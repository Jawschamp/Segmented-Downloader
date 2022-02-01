using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SegmentedDownloader
{
    public class SegmentParser
    {
        public async Task<string> SegmentURIRequester(string segment_url)
        {
            var Client = new HttpClient();
            var request = await Client.GetAsync(segment_url);
            var response_status_code = request.StatusCode;
            return Convert.ToString(response_status_code);
        }

        public async Task<int> SegmentNumParser(string segment_url)
        {
            int len = segment_url.Length - 9;
            string remove_useless_data = segment_url.Remove(len);
            int num_of_segs = Convert.ToInt32(remove_useless_data.Split("seg-")[1]);
            //Console.WriteLine(num_of_segs);
            return num_of_segs;
        }

        public async Task<string> SegmentURIBuilder(string segment_url)
        {
            int len = segment_url.Length - 10;
            string remove_useless_data = segment_url.Remove(len);
            return remove_useless_data;
        }

        // DONE //

        public async Task<string> SegmentURIAlgorithm(string segment_url)
        {
            // feed SegmentURIRequester the segment_url that needs to be parsed
            var test = await SegmentURIRequester(await SegmentURIBuilder(segment_url: segment_url));
            // Use SegmentNumParser() as the add/minus caculator
            //if (SegmentURIRequester(segment_url: segment_url) == "OK")

            // The first step is to request it 100 times per return of HTTP: 200 
            // Note: evetually have a time algorithm that is able to reasoabbly 
            //request the closest (highest segment count without getting a HTTP: 404)

            int add = 100;
            int minus = 10;
            var seg_count = await SegmentNumParser(segment_url: segment_url);
            //for (segment_url < add)
            {

            }

            return null;
        }

    }
}
