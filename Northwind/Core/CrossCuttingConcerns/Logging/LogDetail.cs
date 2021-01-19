using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Logging
{
    public class LogDetail
    {
        /// <summary>
        /// Class name to log, it involves namespaces
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// method name to log
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// Parameters of method to log
        /// </summary>
        public List<LogParameter> Parameters { get; set; }

    }
}
