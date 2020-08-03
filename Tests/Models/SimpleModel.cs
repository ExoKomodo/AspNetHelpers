using AspNetHelpers.Models;
using System;

namespace Tests.Models
{
    public class SimpleModel : Model<Guid>
    {
        public float FloatingNumber { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string SensitiveInfo { get; set; }

    }
}
