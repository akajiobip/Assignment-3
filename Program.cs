using System;
namespace Assignment3
{
    public interface IEmailService { void SendConfirmationEmail(string customerEmail); }
    public interface IInventoryService { void UpdateInventory(string product, int quantity); }
    public interface IPaymentService { void ChargeCustomer(string customerName, decimal amount); }
    public class EmailService : IEmailService { public void SendConfirmationEmail(string customerEmail) { Console.WriteLine($"Email sent to {customerEmail}"); } }
    public class InventoryService : IInventoryService { public void UpdateInventory(string product, int quantity) { Console.WriteLine($"Inventory updated for {product}, quantity reduced by {quantity}"); } }
    public class PaymentService : IPaymentService { public void ChargeCustomer(string customerName, decimal amount) { Console.WriteLine($"Charged {customerName} amount: {amount}"); } }
    public class OrderService {
        private IEmailService _e; private IInventoryService _i; private IPaymentService _p;
        public OrderService(IEmailService e, IInventoryService i, IPaymentService p) { _e=e; _i=i; _p=p; }
        public void ProcessOrder(string n, string em, string pr, int q, decimal price) { _p.ChargeCustomer(n, price*q); _i.UpdateInventory(pr, q); _e.SendConfirmationEmail(em); Console.WriteLine("Order processed successfully."); }
    }
    public class Program { public static void Main(string[] args) { var e=new EmailService(); var i=new InventoryService(); var p=new PaymentService(); new OrderService(e,i,p).ProcessOrder("Alan","alan@macewan.ca","Laptop",1,999.99m); } }
}
