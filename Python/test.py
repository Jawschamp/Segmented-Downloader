from SegmentedDownloader import SegmentDownloader
from Parser.SegmentParser import SegmentParser
from VideoCombiner.FileUtils import FileOperations
from VideoCombiner.video_combiner import VideoCombiner
import threading

Segment_URL = "https://b-g-eu-14.betterstream.co:2222/v2-hls-playback/c7701f032b64a79e0fa16d66b52dd98726efd0d9693ab1909fc47c19d7b787cc0a379cd4aa5d4601287bb8b53e36a06007ddaae0b3e5a5efed870d6cbbb1e36c7051e827c582b4cd5be59b2efbd44f59dd8358260edb50dbf04b468411e1ad1d9af654c7a18e115ce91e2cf0c6eea212357e9322a580189671c146d49fa4cf5471a773ac43596f8fd76ed03fa2d0a562e91de11cde6b24bb652bde6ee9666500/720/seg-13-v1-a1.ts"
Video_Location = r"D:\Videos\Segments"


class Vars(SegmentDownloader, FileOperations):
    def __init__(self, url):
        self.url = url
        self.temp_video_download_location = Video_Location
        #self.test = VideoCombiner(self.download_location).test()

    def concation(self):
        VideoCombiner(self.temp_video_download_location).concate_videos_txt_file()
        VideoCombiner(self.temp_video_download_location).concat_videos(self.temp_video_download_location + "/Movie")

    def download(self):
        parse_url = SegmentParser.url_parser(self)
        self.http_status_algorithm(parse_url)


threading.Thread(target=Vars(Segment_URL).download()).start()
threading.Thread(target=Vars(Segment_URL).concation()).start()