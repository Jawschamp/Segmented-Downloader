import urllib.request
import requests
import random


class SegmentDownloader:
    def http_status_algorithm(url, segment_number):
        '''
        Split the url paramater when the letters "/720" appear"
        '''
        first_part_of_url = url[:url.find("/720")]
        #SegmentDownloader.insert_segment(segment_number)
        #seg_splitter = first_part_of_url[1].split("-v1-a1.ts")[0]
        combine = []
        combine.append(first_part_of_url)
        #combine.append(seg_splitter)
        print(first_part_of_url)

        if segment_number > 10 or 100 or 1000 or 10000:
            while segment_number == 1111:
                segment_number = segment_number + 1
                print(segment_number)
        else:
            return combine


    def insert_segment(segment_nums):
        '''
        Insert the segment number into the list of segments
        '''
        segs = []
        segs.append(segment_nums)

    def download_segment(url, segment_number):
        '''
        Using urllib download all returned endpoints from the http_status_algo() function
        '''
        urllib.request.urlretrieve(url + str(segment_number), str(segment_number) + ".mp4")
        

SegmentDownloader.http_status_algorithm("https://e-3.birdsystem.ru/_v5/90dbdf2fe1188c9242f8b25c678e9050342a39ed8baa4c6bc23c020542b4320bc2b4cdf26fa8e353d29eeff707035a90d45f159e64d5f977921b89232f912c9c888d47f2513d7551b83b6a146efe48750de1f0606c97bc56f594f8b1aeceb1cbd3556df04d7d5310f459cf165f2b23b7c65ec1cc497bdde8b20e33f3864b7357/720/seg-1-v1-a1.ts", 
10)