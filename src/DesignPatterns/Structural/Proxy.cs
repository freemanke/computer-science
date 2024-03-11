namespace DesignPatterns.Structural;

public interface IOrderService
{
    void AddItem(string item);
    List<string> GetItems();
}

public class OrderService: IOrderService
{
    public readonly List<string> Items = [];

    public void AddItem(string item)
    {
        
        Items.Add(item);
    }

    public List<string> GetItems()
    {
        return Items;
    }
}

public class OrderServiceProxy : IOrderService
{
    private readonly IOrderService orderService;

    public OrderServiceProxy(IOrderService orderService)
    {
        this.orderService = orderService;
    }

    public void AddItem(string item)
    {
        if (CheckAmount())
            orderService.AddItem(item);
    }

    public List<string> GetItems()
    {
        return orderService.GetItems();
    }

    public bool CheckAmount()
    {
        if (GetItems().Count >= 2)
        {
            Console.WriteLine("已订购商品超过2件，不允许继续购买");
            return false;
        }

        return true;
    }
}