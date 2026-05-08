public class WarehouseService : IWarehouseService
{
    public string FormatItem(WarehouseItem item)
    {
        return $"{item.Name}: {item.Quantity} шт. по {item.Price} руб.";
    }
}




