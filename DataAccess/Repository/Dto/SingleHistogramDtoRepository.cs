using PowerMonitoring.Data;
using PowerMonitoring.DataAccess.Componenets;
using PowerMonitoring.DataAccess.Initialization;

namespace PowerMonitoring.DataAccess.Repository.Dto
{
    public class SingleHistogramDtoRepository : Repository<PowerLogDbContext, SingleHistogramDto>
    {
        public override object ConvertToPoco(SingleHistogramDto dto)
        {
            return dto.ToEntity();
        }

        public override object ConvertToDto(object entity)
        {
            return ((SingleHistogram) entity).ToDTO();
        }

        public override System.Type GetTypeOfPoco()
        {
            return typeof(SingleHistogram);
        }
    }
}