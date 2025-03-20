// // Task: Design a secure storage system where data is accessed using indexers. 
// // Implement different access levels for reading and writing data. 
// // The system should enforce proper access control based on the caller’s role.

using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

class StudentData {
    private string _name;
    private string _surname;
    private string _email; 
    private int _age;
    private int _id;
    private int _courselevel;

    public StudentData(string name, string surname, string email, int age, int id, int courselevel) {
        this._name = name;
        this._surname = surname;
        this._email = email;
        this._age = age;
        this._id = id;
        this._courselevel = courselevel;
    }

    public string Name {
        get { return _name; }
        set { _name = value; }
    }

    public string Surname {
        get { return _surname; }
        set { _surname = value; }
    }

    public string Email {
        get { return _email; }
        set { _email = value; }
    }

    public int Age {
        get { return _age; }
        set { _age = value; }
    }

    public int Id {
        get { return _id; }
        set { _id = value; }
    }

    public int Courselevel {
        get { return _courselevel; }
        set { 
                if (value < 0 || value > 5) {
                    throw new ArgumentOutOfRangeException("You are enter wront courselevel value");
                } 
                _courselevel = value; 
            }
    }


    public string SuperficialInformation() {
        return $"Name: {this._name}\nSurname: {this._surname}\nCourselevel: {this._courselevel}";
    }

    public string IndepthInformation() {
        return $"Name: {this._name}\nSurname: {this._surname}\nAge: {this._age}\nCourselevel: {this._courselevel}\nId is: {this._id}\nEmail: {this._email}";
    }
}

class Storage {
    private StudentData[] studentDatas;
    private int count = 0;

    public Storage(int size) {
        studentDatas = new StudentData[size];
    }

    public StudentData Addcontact(string name, string surname, string email, int age, int id, int courselevel) {
        if (count < studentDatas.Length) {
            return new StudentData(name, surname, email, age, id, courselevel);
        } 
        throw new ArgumentException("The index is out of range");
    }

    

    public StudentData this[int index] {
        get {
            if (index < 0 || index > studentDatas.Length) {
                throw new ArgumentOutOfRangeException("Index is out of range");
            }

            return studentDatas[index];
        }

        set {
            if (index < 0 || index > studentDatas.Length) {
                throw new ArgumentOutOfRangeException("Index is out of range");
            }
            studentDatas[index] = value;
        }
    }
}

class Program {
    static void Main(string[] args) {
        const int size  = 5;
        Storage storage = new Storage(size);
        storage[0] = storage.Addcontact("David","Movsesyan","davmovsesyan44@gmail.com",22,181254,4);
        storage[1] = storage.Addcontact("Tigran","Davtyan","tigranbadalyan45@gmail.com",21,181345,3);
        storage[2] = storage.Addcontact("Gagik","Stepanyan","gagikstepanyan46@gmail.com",19,181465,2);
        storage[3] = storage.Addcontact("Vladimir","Grigoryan","vladgrigoryan47@gmail.com",21,181224,4);
        storage[4] = storage.Addcontact("Narek","Avagyan","narekavagyanyan48@gmail.com",21,181254,3);

        ProgramRun(storage, size);
    }

    static void ProgramRun(Storage storage, int size) {
        while (true) {
            Console.Write("Do you want\nReading data::For reading enter read\nWriting data::For writing enter write\nFor Exit::Enter exit\nEnter what do you want?: ");
            string? yourchoice = Console.ReadLine();
            if (string.Compare("Read", yourchoice, true) == 0) {
                ReadingData(storage, size);
            }

            else if (string.Compare("Write", yourchoice, true) == 0) {
                WritingData(storage, size);
            }

            else if (string.Compare("exit", yourchoice,true) == 0) {
                Console.WriteLine("Thanks for our sevices");
                return;
            }
        }

    }
    
    
    public static void ReadingData(Storage obj, int size) {
        while (true) {
            bool flag = false;
            Console.WriteLine("This our Students");
            for (int i = 0; i < size; i++) {
                Console.WriteLine($"Name: {obj[i].Name}\nSurname: {obj[i].Surname}\n");
            }
        
            Console.Write("Which student information do you want: ");
            string? choosename = Console.ReadLine();

            for (int i = 0; i < size; i++) {
                if (string.Compare(choosename,obj[i].Name,true) == 0) {
                    flag = true;
                    while(true) {    

                        Console.Write("which info do you want?\nIn-depth or Superficial information: ");
                        string? infotype = Console.ReadLine();
                        
                        if (string.Compare(infotype,"In-depth",true) == 0) {
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine($"{obj[i].IndepthInformation()}\n");
                            Console.WriteLine("----------------------------------");
                            break;
                        }

                        else if (string.Compare(infotype,"Superficial",true) == 0) {
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine($"{obj[i].SuperficialInformation()}");
                            Console.WriteLine("----------------------------------");
                            break;
                        }

                        else {
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("You enter wrong information choose type try again");
                            Console.WriteLine("----------------------------------");
                        }
                    }
                }
            }
            
            if (flag == false) {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Not this name in Students.Try again.");
                Console.WriteLine("----------------------------------");
                return;
            }
            
            Console.Write("Do you want other student info/yes or no: ");
            string? readexit = Console.ReadLine();
            
            if (string.Compare(readexit,"No",true) == 0) {
                break;
            }

        }
    }


    public static void WritingData(Storage obj, int size) {
        while (true) {
            bool flag = false;
            Console.WriteLine("This our Students");
            for (int i = 0; i < size; i++) {
                Console.WriteLine($"Name: {obj[i].Name}\nSurname: {obj[i].Surname}\n");
            }
        
            Console.Write("Which student information do you want change?: ");
            string? choosename = Console.ReadLine();

            for (int i = 0; i < size; i++) {
                if (string.Compare(choosename,obj[i].Name,true) == 0) {
                    flag = true;
                    while(true) {    

                        Console.Write("which info do you want change?\nEmail:\nAge:\nCourselevel:");
                        string? infotype = Console.ReadLine();

                        if (string.Compare(infotype,"Email",true) == 0) {
                            Console.Write("Enter new email: ");
                            obj[i].Email = Console.ReadLine();

                            if (obj[i].Email.Contains("@gmail.com") == false || obj[i].Email.Contains("@mail.ru") == false)
                            {
                                Console.WriteLine("You enter wrong email format.\nPlease try again");
                                return;
                            }

                            break;
                        }

                        else if (string.Compare(infotype,"Age",true) == 0) {
                            Console.Write("Enter new age: ");
                            int copyage;
                            
                            if (int.TryParse(Console.ReadLine(), out copyage) == false) {
                                Console.WriteLine("You are enter letter");
                                return;
                            }

                            else {
                                obj[i].Age = copyage;
                                break;
                            }
                        }

                        else if (string.Compare(infotype,"Courselevel",true) == 0) {
                            Console.Write("Enter new courselevel: ");
                            int courselevel;
                            
                            if (int.TryParse(Console.ReadLine(), out courselevel) == false) {
                                Console.WriteLine("You are enter letter");
                                return;
                            }

                            else {
                                obj[i].Courselevel = courselevel;
                                break;
                            }
                        }

                        else {
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("You enter wrong information choose type try again");
                            Console.WriteLine("----------------------------------");
                        }
                    }
                }
            }
            
            if (flag == false) {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Not this name in Students.Try again.");
                Console.WriteLine("----------------------------------");
                return;
            }
            
            Console.Write("Do you want other student info/yes or no: ");
            string? readexit = Console.ReadLine();
            
            if (string.Compare(readexit,"No",true) == 0) {
                break;
            }

        }
    }
}