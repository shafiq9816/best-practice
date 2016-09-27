using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRMA.BowlingScorer.Common.ErrorManagement
{    
    public class ProcessingException : Exception
    {
        public ProcessingException()
        {
        }

        public ProcessingException(string message)
            : base(message)
        {
        }

        public ProcessingException(Exception innerException)
            : base(null, innerException)
        {
        }

        public ProcessingException(string message, Exception innerException)
            : base(message, innerException)
        {
        }


        public override string Message
        {
            get
            {
                var baseError = base.Message;
                return baseError;
            }
        }
    }
}
