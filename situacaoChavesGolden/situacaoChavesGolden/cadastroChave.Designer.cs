﻿namespace situacaoChavesGolden
{
    partial class cadastroChave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cadastroChave));
            this.boxLogradouro = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.boxNumero = new MetroFramework.Controls.MetroTextBox();
            this.boxCidade = new MetroFramework.Controls.MetroTextBox();
            this.boxBairro = new MetroFramework.Controls.MetroTextBox();
            this.boxEstado = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.boxComplemento = new MetroFramework.Controls.MetroTextBox();
            this.groupSitImovel = new System.Windows.Forms.GroupBox();
            this.radioImovInativo = new MetroFramework.Controls.MetroRadioButton();
            this.radioImovAtivo = new MetroFramework.Controls.MetroRadioButton();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.groupFinalImovel = new System.Windows.Forms.GroupBox();
            this.checkVenda = new MetroFramework.Controls.MetroCheckBox();
            this.checkLocacao = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.groupTipoImovel = new System.Windows.Forms.GroupBox();
            this.radioTipoCom = new MetroFramework.Controls.MetroRadioButton();
            this.radioTipoRes = new MetroFramework.Controls.MetroRadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.excluiProp = new System.Windows.Forms.Label();
            this.labelCod = new MetroFramework.Controls.MetroLabel();
            this.boxCodProp = new MetroFramework.Controls.MetroTextBox();
            this.nomePropBox = new MetroFramework.Controls.MetroTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.metroLabel15 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.groupSitChave = new System.Windows.Forms.GroupBox();
            this.radioChaveIndisponivel = new MetroFramework.Controls.MetroRadioButton();
            this.radioChaveDisponivel = new MetroFramework.Controls.MetroRadioButton();
            this.boxOutraLocalizacao = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.comboLocalizacao = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.codImovel = new MetroFramework.Controls.MetroTextBox();
            this.labelProp = new MetroFramework.Controls.MetroLabel();
            this.metroLabel14 = new MetroFramework.Controls.MetroLabel();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.painelProp = new System.Windows.Forms.Panel();
            this.btnNovoProp = new System.Windows.Forms.Button();
            this.btnCancelarProp = new System.Windows.Forms.Button();
            this.btnConfirmarProp = new System.Windows.Forms.Button();
            this.gridProprietarios = new System.Windows.Forms.DataGridView();
            this.boxProcurarProp = new System.Windows.Forms.TextBox();
            this.btnAdicionarProp = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.boxQtdChaves = new System.Windows.Forms.NumericUpDown();
            this.metroLabel16 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel17 = new MetroFramework.Controls.MetroLabel();
            this.boxCategImov = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.boxCond = new MetroFramework.Controls.MetroTextBox();
            this.btnCadastrarAviso = new System.Windows.Forms.Label();
            this.panelAviso = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.metroLabel18 = new MetroFramework.Controls.MetroLabel();
            this.button3 = new System.Windows.Forms.Button();
            this.boxAviso = new System.Windows.Forms.TextBox();
            this.groupSitImovel.SuspendLayout();
            this.groupFinalImovel.SuspendLayout();
            this.groupTipoImovel.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupSitChave.SuspendLayout();
            this.painelProp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProprietarios)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxQtdChaves)).BeginInit();
            this.panelAviso.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // boxLogradouro
            // 
            this.boxLogradouro.CustomBackground = true;
            this.boxLogradouro.CustomForeColor = true;
            this.boxLogradouro.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.boxLogradouro.Location = new System.Drawing.Point(29, 175);
            this.boxLogradouro.MaxLength = 100;
            this.boxLogradouro.Name = "boxLogradouro";
            this.boxLogradouro.Size = new System.Drawing.Size(374, 25);
            this.boxLogradouro.TabIndex = 1;
            this.boxLogradouro.UseStyleColors = true;
            this.boxLogradouro.Click += new System.EventHandler(this.BoxLogradouro_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel1.Location = new System.Drawing.Point(169, 159);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(78, 15);
            this.metroLabel1.TabIndex = 600;
            this.metroLabel1.Text = "Logradouro  *";
            // 
            // boxNumero
            // 
            this.boxNumero.CustomBackground = true;
            this.boxNumero.CustomForeColor = true;
            this.boxNumero.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.boxNumero.Location = new System.Drawing.Point(13, 81);
            this.boxNumero.MaxLength = 20;
            this.boxNumero.Name = "boxNumero";
            this.boxNumero.Size = new System.Drawing.Size(62, 25);
            this.boxNumero.TabIndex = 2;
            this.boxNumero.UseStyleColors = true;
            // 
            // boxCidade
            // 
            this.boxCidade.CustomBackground = true;
            this.boxCidade.CustomForeColor = true;
            this.boxCidade.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.boxCidade.Location = new System.Drawing.Point(13, 134);
            this.boxCidade.MaxLength = 50;
            this.boxCidade.Name = "boxCidade";
            this.boxCidade.Size = new System.Drawing.Size(157, 25);
            this.boxCidade.TabIndex = 10;
            this.boxCidade.UseStyleColors = true;
            // 
            // boxBairro
            // 
            this.boxBairro.CustomBackground = true;
            this.boxBairro.CustomForeColor = true;
            this.boxBairro.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.boxBairro.Location = new System.Drawing.Point(89, 81);
            this.boxBairro.MaxLength = 50;
            this.boxBairro.Name = "boxBairro";
            this.boxBairro.Size = new System.Drawing.Size(124, 25);
            this.boxBairro.TabIndex = 3;
            this.boxBairro.UseStyleColors = true;
            // 
            // boxEstado
            // 
            this.boxEstado.CustomBackground = true;
            this.boxEstado.CustomForeColor = true;
            this.boxEstado.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.boxEstado.Location = new System.Drawing.Point(176, 134);
            this.boxEstado.MaxLength = 2;
            this.boxEstado.Name = "boxEstado";
            this.boxEstado.Size = new System.Drawing.Size(26, 25);
            this.boxEstado.TabIndex = 11;
            this.boxEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.boxEstado.UseStyleColors = true;
            this.boxEstado.Leave += new System.EventHandler(this.BoxEstado_Leave);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel2.Location = new System.Drawing.Point(17, 66);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(57, 15);
            this.metroLabel2.TabIndex = 6;
            this.metroLabel2.Text = "Número *";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel3.Location = new System.Drawing.Point(68, 119);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(47, 15);
            this.metroLabel3.TabIndex = 700;
            this.metroLabel3.Text = "Cidade*";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel4.Location = new System.Drawing.Point(128, 66);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(45, 15);
            this.metroLabel4.TabIndex = 8;
            this.metroLabel4.Text = "Bairro *";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel5.Location = new System.Drawing.Point(175, 117);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(29, 15);
            this.metroLabel5.TabIndex = 800;
            this.metroLabel5.Text = "UF *";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel6.Location = new System.Drawing.Point(262, 66);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(87, 15);
            this.metroLabel6.TabIndex = 11;
            this.metroLabel6.Text = "Complemento *";
            // 
            // boxComplemento
            // 
            this.boxComplemento.CustomBackground = true;
            this.boxComplemento.CustomForeColor = true;
            this.boxComplemento.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.boxComplemento.Location = new System.Drawing.Point(226, 81);
            this.boxComplemento.MaxLength = 50;
            this.boxComplemento.Name = "boxComplemento";
            this.boxComplemento.Size = new System.Drawing.Size(158, 25);
            this.boxComplemento.TabIndex = 4;
            this.boxComplemento.UseStyleColors = true;
            // 
            // groupSitImovel
            // 
            this.groupSitImovel.Controls.Add(this.radioImovInativo);
            this.groupSitImovel.Controls.Add(this.radioImovAtivo);
            this.groupSitImovel.Location = new System.Drawing.Point(226, 273);
            this.groupSitImovel.Name = "groupSitImovel";
            this.groupSitImovel.Size = new System.Drawing.Size(175, 32);
            this.groupSitImovel.TabIndex = 12;
            this.groupSitImovel.TabStop = false;
            // 
            // radioImovInativo
            // 
            this.radioImovInativo.AutoSize = true;
            this.radioImovInativo.Location = new System.Drawing.Point(93, 11);
            this.radioImovInativo.Name = "radioImovInativo";
            this.radioImovInativo.Size = new System.Drawing.Size(67, 15);
            this.radioImovInativo.TabIndex = 13;
            this.radioImovInativo.Text = "INATIVO";
            this.radioImovInativo.UseVisualStyleBackColor = true;
            // 
            // radioImovAtivo
            // 
            this.radioImovAtivo.AutoSize = true;
            this.radioImovAtivo.Checked = true;
            this.radioImovAtivo.Location = new System.Drawing.Point(16, 11);
            this.radioImovAtivo.Name = "radioImovAtivo";
            this.radioImovAtivo.Size = new System.Drawing.Size(55, 15);
            this.radioImovAtivo.TabIndex = 12;
            this.radioImovAtivo.TabStop = true;
            this.radioImovAtivo.Text = "ATIVO";
            this.radioImovAtivo.UseVisualStyleBackColor = true;
            this.radioImovAtivo.CheckedChanged += new System.EventHandler(this.RadioImovAtivo_CheckedChanged);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel7.Location = new System.Drawing.Point(262, 263);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(110, 15);
            this.metroLabel7.TabIndex = 900;
            this.metroLabel7.Text = "Situação do Imóvel *";
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel9.Location = new System.Drawing.Point(268, 315);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(117, 15);
            this.metroLabel9.TabIndex = 2000;
            this.metroLabel9.Text = "Finalidade do imóvel *";
            // 
            // groupFinalImovel
            // 
            this.groupFinalImovel.Controls.Add(this.checkVenda);
            this.groupFinalImovel.Controls.Add(this.checkLocacao);
            this.groupFinalImovel.Location = new System.Drawing.Point(228, 325);
            this.groupFinalImovel.Name = "groupFinalImovel";
            this.groupFinalImovel.Size = new System.Drawing.Size(174, 32);
            this.groupFinalImovel.TabIndex = 15;
            this.groupFinalImovel.TabStop = false;
            // 
            // checkVenda
            // 
            this.checkVenda.AutoSize = true;
            this.checkVenda.Location = new System.Drawing.Point(107, 10);
            this.checkVenda.Name = "checkVenda";
            this.checkVenda.Size = new System.Drawing.Size(61, 15);
            this.checkVenda.TabIndex = 1;
            this.checkVenda.Text = "VENDA";
            this.checkVenda.UseVisualStyleBackColor = true;
            // 
            // checkLocacao
            // 
            this.checkLocacao.AutoSize = true;
            this.checkLocacao.Location = new System.Drawing.Point(7, 10);
            this.checkLocacao.Name = "checkLocacao";
            this.checkLocacao.Size = new System.Drawing.Size(79, 15);
            this.checkLocacao.TabIndex = 0;
            this.checkLocacao.Text = "LOCAÇÃO";
            this.checkLocacao.UseVisualStyleBackColor = true;
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel10.Location = new System.Drawing.Point(81, 315);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(89, 15);
            this.metroLabel10.TabIndex = 1000;
            this.metroLabel10.Text = "Tipo do imóvel *";
            // 
            // groupTipoImovel
            // 
            this.groupTipoImovel.Controls.Add(this.radioTipoCom);
            this.groupTipoImovel.Controls.Add(this.radioTipoRes);
            this.groupTipoImovel.Location = new System.Drawing.Point(29, 325);
            this.groupTipoImovel.Name = "groupTipoImovel";
            this.groupTipoImovel.Size = new System.Drawing.Size(193, 32);
            this.groupTipoImovel.TabIndex = 17;
            this.groupTipoImovel.TabStop = false;
            // 
            // radioTipoCom
            // 
            this.radioTipoCom.AutoSize = true;
            this.radioTipoCom.Location = new System.Drawing.Point(102, 11);
            this.radioTipoCom.Name = "radioTipoCom";
            this.radioTipoCom.Size = new System.Drawing.Size(89, 15);
            this.radioTipoCom.TabIndex = 15;
            this.radioTipoCom.TabStop = true;
            this.radioTipoCom.Text = "COMERCIAL";
            this.radioTipoCom.UseVisualStyleBackColor = true;
            // 
            // radioTipoRes
            // 
            this.radioTipoRes.AutoSize = true;
            this.radioTipoRes.Location = new System.Drawing.Point(6, 11);
            this.radioTipoRes.Name = "radioTipoRes";
            this.radioTipoRes.Size = new System.Drawing.Size(93, 15);
            this.radioTipoRes.TabIndex = 14;
            this.radioTipoRes.TabStop = true;
            this.radioTipoRes.Text = "RESIDENCIAL";
            this.radioTipoRes.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.excluiProp);
            this.groupBox5.Controls.Add(this.labelCod);
            this.groupBox5.Controls.Add(this.boxCodProp);
            this.groupBox5.Controls.Add(this.nomePropBox);
            this.groupBox5.Controls.Add(this.boxCidade);
            this.groupBox5.Controls.Add(this.metroLabel3);
            this.groupBox5.Controls.Add(this.boxNumero);
            this.groupBox5.Controls.Add(this.metroLabel2);
            this.groupBox5.Controls.Add(this.boxBairro);
            this.groupBox5.Controls.Add(this.metroLabel4);
            this.groupBox5.Controls.Add(this.boxEstado);
            this.groupBox5.Controls.Add(this.metroLabel5);
            this.groupBox5.Controls.Add(this.metroLabel6);
            this.groupBox5.Controls.Add(this.boxComplemento);
            this.groupBox5.ForeColor = System.Drawing.Color.Gray;
            this.groupBox5.Location = new System.Drawing.Point(16, 146);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(397, 268);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            // 
            // excluiProp
            // 
            this.excluiProp.AutoSize = true;
            this.excluiProp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.excluiProp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excluiProp.ForeColor = System.Drawing.SystemColors.Desktop;
            this.excluiProp.Location = new System.Drawing.Point(367, 237);
            this.excluiProp.Name = "excluiProp";
            this.excluiProp.Size = new System.Drawing.Size(25, 24);
            this.excluiProp.TabIndex = 7000;
            this.excluiProp.Text = "X";
            this.excluiProp.Visible = false;
            this.excluiProp.Click += new System.EventHandler(this.ExcluiProp_Click);
            // 
            // labelCod
            // 
            this.labelCod.AutoSize = true;
            this.labelCod.FontSize = MetroFramework.MetroLabelSize.Small;
            this.labelCod.Location = new System.Drawing.Point(15, 219);
            this.labelCod.Name = "labelCod";
            this.labelCod.Size = new System.Drawing.Size(52, 15);
            this.labelCod.TabIndex = 3000;
            this.labelCod.Text = "Código *";
            this.labelCod.Visible = false;
            // 
            // boxCodProp
            // 
            this.boxCodProp.CustomBackground = true;
            this.boxCodProp.CustomForeColor = true;
            this.boxCodProp.ForeColor = System.Drawing.Color.DarkGray;
            this.boxCodProp.Location = new System.Drawing.Point(13, 237);
            this.boxCodProp.Name = "boxCodProp";
            this.boxCodProp.ReadOnly = true;
            this.boxCodProp.Size = new System.Drawing.Size(54, 25);
            this.boxCodProp.TabIndex = 5000;
            this.boxCodProp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.boxCodProp.Visible = false;
            this.boxCodProp.Click += new System.EventHandler(this.BoxCodProp_Click);
            // 
            // nomePropBox
            // 
            this.nomePropBox.CustomBackground = true;
            this.nomePropBox.CustomForeColor = true;
            this.nomePropBox.ForeColor = System.Drawing.Color.DarkGray;
            this.nomePropBox.Location = new System.Drawing.Point(72, 237);
            this.nomePropBox.Name = "nomePropBox";
            this.nomePropBox.ReadOnly = true;
            this.nomePropBox.Size = new System.Drawing.Size(290, 25);
            this.nomePropBox.TabIndex = 6000;
            this.nomePropBox.Text = "Clique para adicionar o proprietário";
            this.nomePropBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nomePropBox.Visible = false;
            this.nomePropBox.Click += new System.EventHandler(this.NomePropBox_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.metroLabel15);
            this.groupBox2.Controls.Add(this.metroLabel12);
            this.groupBox2.Controls.Add(this.groupSitChave);
            this.groupBox2.Controls.Add(this.boxOutraLocalizacao);
            this.groupBox2.Controls.Add(this.metroLabel11);
            this.groupBox2.Controls.Add(this.comboLocalizacao);
            this.groupBox2.Controls.Add(this.metroLabel8);
            this.groupBox2.Controls.Add(this.codImovel);
            this.groupBox2.ForeColor = System.Drawing.Color.Gray;
            this.groupBox2.Location = new System.Drawing.Point(16, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(397, 116);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.GroupBox2_Enter);
            // 
            // metroLabel15
            // 
            this.metroLabel15.AutoSize = true;
            this.metroLabel15.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel15.Location = new System.Drawing.Point(197, 8);
            this.metroLabel15.Name = "metroLabel15";
            this.metroLabel15.Size = new System.Drawing.Size(101, 15);
            this.metroLabel15.TabIndex = 300;
            this.metroLabel15.Text = "Situação da chave*";
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel12.Location = new System.Drawing.Point(250, 64);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(45, 15);
            this.metroLabel12.TabIndex = 500;
            this.metroLabel12.Text = "Outro *";
            // 
            // groupSitChave
            // 
            this.groupSitChave.Controls.Add(this.radioChaveIndisponivel);
            this.groupSitChave.Controls.Add(this.radioChaveDisponivel);
            this.groupSitChave.Location = new System.Drawing.Point(111, 17);
            this.groupSitChave.Name = "groupSitChave";
            this.groupSitChave.Size = new System.Drawing.Size(273, 33);
            this.groupSitChave.TabIndex = 19;
            this.groupSitChave.TabStop = false;
            // 
            // radioChaveIndisponivel
            // 
            this.radioChaveIndisponivel.AutoSize = true;
            this.radioChaveIndisponivel.Location = new System.Drawing.Point(149, 12);
            this.radioChaveIndisponivel.Name = "radioChaveIndisponivel";
            this.radioChaveIndisponivel.Size = new System.Drawing.Size(99, 15);
            this.radioChaveIndisponivel.TabIndex = 3;
            this.radioChaveIndisponivel.Text = "INDISPONIVEL";
            this.radioChaveIndisponivel.UseVisualStyleBackColor = true;
            this.radioChaveIndisponivel.CheckedChanged += new System.EventHandler(this.RadioChaveIndisponivel_CheckedChanged);
            // 
            // radioChaveDisponivel
            // 
            this.radioChaveDisponivel.AutoSize = true;
            this.radioChaveDisponivel.Checked = true;
            this.radioChaveDisponivel.Location = new System.Drawing.Point(25, 12);
            this.radioChaveDisponivel.Name = "radioChaveDisponivel";
            this.radioChaveDisponivel.Size = new System.Drawing.Size(87, 15);
            this.radioChaveDisponivel.TabIndex = 2;
            this.radioChaveDisponivel.TabStop = true;
            this.radioChaveDisponivel.Text = "DISPONIVEL";
            this.radioChaveDisponivel.UseVisualStyleBackColor = true;
            this.radioChaveDisponivel.CheckedChanged += new System.EventHandler(this.RadioChaveDisponivel_CheckedChanged);
            // 
            // boxOutraLocalizacao
            // 
            this.boxOutraLocalizacao.CustomBackground = true;
            this.boxOutraLocalizacao.CustomForeColor = true;
            this.boxOutraLocalizacao.Enabled = false;
            this.boxOutraLocalizacao.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.boxOutraLocalizacao.Location = new System.Drawing.Point(162, 79);
            this.boxOutraLocalizacao.MaxLength = 50;
            this.boxOutraLocalizacao.Name = "boxOutraLocalizacao";
            this.boxOutraLocalizacao.Size = new System.Drawing.Size(220, 25);
            this.boxOutraLocalizacao.Style = MetroFramework.MetroColorStyle.Silver;
            this.boxOutraLocalizacao.TabIndex = 4;
            this.boxOutraLocalizacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.boxOutraLocalizacao.UseStyleColors = true;
            this.boxOutraLocalizacao.Click += new System.EventHandler(this.BoxOutraLocalizacao_Click);
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel11.Location = new System.Drawing.Point(24, 61);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(119, 15);
            this.metroLabel11.TabIndex = 4000;
            this.metroLabel11.Text = "Localização da chave *";
            // 
            // comboLocalizacao
            // 
            this.comboLocalizacao.FormattingEnabled = true;
            this.comboLocalizacao.ItemHeight = 23;
            this.comboLocalizacao.Items.AddRange(new object[] {
            "IMOBILIARIA",
            "PORTARIA",
            "Outro"});
            this.comboLocalizacao.Location = new System.Drawing.Point(13, 76);
            this.comboLocalizacao.Name = "comboLocalizacao";
            this.comboLocalizacao.Size = new System.Drawing.Size(140, 29);
            this.comboLocalizacao.TabIndex = 3;
            this.comboLocalizacao.SelectedIndexChanged += new System.EventHandler(this.ComboLocalizacao_SelectedIndexChanged);
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel8.Location = new System.Drawing.Point(17, 8);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(75, 15);
            this.metroLabel8.TabIndex = 1000;
            this.metroLabel8.Text = "Cód. Imóvel *";
            this.metroLabel8.Click += new System.EventHandler(this.MetroLabel8_Click);
            // 
            // codImovel
            // 
            this.codImovel.CustomBackground = true;
            this.codImovel.CustomForeColor = true;
            this.codImovel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.codImovel.Location = new System.Drawing.Point(13, 23);
            this.codImovel.MaxLength = 25;
            this.codImovel.Name = "codImovel";
            this.codImovel.Size = new System.Drawing.Size(79, 25);
            this.codImovel.TabIndex = 1;
            this.codImovel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.codImovel.UseStyleColors = true;
            this.codImovel.Click += new System.EventHandler(this.CodImovel_Click);
            this.codImovel.Leave += new System.EventHandler(this.CodImovel_Leave);
            // 
            // labelProp
            // 
            this.labelProp.AutoSize = true;
            this.labelProp.FontSize = MetroFramework.MetroLabelSize.Small;
            this.labelProp.Location = new System.Drawing.Point(192, 364);
            this.labelProp.Name = "labelProp";
            this.labelProp.Size = new System.Drawing.Size(75, 15);
            this.labelProp.TabIndex = 4000;
            this.labelProp.Text = "Proprietário *";
            this.labelProp.Visible = false;
            // 
            // metroLabel14
            // 
            this.metroLabel14.AutoSize = true;
            this.metroLabel14.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel14.Location = new System.Drawing.Point(137, 2);
            this.metroLabel14.Name = "metroLabel14";
            this.metroLabel14.Size = new System.Drawing.Size(155, 25);
            this.metroLabel14.TabIndex = 22;
            this.metroLabel14.Text = "Cadastro de Chave";
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnCadastrar.FlatAppearance.BorderSize = 0;
            this.btnCadastrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(107)))));
            this.btnCadastrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(86)))), ((int)(((byte)(122)))));
            this.btnCadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastrar.ForeColor = System.Drawing.Color.White;
            this.btnCadastrar.Location = new System.Drawing.Point(338, 487);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(75, 23);
            this.btnCadastrar.TabIndex = 21;
            this.btnCadastrar.Text = "Confirmar";
            this.btnCadastrar.UseVisualStyleBackColor = false;
            this.btnCadastrar.Click += new System.EventHandler(this.BtnCadastrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(107)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(86)))), ((int)(((byte)(122)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnCancelar.Location = new System.Drawing.Point(238, 486);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 24;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            this.btnCancelar.MouseEnter += new System.EventHandler(this.BtnCancelar_MouseEnter);
            this.btnCancelar.MouseLeave += new System.EventHandler(this.BtnCancelar_MouseLeave);
            // 
            // painelProp
            // 
            this.painelProp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.painelProp.Controls.Add(this.btnNovoProp);
            this.painelProp.Controls.Add(this.btnCancelarProp);
            this.painelProp.Controls.Add(this.btnConfirmarProp);
            this.painelProp.Controls.Add(this.gridProprietarios);
            this.painelProp.Controls.Add(this.boxProcurarProp);
            this.painelProp.Location = new System.Drawing.Point(23, 24);
            this.painelProp.Name = "painelProp";
            this.painelProp.Size = new System.Drawing.Size(374, 225);
            this.painelProp.TabIndex = 25;
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
            this.btnNovoProp.Click += new System.EventHandler(this.btnNovoProp_Click);
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
            this.btnCancelarProp.Click += new System.EventHandler(this.BtnCancelarProp_Click);
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
            this.btnConfirmarProp.Click += new System.EventHandler(this.BtnConfirmarProp_Click);
            // 
            // gridProprietarios
            // 
            this.gridProprietarios.AllowUserToAddRows = false;
            this.gridProprietarios.AllowUserToDeleteRows = false;
            this.gridProprietarios.AllowUserToResizeRows = false;
            this.gridProprietarios.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.gridProprietarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridProprietarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProprietarios.Location = new System.Drawing.Point(29, 58);
            this.gridProprietarios.MultiSelect = false;
            this.gridProprietarios.Name = "gridProprietarios";
            this.gridProprietarios.ReadOnly = true;
            this.gridProprietarios.RowHeadersVisible = false;
            this.gridProprietarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridProprietarios.Size = new System.Drawing.Size(317, 125);
            this.gridProprietarios.TabIndex = 1;
            // 
            // boxProcurarProp
            // 
            this.boxProcurarProp.Location = new System.Drawing.Point(29, 23);
            this.boxProcurarProp.Name = "boxProcurarProp";
            this.boxProcurarProp.Size = new System.Drawing.Size(317, 20);
            this.boxProcurarProp.TabIndex = 0;
            this.boxProcurarProp.TextChanged += new System.EventHandler(this.BoxProcurarProp_TextChanged);
            // 
            // btnAdicionarProp
            // 
            this.btnAdicionarProp.AutoSize = true;
            this.btnAdicionarProp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdicionarProp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarProp.Location = new System.Drawing.Point(154, 379);
            this.btnAdicionarProp.Name = "btnAdicionarProp";
            this.btnAdicionarProp.Size = new System.Drawing.Size(125, 15);
            this.btnAdicionarProp.TabIndex = 28;
            this.btnAdicionarProp.Text = "Adicionar Proprietário";
            this.btnAdicionarProp.Click += new System.EventHandler(this.BtnAdicionarProp_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.boxQtdChaves);
            this.groupBox1.Controls.Add(this.metroLabel16);
            this.groupBox1.Controls.Add(this.metroLabel17);
            this.groupBox1.Controls.Add(this.boxCategImov);
            this.groupBox1.Controls.Add(this.metroLabel13);
            this.groupBox1.Controls.Add(this.boxCond);
            this.groupBox1.ForeColor = System.Drawing.Color.Silver;
            this.groupBox1.Location = new System.Drawing.Point(16, 420);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 62);
            this.groupBox1.TabIndex = 4000;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados para a plaquina de chaves";
            // 
            // boxQtdChaves
            // 
            this.boxQtdChaves.Location = new System.Drawing.Point(322, 33);
            this.boxQtdChaves.Name = "boxQtdChaves";
            this.boxQtdChaves.Size = new System.Drawing.Size(68, 20);
            this.boxQtdChaves.TabIndex = 20;
            this.boxQtdChaves.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // metroLabel16
            // 
            this.metroLabel16.AutoSize = true;
            this.metroLabel16.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel16.Location = new System.Drawing.Point(176, 15);
            this.metroLabel16.Name = "metroLabel16";
            this.metroLabel16.Size = new System.Drawing.Size(109, 15);
            this.metroLabel16.TabIndex = 9000;
            this.metroLabel16.Text = "Categoria do Imóvel";
            // 
            // metroLabel17
            // 
            this.metroLabel17.AutoSize = true;
            this.metroLabel17.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel17.Location = new System.Drawing.Point(322, 15);
            this.metroLabel17.Name = "metroLabel17";
            this.metroLabel17.Size = new System.Drawing.Size(68, 15);
            this.metroLabel17.TabIndex = 10000;
            this.metroLabel17.Text = "Qtd. Chaves";
            // 
            // boxCategImov
            // 
            this.boxCategImov.CustomBackground = true;
            this.boxCategImov.CustomForeColor = true;
            this.boxCategImov.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.boxCategImov.Location = new System.Drawing.Point(160, 30);
            this.boxCategImov.MaxLength = 30;
            this.boxCategImov.Name = "boxCategImov";
            this.boxCategImov.Size = new System.Drawing.Size(142, 25);
            this.boxCategImov.Style = MetroFramework.MetroColorStyle.Silver;
            this.boxCategImov.TabIndex = 19;
            this.boxCategImov.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.boxCategImov.UseStyleColors = true;
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel13.Location = new System.Drawing.Point(23, 15);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(106, 15);
            this.metroLabel13.TabIndex = 8000;
            this.metroLabel13.Text = "Condomínio/Edifício";
            // 
            // boxCond
            // 
            this.boxCond.CustomBackground = true;
            this.boxCond.CustomForeColor = true;
            this.boxCond.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.boxCond.Location = new System.Drawing.Point(7, 30);
            this.boxCond.MaxLength = 30;
            this.boxCond.Name = "boxCond";
            this.boxCond.Size = new System.Drawing.Size(138, 25);
            this.boxCond.Style = MetroFramework.MetroColorStyle.Silver;
            this.boxCond.TabIndex = 18;
            this.boxCond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.boxCond.UseStyleColors = true;
            // 
            // btnCadastrarAviso
            // 
            this.btnCadastrarAviso.AutoSize = true;
            this.btnCadastrarAviso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCadastrarAviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrarAviso.Location = new System.Drawing.Point(131, 489);
            this.btnCadastrarAviso.Name = "btnCadastrarAviso";
            this.btnCadastrarAviso.Size = new System.Drawing.Size(91, 15);
            this.btnCadastrarAviso.TabIndex = 4001;
            this.btnCadastrarAviso.Text = "Cadastrar aviso";
            this.btnCadastrarAviso.Click += new System.EventHandler(this.BtnCadastrarAviso_Click);
            // 
            // panelAviso
            // 
            this.panelAviso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAviso.Controls.Add(this.groupBox3);
            this.panelAviso.Controls.Add(this.metroLabel18);
            this.panelAviso.Controls.Add(this.button3);
            this.panelAviso.Controls.Add(this.boxAviso);
            this.panelAviso.Location = new System.Drawing.Point(24, 253);
            this.panelAviso.Name = "panelAviso";
            this.panelAviso.Size = new System.Drawing.Size(374, 233);
            this.panelAviso.TabIndex = 28;
            this.panelAviso.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(15, 151);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(346, 45);
            this.groupBox3.TabIndex = 4003;
            this.groupBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(14, 14);
            this.label3.MaximumSize = new System.Drawing.Size(330, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(317, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "Este aviso será exibido toda vez que for registrado um empréstimo desta chave.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroLabel18
            // 
            this.metroLabel18.AutoSize = true;
            this.metroLabel18.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel18.Location = new System.Drawing.Point(162, 3);
            this.metroLabel18.Name = "metroLabel18";
            this.metroLabel18.Size = new System.Drawing.Size(51, 25);
            this.metroLabel18.TabIndex = 4002;
            this.metroLabel18.Text = "Aviso";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(107)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(86)))), ((int)(((byte)(122)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(285, 203);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 25;
            this.button3.Text = "Salvar";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // boxAviso
            // 
            this.boxAviso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.boxAviso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxAviso.Location = new System.Drawing.Point(14, 30);
            this.boxAviso.Multiline = true;
            this.boxAviso.Name = "boxAviso";
            this.boxAviso.Size = new System.Drawing.Size(346, 121);
            this.boxAviso.TabIndex = 0;
            // 
            // cadastroChave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(429, 516);
            this.Controls.Add(this.panelAviso);
            this.Controls.Add(this.btnCadastrarAviso);
            this.Controls.Add(this.painelProp);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAdicionarProp);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.metroLabel14);
            this.Controls.Add(this.labelProp);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.groupTipoImovel);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.groupFinalImovel);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.groupSitImovel);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.boxLogradouro);
            this.Controls.Add(this.groupBox5);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "cadastroChave";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.None;
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Text = "cadastroChave";
            this.Load += new System.EventHandler(this.CadastroChave_Load);
            this.groupSitImovel.ResumeLayout(false);
            this.groupSitImovel.PerformLayout();
            this.groupFinalImovel.ResumeLayout(false);
            this.groupFinalImovel.PerformLayout();
            this.groupTipoImovel.ResumeLayout(false);
            this.groupTipoImovel.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupSitChave.ResumeLayout(false);
            this.groupSitChave.PerformLayout();
            this.painelProp.ResumeLayout(false);
            this.painelProp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProprietarios)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxQtdChaves)).EndInit();
            this.panelAviso.ResumeLayout(false);
            this.panelAviso.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox boxLogradouro;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox boxNumero;
        private MetroFramework.Controls.MetroTextBox boxCidade;
        private MetroFramework.Controls.MetroTextBox boxBairro;
        private MetroFramework.Controls.MetroTextBox boxEstado;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox boxComplemento;
        private System.Windows.Forms.GroupBox groupSitImovel;
        private MetroFramework.Controls.MetroRadioButton radioImovInativo;
        private MetroFramework.Controls.MetroRadioButton radioImovAtivo;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private System.Windows.Forms.GroupBox groupFinalImovel;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private System.Windows.Forms.GroupBox groupTipoImovel;
        private MetroFramework.Controls.MetroRadioButton radioTipoCom;
        private MetroFramework.Controls.MetroRadioButton radioTipoRes;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTextBox codImovel;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroTextBox boxOutraLocalizacao;
        private MetroFramework.Controls.MetroComboBox comboLocalizacao;
        private MetroFramework.Controls.MetroLabel labelProp;
        private MetroFramework.Controls.MetroLabel metroLabel14;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnCancelar;
        private MetroFramework.Controls.MetroLabel metroLabel15;
        private System.Windows.Forms.GroupBox groupSitChave;
        private MetroFramework.Controls.MetroRadioButton radioChaveIndisponivel;
        private MetroFramework.Controls.MetroRadioButton radioChaveDisponivel;
        private System.Windows.Forms.Panel painelProp;
        private System.Windows.Forms.TextBox boxProcurarProp;
        private System.Windows.Forms.DataGridView gridProprietarios;
        private MetroFramework.Controls.MetroTextBox nomePropBox;
        private MetroFramework.Controls.MetroTextBox boxCodProp;
        private MetroFramework.Controls.MetroLabel labelCod;
        private System.Windows.Forms.Button btnCancelarProp;
        private System.Windows.Forms.Button btnConfirmarProp;
        private System.Windows.Forms.Label excluiProp;
        private System.Windows.Forms.Label btnAdicionarProp;
        private System.Windows.Forms.Button btnNovoProp;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroLabel metroLabel16;
        private MetroFramework.Controls.MetroLabel metroLabel17;
        private MetroFramework.Controls.MetroTextBox boxCategImov;
        private MetroFramework.Controls.MetroLabel metroLabel13;
        private MetroFramework.Controls.MetroTextBox boxCond;
        private System.Windows.Forms.NumericUpDown boxQtdChaves;
        private MetroFramework.Controls.MetroCheckBox checkVenda;
        private MetroFramework.Controls.MetroCheckBox checkLocacao;
        private System.Windows.Forms.Label btnCadastrarAviso;
        private System.Windows.Forms.Panel panelAviso;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox boxAviso;
        private MetroFramework.Controls.MetroLabel metroLabel18;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
    }
}