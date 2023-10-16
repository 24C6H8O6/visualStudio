namespace ClientTest1
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
            textBox = new RichTextBox();
            button1 = new Button();
            textBox1 = new TextBox();
            button2 = new Button();
            textBox2 = new RichTextBox();
            textBox3 = new TextBox();
            button3 = new Button();
            button4 = new Button();
            label1 = new Label();
            label2 = new Label();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // textBox
            // 
            textBox.Location = new Point(12, 53);
            textBox.Name = "textBox";
            textBox.Size = new Size(484, 385);
            textBox.TabIndex = 0;
            textBox.Text = "";
            // 
            // button1
            // 
            button1.Location = new Point(427, 17);
            button1.Name = "button1";
            button1.Size = new Size(69, 24);
            button1.TabIndex = 1;
            button1.Text = "Connect";
            button1.UseVisualStyleBackColor = true;
            button1.Click += connectToServer;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(286, 18);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(135, 23);
            textBox1.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(527, 308);
            button2.Name = "button2";
            button2.Size = new Size(261, 24);
            button2.TabIndex = 1;
            button2.Text = "SendtoServer";
            button2.UseVisualStyleBackColor = true;
            button2.Click += sendToServer;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(527, 53);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(261, 249);
            textBox2.TabIndex = 0;
            textBox2.Text = "";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(527, 355);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(261, 23);
            textBox3.TabIndex = 2;
            // 
            // button3
            // 
            button3.Location = new Point(527, 384);
            button3.Name = "button3";
            button3.Size = new Size(261, 24);
            button3.TabIndex = 1;
            button3.Text = "Path";
            button3.UseVisualStyleBackColor = true;
            button3.Click += searchFilePath;
            // 
            // button4
            // 
            button4.Location = new Point(527, 414);
            button4.Name = "button4";
            button4.Size = new Size(261, 24);
            button4.TabIndex = 1;
            button4.Text = "sendFile";
            button4.UseVisualStyleBackColor = true;
            button4.Click += sendFile;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 17);
            label1.Name = "label1";
            label1.Size = new Size(51, 19);
            label1.TabIndex = 3;
            label1.Text = "닉네임";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(527, 17);
            label2.Name = "label2";
            label2.Size = new Size(84, 19);
            label2.TabIndex = 3;
            label2.Text = "귓속말 상대";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(622, 18);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(166, 23);
            textBox4.TabIndex = 2;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(69, 17);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(135, 23);
            textBox5.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(213, 18);
            label3.Name = "label3";
            label3.Size = new Size(70, 19);
            label3.TabIndex = 3;
            label3.Text = "서버 주소";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(textBox3);
            Controls.Add(textBox4);
            Controls.Add(textBox5);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox);
            Name = "Form1";
            Text = "Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox textBox;
        private Button button1;
        private TextBox textBox1;
        private Button button2;
        private RichTextBox textBox2;
        private TextBox textBox3;
        private Button button3;
        private Button button4;
        private Label label1;
        private Label label2;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label3;
    }
}