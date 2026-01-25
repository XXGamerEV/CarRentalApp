namespace CarRentalApp
{
    partial class EditCustomerInfo
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCustomerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCar = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbBank = new System.Windows.Forms.TextBox();
            this.Submit = new System.Windows.Forms.Button();
            this.lblRecordId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(257, 31);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Edit Customer Info";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Customer Name";
            // 
            // tbCustomerName
            // 
            this.tbCustomerName.Location = new System.Drawing.Point(14, 90);
            this.tbCustomerName.Name = "tbCustomerName";
            this.tbCustomerName.Size = new System.Drawing.Size(201, 20);
            this.tbCustomerName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Type Of Car";
            // 
            // cbCar
            // 
            this.cbCar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCar.FormattingEnabled = true;
            this.cbCar.Location = new System.Drawing.Point(14, 216);
            this.cbCar.Name = "cbCar";
            this.cbCar.Size = new System.Drawing.Size(201, 21);
            this.cbCar.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "Banking info";
            // 
            // tbBank
            // 
            this.tbBank.Location = new System.Drawing.Point(14, 150);
            this.tbBank.Name = "tbBank";
            this.tbBank.Size = new System.Drawing.Size(201, 20);
            this.tbBank.TabIndex = 15;
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(39, 272);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(125, 56);
            this.Submit.TabIndex = 17;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // lblRecordId
            // 
            this.lblRecordId.AutoSize = true;
            this.lblRecordId.Location = new System.Drawing.Point(213, 302);
            this.lblRecordId.Name = "lblRecordId";
            this.lblRecordId.Size = new System.Drawing.Size(0, 13);
            this.lblRecordId.TabIndex = 18;
            this.lblRecordId.Visible = false;
            // 
            // EditCustomerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 350);
            this.Controls.Add(this.lblRecordId);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbBank);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCustomerName);
            this.Controls.Add(this.lblTitle);
            this.Name = "EditCustomerInfo";
            this.Text = "Edit Customer Info";
            this.Load += new System.EventHandler(this.EditCustomerInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCustomerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbBank;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.Label lblRecordId;
    }
}