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

    def concat_videos(self, output_dir):
        os.chdir(self.temp_video_download_location)
        try:
            ffmpeg.input("txt.txt", f="concat").output("{}/movie.mp4".format(output_dir)).run()
        except ffmpeg.Error:
            pass

    def sort_videos(self):
        array = []
        for files in VideoCombiner(self.temp_video_download_location).list_files():
            if files.endswith(".mp4"):
                array.append(int(files[:-4]))
        return sorted(array)