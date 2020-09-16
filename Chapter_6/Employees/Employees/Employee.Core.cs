using System;

namespace Employees
{
    partial class Employee
    {
        // Field data.
        protected string EmpName;
        protected int EmpId;
        protected float CurrPay;
        protected int EmpAge;
        protected string EmpSsn;
        protected EmployeePayTypeEnum EmpPayType;
        protected BenefitPackage EmpBenefits = new BenefitPackage();

        // Properties!
        // Expose object through a custom property.
        public BenefitPackage Benefits
        {
            get { return EmpBenefits; }
            set { EmpBenefits = value; }
        }

        public string Name
        {
            get { return EmpName; }
            set
            {
                if (value.Length > 15)
                {
                    Console.WriteLine("Error! Name length exceeds 15 characters!");
                }
                else
                {
                    EmpName = value;
                }
            }
        }

        // We could add additional business rules to the sets of these properties;
        // however, there is no need to do so for this example.
        public int Id
        {
            get { return EmpId; }
            set { EmpId = value; }
        }
        public float Pay
        {
            get { return CurrPay; }
            set { CurrPay = value; }
        }

        public int Age
        {
            get => EmpAge;
            set => EmpAge = value;
        }

        public EmployeePayTypeEnum PayType
        {
            get => EmpPayType;
            set => EmpPayType = value;
        }
        public string SocialSecurityNumber
        {
            get => EmpSsn;
            private set => EmpSsn = value;
        }

    }
}
