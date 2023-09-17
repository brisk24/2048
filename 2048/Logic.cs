using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    class Logic
    {
        int size = 4;
        int[,] map;
        DelegateShow show;
        static Random rnd = new Random();
        public Logic(int size, DelegateShow show)
        {
            this.size = size;
            map = new int[size, size];
            this.show = show;
        }

        public void InitGame()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                {
                    map[x, y] = 0;
                    show(x, y, 0);
                }
            addNumbers();
            addNumbers();
        }

        public void ShiftLeft()
        {
            for (int y = 0; y < size; y++)
                Shift(3, y, -1, 0);
        }

        public void ShiftRight()
        {
            for (int y = 0; y < size; y++)
                Shift(0, y, 1, 0);
        }

        public void ShiftUp()
        {
            for (int x = 0; x < size; x++)
                Shift(x, 3, 0, -1);
        }

        public void ShiftDown()
        {
            for (int x = 0; x < size; x++)
                Shift(x, 0, 0, 1);
        }

        private void addNumbers()
        {
            if (GameOver()) return;
            int x, y;
            do
            {
                x = rnd.Next(0, size);
                y = rnd.Next(0, size);
            } while (map[x, y] > 0);
            map[x, y] = rnd.Next(1, 3) * 2;
            show(x, y, map[x, y]);
        }

        public bool GameOver()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    if (map[x, y] == 0)
                        return false;
            return true;
        }

        private void Shift(int x, int y, int sx, int sy)
        {
            if (x + sx < 0 || x + sx >= size ||
                y + sy < 0 || y + sy >= size)
                return;

            Shift(x + sx, y + sy, sx, sy);
            if (map[x + sx, y + sy] == 0 &&
                map[x, y] > 0)
            {
                map[x + sx, y + sy] = map[x, y];
                map[x, y] = 0;
                show(x + sx, y + sy, map[x + sx, y + sy]);
                show(x, y, map[x, y]);
                Shift(x + sx, y + sy, sx, sy);
            }



        }

        private void combine()
        {

        }
    }
}
