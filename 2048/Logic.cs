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

        }

        public void ShiftRight()
        {

        }

        public void ShiftUp()
        {

        }

        public void ShiftDown()
        {

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
            return false;
        }

        private void combine()
        {

        }
    }
}
