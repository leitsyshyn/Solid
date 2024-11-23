using System;
using System.Collections.Generic;
using System.Text;

interface IPriceable
{
    void SetPrice(double price);
    double GetPrice();
}

interface IDiscountable
{
    void ApplyDiscount(string discount);
    void ApplyPromocode(string promocode);
}

interface IClothingAttributes
{
    void SetColor(string hexColor);
    string GetColor();
    void SetSize(byte size);
    byte GetSize();
}

class Book : IPriceable, IDiscountable
{
    private double _price;
    private readonly Dictionary<string, string> _promocodeDiscounts = new Dictionary<string, string>
    {
        { "KUBIK2024", "15%" },
        { "READMORE", "10%" }
    };

    public void SetPrice(double price)
    {
        _price = price;
        Console.WriteLine($"Ціну книги встановлено: {price} грн.");
    }

    public double GetPrice()
    {
        return _price;
    }

    public void ApplyDiscount(string discount)
    {
        if (double.TryParse(discount.TrimEnd('%'), out double discountValue))
        {
            _price -= _price * discountValue / 100;
            Console.WriteLine($"Знижка {discount} застосована. Нова ціна книги: {_price} грн.");
        }
        else
        {
            Console.WriteLine("Невірний формат знижки.");
        }
    }

    public void ApplyPromocode(string promocode)
    {
        if (_promocodeDiscounts.TryGetValue(promocode, out string discount))
        {
            Console.WriteLine($"Промокод '{promocode}' застосовано.");
            ApplyDiscount(discount);
        }
        else
        {
            Console.WriteLine($"Промокод '{promocode}' недійсний.");
        }
    }
}

class Outerwear : IPriceable, IDiscountable, IClothingAttributes
{
    private double _price;
    private string _color;
    private byte _size;
    private readonly Dictionary<string, string> _promocodeDiscounts = new Dictionary<string, string>
    {
        { "SNOWY2024", "20%" },
        { "KNUBEST", "15%" }
    };

    public void SetPrice(double price)
    {
        _price = price;
        Console.WriteLine($"Ціну верхнього одягу встановлено: {price} грн.");
    }

    public double GetPrice()
    {
        return _price;
    }

    public void ApplyDiscount(string discount)
    {
        if (double.TryParse(discount.TrimEnd('%'), out double discountValue))
        {
            _price -= _price * discountValue / 100;
            Console.WriteLine($"Знижка {discount} застосована. Нова ціна одягу: {_price} грн.");
        }
        else
        {
            Console.WriteLine("Невірний формат знижки.");
        }
    }

    public void ApplyPromocode(string promocode)
    {
        if (_promocodeDiscounts.TryGetValue(promocode, out string discount))
        {
            Console.WriteLine($"Промокод '{promocode}' застосовано.");
            ApplyDiscount(discount);
        }
        else
        {
            Console.WriteLine($"Промокод '{promocode}' недійсний.");
        }
    }

    public void SetColor(string hexColor)
    {
        _color = hexColor;
        Console.WriteLine($"Колір верхнього одягу встановлено: {hexColor}");
    }

    public string GetColor()
    {
        return _color;
    }

    public void SetSize(byte size)
    {
        _size = size;
        Console.WriteLine($"Розмір верхнього одягу встановлено: {size}");
    }

    public byte GetSize()
    {
        return _size;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Book book = new Book();
        book.SetPrice(299.99);
        book.ApplyDiscount("10%");
        book.ApplyPromocode("KUBIK2024");
        Console.WriteLine($"Ціна книги після промокоду: {book.GetPrice()} грн.\n");

        Outerwear coat = new Outerwear();
        coat.SetPrice(1599.99);
        coat.ApplyPromocode("KNUBEST");
        coat.SetColor("#FF5733");
        coat.SetSize(50);
        Console.WriteLine($"Ціна верхнього одягу після промокоду: {coat.GetPrice()} грн.");
        Console.WriteLine($"Колір: {coat.GetColor()}, Розмір: {coat.GetSize()}");

        Console.ReadKey();
    }
}
