using System;
using System.Collections.Generic;
using System.Text;
using Bakery.Utilities.Enums;

namespace Bakery.Models.Tables
{
    public class OutsideTable  : Table
    {
        private const decimal InitialPricePerPerson = 3.50m;
        private TableType type;

        public OutsideTable(int tableNumber, int capacity) 
            : base(tableNumber, capacity, InitialPricePerPerson)
        {
            type = TableType.OutsideTable;
        }
    }
}
