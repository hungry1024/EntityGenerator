using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityGenerator
{
    static class Guids
    {
        public const string guidEntityGeneratorPkgString = "3eb5be4a-0816-4d30-92e4-3edd9c786feb";

        public const string guidEntityGeneratorCmdSetString = "3a67dc42-a63c-4aac-98b2-41911fb4c65f";
        public static readonly Guid guidEntityGeneratorPackageCmdSet = new Guid(guidEntityGeneratorCmdSetString);
    }
}
