using System;
using System.Collections.Generic;

#nullable disable

namespace Negocios.MODELS
{
    public partial class Producto
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public long? Stock { get; set; }
    }
}
