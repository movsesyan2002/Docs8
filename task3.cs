// Task 3:  Multi-Dimensional Grid System

// Task: Create a grid system where each cell can store a value. Implement a multidimensional indexer for retrieving and setting values. 

// The system should validate index bounds and provide a method for retrieving a row or column.

// using System;


class Grid {
    private int[,] matrix;
    public int Raw;
    public int Column;

    public Grid (int raw, int column) {
        if (raw < 0 || column < 0) {
            throw new ArgumentException("\n\nTaking raw or column argument is less than 0\n\n");
        }
        this.Raw = raw;
        this.Column = column;
        this.matrix = new int[Raw, Column];
    }

    public int this[int raw, int column] {
        get {
            ValidationIndex(raw, column);
            return this.matrix[Raw, column];
        }

        set {
            ValidationIndex(raw, column);
            this.matrix[raw, column] = value;
        }
    }

    private void ValidationIndex(int raw, int column) {
        if (raw < 0 || raw >= this.Raw || column < 0 || column >= this.Column) {
            throw new ArgumentException("\n\nTaking raw or column argument is less than 0\n\n");
        }
    }

    public int[] GetRaw(int raw) {
        ValidationIndex(raw, 0);
        int[] result = new int[this.Column];
        
        for (int i = 0; i < this.Column; ++i) {
            result[i] = this.matrix[raw,i];
        }

        return result;
    }

    public int[] GetColumn(int column) {
        ValidationIndex(0, column);
        int[] result = new int[this.Raw];
        
        for (int i = 0; i < this.Raw; ++i) {
            result[i] = this.matrix[i,column];
        }

        return result;
    }
}

class Program {
    static void Main(string[] args) {
        Grid grid = new Grid(3, 3);
        grid[0,0] = 1;
        grid[0,1] = 2;
        grid[0,2] = 3;
        grid[1,0] = 1;
        grid[2,0] = 1;
        Console.WriteLine($"{string.Join(",", grid.GetRaw(0))}");
    }
}
