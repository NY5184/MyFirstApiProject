using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record OrderDTO(
        int OrderId = 0,
        int UserId = 0,
        DateTime? OrderDate = null,
        int OrderSum = 0,
        string UserName = "",
        List<OrderItemDTO>? Items = null
    );
}
