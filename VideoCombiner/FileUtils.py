import os

class FileOperations:
    def __init__(self, temp_video_download_location):
        self.temp_video_download_location = temp_video_download_location

    def create_directory(self, name):
        if not os.path.isdir(self.temp_video_download_location):
            os.mkdir(self.temp_video_download_location)
            os.chdir(self.temp_video_download_location)
