from SegmentedDownloader import SegmentDownloader

class SegmentParser(SegmentDownloader):
    def url_parser(self):
        """"The paramater highest_segement should be the highest segment number
        It should either be manually placed or passed via the 
        SegmentDownloader.http_status_algorithm() function"""
        #segment_url = 
        array = []
        for i in range(1, 9999):
            array.append(self.url.split("seg-")[0] + "seg-" + str(i) + "-v1-a1.ts")
        return array