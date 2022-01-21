# SegmentedDownloader
Unfamiliar to Video Segments?
A video segment (or chunk) is a fragment of video information that is a collection of video frames. Combined together, these segments make up a whole video. In streaming, video segments vary in size.

# Example (What I use to test the Python API **AGAIN PYTHON**
```python
from SegmentedDownloader import SegmentDownloader
from Parser.SegmentParser import SegmentParser
from VideoCombiner.video_combiner import VideoCombiner, VideoUtils
from VideoCombiner.FileUtils import FileOperations

Segment_URL = ""
Video_Location = r"C:\Users\dbroo\Videos\Segments" # change this

class Vars(SegmentDownloader, VideoUtils, FileOperations):
    def __init__(self, url, download_location):
        self.url = url
        self.download_location = download_location
        self.temp_video_download_location = Video_Location
        self.create_or_store_to_dir = self.create_directory()
        self.list_videos = FileOperations(Video_Location).list_files()
        self.video_size = FileOperations(Video_Location).get_file_size(self.list_videos)

    def test(self):
        parse_url = SegmentParser(Segment_URL).url_parser()
        self.create_or_store_to_dir
        print(self.http_status_algorithm(parse_url))
        print(self.video_size)



Vars(Segment_URL, Video_Location).test()
```
