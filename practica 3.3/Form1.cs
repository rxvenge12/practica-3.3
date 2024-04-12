using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practica_3._3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Создаем двумерный массив (матрицу) размером 8x5
            int[,] matrix = new int[8, 5];

            Random random = new Random();

            // Заполняем матрицу случайными целыми числами из интервала [20, 40]
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix[i, j] = random.Next(20, 41); // [20, 40]
                }
            }

            // Отображаем матрицу в DataGridView
            dataGridView1.RowCount = 8;
            dataGridView1.ColumnCount = 5;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    dataGridView1[j, i].Value = matrix[i, j];
                }
            }

            // Ищем номер строки, содержащей не менее двух чётных чисел
            int rowWithTwoOrMoreEvens = -1; // Переменная для хранения номера строки, -1 если не найдено
            for (int i = 0; i < 8; i++)
            {
                int countEven = 0; // Количество четных чисел в строке
                for (int j = 0; j < 5; j++)
                {
                    if (matrix[i, j] % 2 == 0)
                        countEven++;
                }
                if (countEven >= 2)
                {
                    rowWithTwoOrMoreEvens = i + 1; // Нумерация строк с единицы
                    break;
                }
            }

            // Выводим результат на форму
            if (rowWithTwoOrMoreEvens != -1)
                MessageBox.Show($"Номер строки, содержащей не менее двух четных чисел: {rowWithTwoOrMoreEvens}", "Результат");
            else
                MessageBox.Show("В матрице нет строки, содержащей не менее двух четных чисел", "Результат");
        }

    }
}
