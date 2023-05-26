
namespace TestAutomation
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
            this.button1 = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.txtPhones = new System.Windows.Forms.TextBox();
            this.Remove = new System.Windows.Forms.Button();
            this.cbxAll = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(97, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(286, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "Pay";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Pay_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(12, 116);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(198, 213);
            this.checkedListBox1.TabIndex = 3;
            // 
            // txtPhones
            // 
            this.txtPhones.Location = new System.Drawing.Point(285, 116);
            this.txtPhones.Multiline = true;
            this.txtPhones.Name = "txtPhones";
            this.txtPhones.Size = new System.Drawing.Size(204, 213);
            this.txtPhones.TabIndex = 4;
            // 
            // Remove
            // 
            this.Remove.Location = new System.Drawing.Point(135, 87);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(75, 23);
            this.Remove.TabIndex = 6;
            this.Remove.Text = "Remove";
            this.Remove.UseVisualStyleBackColor = true;
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // cbxAll
            // 
            this.cbxAll.AccessibleDescription = "";
            this.cbxAll.AutoSize = true;
            this.cbxAll.Location = new System.Drawing.Point(12, 89);
            this.cbxAll.Name = "cbxAll";
            this.cbxAll.Size = new System.Drawing.Size(78, 21);
            this.cbxAll.TabIndex = 5;
            this.cbxAll.Tag = "";
            this.cbxAll.Text = "SelectAll";
            this.cbxAll.UseVisualStyleBackColor = true;
            this.cbxAll.CheckedChanged += new System.EventHandler(this.cbxAll_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 350);
            this.Controls.Add(this.Remove);
            this.Controls.Add(this.cbxAll);
            this.Controls.Add(this.txtPhones);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.TextBox txtPhones;
        private System.Windows.Forms.CheckBox cbxAll;
        private System.Windows.Forms.Button Remove;
    }
}

