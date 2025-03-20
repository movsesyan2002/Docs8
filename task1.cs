// Task 1: Custom List Implementation
// Task: Create a custom list based on an array with dynamic size adjustment. 
// Implement an indexer for element access, a Length property, and methods for adding and removing elements.
// Ensure proper validation when accessing indices.

using System.Formats.Asn1;

class ListExample {

    private int[] array;
    private int _capacity;
    private int _size = 0;

    public ListExample(int capacity) {
        this._capacity = capacity;
        this.array = new int[_capacity];
    }   

    public int this[int index] {
        get {
            if (index < 0 || index >= _size) {
                Console.WriteLine("You enter invalid index try again");
                return -1;
            }

            return array[index];
        }
    }

    public void AddElement(int value) {
        if (_size < _capacity) {
            array[_size++] = value; 
        }
        else if (_size == _capacity) {
            int[] newarrray = new int[_capacity * 2];
            _capacity *=  2;
            Array.Copy(array, newarrray, _size);
            newarrray[_size++] = value;
            array = newarrray;
        }
    }

    public void RemoveElement(int index) {
        if (index >= _size || index < 0) {
            Console.WriteLine("You are enter Invalid value");
            return;
        }

        else {
            int[] newarrray = new int[_capacity];
            for (int i = 0; i < index; i++){
                newarrray[i] = array[i];
            }

            for (int i = index + 1; i < _size; i++){
                newarrray[i - 1] = array[i];
            }
            _size--;
            array = newarrray;
        }
    }

    public void Display() {
        for (int i = 0; i < _size; i++) {
            Console.WriteLine(this[i]);
        }
    }
}


class Program {
    static void Main(string[] args) {
        ListExample obj = new ListExample(5);
        obj.AddElement(1);
        obj.AddElement(2);
        obj.AddElement(3);
        obj.RemoveElement(2);
        obj.Display();
    }
}
