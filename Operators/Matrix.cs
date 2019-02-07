using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operators
{
    class Matrix
    {
        int _w;
        int _h;
        int[,] _mas;
        public int Width

        {
            get => _w;
            set => _w = value;
        }

        public int Heigth
        {
            get => _h;
            set => _h = value;
        }

        public int this[int i, int j]
        {
            get
            {
                return _mas[i, j];
            }
            set
            {
                _mas[i, j] = value;
            }
        }

        public Matrix(int width = 1, int height = 1, bool f = true)
        {
            Random rand = new Random();
            if (width <= 0 || height <= 0) throw new Exception();
            _w = width;
            _h = height;
            _mas = new int[_h, _w];
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    if (f) _mas[i, j] = rand.Next(25);
                    else _mas[i, j] = 0;
        }

        public Matrix(Matrix a)
        {
            _w = a.Width;
            _h = a.Heigth;
            _mas = new int[_h, _w];
            for (int i = 0; i < _h; i++)
                for (int j = 0; j < _w; j++)
                    _mas[i, j] = a[i, j];
        }

        public Matrix(int[,] mas)
        {
            _h = mas.GetLength(0);
            _w = mas.GetLength(1);
            _mas = new int[_h, _w];
            for (int i = 0; i < _h; i++)
                for (int j = 0; j < _w; j++)
                    _mas[i, j] = mas[i, j];
        }

        public override string ToString()
        {
            StringBuilder myStr = new StringBuilder();
            if (_mas == null) return myStr.ToString();

            for (int i = 0; i < _h; i++)
            {
                for (int j = 0; j < _w; j++)
                {
                    myStr.Append(_mas[i, j]);
                    myStr.Append("\t");
                }
                myStr.Append("\n");
            }
            return myStr.ToString();
        }

        public static Matrix operator +(Matrix a)
        {
            Matrix tmp = new Matrix(a.Heigth, a.Width);
            for (int i = 0; i < a.Heigth; i++)
                for (int j = 0; j < a.Width; j++)
                    tmp[i, j] = Math.Abs(a[i, j]);
            return tmp;
        }

        public static Matrix operator -(Matrix a)
        {
            Matrix tmp = new Matrix(a.Heigth, a.Width);
            for (int i = 0; i < a.Heigth; i++)
                for (int j = 0; j < a.Width; j++)
                    tmp[i, j] = -a[i, j];
            return tmp;
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            Matrix tmp = new Matrix(a);
            if (a.Width != b.Width || a.Heigth != b.Heigth) //по идее ошибка входных данных.
                return new Matrix(a);  // не могу придумать что сделать

            for (int i = 0; i < a.Heigth; i++)
                for (int j = 0; j < a.Width; j++)
                    tmp[i, j] = a[i, j] + b[i, j];
            return tmp;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            Matrix tmp = new Matrix(a);
            if (a.Width != b.Width || a.Heigth != b.Heigth) //по идее ошибка входных данных.
                return new Matrix(a);  // не могу придумать что сделать

            for (int i = 0; i < a.Heigth; i++)
                for (int j = 0; j < a.Width; j++)
                    tmp[i, j] = a[i, j] - b[i, j];
            return tmp;
        }

        public static Matrix operator *(Matrix a, int b)
        {
            Matrix tmp = new Matrix(a);
            for (int i = 0; i < a.Heigth; i++)
                for (int j = 0; j < a.Width; j++)
                    tmp[i, j] = a[i, j] * b;
            return tmp;
        }

        public static Matrix operator *(int a, Matrix b)
        {
            Matrix tmp = new Matrix(b);
            for (int i = 0; i < b.Heigth; i++)
                for (int j = 0; j < b.Width; j++)
                    tmp[i, j] = a * b[i, j];
            return tmp;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            Matrix tmp = new Matrix(a.Heigth, b.Width);
            if (a.Width != b.Heigth) //по идее ошибка входных данных.
                return new Matrix(a);  // не могу придумать что сделать

            for (int i = 0; i < a.Heigth; i++)
                for (int j = 0; j < b.Width; j++)
                {
                    for (int k = 0; k < a.Width; k++)
                        tmp[i, j] += a[i, k] + b[k, j];
                }
            return tmp;
        }

        public static bool operator ==(Matrix a, Matrix b)
        {
            if (a.Width != b.Width || a.Heigth != b.Heigth) return false;
            for (int i = 0; i < a.Heigth; i++)
                for (int j = 0; j < b.Width; j++)
                    if (a[i, j] != b[i, j]) return false;
            return true;
        }

        public static bool operator !=(Matrix a, Matrix b)
        {
            if (a.Width != b.Width || a.Heigth != b.Heigth) return true;
            for (int i = 0; i < a.Heigth; i++)
                for (int j = 0; j < b.Width; j++)
                    if (a[i, j] != b[i, j]) return true;
            return false;
        }

        public static implicit operator int[,] (Matrix a)
        {
            int[,] tmp = new int[a.Heigth, a.Width];
            for (int i = 0; i < a.Heigth; i++)
                for (int j = 0; j < a.Width; j++)
                    tmp[i, j] = a[i, j];
            return tmp;
        }

        private Matrix(Matrix a, int column)
        {
            _w = a.Width - 1;
            _h = a.Heigth - 1;
            _mas = new int[_h, _w];
            for (int i = 0; i < _h; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    _mas[i, j] = a[i + 1, j];
                }
                for (int j = column; j < _h; j++)
                {
                    _mas[i, j] = a[i + 1, j + 1];
                }
            }
        }

        public int Determinant()
        {
            if (_h != _w) return -1;
            if (_h == 2) return _mas[0, 0] * _mas[1, 1] - _mas[0, 1] * _mas[1, 0];
            int tmp = 0;
            for (int i = 0; i < _h; i++)
            {
                if ((i & 1) == 0) tmp += _mas[0, i] * new Matrix(this, i).Determinant();
                else tmp -= _mas[0, i] * new Matrix(this, i).Determinant();
            }
            return tmp;
        }

        public int Track()
        {
            if (this.Heigth != this.Width) return -1;
            int tmp = 0;
            for (int i = 0; i < this.Heigth; i++)
                tmp += this[i, i];
            return tmp;
        }
        //to be continued. Or not to be...
    }
}