using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApp
{
    public enum EmployeePayTypeEnum
    {
        Hourly,
        Salaried,
        Commission
    }
    class Employee
    {

        // Field data.
        private string _empName;
        private int _empId;
        private float _currPay;
        private int _empAge;
        private string _empSSN;
        private EmployeePayTypeEnum _payType;

        // Properties!
        public string Name
        {
            get { return _empName; }
            set
            {
                if (value.Length > 15)
                {
                    Console.WriteLine("Error! Name length exceeds 15 characters!");
                }
                else
                {
                    _empName = value;
                }
            }
        }

        // We could add additional business rules to the sets of these properties;
        // however, there is no need to do so for this example.
        public int Id
        {
            get { return _empId; }
            set { _empId = value; }
        }
        public float Pay
        {
            get { return _currPay; }
            set { _currPay = value; }
        }

        public int Age
        {
            get => _empAge;
            set => _empAge = value;
        }

        public EmployeePayTypeEnum PayType
        {
            get => _payType;
            set => _payType = value;
        }
        //public string SocialSecurityNumber => _empSSN;
        public string SocialSecurityNumber
        {
            get => _empSSN;
            private set => _empSSN = value;
        }

        // Constructors.
        public Employee()
        {

        }
        public Employee(string name, int id, float pay, string empSsn) : this(name,0,id,pay, empSsn, EmployeePayTypeEnum.Salaried)
        {
        }
        //public Employee(string name, int age, int id, float pay)
        //{
        //    _empName = name;
        //    _empId = id;
        //    _empAge = age;
        //    _currPay = pay;
        //}
        public Employee(string name, int age, int id, 
            float pay, string empSsn, EmployeePayTypeEnum payType)
        {
            Name = name;
            Id = id;
            Age = age;
            Pay = pay;
            //With read only, this format must be used
            //_empSSN = empSsn;
            //With private set and public get, this format can be used
            SocialSecurityNumber = empSsn;
            PayType = payType;
        }

        // Methods.
        //public void GiveBonus(float amount) => Pay += amount;
        public void GiveBonus(float amount)
        {
            Pay = this switch
            {
                {PayType: EmployeePayTypeEnum.Commission } => Pay += .10F * amount,
                {PayType: EmployeePayTypeEnum.Hourly } => Pay += 40F * amount/2080F,
                {PayType: EmployeePayTypeEnum.Salaried } => Pay += amount,
                _ => Pay+=0
            };
            //Pay += amount;
        }

        public void DisplayStats()
        {
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("ID: {0}", Id);
            Console.WriteLine("Age: {0}", Age);
            Console.WriteLine("Pay: {0}", Pay);
        }
        // Accessor (get method).
        public string GetName() => _empName;

        // Mutator (set method).
        public void SetName(string name)
        {
            // Do a check on incoming value
            // before making assignment.
            if (name.Length > 15)
            {
                Console.WriteLine("Error! Name length exceeds 15 characters!");
            }
            else
            {
                _empName = name;
            }
        }

    }
}
