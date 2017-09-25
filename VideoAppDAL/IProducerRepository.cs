using System;
using System.Collections.Generic;
using System.Text;
using VideoAppDAL.Entities;

namespace VideoAppDAL
{
    public interface IProducerRepository

    {

        //
        Producer Create(Producer address);
        //R
        List<Producer> GetAll();
        IEnumerable<Producer> GetAllById(List<int> ids);
        Producer Get(int Id);
        //U
        //Update for Repository in the of Unit of Work
        //D
        Producer Delete(int Id);
    }
}
