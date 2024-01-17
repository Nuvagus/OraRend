namespace OraRend
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
            this.UN_TB = new System.Windows.Forms.TextBox();
            this.Pw_TB = new System.Windows.Forms.TextBox();
            this.GO_BTN = new System.Windows.Forms.Button();
            this.UN_L = new System.Windows.Forms.Label();
            this.Pw_L = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // UN_TB
            // 
            this.UN_TB.Location = new System.Drawing.Point(12, 30);
            this.UN_TB.Name = "UN_TB";
            this.UN_TB.Size = new System.Drawing.Size(130, 23);
            this.UN_TB.TabIndex = 0;
            // 
            // Pw_TB
            // 
            this.Pw_TB.Location = new System.Drawing.Point(161, 30);
            this.Pw_TB.Name = "Pw_TB";
            this.Pw_TB.Size = new System.Drawing.Size(130, 23);
            this.Pw_TB.TabIndex = 1;
            // 
            // GO_BTN
            // 
            this.GO_BTN.Location = new System.Drawing.Point(316, 30);
            this.GO_BTN.Name = "GO_BTN";
            this.GO_BTN.Size = new System.Drawing.Size(78, 23);
            this.GO_BTN.TabIndex = 2;
            this.GO_BTN.Text = "GO!";
            this.GO_BTN.UseVisualStyleBackColor = true;
            this.GO_BTN.Click += new System.EventHandler(this.GO_BTN_Click);
            // 
            // UN_L
            // 
            this.UN_L.AutoSize = true;
            this.UN_L.Location = new System.Drawing.Point(12, 9);
            this.UN_L.Name = "UN_L";
            this.UN_L.Size = new System.Drawing.Size(63, 15);
            this.UN_L.TabIndex = 3;
            this.UN_L.Text = "Username:";
            // 
            // Pw_L
            // 
            this.Pw_L.AutoSize = true;
            this.Pw_L.Location = new System.Drawing.Point(161, 9);
            this.Pw_L.Name = "Pw_L";
            this.Pw_L.Size = new System.Drawing.Size(60, 15);
            this.Pw_L.TabIndex = 4;
            this.Pw_L.Text = "Password:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(776, 377);
            this.dataGridView1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Pw_L);
            this.Controls.Add(this.UN_L);
            this.Controls.Add(this.GO_BTN);
            this.Controls.Add(this.Pw_TB);
            this.Controls.Add(this.UN_TB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox UN_TB;
        private TextBox Pw_TB;
        private Button GO_BTN;
        private Label UN_L;
        private Label Pw_L;
        private DataGridView dataGridView1;
    }
}