namespace Fsys
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
            components = new System.ComponentModel.Container();
            listBox1 = new ListBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            textBox1 = new TextBox();
            listBox2 = new ListBox();
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            richTextBox2 = new RichTextBox();
            richTextBox3 = new RichTextBox();
            richTextBox4 = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            button2 = new Button();
            progressBar1 = new ProgressBar();
            label6 = new Label();
            label7 = new Label();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 25;
            listBox1.Location = new Point(12, 26);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(148, 179);
            listBox1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 227);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 1;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 25;
            listBox2.Location = new Point(186, 26);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(145, 179);
            listBox2.TabIndex = 2;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(10, 276);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(334, 162);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
            // 
            // button1
            // 
            button1.Location = new Point(186, 224);
            button1.Name = "button1";
            button1.Size = new Size(145, 34);
            button1.TabIndex = 4;
            button1.Text = "Новый файл";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(350, 26);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(240, 531);
            richTextBox2.TabIndex = 5;
            richTextBox2.Text = "";
            // 
            // richTextBox3
            // 
            richTextBox3.Location = new Point(596, 26);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(282, 531);
            richTextBox3.TabIndex = 6;
            richTextBox3.Text = "";
            // 
            // richTextBox4
            // 
            richTextBox4.BackColor = SystemColors.InfoText;
            richTextBox4.ForeColor = SystemColors.InactiveBorder;
            richTextBox4.Location = new Point(10, 488);
            richTextBox4.Name = "richTextBox4";
            richTextBox4.Size = new Size(334, 69);
            richTextBox4.TabIndex = 7;
            richTextBox4.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, -2);
            label1.Name = "label1";
            label1.Size = new Size(66, 25);
            label1.TabIndex = 8;
            label1.Text = "Файлы";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(186, -2);
            label2.Name = "label2";
            label2.Size = new Size(101, 25);
            label2.TabIndex = 9;
            label2.Text = "Удалённые";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(433, -2);
            label3.Name = "label3";
            label3.Size = new Size(61, 25);
            label3.TabIndex = 10;
            label3.Text = "байты";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(663, -2);
            label4.Name = "label4";
            label4.Size = new Size(86, 25);
            label4.TabIndex = 11;
            label4.Text = "символы";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 441);
            label5.Name = "label5";
            label5.Size = new Size(49, 25);
            label5.TabIndex = 12;
            label5.Text = "логи";
            // 
            // button2
            // 
            button2.Location = new Point(254, 448);
            button2.Name = "button2";
            button2.Size = new Size(90, 34);
            button2.TabIndex = 13;
            button2.Text = "форматирование";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 584);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(538, 19);
            progressBar1.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(582, 584);
            label6.Name = "label6";
            label6.Size = new Size(59, 25);
            label6.TabIndex = 15;
            label6.Text = "label6";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(647, 584);
            label7.Name = "label7";
            label7.Size = new Size(90, 25);
            label7.TabIndex = 16;
            label7.Text = "/512 байт";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(890, 615);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(progressBar1);
            Controls.Add(button2);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(richTextBox4);
            Controls.Add(richTextBox3);
            Controls.Add(richTextBox2);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            Controls.Add(listBox2);
            Controls.Add(textBox1);
            Controls.Add(listBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox textBox1;
        private ListBox listBox2;
        private RichTextBox richTextBox1;
        private Button button1;
        private RichTextBox richTextBox2;
        private RichTextBox richTextBox3;
        private RichTextBox richTextBox4;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button2;
        private ProgressBar progressBar1;
        private Label label6;
        private Label label7;
    }
}
