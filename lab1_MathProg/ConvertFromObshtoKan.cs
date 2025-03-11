using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace lab1_MathProg
{
    public partial class ConvertFromObshtoKan : Form
    {
        public ConvertFromObshtoKan()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            int cols =Convert.ToInt32(numericUpDown1.Value);
            int rows =Convert.ToInt32(numericUpDown2.Value);
            columnIndex = cols;
            columnIndexMinMax = cols+1;
            for (int i = 0; i < cols; i++)
            {
                dataGridView2.Columns.Add("X" + i, "X" + i);
                dataGridView1.Columns.Add("X" + i, "X" + i);
            }
            dataGridView1.Columns.Add("zn","Знак");
            dataGridView1.Columns.Add("b", "b");
            dataGridView2.Columns.Add("s", "->");
            dataGridView2.Columns.Add("ds", "к чему стремиться");
            for (int i = 0; i < rows; i++)
            {
                dataGridView1.Rows.Add();
            }
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    dataGridView1[i, j].Value = 0;
                }
            }
            dataGridView2.Rows.Add();
            dataGridView2[cols, 0].Value = "->";
            dataGridView1.Controls.Add(comboBox);
        }
        ComboBox comboBox = new ComboBox();
        ComboBox comboBoxMinMax = new ComboBox();
        //Индекс столбца для отображения элемента
        int columnIndex = 0;
        //Индекс столбца для отображения элемента
        int columnIndexMinMax = 0;
        //Индекс ячейки для отображения элемента
        int rowIndex = 0;
        private void ConvertFromObshtoKan_Load(object sender, EventArgs e)
        {
            comboBox.Visible = false;

            //Создаем перечисление значений
            string[] arrayItem = { ">=", "<=", "=", ">", "<"};
            comboBox.Items.AddRange(arrayItem);

            //Создаем обработчик события(выбор из списка)
            comboBox.SelectedValueChanged += comboBox_SelectedValueChanged;

            comboBoxMinMax.Visible = false;

            //Создаем перечисление значений
            string[] arrayItem1 = { "max", "min" };
            comboBoxMinMax.Items.AddRange(arrayItem1);

            //Создаем обработчик события(выбор из списка)
            comboBoxMinMax.SelectedValueChanged += comboBox_SelectedValueChangedMinMax;

        }
        //Событие происходит всякий раз, при выборе значения из списка
        private void comboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            //Заносим данные в ячейку
            dataGridView1[columnIndex, rowIndex].Value = comboBox.SelectedItem;

            //Скрываем элемент
            comboBox.Visible = false;
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex != columnIndex) return;
            if (e.RowIndex == -1) return;
            //Задаем индекс строки
            rowIndex = e.RowIndex;
            string tmp = Convert.ToString(dataGridView1[e.ColumnIndex, e.RowIndex].Value);
            if (tmp!="")
                comboBox.SelectedIndex = comboBox.Items.IndexOf(tmp);
            else comboBox.SelectedIndex = -1;

            //получаем прямоугольник ячейки
            Rectangle rectangle = dataGridView1.GetCellDisplayRectangle(columnIndex, rowIndex, true);

            //Задаем размеры и месторасположение
            comboBox.Size = new Size(rectangle.Width, rectangle.Height);
            comboBox.Location = new Point(rectangle.X, rectangle.Y);

            //Показываем элемент
            comboBox.Visible = true;
        }

        private void comboBox_SelectedValueChangedMinMax(object sender, EventArgs e)
        {
            //Заносим данные в ячейку
            dataGridView2[columnIndexMinMax, 0].Value = comboBoxMinMax.SelectedItem;

            //Скрываем элемент
            comboBoxMinMax.Visible = false;
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != columnIndexMinMax) return;
            if (e.RowIndex == -1) return;
            string tmp = Convert.ToString(dataGridView2[e.ColumnIndex, 0].Value);
            if (tmp != "")
                comboBoxMinMax.SelectedIndex = comboBoxMinMax.Items.IndexOf(tmp);
            else comboBoxMinMax.SelectedIndex = -1;

            //получаем прямоугольник ячейки
            Rectangle rectangle = dataGridView2.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

            //Задаем размеры и месторасположение
            comboBoxMinMax.Size = new Size(rectangle.Width, rectangle.Height);
            comboBoxMinMax.Location = new Point(rectangle.X, rectangle.Y);

            //Показываем элемент
            comboBoxMinMax.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
