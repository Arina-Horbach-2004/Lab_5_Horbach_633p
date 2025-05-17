namespace Lab_5_Horbach_633p
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox_matrix_values = new TextBox();
            textBox_matrix_appointments = new TextBox();
            textBox_cost = new TextBox();
            button_result = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button_protocol = new Button();
            SuspendLayout();
            // 
            // textBox_matrix_values
            // 
            textBox_matrix_values.Location = new Point(35, 45);
            textBox_matrix_values.Multiline = true;
            textBox_matrix_values.Name = "textBox_matrix_values";
            textBox_matrix_values.Size = new Size(288, 312);
            textBox_matrix_values.TabIndex = 0;
            // 
            // textBox_matrix_appointments
            // 
            textBox_matrix_appointments.Location = new Point(358, 45);
            textBox_matrix_appointments.Multiline = true;
            textBox_matrix_appointments.Name = "textBox_matrix_appointments";
            textBox_matrix_appointments.ReadOnly = true;
            textBox_matrix_appointments.Size = new Size(288, 312);
            textBox_matrix_appointments.TabIndex = 1;
            // 
            // textBox_cost
            // 
            textBox_cost.Location = new Point(445, 391);
            textBox_cost.Name = "textBox_cost";
            textBox_cost.ReadOnly = true;
            textBox_cost.Size = new Size(201, 27);
            textBox_cost.TabIndex = 2;
            // 
            // button_result
            // 
            button_result.Location = new Point(35, 380);
            button_result.Name = "button_result";
            button_result.Size = new Size(288, 49);
            button_result.TabIndex = 3;
            button_result.Text = "Знайти матрицю призначень";
            button_result.UseVisualStyleBackColor = true;
            button_result.Click += button_result_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(358, 398);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 4;
            label1.Text = "Вартість:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 22);
            label2.Name = "label2";
            label2.Size = new Size(148, 20);
            label2.TabIndex = 5;
            label2.Text = "Матриця вартостей:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(358, 22);
            label3.Name = "label3";
            label3.Size = new Size(162, 20);
            label3.TabIndex = 6;
            label3.Text = "Матриця призначень:";
            // 
            // button_protocol
            // 
            button_protocol.Location = new Point(183, 454);
            button_protocol.Name = "button_protocol";
            button_protocol.Size = new Size(288, 49);
            button_protocol.TabIndex = 7;
            button_protocol.Text = "Протокол обчислення";
            button_protocol.UseVisualStyleBackColor = true;
            button_protocol.Click += button_protocol_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(688, 524);
            Controls.Add(button_protocol);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button_result);
            Controls.Add(textBox_cost);
            Controls.Add(textBox_matrix_appointments);
            Controls.Add(textBox_matrix_values);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_matrix_values;
        private TextBox textBox_matrix_appointments;
        private TextBox textBox_cost;
        private Button button_result;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button_protocol;
    }
}
