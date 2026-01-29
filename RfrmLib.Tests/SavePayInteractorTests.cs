using FluentAssertions;
using RfrmLib.Domain.UseCase.SavePay;
using RfrmLib.Tests.Data;
using RfrmLib.Tests.Fakes;
using Xunit;
using static RfrmLib.Utility.Txt;

namespace RfrmLib.Tests
{
    public class SavePayInteractorTests
    {
        private readonly SavePayInteractor _sut;

        #region .ctors
        public SavePayInteractorTests()
        {
            var writer = new FakeWriter();
            _sut = new SavePayInteractor(writer);
        }
        #endregion

        [Fact]
        public void afterSave_with_empty_filename_has_error()
        {
            var pay = Pays.Get();

            string error = _sut.Execute(pay, "");

            error.Should().Be(__errorFilenames);
        }

        [Fact]
        public void afterSave_with_null_pay_has_error()
        {
            string error = _sut.Execute(null, "lalala");

            error.Should().Be(__errorNullData);
        }
    }
}
