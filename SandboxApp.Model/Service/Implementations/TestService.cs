using System;
using System.Collections.Generic;
using System.Text;
using SandboxApp.Model.Domain;
using System.Linq;

namespace SandboxApp.Model.Service.Implementations
{
    public class TestService : ITestService
    {
        private readonly PostgresContext _context;

        public TestService(PostgresContext context)
        {
            _context = context;
        }

        public List<TestTable> GetAll()
        {
            return _context.TestTable.ToList();
        }

        public TestTable Get(int id)
        {
            return _context.TestTable.Find(id);
        }

        public TestTable Add(TestTable testTable)
        {
            _context.TestTable.Add(testTable);
            return testTable;
        }

        public void Update(TestTable testTable)
        {
            _context.TestTable.Update(testTable);
        }

        public void Delete(int id)
        {
            var testTable = _context.TestTable.Find(id);
            _context.Remove(testTable);
        }
    }
}
