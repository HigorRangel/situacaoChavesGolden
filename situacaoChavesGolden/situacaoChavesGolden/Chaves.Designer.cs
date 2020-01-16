namespace situacaoChavesGolden
{
    partial class Chaves
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
            this.gridChaves = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.excluirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.codigoImob = new System.Windows.Forms.Label();
            this.endereco = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sitChave = new System.Windows.Forms.Label();
            this.labelChave = new System.Windows.Forms.Label();
            this.localizacao = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.proprietario = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.finalidade = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.sitImovel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tipoImovel = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.emprestimo = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.groupMenuSup = new System.Windows.Forms.GroupBox();
            this.radioVenda = new MetroFramework.Controls.MetroRadioButton();
            this.radioLocacao = new MetroFramework.Controls.MetroRadioButton();
            this.radioTodos = new MetroFramework.Controls.MetroRadioButton();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridChaves)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupMenuSup.SuspendLayout();
            this.SuspendLayout();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridChaves.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridChaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridChaves.ContextMenuStrip = this.contextMenuStrip1;
            this.gridChaves.GridColor = System.Drawing.Color.White;
            this.gridChaves.Location = new System.Drawing.Point(23, 68);
            this.gridChaves.MultiSelect = false;
            this.gridChaves.Name = "gridChaves";
            this.gridChaves.ReadOnly = true;
            this.gridChaves.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridChaves.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridChaves.RowHeadersVisible = false;
            this.gridChaves.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridChaves.RowTemplate.ReadOnly = true;
            this.gridChaves.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridChaves.Size = new System.Drawing.Size(609, 188);
            this.gridChaves.TabIndex = 0;
            this.gridChaves.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridChaves_CellMouseClick);
            this.gridChaves.SelectionChanged += new System.EventHandler(this.GridChaves_SelectionChanged);
            this.gridChaves.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridChaves_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excluirToolStripMenuItem,
            this.editarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(110, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip1_Opening);
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
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.EditarToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(91)))), ((int)(((byte)(115)))));
            this.label1.Location = new System.Drawing.Point(28, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código Imob: ";
            // 
            // codigoImob
            // 
            this.codigoImob.AutoSize = true;
            this.codigoImob.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codigoImob.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.codigoImob.Location = new System.Drawing.Point(106, 278);
            this.codigoImob.Name = "codigoImob";
            this.codigoImob.Size = new System.Drawing.Size(53, 15);
            this.codigoImob.TabIndex = 2;
            this.codigoImob.Text = "Código: ";
            // 
            // endereco
            // 
            this.endereco.AutoSize = true;
            this.endereco.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endereco.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.endereco.Location = new System.Drawing.Point(92, 312);
            this.endereco.Name = "endereco";
            this.endereco.Size = new System.Drawing.Size(53, 15);
            this.endereco.TabIndex = 4;
            this.endereco.Text = "Código: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(91)))), ((int)(((byte)(115)))));
            this.label3.Location = new System.Drawing.Point(28, 312);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Endereço:";
            // 
            // sitChave
            // 
            this.sitChave.AutoSize = true;
            this.sitChave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sitChave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(201)))), ((int)(((byte)(209)))));
            this.sitChave.Location = new System.Drawing.Point(116, 17);
            this.sitChave.Name = "sitChave";
            this.sitChave.Size = new System.Drawing.Size(53, 15);
            this.sitChave.TabIndex = 6;
            this.sitChave.Text = "Código: ";
            // 
            // labelChave
            // 
            this.labelChave.AutoSize = true;
            this.labelChave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChave.ForeColor = System.Drawing.Color.White;
            this.labelChave.Location = new System.Drawing.Point(3, 17);
            this.labelChave.Name = "labelChave";
            this.labelChave.Size = new System.Drawing.Size(114, 15);
            this.labelChave.TabIndex = 5;
            this.labelChave.Text = "Situação da chave:";
            // 
            // localizacao
            // 
            this.localizacao.AutoSize = true;
            this.localizacao.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localizacao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(201)))), ((int)(((byte)(209)))));
            this.localizacao.Location = new System.Drawing.Point(564, 17);
            this.localizacao.Name = "localizacao";
            this.localizacao.Size = new System.Drawing.Size(53, 15);
            this.localizacao.TabIndex = 8;
            this.localizacao.Text = "Código: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(489, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "Localização:";
            // 
            // proprietario
            // 
            this.proprietario.AutoSize = true;
            this.proprietario.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proprietario.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.proprietario.Location = new System.Drawing.Point(111, 350);
            this.proprietario.Name = "proprietario";
            this.proprietario.Size = new System.Drawing.Size(53, 15);
            this.proprietario.TabIndex = 10;
            this.proprietario.Text = "Código: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(91)))), ((int)(((byte)(115)))));
            this.label9.Location = new System.Drawing.Point(28, 350);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "Proprietário:";
            // 
            // finalidade
            // 
            this.finalidade.AutoSize = true;
            this.finalidade.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finalidade.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.finalidade.Location = new System.Drawing.Point(306, 278);
            this.finalidade.Name = "finalidade";
            this.finalidade.Size = new System.Drawing.Size(53, 15);
            this.finalidade.TabIndex = 12;
            this.finalidade.Text = "Código: ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(91)))), ((int)(((byte)(115)))));
            this.label11.Location = new System.Drawing.Point(242, 277);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 15);
            this.label11.TabIndex = 11;
            this.label11.Text = "Finalidade:";
            // 
            // sitImovel
            // 
            this.sitImovel.AutoSize = true;
            this.sitImovel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sitImovel.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.sitImovel.Location = new System.Drawing.Point(567, 279);
            this.sitImovel.Name = "sitImovel";
            this.sitImovel.Size = new System.Drawing.Size(53, 15);
            this.sitImovel.TabIndex = 14;
            this.sitImovel.Text = "Código: ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(91)))), ((int)(((byte)(115)))));
            this.label13.Location = new System.Drawing.Point(452, 278);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(117, 15);
            this.label13.TabIndex = 13;
            this.label13.Text = "Situação do Imóvel:";
            // 
            // tipoImovel
            // 
            this.tipoImovel.AutoSize = true;
            this.tipoImovel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoImovel.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.tipoImovel.Location = new System.Drawing.Point(552, 350);
            this.tipoImovel.Name = "tipoImovel";
            this.tipoImovel.Size = new System.Drawing.Size(53, 15);
            this.tipoImovel.TabIndex = 16;
            this.tipoImovel.Text = "Código: ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(91)))), ((int)(((byte)(115)))));
            this.label15.Location = new System.Drawing.Point(461, 350);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(91, 15);
            this.label15.TabIndex = 15;
            this.label15.Text = "Tipo do imóvel:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(91)))), ((int)(((byte)(115)))));
            this.panel1.Controls.Add(this.emprestimo);
            this.panel1.Controls.Add(this.label);
            this.panel1.Controls.Add(this.sitChave);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.localizacao);
            this.panel1.Controls.Add(this.labelChave);
            this.panel1.Location = new System.Drawing.Point(-1, 383);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(660, 49);
            this.panel1.TabIndex = 17;
            // 
            // emprestimo
            // 
            this.emprestimo.AutoSize = true;
            this.emprestimo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emprestimo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(201)))), ((int)(((byte)(209)))));
            this.emprestimo.Location = new System.Drawing.Point(341, 17);
            this.emprestimo.Name = "emprestimo";
            this.emprestimo.Size = new System.Drawing.Size(53, 15);
            this.emprestimo.TabIndex = 10;
            this.emprestimo.Text = "Código: ";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.White;
            this.label.Location = new System.Drawing.Point(261, 17);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(79, 15);
            this.label.TabIndex = 9;
            this.label.Text = "Empréstimo:";
            // 
            // groupMenuSup
            // 
            this.groupMenuSup.Controls.Add(this.radioVenda);
            this.groupMenuSup.Controls.Add(this.radioLocacao);
            this.groupMenuSup.Controls.Add(this.radioTodos);
            this.groupMenuSup.Controls.Add(this.metroTextBox1);
            this.groupMenuSup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupMenuSup.Location = new System.Drawing.Point(138, 20);
            this.groupMenuSup.Name = "groupMenuSup";
            this.groupMenuSup.Size = new System.Drawing.Size(494, 40);
            this.groupMenuSup.TabIndex = 18;
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
            this.radioVenda.CheckedChanged += new System.EventHandler(this.RadioTodos_CheckedChanged);
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
            this.radioLocacao.CheckedChanged += new System.EventHandler(this.RadioTodos_CheckedChanged);
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
            this.radioTodos.CheckedChanged += new System.EventHandler(this.RadioTodos_CheckedChanged);
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
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(23, 263);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(609, 114);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(26, 29);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(68, 25);
            this.metroLabel1.TabIndex = 20;
            this.metroLabel1.Text = "Chaves";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(491, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Chaves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 430);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.groupMenuSup);
            this.Controls.Add(this.tipoImovel);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.sitImovel);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.finalidade);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.proprietario);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.endereco);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.codigoImob);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridChaves);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.DisplayHeader = false;
            this.Movable = false;
            this.Name = "Chaves";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.None;
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Text = "Chaves";
            this.Load += new System.EventHandler(this.Chaves_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridChaves)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupMenuSup.ResumeLayout(false);
            this.groupMenuSup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridChaves;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem excluirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label codigoImob;
        private System.Windows.Forms.Label endereco;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label sitChave;
        private System.Windows.Forms.Label labelChave;
        private System.Windows.Forms.Label localizacao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label proprietario;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label finalidade;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label sitImovel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label tipoImovel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label emprestimo;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.GroupBox groupMenuSup;
        private MetroFramework.Controls.MetroRadioButton radioVenda;
        private MetroFramework.Controls.MetroRadioButton radioLocacao;
        private MetroFramework.Controls.MetroRadioButton radioTodos;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.Button button1;
    }
}