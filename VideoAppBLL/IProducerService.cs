using System;
using System.Collections.Generic;
using System.Text;
using VideoAppBLL.BusinessObjects;

namespace VideoAppBLL
{
    public interface IProducerService
    {
        //C
        ProducerBO Create(ProducerBO producerBO);
        //R
        List<ProducerBO> GetAll();
        ProducerBO Get(int Id);
        //U
        ProducerBO Update(ProducerBO cust);
        //D
        ProducerBO Delete(int Id);
    }
}
