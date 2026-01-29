using FluentAssertions;
using RfrmLib.Domain.Entity;
using RfrmLib.Domain.UseCase.AddTotalAmount;
using RfrmLib.Tests.Fakes;
using Xunit;
using static RfrmLib.Utility.Txt;

namespace RfrmLib.Tests
{
    public class AddTotalAmountInteractorTests
    {
        private readonly AddTotalAmountInteractor _sut;

        #region .ctors
        public AddTotalAmountInteractorTests()
        {
            var reader = new FakeReader();
            _sut = new AddTotalAmountInteractor(reader);
        }
        #endregion

        [Fact]
        public void afterAdd_pay_will_has_not_empty_totalAmount_and_no_error()
        {
            (Pay pay, string error) = _sut.Execute("");

            error.Should().BeNullOrWhiteSpace();
            pay.TotalAmount.Should().NotBeEmpty();
        }

        [Fact]
        public void afterAdd_pay_will_has_need_totalAmount()
        {
            var needTotalAmount = "12003" + __systemDecimalSeparator + "2";

            (Pay pay, string error) = _sut.Execute("");

            pay.TotalAmount.Should().Be(needTotalAmount);
        }
    }
}
