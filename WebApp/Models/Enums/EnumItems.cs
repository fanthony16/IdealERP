using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models.Enums
{
    public class EnumItems
    {
        public enum Registration_Stage
        {

            Active = 1,
            Suspended = 2,
            Trial = 3

        }

        public enum Income_Balance
        {

            Income_Statement = 1,
            Balance_Sheet = 2
            
        }

        public enum Account_Category
        {

            Asset = 1,
            Liabilities = 2,
            Equity = 3,
            Income = 4,
            Cost_of_Goods_Sold = 5,
            Expence = 6

        }

        public enum Debit_Credit
        {

            Both = 1,
            Debit = 2,
            Credit = 3
            
        }

        public enum Account_Type
        {

            Posting = 1,
            Heading = 2,
            Total = 3,
            Begin_Total = 4,
            End_Total = 5

        }

        public enum General_Posting_Type
        {

            Purchase = 1,
            Sale = 2,
            Settlement = 3
            
        }

    }
}
