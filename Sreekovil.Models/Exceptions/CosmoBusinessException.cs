using System;
using System.Collections.Generic;
using System.Text;

namespace COSMO.Models.Exceptions
{
    public class CosmoBusinessException : Exception
    {
        public CosmoBusinessException(string messagename)
        : base(messagename)
        {

        }
    }
}
