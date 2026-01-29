using FluentAssertions;
using RfrmLib.Domain.Entity;
using RfrmLib.Domain.UseCase.AddSalarySum;
using RfrmLib.Domain.UseCase.GetEmployeesAmounts;
using RfrmLib.Tests.Fakes;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static RfrmLib.Utility.Txt;

namespace RfrmLib.Tests
{
    public class GetEmployeesAmountsInteractorTests
    {
        private readonly GetEmployeesAmountsInteractor _sut;
        private readonly IEnumerable<Employee> _employees;

        #region .ctors
        public GetEmployeesAmountsInteractorTests()
        {
            var reader = new FakeReader();
            var addSalaryInteractor = new AddSalarySumInteractor(reader);
            _employees = addSalaryInteractor.Execute("", "").Item1;
            _sut = new GetEmployeesAmountsInteractor();
        }
        #endregion

        [Fact]
        public void afterGet_result_have_2_items()
        {
            var result = _sut.Execute(_employees);

            result.Should().HaveCount(2);
        }

        [Fact]
        public void afterGet_result_have_sums()
        {
            var sumFirst = "6003" + __systemDecimalSeparator + "2";
            var sumSecond = "6000";

            var result = _sut.Execute(_employees);

            result.First().Should().Contain(sumFirst);
            result.Skip(1).First().Should().Contain(sumSecond);
        }
    }
}
