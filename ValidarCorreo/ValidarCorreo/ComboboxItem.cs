using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidarCorreo
{
    class ComboboxItem
    {
        public String texto { get; set; }
        public String value { get; set; }

        public override string ToString()
        {
            return texto;
        }
    }
}
