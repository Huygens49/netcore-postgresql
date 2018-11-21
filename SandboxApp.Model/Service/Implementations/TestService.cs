using Microsoft.EntityFrameworkCore;
using SandboxApp.Model.Domain;
using SandboxApp.Model.Exceptions;
using System.Collections.Generic;
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
            var testTable = _context.TestTable
                .Include(t => t.TestSubTable)
                .Where(t => t.Testid == id)
                .FirstOrDefault();

            if (testTable == null) throw new ItemNotFoundException($"TestTable {id} not found.");

            return testTable;
        }

        public void Add(TestTable testTable)
        {
            // Pretend description is required
            if (string.IsNullOrEmpty(testTable.Testdescription)) throw new InvalidInputException("Required field missing.");

            _context.TestTable.Add(testTable);
            _context.SaveChanges();
        }

        public void Update(TestTable testTable)
        {
            var existingTestTable = _context.TestTable.Find(testTable.Testid);

            if (existingTestTable == null) throw new ItemNotFoundException($"TestTable {testTable.Testid} not found.");
            if (string.IsNullOrEmpty(testTable.Testdescription)) throw new InvalidInputException("Required field missing.");

            // Entity Framework is weird and this seems like the only away to avoid all exception states?
            existingTestTable.Testdescription = testTable.Testdescription;
            existingTestTable.Testnumber = testTable.Testnumber;
            existingTestTable.Testdecimal = testTable.Testdecimal;
            existingTestTable.Testdate = testTable.Testdate;

            _context.TestTable.Update(existingTestTable);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var testTable = _context.TestTable.Find(id);

            if (testTable == null) throw new ItemNotFoundException($"TestTable {id} not found.");

            _context.Remove(testTable);
            _context.SaveChanges();
        }
    }
}
