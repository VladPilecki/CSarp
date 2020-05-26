using System;
using System.Collections;

namespace lab6
{
    class EC : Student
    {

        public EC() : base()
        {
            GroupNumber = "950506";
            studentMarks.math = 9;
            studentMarks.programming = 9;
            studentMarks.logics = 9;
        }


        public EC(string name, string surname, int age, int math, int programming, int logics) : base(name, surname, age, "Computing Systems and Networks")
        {
            GroupNumber = "950506";
            studentMarks.math = math;
            studentMarks.programming = programming;
            studentMarks.logics = logics;
        }

        public override string ToString()
        {
            return base.ToString() + " Group: " + GroupNumber + ";\n " + "Marks: \n " + "Math - " + studentMarks.math + ";\n" + " Programming - " + studentMarks.programming + ";\n" + " Logics - " + studentMarks.logics + ";\n";
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

    interface IStudent
    {
        float AvMark();
        Level CountLevel();
    }
    class IITP : Student
    {
        public IITP() : base()
        {
            GroupNumber = "953503";
            studentMarks.math = 9;
            studentMarks.programming = 9;
            studentMarks.logics = 9;
        }


        public IITP(string name, string surname, int age, int math, int programming, int logics) : base(name, surname, age, "Informatics")
        {
            GroupNumber = "953503";
            studentMarks.math = math;
            studentMarks.programming = programming;
            studentMarks.logics = logics;
        }

        public override string ToString()
        {
            return base.ToString() + " Group: " + GroupNumber + ";\n " + "Marks: \n " + "Math - " + studentMarks.math + ";\n" + " Programming - " + studentMarks.programming + ";\n" + " Logics - " + studentMarks.logics + ";\n";
        }
    }
    class Program
    {

        static public void SetParametrs(Student st)
        {
            Console.Write("Enter student name: ");
            st.Name = Console.ReadLine();

            Console.Write("Enter student surname: ");
            st.Surname = Console.ReadLine();

            Console.Write("Enter student age: ");
            st.Age = CheckAge();

            Console.Write("Enter student course: ");
            st.Course = (Courses)CheckCourse();

            Console.Write("Enter student group number: ");
            st.GroupNumber = Console.ReadLine();

            Console.Write("Enter marks:\n");
            Console.Write("Math mark: ");
            st.studentMarks.math = CheckInt();

            Console.Write("Programming mark: ");
            st.studentMarks.programming = CheckInt();

            Console.Write("Logics mark: ");
            st.studentMarks.logics = CheckInt();

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
            while (!int.TryParse(Console.ReadLine(), out a) || a <= 0 || a > 10)
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

        public static void SetArray(Student[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                int sp;
                Console.Write("Choose your specialty: IITP - 1, SIT - 2, EC - 3\n ");
                while (!int.TryParse(Console.ReadLine(), out sp) || sp < 1 || sp > 3)
                {
                    Console.Write("Wrong input, try again: ");
                }
                switch (sp)
                {
                    case 1:
                        list[i] = new IITP { Specialty = "Informatics" };
                        SetParametrs(list[i]);
                        Console.WriteLine(); break;
                    case 2:
                        list[i] = new SIT { Specialty = "Software for Information Technologies" };
                        SetParametrs(list[i]);
                        Console.WriteLine(); break;
                    case 3:
                        list[i] = new EC { Specialty = "Electronic Computing" };
                        SetParametrs(list[i]);
                        Console.WriteLine(); break;
                }
            }

            Console.WriteLine("List of students:");
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
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


            Student[] list = new Student[2];
            SetArray(list);
            Console.WriteLine();

            if (list[0].CompareTo(list[1]) == 0) Console.WriteLine("Students have the same level of knowledge\n");
            if (list[0].CompareTo(list[1]) == 1) Console.WriteLine("The first student knows more than the second\n");
            if (list[0].CompareTo(list[1]) == -1) Console.WriteLine("The first student knows less than the second\n");

            Console.WriteLine("Copy of the first student: ");
            Student st1 = (Student)list[0].Clone();
            Console.WriteLine(st1);

            Console.WriteLine("Copy of the second student:");
            Student st2 = (Student)list[1].Clone();
            Console.WriteLine(st2);

            foreach (Student s in list)
            {
                Console.WriteLine($"{s.Name}  {s.Surname} - Level: {s.CountLevel()}");
            }

            Human.Show();
            Console.WriteLine();

            Console.ReadKey();
        }
    }
    class SIT : Student
    {

        public SIT() : base()
        {
            GroupNumber = "951001";
            studentMarks.math = 9;
            studentMarks.programming = 9;
            studentMarks.logics = 9;
        }


        public SIT(string name, string surname, int age, int math, int programming, int logics) : base(name, surname, age, "Software for Information Technologies")
        {
            GroupNumber = "951001";
            studentMarks.math = math;
            studentMarks.programming = programming;
            studentMarks.logics = logics;
        }

        public override string ToString()
        {
            return base.ToString() + " Group: " + GroupNumber + ";\n " + "Marks: \n " + "Math - " + studentMarks.math + ";\n" + " Programming - " + studentMarks.programming + ";\n" + " Logics - " + studentMarks.logics + ";\n";
        }

    }
    class Student : Human, IComparable, ICloneable, IStudent
    {
        public string GroupNumber { get; set; }
        public string Specialty { get; set; }
        public Courses Course { get; set; }
        public Level CountLevel()
        {
            int avMark = (int)AvMark();
            switch (avMark)
            {
                case 10:
                case 9:
                    return Level.Ultra;
                case 8:
                case 7:
                    return Level.High;
                case 6:
                case 5:
                case 4:
                    return Level.Mid;
                default:
                    return Level.Low;
            }
        }

        public float AvMark()
        {
            int sum = studentMarks.logics + studentMarks.math + studentMarks.programming;
            if (sum == 0)
                throw new Exception("There are no marks");
            return (float)sum / 3;
        }

        public int CompareTo(object obj)
        {
            if (this.Programming > ((Student)obj).Programming)
            {
                return 1;
            }
            if (this.Programming < ((Student)obj).Programming)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public object Clone()
        {
            return (Student)this.MemberwiseClone();
        }

        public Marks studentMarks;

        public int Math
        {
            get { return studentMarks.math; }
            protected set { studentMarks.math = value; }
        }

        public int Programming
        {
            get { return studentMarks.programming; }
            protected set { studentMarks.programming = value; }
        }

        public int Logics
        {
            get { return studentMarks.logics; }
            protected set { studentMarks.logics = value; }
        }
        public bool Equals(Student other)
        {
            if (other != null && this.Course == other.Course)
                return true;
            else
                return false;
        }

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
    struct Marks
    {
        public int math;
        public int programming;
        public int logics;
    }
    public enum Courses
    {
        first = 1,
        second,
        third,
        fourth
    }
    enum Level { Low, Mid, High, Ultra }
}