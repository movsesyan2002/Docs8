// Task 5:  Dynamic Cache with Auto-Cleanup
// Task: Create a cache system that stores objects(documents) using an indexer. 
// Implement automatic cleanup of stale objects based on time or memory constraints. 
// The system should use a static member to track total cached objects.

// class Object {

//     public string name {get;set;}
//     public double  time {get;set;}

//     public Object (string Name, double Time) {

//         if (Time <= 0) {
//             throw new ArgumentException ("\n\nTime can not be 0 or less");
//         }

//         name = Name;        
//         time = Time;

//     }
    
// }
// class ArrayObjects {

//     private Object [] objects;

//     public ArrayObjects (int capacity) {
//         if (capacity <= 0) {
//             throw new ArgumentException ("\n\nCapacity can not be 0 or less");
//         }
//         objects = new Object[capacity];
//     }
//     public int Length {
//         get { return objects.Length; }
//     }
//     public double this [string name ] {
//         get {
//             for (int i = 0; i < objects.Length; ++i) {
//                 if (name == objects[i].name) {
//                     return objects[i].time;
//                 }
//             }
//             return -1;
//         }
//         set {
//             for (int i = 0; i < objects.Length; ++i) {
//                 if (name == objects[i].name) {
//                     objects[i].time = value;
//                 }
//             }           
//         }
//     }
    
//     public Object this [int index] {
//         get {
//             if (index < 0 || index > objects.Length) {
//                 throw new ArgumentException ("\n\nThe Index is out of range");
//             } 
//             return objects [index];
//         }
//         set{
//             if (index < 0 || index > objects.Length) {
//                 throw new ArgumentException ("\n\nThe Index is out of range");
//             }
//             objects [index] = value;    
//         }

//     }
//     public void RemoveObject () {
//         for (int i = 0; i < objects.Length; ++i) {

//             if (objects[i] != null && objects[i].time <=0) {
//                 objects[i] = null;
//             }
//         }
//     }
//     public void DisplayInfo () {
//         for (int i = 0; i < objects.Length; ++i) {
//             if (objects[i] != null) {
//                 Console.WriteLine ($"\nObject Name: {objects[i].name}\nObject Time: {objects[i].time}\n");
//             }
//         }
//     }
// }

// class Program {
//     static void Main (string [] args) {

//         ArrayObjects arrayObjects = new ArrayObjects(5);
//         Random r = new Random();
//         Console.WriteLine ("\nEnter Products");
//         for (int i = 0; i < arrayObjects.Length; ++i) {
//             string str = Console.ReadLine();
//             arrayObjects[i] = new Object (str, r.Next(1,15));
//         }
//         while (true) {

//             for (int i = 0; i < arrayObjects.Length; ++i) {
//                 if ( arrayObjects[i] != null && arrayObjects[i].time >= 1) {
//                     arrayObjects[i].time -= 1;
//                 }
//             }
//             arrayObjects.RemoveObject();   
//             arrayObjects.DisplayInfo();
//             int count = 0;
//             for (int i = 0; i < arrayObjects.Length; ++i) {
        
//                 if (arrayObjects[i] == null) {
//                     ++count;
//                 }
//             }
            
//             if (count == arrayObjects.Length) {
//                 break;
//             }
//         }
//     }
// }            
