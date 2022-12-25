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
        string[] member = { "Игрок1" };

        

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
                    if (mas[i + 1, j] == 0 && mas[i, j] == 1)
                    {
                        mas[i, j] = 0;
                        MessageBox.Show("Выберите нижнюю свободную ячейку!");
                        break;
                    }
                    else continue;
                }
            }
            return true;
        }



        bool isGameOver(int[,] mas)
        {

            for (int i = 0; i < SIZE; i++)   //ПРОВЕРКА ПО СТРОКАМ И СТОЛБЦАМ
            {
                int cntStr = 0;
                int cntStlb = 0;

                for (int j = 0; j < SIZE; j++)
                {
                    if (j < 5 && j > 1)
                        if (mas[i, j] == 1 && mas[i, j + 1] == 1 && mas[i, j - 1] == 1 && (mas[i, j + 2] == 1 || mas[i, j - 2] == 1)) cntStr++;
                    if (i < 5 && i > 1)
                        if (mas[i, j] == 1 && mas[i + 1, j] == 1 && mas[i - 1, j] == 1 && (mas[i + 2, j] == 1 || mas[i - 2, j] == 1)) cntStlb++;
                }

                if (cntStlb > 0 || cntStr > 0) return true;     
            }


            int mainD = 0;     //ПРОВЕРКА ПО ДИАГОНАЛЯМ
            int secD = 0;
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    if (j < 5 && j > 1 && i < 5 && i > 1)
                    {
                        if (mas[i, j] == 1 && mas[i + 1, j + 1] == 1 && mas[i - 1, j - 1] == 1 && (mas[i + 2, j + 2] == 1 || mas[i - 2, j - 2] == 1)) mainD++;
                        if (mas[i, j] == 1 && mas[i - 1, j + 1] == 1 && mas[i + 1, j - 1] == 1 && (mas[i - 2, j + 2] == 1 || mas[i + 2, j - 2] == 1)) secD++;
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
                field[e.RowIndex, e.ColumnIndex] = 1;
                rightStep(field);
                showField(field);
                if (isGameOver(field) == true) MessageBox.Show("Победил " + member[0]);
            }
            //MessageBox.Show(e.RowIndex + " " + e.ColumnIndex);
        }
        

    }
}
