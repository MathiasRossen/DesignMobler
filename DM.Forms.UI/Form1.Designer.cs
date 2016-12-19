namespace DM.Forms.UI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnAdd = new System.Windows.Forms.Button();
            this.ddSurface = new System.Windows.Forms.ComboBox();
            this.ddExtension = new System.Windows.Forms.ComboBox();
            this.Count = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWareNumber = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.boardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boardBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(39, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(880, 533);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnAdd);
            this.tabPage1.Controls.Add(this.ddSurface);
            this.tabPage1.Controls.Add(this.ddExtension);
            this.tabPage1.Controls.Add(this.Count);
            this.tabPage1.Controls.Add(this.txtWidth);
            this.tabPage1.Controls.Add(this.txtLength);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtWareNumber);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(872, 507);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Enter Order";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(733, 44);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "button1";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ddSurface
            // 
            this.ddSurface.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.boardBindingSource, "Surface", true));
            this.ddSurface.DataSource = this.boardBindingSource;
            this.ddSurface.DisplayMember = "Surface";
            this.ddSurface.FormattingEnabled = true;
            this.ddSurface.Location = new System.Drawing.Point(500, 45);
            this.ddSurface.Name = "ddSurface";
            this.ddSurface.Size = new System.Drawing.Size(121, 21);
            this.ddSurface.TabIndex = 6;
            this.ddSurface.ValueMember = "Surface";
            this.ddSurface.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // ddExtension
            // 
            this.ddExtension.FormattingEnabled = true;
            this.ddExtension.Location = new System.Drawing.Point(368, 45);
            this.ddExtension.Name = "ddExtension";
            this.ddExtension.Size = new System.Drawing.Size(121, 21);
            this.ddExtension.TabIndex = 5;
            this.ddExtension.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Count
            // 
            this.Count.Location = new System.Drawing.Point(700, 46);
            this.Count.Name = "Count";
            this.Count.Size = new System.Drawing.Size(27, 20);
            this.Count.TabIndex = 4;
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(257, 45);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(100, 20);
            this.txtWidth.TabIndex = 3;
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(146, 45);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(100, 20);
            this.txtLength.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ware Number";
            // 
            // txtWareNumber
            // 
            this.txtWareNumber.Location = new System.Drawing.Point(35, 45);
            this.txtWareNumber.Name = "txtWareNumber";
            this.txtWareNumber.Size = new System.Drawing.Size(100, 20);
            this.txtWareNumber.TabIndex = 0;
            this.txtWareNumber.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(872, 507);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Order List";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // boardBindingSource
            // 
            this.boardBindingSource.DataSource = typeof(DM.Core.Board);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 576);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boardBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtWareNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.TextBox Count;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.ComboBox ddSurface;
        private System.Windows.Forms.ComboBox ddExtension;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.BindingSource boardBindingSource;
    }
}

