namespace situacaoChavesGolden
{
    partial class CadastrarEmprestimo
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
            this.groupQuemEmpresta = new System.Windows.Forms.GroupBox();
            this.radioFuncionario = new MetroFramework.Controls.MetroRadioButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.radioCliente = new MetroFramework.Controls.MetroRadioButton();
            this.radioProprietario = new MetroFramework.Controls.MetroRadioButton();
            this.groupDadosEmp = new System.Windows.Forms.GroupBox();
            this.qtdControles = new System.Windows.Forms.NumericUpDown();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.qtdChaves = new System.Windows.Forms.NumericUpDown();
            this.descBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.previsaoLabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.datePrevisao = new System.Windows.Forms.DateTimePicker();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.codigoChaveBox = new MetroFramework.Controls.MetroTextBox();
            this.groupDadosCliente = new System.Windows.Forms.GroupBox();
            this.btnAdicionarPessoa = new System.Windows.Forms.Label();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.excluiProp = new System.Windows.Forms.Label();
            this.boxDescDoc = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.comboDocs = new MetroFramework.Controls.MetroComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCodChave = new System.Windows.Forms.Label();
            this.endereco = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textoCodChave = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textoTel2 = new System.Windows.Forms.Label();
            this.textoTel1 = new System.Windows.Forms.Label();
            this.textoCpf = new System.Windows.Forms.Label();
            this.nome = new System.Windows.Forms.Label();
            this.btnEditarCliente = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.labelTel1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelTel2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelCpf = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
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
            this.groupQuemEmpresta.SuspendLayout();
            this.groupDadosEmp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtdControles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtdChaves)).BeginInit();
            this.groupDadosCliente.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.painelProp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPessoas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupQuemEmpresta
            // 
            this.groupQuemEmpresta.Controls.Add(this.radioFuncionario);
            this.groupQuemEmpresta.Controls.Add(this.metroLabel1);
            this.groupQuemEmpresta.Controls.Add(this.radioCliente);
            this.groupQuemEmpresta.Controls.Add(this.radioProprietario);
            this.groupQuemEmpresta.Location = new System.Drawing.Point(9, 34);
            this.groupQuemEmpresta.Name = "groupQuemEmpresta";
            this.groupQuemEmpresta.Size = new System.Drawing.Size(410, 42);
            this.groupQuemEmpresta.TabIndex = 0;
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
            this.radioFuncionario.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel1.Location = new System.Drawing.Point(136, -1);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(138, 15);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Quem está emprestando?";
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
            this.radioCliente.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
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
            this.radioProprietario.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // groupDadosEmp
            // 
            this.groupDadosEmp.Controls.Add(this.qtdControles);
            this.groupDadosEmp.Controls.Add(this.metroLabel11);
            this.groupDadosEmp.Controls.Add(this.qtdChaves);
            this.groupDadosEmp.Controls.Add(this.descBox);
            this.groupDadosEmp.Controls.Add(this.metroLabel6);
            this.groupDadosEmp.Controls.Add(this.previsaoLabel);
            this.groupDadosEmp.Controls.Add(this.metroLabel4);
            this.groupDadosEmp.Controls.Add(this.metroLabel3);
            this.groupDadosEmp.Controls.Add(this.datePrevisao);
            this.groupDadosEmp.Controls.Add(this.metroLabel2);
            this.groupDadosEmp.Controls.Add(this.codigoChaveBox);
            this.groupDadosEmp.Location = new System.Drawing.Point(9, 81);
            this.groupDadosEmp.Name = "groupDadosEmp";
            this.groupDadosEmp.Size = new System.Drawing.Size(410, 122);
            this.groupDadosEmp.TabIndex = 1;
            this.groupDadosEmp.TabStop = false;
            // 
            // qtdControles
            // 
            this.qtdControles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.qtdControles.Location = new System.Drawing.Point(335, 29);
            this.qtdControles.Name = "qtdControles";
            this.qtdControles.Size = new System.Drawing.Size(60, 20);
            this.qtdControles.TabIndex = 13;
            this.qtdControles.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel11.Location = new System.Drawing.Point(326, 11);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(78, 15);
            this.metroLabel11.TabIndex = 12;
            this.metroLabel11.Text = "Qtd Controles";
            // 
            // qtdChaves
            // 
            this.qtdChaves.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.qtdChaves.Location = new System.Drawing.Point(262, 29);
            this.qtdChaves.Name = "qtdChaves";
            this.qtdChaves.Size = new System.Drawing.Size(60, 20);
            this.qtdChaves.TabIndex = 11;
            this.qtdChaves.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // descBox
            // 
            this.descBox.CustomBackground = true;
            this.descBox.Location = new System.Drawing.Point(15, 74);
            this.descBox.Multiline = true;
            this.descBox.Name = "descBox";
            this.descBox.Size = new System.Drawing.Size(380, 33);
            this.descBox.TabIndex = 9;
            this.descBox.UseStyleColors = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel6.Location = new System.Drawing.Point(178, 56);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(55, 15);
            this.metroLabel6.TabIndex = 8;
            this.metroLabel6.Text = "Descrição";
            // 
            // previsaoLabel
            // 
            this.previsaoLabel.AutoSize = true;
            this.previsaoLabel.Location = new System.Drawing.Point(199, 29);
            this.previsaoLabel.Name = "previsaoLabel";
            this.previsaoLabel.Size = new System.Drawing.Size(53, 19);
            this.previsaoLabel.TabIndex = 6;
            this.previsaoLabel.Text = "1 dia (s)";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel4.Location = new System.Drawing.Point(253, 11);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(65, 15);
            this.metroLabel4.TabIndex = 4;
            this.metroLabel4.Text = "Qtd Chaves";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel3.Location = new System.Drawing.Point(88, 12);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(110, 15);
            this.metroLabel3.TabIndex = 3;
            this.metroLabel3.Text = "Previsão de entrega:";
            // 
            // datePrevisao
            // 
            this.datePrevisao.CalendarForeColor = System.Drawing.Color.Gray;
            this.datePrevisao.CalendarTitleForeColor = System.Drawing.Color.Gray;
            this.datePrevisao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePrevisao.Location = new System.Drawing.Point(91, 29);
            this.datePrevisao.Name = "datePrevisao";
            this.datePrevisao.Size = new System.Drawing.Size(105, 20);
            this.datePrevisao.TabIndex = 2;
            this.datePrevisao.ValueChanged += new System.EventHandler(this.DateTimePicker1_ValueChanged);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel2.Location = new System.Drawing.Point(15, 11);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(64, 15);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Cod. Chave";
            // 
            // codigoChaveBox
            // 
            this.codigoChaveBox.CustomBackground = true;
            this.codigoChaveBox.CustomForeColor = true;
            this.codigoChaveBox.ForeColor = System.Drawing.Color.Gray;
            this.codigoChaveBox.Location = new System.Drawing.Point(15, 26);
            this.codigoChaveBox.MaxLength = 12;
            this.codigoChaveBox.Name = "codigoChaveBox";
            this.codigoChaveBox.ReadOnly = true;
            this.codigoChaveBox.Size = new System.Drawing.Size(64, 26);
            this.codigoChaveBox.TabIndex = 2;
            this.codigoChaveBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.codigoChaveBox.UseStyleColors = true;
            // 
            // groupDadosCliente
            // 
            this.groupDadosCliente.Controls.Add(this.btnAdicionarPessoa);
            this.groupDadosCliente.Controls.Add(this.metroLabel5);
            this.groupDadosCliente.Controls.Add(this.metroLabel10);
            this.groupDadosCliente.Controls.Add(this.excluiProp);
            this.groupDadosCliente.Controls.Add(this.boxDescDoc);
            this.groupDadosCliente.Controls.Add(this.metroLabel9);
            this.groupDadosCliente.Controls.Add(this.comboDocs);
            this.groupDadosCliente.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupDadosCliente.Location = new System.Drawing.Point(9, 209);
            this.groupDadosCliente.Name = "groupDadosCliente";
            this.groupDadosCliente.Size = new System.Drawing.Size(410, 117);
            this.groupDadosCliente.TabIndex = 10;
            this.groupDadosCliente.TabStop = false;
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
            this.btnAdicionarPessoa.Click += new System.EventHandler(this.btnAdicionarPessoa_Click);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel5.Location = new System.Drawing.Point(123, -1);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(183, 15);
            this.metroLabel5.TabIndex = 3;
            this.metroLabel5.Text = "Dados de quem está emprestando";
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel10.Location = new System.Drawing.Point(193, 59);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(133, 15);
            this.metroLabel10.TabIndex = 14;
            this.metroLabel10.Text = "Descrição do documento";
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
            this.excluiProp.Click += new System.EventHandler(this.ExcluiProp_Click);
            // 
            // boxDescDoc
            // 
            this.boxDescDoc.CustomBackground = true;
            this.boxDescDoc.CustomForeColor = true;
            this.boxDescDoc.ForeColor = System.Drawing.Color.Gray;
            this.boxDescDoc.Location = new System.Drawing.Point(136, 75);
            this.boxDescDoc.MaxLength = 14;
            this.boxDescDoc.Name = "boxDescDoc";
            this.boxDescDoc.Size = new System.Drawing.Size(246, 26);
            this.boxDescDoc.TabIndex = 15;
            this.boxDescDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.boxDescDoc.UseStyleColors = true;
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel9.Location = new System.Drawing.Point(39, 60);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(73, 15);
            this.metroLabel9.TabIndex = 13;
            this.metroLabel9.Text = "Doc. deixado";
            // 
            // comboDocs
            // 
            this.comboDocs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboDocs.FontSize = MetroFramework.MetroLinkSize.Small;
            this.comboDocs.FormattingEnabled = true;
            this.comboDocs.ItemHeight = 19;
            this.comboDocs.Location = new System.Drawing.Point(30, 76);
            this.comboDocs.Name = "comboDocs";
            this.comboDocs.Size = new System.Drawing.Size(85, 25);
            this.comboDocs.Style = MetroFramework.MetroColorStyle.Blue;
            this.comboDocs.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 14);
            this.label1.TabIndex = 11;
            this.label1.Text = "Cod. Chave:";
            // 
            // labelCodChave
            // 
            this.labelCodChave.AutoSize = true;
            this.labelCodChave.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCodChave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelCodChave.Location = new System.Drawing.Point(75, 11);
            this.labelCodChave.Name = "labelCodChave";
            this.labelCodChave.Size = new System.Drawing.Size(0, 14);
            this.labelCodChave.TabIndex = 12;
            // 
            // endereco
            // 
            this.endereco.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endereco.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.endereco.Location = new System.Drawing.Point(25, 48);
            this.endereco.MinimumSize = new System.Drawing.Size(160, 0);
            this.endereco.Name = "endereco";
            this.endereco.Size = new System.Drawing.Size(160, 14);
            this.endereco.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 14);
            this.label4.TabIndex = 13;
            this.label4.Text = "Endereço:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textoCodChave);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.endereco);
            this.groupBox3.Controls.Add(this.labelCodChave);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(9, 332);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 117);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            // 
            // textoCodChave
            // 
            this.textoCodChave.AutoSize = true;
            this.textoCodChave.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textoCodChave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textoCodChave.Location = new System.Drawing.Point(75, 11);
            this.textoCodChave.Name = "textoCodChave";
            this.textoCodChave.Size = new System.Drawing.Size(39, 14);
            this.textoCodChave.TabIndex = 34;
            this.textoCodChave.Text = "codigo";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textoTel2);
            this.groupBox4.Controls.Add(this.textoTel1);
            this.groupBox4.Controls.Add(this.textoCpf);
            this.groupBox4.Controls.Add(this.nome);
            this.groupBox4.Controls.Add(this.btnEditarCliente);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.email);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.labelTel1);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.labelTel2);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.labelCpf);
            this.groupBox4.Location = new System.Drawing.Point(215, 332);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(204, 117);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Enter += new System.EventHandler(this.GroupBox4_Enter);
            // 
            // textoTel2
            // 
            this.textoTel2.AutoSize = true;
            this.textoTel2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textoTel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textoTel2.Location = new System.Drawing.Point(131, 30);
            this.textoTel2.Name = "textoTel2";
            this.textoTel2.Size = new System.Drawing.Size(0, 14);
            this.textoTel2.TabIndex = 33;
            // 
            // textoTel1
            // 
            this.textoTel1.AutoSize = true;
            this.textoTel1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textoTel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textoTel1.Location = new System.Drawing.Point(30, 31);
            this.textoTel1.Name = "textoTel1";
            this.textoTel1.Size = new System.Drawing.Size(0, 14);
            this.textoTel1.TabIndex = 32;
            // 
            // textoCpf
            // 
            this.textoCpf.AutoSize = true;
            this.textoCpf.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textoCpf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textoCpf.Location = new System.Drawing.Point(28, 11);
            this.textoCpf.Name = "textoCpf";
            this.textoCpf.Size = new System.Drawing.Size(0, 14);
            this.textoCpf.TabIndex = 31;
            // 
            // nome
            // 
            this.nome.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nome.Location = new System.Drawing.Point(41, 75);
            this.nome.MinimumSize = new System.Drawing.Size(150, 25);
            this.nome.Name = "nome";
            this.nome.Size = new System.Drawing.Size(150, 25);
            this.nome.TabIndex = 30;
            this.nome.Text = " ";
            // 
            // btnEditarCliente
            // 
            this.btnEditarCliente.AutoSize = true;
            this.btnEditarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarCliente.Enabled = false;
            this.btnEditarCliente.Font = new System.Drawing.Font("Arial", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnEditarCliente.Location = new System.Drawing.Point(165, 101);
            this.btnEditarCliente.Name = "btnEditarCliente";
            this.btnEditarCliente.Size = new System.Drawing.Size(34, 12);
            this.btnEditarCliente.TabIndex = 29;
            this.btnEditarCliente.Text = "Editar";
            this.btnEditarCliente.Click += new System.EventHandler(this.BtnEditarCliente_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(1, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 14);
            this.label12.TabIndex = 23;
            this.label12.Text = "Email:";
            // 
            // email
            // 
            this.email.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.email.Location = new System.Drawing.Point(38, 48);
            this.email.MinimumSize = new System.Drawing.Size(150, 25);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(150, 25);
            this.email.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 14);
            this.label10.TabIndex = 21;
            this.label10.Text = "Tel2:";
            // 
            // labelTel1
            // 
            this.labelTel1.AutoSize = true;
            this.labelTel1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTel1.Location = new System.Drawing.Point(29, 31);
            this.labelTel1.Name = "labelTel1";
            this.labelTel1.Size = new System.Drawing.Size(10, 14);
            this.labelTel1.TabIndex = 22;
            this.labelTel1.Text = " ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 14);
            this.label6.TabIndex = 17;
            this.label6.Text = "Nome:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(103, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 14);
            this.label8.TabIndex = 19;
            this.label8.Text = "Tel1:";
            // 
            // labelTel2
            // 
            this.labelTel2.AutoSize = true;
            this.labelTel2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTel2.Location = new System.Drawing.Point(131, 30);
            this.labelTel2.Name = "labelTel2";
            this.labelTel2.Size = new System.Drawing.Size(10, 14);
            this.labelTel2.TabIndex = 20;
            this.labelTel2.Text = " ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 14);
            this.label3.TabIndex = 15;
            this.label3.Text = "CPF:";
            // 
            // labelCpf
            // 
            this.labelCpf.AutoSize = true;
            this.labelCpf.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCpf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelCpf.Location = new System.Drawing.Point(29, 11);
            this.labelCpf.Name = "labelCpf";
            this.labelCpf.Size = new System.Drawing.Size(10, 14);
            this.labelCpf.TabIndex = 16;
            this.labelCpf.Text = " ";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(107)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(86)))), ((int)(((byte)(122)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnCancelar.Location = new System.Drawing.Point(235, 454);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 28;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(107)))));
            this.btnConfirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(86)))), ((int)(((byte)(122)))));
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(335, 455);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 27;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.BtnConfirmar_Click);
            // 
            // painelProp
            // 
            this.painelProp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.painelProp.Controls.Add(this.btnNovoProp);
            this.painelProp.Controls.Add(this.btnCancelarProp);
            this.painelProp.Controls.Add(this.btnConfirmarProp);
            this.painelProp.Controls.Add(this.gridPessoas);
            this.painelProp.Controls.Add(this.boxProcurarProp);
            this.painelProp.Location = new System.Drawing.Point(25, 166);
            this.painelProp.Name = "painelProp";
            this.painelProp.Size = new System.Drawing.Size(374, 225);
            this.painelProp.TabIndex = 26;
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
            this.btnNovoProp.Click += new System.EventHandler(this.BtnNovoProp_Click);
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
            this.btnCancelarProp.Click += new System.EventHandler(this.btnCancelarProp_Click);
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
            this.btnConfirmarProp.Click += new System.EventHandler(this.btnConfirmarProp_Click);
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
            this.boxProcurarProp.TextChanged += new System.EventHandler(this.BoxProcurarProp_TextChanged);
            // 
            // labelCod
            // 
            this.labelCod.AutoSize = true;
            this.labelCod.FontSize = MetroFramework.MetroLabelSize.Small;
            this.labelCod.Location = new System.Drawing.Point(43, 222);
            this.labelCod.Name = "labelCod";
            this.labelCod.Size = new System.Drawing.Size(52, 15);
            this.labelCod.TabIndex = 32;
            this.labelCod.Text = "Código *";
            this.labelCod.Visible = false;
            // 
            // codPessoaBox
            // 
            this.codPessoaBox.CustomBackground = true;
            this.codPessoaBox.CustomForeColor = true;
            this.codPessoaBox.ForeColor = System.Drawing.Color.DarkGray;
            this.codPessoaBox.Location = new System.Drawing.Point(41, 240);
            this.codPessoaBox.Name = "codPessoaBox";
            this.codPessoaBox.ReadOnly = true;
            this.codPessoaBox.Size = new System.Drawing.Size(54, 25);
            this.codPessoaBox.TabIndex = 30;
            this.codPessoaBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.codPessoaBox.Visible = false;
            // 
            // labelProp
            // 
            this.labelProp.AutoSize = true;
            this.labelProp.FontSize = MetroFramework.MetroLabelSize.Small;
            this.labelProp.Location = new System.Drawing.Point(204, 223);
            this.labelProp.Name = "labelProp";
            this.labelProp.Size = new System.Drawing.Size(42, 15);
            this.labelProp.TabIndex = 31;
            this.labelProp.Text = "Nome:";
            this.labelProp.Visible = false;
            // 
            // nomePessoaBox
            // 
            this.nomePessoaBox.CustomBackground = true;
            this.nomePessoaBox.CustomForeColor = true;
            this.nomePessoaBox.ForeColor = System.Drawing.Color.DarkGray;
            this.nomePessoaBox.Location = new System.Drawing.Point(100, 240);
            this.nomePessoaBox.Name = "nomePessoaBox";
            this.nomePessoaBox.ReadOnly = true;
            this.nomePessoaBox.Size = new System.Drawing.Size(268, 25);
            this.nomePessoaBox.TabIndex = 29;
            this.nomePessoaBox.Text = "Clique para adicionar";
            this.nomePessoaBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nomePessoaBox.Visible = false;
            // 
            // CadastrarEmprestimo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(429, 486);
            this.Controls.Add(this.painelProp);
            this.Controls.Add(this.labelCod);
            this.Controls.Add(this.codPessoaBox);
            this.Controls.Add(this.labelProp);
            this.Controls.Add(this.nomePessoaBox);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupDadosEmp);
            this.Controls.Add(this.groupQuemEmpresta);
            this.Controls.Add(this.groupDadosCliente);
            this.DisplayHeader = false;
            this.Name = "CadastrarEmprestimo";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.None;
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Text = "CadastrarEmprestimo";
            this.Load += new System.EventHandler(this.CadastrarEmprestimo_Load);
            this.groupQuemEmpresta.ResumeLayout(false);
            this.groupQuemEmpresta.PerformLayout();
            this.groupDadosEmp.ResumeLayout(false);
            this.groupDadosEmp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtdControles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtdChaves)).EndInit();
            this.groupDadosCliente.ResumeLayout(false);
            this.groupDadosCliente.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.painelProp.ResumeLayout(false);
            this.painelProp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPessoas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupQuemEmpresta;
        private MetroFramework.Controls.MetroRadioButton radioCliente;
        private MetroFramework.Controls.MetroRadioButton radioProprietario;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.GroupBox groupDadosEmp;
        private MetroFramework.Controls.MetroLabel previsaoLabel;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.DateTimePicker datePrevisao;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox codigoChaveBox;
        private MetroFramework.Controls.MetroTextBox descBox;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private System.Windows.Forms.GroupBox groupDadosCliente;
        private System.Windows.Forms.NumericUpDown qtdChaves;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroTextBox boxDescDoc;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroComboBox comboDocs;
        private System.Windows.Forms.NumericUpDown qtdControles;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCodChave;
        private System.Windows.Forms.Label endereco;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label email;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelTel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelTel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelCpf;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label btnEditarCliente;
        private System.Windows.Forms.Label nome;
        private System.Windows.Forms.Label textoCpf;
        private System.Windows.Forms.Label textoTel2;
        private System.Windows.Forms.Label textoTel1;
        private System.Windows.Forms.Label textoCodChave;
        private MetroFramework.Controls.MetroRadioButton radioFuncionario;
        private System.Windows.Forms.Panel painelProp;
        private System.Windows.Forms.Button btnNovoProp;
        private System.Windows.Forms.Button btnCancelarProp;
        private System.Windows.Forms.Button btnConfirmarProp;
        private System.Windows.Forms.DataGridView gridPessoas;
        private System.Windows.Forms.TextBox boxProcurarProp;
        private MetroFramework.Controls.MetroLabel labelCod;
        private MetroFramework.Controls.MetroTextBox codPessoaBox;
        private MetroFramework.Controls.MetroLabel labelProp;
        private System.Windows.Forms.Label excluiProp;
        private MetroFramework.Controls.MetroTextBox nomePessoaBox;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private System.Windows.Forms.Label btnAdicionarPessoa;
    }
}