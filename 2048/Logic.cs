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
        public bool moved;
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
            moved = false;
            for (int y = 0; y < size; y++)
            {
                Shift(size - 1, y, -1, 0);
                combine(size - 1, y, -1, 0);
                Shift(size - 1, y, -1, 0);
            }
            if (moved)
                addNumbers();
        }

        public void ShiftRight()
        {
            moved = false;
            for (int y = 0; y < size; y++)
            {
                Shift(0, y, 1, 0);
                combine(0, y, 1, 0);
                Shift(0, y, 1, 0);
            }
            if (moved)
                addNumbers();
        }

        public void ShiftUp()
        {
            moved = false;
            for (int x = 0; x < size; x++)
            {
                Shift(x, size - 1, 0, -1);
                combine(x, size - 1, 0, -1);
                Shift(x, size - 1, 0, -1);
            }
            if (moved)
                addNumbers();
        }

        public void ShiftDown()
        {
            moved = false;
            for (int x = 0; x < size; x++)
            {
                Shift(x, 0, 0, 1);
                combine(x, 0, 0, 1);
                Shift(x, 0, 0, 1);
            }
            if (moved)
                addNumbers();
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

            for (int x = 0; x < size - 1; x++)
                for (int y = 0; y < size; y++)
                    if (map[x, y] == map[x + 1, y])
                        return false;
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size-1; y++)
                    if (map[x, y] == map[x,y + 1])
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
                moved = true;
            }
        }

        private void combine(int x, int y, int sx, int sy)
        {
            if (x + sx < 0 || x + sx >= size ||
               y + sy < 0 || y + sy >= size)
                return;

            combine(x + sx, y + sy, sx, sy);
            if (map[x + sx, y + sy] > 0 &&
                map[x + sx, y + sy] == map[x, y])
            {
                map[x + sx, y + sy] *= 2;
                map[x, y] = 0;
                show(x + sx, y + sy, map[x + sx, y + sy]);
                show(x, y, map[x, y]);
                combine(x + sx, y + sy, sx, sy);
                moved |= true;
            }
        }
    }
}
