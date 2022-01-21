import requests

class SegmentDownloader:
    def __init__(self, url):
        self.url = url

    def http_status_algorithm(self, url_list: list):
        for urls in url_list:
            print(urls)
            response = requests.get(urls)
            print(response.status_code)
            if response.status_code == 200:
                self.download_segment(urls)
            if response.status_code != 200:
                print("Error: " + str(response.status_code))
                break

    def download_segment(self):
        file = requests.get(self.url).content
        print(self.url.split("seg-"))
        # Make a nameing scheme for the file
        file_name = self.url.split("seg-")[1].split("-v1-a1.ts")[0]
        with open(file_name + ".ts", "wb") as f:
            f.write(file)
            print(file_name)
        return file_name
        #with open("{}".format(self.url.split("seg-")), "wb") as output:
        #    output.write(file)
