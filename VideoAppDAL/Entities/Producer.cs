using System;
using System.Collections.Generic;
using System.Text;
using VideoAppUI.VideoAppDAL.Entities;

namespace VideoAppDAL.Entities
{
    public class Producer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        List<Video> Videos { get; set; }
    }
}
