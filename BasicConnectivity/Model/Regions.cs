using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity
{
    public class Regions : ManageAll
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
