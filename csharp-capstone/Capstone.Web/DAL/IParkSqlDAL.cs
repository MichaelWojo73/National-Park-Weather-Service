using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public interface IParkSqlDAL
    {
        IList<Park> GetParks();

        Park GetPark(string id);

        
    }
}
