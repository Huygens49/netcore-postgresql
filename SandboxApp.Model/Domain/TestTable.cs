using System;
using System.Collections.Generic;

namespace SandboxApp.Model.Domain
{
    public partial class TestTable
    {
        public TestTable()
        {
            TestSubTable = new HashSet<TestSubTable>();
        }

        public int Testid { get; set; }
        public string Testdescription { get; set; }
        public int? Testnumber { get; set; }
        public decimal? Testdecimal { get; set; }
        public DateTime? Testdate { get; set; }

        public ICollection<TestSubTable> TestSubTable { get; set; }
    }
}
