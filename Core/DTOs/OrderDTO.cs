using Core.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs;

public class OrderDTO
{
    public int Id { get; set; }
    [Required(ErrorMessage = "CustomerId is required.")]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    [Required(ErrorMessage = "OrderId is required.")]
    public int OrderItemId { get; set; }
    public OrderItem OrderItem { get; set; }
    public DateTime OrderDate { get; set; }
    [Required(ErrorMessage = "Status is required.")]
    public string Status { get; set; }

}

