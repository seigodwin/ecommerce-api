using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Enums
{
    public enum OrderStatus
    {
        Pending = 1,
        Processing = 2,
        Shipped = 3,
        Delivered = 4,
        Cancelled = 5,
        Returned = 6,
    }
   
}
