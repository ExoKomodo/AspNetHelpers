using AspNetHelpers.Mappers;
using System;
using Tests.Dtos;
using Tests.Models;

namespace Tests.Mappers
{
    public class SimpleMapper : Mapper<Guid, SimpleModel, SimpleDto> {}
}
