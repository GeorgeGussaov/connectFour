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
        int SIZE = 7;
        int[,] field = new int[7, 7];
        int pl = 2;
        string[] member = {"Игрок1","Игрок2" };

        

        void showField(int[,] mas)
        {
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    if (mas[i, j] == 1)
                    {
                        dataGridViewField.Rows[i].Cells[j].Value = 1;
                        dataGridViewField.Rows[i].Cells[j].Style.BackColor = Color.Orange;
                    }
                    if (mas[i, j] == 2)
                    {
                        dataGridViewField.Rows[i].Cells[j].Value = 2;
                        dataGridViewField.Rows[i].Cells[j].Style.BackColor = Color.OrangeRed;
                    }
                }

            }

        }


        public FormGame()
        {
            InitializeComponent();
            dataGridViewField.Rows.Add(SIZE);
        }


        bool rightStep(int[,] mas)
        {

            for (int i = SIZE - 2; i >= 0; i--)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    if (mas[i + 1, j] == 0 && mas[i, j] == pl)
                    {
                        mas[i, j] = 0;
                        MessageBox.Show("Выберите нижнюю свободную ячейку!");
                        pl = pl % 2 + 1; //это чтоб после невнрного хода не менялся игрок
                    }
                }
            }
            return false;

        }


        bool isGameOver(int[,] mas)
        {

            for (int i = 0; i < SIZE; i++)   //проверка по строкам и столбцам
            {
                int cntStr = 0;
                int cntStlb = 0;

                for (int j = 0; j < SIZE; j++)
                {
                    if (j < 5 && j > 1)
                        if (mas[i, j] == pl && mas[i, j + 1] == pl && mas[i, j - 1] == pl && (mas[i, j + 2] == pl || mas[i, j - 2] == pl)) cntStr++;
                    if (i < 5 && i > 1)
                        if (mas[i, j] == pl && mas[i + 1, j] == pl && mas[i - 1, j] == pl && (mas[i + 2, j] == pl || mas[i - 2, j] == pl)) cntStlb++;
                }

                if (cntStlb > 0 || cntStr > 0) return true;     
            }


            int mainD = 0;     //проверка по диагоналям
            int secD = 0;
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    if (j < 5 && j > 1 && i < 5 && i > 1)
                    {
                        if (mas[i, j] == pl && mas[i + 1, j + 1] == pl && mas[i - 1, j - 1] == pl && (mas[i + 2, j + 2] == pl || mas[i - 2, j - 2] == pl)) mainD++;
                        if (mas[i, j] == pl && mas[i - 1, j + 1] == pl && mas[i + 1, j - 1] == pl && (mas[i - 2, j + 2] == pl || mas[i + 2, j - 2] == pl)) secD++;
                    }
                }
            }
            if (mainD > 0 || secD > 0) return true;
            return false;
        }




        private void dataGridViewField_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (field[e.RowIndex, e.ColumnIndex] == 0)
            {
                pl = pl % 2 + 1;   //смена хода игрока
                field[e.RowIndex, e.ColumnIndex] = pl;
                rightStep(field);
                showField(field);
                if (isGameOver(field) == true) MessageBox.Show("Победил " + member[pl - 1]);
            }
            //MessageBox.Show(e.RowIndex + " " + e.ColumnIndex);
        }
        

    }
}
