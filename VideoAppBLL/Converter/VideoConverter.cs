using System;
using VideoAppUI.VideoAppBLL.BusinessObjects;
using VideoAppUI.VideoAppDAL.Entities;

namespace VideoAppBLL.Converter
{
    class VideoConverter
    {
        internal Video Convert(VideoBO videoBO)
        {
            if (videoBO == null) { return null; }

            return new Video()
            {
                Id = videoBO.Id,
                Title = videoBO.Title,
                Genre = videoBO.Genre,
                Duration = videoBO.Duration


               // Producers = videoBO.ProducerIds?.Select(producerId => new CustomerAddress()
               // {
                //    ProducerId = producerId,
                //    VideoId = videoBO.Id
                //}).ToList(),

            };
        }

        internal VideoBO Convert(Video video)
        {
            if(video == null) { return null; }
            
            return new VideoBO()
            {
                Id = video.Id,
                Title = video.Title,
                Genre = video.Genre,
                Duration = video.Duration,
                Producers = video.Producers
            };
        }
    }
}
