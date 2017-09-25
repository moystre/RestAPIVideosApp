using System;
using System.Collections.Generic;
using System.Text;
using VideoAppDAL.Entities;

namespace VideoAppUI.VideoAppDAL.Entities
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }

        public List<Genre> Genres { get; set; }
        public List<VideoProducer> VideoProducer { get; set; }
    }
}
