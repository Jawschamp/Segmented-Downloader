import os

class VideoCombiner:
    def __init__(self, video_location, output_location, video_list) -> None:
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