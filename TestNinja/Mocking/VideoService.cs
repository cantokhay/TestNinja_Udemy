using System;
using System.Collections.Generic;
using System.Data.Entity;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        private IFileReader _fileReader;
        private IVideoRepository _videoRepository;

        public VideoService(IFileReader fileReader = null, IVideoRepository videoRepository = null)
        {
            _fileReader = fileReader ?? new FileReader();
            _videoRepository = videoRepository ?? new VideoRepository();
        } //ctor injection. this approach is better than property injection. But called poor man's dependency injection. We should choose best DI framework for our project.

        public string ReadVideoTitle()
        {
            //var str = File.ReadAllText("video.txt"); // This is a dependency on the file system. Tight coupling. Makes the code hard to test. So, we need to refactor this. Hence, we create an interface IFileReader and inject it into the VideoService class.

            var str = _fileReader.Read("video.txt"); // We add a dependency on the FileReader class. This is a better approach than the previous one. We can now mock the FileReader class in our tests.

            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();
            
            var videos = _videoRepository.GetUnprocessedVideos();

            foreach (var v in videos)
                    videoIds.Add(v.Id);

                return String.Join(",", videoIds);
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}