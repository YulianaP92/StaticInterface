using System;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_3_Static_Interface
{
    public partial class Practice
    {
        /// <summary>
        /// AL3-P1/3. Создать класс UniqueItem c числовым полем Id. 
        /// Каждый раз, когда создается новый экземпляр данного класса, 
        /// его идентификатор должен увеличиваться на 1 относительно последнего созданного. 
        /// Приложение должно поддерживать возможность начать идентификаторы с любого числа. 
        /// </summary>
        public static void AL3_P1_3()
        {
            for (int i = 0; i < 100; i++)
            {
                UniqueItem c = new UniqueItem();
            }
            Console.WriteLine(UniqueItem.Id);
        }

        /// <summary>
        /// AL3-P2/3. Отредактировать консольное приложение Printer. 
        /// Заменить базовый абстрактный класс на интерфейс.
        /// </summary>
        public static void AL3_P2_3()
        {

        }


        /// <summary>
        /// AL3-P3/3. Создайте обобщенный метод GuessType<T>(T item), 
        /// который будет принимать переменную обобщенного типа и выводить на консоль, 
        /// что это за тип был передан.
        /// </summary>
        public static void AL3_P3_3()
        {
            GuessType("asdfg");
            GuessType<uint>(10);
            GuessType(13.23456);
            GuessType(13.234);
            DateTime date2 = new DateTime(2019, 7, 20);
            GuessType(date2);
        }

        public static void GuessType<T>(T type)
        {
            switch (type)
            {
                case string _type:
                    if (_type.Length != 5)
                        goto default;
                    else
                        Console.WriteLine("Вы передали строку длиной 5 символов");
                    break;
                case uint _type:
                    Console.WriteLine("Вы передали положительное целое число");
                    break;
                case double _type:
                    int integer = Math.Abs((int)_type);
                    int count = integer.ToString().Length; // длина целой части
                    double fractional = Math.Abs(_type) - integer;
                    count = count + fractional.ToString().Length - 2; // длина всего числа
                    if (count != 5)
                        goto default;
                    else
                        Console.WriteLine("Вы передали вещественное число с 5 значимыми цифрами.");
                    break;
                case DateTime _type:
                    Console.WriteLine("Вы передали время");
                    break;
                default:
                    Console.WriteLine("Понятия не имею, что вы передали");
                    break;
            }
        }
    }
    public class UniqueItem
    {
        public static int Id;
        public string Name;
        public UniqueItem()
        {
            Id++;
        }
        static UniqueItem()
        {
            Id = 1000;
        }
    }
}
