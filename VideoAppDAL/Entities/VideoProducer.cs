using System;
using System.Collections.Generic;
using System.Text;
using VideoAppUI.VideoAppDAL.Entities;

namespace VideoAppDAL.Entities
{
    public class VideoProducer
    {
        public int VideoId { get; set; }
        public Video Video { get; set; }

        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
    }
}
