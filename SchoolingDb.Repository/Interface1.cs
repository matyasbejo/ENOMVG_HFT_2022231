using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENOMVG_HFT_2022231.Repository
{
    public interface ISchoolingRepository
    {
        void Create();

        void Delete(int id);
    }
}
