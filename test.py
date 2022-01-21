from SegmentedDownloader import SegmentDownloader
from Parser.SegmentParser import SegmentParser
from VideoCombiner.video_combiner import VideoCombiner, VideoUtils
from Providers import ProvidersEnum

import requests

Segment_URL = "https://e-4.foximage.net/_v5/24e672db5b1786b715fcf565786b781ab87350fc07173671ca5f5f6f4ab538986770f43f7a3c64483563b9da548a385276686ccd66140d379a045b5e9ec30c5cb0861d8e4a438b3c935308fefaf2dbe1cb7556d13484c327e5471c5260a6cd66e9c05d20f3196422ed61b39b03cf9f78a72acce3e65a78653ec0322cf4f18d01/720/seg-1-v1-a1.ts"
Video_Location = r"C:\Users\dbroo\Videos\Segments"

class Vars(SegmentDownloader, VideoUtils):
    def __init__(self, url, download_location):
        self.url = url
        self.download_location = download_location

    def test(self):
        parse_url = SegmentParser(Segment_URL).url_parser()
        print(self.http_status_algorithm(parse_url))


Vars(Segment_URL, Video_Location).test()