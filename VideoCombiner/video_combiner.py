import os

class VideoCombiner:
    def __init__(self, video_location: str, output_location: str, video_list: list) -> None:
        """
        Initializes the VideoCombiner class.
        :param video_location: The location of the video to be combined.
        """
        self.video_location = video_location
        self.output_location = output_location
        self.video_list = video_list

    def combine_videos(self):
        """
        Combines all the videos in the video_list into one video ordered by the video name.
        :param video_list: List of videos to combine
        :param output_location: Location to save the combined video
        :return:
        """
        command = "ffmpeg -f concat -i " + self.video_location + \
                  " -c copy " + self.output_location
        os.system(command)

    def sort_videos(self):
        self.video_list.sort()

class VideoUtils(VideoCombiner):
    def __init__(self, video_location, video_list) -> None:
        super().__init__(video_location, video_list)

    def get_video_list(self):
        """
        Gets a list of all the videos in the video_location.
        :return: List of videos in the video_location
        """
        video_list = []
        for file in os.listdir(self.video_location):
            if file.endswith(".ts"):
                video_list.append(file)
        return video_list

    def get_video_length(self, video_name: str) -> int:
        """
        Gets the length of the video in seconds.
        :param video_name: Name of the video to get the length of.
        :return: Length of the video in seconds.
        """
        command = "ffprobe -i " + self.video_location + video_name + " -show_entries format=duration -v quiet -of csv=\"p=0\""
        output = os.popen(command).read()
        return int(output)

    def get_video_name(self, video_name: str) -> str:
        """
        Gets the name of the video without the extension.
        :param video_name: Name of the video to get the name of.
        :return: Name of the video without the extension.
        """
        return video_name.split(".")[0]

    def get_video_extension(self, video_name: str) -> str:
        """
        Gets the extension of the video.
        :param video_name: Name of the video to get the extension of.
        :return: Extension of the video.
        """
        return video_name.split(".")[1]
