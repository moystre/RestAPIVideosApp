using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppBLL.Converter;
using VideoAppDAL;
using VideoAppUI.VideoAppBLL.BusinessObjects;
using VideoAppUI.VideoAppDAL.Entities;

namespace VideoAppBLL.Services
{
    class VideoService : IVideoService
    {
        DALFacade facade;
        VideoConverter conv = new VideoConverter();
        ProducerConverter pconv = new ProducerConverter();

        public VideoService(DALFacade facade)
        {
            this.facade = facade;
        }

        public VideoBO Create(VideoBO video)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVideo = uow.VideoRepository.Create(conv.Convert(video));
                uow.Complete();
                return conv.Convert(newVideo);
            }
        }

        public List<VideoBO> CreateVideos(List<VideoBO> listOfVideos)
        {
            using (var uow = facade.UnitOfWork)
            {
                List<VideoBO> newListOfVideos = new List<VideoBO>();
                foreach (var VideoBO in listOfVideos)
                {
                    var newVideo = uow.VideoRepository.Create(conv.Convert(VideoBO));
                    newListOfVideos.Add(conv.Convert(newVideo));
                }
                uow.Complete();
                return newListOfVideos;
            }      
        }

        public VideoBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVideo = uow.VideoRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(newVideo);
            }

            //var listOfVideos = FakeDB.Videos.Where(x => x.Id == Id).ToList();
            //FakeDB.Videos.RemoveAll(x => x.Id == Id);
        }

        public VideoBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                //get and convert the video
                var video = conv.Convert(uow.VideoRepository.Get(Id));

                if(video.ProducerIds != null)
                {
                    //get all related Producers from ProducerRepository using producer 
                    //convert and add the producers to the VideoBO

                    /*
                    video.Producers = video.ProducerIds?
                        .Select(id => pconv
                        .Convert(uow.ProducerRepository.Get(Id)))
                        .ToList();
                    */
                    video.Producers = uow.ProducerRepository.GetAllById(video.ProducerIds)
                        .Select(p => pconv.Convert(p))
                        .ToList();
                }

                //return conv.Convert(uow.VideoRepository.Get(Id));
                return video;
            }
        }

        public List<VideoBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                //list of Videos -> VideoBO
                return uow.VideoRepository.GetAll().Select(v => conv.Convert(v)).ToList();
            }
        }

        public VideoBO Update(VideoBO video)
        {
            using(var uow = facade.UnitOfWork)
            {
                var videoFromDB = uow.VideoRepository.Get(video.Id);
                if (videoFromDB == null)
                {
                    throw new InvalidOperationException("Video not found");
                }

                var videoUpdated = conv.Convert(video);

                videoFromDB.Title = video.Title;
                videoFromDB.Genre = video.Genre;
                videoFromDB.Duration = video.Duration;
                //videoFromDB.Producers = video.Producers;

                // 1. remove all, except the old ids we want to keep - avoid attached issues
                videoFromDB.Producers.RemoveAll(
                    vp => !videoUpdated.Producers.Exists(
                    p => p.ProducerId == vp.ProducerId && p.VideoId == vp.VideoId
                    ));
                // 2. remove all Ids in db from videoUpdated
                videoUpdated.Producers.RemoveAll(
                    vp => videoFromDB.Producers.Exists(
                    p => p.ProducerId == vp.ProducerId && p.VideoId == vp.VideoId
                    ));

                // 3. add all new VideoProducers not yet seen in db
                videoFromDB.Producers.AddRange(
                    videoUpdated.Producers);

                uow.Complete();
                return conv.Convert(videoFromDB);
            }
        }
    }
}
