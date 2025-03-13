using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BackendCsharp
{
    class Inheritance
    {
        // Herencia Reutitización
        public class SaleWithTax : Sale
        {
            public decimal Tax { get; set; }

            public SaleWithTax(decimal total, decimal tax) : base(total)
            {
                GetInfo();
                Tax = tax;
            }

            public string GetinfoWithTax()
            {
                return "Total: " + Total + "Impuesto: " + Tax;
            }

            // Sobreescritura de objeto
            public override string GetData()
            {
                return base.GetData();
            }
        }
    }
}
