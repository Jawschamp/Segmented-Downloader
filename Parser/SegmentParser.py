class SegmentParser:
    def url_splitter(segment_url):
        segment_url = segment_url.split("seg-")[0] + "seg-" # + SegmentParser.add_to_array(segment_url)[0]
        array = []
        for i in range(1, 20):
            array.append(segment_url + str(i) + "-v1-a1.ts")
        return array

    def parse_array(array: function):
        for segmet_url_strings in array:
            return segmet_url_strings