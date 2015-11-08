using System;

namespace Dev204x {
    /*
        XOXOXOXO
        OXOXOXOX
        XOXOXOXO
        OXOXOXOX
        XOXOXOXO
        OXOXOXOX
        XOXOXOXO
        OXOXOXOX
    */
    class Program {
        static void TypeWriter(char[] chars, int lines, int lineLength) {
            bool flip = false;

            for (int i = 0; i < lines; ++i) {
                if (flip) {
                    flip = false;                    
                    for (int j = lineLength - 1; j >= 0; --j) {
                        Console.Write(chars[j % chars.Length]);
                    }
                } else {
                    flip = true;
                    for (int j = 0; j < lineLength; ++j) {
                        Console.Write(chars[j % chars.Length]);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Main() {
            TypeWriter( new char[] { 'X', 'O' }, 8, 8);
        }
    }
}
