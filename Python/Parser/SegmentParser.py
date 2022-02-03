from Python.SegmentedDownloader import SegmentDownloader

class SegmentParser(SegmentDownloader):
    def url_parser(self):
        array = []
        for i in range(1, 9999):
            array.append(self.url.split("seg-")[0] + "seg-" + str(i) + "-v1-a1.ts")
        return array