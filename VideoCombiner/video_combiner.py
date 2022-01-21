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

    def combine_videos(self, video_name: str):
        """
        Combines all the videos in the video_list into one video ordered by the video name.
        at the end ask for input on what to name the video
        """
        command = "ffmpeg -f concat -i " + self.video_location + \
                  " -c copy " + self.output_location + video_name
        os.system(command)

class VideoUtils(VideoCombiner):
    def __init__(self, video_location, video_list) -> None:
        super().__init__(video_location, video_list)