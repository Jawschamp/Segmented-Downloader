import urllib.request
import requests
import datetime

import random


from Parser.SegmentParser import SegmentParser

class SegmentDownloader:
    def __init__(self, url):
        self.url = url

    def http_status_algorithm(self):
        pass

    def download_segment(url, highest_segement):
        for segments in highest_segement:
             # Make the client run the add_to_array() function
             pass