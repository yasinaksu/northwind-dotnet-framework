using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Logging
{
    public class LogParameter
    {
        /// <summary>
        /// Name of the method parameter
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type of the method parameter
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Value of method parameter
        /// </summary>
        public object Value { get; set; }
    }
}
