using System;

namespace Operators
{
    class Complex
    {
        double _x;
        double _y;
        public double X

        {
            get => _x;
            set => _x = value;
        }

        public double Y
        {
            get => _y;
            set => _y = value;
        }

        public Complex(double a = 0, double b = 0)
        {
            _x = a;
            _y = b;
        }

        public override string ToString()
        {
            if (_x == 0)
            {
                if (_y == 0) return "0";
                else return $"{_y}*i";
            }
            else
            {
                if (_y == 0) return _x.ToString();
                else
                {
                    if (_y > 0) return $"{_x}+{_y}*i";
                    else return $"{_x}{_y}*i";
                }
            }
        }

        public static Complex operator +(Complex a)
        {
            return new Complex(Math.Abs(a._x), a._y);
        }

        public static Complex operator -(Complex a)
        {
            return new Complex(-a._x, a._y);
        }

        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a._x + b._x, a._y + b._y);
        }

        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a._x - b._x, a._y - b._y);
        }

        public static Complex operator *(Complex a, Complex b)
        {
            return new Complex(a._x * b._x - a._y * b._y, a._y * b._x + a._x * b._y);
        }

        public static Complex operator /(Complex a, Complex b)
        {
            double tmp = b._x * b._x + b._y * b._y;
            if (tmp == 0) throw new DivideByZeroException();
            return new Complex((a._x * b._x + a._y * b._y) / tmp, (a._y * b._x + a._x * b._y) / tmp);
        }

        public static bool operator ==(Complex a, Complex b)
        {
            return (a._x == b._x && a._y == b._y);
        }

        public static bool operator !=(Complex a, Complex b)
        {
            return (a._x != b._x || a._y != b._y);
        }

        public static bool operator true(Complex a)  //мнимая часть на то и мнимая, что роли не играет
        {
            return a._x != 0;
        }

        public static bool operator false(Complex a)
        {
            return a._x == 0;
        }

        /*public static implicit operator double (Complex a)
        {
            return a._x;
        }
        */

        public static Complex operator ++(Complex a)
        {
            return new Complex(a._x++, a._y);
        }

        public static Complex operator --(Complex a)
        {
            return new Complex(a._x--, a._y);
        }

        public static Complex operator ~(Complex a)
        {
            return new Complex(a._x, -a._y);
        }

        public static double Abs(Complex a)
        {
            return Math.Sqrt(a._x * a._x + a._y * a._y);
        }
    }
}
