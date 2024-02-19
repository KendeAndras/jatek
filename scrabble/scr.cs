using System.Diagnostics.Metrics;

namespace scrabble
{
    public class scr
    {
        public scr()
        {
            FileRead();
            Check();
        }

        //@ itt: figyelmen kivul hagyja pl a \t meg a \n -t
        const string fileName = @"c:\temp\book.txt";
        //kulcs es ertekpar van a dictionary ban
        Dictionary<char,int> dic = new Dictionary<char,int>();
        int counter = 0;

        public int LetterValue (char chr)
        {
            if ((chr >= 65 && chr <= 90) || (chr >= 97 && chr <= 122))
            {
                return dic[char.ToUpper(chr)];
            }
            return 0;  
        }
        public int WordValue(string str)
        {
            int num = 0;
            foreach (char c in str)
            {
                num += LetterValue(num);
            }
            return num;
        }

        private void FileRead()
        {
            dic = new Dictionary<char, int>();
            try
            {
                string[] rows = File.ReadAllLines(fileName);
                foreach (string row in rows)
                {
                    foreach (char letter in row)
                    {
                        if ((letter >= 65 && letter <= 90) || (letter >= 97 && letter <= 122))
                        {
                            if (dic.ContainsKey(char.ToUpper(letter)))
                            {
                                dic[letter]++;
                            }
                            else
                            {
                                dic.Add(letter, 1);
                            }
                            counter++;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Check()
        {
            dic = new Dictionary<char,int>();
            foreach (KeyValuePair<char,int> item in dic)
            {
                dic.Add(item.Key, counter/item.Value);
            }
        }
    }
}