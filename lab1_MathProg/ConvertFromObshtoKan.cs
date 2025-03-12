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
            comboBoxX.Visible = false;
            comboBox.Visible = false;
            comboBoxMinMax.Visible = false;
            comboBoxMinMax.SelectedIndex = -1;
            comboBoxX.SelectedIndex = -1;
            comboBox.SelectedIndex = -1;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();
            int cols =Convert.ToInt32(numericUpDown1.Value);
            int rows =Convert.ToInt32(numericUpDown2.Value);
            columnIndex = cols;
            columnIndexMinMax = cols+1;
            for (int i = 0; i < cols; i++)
            {
                dataGridView2.Columns.Add("X" + i, "X" + (i+1));
                dataGridView1.Columns.Add("X" + i, "X" + (i + 1));
                dataGridView3.Columns.Add("X" + i, "X" + (i + 1));
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
            for (int j = 0; j < rows; j++)
            {
                dataGridView1[cols+1, j].Value = 0;
            }
            dataGridView2.Rows.Add();
            dataGridView3.Rows.Add();
            dataGridView2[cols, 0].Value = "->";
            dataGridView1.Controls.Add(comboBox);
            dataGridView2.Controls.Add(comboBoxMinMax);
            dataGridView3.Controls.Add(comboBoxX);
        }
        ComboBox comboBox = new ComboBox();
        ComboBox comboBoxMinMax = new ComboBox();
        ComboBox comboBoxX = new ComboBox();
        int columnX = 0;
        //Индекс столбца для отображения элемента
        int columnIndex = 0;
        //Индекс столбца для отображения элемента
        int columnIndexMinMax = 0;
        //Индекс ячейки для отображения элемента
        int rowIndex = 0;
        private void ConvertFromObshtoKan_Load(object sender, EventArgs e)
        {

            comboBoxX.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMinMax.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBoxX.Visible = false;
            comboBox.Visible = false;
            comboBoxMinMax.Visible = false;
            //Создаем перечисление значений
            string[] arrayItem = { ">=", "<=", "="};
            comboBox.Items.AddRange(arrayItem);

            //Создаем обработчик события(выбор из списка)
            comboBox.SelectedValueChanged += comboBox_SelectedValueChanged;

            comboBoxMinMax.Visible = false;

            //Создаем перечисление значений
            string[] arrayItem1 = { "max", "min" };
            comboBoxMinMax.Items.AddRange(arrayItem1);

            //Создаем обработчик события(выбор из списка)
            comboBoxMinMax.SelectedValueChanged += comboBox_SelectedValueChangedMinMax;

            comboBoxX.Visible = false;

            //Создаем перечисление значений
            string[] arrayItem2 = { ">=0", "<=0" };
            comboBoxX.Items.AddRange(arrayItem2);

            //Создаем обработчик события(выбор из списка)
            comboBoxX.SelectedValueChanged += comboBox_SelectedValueChangedX;

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
            else 
                comboBox.SelectedIndex = -1;

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
            else 
                comboBoxMinMax.SelectedIndex = -1;
            
            //получаем прямоугольник ячейки
            Rectangle rectangle = dataGridView2.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

            //Задаем размеры и месторасположение
            comboBoxMinMax.Size = new Size(rectangle.Width, rectangle.Height);
            comboBoxMinMax.Location = new Point(rectangle.X, rectangle.Y);

            //Показываем элемент
            comboBoxMinMax.Visible = true;
        }

        private void comboBox_SelectedValueChangedX(object sender, EventArgs e)
        {

            //Заносим данные в ячейку
            dataGridView3[columnX, 0].Value = comboBoxX.SelectedItem;

            //Скрываем элемент
            comboBoxX.Visible = false;

        }
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            comboBox_SelectedValueChangedX(sender, e);
            string tmp = Convert.ToString(dataGridView3[e.ColumnIndex, 0].Value);
            int save = comboBoxX.SelectedIndex;
            columnX = e.ColumnIndex;
            if (tmp != "")
                comboBoxX.SelectedIndex = comboBoxX.Items.IndexOf(tmp);
            else 
                comboBoxX.SelectedIndex = -1;
            
            //получаем прямоугольник ячейки
            Rectangle rectangle = dataGridView3.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

            //Задаем размеры и месторасположение
            comboBoxX.Size = new Size(rectangle.Width, rectangle.Height);
            comboBoxX.Location = new Point(rectangle.X, rectangle.Y);

            //Показываем элемент
            comboBoxX.Visible = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Columns.Count == 0|| dataGridView2.Columns.Count == 0|| dataGridView3.Columns.Count == 0) { MessageBox.Show("Не введены данные"); return; }
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                for (int j = 0; j < dataGridView1.RowCount; j++)
                    if (Convert.ToString(dataGridView1[i, j].Value) == "") { MessageBox.Show("Не должно быть незаполненныйх полей");return; }
            for (int i = 0; i < dataGridView2.ColumnCount; i++)
                for (int j = 0; j < dataGridView2.RowCount; j++)
                    if (Convert.ToString(dataGridView2[i, j].Value) == "") { MessageBox.Show("Не должно быть незаполненныйх полей"); return; }
            for (int i = 0; i < dataGridView3.ColumnCount; i++)
                for (int j = 0; j < dataGridView3.RowCount; j++)
                    if (Convert.ToString(dataGridView3[i, j].Value) == "") { MessageBox.Show("Не должно быть незаполненныйх полей"); return; }
            int varCount = dataGridView3.ColumnCount;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                if(Convert.ToString( dataGridView1[columnIndex,i].Value)!="=")
                    varCount++; 
            List<string> varNames = new List<string>();
            int varInd = 0;
            int countAdded = 0;
            for (varInd = 0;varInd< dataGridView3.Columns.Count; varInd++)
            {
                if (Convert.ToString(dataGridView3[varInd, 0].Value) == "<=0")
                    varCount++;
                if (Convert.ToString(dataGridView3[varInd, 0].Value) == ">=0")
                {
                    varNames.Add("X" + (varInd + 1));
                    countAdded++;
                }
            }
  
            for (; countAdded < varCount; varInd++)
            {
                varNames.Add("X" + (varInd + 1));
                countAdded++;
            }

            varNames.Add("b");
            countAdded = 0;
            double[,] ratio = new double[dataGridView1.RowCount + 1, varNames.Count];
            for (varInd = 0; varInd < dataGridView3.Columns.Count; varInd++)
                if (Convert.ToString(dataGridView3[varInd, 0].Value) == ">=0")
                {
                    ratio[dataGridView1.RowCount, varInd] = Convert.ToDouble(dataGridView2[varInd, 0].Value);
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        ratio[i, countAdded] = Convert.ToDouble(dataGridView1[varInd, i].Value);
                    }
                    countAdded++;
                }
            for (varInd = 0; varInd < dataGridView3.Columns.Count; varInd++)
            {                
                if (Convert.ToString(dataGridView3[varInd, 0].Value) == "<=0")
                {
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        ratio[i, countAdded] = Convert.ToDouble(dataGridView1[varInd, i].Value);
                        ratio[i, countAdded + 1] = Convert.ToDouble(dataGridView1[varInd, i].Value);
                    }
                    ratio[dataGridView1.RowCount, countAdded] = Convert.ToDouble(dataGridView2[varInd, 0].Value);
                    ratio[dataGridView1.RowCount, countAdded + 1] = Convert.ToDouble(dataGridView2[varInd, 0].Value);
                    countAdded += 2;
                }
            }


            for(int i = 0; i < dataGridView1.RowCount; i++)
            {
                ratio[i, varNames.Count - 1] = Convert.ToDouble(dataGridView1[dataGridView1.ColumnCount - 1, i].Value);
                if (Convert.ToString( dataGridView1[columnIndex,i].Value) != "=")
                {
                    if(Convert.ToString(dataGridView1[columnIndex, i].Value) == ">=0")
                        ratio[i, countAdded++] = -1;
                    else
                        ratio[i, countAdded++] = 1;
                }
                    
            }
            if (Convert.ToString(dataGridView2[dataGridView2.Columns.Count - 1, 0].Value) == "max")
            {
                for (int i = 0; i < varNames.Count; i++)
                {
                    ratio[dataGridView1.RowCount,i] *= -1;
                }
            }


            ReturnValue1 = varNames;
            ReturnValue2 =ratio;
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
        public List<string> ReturnValue1 { get; set; }
        public double[,] ReturnValue2 { get; set; }
    }
}
