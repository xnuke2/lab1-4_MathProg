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
        int rowIndGL = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCreatetableToConditions_Click(object sender, EventArgs e)
        {
            dataGridViewConditions.Rows.Clear();
            dataGridViewConditions.Columns.Clear();
            int baseX =Convert.ToInt32(numericUpDownOgr.Value);
            int libertyX =Convert.ToInt32(numericUpDownBase.Value);
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
            if ( dataGridViewConditions.Columns.Count == 0) { MessageBox.Show("Не введены данные"); return; }
            for (int i = 0; i < dataGridViewConditions.ColumnCount; i++)
                for (int j = 0; j < dataGridViewConditions.RowCount; j++)
                    if (Convert.ToString(dataGridViewConditions[i, j].Value) == "") { MessageBox.Show("Не должно быть незаполненныйх полей"); return; }

            dataGridViewRezult.Rows.Clear();
            dataGridViewRezult.Columns.Clear();
            
            
            int columns = Convert.ToInt32(dataGridViewConditions.Columns.Count) - 1;
            int rows = Convert.ToInt32(dataGridViewConditions.Rows.Count);


            
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
                    matrix[i, j] = Convert.ToDouble(Convert.ToString( dataGridViewConditions[j+1,i].Value).Replace(",","."));
                }
            }
            int ch = 0;



            ch = 0;
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                    if (matrix[j, i] == 1)
                    {
                        ch++;
                        for (int k = 0; k < rows; k++)
                        {
                            if (matrix[k, i] != 0 && k != j)
                            {
                                ch--;
                                break;
                            }
                        }
                    }

            }
            if (ch != baseNames.Length - 1)
            {
                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, columns - 1] < 0)
                    {
                        //решать двойственным симплексом
                        dataGridViewAnswer.Rows.Clear();
                        dataGridViewAnswer.Columns.Clear();
                        dataGridViewAnswer.Columns.Add("b", "Ошибка");
                        dataGridViewAnswer.Rows.Add("Решение отсутствует");
                        return;
                    };
                }
                string[] newBaseName =new string[baseNames.Length+1];
                for(int i = 0;i < baseNames.Length-1; i++)
                {
                    newBaseName[i] ="Y" + (i + 1);
                }
                newBaseName[baseNames.Length-1] = "Z";
                newBaseName[baseNames.Length] = "Z";
                double[,] newMatrix = new double[rows+1,columns+rows-1];
                for(int i = 0; i < columns - 1; i++)
                {
                    for(int j = 0;j < rows; j++)
                    {
                        newMatrix[j,i] = matrix[j,i];
                    }
                }
                for (int j = 0; j < rows; j++)
                {
                    newMatrix[j, columns + rows-2] = matrix[j, columns - 1];
                }
                for(int j = columns - 1; j< columns + rows-2; j++)
                {
                    newMatrix[j - columns + 1, j] = 1;
                }
                for (int i = 0; i < columns - 1; i++)
                {
                    for (int j = 0; j < rows-1; j++)
                    {
                        newMatrix[rows, i] -= matrix[j, i];
                    }
                }
                //for (int j = 0; j < rows; j++)
                //{
                //    newMatrix[rows, columns + rows - 2] -= matrix[j, columns  - 1];
                //}
                rowIndGL = 0;
                Mmetod(columns + rows-1, rows + 1, newBaseName, newMatrix);
            } 
            else
            {
                rowIndGL = 0;
                dataGridViewRezult.Columns.Add("Xk", "Xk");
                for (int i = 0; i < columns - 1; i++)
                {
                    dataGridViewRezult.Columns.Add("x" + (i + 1), "x" + (i + 1));
                }
                dataGridViewRezult.Columns.Add("b", "b");
                dataGridViewRezult.Columns.Add("s", "s");
                chooseMetod(columns, rows, baseNames, matrix);

            }
                    

        }
        private void chooseMetod(int columns, int rows, int[] baseNames, double[,] matrix)
        {

            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, columns - 1] < 0)
                {
                    dvSimplex(columns, rows, baseNames, matrix);
                    return;
                };
            }
            simplex(columns, rows, baseNames, matrix);
        }

        private void simplex(int columns, int rows, int[] baseNames, double[,] matrix)
        {
          
            DataGridViewCellStyle styleGreen = new DataGridViewCellStyle();
            styleGreen.BackColor = Color.Green;
            styleGreen.ForeColor = Color.Black;
            //row.Cells[color.Index].Style = style;
            DataGridViewCellStyle styleRed = new DataGridViewCellStyle();
            styleRed.BackColor = Color.Red;
            styleRed.ForeColor = Color.Black;
            int indSimRel = 0;
            while (true)
            {

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
                    int fsd = Convert.ToInt32(numericUpDownBase.Value);
                    dataGridViewAnswer.Rows.Clear();
                    dataGridViewAnswer.Columns.Clear();
                    for (int i = 0; i < fsd; i++)
                    {
                        dataGridViewAnswer.Columns.Add("x" + (i + 1), "x" + (i + 1));
                    }
                    dataGridViewAnswer.Columns.Add("b", "Z");
                    dataGridViewAnswer.Rows.Add();
                    for (int i = 0; i < rows; i++)
                       dataGridViewAnswer[i, 0].Value = 0;

                    
                    for (int i = 0; i < rows - 1; i++)
                    {
                        if (baseNames[i] > rows - 1) continue;
                        else dataGridViewAnswer[baseNames[i], 0].Value = matrix[i, columns - 1];
                    }
                    dataGridViewAnswer[fsd, 0].Value = matrix[rows - 1, columns - 1];
                    //dataGridViewAnswer.Rows.Add();
                    
                    //for (int j = 0; j < rows - 1; j++)
                    //{
                    //    for (int k = 0; k < rows - 1; k++)
                    //        if (baseNames[k]== j + fsd - 1)
                    //        {
                    //            dataGridViewAnswer[j, 1].Value = "недефицитный";
                    //            break;
                    //        }

                    //     if(Convert.ToString(dataGridViewAnswer[j, 1].Value)=="")       
                    //            dataGridViewAnswer[j , 1].Value = "дефицитный (ценность - " + matrix[rows - 1, j + rows-1] + ")";
                    //}
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
                    dataGridViewAnswer.Rows.Clear();
                    dataGridViewAnswer.Columns.Clear();
                    dataGridViewAnswer.Columns.Add("b", "Ошибка");
                    dataGridViewAnswer.Rows.Add("Оптимальное решение отсутствует");
                    //оптимальное отсутсвуект
                    return;
                }
                min = int.MaxValue;
                indSimRel = 0;
                for (int i = 0; i < rows; i++)
                    if (simRel[i] < min && simRel[i] != 0)
                    {
                        min = simRel[i];
                        indSimRel = i;
                    }
                //сохранение итерации
                for (int i = 0; i < rows - 1; i++)
                {
                    dataGridViewRezult.Rows.Add("x" + (baseNames[i] + 1));
                    dataGridViewRezult.Rows[rowIndGL + i].Cells[columns + 1].Value = simRel[i];
                }
                dataGridViewRezult.Rows.Add("Z");
                dataGridViewRezult.Rows[rows - 1].Cells[columns + 1].Value = simRel[rows - 1];

                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < columns; j++)
                    {
                        dataGridViewRezult[+j + 1, rowIndGL + i].Value = matrix[i, j];
                    }
                
                for (int i = 0; i < rows; i++)
                    dataGridViewRezult[indMin + 1, rowIndGL + i].Style = styleGreen;
                for (int j = 0; j < columns + 1; j++)
                    dataGridViewRezult[j + 1, rowIndGL + indSimRel].Style = styleRed;
                dataGridViewRezult.Rows.Add();
                rowIndGL += rows + 1;
                
                //переход к следующему решению
                baseNames[indSimRel] = indMin;
                double tmp = matrix[indSimRel, indMin];
                for (int i = 0; i < columns; i++)
                {
                    matrix[indSimRel, i] = matrix[indSimRel, i] / tmp;
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
        private void Mmetod(int columns, int rows, string[] baseNames, double[,] matrix)
        {
            dataGridViewRezult.Rows.Clear();
            dataGridViewRezult.Columns.Clear();
            rowIndGL = 0;
            DataGridViewCellStyle styleGreen = new DataGridViewCellStyle();
            styleGreen.BackColor = Color.Green;
            styleGreen.ForeColor = Color.Black;
            //row.Cells[color.Index].Style = style;
            DataGridViewCellStyle styleRed = new DataGridViewCellStyle();
            styleRed.BackColor = Color.Red;
            styleRed.ForeColor = Color.Black;
            dataGridViewRezult.Columns.Add("Basis", "Базис");
            for (int i=0; i<columns-rows+1; i++)
                dataGridViewRezult.Columns.Add("X" + (i + 1), "X" + (i + 1));
            for (int i = 0; i < columns - (columns - rows + 2); i++)
                dataGridViewRezult.Columns.Add("Y" + (i + 1), "Y" + (i + 1));
            dataGridViewRezult.Columns.Add("B","B" );
            dataGridViewRezult.Columns.Add("Si", "Si");
            bool noZero = true;
            List<int> deletedColumnsIndex  =new List<int>();
            while (true)
            {
                if (noZero)
                {
                    int chI;
                    for (chI = 0; chI < columns-3; chI++)
                        if (Math.Abs(matrix[rows - 1, chI])> 1E-10 ) break;
                    if (chI == columns-3) noZero = false;
                }
                
                if (noZero)
                    for (int i = 0; i < rows; i++)
                    {
                        dataGridViewRezult.Rows.Add(baseNames[i]);

                        for (int j = 0; j < columns; j++)
                        {
                            if (deletedColumnsIndex.Contains(j))
                                dataGridViewRezult[j + 1, rowIndGL].Value = "-";
                            else
                                dataGridViewRezult[j + 1, rowIndGL].Value = matrix[i, j];
                        }
                        rowIndGL++;

                    }
                else
                {
                    for (int i = 0; i < rows - 1; i++)
                    {
                        dataGridViewRezult.Rows.Add(baseNames[i]);

                        for (int j = 0; j < columns; j++)
                        {
                            if (deletedColumnsIndex.Contains(j))
                                dataGridViewRezult[j + 1, rowIndGL].Value = "-";
                            else
                                dataGridViewRezult[j + 1, rowIndGL].Value = matrix[i, j];
                        }
                        rowIndGL++;
                    }

                    dataGridViewRezult.Rows.Add(baseNames[rows-1]);
                    for (int j = 0; j < columns; j++)
                        dataGridViewRezult[j + 1, rowIndGL].Value = "-";
                    rowIndGL++;
                }

                //int countZero;
                //for (countZero = 0; countZero < columns; countZero++)
                //    if (matrix[rows - 2, countZero] != 0) break;
                ////нахождение ответа
                //if (countZero == columns)
                //{
                //    return;
                //}
                double min = double.MaxValue;
                int indexMinColumns = -1;
                for (int i = 0; i < columns-3; i++)
                    if(noZero)
                    {                        
                        if (matrix[rows - 1, i] < min)
                        {
                            min = matrix[rows - 1, i];
                            indexMinColumns = i;
                        }
                    }
                    else
                        if (matrix[rows - 2, i] < min)
                        {
                            min = matrix[rows - 2, i];
                            indexMinColumns = i;
                        }
                if (min >= 0)
                {
                    //найдено решение
                    dataGridViewAnswer.Rows.Clear();
                    dataGridViewAnswer.Columns.Clear();
                    for (int i = 0; i < columns - 3; i++)
                    {
                        dataGridViewAnswer.Columns.Add("X" + (i + 1), "X" + (i + 1));
                    }
                    dataGridViewAnswer.Columns.Add("Zmax", "Zmax" );
                    for (int i = 0; i < dataGridViewAnswer.ColumnCount; i++)
                    {
                        dataGridViewAnswer[i, 0].Value = 0;
                        for (int j = 0; j < baseNames.Length-2;j++)
                            if (dataGridViewAnswer.Columns[i].HeaderText == baseNames[j]) dataGridViewAnswer[i,0].Value=matrix[j,columns-1];

                    }
                    dataGridViewAnswer[dataGridViewAnswer.ColumnCount - 1, 0].Value = matrix[rows - 2, columns - 1];
                    return;
                }
                for(int i = 0;i<rows; i++)
                    dataGridViewRezult[indexMinColumns+1, rowIndGL - rows +i].Style =styleGreen;
                double[] Si = new double[rows];
                for(int i = 0;i< rows; i++)
                    if (matrix[i, columns - 1] > 0&& matrix[i, indexMinColumns] > 0) 
                    { 
                        Si[i] = matrix[i, columns - 1] / matrix[i, indexMinColumns];
                        dataGridViewRezult[dataGridViewRezult.ColumnCount - 1, rowIndGL-rows + i].Value =Si[i];
                    }

                min =double.MaxValue;
                int indexMinRows = -1;
                for (int i = 0; i < rows-2; i++)
                    if (min > Si[i] && Si[i]!=0)
                    { 
                        min = Si[i];
                        indexMinRows = i;
                    }

                for (int i = 0; i < dataGridViewRezult.ColumnCount; i++)
                    dataGridViewRezult[i, rowIndGL - rows + indexMinRows].Style = styleRed;
                double ratio = matrix[indexMinRows, indexMinColumns];
                for (int i = 0;i<columns; i++)
                {
                    matrix[indexMinRows,i] /=ratio;
                }
                for (int i = 0; i < rows; i++)
                    if (i != indexMinRows)
                    {
                        double rat = matrix[i, indexMinColumns];
                        for (int j = 0; j < columns; j++)
                        {
                            matrix[i, j] -= rat * matrix[indexMinRows, j];
                            if (matrix[i, j] < -1E16) matrix[i, j] = 0;
                        }
                            
                    }


                for (int i = 0;i<dataGridViewRezult.Columns.Count; i++)
                    if (dataGridViewRezult.Columns[i].HeaderText == baseNames[indexMinRows] && baseNames[indexMinRows].Contains("Y")) 
                    {
                        deletedColumnsIndex.Add(i - 1);
                        break; 
                    }
                baseNames[indexMinRows] = "X" + (indexMinColumns + 1);
                dataGridViewRezult.Rows.Add();
                rowIndGL++;
            }


                    


        }

        private void dvSimplex(int columns, int rows, int[] baseNames, double[,] matrix)
        {
            DataGridViewCellStyle styleGreen = new DataGridViewCellStyle();
            styleGreen.BackColor = Color.Green;
            styleGreen.ForeColor = Color.Black;
            //row.Cells[color.Index].Style = style;
            DataGridViewCellStyle styleRed = new DataGridViewCellStyle();
            styleRed.BackColor = Color.Red;
            styleRed.ForeColor = Color.Black;
            for (int i = 0; i < rows - 1; i++)
            {
                dataGridViewRezult.Rows.Add("x" + (baseNames[i] + 1));

            }
            dataGridViewRezult.Rows.Add("Z");


            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                {
                    dataGridViewRezult[j + 1, rowIndGL + i].Value = matrix[i, j];
                }

            
            rowIndGL += rows;
            bool findNeg =false;
            for (int i = 0; i < rows; i++)
                if (matrix[i, columns - 1] < 0)
                    for (int j = 0; j < columns - 1; j++)
                        if (matrix[i, j] < 0)
                        {
                            findNeg = true;
                            break;
                        }

            if (!findNeg)
            {
                dataGridViewAnswer.Rows.Clear();
                dataGridViewAnswer.Columns.Clear();
                dataGridViewAnswer.Columns.Add("b", "Ошибка");
                dataGridViewAnswer.Rows.Add("неразрешима в силу несовместности системы ограничений");
                return;
            }
            int enablingRow = -1;
            double min=double.MaxValue;
            double?[] d=new double?[columns];
            for (int i = 0; i < rows-1; ++i)
            {
                if(matrix[i,columns-1] < min)
                {
                    min = matrix[i,columns-1];
                    enablingRow = i;
                }
            }
            for(int i = 0; i < columns+1; i++)
            {
                dataGridViewRezult[i , rowIndGL - rows + enablingRow-1].Style = styleRed;
            }
            int enablingColumn = -1;
            min = double.MaxValue;
            for (int i = 0;i < columns-1; ++i) 
                if (matrix[enablingRow, i] < 0)
                {
                    d[i] = Math.Abs(matrix[rows - 1, i] / matrix[enablingRow, i]);
                    if (d[i] < min)
                    {
                        enablingColumn = i;
                        min =Convert.ToDouble(d[i]);
                    }
                }

            dataGridViewRezult.Rows.Add("d");
            for (int i = 0; i < rows + 1; i++)
            {
                dataGridViewRezult[enablingColumn + 1, rowIndGL - rows + i].Style = styleGreen;
            }
            for (int i = 0; i < columns; i++)
            {
                dataGridViewRezult[i+1, rowIndGL].Value = d[i];
            }
            dataGridViewRezult.Rows.Add();
            rowIndGL+=2;

            double value = matrix[enablingRow, enablingColumn];
            for (int i = 0; i < columns; i++)
            {
                matrix[enablingRow, i] /= value;
            }

            for(int i = 0; i < rows; i++)
                if(enablingRow != i)
                {
                    double ratio = matrix[i, enablingColumn] / matrix[enablingRow, enablingColumn];
                    for (int j = 0; j < columns; j++)
                    {
                        matrix[i, j] -= ratio * matrix[enablingRow, j];
                    }
                }

            baseNames[enablingRow]=enablingColumn;

            chooseMetod(columns, rows, baseNames, matrix);
        }

        double TruncateToSignificantDigits( double d, int digits)
        {
            if (d == 0)
                return 0;

            double scale = Math.Pow(10, Math.Floor(Math.Log10(Math.Abs(d))) + 1 - digits);
            return scale * Math.Truncate(d / scale);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (var form = new ConvertFromObshtoKan())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    List<string> varNames = form.ReturnValue1;            //values preserved after close
                    double[,] ratio = form.ReturnValue2;
                    dataGridViewConditions.Rows.Clear();
                    dataGridViewConditions.Columns.Clear();
                    dataGridViewConditions.Columns.Add("xk", "Xk");
                    for (int i = 0;i< varNames.Count;i++)
                        dataGridViewConditions.Columns.Add(varNames[i], varNames[i]);
                    int indexOfNameRows = ratio.GetLength(1) - ratio.GetLength(0);
                    for (int i = 0; i < ratio.GetLength(0); i++)
                    {
                        dataGridViewConditions.Rows.Add();
                        dataGridViewConditions[0, i].Value = varNames[indexOfNameRows++];
                        for (int j = 0;j< ratio.GetLength(1); j++)
                            dataGridViewConditions[j + 1, i].Value = ratio[i,j];
                    }
                    
                    dataGridViewConditions[0, dataGridViewConditions.Rows.Count - 1].Value = "Z";

                }
            }
        }
    }
}
