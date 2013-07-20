using PowerMonitoring.Data;
using PowerMonitoring.DataAccess.Componenets;
using PowerMonitoring.DataAccess.Initialization;

namespace PowerMonitoring.DataAccess.Repository.Dto
{
    public class DoubleLogDtoRepository : Repository<PowerLogDbContext, DoubleLogDto>
    {
        public override object ConvertToPoco(DoubleLogDto dto)
        {
            return dto.ToEntity();
        }

        public override object ConvertToDto(object entity)
        {
            return ((DoubleLog) entity).ToDTO();
        }

        public override System.Type GetTypeOfPoco()
        {
            return typeof(DoubleLog);
        }
    }
}