using System;

namespace lab5
{
    class EC : Student
    {
        public string GroupNumber { get; set; }

        Marks mark;

        public EC() : base()
        {
            GroupNumber = "950506";
            mark.Math = 9;
            mark.Programming = 9;
            mark.Logics = 9;
        }


        public EC(string name, string surname, int age, int math, int programming, int logics) : base(name, surname, age, "Computing Systems and Networks")
        {
            GroupNumber = "950506";
            mark.Math = math;
            mark.Programming = programming;
            mark.Logics = logics;
        }

        public override string ToString()
        {
            return base.ToString() + " Group: " + GroupNumber + ";\n " + "Marks: \n " + "Math - " + mark.Math + ";\n" + " Programming - " + mark.Programming + ";\n" + " Logics - " + mark.Logics + ";\n";
        }

        public void SetParametrs()
        {
            Console.Write("Enter student name: ");
            Name = Console.ReadLine();

            Console.Write("Enter student surname: ");
            Surname = Console.ReadLine();

            Console.Write("Enter student age: ");
            Age = CheckAge();

            Console.Write("Enter student course: ");
            Course = (Courses)CheckCourse();

            Console.Write("Enter student group number: ");
            GroupNumber = Console.ReadLine();

            Console.Write("Enter student marks:\n");
            Console.Write("Math mark: ");
            mark.Math = CheckInt();

            Console.Write("Programming mark: ");
            mark.Programming = CheckInt();

            Console.Write("Logics mark: ");
            mark.Logics = CheckInt();

        }

        public static int CheckCourse()
        {
            int course;
            while (!int.TryParse(Console.ReadLine(), out course) || course < 1 || course > 4)
            {
                Console.Write("Wrong input, try again: ");
            }

            return course;
        }

        public static int CheckAge()
        {
            int age;
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.Write("Wrong input, try again: ");
            }

            return age;
        }

        public static int CheckInt()
        {
            int a;
            while (!int.TryParse(Console.ReadLine(), out a) || a <= 0)
            {
                Console.Write("Wrong input, try again: ");
            }

            return a;
        }

        public static double CheckDouble()
        {
            double a;
            while (!double.TryParse(Console.ReadLine(), out a) || a <= 0)
            {
                Console.Write("Wrong input, try again: ");
            }

            return a;
        }
    }
    abstract class Human
    {
        protected int age;

        static private int population = 0;

        protected string[] family;

        public string Name { get; set; }
        public string Surname { get; set; }


        public int Age
        {
            get { return age; }
            set { age = value > 0 ? value : 0; }
        }

        public Human()
        {
            Name = "Vladislav";
            Surname = "Piletskiy";
            age = 17;
            population++;
        }
        public Human(string name, string surname, int a)
        {
            Name = name;
            Surname = surname;
            age = a;
            population++;
        }
        public override string ToString()
        {
            string info = " Name: " + Name + ";" + " Surname: " + Surname + " Age: " + age + ";";
            return info;

        }


        public void Increase(int a)
        {
            age += a;
        }


        public static void Show()
        {
            Console.WriteLine(" The population is: " + population);
        }

        public Human(int n)
        {
            family = new string[n];
        }

        public string this[int n]
        {
            get
            {
                return family[n];
            }

            set
            {
                family[n] = value;
            }
        }
    }
    class IITP : Student
    {
        public string GroupNumber { get; set; }

        Marks mark;


        public IITP() : base()
        {
            GroupNumber = "953503";
            mark.Math = 9;
            mark.Programming = 9;
            mark.Logics = 9;
        }


        public IITP(string name, string surname, int age, int math, int programming, int logics) : base(name, surname, age, "Informatics")
        {
            GroupNumber = "953503";
            mark.Math = math;
            mark.Programming = programming;
            mark.Logics = logics;
        }

        public override string ToString()
        {
            return base.ToString() + " Group: " + GroupNumber + ";\n " + "Marks: \n " + "Math - " + mark.Math + ";\n" + " Programming - " + mark.Programming + ";\n" + " Logics - " + mark.Logics + ";\n";
        }


        public void SetParametrs()
        {
            Console.Write("Enter student name: ");
            Name = Console.ReadLine();

            Console.Write("Enter student surname: ");
            Surname = Console.ReadLine();

            Console.Write("Enter student age: ");
            Age = CheckAge();

            Console.Write("Enter student course: ");
            Course = (Courses)CheckCourse();

            Console.Write("Enter student group number: ");
            GroupNumber = Console.ReadLine();

            Console.Write("Enter student marks:\n");
            Console.Write("Math mark: ");
            mark.Math = CheckInt();

            Console.Write("Programming mark: ");
            mark.Programming = CheckInt();

            Console.Write("Logics mark: ");
            mark.Logics = CheckInt();

        }

        public static int CheckCourse()
        {
            int course;
            while (!int.TryParse(Console.ReadLine(), out course) || course < 1 || course > 4)
            {
                Console.Write("Wrong input, try again: ");
            }

            return course;
        }

        public static int CheckAge()
        {
            int age;
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.Write("Wrong input, try again: ");
            }

            return age;
        }

        public static int CheckInt()
        {
            int a;
            while (!int.TryParse(Console.ReadLine(), out a) || a <= 0)
            {
                Console.Write("Wrong input, try again: ");
            }

            return a;
        }

        public static double CheckDouble()
        {
            double a;
            while (!double.TryParse(Console.ReadLine(), out a) || a <= 0)
            {
                Console.Write("Wrong input, try again: ");
            }

            return a;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Human.Show();
            Console.WriteLine();

            Student studentOne = new Student("Vladislav", "Piletskiy", 17, "IITP");
            Console.WriteLine(studentOne);
            Console.WriteLine();

            IITP informaticStudent = new IITP("Vladislav", "Piletskiy", 17, 9, 9, 9);
            Console.WriteLine(informaticStudent);

            SIT softwareStudent = new SIT("Andrew", "Oleshkevich", 18, 10, 10, 9);
            Console.WriteLine(softwareStudent);

            EC computingStudent = new EC("Alexey", "Dilevskiy", 17, 9, 10, 9);
            Console.WriteLine(computingStudent);

            Human.Show();
            Console.WriteLine();


            int sp;
            Console.Write("Choose your specialty: IITP - 1, SIT - 2, EC - 3\n ");
            while (!int.TryParse(Console.ReadLine(), out sp) || sp < 1 || sp > 3)
            {
                Console.Write("Wrong input, try again: ");
            }
            switch (sp)
            {
                case 1:
                    IITP informaticStudentOne = new IITP();
                    informaticStudentOne.SetParametrs();
                    Console.WriteLine();
                    Console.WriteLine(informaticStudentOne); break;
                case 2:
                    SIT softwareStudentOne = new SIT();
                    softwareStudentOne.SetParametrs();
                    Console.WriteLine();
                    Console.WriteLine(softwareStudentOne); break;
                case 3:
                    EC computingStudentOne = new EC();
                    computingStudentOne.SetParametrs();
                    Console.WriteLine();
                    Console.WriteLine(computingStudentOne); break;
            }


            Human.Show();
            Console.WriteLine();

            Console.ReadKey();
        }
    }
    class SIT : Student
    {
        public string GroupNumber { get; set; }

        Marks mark;


        public SIT() : base()
        {
            GroupNumber = "951001";
            mark.Math = 9;
            mark.Programming = 9;
            mark.Logics = 9;
        }


        public SIT(string name, string surname, int age, int math, int programming, int logics) : base(name, surname, age, "Software for Information Technologies")
        {
            GroupNumber = "951001";
            mark.Math = math;
            mark.Programming = programming;
            mark.Logics = logics;
        }

        public override string ToString()
        {
            return base.ToString() + " Group: " + GroupNumber + ";\n " + "Marks: \n " + "Math - " + mark.Math + ";\n" + " Programming - " + mark.Programming + ";\n" + " Logics - " + mark.Logics + ";\n";
        }

        public void SetParametrs()
        {
            Console.Write("Enter student name: ");
            Name = Console.ReadLine();

            Console.Write("Enter student surname: ");
            Surname = Console.ReadLine();

            Console.Write("Enter student age: ");
            Age = CheckAge();

            Console.Write("Enter student course: ");
            Course = (Courses)CheckCourse();

            Console.Write("Enter student group number: ");
            GroupNumber = Console.ReadLine();

            Console.Write("Enter student marks:\n");
            Console.Write("Math mark: ");
            mark.Math = CheckInt();

            Console.Write("Programming mark: ");
            mark.Programming = CheckInt();

            Console.Write("Logics mark: ");
            mark.Logics = CheckInt();

        }

        public static int CheckCourse()
        {
            int course;
            while (!int.TryParse(Console.ReadLine(), out course) || course < 1 || course > 4)
            {
                Console.Write("Wrong input, try again: ");
            }

            return course;
        }

        public static int CheckAge()
        {
            int age;
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.Write("Wrong input, try again: ");
            }

            return age;
        }

        public static int CheckInt()
        {
            int a;
            while (!int.TryParse(Console.ReadLine(), out a) || a <= 0)
            {
                Console.Write("Wrong input, try again: ");
            }

            return a;
        }

        public static double CheckDouble()
        {
            double a;
            while (!double.TryParse(Console.ReadLine(), out a) || a <= 0)
            {
                Console.Write("Wrong input, try again: ");
            }

            return a;
        }
    }
    class Student : Human
    {
        public string Specialty { get; set; }
        public enum Courses
        {
            first = 1,
            second,
            third,
            fourth
        }
        public Courses Course { get; set; }


        public Student(string name, string surname, int age, string specialty) : base(name, surname, age)
        {
            Course = Courses.first;
            Specialty = specialty;
        }

        public Student() : base()
        {
            Course = Courses.second;
            Specialty = "IITP";
        }

        public override string ToString()
        {
            return base.ToString() + "\n Course: " + Course + ";" + "\n Specialty: " + Specialty + ";";
        }
    }

    public struct Marks
    {
        public int Math { get; set; }
        public int Programming { get; set; }
        public int Logics { get; set; }

    }
}