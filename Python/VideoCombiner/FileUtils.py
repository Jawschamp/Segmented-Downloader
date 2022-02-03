import os
import time


class FileOperations:
    def __init__(self, temp_video_download_location):
        self.temp_video_download_location = temp_video_download_location

    def create_directory(self) -> None:
        if not os.path.exists(self.temp_video_download_location):
            os.mkdir(self.temp_video_download_location + str(time.time()))
            print("Directory Created")

    def list_files(self):
        return os.listdir(self.temp_video_download_location)

    def get_file_size(self, file_names: list):
        os.chdir(self.temp_video_download_location)
        for file in file_names:
            if file.endswith(".mp4") and os.path.getsize(file) > 11111:
                os.remove(file)