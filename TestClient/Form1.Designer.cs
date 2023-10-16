namespace TestClient
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
            btnConnect = new Button();
            btnSendText = new Button();
            textBox1 = new TextBox();
            browseButton = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // textBox
            // 
            textBox.Location = new Point(24, 25);
            textBox.Name = "textBox";
            textBox.Size = new Size(752, 237);
            textBox.TabIndex = 0;
            textBox.Text = "";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(24, 268);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(752, 23);
            btnConnect.TabIndex = 1;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnSendText
            // 
            btnSendText.Location = new Point(691, 306);
            btnSendText.Name = "btnSendText";
            btnSendText.Size = new Size(85, 23);
            btnSendText.TabIndex = 2;
            btnSendText.Text = "Send Text";
            btnSendText.UseVisualStyleBackColor = true;
            btnSendText.Click += btnSendText_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(24, 306);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(652, 23);
            textBox1.TabIndex = 3;
            // 
            // browseButton
            // 
            browseButton.Location = new Point(24, 345);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(213, 23);
            browseButton.TabIndex = 4;
            browseButton.Text = "Browse";
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += browseButton_Click;
            // 
            // button2
            // 
            button2.Location = new Point(520, 345);
            button2.Name = "button2";
            button2.Size = new Size(256, 23);
            button2.TabIndex = 5;
            button2.Text = "send to server";
            button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 561);
            Controls.Add(button2);
            Controls.Add(browseButton);
            Controls.Add(textBox1);
            Controls.Add(btnSendText);
            Controls.Add(btnConnect);
            Controls.Add(textBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox textBox;
        private Button btnConnect;
        private Button btnSendText;
        private TextBox textBox1;
        private Button browseButton;
        private Button button2;
    }
}