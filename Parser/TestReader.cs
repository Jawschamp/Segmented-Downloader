using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SegmentedDownloader
{
    public class SegmentParser
    {
        public int SegCount { get; private set; }


        public async Task<int> SegmentParse()
        {
            SegCount = 0;
            return SegCount;
        }


        public async Task SegmentURISegAlg(string segment_url)
        {
            var Client = new HttpClient();
            var response = await Client.GetAsync(segment_url);
            if (response.IsSuccessStatusCode)
            {
                while (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(await SegmentSegNumParse(segment_url: segment_url));
                }
            }
            //return response;
        }


        public async Task<int> SegmentSegNumParse(string segment_url)
        {
            int len = segment_url.Length - 9;
            string remove_useless_data = segment_url.Remove(len);
            int num_of_segs = Convert.ToInt32(remove_useless_data.Split("seg-")[1]);
            Console.WriteLine(num_of_segs);
            return num_of_segs;
        }

        public async Task<> 
    }
}
