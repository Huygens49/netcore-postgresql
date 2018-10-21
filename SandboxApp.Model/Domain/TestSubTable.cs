using System;
using System.Collections.Generic;

namespace SandboxApp.Model.Domain
{
    public partial class TestSubTable
    {
        public int Testsubid { get; set; }
        public int? Testid { get; set; }
        public string Testsubdescription { get; set; }
        public DateTime? Testsubdate { get; set; }

        public TestTable Test { get; set; }
    }
}
