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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.groupMenuSup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProprietarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridChaves)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridProprietarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridProprietarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridProprietarios.GridColor = System.Drawing.Color.White;
            this.gridProprietarios.Location = new System.Drawing.Point(23, 69);
            this.gridProprietarios.MultiSelect = false;
            this.gridProprietarios.Name = "gridProprietarios";
            this.gridProprietarios.ReadOnly = true;
            this.gridProprietarios.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridProprietarios.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridChaves.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridChaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridChaves.GridColor = System.Drawing.Color.White;
            this.gridChaves.Location = new System.Drawing.Point(23, 267);
            this.gridChaves.MultiSelect = false;
            this.gridChaves.Name = "gridChaves";
            this.gridChaves.ReadOnly = true;
            this.gridChaves.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridChaves.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridChaves.RowHeadersVisible = false;
            this.gridChaves.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridChaves.RowTemplate.ReadOnly = true;
            this.gridChaves.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridChaves.Size = new System.Drawing.Size(609, 127);
            this.gridChaves.TabIndex = 26;
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
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
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
    }
}