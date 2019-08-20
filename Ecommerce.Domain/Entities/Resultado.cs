using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce
{
    public class Resultado<T>
    {
        public string Mensagem { get; set; } 
        public bool Sucesso { get; set; }
        public T Dado { get; set; }
    }
}
