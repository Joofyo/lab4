using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbers
{
    public class RomanNumber : ICloneable, IComparable
    {
        private string _romanForm;
        private ushort _arabicForm;
        private readonly ushort[] _numeric = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        private readonly string[] _symbolic = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

        public RomanNumber(ushort n)
        {
            if (n <= 0)
            {
                throw new RomanNumberException("Значение должно быть больше 0.");
            }
            else
            {
                this._arabicForm = n;
                this._romanForm = "";
            }
        }

        public static RomanNumber operator +(RomanNumber? n1, RomanNumber? n2)
        {
            return new RomanNumber((ushort)(n1._arabicForm + n2._arabicForm));
        }

        public static RomanNumber operator -(RomanNumber? n1, RomanNumber? n2)
        {
            if (0 >= n1._arabicForm - n2._arabicForm)
            {
                throw new RomanNumberException("Значение вычитания меньше/равно 0.");
            }
            else
            {
                return new RomanNumber((ushort)(n1._arabicForm - n2._arabicForm));
            }
        }

        public static RomanNumber operator *(RomanNumber? n1, RomanNumber? n2)
        {
            return new RomanNumber((ushort)(n1._arabicForm * n2._arabicForm));
        }

        public static RomanNumber operator /(RomanNumber? n1, RomanNumber? n2)
        {
            if (0 >= (n1._arabicForm / n2._arabicForm))
            {
                throw new RomanNumberException("Значение деления меньше/равно 0.");
            }
            else
            {
                return new RomanNumber((ushort)(n1._arabicForm / n2._arabicForm));
            }
        }

        public override string ToString()
        {
            ushort temp = this._arabicForm;
            this._romanForm = "";
            for (int i = 0; i < 13; i++)
            {
                while (temp >= _numeric[i])
                {
                    this._romanForm += _symbolic[i];
                    temp -= _numeric[i];
                }
            }

            return this._romanForm;
        }

        public object Clone()
        {
            return new RomanNumber(this._arabicForm);
        }

        public int CompareTo(object? obj)
        {
            if (obj is RomanNumber number)
            {
                return _arabicForm.CompareTo(number._arabicForm);
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }

}
