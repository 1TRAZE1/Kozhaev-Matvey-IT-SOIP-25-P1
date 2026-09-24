using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozhaev_Matvey_IT_SOIP_25_P1
{
    abstract class Delivery
    {
        protected string name;
        protected decimal price;
        public Delivery(string name)
        {
            Name = name;
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length <= 20)
                {
                    name = value;
                }
                else
                {
                    Console.WriteLine("Ошибка! имя не может быть пустым и должно быть не длинее 20 символов");
                    name = "Неизвестно";
                }
            }
        }
        public decimal Price
        {
            get { return price; }
        }
        public abstract void CalculatePrice(decimal basePrice);
        public override string ToString()
        {
            return $"Доставка: {Name} - Стоимость: {Price} рублей";
        }
    }
    class StandardDelivery : Delivery
    {
        public StandardDelivery(string name) : base(name)
        {
        }
        public override void CalculatePrice(decimal basePrice)
        {
            price = basePrice * 1.0m;
        }
    }
    class ExpressDelivery : Delivery
    {
        public ExpressDelivery(string name) : base(name)
        {
        }
        public override void CalculatePrice(decimal basePrice)
        {
            price = basePrice * 2.5m;
        }
    }
    class InternationalDelivery : Delivery
    {
        public InternationalDelivery(string name) : base(name)
        {
        }
        public override void CalculatePrice(decimal basePrice)
        {
            price = basePrice * 4.0m;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal basePrice = 20m;
            Delivery standard = new StandardDelivery("Стандартная");
            Delivery express = new ExpressDelivery("Экспресс");
            Delivery international = new InternationalDelivery("Международная");
            standard.CalculatePrice(basePrice);
            express.CalculatePrice(basePrice);
            international.CalculatePrice(basePrice);
            Console.WriteLine("Информация о доставках");
            Console.WriteLine(standard);
            Console.WriteLine(express);
            Console.WriteLine(international);
            Console.ReadKey();
        }
    }
}

