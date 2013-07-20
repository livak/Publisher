using PowerMonitoring.Data;
using PowerMonitoring.DataAccess.Componenets;
using PowerMonitoring.DataAccess.Initialization;

namespace PowerMonitoring.DataAccess.Repository.Dto
{
    public class AlarmLogDtoRepository : Repository<PowerLogDbContext, AlarmLogDto>
    {
        public override object ConvertToPoco(AlarmLogDto dto)
        {
            return dto.ToEntity();
        }

        public override object ConvertToDto(object entity)
        {
            return ((AlarmLog) entity).ToDTO();
        }

        public override System.Type GetTypeOfPoco()
        {
            return typeof(AlarmLog);
        }
    }
}