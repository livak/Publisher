using PowerMonitoring.Data;
using PowerMonitoring.DataAccess.Componenets;
using PowerMonitoring.DataAccess.Initialization;

namespace PowerMonitoring.DataAccess.Repository.Dto
{
    public class VariableDtoRepository : Repository<PowerLogDbContext, VariableDto>
    {
        public override object ConvertToPoco(VariableDto dto)
        {
            return dto.ToEntity();
        }

        public override object ConvertToDto(object entity)
        {
            return ((Variable) entity).ToDTO();
        }

        public override System.Type GetTypeOfPoco()
        {
            return typeof (Variable);
        }
    }
}