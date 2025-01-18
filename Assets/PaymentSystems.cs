using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Order order = new Order(1, 12000);

        IPaymentSystem system1 = new PaymentSystem1();
        IPaymentSystem system2 = new PaymentSystem2();
        IPaymentSystem system3 = new PaymentSystem3("секретный_ключ");

        Console.WriteLine(system1.GetPayingLink(order));
        Console.WriteLine(system2.GetPayingLink(order));
        Console.WriteLine(system3.GetPayingLink(order));
    }
}

public class Order
{
    public readonly int Id;
    public readonly int Amount;

    public Order(int id, int amount) => (Id, Amount) = (id, amount);
}

public interface IPaymentSystem
{
    public string GetPayingLink(Order order);
}

public class PaymentSystem1 : IPaymentSystem
{
    public string GetPayingLink(Order order)
    {
        string hash = ComputeMd5(order.Id.ToString());
        return $"https://pay.system1.ru/order?amount={order.Amount}RUB&hash={hash}";
    }

    private string ComputeMd5(string input)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
        }
    }
}

public class PaymentSystem2 : IPaymentSystem
{
    public string GetPayingLink(Order order)
    {
        string hash = ComputeMd5(order.Id.ToString() + order.Amount.ToString());
        return $"https://order.system2.ru/pay?hash={hash}";
    }

    private string ComputeMd5(string input)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
        }
    }
}

public class PaymentSystem3 : IPaymentSystem
{
    private readonly string _secretKey;

    public PaymentSystem3(string secretKey)
    {
        _secretKey = secretKey;
    }

    public string GetPayingLink(Order order)
    {
        string hash = ComputeSha1(order.Amount.ToString() + order.Id.ToString() + _secretKey);
        return $"https://system3.com/pay?amount={order.Amount}&currency=RUB&hash={hash}";
    }

    private string ComputeSha1(string input)
    {
        using (SHA1 sha1 = SHA1.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha1.ComputeHash(inputBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
        }
    }
}