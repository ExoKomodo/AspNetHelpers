using System;
using AspNetHelpers.Models;

namespace Tests.Models
{
    public abstract class MockMapper : Mapper<Guid, SimpleModel, SimpleDto>
    {
    }
}