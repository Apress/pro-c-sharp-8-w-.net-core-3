using System;
using System.Collections.Generic;
using System.Text;

namespace Employees
{
    sealed class PtSalesPerson : SalesPerson
    {
        public PtSalesPerson(string fullName, int age, int empId,
            float currPay, string ssn, int numbOfSales)
            : base(fullName, age, empId, currPay, ssn, numbOfSales)
        {
        }

    }
}