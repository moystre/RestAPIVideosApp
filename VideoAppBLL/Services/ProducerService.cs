using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppBLL.BusinessObjects;
using VideoAppBLL.Converter;
using VideoAppDAL;

namespace VideoAppBLL.Services
{
    public class ProducerService : IProducerService
    {

        ProducerConverter _conv;
        DALFacade _facade;


        public ProducerService(DALFacade facade)
        {
            _facade = facade;
            _conv = new ProducerConverter();
        }

        public ProducerBO Create(ProducerBO producerBO)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newproducer = uow.ProducerRepository.Create(_conv.Convert(producerBO));
                uow.Complete();
                return _conv.Convert(newproducer);
            }
        }

        public ProducerBO Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                return _conv.Convert(uow.ProducerRepository.Get(Id));
            }
        }

        public ProducerBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                return _conv.Convert(uow.ProducerRepository.Get(Id));
            }
        }

        public List<ProducerBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.ProducerRepository.GetAll().Select(_conv.Convert).ToList();
            }
        }

        public ProducerBO Update(ProducerBO producerBO)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var producerfromDB = uow.ProducerRepository.Get(producerBO.Id);

                if (producerfromDB == null)
                {
                    throw new InvalidOperationException("Address not found");
                }           
                var producerUpdated = _conv.Convert(producerBO);
                producerfromDB.Name = producerUpdated.Name;
                producerfromDB.Location = producerUpdated.Location;

                uow.Complete();
                return _conv.Convert(producerfromDB);
            }
        }
    }
}
