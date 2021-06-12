using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateEntriesCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "gca.csv";
            int duplicateCount = 0;
            List<Name> list = new List<Name>();
            StreamReader sr = File.OpenText(fileName);
            string line;
            string[] data;
            while ((line = sr.ReadLine()) != null)
            {
                data = line.Split(',');
                Name temp = new Name();
                temp.firstName = data[0].ToLower(); //to handle case insensitive
                temp.lastName = data[1].ToLower(); //to handle case insensitive
                list.Add(temp);
            }
            int i = 0;
            while(i<list.Count)
            {
                int jump = 0;
                while (i+jump+1<list.Count /*stop before last entry*/ && list[i+jump].firstName == list[i + jump + 1].firstName && list[i + jump].lastName == list[i + jump + 1].lastName)
                {
                    jump++;
                }
                if (jump > 0)
                {
                    duplicateCount++;
                    Console.WriteLine("Line: "+(i + 1));
                    i += jump;
                }
                else
                {
                    i++;
                }
            }
            Console.WriteLine($"Count Of Duplicates: {duplicateCount}");
            Console.Read();
        }
    }
}
