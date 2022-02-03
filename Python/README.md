# Welcome to the Python Interface for SegmentedDownloader

# To begin downloading a stream:
You'll need access to a Segment Stream (otherwise known as stream)
once you have that import a couple classes e.g (SegmentParser, SegmentDownloader)
The code underneath will download all available segments from only one url
```python
from SegmentedDownloader.SegmentedDownloader import SegmentDownloader
from SegmentedDownloader.Parser.SegmentParser import SegmentParser
parse_url = SegmentParser.url_parser(url) # Url being one of the urls in the segment stream
SegmentedDownloader.http_status_algorithm(parse_url)
```

# Concat
SegmentedDownloader has a few concation functions via a FFMPEG wrapper
```python
from SegmentedDownloader.VideoCombiner.FileUtils import FileOperations
from SegmentedDownloader.VideoCombiner.video_combiner import VideoCombiner
VideoCombiner(DIRECTORY).concate_videos_txt_file() # DIRECTORY being where raw segments will be saved before being concatenated into a whole video
VideoCombiner(DIRECTORY).concat_videos(DIRECTORY + "/Movie")
```
The ``concate_videos_txt_file()`` function calls a sort video function so that FFMPEG can easily concat all videos in order
here's a sample of that format being done automatically:
```
file '1.mp4'
file '6.mp4'
file '13.mp4'
file '16.mp4'
file '17.mp4'
file '20.mp4'
file '21.mp4'
file '22.mp4'
file '25.mp4'
file '28.mp4'
file '31.mp4'
file '32.mp4'
```