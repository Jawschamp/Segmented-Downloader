# SegmentedDownloader
Unfamiliar to Video Segments?
A video segment (or chunk) is a fragment of video information that is a collection of video frames. Combined together, these segments make up a whole video. In streaming, video segments vary in size.

Currently this Library does not completly work as it is having both of it's API's rewritten. (C# & Python)
**This Library makes very small use of the threading library but the download function is 100% wrapped into a thread for I/O bound operations. 
**More** improvments will be made very soon.**
**Note:** Currently there is no way to see if you already have a full stream**
# Example (What I use this to test the **Python API**)

Massive thanks to [SirSloth](https://github.com/SlothsAreLazyTho/) for writting the C# version into something useful.
And Thanks to [Muh2k](https://github.com/muh2k) For Englishifying the project.


```python
from SegmentedDownloader import SegmentDownloader
from Parser.SegmentParser import SegmentParser
from VideoCombiner.FileUtils import FileOperations


import threading

Segment_URL = ""
Video_Location = r"D:\Videos\Segments" # Change this to where you want your videos to be downloaded to
class Vars(SegmentDownloader, FileOperations):
    def __init__(self, download_location):
        self.download_location = download_location
        self.temp_video_download_location = Video_Location
        self.list_videos = FileOperations(Video_Location).list_files()
        self.video_size = FileOperations(Video_Location).get_file_size(self.list_videos)

    def test(self):
        print(self.temp_video_download_location)
        parse_url = SegmentParser.url_parser(Segment_URL)
        self.create_directory()
        threading.Thread(target=self.http_status_algorithm, args=(parse_url,)).start()
        threading.Thread(target=self.video_size).start()

Vars(Video_Location).test(
```

