using System;

namespace Operators
{
    class Fract
    {
        int _ch;
        int _zn;
        public int Chislitel

        {
            get => _ch;
            set => _ch = value;
        }

        public int Znamnatel
        {
            get => _zn;
            set => _zn = value;
        }

        public Fract(int chislitel = 0, int znamenatel = 1)
        {
            if (znamenatel == 0) throw new DivideByZeroException();
            _ch = chislitel;
            _zn = znamenatel;
        }

        public override string ToString()
        {

            return _ch > _zn ? $"{_ch / _zn}+ {_ch % _zn}/{_zn}" : $"{_ch}/{_zn}";
        }

        public static Fract operator +(Fract a)
        {
            return new Fract(a._ch, a._zn);
        }

        public static Fract operator -(Fract a)
        {
            return new Fract(-a._ch, a._zn);
        }

        public static Fract operator +(Fract a, Fract b)
        {
            return new Fract(a._ch * b._zn + b._ch * a._zn, a._zn * b._zn);
        }

        public static Fract operator -(Fract a, Fract b)
        {
            return new Fract(a._ch * b._zn - b._ch * a._zn, a._zn * b._zn);
        }

        public static Fract operator *(Fract a, Fract b)
        {
            return new Fract(a._ch * b._ch, a._zn * b._zn);
        }

        public static Fract operator /(Fract a, Fract b)
        {
            return new Fract(a._ch * b._zn, a._zn * b._ch);
        }

        public static Fract operator +(Fract a, int b)
        {
            return new Fract(a._ch + b, a._zn);
        }

        public static Fract operator /(int a, Fract b)
        {
            return new Fract(a + b._zn, b._ch);
        }

        public static bool operator ==(Fract a, Fract b)
        {
            return a._ch * b._zn == b._ch * a._zn;
        }

        public static bool operator !=(Fract a, Fract b)
        {
            return a._ch * b._zn != b._ch * a._zn;
        }

        public static bool operator >(Fract a, Fract b)
        {
            return a._ch * b._zn > b._ch * a._zn;
        }

        public static bool operator <(Fract a, Fract b)
        {
            return a._ch * b._zn < b._ch * a._zn;
        }

        public static bool operator true(Fract a)
        {
            return a._ch != 0;
        }

        public static bool operator false(Fract a)
        {
            return a._ch == 0;
        }

        /*
        public static implicit operator double (Fract a)
        {
            return a._ch / (double)a._zn;
        }

        public static explicit operator int (Fract a)
        {
            return a._ch / a._zn;
        }
        */

        //Домашнее Задание
        public static Fract operator ++(Fract a)
        {
            return new Fract(a._ch + a._zn, a._zn);
        }

        public static Fract operator --(Fract a)
        {
            return new Fract(a._ch - a._zn, a._zn);
        }

        public Fract Normalize()
        {
            if (_ch == 0) return this;
            int gcd = GCD(_ch, _zn);
            if (gcd == 1) return this;
            return new Fract(_ch / gcd, _zn / gcd);
        }

        private int GCD(int a, int b)
        {
            while (b != 0)
                b = a % (a = b);
            return a;
        }
    }
}
