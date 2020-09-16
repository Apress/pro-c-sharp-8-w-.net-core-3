using System;

namespace FunWithEnums
{
    enum EmpTypeEnum : byte
    {
        Manager = 10,
        Grunt = 1,
        Contractor = 100,
        VicePresident = 9
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Fun with Enums *****\n");
            EmpTypeEnum e2 = EmpTypeEnum.Contractor;

            // These types are enums in the System namespace.
            DayOfWeek day = DayOfWeek.Monday;
            ConsoleColor cc = ConsoleColor.Gray;

            EvaluateEnum(e2);
            EvaluateEnum(day);
            EvaluateEnum(cc);

            Enum.Format(typeof(EmpTypeEnum), e2, "x");
            Console.ReadLine();
        }

        #region Enum as parameter
        // Enums as parameters.
        static void AskForBonus(EmpTypeEnum e)
        {
            switch (e)
            {
                case EmpTypeEnum.Manager:
                    Console.WriteLine("How about stock options instead?");
                    break;
                case EmpTypeEnum.Grunt:
                    Console.WriteLine("You have got to be kidding...");
                    break;
                case EmpTypeEnum.Contractor:
                    Console.WriteLine("You already get enough cash...");
                    break;
                case EmpTypeEnum.VicePresident:
                    Console.WriteLine("VERY GOOD, Sir!");
                    break;
            }
        }
        #endregion

        #region Just a test.  Uncomment to verify.
        static void ThisMethodWillNotCompile()
        {
            //// Error! SalesManager is not in the EmpType enum!
            //EmpType emp = EmpType.SalesManager;

            //// Error! Forgot to scope Grunt value to EmpType enum!
            //emp = Grunt;
        }
        #endregion

        #region Examine enum!
        // This method will print out the details of any enum.
        static void EvaluateEnum(System.Enum e)
        {
            Console.WriteLine("=> Information about {0}", e.GetType().Name);

            Console.WriteLine("Underlying storage type: {0}",
                Enum.GetUnderlyingType(e.GetType()));

            // Get all name/value pairs for incoming parameter.
            Array enumData = Enum.GetValues(e.GetType());
            Console.WriteLine("This enum has {0} members.", enumData.Length);

            // Now show the string name and associated value.
            for (int i = 0; i < enumData.Length; i++)
            {
                Console.WriteLine("Name: {0}, Value: {0:D}",
                    enumData.GetValue(i));
            }
            Console.WriteLine();
        }
        #endregion

    }
}
