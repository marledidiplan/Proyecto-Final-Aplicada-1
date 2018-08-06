using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Balance
    {
        [Key]
        public int BalanceId { get; set; }
        public int Monto { get; set; }

        public Balance()
        {
            BalanceId = 0;
            Monto = 0;
        }
    }
}
