using System;
using System.Collections.Generic;
using System.Text;
using VideoAppDAL.Repositories;
using VideoAppDAL.UOW;

namespace VideoAppDAL
{
    public class DALFacade
    {
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return new UnitOfWorkMemory();
            }
        }
    }
}
