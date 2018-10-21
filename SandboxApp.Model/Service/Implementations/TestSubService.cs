using Microsoft.EntityFrameworkCore;
using SandboxApp.Model.Domain;
using SandboxApp.Model.Exceptions;
using System.Collections.Generic;
using System.Linq;


namespace SandboxApp.Model.Service.Implementations
{
    public class TestSubService : ITestSubService
    {
        private readonly PostgresContext _context;

        public TestSubService(PostgresContext context)
        {
            _context = context;
        }

        public List<TestSubTable> GetAllForTestTable(int testId)
        {
            return _context.TestSubTable.Where(s => s.Testid == testId).ToList();
        }

        public TestSubTable Get(int id)
        {
            var testSubTable = _context.TestSubTable.Find(id);

            if (testSubTable == null) throw new ItemNotFoundException(string.Format("TestSubTable {0} not found.", id));

            return testSubTable;
        }

        public TestSubTable Add(TestSubTable testSubTable)
        {
            // Pretend description is required
            if (string.IsNullOrEmpty(testSubTable.Testsubdescription)) throw new InvalidInputException("Required field missing.");

            _context.Add(testSubTable);
            _context.SaveChanges();

            return testSubTable;
        }

        public void Update(TestSubTable testSubTable)
        {
            var existingSubTable = _context.TestSubTable.Find(testSubTable.Testsubid);

            if (existingSubTable == null) throw new ItemNotFoundException(string.Format("TestSubTable {0} not found.", testSubTable.Testsubid));
            if (string.IsNullOrEmpty(testSubTable.Testsubdescription)) throw new InvalidInputException("Required field missing.");

            existingSubTable.Testsubdescription = testSubTable.Testsubdescription;
            existingSubTable.Testsubdate = testSubTable.Testsubdate;

            _context.TestSubTable.Update(existingSubTable);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var testSubTable = _context.TestSubTable.Find(id);

            if (testSubTable == null) throw new ItemNotFoundException(string.Format("TestTable {0} not found.", testSubTable.Testsubid));

            _context.Remove(testSubTable);
            _context.SaveChanges();
        }
    }
}
