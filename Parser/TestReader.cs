using System;


class SegmentedDownloaderParser
{
    public static int get_number_of_segments(string seg_url)
    {
        int len = seg_url.Length - 9;
        string remove_usless_data = seg_url.Remove(len);
        int number_of_segments = Convert.ToInt32(remove_usless_data.Split("seg-")[1]);
        return number_of_segments;
    }
}