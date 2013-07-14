using PowerMonitoring.Data;
using PowerMonitoring.DataAccess.Componenets;
using PowerMonitoring.DataAccess.Initialization;

namespace PowerMonitoring.DataAccess.Repository.Dto
{
    public class AlarmDtoRepository : Repository<PowerLogDbContext, AlarmDto>
    {
        public override object ConvertToPoco(AlarmDto dto)
        {
            return dto.ToEntity();
        }

        public override object ConvertToDto(object entity)
        {
            return ((Alarm) entity).ToDTO();
        }
    }
}