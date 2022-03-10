using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace romannumbers
{
    public class RomanNumber : ICloneable, IComparable
    {
        private string rom;
        private ushort arab;
        private readonly ushort[] _numeric = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        private readonly string[] _symbolic = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
        //Конструктор получает представление числа n в римской записи
        public RomanNumber(ushort n)
        {
            if (n <= 0)
            {
                throw new RomanNumberException("Значение должно быть больше 0.");
            }
            else
            {
                this.arab = n;
                this.rom = "";
            }
        }
        //Сложение римских чисел
        public static RomanNumber operator +(RomanNumber? n1, RomanNumber? n2)
        {
            return new RomanNumber((ushort)(n1.arab + n2.arab));
        }
        //Вычитание римских чисел
        public static RomanNumber operator -(RomanNumber? n1, RomanNumber? n2)
        {
            if (0 >= n1.arab - n2.arab)
            {
                throw new RomanNumberException("Значение вычитания меньше/равно 0.");
            }
            else
            {
                return new RomanNumber((ushort)(n1.arab - n2.arab));
            }
        }
        //Умножение римских чисел
        public static RomanNumber operator *(RomanNumber? n1, RomanNumber? n2)
        {
            return new RomanNumber((ushort)(n1.arab * n2.arab));
        }
        //Целочисленное деление римских чисел
        public static RomanNumber operator /(RomanNumber? n1, RomanNumber? n2)
        {
            if (0 >= (n1.arab / n2.arab))
            {
                throw new RomanNumberException("Значение деления меньше/равно 0.");
            }
            else
            {
                return new RomanNumber((ushort)(n1.arab / n2.arab));
            }
        }
        //Возвращает строковое представление римского числа
        public override string ToString()
        {
            ushort temp = this.arab;
            this.rom = "";
            for (int i = 0; i < 13; i++)
            {
                while (temp >= _numeric[i])
                {
                    this.rom += _symbolic[i];
                    temp -= _numeric[i];
                }
            }

            return this.rom;
        }
        // реализация интерфейса IClonable
        public object Clone()
        {
            return new RomanNumber(this.arab);
        }
        // реализация интерфейса IComparable
        public int CompareTo(object? obj)
        {
            if (obj is RomanNumber number)
            {
                return arab.CompareTo(number.arab);
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }

}
