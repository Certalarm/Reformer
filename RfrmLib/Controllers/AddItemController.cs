using RfrmLib.Data.Implementation.XmlDataReader;
using RfrmLib.Data.Implementation.XmlDataWriter;
using RfrmLib.Domain.Entity;
using RfrmLib.Domain.UseCase.AddItem;
using RfrmLib.Domain.UseCase.SavePay;
using System.Collections.Generic;
using static RfrmLib.Controllers.ControllerHelper;

namespace RfrmLib.Controllers
{
    public class AddItemController
    {
        #region .ctors
        public AddItemController() { }
        #endregion

        // inputDataFilename = data1
        // stylesheetFilename = transform
        // outputDataFilename = employees
        public IEnumerable<string> Handle(
            string inputDataFilename, 
            string stylesheetFilename, 
            string outputDataFilename, 
            string item)
        {
            XmlDataReader reader = new XmlDataReader();
            var aii = new AddItemInteractor(reader);
            (Pay pay, string error) = aii.Execute(inputDataFilename, Mapper.ToDomain(item));
            if (error.Length > 0)
                return [error];

            XmlDataWriter writer = new XmlDataWriter();
            var spi = new SavePayInteractor(writer);
            var newInputFilename = GetNewInputDataFilename(inputDataFilename, outputDataFilename);
            error = spi.Execute(pay, newInputFilename);
            if (error.Length > 0)
                return [error];

            return HandleMainFlow(newInputFilename, stylesheetFilename, outputDataFilename);
        }
    }
}
