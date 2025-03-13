// See https://aka.ms/new-console-template for more information
using static BackendCsharp.Inheritance;

Console.WriteLine("Hello, World!");

// Creación de un objeto y clases

// var sale = new Sale();
// Sale sale = new();

Sale sale = new Sale(15);
sale.Total = 26;
var saleTax = new SaleWithTax(15, 16.5m);

public class Sale
{
    public decimal Total { get; set; }
    // Acceso privado
    private decimal _some;

    // Constructor
    public Sale(decimal total)
    {
        // this.total = total;
        Total = total;
        _some = 16;
    }

    public string GetInfo()
    {
        return "Total de venta: " + Total;
    }

    // Método padre sobreescrito
    public virtual string GetData()
    {
        return "Dato: " + _some;
    }
}
