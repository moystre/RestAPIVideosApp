﻿using System;
using System.Collections.Generic;
using System.Text;
using VideoAppUI.VideoAppDAL.Entities;

namespace VideoAppDAL.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int VideoId { get; set; }
        public Video Video { get; set; }
    }
}
