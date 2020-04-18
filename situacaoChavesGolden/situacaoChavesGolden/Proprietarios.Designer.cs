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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCadastrarProprietario = new System.Windows.Forms.Label();
            this.groupMenuSup = new System.Windows.Forms.GroupBox();
            this.radioVenda = new MetroFramework.Controls.MetroRadioButton();
            this.radioLocacao = new MetroFramework.Controls.MetroRadioButton();
            this.radioTodos = new MetroFramework.Controls.MetroRadioButton();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
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
            this.groupMenuSup.Controls.Add(this.radioVenda);
            this.groupMenuSup.Controls.Add(this.radioLocacao);
            this.groupMenuSup.Controls.Add(this.radioTodos);
            this.groupMenuSup.Controls.Add(this.metroTextBox1);
            this.groupMenuSup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupMenuSup.Location = new System.Drawing.Point(138, 21);
            this.groupMenuSup.Name = "groupMenuSup";
            this.groupMenuSup.Size = new System.Drawing.Size(494, 40);
            this.groupMenuSup.TabIndex = 24;
            this.groupMenuSup.TabStop = false;
            // 
            // radioVenda
            // 
            this.radioVenda.AutoSize = true;
            this.radioVenda.Location = new System.Drawing.Point(139, 13);
            this.radioVenda.Name = "radioVenda";
            this.radioVenda.Size = new System.Drawing.Size(55, 15);
            this.radioVenda.TabIndex = 3;
            this.radioVenda.Text = "Venda";
            this.radioVenda.UseVisualStyleBackColor = true;
            // 
            // radioLocacao
            // 
            this.radioLocacao.AutoSize = true;
            this.radioLocacao.Location = new System.Drawing.Point(66, 13);
            this.radioLocacao.Name = "radioLocacao";
            this.radioLocacao.Size = new System.Drawing.Size(67, 15);
            this.radioLocacao.TabIndex = 2;
            this.radioLocacao.Text = "Locação";
            this.radioLocacao.UseVisualStyleBackColor = true;
            // 
            // radioTodos
            // 
            this.radioTodos.AutoSize = true;
            this.radioTodos.Checked = true;
            this.radioTodos.Location = new System.Drawing.Point(6, 13);
            this.radioTodos.Name = "radioTodos";
            this.radioTodos.Size = new System.Drawing.Size(54, 15);
            this.radioTodos.TabIndex = 1;
            this.radioTodos.TabStop = true;
            this.radioTodos.Text = "Todos";
            this.radioTodos.UseVisualStyleBackColor = true;
            // 
            // metroTextBox1
            // 
            this.metroTextBox1.CustomBackground = true;
            this.metroTextBox1.CustomForeColor = true;
            this.metroTextBox1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.metroTextBox1.Location = new System.Drawing.Point(228, 11);
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.Size = new System.Drawing.Size(222, 23);
            this.metroTextBox1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox1.TabIndex = 0;
            this.metroTextBox1.Text = "Buscar";
            this.metroTextBox1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox1.UseStyleColors = true;
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
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridProprietarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.gridProprietarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridProprietarios.GridColor = System.Drawing.Color.White;
            this.gridProprietarios.Location = new System.Drawing.Point(23, 69);
            this.gridProprietarios.MultiSelect = false;
            this.gridProprietarios.Name = "gridProprietarios";
            this.gridProprietarios.ReadOnly = true;
            this.gridProprietarios.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridProprietarios.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.gridProprietarios.RowHeadersVisible = false;
            this.gridProprietarios.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridProprietarios.RowTemplate.ReadOnly = true;
            this.gridProprietarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridProprietarios.Size = new System.Drawing.Size(609, 177);
            this.gridProprietarios.TabIndex = 23;
            this.gridProprietarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridProprietarios_CellContentClick);
            this.gridProprietarios.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridProprietarios_CellMouseClick);
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
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridChaves.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.gridChaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridChaves.GridColor = System.Drawing.Color.White;
            this.gridChaves.Location = new System.Drawing.Point(23, 267);
            this.gridChaves.MultiSelect = false;
            this.gridChaves.Name = "gridChaves";
            this.gridChaves.ReadOnly = true;
            this.gridChaves.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridChaves.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
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
            this.metroLabel1.Location = new System.Drawing.Point(301, 247);
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
            this.contextMenuStrip2.Size = new System.Drawing.Size(188, 114);
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
            this.Name = "Proprietarios";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Text = "Proprietarios";
            this.Load += new System.EventHandler(this.Proprietarios_Load);
            this.groupMenuSup.ResumeLayout(false);
            this.groupMenuSup.PerformLayout();
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
        public MetroFramework.Controls.MetroRadioButton radioVenda;
        public MetroFramework.Controls.MetroRadioButton radioLocacao;
        public MetroFramework.Controls.MetroRadioButton radioTodos;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
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