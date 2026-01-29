using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using RfrmLib.Domain.UseCase.AddSalarySum;
using RfrmLib.Tests.Fakes;

namespace RfrmLib.Tests
{
    public class AddSalarySumInteractorTests
    {
        private readonly AddSalarySumInteractor _sut;

        #region .ctors
        public AddSalarySumInteractorTests()
        {
            var reader = new FakeReader();
            var writer = new FakeWriter();
            _sut = new AddSalarySumInteractor(reader, writer);
        }
        #region
    }
}
