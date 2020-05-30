namespace situacaoChavesGolden
{
    partial class CadastroReserva
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastroReserva));
            this.painelProp = new System.Windows.Forms.Panel();
            this.btnNovoProp = new System.Windows.Forms.Button();
            this.btnCancelarProp = new System.Windows.Forms.Button();
            this.btnConfirmarProp = new System.Windows.Forms.Button();
            this.gridPessoas = new System.Windows.Forms.DataGridView();
            this.boxProcurarProp = new System.Windows.Forms.TextBox();
            this.labelCod = new MetroFramework.Controls.MetroLabel();
            this.codPessoaBox = new MetroFramework.Controls.MetroTextBox();
            this.labelProp = new MetroFramework.Controls.MetroLabel();
            this.nomePessoaBox = new MetroFramework.Controls.MetroTextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.groupDadosEmp = new System.Windows.Forms.GroupBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.dateRetirada = new System.Windows.Forms.DateTimePicker();
            this.descBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.groupQuemEmpresta = new System.Windows.Forms.GroupBox();
            this.radioFuncionario = new MetroFramework.Controls.MetroRadioButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.radioCliente = new MetroFramework.Controls.MetroRadioButton();
            this.radioProprietario = new MetroFramework.Controls.MetroRadioButton();
            this.groupDadosCliente = new System.Windows.Forms.GroupBox();
            this.btnAdicionarPessoa = new System.Windows.Forms.Label();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.excluiProp = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddChave = new System.Windows.Forms.Label();
            this.gridChaves = new System.Windows.Forms.DataGridView();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.panelChaves = new System.Windows.Forms.Panel();
            this.btnCancelarChave = new System.Windows.Forms.Button();
            this.btnConfirmChave = new System.Windows.Forms.Button();
            this.gridChavesTotal = new System.Windows.Forms.DataGridView();
            this.boxBusca = new System.Windows.Forms.TextBox();
            this.painelProp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPessoas)).BeginInit();
            this.groupDadosEmp.SuspendLayout();
            this.groupQuemEmpresta.SuspendLayout();
            this.groupDadosCliente.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridChaves)).BeginInit();
            this.panelChaves.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridChavesTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // painelProp
            // 
            this.painelProp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.painelProp.Controls.Add(this.btnNovoProp);
            this.painelProp.Controls.Add(this.btnCancelarProp);
            this.painelProp.Controls.Add(this.btnConfirmarProp);
            this.painelProp.Controls.Add(this.gridPessoas);
            this.painelProp.Controls.Add(this.boxProcurarProp);
            this.painelProp.Location = new System.Drawing.Point(35, 15);
            this.painelProp.Name = "painelProp";
            this.painelProp.Size = new System.Drawing.Size(374, 225);
            this.painelProp.TabIndex = 38;
            this.painelProp.Visible = false;
            this.painelProp.Paint += new System.Windows.Forms.PaintEventHandler(this.PainelProp_Paint);
            // 
            // btnNovoProp
            // 
            this.btnNovoProp.BackColor = System.Drawing.Color.White;
            this.btnNovoProp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnNovoProp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(107)))));
            this.btnNovoProp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(86)))), ((int)(((byte)(122)))));
            this.btnNovoProp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoProp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnNovoProp.Location = new System.Drawing.Point(29, 194);
            this.btnNovoProp.Name = "btnNovoProp";
            this.btnNovoProp.Size = new System.Drawing.Size(59, 23);
            this.btnNovoProp.TabIndex = 27;
            this.btnNovoProp.Text = "Novo";
            this.btnNovoProp.UseVisualStyleBackColor = false;
            this.btnNovoProp.Click += new System.EventHandler(this.BtnNovoProp_Click_1);
            // 
            // btnCancelarProp
            // 
            this.btnCancelarProp.BackColor = System.Drawing.Color.White;
            this.btnCancelarProp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnCancelarProp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(107)))));
            this.btnCancelarProp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(86)))), ((int)(((byte)(122)))));
            this.btnCancelarProp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarProp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnCancelarProp.Location = new System.Drawing.Point(178, 194);
            this.btnCancelarProp.Name = "btnCancelarProp";
            this.btnCancelarProp.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarProp.TabIndex = 26;
            this.btnCancelarProp.Text = "Cancelar";
            this.btnCancelarProp.UseVisualStyleBackColor = false;
            this.btnCancelarProp.Click += new System.EventHandler(this.BtnCancelarProp_Click_1);
            // 
            // btnConfirmarProp
            // 
            this.btnConfirmarProp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnConfirmarProp.FlatAppearance.BorderSize = 0;
            this.btnConfirmarProp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(107)))));
            this.btnConfirmarProp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(86)))), ((int)(((byte)(122)))));
            this.btnConfirmarProp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmarProp.ForeColor = System.Drawing.Color.White;
            this.btnConfirmarProp.Location = new System.Drawing.Point(270, 195);
            this.btnConfirmarProp.Name = "btnConfirmarProp";
            this.btnConfirmarProp.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmarProp.TabIndex = 25;
            this.btnConfirmarProp.Text = "Confirmar";
            this.btnConfirmarProp.UseVisualStyleBackColor = false;
            this.btnConfirmarProp.Click += new System.EventHandler(this.BtnConfirmarProp_Click_1);
            // 
            // gridPessoas
            // 
            this.gridPessoas.AllowUserToAddRows = false;
            this.gridPessoas.AllowUserToDeleteRows = false;
            this.gridPessoas.AllowUserToResizeRows = false;
            this.gridPessoas.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.gridPessoas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridPessoas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPessoas.Location = new System.Drawing.Point(29, 58);
            this.gridPessoas.MultiSelect = false;
            this.gridPessoas.Name = "gridPessoas";
            this.gridPessoas.ReadOnly = true;
            this.gridPessoas.RowHeadersVisible = false;
            this.gridPessoas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPessoas.Size = new System.Drawing.Size(317, 125);
            this.gridPessoas.TabIndex = 1;
            // 
            // boxProcurarProp
            // 
            this.boxProcurarProp.Location = new System.Drawing.Point(29, 23);
            this.boxProcurarProp.Name = "boxProcurarProp";
            this.boxProcurarProp.Size = new System.Drawing.Size(317, 20);
            this.boxProcurarProp.TabIndex = 0;
            this.boxProcurarProp.TextChanged += new System.EventHandler(this.BoxProcurarProp_TextChanged_1);
            // 
            // labelCod
            // 
            this.labelCod.AutoSize = true;
            this.labelCod.FontSize = MetroFramework.MetroLabelSize.Small;
            this.labelCod.Location = new System.Drawing.Point(32, 14);
            this.labelCod.Name = "labelCod";
            this.labelCod.Size = new System.Drawing.Size(52, 15);
            this.labelCod.TabIndex = 44;
            this.labelCod.Text = "Código *";
            this.labelCod.Visible = false;
            // 
            // codPessoaBox
            // 
            this.codPessoaBox.CustomBackground = true;
            this.codPessoaBox.CustomForeColor = true;
            this.codPessoaBox.ForeColor = System.Drawing.Color.DarkGray;
            this.codPessoaBox.Location = new System.Drawing.Point(30, 32);
            this.codPessoaBox.Name = "codPessoaBox";
            this.codPessoaBox.ReadOnly = true;
            this.codPessoaBox.Size = new System.Drawing.Size(54, 25);
            this.codPessoaBox.TabIndex = 42;
            this.codPessoaBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.codPessoaBox.Visible = false;
            // 
            // labelProp
            // 
            this.labelProp.AutoSize = true;
            this.labelProp.FontSize = MetroFramework.MetroLabelSize.Small;
            this.labelProp.Location = new System.Drawing.Point(208, 15);
            this.labelProp.Name = "labelProp";
            this.labelProp.Size = new System.Drawing.Size(42, 15);
            this.labelProp.TabIndex = 43;
            this.labelProp.Text = "Nome:";
            this.labelProp.Visible = false;
            this.labelProp.Click += new System.EventHandler(this.LabelProp_Click);
            // 
            // nomePessoaBox
            // 
            this.nomePessoaBox.CustomBackground = true;
            this.nomePessoaBox.CustomForeColor = true;
            this.nomePessoaBox.ForeColor = System.Drawing.Color.DarkGray;
            this.nomePessoaBox.Location = new System.Drawing.Point(92, 32);
            this.nomePessoaBox.Name = "nomePessoaBox";
            this.nomePessoaBox.ReadOnly = true;
            this.nomePessoaBox.Size = new System.Drawing.Size(268, 25);
            this.nomePessoaBox.TabIndex = 41;
            this.nomePessoaBox.Text = "Clique para adicionar";
            this.nomePessoaBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nomePessoaBox.Visible = false;
            this.nomePessoaBox.Click += new System.EventHandler(this.NomePessoaBox_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(107)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(86)))), ((int)(((byte)(122)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnCancelar.Location = new System.Drawing.Point(266, 479);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 40;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click_1);
            this.btnCancelar.MouseEnter += new System.EventHandler(this.BtnCancelar_MouseEnter);
            this.btnCancelar.MouseLeave += new System.EventHandler(this.BtnCancelar_MouseLeave);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(107)))));
            this.btnConfirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(86)))), ((int)(((byte)(122)))));
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(366, 480);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 39;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.BtnConfirmar_Click);
            // 
            // groupDadosEmp
            // 
            this.groupDadosEmp.Controls.Add(this.metroLabel3);
            this.groupDadosEmp.Controls.Add(this.dateRetirada);
            this.groupDadosEmp.Controls.Add(this.descBox);
            this.groupDadosEmp.Controls.Add(this.metroLabel6);
            this.groupDadosEmp.Location = new System.Drawing.Point(19, 81);
            this.groupDadosEmp.Name = "groupDadosEmp";
            this.groupDadosEmp.Size = new System.Drawing.Size(435, 96);
            this.groupDadosEmp.TabIndex = 34;
            this.groupDadosEmp.TabStop = false;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel3.Location = new System.Drawing.Point(301, 35);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(89, 15);
            this.metroLabel3.TabIndex = 11;
            this.metroLabel3.Text = "Data de retirada";
            this.metroLabel3.Click += new System.EventHandler(this.MetroLabel3_Click);
            // 
            // dateRetirada
            // 
            this.dateRetirada.CalendarForeColor = System.Drawing.Color.Gray;
            this.dateRetirada.CalendarTitleForeColor = System.Drawing.Color.Gray;
            this.dateRetirada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateRetirada.Location = new System.Drawing.Point(297, 52);
            this.dateRetirada.Name = "dateRetirada";
            this.dateRetirada.Size = new System.Drawing.Size(97, 20);
            this.dateRetirada.TabIndex = 10;
            this.dateRetirada.ValueChanged += new System.EventHandler(this.DatePrevisao_ValueChanged);
            // 
            // descBox
            // 
            this.descBox.CustomBackground = true;
            this.descBox.Location = new System.Drawing.Point(15, 27);
            this.descBox.MaxLength = 256;
            this.descBox.Multiline = true;
            this.descBox.Name = "descBox";
            this.descBox.Size = new System.Drawing.Size(270, 56);
            this.descBox.TabIndex = 9;
            this.descBox.UseStyleColors = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel6.Location = new System.Drawing.Point(128, 10);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(55, 15);
            this.metroLabel6.TabIndex = 8;
            this.metroLabel6.Text = "Descrição";
            // 
            // groupQuemEmpresta
            // 
            this.groupQuemEmpresta.Controls.Add(this.radioFuncionario);
            this.groupQuemEmpresta.Controls.Add(this.metroLabel1);
            this.groupQuemEmpresta.Controls.Add(this.radioCliente);
            this.groupQuemEmpresta.Controls.Add(this.radioProprietario);
            this.groupQuemEmpresta.Location = new System.Drawing.Point(19, 34);
            this.groupQuemEmpresta.Name = "groupQuemEmpresta";
            this.groupQuemEmpresta.Size = new System.Drawing.Size(435, 42);
            this.groupQuemEmpresta.TabIndex = 33;
            this.groupQuemEmpresta.TabStop = false;
            // 
            // radioFuncionario
            // 
            this.radioFuncionario.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.radioFuncionario.Location = new System.Drawing.Point(258, 13);
            this.radioFuncionario.Name = "radioFuncionario";
            this.radioFuncionario.Size = new System.Drawing.Size(101, 20);
            this.radioFuncionario.TabIndex = 2;
            this.radioFuncionario.TabStop = true;
            this.radioFuncionario.Text = "Funcionario";
            this.radioFuncionario.UseVisualStyleBackColor = true;
            this.radioFuncionario.CheckedChanged += new System.EventHandler(this.radioChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel1.Location = new System.Drawing.Point(136, -1);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(127, 15);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Quem está reservando?";
            // 
            // radioCliente
            // 
            this.radioCliente.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.radioCliente.Location = new System.Drawing.Point(52, 10);
            this.radioCliente.Name = "radioCliente";
            this.radioCliente.Size = new System.Drawing.Size(74, 26);
            this.radioCliente.TabIndex = 1;
            this.radioCliente.TabStop = true;
            this.radioCliente.Text = "Cliente";
            this.radioCliente.UseVisualStyleBackColor = true;
            this.radioCliente.CheckedChanged += new System.EventHandler(this.radioChanged);
            // 
            // radioProprietario
            // 
            this.radioProprietario.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.radioProprietario.Location = new System.Drawing.Point(138, 13);
            this.radioProprietario.Name = "radioProprietario";
            this.radioProprietario.Size = new System.Drawing.Size(101, 20);
            this.radioProprietario.TabIndex = 0;
            this.radioProprietario.TabStop = true;
            this.radioProprietario.Text = "Proprietario";
            this.radioProprietario.UseVisualStyleBackColor = true;
            this.radioProprietario.CheckedChanged += new System.EventHandler(this.radioChanged);
            // 
            // groupDadosCliente
            // 
            this.groupDadosCliente.Controls.Add(this.labelProp);
            this.groupDadosCliente.Controls.Add(this.labelCod);
            this.groupDadosCliente.Controls.Add(this.nomePessoaBox);
            this.groupDadosCliente.Controls.Add(this.btnAdicionarPessoa);
            this.groupDadosCliente.Controls.Add(this.codPessoaBox);
            this.groupDadosCliente.Controls.Add(this.metroLabel5);
            this.groupDadosCliente.Controls.Add(this.excluiProp);
            this.groupDadosCliente.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupDadosCliente.Location = new System.Drawing.Point(19, 183);
            this.groupDadosCliente.Name = "groupDadosCliente";
            this.groupDadosCliente.Size = new System.Drawing.Size(435, 77);
            this.groupDadosCliente.TabIndex = 35;
            this.groupDadosCliente.TabStop = false;
            this.groupDadosCliente.Enter += new System.EventHandler(this.GroupDadosCliente_Enter);
            // 
            // btnAdicionarPessoa
            // 
            this.btnAdicionarPessoa.AutoSize = true;
            this.btnAdicionarPessoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdicionarPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarPessoa.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAdicionarPessoa.Location = new System.Drawing.Point(149, 29);
            this.btnAdicionarPessoa.Name = "btnAdicionarPessoa";
            this.btnAdicionarPessoa.Size = new System.Drawing.Size(158, 15);
            this.btnAdicionarPessoa.TabIndex = 29;
            this.btnAdicionarPessoa.Text = "Escolher cliente/funcionário";
            this.btnAdicionarPessoa.Click += new System.EventHandler(this.BtnAdicionarPessoa_Click_1);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel5.Location = new System.Drawing.Point(123, -1);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(127, 15);
            this.metroLabel5.TabIndex = 3;
            this.metroLabel5.Text = "Quem está reservando?";
            // 
            // excluiProp
            // 
            this.excluiProp.AutoSize = true;
            this.excluiProp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.excluiProp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excluiProp.ForeColor = System.Drawing.SystemColors.Desktop;
            this.excluiProp.Location = new System.Drawing.Point(365, 32);
            this.excluiProp.Name = "excluiProp";
            this.excluiProp.Size = new System.Drawing.Size(25, 24);
            this.excluiProp.TabIndex = 33;
            this.excluiProp.Text = "X";
            this.excluiProp.Visible = false;
            this.excluiProp.Click += new System.EventHandler(this.ExcluiProp_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddChave);
            this.groupBox1.Controls.Add(this.gridChaves);
            this.groupBox1.Controls.Add(this.metroLabel2);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox1.Location = new System.Drawing.Point(19, 266);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 185);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            // 
            // btnAddChave
            // 
            this.btnAddChave.AutoSize = true;
            this.btnAddChave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddChave.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnAddChave.Location = new System.Drawing.Point(14, 152);
            this.btnAddChave.Name = "btnAddChave";
            this.btnAddChave.Size = new System.Drawing.Size(85, 13);
            this.btnAddChave.TabIndex = 5;
            this.btnAddChave.Text = "Adicionar Chave";
            this.btnAddChave.Click += new System.EventHandler(this.BtnAddChave_Click);
            // 
            // gridChaves
            // 
            this.gridChaves.AllowUserToAddRows = false;
            this.gridChaves.AllowUserToDeleteRows = false;
            this.gridChaves.AllowUserToResizeRows = false;
            this.gridChaves.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.gridChaves.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridChaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridChaves.DefaultCellStyle = dataGridViewCellStyle1;
            this.gridChaves.Location = new System.Drawing.Point(12, 19);
            this.gridChaves.MultiSelect = false;
            this.gridChaves.Name = "gridChaves";
            this.gridChaves.ReadOnly = true;
            this.gridChaves.RowHeadersVisible = false;
            this.gridChaves.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridChaves.Size = new System.Drawing.Size(408, 110);
            this.gridChaves.TabIndex = 4;
            this.gridChaves.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridChaves_CellContentClick);
            this.gridChaves.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridChaves_CellMouseEnter);
            this.gridChaves.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.GridChaves_RowsAdded);
            this.gridChaves.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.GridChaves_RowsRemoved);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel2.Location = new System.Drawing.Point(123, -1);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(183, 15);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Dados de quem está emprestando";
            // 
            // panelChaves
            // 
            this.panelChaves.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelChaves.Controls.Add(this.btnCancelarChave);
            this.panelChaves.Controls.Add(this.btnConfirmChave);
            this.panelChaves.Controls.Add(this.gridChavesTotal);
            this.panelChaves.Controls.Add(this.boxBusca);
            this.panelChaves.Location = new System.Drawing.Point(19, 247);
            this.panelChaves.Name = "panelChaves";
            this.panelChaves.Size = new System.Drawing.Size(435, 225);
            this.panelChaves.TabIndex = 44;
            this.panelChaves.Visible = false;
            // 
            // btnCancelarChave
            // 
            this.btnCancelarChave.BackColor = System.Drawing.Color.White;
            this.btnCancelarChave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnCancelarChave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(107)))));
            this.btnCancelarChave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(86)))), ((int)(((byte)(122)))));
            this.btnCancelarChave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarChave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnCancelarChave.Location = new System.Drawing.Point(260, 196);
            this.btnCancelarChave.Name = "btnCancelarChave";
            this.btnCancelarChave.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarChave.TabIndex = 26;
            this.btnCancelarChave.Text = "Cancelar";
            this.btnCancelarChave.UseVisualStyleBackColor = false;
            this.btnCancelarChave.Click += new System.EventHandler(this.BtnCancelarChave_Click);
            // 
            // btnConfirmChave
            // 
            this.btnConfirmChave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnConfirmChave.FlatAppearance.BorderSize = 0;
            this.btnConfirmChave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(107)))));
            this.btnConfirmChave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(86)))), ((int)(((byte)(122)))));
            this.btnConfirmChave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmChave.ForeColor = System.Drawing.Color.White;
            this.btnConfirmChave.Location = new System.Drawing.Point(352, 197);
            this.btnConfirmChave.Name = "btnConfirmChave";
            this.btnConfirmChave.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmChave.TabIndex = 25;
            this.btnConfirmChave.Text = "Confirmar";
            this.btnConfirmChave.UseVisualStyleBackColor = false;
            this.btnConfirmChave.Click += new System.EventHandler(this.BtnConfirmChave_Click);
            // 
            // gridChavesTotal
            // 
            this.gridChavesTotal.AllowUserToAddRows = false;
            this.gridChavesTotal.AllowUserToDeleteRows = false;
            this.gridChavesTotal.AllowUserToResizeRows = false;
            this.gridChavesTotal.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.gridChavesTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridChavesTotal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridChavesTotal.Location = new System.Drawing.Point(7, 55);
            this.gridChavesTotal.Name = "gridChavesTotal";
            this.gridChavesTotal.ReadOnly = true;
            this.gridChavesTotal.RowHeadersVisible = false;
            this.gridChavesTotal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridChavesTotal.Size = new System.Drawing.Size(420, 125);
            this.gridChavesTotal.TabIndex = 1;
            // 
            // boxBusca
            // 
            this.boxBusca.Location = new System.Drawing.Point(7, 23);
            this.boxBusca.Name = "boxBusca";
            this.boxBusca.Size = new System.Drawing.Size(420, 20);
            this.boxBusca.TabIndex = 0;
            // 
            // CadastroReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(468, 515);
            this.Controls.Add(this.panelChaves);
            this.Controls.Add(this.painelProp);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.groupDadosEmp);
            this.Controls.Add(this.groupQuemEmpresta);
            this.Controls.Add(this.groupDadosCliente);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CadastroReserva";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Text = "ReservarChave";
            this.Load += new System.EventHandler(this.ReservarChave_Load);
            this.painelProp.ResumeLayout(false);
            this.painelProp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPessoas)).EndInit();
            this.groupDadosEmp.ResumeLayout(false);
            this.groupDadosEmp.PerformLayout();
            this.groupQuemEmpresta.ResumeLayout(false);
            this.groupQuemEmpresta.PerformLayout();
            this.groupDadosCliente.ResumeLayout(false);
            this.groupDadosCliente.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridChaves)).EndInit();
            this.panelChaves.ResumeLayout(false);
            this.panelChaves.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridChavesTotal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel painelProp;
        private System.Windows.Forms.Button btnNovoProp;
        private System.Windows.Forms.Button btnCancelarProp;
        private System.Windows.Forms.Button btnConfirmarProp;
        private System.Windows.Forms.DataGridView gridPessoas;
        private System.Windows.Forms.TextBox boxProcurarProp;
        private MetroFramework.Controls.MetroLabel labelCod;
        private MetroFramework.Controls.MetroTextBox codPessoaBox;
        private MetroFramework.Controls.MetroLabel labelProp;
        private MetroFramework.Controls.MetroTextBox nomePessoaBox;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.GroupBox groupDadosEmp;
        private MetroFramework.Controls.MetroTextBox descBox;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private System.Windows.Forms.GroupBox groupQuemEmpresta;
        private MetroFramework.Controls.MetroRadioButton radioFuncionario;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroRadioButton radioCliente;
        private MetroFramework.Controls.MetroRadioButton radioProprietario;
        private System.Windows.Forms.GroupBox groupDadosCliente;
        private System.Windows.Forms.Label btnAdicionarPessoa;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private System.Windows.Forms.Label excluiProp;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.DateTimePicker dateRetirada;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label btnAddChave;
        private System.Windows.Forms.DataGridView gridChaves;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.Panel panelChaves;
        private System.Windows.Forms.Button btnCancelarChave;
        private System.Windows.Forms.Button btnConfirmChave;
        private System.Windows.Forms.DataGridView gridChavesTotal;
        private System.Windows.Forms.TextBox boxBusca;
    }
}