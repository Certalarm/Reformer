using FluentAssertions;
using RfrmLib.Domain.Entity;
using RfrmLib.Domain.UseCase.AddSalarySum;
using RfrmLib.Tests.Fakes;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static RfrmLib.Utility.Txt;

namespace RfrmLib.Tests
{
    public class AddSalarySumInteractorTests
    {
        private readonly AddSalarySumInteractor _sut;

        #region .ctors
        public AddSalarySumInteractorTests()
        {
            var reader = new FakeReader();
            _sut = new AddSalarySumInteractor(reader);
        }
        #endregion

        [Fact]
        public void afterRead_employees_will_has_not_empty_salarySum_and_no_error()
        {
            (IEnumerable<Employee> employees, string error) = _sut.Execute("", "");

            error.Should().BeNullOrWhiteSpace();
            employees.First().SalarySum.Should().NotBeEmpty();
            employees.Skip(1).First().SalarySum.Should().NotBeEmpty();
        }

        [Fact]
        public void afterRead_employees_will_has_need_salarySum()
        {
            var needSalarySum1 = "6003" + __systemDecimalSeparator + "2";
            var needSalarySum2 = "6000";

            (IEnumerable<Employee> employees, string error) = _sut.Execute("", "");

            employees.First().SalarySum.Should().Be(needSalarySum1);
            employees.Skip(1).First().SalarySum.Should().Be(needSalarySum2);
        }
    }
}
