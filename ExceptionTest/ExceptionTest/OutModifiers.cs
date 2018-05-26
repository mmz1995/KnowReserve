using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionTest
{


    class OutModifiers
    {
        static void Main()
        {
            string str;//登陆状态
            Console.WriteLine("请输入用户名：");
            string userName = Console.ReadLine();
            Console.WriteLine("请输入密码：");
            string userPsw = Console.ReadLine();
            bool login = Login(userName, userPsw, out str);
            if (login)
            {
                Console.WriteLine(str);
            }
            else
            {
                Console.WriteLine(str);
            }
        }
        /// <summary>
        /// out:参数修饰符
        /// </summary>
        /// <param name="name"></param>
        /// <param name="psw"></param>
        /// <param name="msg">在方法种必须被初始化，且在每条可能导致方法结束的分支中都赋值</param>
        /// <returns>返回一个bool值，但由于参数中存在 out 修饰符参数，会返回多余的参数：msg </returns>
        public static bool Login(string name,string psw,out string msg)
        {
            bool result;
            if (name.Equals("admin") && psw.Equals("123"))
            {
                msg = "登陆成功";
                result = true;
            }
            else
            {
                msg = "登陆失败";
                result = false;
            }
            return result;
        }
    }
}
