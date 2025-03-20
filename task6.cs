// Task 6: Custom Notification System
// Task: Create a notification system where different users can register messages dynamically and retrieve them later. 

class Message {
    private string _sms;
    private int _Idnumber;
    public bool _isread;

    public Message(string sms, int idnumber) {
        this._sms = sms;
        this._Idnumber = idnumber;
        this._isread = false;
    }

    public string Sms {
        get { return _sms; }
    }

    public int Idnumber {
        get { return _Idnumber; }
    }


}

class Chat {
    public Message[] messages;
    private int _size = 0;
    private int _capacity;

    public Chat(int capacity) {
        this._capacity = capacity;
        this.messages = new Message[capacity];
    }    

    public int Size {
        get { return _size; }
    }

    public Message this[int index] {
        get { 
            if (index < 0 || index >= _size) {
                throw new ArgumentOutOfRangeException("Index is out of range");
            }
            return messages[index];
        }

        set {
            if (index < 0 || index >= _size) {
                throw new ArgumentOutOfRangeException("Index is out of range");
            }
            messages[index] = value;
        }
    }

    public void Addmessage(string massage, int idnumber) {
        if (_size == _capacity) {
            Message[] newmessages = new Message[this._capacity * 2];
            _capacity *= 2;
            Array.Copy(messages, newmessages, _size);
            newmessages[_size++] = new Message(massage, idnumber);
            messages = newmessages;
        }
        else {
            messages[_size++] = new Message(massage, idnumber);
        }
    }

}


class User {
    public string _name;
    public int idnumber;

    public User(string name, int idnumber) {
        this._name = name;
        this.idnumber = idnumber;
    }

    public void ReadMessage(Chat obj) {
        for (int i = 0; i < obj.Size; i++) {
            if (obj[i].Idnumber == idnumber && obj[i]._isread == false) {
                Console.Write("Message is ");
                Console.WriteLine($"{obj[i].Sms}");
                obj[i]._isread = true;
            }
        }
    }

}

class Program {
    static void Main(string[] args) {
        User user = new User("Arman",1);
        User user2 = new User("Narek",2);
        User user3 = new User("Gagik",3);
        Chat chat = new Chat(1);
        chat.Addmessage("Nareky lav txaya",2);
        chat.Addmessage("Nareky shat simpo txaya",2);
        
        user2.ReadMessage(chat);
       
        chat.Addmessage("djf",2);
        user2.ReadMessage(chat);

    }


}