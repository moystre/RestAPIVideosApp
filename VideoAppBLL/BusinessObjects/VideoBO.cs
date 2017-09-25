using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VideoAppBLL.BusinessObjects;

namespace VideoAppUI.VideoAppBLL.BusinessObjects
{
    public class VideoBO
    {
       
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        [MinLength(2)]
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }

        public List<ProducerBO> Producers { get; set; }
        //public object ProducerIds { get; internal set; }
    }
}
