using PowerMonitoring.Data;
using PowerMonitoring.DataAccess.Repository;

namespace Database.Model
{
    class Program
    {
        static void Main(string[] args)
        {

            var variableRepo = new VariableRepository();
            var variable = new VariableDto
                               {
                                   Name = "dto",
                                   Type = "1",
                                   DataLoggingEnabled = true,
                               };

            var varfromDB = variableRepo.Insert(variable.ToEntity(), true);

            var varfromDb = variableRepo.Context.Variables.Find(8);

        }
    }
}
