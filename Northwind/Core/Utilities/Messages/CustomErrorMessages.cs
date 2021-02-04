using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Messages
{
    public static class CustomErrorMessages
    {
        public static string NoControllerFound = "No controller found";
        public static string TypeDoesNotSubclassControllerBase = "Type does not subclass of ControllerBase";
        public static string TypeDoesNotSubclassValidatorBase = "Type does not subclass of ValidatorBase";
    }
}
