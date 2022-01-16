from SegmentedDownloader import SegmentDownloader
from Parser.SegmentParser import SegmentParser
Segment_URL = ""

def test():
    highest_segment = SegmentDownloader.url_splitter(Segment_URL)
    # The highest_segment*() var returns the max amount of video segments that are available
    #print(highest_segment)
    #SegmentDownloader.download_segment(Segment_URL, highest_segment)

#test()
def test2():
    segment_array = SegmentParser.segments_array(Segment_URL)
    parse_array = SegmentParser.parse_array(segment_array)
    print(parse_array)
test2()