using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arquetipo.Infrastructure.Helpers
{
    public class ExMessage : Exception
    {
        public ExMessage(string message) : base(message)
        {
        }

    }
}
