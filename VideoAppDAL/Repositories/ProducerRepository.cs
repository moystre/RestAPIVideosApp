using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppDAL.Context;
using VideoAppDAL.Entities;

namespace VideoAppDAL.Repositories
{
    class ProducerRepository : IProducerRepository
    {
        VideoAppContext _context;

        public ProducerRepository(VideoAppContext context)
        {
            _context = context;
        }

        public Producer Create(Producer producer)
        {
            _context.Producers.Add(producer);
            return producer;
        }

        public Producer Delete(int Id)
        {
            var producer = Get(Id);
            _context.Producers.Remove(producer);
            return producer;
        }

        public Producer Get(int Id)
        {
            return _context.Producers.FirstOrDefault(a => a.Id == Id);
        }

        public List<Producer> GetAll()
        {
            return _context.Producers.ToList();
        }


        public IEnumerable<Producer> GetAllById(List<int> ids)
        {
            if (ids == null) { return null; }
            return _context.Producers.Where(p => ids.Contains(p.Id));


        }
    }
}   
