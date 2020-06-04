namespace situacaoChavesGolden
{
    partial class Cliente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.gridEmprestimos = new System.Windows.Forms.DataGridView();
            this.btnCadastrarProprietario = new System.Windows.Forms.Label();
            this.groupMenuSup = new System.Windows.Forms.GroupBox();
            this.boxBusca = new MetroFramework.Controls.MetroTextBox();
            this.gridCliente = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmprestimos)).BeginInit();
            this.groupMenuSup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(301, 248);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(53, 19);
            this.metroLabel1.TabIndex = 32;
            this.metroLabel1.Text = "Chaves:";
            // 
            // gridEmprestimos
            // 
            this.gridEmprestimos.AllowUserToAddRows = false;
            this.gridEmprestimos.AllowUserToDeleteRows = false;
            this.gridEmprestimos.AllowUserToResizeColumns = false;
            this.gridEmprestimos.AllowUserToResizeRows = false;
            this.gridEmprestimos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(234)))), ((int)(((byte)(242)))));
            this.gridEmprestimos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridEmprestimos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridEmprestimos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gridEmprestimos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridEmprestimos.GridColor = System.Drawing.Color.White;
            this.gridEmprestimos.Location = new System.Drawing.Point(10, 268);
            this.gridEmprestimos.MultiSelect = false;
            this.gridEmprestimos.Name = "gridEmprestimos";
            this.gridEmprestimos.ReadOnly = true;
            this.gridEmprestimos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridEmprestimos.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridEmprestimos.RowHeadersVisible = false;
            this.gridEmprestimos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridEmprestimos.RowTemplate.ReadOnly = true;
            this.gridEmprestimos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEmprestimos.Size = new System.Drawing.Size(635, 127);
            this.gridEmprestimos.TabIndex = 31;
            // 
            // btnCadastrarProprietario
            // 
            this.btnCadastrarProprietario.AutoSize = true;
            this.btnCadastrarProprietario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCadastrarProprietario.Location = new System.Drawing.Point(498, 410);
            this.btnCadastrarProprietario.Name = "btnCadastrarProprietario";
            this.btnCadastrarProprietario.Size = new System.Drawing.Size(116, 13);
            this.btnCadastrarProprietario.TabIndex = 30;
            this.btnCadastrarProprietario.Text = "Cadastrar proprietário >";
            // 
            // groupMenuSup
            // 
            this.groupMenuSup.Controls.Add(this.boxBusca);
            this.groupMenuSup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupMenuSup.Location = new System.Drawing.Point(10, 15);
            this.groupMenuSup.Name = "groupMenuSup";
            this.groupMenuSup.Size = new System.Drawing.Size(635, 49);
            this.groupMenuSup.TabIndex = 29;
            this.groupMenuSup.TabStop = false;
            // 
            // boxBusca
            // 
            this.boxBusca.CustomBackground = true;
            this.boxBusca.CustomForeColor = true;
            this.boxBusca.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.boxBusca.Location = new System.Drawing.Point(6, 15);
            this.boxBusca.Name = "boxBusca";
            this.boxBusca.Size = new System.Drawing.Size(367, 23);
            this.boxBusca.Style = MetroFramework.MetroColorStyle.Blue;
            this.boxBusca.TabIndex = 0;
            this.boxBusca.Theme = MetroFramework.MetroThemeStyle.Light;
            this.boxBusca.UseStyleColors = true;
            this.boxBusca.TextChanged += new System.EventHandler(this.boxBusca_TextChanged);
            // 
            // gridCliente
            // 
            this.gridCliente.AllowUserToAddRows = false;
            this.gridCliente.AllowUserToDeleteRows = false;
            this.gridCliente.AllowUserToResizeColumns = false;
            this.gridCliente.AllowUserToResizeRows = false;
            this.gridCliente.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(234)))), ((int)(((byte)(242)))));
            this.gridCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridCliente.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCliente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gridCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridCliente.GridColor = System.Drawing.Color.White;
            this.gridCliente.Location = new System.Drawing.Point(10, 70);
            this.gridCliente.MultiSelect = false;
            this.gridCliente.Name = "gridCliente";
            this.gridCliente.ReadOnly = true;
            this.gridCliente.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCliente.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gridCliente.RowHeadersVisible = false;
            this.gridCliente.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridCliente.RowTemplate.ReadOnly = true;
            this.gridCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCliente.Size = new System.Drawing.Size(635, 177);
            this.gridCliente.TabIndex = 28;
            this.gridCliente.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridCliente_CellMouseClick);
            this.gridCliente.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridCliente_CellMouseEnter);
            this.gridCliente.SelectionChanged += new System.EventHandler(this.GridCliente_SelectionChanged);
            // 
            // Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 430);
            this.ControlBox = false;
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.gridEmprestimos);
            this.Controls.Add(this.btnCadastrarProprietario);
            this.Controls.Add(this.groupMenuSup);
            this.Controls.Add(this.gridCliente);
            this.DisplayHeader = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "Cliente";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Text = "Cliente";
            this.Load += new System.EventHandler(this.Cliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridEmprestimos)).EndInit();
            this.groupMenuSup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.DataGridView gridEmprestimos;
        private System.Windows.Forms.Label btnCadastrarProprietario;
        private System.Windows.Forms.GroupBox groupMenuSup;
        private MetroFramework.Controls.MetroTextBox boxBusca;
        private System.Windows.Forms.DataGridView gridCliente;
    }
}