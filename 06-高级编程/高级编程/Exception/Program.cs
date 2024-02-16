using System;
using System.IO;

namespace ExceptionHald
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var calculator = new Calculator();
            var result = 0;

            try
            {
                result = calculator.devide(5, 0);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("分母不得为零：" + ex.Message);
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine("算术出错：" + ex.Message);
            }
            catch (SystemException ex)
            {
                Console.WriteLine("系统出错：" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("有情况：" + ex.Message);
                // throw new Exception() 向上抛出异常
            }
            finally
            {
                Console.WriteLine(result);
            }

            StreamReader reader = null;
            try
            {
                var filePath = Path.Combine("C:\\Users\\51790\\OneDrive\\C#Repository\\06-高级编程\\高级编程", "demo.txt");
                reader = new StreamReader(filePath);
                var text = reader.ReadToEnd();
                Console.WriteLine(text);
            }
            catch (Exception ex)
            {
                Console.WriteLine("有情况：" + ex.Message);
            }
            finally
            {
                //if (reader != null)
                //{
                //    reader.Close();
                //}
                reader?.Dispose(); // 简化 Null 检查
            }
        }
    }
}
