import requests
import threading
import time
import os

from VideoCombiner.FileUtils import FileOperations


class SegmentDownloader(FileOperations):
    def __init__(self):
        super()

    def http_status_algorithm(self, url_list: list):
        for urls in url_list:
            count = 0
            response = requests.get(urls)
            print("HTTP Status:", response.status_code, time.time())
            if response.status_code == 200:
                count += 1
                try:
                    if int(response.headers["Content-Length"]) < 1024:
                        url_list.remove(urls)
                    else:
                        print(count)
                        t1 = threading.Thread(target=self.download_segment, args=(urls,))
                        t1.start()
                except:
                    return url_list
            if response.status_code != 200:
                print("Error: " + str(response.status_code), time.time())
                break

    def download_segment(self, urls):
        file = requests.get(urls).content
        file_name = urls.split("seg-")[1].split("-v1-a1.ts")[0]
        os.chdir(self.temp_video_download_location)
        with open(file_name + ".mp4", "wb") as f:
            f.write(file)
            print(file_name)
        return file_name