import os
import ffmpeg


from .FileUtils import FileOperations

class VideoCombiner(FileOperations):
    def __init(self):
        super()

    def concate_videos_txt_file(self):
        os.chdir(self.temp_video_download_location)
        with open("txt.txt", "w+") as file:
            for files in VideoCombiner.sort_videos(self):
                file.write("file" + " '" + str(files) + ".mp4" + "'\n")

    def concat_videos(self):
        os.chdir(self.temp_video_download_location)
        ffmpeg.input()

    def sort_videos(self):
        array = []
        for files in VideoCombiner(self.temp_video_download_location).list_files():
            if files.endswith(".mp4"):
                array.append(int(files[:-4]))
        return sorted(array)