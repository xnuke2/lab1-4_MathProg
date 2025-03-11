namespace lab1_MathProg
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericUpDownLiberty = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBase = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewConditions = new System.Windows.Forms.DataGridView();
            this.buttonCreatetableToConditions = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonCulculate = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewRezult = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridViewAnswer = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLiberty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConditions)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRezult)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAnswer)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownLiberty
            // 
            this.numericUpDownLiberty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownLiberty.Location = new System.Drawing.Point(232, 28);
            this.numericUpDownLiberty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownLiberty.Name = "numericUpDownLiberty";
            this.numericUpDownLiberty.Size = new System.Drawing.Size(102, 20);
            this.numericUpDownLiberty.TabIndex = 0;
            this.numericUpDownLiberty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownBase
            // 
            this.numericUpDownBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownBase.Location = new System.Drawing.Point(232, 56);
            this.numericUpDownBase.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownBase.Name = "numericUpDownBase";
            this.numericUpDownBase.Size = new System.Drawing.Size(102, 20);
            this.numericUpDownBase.TabIndex = 1;
            this.numericUpDownBase.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Количество свободных переменных";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Количество базовых переменных";
            // 
            // dataGridViewConditions
            // 
            this.dataGridViewConditions.AllowUserToAddRows = false;
            this.dataGridViewConditions.AllowUserToDeleteRows = false;
            this.dataGridViewConditions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewConditions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridViewConditions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewConditions.Location = new System.Drawing.Point(6, 82);
            this.dataGridViewConditions.Name = "dataGridViewConditions";
            this.dataGridViewConditions.RowHeadersVisible = false;
            this.dataGridViewConditions.RowHeadersWidth = 51;
            this.dataGridViewConditions.Size = new System.Drawing.Size(565, 172);
            this.dataGridViewConditions.TabIndex = 4;
            // 
            // buttonCreatetableToConditions
            // 
            this.buttonCreatetableToConditions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreatetableToConditions.Location = new System.Drawing.Point(340, 49);
            this.buttonCreatetableToConditions.Name = "buttonCreatetableToConditions";
            this.buttonCreatetableToConditions.Size = new System.Drawing.Size(231, 27);
            this.buttonCreatetableToConditions.TabIndex = 5;
            this.buttonCreatetableToConditions.Text = "Создать таблицу для задания условий";
            this.buttonCreatetableToConditions.UseVisualStyleBackColor = true;
            this.buttonCreatetableToConditions.Click += new System.EventHandler(this.buttonCreatetableToConditions_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.buttonCulculate);
            this.groupBox1.Controls.Add(this.buttonCreatetableToConditions);
            this.groupBox1.Controls.Add(this.dataGridViewConditions);
            this.groupBox1.Controls.Add(this.numericUpDownLiberty);
            this.groupBox1.Controls.Add(this.numericUpDownBase);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(577, 290);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Задание условий";
            // 
            // buttonCulculate
            // 
            this.buttonCulculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCulculate.Location = new System.Drawing.Point(451, 260);
            this.buttonCulculate.Name = "buttonCulculate";
            this.buttonCulculate.Size = new System.Drawing.Size(120, 21);
            this.buttonCulculate.TabIndex = 7;
            this.buttonCulculate.Text = "Вычислить";
            this.buttonCulculate.UseVisualStyleBackColor = true;
            this.buttonCulculate.Click += new System.EventHandler(this.buttonCulculate_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridViewRezult);
            this.groupBox2.Location = new System.Drawing.Point(15, 308);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(577, 291);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Решение";
            // 
            // dataGridViewRezult
            // 
            this.dataGridViewRezult.AllowUserToAddRows = false;
            this.dataGridViewRezult.AllowUserToDeleteRows = false;
            this.dataGridViewRezult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewRezult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRezult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRezult.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewRezult.Name = "dataGridViewRezult";
            this.dataGridViewRezult.RowHeadersVisible = false;
            this.dataGridViewRezult.RowHeadersWidth = 51;
            this.dataGridViewRezult.Size = new System.Drawing.Size(565, 266);
            this.dataGridViewRezult.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dataGridViewAnswer);
            this.groupBox3.Location = new System.Drawing.Point(15, 597);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(577, 99);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ответ";
            // 
            // dataGridViewAnswer
            // 
            this.dataGridViewAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAnswer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAnswer.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewAnswer.Name = "dataGridViewAnswer";
            this.dataGridViewAnswer.RowHeadersWidth = 51;
            this.dataGridViewAnswer.Size = new System.Drawing.Size(565, 74);
            this.dataGridViewAnswer.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(340, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(231, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Задать в общей форме";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 708);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLiberty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConditions)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRezult)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAnswer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownLiberty;
        private System.Windows.Forms.NumericUpDown numericUpDownBase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewConditions;
        private System.Windows.Forms.Button buttonCreatetableToConditions;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonCulculate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridViewRezult;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridViewAnswer;
        private System.Windows.Forms.Button button1;
    }
}

