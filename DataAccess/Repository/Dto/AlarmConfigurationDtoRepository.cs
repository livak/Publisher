using PowerMonitoring.Data;
using PowerMonitoring.DataAccess.Componenets;
using PowerMonitoring.DataAccess.Initialization;

namespace PowerMonitoring.DataAccess.Repository.Dto
{
    public class AlarmConfigurationDtoRepository : Repository<PowerLogDbContext, AlarmConfigurationDto>
    {
        public override object ConvertToPoco(AlarmConfigurationDto dto)
        {
            return dto.ToEntity();
        }

        public override object ConvertToDto(object entity)
        {
            return ((AlarmConfiguration) entity).ToDTO();
        }
    }
}