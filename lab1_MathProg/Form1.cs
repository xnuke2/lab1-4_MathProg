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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCreatetableToConditions_Click(object sender, EventArgs e)
        {
            dataGridViewConditions.Rows.Clear();
            dataGridViewConditions.Columns.Clear();
            int baseX =Convert.ToInt32(numericUpDownBase.Value);
            int libertyX =Convert.ToInt32(numericUpDownLiberty.Value);
            dataGridViewConditions.Columns.Add("Xk" , "Xk" );
            for (int i = 0; i < baseX + libertyX ; i++)
            {
                dataGridViewConditions.Columns.Add("x"+(i+1),"x"+(i+1));
            }
            dataGridViewConditions.Columns.Add("b", "b" );
            for (int i = libertyX; i < baseX + libertyX; i++)
            {
                dataGridViewConditions.Rows.Add("x"+(i+1));
            }
            dataGridViewConditions.Rows.Add("Z");
            for (int i = 0;i < baseX + 1; i++)
                for (int j = 1;j < baseX + libertyX+2; j++)
                {
                    dataGridViewConditions.Rows[i].Cells[j].Value = 0;
                }
            
        }

        private void buttonCulculate_Click(object sender, EventArgs e)
        {
            dataGridViewRezult.Rows.Clear();
            dataGridViewRezult.Columns.Clear();
            int rowIndGL = 0;
            int columns = Convert.ToInt32(dataGridViewConditions.Columns.Count) - 1;
            int rows = Convert.ToInt32(dataGridViewConditions.Rows.Count);
            dataGridViewRezult.Columns.Add("Xk", "Xk");
            for (int i = 0; i < columns - 1; i++)
            {
                dataGridViewRezult.Columns.Add("x" + (i + 1), "x" + (i + 1));
            }
            dataGridViewRezult.Columns.Add("b", "b");
            dataGridViewRezult.Columns.Add("s", "s");
            
            int[] baseNames = new int[rows];
            for (int i = 0; i < rows-1; i++)
            {
                baseNames[i] = columns -rows+i;
            }
            double[,] matrix = new double[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = Convert.ToDouble(dataGridViewConditions.Rows[i].Cells[j + 1].Value);
                }
            }
            DataGridViewCellStyle styleGreen = new DataGridViewCellStyle();
            styleGreen.BackColor = Color.Green;
            styleGreen.ForeColor = Color.Black;
            //row.Cells[color.Index].Style = style;
            DataGridViewCellStyle styleRed = new DataGridViewCellStyle();
            styleRed.BackColor = Color.Red;
            styleRed.ForeColor = Color.Black;
            int indSimRel = 0;
            while (true) { 

                double min = 0;
                int indMin = 0;
                for (int i = 0; i < columns; i++)
                {
                    if (matrix[rows - 1, i] < min)
                    {
                        min = matrix[rows - 1, i];
                        indMin = i;
                    }
                }
                if (min >= 0)
                {
                    //сохранение итерации
                    for (int i = 0; i < rows - 1; i++)
                    {
                        dataGridViewRezult.Rows.Add("x" + (baseNames[i] + 1));
                        
                    }
                    dataGridViewRezult.Rows.Add("Z");
                    

                    for (int i = 0; i < rows; i++)
                        for (int j = 0; j < columns; j++)
                        {
                            dataGridViewRezult[+j + 1, rowIndGL + i].Value = matrix[i, j];
                        }

                    dataGridViewRezult.Rows.Add();
                    rowIndGL += rows + 1;

                    dataGridViewAnswer.Rows.Clear();
                    dataGridViewAnswer.Columns.Clear();
                    for (int i = 0; i < columns - 1; i++)
                    {
                        dataGridViewAnswer.Columns.Add("x" + (i + 1), "x" + (i + 1));
                    }
                    dataGridViewAnswer.Columns.Add("b", "b");
                    dataGridViewAnswer.Rows.Add();
                    for(int i=0;i<columns; i++)
                       dataGridViewAnswer[i, 0].Value = 0;

                    for (int i = 0; i < rows - 1; i++)
                    {
                        dataGridViewAnswer[baseNames[i], 0].Value = matrix[i, columns - 1];
                    }
                    dataGridViewAnswer[columns-1,0].Value=matrix[rows-1,columns-1];
                    
                    return;
                }
                double[] simRel = new double[rows];
                bool find = false;
                for (int i = 0; i < rows; i++)
                    if (matrix[i, indMin] > 0)
                    {
                        simRel[i] = matrix[i, columns - 1] / matrix[i, indMin];
                        find = true;
                    }


                if (!find)
                {
                    dataGridViewAnswer.Columns.Add("b", "Ошибка");
                    dataGridViewAnswer.Rows.Add("Оптимальное решение отсутствует");
                    //оптимальное отсутсвуект
                    return;
                }
                min = int.MaxValue;
                indSimRel = 0;
                for (int i = 0; i < rows; i++)
                    if (simRel[i] < min&& simRel[i]!=0)
                    {
                        min = simRel[i];
                        indSimRel = i;
                    }
                //сохранение итерации
                for (int i = 0; i < rows-1; i++)
                {
                    dataGridViewRezult.Rows.Add("x" +(baseNames[i]+1));
                    dataGridViewRezult.Rows[rowIndGL + i].Cells[columns + 1].Value = simRel[i];
                }
                dataGridViewRezult.Rows.Add("Z");
                dataGridViewRezult.Rows[rows-1].Cells[columns + 1].Value = simRel[rows-1];

                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < columns; j++)
                    {
                        dataGridViewRezult[+j + 1,rowIndGL+ i ].Value = matrix[i, j];
                    }
                
                for(int i=0; i<rows; i++)
                    dataGridViewRezult[indMin+1, rowIndGL +i].Style = styleGreen;
                for(int j=0; j<columns+1; j++)
                    dataGridViewRezult[ j + 1, rowIndGL + indSimRel].Style = styleRed;
                dataGridViewRezult.Rows.Add();
                rowIndGL += rows+1;
                
                //переход к следующему решению
                baseNames[indSimRel] = indMin;
                double tmp = matrix[indSimRel, indMin];
                for (int i = 0; i < columns; i++)
                {
                    matrix[indSimRel, i] = matrix[indSimRel, i] /tmp;
                }
                double[] tmp2 = new double[rows];
                for (int i = 0; i < rows; i++)
                    tmp2[i] = matrix[i, indMin];
                for (int i = 0; i < rows; i++)
                {
                    if (i == indSimRel) continue;
                    for (int j = 0; j < columns; j++)
                    {
                        matrix[i, j] = matrix[i, j] + matrix[indSimRel, j] * (-tmp2[i]);
                    }
                }

            }
        }

    }
}
