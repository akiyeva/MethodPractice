using System;

namespace MethodPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Do you want to add a new employee? Y/N");

                string addEmployeeValidation = ToLower(Console.ReadLine());
                if (addEmployeeValidation == "n" || addEmployeeValidation == "no")
                {
                    Console.WriteLine("Program terminates");
                    break;
                }
                else if (addEmployeeValidation == "y" || addEmployeeValidation == "yes")
                {
                    AddEmployee();
                }
                else
                {
                    Console.WriteLine("Please enter YES or NO (Y/N)");
                    continue;
                }
            }
        }

        public static void AddEmployee()
        {
            string firstName;
            string lastName;
            string fatherName;
            int age;
            string finCode;
            string phoneNumber;
            string position;
            decimal salary;

            while (true)
            {
                while (true)
                {
                    Console.WriteLine("Enter first name: ");
                    firstName = Console.ReadLine();
                    if (!CheckFirstName(firstName))
                    {
                        Console.WriteLine("The length of the first name should be between 2 and 20 characters, and it should only contain letters. The first letter must be uppercase.");
                    }
                    else
                        break;
                }

                while (true)
                {
                    Console.WriteLine("Enter last name: ");
                    lastName = Console.ReadLine();
                    if (!CheckLastName(lastName))
                    {
                        Console.WriteLine("The length of the last name should be between 2 and 35 characters, and it should only contain letters. The first letter must be uppercase.");
                    }
                    else
                        break;
                }

                while (true)
                {
                    Console.WriteLine("Enter middle name: ");
                    fatherName = Console.ReadLine();
                    if (!CheckFatherName(fatherName))
                    {
                        Console.WriteLine("The length of the middle name should be between 2 and 20 characters, and it should only contain letters. The first letter must be uppercase.");
                    }
                    else
                        break;
                }

                while (true)
                {
                    Console.WriteLine("Enter age: ");
                    if (!int.TryParse(Console.ReadLine(), out age) || !CheckAge(age))
                    {
                        Console.WriteLine("Age should be between 18 and 65.");
                    }
                    else
                        break;
                }

                while (true)
                {
                    Console.WriteLine("Enter FIN: ");
                    finCode = Console.ReadLine();
                    if (!CheckFIN(finCode))
                    {
                        Console.WriteLine("The length of the FIN should be 7 characters, and it should only contain uppercase letters and numbers.");
                    }
                    else
                        break;
                }

                while (true)
                {
                    Console.WriteLine("Enter phone number: ");
                    phoneNumber = Console.ReadLine();
                    if (!CheckPhoneNumber(phoneNumber))
                    {
                        Console.WriteLine("The phone number should start with +994 and its total length should be 13 characters.");
                    }
                    else
                        break;
                }

                while (true)
                {
                    Console.WriteLine("Enter position: ");
                    position = ToUpper(Console.ReadLine());
                    if (!CheckPosition(position))
                    {
                        Console.WriteLine("The position can only be HR, Audit, or Engineer.");
                    }
                    else
                        break;
                }

                while (true)
                {
                    Console.WriteLine("Enter salary: ");
                    if (!decimal.TryParse(Console.ReadLine(), out salary) || !CheckSalary(salary))
                    {
                        Console.WriteLine("The salary should be between 1500 and 5000.");
                    }
                    else
                        break;
                }

                Console.WriteLine($"Data ({firstName}, {lastName}) added to the system.");
                break;
            }
        }


        public static bool CheckFirstName(string firstName)
        {
            return firstName.Length >= 2
                && firstName.Length <= 20
                && char.IsUpper(firstName[0])
                && AreAllLetters(firstName);
        }

        public static bool CheckLastName(string lastName)
        {
            return lastName.Length >= 2
                && lastName.Length <= 35
                && char.IsUpper(lastName[0])
                && AreAllLetters(lastName);
        }

        public static bool CheckFatherName(string fatherName)
        {
            return fatherName.Length >= 2
                && fatherName.Length <= 20
                && char.IsUpper(fatherName[0])
                && AreAllLetters(fatherName);
        }

        public static bool CheckAge(int age)
        {
            return age >= 18 && age <= 65;
        }

        public static bool CheckFIN(string fin)
        {
            if (fin.Length != 7)
                return false;
            foreach (char c in fin)
            {
                if (!char.IsUpper(c) && !char.IsDigit(c)) return false;
            }
            return true;
        }

        public static bool CheckPhoneNumber(string phoneNumber)
        {
            return phoneNumber.Length == 13
                && phoneNumber.StartsWith("+994")
                && AreAllDigits(phoneNumber.Substring(4));
        }

        public static bool CheckPosition(string position)
        {
            return position == "HR" || position == "Audit" || position == "Engineer";
        }

        public static bool CheckSalary(decimal salary)
        {
            return salary >= 1500 && salary <= 5000;
        }

        public static bool AreAllLetters(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsLetter(c))
                    return false;
            }
            return true;
        }

        public static bool AreAllDigits(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        public static string ToLower(string str)
        {
            string result = "";
            foreach (char c in str)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    result += (char)(c + 32);
                }
                else
                {
                    result += c;
                }
            }
            return result;
        }

        public static string ToUpper(string str)
        {
            string result = "";
            foreach (char c in str)
            {
                if (c >= 'a' && c <= 'z')
                {
                    result += (char)(c - 'a' + 'A');
                }
                else
                {
                    result += c;
                }
            }
            return result;
        }
    }
}

