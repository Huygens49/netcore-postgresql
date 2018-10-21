using SandboxApp.Model.Domain;
using System.Collections.Generic;

namespace SandboxApp.Model.Service
{
    public interface ITestSubService
    {
        TestSubTable Get(int id);
        TestSubTable Add(TestSubTable testSubTable);
        void Update(TestSubTable testSubTable);
        void Delete(int id);
    }
}
