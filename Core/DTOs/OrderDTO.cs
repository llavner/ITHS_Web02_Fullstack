using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs;

public class OrderDTO
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int OrderDetailId { get; set; }
    public OrderItem OrderDetail { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; }

}

