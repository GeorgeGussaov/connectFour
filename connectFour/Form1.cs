using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace connectFour
{
    public partial class FormGame : Form
    {
        const int strSIZE = 6;
        const int stlbSIZE = 7;
        int[,] field = new int[strSIZE, stlbSIZE ];


        

        void showField(int[,] mas)
        {
            for (int i = 0; i < strSIZE; i++)
            {
                for (int j = 0; j < stlbSIZE; j++)
                {
                    if (mas[i,j] == 1)
                        dataGridViewField.Rows[i].Cells[j].Value = 1;
                }

            }

        }

        bool isGameOver(int[,] mas)
        {

            for (int i = 0; i < 6; i++)
            {
                int cntStr = 0;
                int cntStlb = 0;

                for (int j = 0; j < 6; j++)
                {
                    if (mas[i, j] == 1) cntStlb++;
                    if (mas[j, i] == 1) cntStr++;
                }
                if (cntStlb == 4 || cntStr == 4) return true;
            }
            return false;
        }


        public FormGame()
        {
            InitializeComponent();
            dataGridViewField.Rows.Add(strSIZE);
        }


        private void dataGridViewField_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (field[e.RowIndex, e.ColumnIndex] == 0)
            {
                field[e.RowIndex, e.ColumnIndex] = 1; //change field
                showField(field);
                if (isGameOver(field) == true) MessageBox.Show("win");
            }
        }
        

    }
}
