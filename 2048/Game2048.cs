using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public delegate void DelegateShow(int x, int y, int number);
    public partial class Game2048 : Form
    {
        static int size = 4;
        Label[,] box;
        Dictionary<int, Color> backColors;
        public Game2048()
        {
            InitializeComponent();
            InitBackColors();
            InitLabels();
            int j = 2;

            for (int y = 0; y < size; y++)
                for (int x = 0; x < size; x++)
                {
                    Show(x, y, j);
                    j *= 2;
                }
        }

        void InitBackColors()
        {
            backColors = new Dictionary<int, Color>();
            backColors.Add(0, this.BackColor);

            byte r = 255;
            byte g = 224;
            byte b = 192;

            for (int j = 1; j < 65536 * 2048; j *= 2)
            {
                backColors.Add(j, Color.FromArgb(r, g, b));
                r -= 6;
                g -= 10;
                b -= 20;
            }





        }

        void InitLabels()
        {
            box = new Label[size, size];

            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                {
                    box[x, y] = CreateLabel();
                    tableLayoutPanel1.Controls.Add(box[x, y], x, y);
                }
        }

        Label CreateLabel()
        {
            Label label = new Label();
            label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            label.Dock = System.Windows.Forms.DockStyle.Fill;
            label.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label.Text = "-";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            return label;
        }

        void Show(int x, int y, int number)
        {
            box[x, y].Text = number > 0 ? number.ToString() : "";
            box[x, y].BackColor = backColors[number];
        }

    }
}
