using System;
using System.Collections.Generic;
using System.Text;
using SandboxApp.Model.Domain;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            return _context.TestTable
                .Include(t => t.TestSubTable)
                .Where(t => t.Testid == id)
                .FirstOrDefault();
        }

        public TestTable Add(TestTable testTable)
        {
            _context.TestTable.Add(testTable);
            _context.SaveChanges();

            return testTable;
        }

        public void Update(TestTable testTable)
        {
            _context.TestTable.Update(testTable);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var testTable = _context.TestTable.Find(id);
            _context.Remove(testTable);
            _context.SaveChanges();
        }
    }
}
