# SegmentedDownloader
Unfamiliar to Video Segments?
A video segment (or chunk) is a fragment of video information that is a collection of video frames. Combined together, these segments make up a whole video. In streaming, video segments vary in size.

**This Library makes very small uses of the threading library but the download function is 100% wrapped into a thread for I/O bound operations. **More** improvments will be made very soon.**
**Note: Currenly there are no way to see if you already have a full stream**
# Example (What I use this to test the **Python API**)
```python
from SegmentedDownloader import SegmentDownloader
from Parser.SegmentParser import SegmentParser
from VideoCombiner.video_combiner import VideoCombiner, VideoUtils
from VideoCombiner.FileUtils import FileOperations

import threading

Segment_URL = ""
Video_Location = r"D:\Videos\Segments" # Change this to where you want your videos to be downloaded to

class Vars(SegmentDownloader, VideoUtils, FileOperations):
    def __init__(self, url, download_location):
        self.url = url
        self.download_location = download_location
        self.temp_video_download_location = Video_Location
        self.create_or_store_to_dir = self.create_directory()
        self.list_videos = FileOperations(Video_Location).list_files()
        self.video_size = FileOperations(Video_Location).get_file_size(self.list_videos)


    def test(self):
        print(self.temp_video_download_location)
        parse_url = SegmentParser.url_parser(self)
        print("Estimated amount of of segments are:", len(parse_url))
        self.create_or_store_to_dir
        t1 = threading.Thread(target=self.http_status_algorithm(parse_url))
        t2 = threading.Thread(target=self.video_size)
        t1.start()
        t2.start()

Vars(Segment_URL, Video_Location).test()
```

