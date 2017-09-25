using System;
using System.Linq;
using VideoAppBLL.BusinessObjects;
using VideoAppDAL.Entities;
using VideoAppUI.VideoAppBLL.BusinessObjects;
using VideoAppUI.VideoAppDAL.Entities;

namespace VideoAppBLL.Converter
{
    class VideoConverter
    {
        private ProducerConverter pConv; 

        public VideoConverter()
        {
            pConv = new ProducerConverter();
        }

        internal Video Convert(VideoBO videoBO)
        {
            if (videoBO == null) { return null; }

            return new Video()
            {
                Id = videoBO.Id,
                Title = videoBO.Title,
                Genre = videoBO.Genre,
                Duration = videoBO.Duration,

                //? wont do select unless there is something. return null if there s a null
                Producers = videoBO.ProducerIds?.Select(pIds => new VideoProducer(){
                    ProducerId = pIds,
                    VideoId = videoBO.Id
                }).ToList()

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

                ProducerIds = video.Producers?.Select(p => p.ProducerId).ToList(),
                Producers = video.Producers?.Select(p => new ProducerBO() {
                    Id = p.ProducerId,
                    Name = p.Producer?.Name,
                    Location = p.Producer?.Location
                }).ToList()
            };
        }
    }
}
