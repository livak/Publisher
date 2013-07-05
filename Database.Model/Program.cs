using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerMonitoring.Data;
using PowerMonitoring.DataAccess;

namespace Database.Model
{
    class Program
    {
        private const string Connectionstring = @"Data Source=jure-pc\sqlexpress;Initial Catalog=Logging2;persist security info=True; Integrated Security=SSPI;;Application Name=EntityFramework";
       
        static void Main(string[] args)
        {
            using (var ctx = new PowerLogDbContext(Connectionstring))
            {
                var query = ctx.Variables.ToList();
                query.Add(new Variable(){Name = "Pero"});
            }
            
        }
    }
}
