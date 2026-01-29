using FluentAssertions;
using RfrmLib.Domain.Entity;
using RfrmLib.Domain.UseCase.AddItem;
using RfrmLib.Tests.Fakes;
using Xunit;
using static RfrmLib.Utility.Txt;

namespace RfrmLib.Tests
{
    public class AddItemInteractorTests
    {
        private readonly AddItemInteractor _sut;

        #region .ctors
        public AddItemInteractorTests()
        {
            var reader = new FakeReader();
            _sut = new AddItemInteractor(reader);
        }
        #endregion

        [Fact]
        public void afterAdd_null_item_has_error()
        {
            (Pay pay, string error) = _sut.Execute("", null);

            error.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void afterAdd_item_totalAmount_will_changed()
        {
            var item = new Item("Lena", "Ivanova", "1234.3", "april");
            var result = "13237" + __systemDecimalSeparator + "5";

            (Pay pay, string error) = _sut.Execute("", item);
            
            pay.TotalAmount.Should().Be(result);
        }
    }
}
