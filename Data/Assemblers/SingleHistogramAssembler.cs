//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2013.07.14 - 16:59:50
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using PowerMonitoring.Data;

namespace PowerMonitoring.Data
{

    /// <summary>
    /// Assembler for <see cref="SingleHistogram"/> and <see cref="SingleHistogramDto"/>.
    /// </summary>
    public static partial class SingleHistogramAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="SingleHistogramDto"/> converted from <see cref="SingleHistogram"/>.</param>
        static partial void OnDTO(this SingleHistogram entity, SingleHistogramDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="SingleHistogram"/> converted from <see cref="SingleHistogramDto"/>.</param>
        static partial void OnEntity(this SingleHistogramDto dto, SingleHistogram entity);

        /// <summary>
        /// Converts this instance of <see cref="SingleHistogramDto"/> to an instance of <see cref="SingleHistogram"/>.
        /// </summary>
        /// <param name="dto"><see cref="SingleHistogramDto"/> to convert.</param>
        public static SingleHistogram ToEntity(this SingleHistogramDto dto)
        {
            if (dto == null) return null;

            var entity = new SingleHistogram();

            entity.SingleHistogramId = dto.SingleHistogramId;
            entity.SingleValue = dto.SingleValue;
            entity.TimeStamp = dto.TimeStamp;
            entity.VariableId = dto.VariableId;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="SingleHistogram"/> to an instance of <see cref="SingleHistogramDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="SingleHistogram"/> to convert.</param>
        public static SingleHistogramDto ToDTO(this SingleHistogram entity)
        {
            if (entity == null) return null;

            var dto = new SingleHistogramDto();

            dto.SingleHistogramId = entity.SingleHistogramId;
            dto.SingleValue = entity.SingleValue;
            dto.TimeStamp = entity.TimeStamp;
            dto.VariableId = entity.VariableId;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="SingleHistogramDto"/> to an instance of <see cref="SingleHistogram"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<SingleHistogram> ToEntities(this IEnumerable<SingleHistogramDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="SingleHistogram"/> to an instance of <see cref="SingleHistogramDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<SingleHistogramDto> ToDTOs(this IEnumerable<SingleHistogram> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
