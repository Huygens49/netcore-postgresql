using SandboxApp.Model.Domain;
using System.Collections.Generic;

namespace SandboxApp.Model.Service
{
    public interface ITestService
    {
        List<TestTable> GetAll();
        TestTable Get(int id);
        void Add(TestTable testTable);
        void Update(TestTable testTable);
        void Delete(int id);
    }
}
