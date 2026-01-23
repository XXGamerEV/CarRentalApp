namespace CarRentalApp
{
    partial class ManageCustomerInfo
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDeleteCustomerInfo = new System.Windows.Forms.Button();
            this.btnCustomerInfo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gvCustomerList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomerList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 344);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 34);
            this.btnRefresh.TabIndex = 17;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDeleteCustomerInfo
            // 
            this.btnDeleteCustomerInfo.Location = new System.Drawing.Point(244, 344);
            this.btnDeleteCustomerInfo.Name = "btnDeleteCustomerInfo";
            this.btnDeleteCustomerInfo.Size = new System.Drawing.Size(118, 34);
            this.btnDeleteCustomerInfo.TabIndex = 16;
            this.btnDeleteCustomerInfo.Text = "Delete Customer Info";
            this.btnDeleteCustomerInfo.UseVisualStyleBackColor = true;
            this.btnDeleteCustomerInfo.Click += new System.EventHandler(this.btnDeleteCustomerInfo_Click);
            // 
            // btnCustomerInfo
            // 
            this.btnCustomerInfo.Location = new System.Drawing.Point(128, 344);
            this.btnCustomerInfo.Name = "btnCustomerInfo";
            this.btnCustomerInfo.Size = new System.Drawing.Size(110, 34);
            this.btnCustomerInfo.TabIndex = 15;
            this.btnCustomerInfo.Text = "Edit Customer Info";
            this.btnCustomerInfo.UseVisualStyleBackColor = true;
            this.btnCustomerInfo.Click += new System.EventHandler(this.btnCustomerInfo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 31);
            this.label1.TabIndex = 13;
            this.label1.Text = "Manage Customer Info";
            // 
            // gvCustomerList
            // 
            this.gvCustomerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCustomerList.Location = new System.Drawing.Point(12, 43);
            this.gvCustomerList.Name = "gvCustomerList";
            this.gvCustomerList.Size = new System.Drawing.Size(574, 295);
            this.gvCustomerList.TabIndex = 12;
            // 
            // ManageCustomerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 406);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDeleteCustomerInfo);
            this.Controls.Add(this.btnCustomerInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gvCustomerList);
            this.Name = "ManageCustomerInfo";
            this.Text = "Manage Customer Info";
            this.Load += new System.EventHandler(this.ManageCustomerInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomerList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDeleteCustomerInfo;
        private System.Windows.Forms.Button btnCustomerInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gvCustomerList;
    }
}