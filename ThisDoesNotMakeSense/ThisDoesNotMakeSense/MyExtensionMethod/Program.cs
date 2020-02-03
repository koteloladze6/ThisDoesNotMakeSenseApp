using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyExtensionMethod
{
    class Program
    {
        static void Main(string[] args)
        {

            string numbersForExample = "1,4,5";
            List<int> numbers = new List<int>(Array.ConvertAll(numbersForExample.Split(','), int.Parse));
            int addValue = 8;

            int firstExampleResult = numbers.ThisDoesntMakeAnySense(x => x > 0, (ref IEnumerable<int> data) =>
            {
                List<int> temp = new List<int>();
                temp.AddRange(data);
                temp.Add(addValue);
                data = temp;
                return addValue;
            });

            Console.WriteLine("First Example Numbers : " + numbersForExample);
            Console.WriteLine("Predicate : Numbers must be positive ");
            Console.WriteLine("Output Default Number : " + firstExampleResult + "\n");

            int secondExampleResult = numbers.ThisDoesntMakeAnySense(x => x < 0, (ref IEnumerable<int> data) =>
            {
                List<int> temp = new List<int>();
                temp.AddRange(data);
                temp.Add(addValue);
                data = temp;
                return addValue;
            });

            Console.WriteLine("Second Example Numbers : " + numbersForExample);
            Console.WriteLine("Predicate : Numbers must not be positive ");
            Console.WriteLine("Output newly added  number to the list  : " + secondExampleResult + "\n");

            List<int> emptyList = null;

            Console.WriteLine("Third Example List is Null");

            try
            {
                emptyList.ThisDoesntMakeAnySense(x => x > 0, (ref IEnumerable<int> data) =>
                {
                    List<int> temp = new List<int>();
                    temp.AddRange(data);
                    temp.Add(addValue);
                    data = temp;
                    return addValue;
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
