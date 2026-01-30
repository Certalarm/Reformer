using System.Collections.Generic;

namespace RfrmLib.Controllers
{
    public class MainFlowController
    {
        #region .ctors
        public MainFlowController()
        {
        }
        #endregion

        // inputDataFilename = data1
        // stylesheetFilename = transform
        // outputDataFilename = employees
        public IEnumerable<string> Handle(
            string inputDataFilename, 
            string stylesheetFilename, 
            string outputDataFilename)
        {
            return ControllerHelper.HandleMainFlow(inputDataFilename, stylesheetFilename, outputDataFilename);
        }


    }
}
