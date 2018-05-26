using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 异常处理
/// </summary>
namespace ExceptionTest
{
    public class Sentence
    {
        public Sentence(string s)
        {
            Value = s;
        }
        public string Value { get; set; }
        public char GetFirstChar()
        {
            try//疑似异常语句块
            {
                return Value[0];
            }
            catch (IndexOutOfRangeException e)//异常处理语句----- 异常处理分类，越精细越可能造成异常的类别，位置顺序越靠上
            {
                Console.WriteLine($"Exception:{e.Message}");
                throw;
            }
        }
    }

    class ExceptionExample
    {
        /*static void Main(string[] args)
        {
            Sentence s = new Sentence(null);//未实例化，将抛出异常
            //Sentence s = new Sentence("zhen");//正常调用
            Console.WriteLine($"the first character is {s.GetFirstChar()}");
        }*/
    }
}
