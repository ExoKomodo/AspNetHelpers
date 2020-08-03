using System;
using AspNetHelpers.Models;

namespace Tests.Models
{
    public class SimpleDto : Dto<Guid>
    {
        public float FloatingNumber { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
    }
}