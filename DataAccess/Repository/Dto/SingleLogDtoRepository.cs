using PowerMonitoring.Data;
using PowerMonitoring.DataAccess.Componenets;
using PowerMonitoring.DataAccess.Initialization;

namespace PowerMonitoring.DataAccess.Repository.Dto
{
    public class SingleLogDtoRepository : Repository<PowerLogDbContext, SingleLogDto>
    {
        public override object ConvertToPoco(SingleLogDto dto)
        {
            return dto.ToEntity();
        }

        public override object ConvertToDto(object entity)
        {
            return ((SingleLog) entity).ToDTO();
        }

        public override System.Type GetTypeOfPoco()
        {
            return typeof(SingleLog);
        }
    }
}