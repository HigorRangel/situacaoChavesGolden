namespace situacaoChavesGolden
{
    partial class Proprietarios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCadastrarProprietario = new System.Windows.Forms.Label();
            this.groupMenuSup = new System.Windows.Forms.GroupBox();
            this.boxBuscar = new MetroFramework.Controls.MetroTextBox();
            this.gridProprietarios = new System.Windows.Forms.DataGridView();
            this.gridChaves = new System.Windows.Forms.DataGridView();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.excluirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.retirarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarEmpréstimoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupMenuSup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProprietarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridChaves)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCadastrarProprietario
            // 
            this.btnCadastrarProprietario.AutoSize = true;
            this.btnCadastrarProprietario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCadastrarProprietario.Location = new System.Drawing.Point(498, 409);
            this.btnCadastrarProprietario.Name = "btnCadastrarProprietario";
            this.btnCadastrarProprietario.Size = new System.Drawing.Size(116, 13);
            this.btnCadastrarProprietario.TabIndex = 25;
            this.btnCadastrarProprietario.Text = "Cadastrar proprietário >";
            this.btnCadastrarProprietario.Click += new System.EventHandler(this.btnCadastrarProprietario_Click);
            // 
            // groupMenuSup
            // 
            this.groupMenuSup.Controls.Add(this.boxBuscar);
            this.groupMenuSup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupMenuSup.Location = new System.Drawing.Point(23, 21);
            this.groupMenuSup.Name = "groupMenuSup";
            this.groupMenuSup.Size = new System.Drawing.Size(609, 48);
            this.groupMenuSup.TabIndex = 24;
            this.groupMenuSup.TabStop = false;
            // 
            // boxBuscar
            // 
            this.boxBuscar.CustomBackground = true;
            this.boxBuscar.CustomForeColor = true;
            this.boxBuscar.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.boxBuscar.Location = new System.Drawing.Point(17, 15);
            this.boxBuscar.Name = "boxBuscar";
            this.boxBuscar.Size = new System.Drawing.Size(335, 23);
            this.boxBuscar.Style = MetroFramework.MetroColorStyle.Blue;
            this.boxBuscar.TabIndex = 0;
            this.boxBuscar.Theme = MetroFramework.MetroThemeStyle.Light;
            this.boxBuscar.UseStyleColors = true;
            this.boxBuscar.TextChanged += new System.EventHandler(this.BoxBuscar_TextChanged);
            this.boxBuscar.Click += new System.EventHandler(this.MetroTextBox1_Click);
            // 
            // gridProprietarios
            // 
            this.gridProprietarios.AllowUserToAddRows = false;
            this.gridProprietarios.AllowUserToDeleteRows = false;
            this.gridProprietarios.AllowUserToResizeColumns = false;
            this.gridProprietarios.AllowUserToResizeRows = false;
            this.gridProprietarios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(234)))), ((int)(((byte)(242)))));
            this.gridProprietarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridProprietarios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridProprietarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gridProprietarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridProprietarios.GridColor = System.Drawing.Color.White;
            this.gridProprietarios.Location = new System.Drawing.Point(23, 75);
            this.gridProprietarios.MultiSelect = false;
            this.gridProprietarios.Name = "gridProprietarios";
            this.gridProprietarios.ReadOnly = true;
            this.gridProprietarios.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridProprietarios.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridProprietarios.RowHeadersVisible = false;
            this.gridProprietarios.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridProprietarios.RowTemplate.ReadOnly = true;
            this.gridProprietarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridProprietarios.Size = new System.Drawing.Size(609, 177);
            this.gridProprietarios.TabIndex = 23;
            this.gridProprietarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridProprietarios_CellContentClick);
            this.gridProprietarios.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridProprietarios_CellMouseClick);
            this.gridProprietarios.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridProprietarios_CellMouseEnter);
            this.gridProprietarios.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridProprietarios_ColumnHeaderMouseClick);
            this.gridProprietarios.SelectionChanged += new System.EventHandler(this.gridProprietarios_SelectionChanged);
            this.gridProprietarios.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridProprietarios_MouseClick);
            // 
            // gridChaves
            // 
            this.gridChaves.AllowUserToAddRows = false;
            this.gridChaves.AllowUserToDeleteRows = false;
            this.gridChaves.AllowUserToResizeColumns = false;
            this.gridChaves.AllowUserToResizeRows = false;
            this.gridChaves.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(234)))), ((int)(((byte)(242)))));
            this.gridChaves.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridChaves.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridChaves.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gridChaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridChaves.GridColor = System.Drawing.Color.White;
            this.gridChaves.Location = new System.Drawing.Point(23, 273);
            this.gridChaves.MultiSelect = false;
            this.gridChaves.Name = "gridChaves";
            this.gridChaves.ReadOnly = true;
            this.gridChaves.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridChaves.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gridChaves.RowHeadersVisible = false;
            this.gridChaves.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridChaves.RowTemplate.ReadOnly = true;
            this.gridChaves.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridChaves.Size = new System.Drawing.Size(609, 127);
            this.gridChaves.TabIndex = 26;
            this.gridChaves.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GridChaves_MouseClick);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(301, 253);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(53, 19);
            this.metroLabel1.TabIndex = 27;
            this.metroLabel1.Text = "Chaves:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excluirToolStripMenuItem,
            this.editarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(110, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // excluirToolStripMenuItem
            // 
            this.excluirToolStripMenuItem.Name = "excluirToolStripMenuItem";
            this.excluirToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.excluirToolStripMenuItem.Text = "Excluir";
            this.excluirToolStripMenuItem.Click += new System.EventHandler(this.ExcluirToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.retirarToolStripMenuItem,
            this.editarToolStripMenuItem1,
            this.registrarEmpréstimoToolStripMenuItem,
            this.reservarToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(188, 92);
            // 
            // retirarToolStripMenuItem
            // 
            this.retirarToolStripMenuItem.Name = "retirarToolStripMenuItem";
            this.retirarToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.retirarToolStripMenuItem.Text = "Retirar";
            this.retirarToolStripMenuItem.Click += new System.EventHandler(this.RetirarToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem1
            // 
            this.editarToolStripMenuItem1.Name = "editarToolStripMenuItem1";
            this.editarToolStripMenuItem1.Size = new System.Drawing.Size(187, 22);
            this.editarToolStripMenuItem1.Text = "Editar";
            // 
            // registrarEmpréstimoToolStripMenuItem
            // 
            this.registrarEmpréstimoToolStripMenuItem.Name = "registrarEmpréstimoToolStripMenuItem";
            this.registrarEmpréstimoToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.registrarEmpréstimoToolStripMenuItem.Text = "Registrar Empréstimo";
            // 
            // reservarToolStripMenuItem
            // 
            this.reservarToolStripMenuItem.Name = "reservarToolStripMenuItem";
            this.reservarToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.reservarToolStripMenuItem.Text = "Reservar";
            // 
            // Proprietarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(655, 430);
            this.ControlBox = false;
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.gridChaves);
            this.Controls.Add(this.btnCadastrarProprietario);
            this.Controls.Add(this.groupMenuSup);
            this.Controls.Add(this.gridProprietarios);
            this.DisplayHeader = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Proprietarios";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Text = "Proprietarios";
            this.Load += new System.EventHandler(this.Proprietarios_Load);
            this.groupMenuSup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridProprietarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridChaves)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label btnCadastrarProprietario;
        private System.Windows.Forms.GroupBox groupMenuSup;
        private MetroFramework.Controls.MetroTextBox boxBuscar;
        private System.Windows.Forms.DataGridView gridProprietarios;
        private System.Windows.Forms.DataGridView gridChaves;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem excluirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem retirarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem registrarEmpréstimoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservarToolStripMenuItem;
    }
}