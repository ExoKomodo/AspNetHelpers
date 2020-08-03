using System;
using AspNetHelpers.Models;

namespace Tests.Models
{
    public class SimpleMapper : Mapper<Guid, SimpleModel, SimpleDto>
    {
        public override SimpleDto ToDto(SimpleModel model)
        {
            return new SimpleDto {
                Id = model.Id,
                FloatingNumber = model.FloatingNumber,
                Name = model.Name,
                Number = model.Number,
            };
        }

        public override SimpleModel ToModel(SimpleDto dto)
        {
            return new SimpleModel {
                Id = dto.Id,
                FloatingNumber = dto.FloatingNumber,
                Name = dto.Name,
                Number = dto.Number,
            };
        }
    }
}