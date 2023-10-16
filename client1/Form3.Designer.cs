namespace client1
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightBlue;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.Location = new System.Drawing.Point(23, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 36);
            this.button2.TabIndex = 0;
            this.button2.Text = "뒤로가기";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(23, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(688, 410);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // Form3
            // 
            this.ClientSize = new System.Drawing.Size(725, 481);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Name = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}