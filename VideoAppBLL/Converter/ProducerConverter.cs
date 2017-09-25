using System;
using System.Collections.Generic;
using System.Text;
using VideoAppBLL.BusinessObjects;
using VideoAppDAL.Entities;

namespace VideoAppBLL.Converter
{
    class ProducerConverter
    {
        internal Producer Convert(ProducerBO producerBO)
        {
            if (producerBO == null) { return null; }
            return new Producer()
            {
                Id = producerBO.Id,
                Name = producerBO.Name
            };
        }

        internal ProducerBO Convert(Producer genre)
        {
            if (genre == null) { return null; }
            return new ProducerBO()
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }
    }
}
