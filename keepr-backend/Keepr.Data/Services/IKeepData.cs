using Keepr.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keepr.Data.Services
{
    public interface IKeepData
    {
        Keep Get(int id);
        IEnumerable<Keep> GetAll();
        void Add(Keep keep);
        void Update(Keep keep);
        void Delete(int id);
    }
}
