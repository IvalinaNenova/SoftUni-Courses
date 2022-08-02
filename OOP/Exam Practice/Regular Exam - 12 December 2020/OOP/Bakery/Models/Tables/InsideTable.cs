using System;
using System.Collections.Generic;
using System.Text;
using Bakery.Utilities.Enums;

namespace Bakery.Models.Tables
{
    public class InsideTable : Table
    {
        private const decimal InitialPricePerPerson = 2.50m;
        private TableType type;
        public InsideTable(int tableNumber, int capacity) 
            : base(tableNumber, capacity, InitialPricePerPerson)
        {
            type = TableType.InsideTable;
        }
    }
}
