using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int OrderItemId { get; set; }
    public OrderItem OrderItem { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; }
}

