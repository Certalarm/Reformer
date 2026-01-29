using FluentAssertions;
using RfrmLib.Domain.UseCase.SaveEmployees;
using RfrmLib.Tests.Data;
using RfrmLib.Tests.Fakes;
using Xunit;
using static RfrmLib.Utility.Txt;

namespace RfrmLib.Tests
{
    public class SaveEmployeesInteractorTests
    {
        private readonly SaveEmployeesInteractor _sut;

        #region .ctors
        public SaveEmployeesInteractorTests()
        {
            var writer = new FakeWriter();
            _sut = new SaveEmployeesInteractor(writer);
        }
        #endregion

        [Fact]
        public void afterSave_with_empty_filename_has_error()
        {
            var employees = Employees.Get();

            string error = _sut.Execute(employees, "");

            error.Should().Be(__errorFilenames);
        }

        [Fact]
        public void afterSave_with_null_employees_has_error()
        {
            string error = _sut.Execute(null, "lalala");

            error.Should().Be(__errorNullData);
        }
    }
}
