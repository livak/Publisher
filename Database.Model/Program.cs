using PowerMonitoring.Data;
using PowerMonitoring.DataAccess.Repository.Dto;

namespace Database.Model
{
    class Program
    {
        static void Main(string[] args)
        {

            var variableRepo = new VariableDtoRepository();
            var variable = new VariableDto
                               {
                                   Name = "dto",
                                   Type = "1",
                                   DataLoggingEnabled = true,
                               };



            var varfromDB = variableRepo.Insert(variable, true);

            var variaabla=variableRepo.GetById(2);
            var varfromDb = variableRepo.Context.Variables.Find(8);

        }
    }
}
