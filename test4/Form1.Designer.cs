namespace test4
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
            btnSearch = new Button();
            txtSearch = new TextBox();
            listView1 = new ListView();
            SuspendLayout();
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(306, 23);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(99, 23);
            btnSearch.TabIndex = 0;
            btnSearch.Text = "검색";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(41, 23);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(232, 23);
            txtSearch.TabIndex = 1;
            // 
            // listView1
            // 
            listView1.Location = new Point(41, 67);
            listView1.Name = "listView1";
            listView1.Size = new Size(364, 407);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 528);
            Controls.Add(listView1);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSearch;
        private TextBox txtSearch;
        private ListView listView1;
    }
}