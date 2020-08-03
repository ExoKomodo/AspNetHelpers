using System;
using AspNetHelpers.Dtos;

namespace Tests.Dtos
{
    public class SimpleDto : Dto<Guid>
    {
        public float FloatingNumber { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
    }
}
