using System;

class User{

    private string last;
    private string first;
    private int id;

    public User(int userId ,string firstName, string lastName)
    {
        id = userId;
        last = lastName;
        first = firstName;
    }

    public int getUserId()
    {
        return id;
    }

    public string getUserFirstName()
    {
        return first;
    }
     
    public string getUserLastName()
    {
        return last;
    }

}

class Order
{
    private int price; 
    private int amount; 
    private string name; 
    public Order( int productPrice, int productAmoubt, string productName)
    {
        price = productPrice;
        amount = productAmoubt;
        name = productName;
    }

    public int getOrderId()
    {
        Random x = new Random();
        int orderId = x.Next(1, 100);

        return orderId;
    }

    public int productPrice()
    {
        return price;
    }

    public int productAmount()
    {
        return amount;
    }

    public string productName()
    {
        return name;
    }
}

interface Provider
{
    void pay(int orderId, string orderName, int orderPrice);
}

class PayeerProvider : Provider
{
    private int app_id;
    private string app_key;
    private string app_url;

    public PayeerProvider(int appId, string appKey, string appUrl)
    {
        if (appId == null)
            throw new Exception("appId is required!");

        if (appKey == null)
            throw new Exception("appKey id is required!");

        if (appUrl == null)
            throw new Exception("appKey appUrl is required!");

        app_id = appId;
        app_key = appKey;
        app_url = appUrl;
    }

    public void pay(int orderId, string orderName, int orderPrice)
    {
        //выполняем пост запрос через какой момент не знаю пока что)
        var error = false;// так как не знаю как API работает ставлю также заглушку
        
        if (error != true)
        {
            //и выводим лог
            Console.WriteLine("Произведена покупка заказа - " + orderId + ", " + "(" + orderName + ")" + ", " + "стоимостью " + orderPrice + ") методом Payeer");
        }
        
    }
}

namespace ConsoleBillingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var user1 = new User(21, "Дмитрий", "Гончаров");
            var order1 = new Order(122, 1, "Вкусное Пивко");
 
            Console.WriteLine("Информация о пользователе: \n");
            Console.WriteLine("id: " + user1.getUserId() + "\n");
            Console.WriteLine("Имя: " + user1.getUserFirstName() + "\n");
            Console.WriteLine("Фамилия: " + user1.getUserLastName() + "\n");
            
            Console.WriteLine("Заказ № : " + order1.getOrderId() + "\n");
            Console.WriteLine("Название товара : " + order1.productName() + "\n");
            Console.WriteLine("Стоимость : " + order1.productPrice() + "\n");
            Console.WriteLine("Количество : " + order1.productAmount() + "\n");


            //Console.Write("Выберите доступнык способы оплаты: \n\n");
            //Console.Write("1 - Payeer \n");
      
            var payeer = new PayeerProvider(1233456, "ABCDEF", "https://mail.ru/");
            payeer.pay(order1.getOrderId(), order1.productName(), order1.productPrice());
        }
    }

}
