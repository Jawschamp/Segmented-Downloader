import requests
import threading
class SegmentDownloader:
    def http_status_algorithm(self, url_list: list):
        for urls in url_list:
            count = 0
            response = requests.get(urls)
            print(response.status_code)
            if response.status_code == 200:
                count += 1
                print(count)
                t1 = threading.Thread(target=self.download_segment, args=(urls,))
                t1.start()
            if response.status_code != 200:
                print("Error: " + str(response.status_code))
                break

    def download_segment(self, urls: list):
        file = requests.get(urls).content
        file_name = urls.split("seg-")[1].split("-v1-a1.ts")[0]
        with open(file_name + ".mp4", "wb") as f:
            f.write(file)
            print(file_name)
        return file_name