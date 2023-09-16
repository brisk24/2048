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
    public partial class Game2048 : Form
    {
        static int size = 4;
        Label[,] box;
        public Game2048()
        {
            InitializeComponent();
            InitLabels();
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
    }
}
