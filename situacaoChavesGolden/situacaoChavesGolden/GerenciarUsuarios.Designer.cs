namespace situacaoChavesGolden
{
    partial class GerenciarUsuarios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridUsers = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // gridUsers
            // 
            this.gridUsers.AllowUserToAddRows = false;
            this.gridUsers.AllowUserToDeleteRows = false;
            this.gridUsers.AllowUserToResizeColumns = false;
            this.gridUsers.AllowUserToResizeRows = false;
            this.gridUsers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(234)))), ((int)(((byte)(242)))));
            this.gridUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridUsers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridUsers.GridColor = System.Drawing.Color.White;
            this.gridUsers.Location = new System.Drawing.Point(34, 51);
            this.gridUsers.MultiSelect = false;
            this.gridUsers.Name = "gridUsers";
            this.gridUsers.ReadOnly = true;
            this.gridUsers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridUsers.RowHeadersVisible = false;
            this.gridUsers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridUsers.RowTemplate.ReadOnly = true;
            this.gridUsers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridUsers.Size = new System.Drawing.Size(285, 177);
            this.gridUsers.TabIndex = 1;
            this.gridUsers.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridUsers_CellFormatting);
            // 
            // GerenciarUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(353, 450);
            this.Controls.Add(this.gridUsers);
            this.DisplayHeader = false;
            this.Name = "GerenciarUsuarios";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Text = "GerenciarUsuarios";
            this.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Load += new System.EventHandler(this.GerenciarUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridUsers;
    }
}