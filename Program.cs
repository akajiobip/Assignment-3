using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public interface IEmailService
    {
        void SendConfirmationEmail(string customerEmail);
    }

    public interface IInventoryService
    {
        void UpdateInventory(string product, int quantity);
    }

    public interface IPaymentService
    {
        void ChargeCustomer(string customerName, decimal amount);
    }

    public class EmailService : IEmailService
    {
        public void SendConfirmationEmail(string customerEmail)
        {
            Console.WriteLine($"Email sent to {customerEmail}");
        }
    }

    public class InventoryService : IInventoryService
    {
        public void UpdateInventory(string product, int quantity)
        {
            Console.WriteLine($"Inventory updated for {product}, quantity reduced by {quantity}");
        }
    }

    public class PaymentService : IPaymentService
    {
        public void ChargeCustomer(string customerName, decimal amount)
        {
            Console.WriteLine($"Charged {customerName} amount: {amount}");
        }
    }

    public class OrderService
    {
        private IEmailService _emailService;
        private IInventoryService _inventoryService;
        private IPaymentService _paymentService;

        public OrderService(IEmailService emailService, IInventoryService inventoryService, IPaymentService paymentService)
        {
            _emailService = emailService;
            _inventoryService = inventoryService;
            _paymentService = paymentService;
        }

        public void ProcessOrder(string customerName, string customerEmail, string product, int quantity, decimal price)
        {
            _paymentService.ChargeCustomer(customerName, price * quantity);
            _inventoryService.UpdateInventory(product, quantity);
            _emailService.SendConfirmationEmail(customerEmail);
            Console.WriteLine("Order processed successfully.");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            IEmailService emailService = new EmailService();
            IInventoryService inventoryService = new InventoryService();
            IPaymentService paymentService = new PaymentService();

            OrderService orderService = new OrderService(emailService, inventoryService, paymentService);
            orderService.ProcessOrder("Alan", "alan@macewan.ca", "Laptop", 1, 999.99m);
        }
    }
}
