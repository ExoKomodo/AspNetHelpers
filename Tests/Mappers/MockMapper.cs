using AspNetHelpers.Mappers;
using System;
using Tests.Dtos;
using Tests.Models;

namespace Tests.Mappers
{
    public abstract class MockMapper : Mapper<Guid, SimpleModel, SimpleDto>
    {
    }
}