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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.radioCliente = new MetroFramework.Controls.MetroRadioButton();
            this.radioProprietario = new MetroFramework.Controls.MetroRadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.metroTextBox2 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.previsaoLabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.datePrevisao = new System.Windows.Forms.DateTimePicker();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.codigoChaveBox = new MetroFramework.Controls.MetroTextBox();
            this.groupDadosCliente = new System.Windows.Forms.GroupBox();
            this.comboClientes = new MetroFramework.Controls.MetroComboBox();
            this.addCliente = new System.Windows.Forms.Label();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.boxDescDoc = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.comboDocs = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.boxCpf = new MetroFramework.Controls.MetroTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupDadosCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.metroLabel1);
            this.groupBox1.Controls.Add(this.radioCliente);
            this.groupBox1.Controls.Add(this.radioProprietario);
            this.groupBox1.Location = new System.Drawing.Point(9, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 42);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
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
            this.radioCliente.Location = new System.Drawing.Point(113, 10);
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
            this.radioProprietario.Location = new System.Drawing.Point(199, 13);
            this.radioProprietario.Name = "radioProprietario";
            this.radioProprietario.Size = new System.Drawing.Size(101, 20);
            this.radioProprietario.TabIndex = 0;
            this.radioProprietario.TabStop = true;
            this.radioProprietario.Text = "Proprietario";
            this.radioProprietario.UseVisualStyleBackColor = true;
            this.radioProprietario.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDown2);
            this.groupBox2.Controls.Add(this.metroLabel11);
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.metroTextBox2);
            this.groupBox2.Controls.Add(this.metroLabel6);
            this.groupBox2.Controls.Add(this.previsaoLabel);
            this.groupBox2.Controls.Add(this.metroLabel4);
            this.groupBox2.Controls.Add(this.metroLabel3);
            this.groupBox2.Controls.Add(this.datePrevisao);
            this.groupBox2.Controls.Add(this.metroLabel2);
            this.groupBox2.Controls.Add(this.codigoChaveBox);
            this.groupBox2.Location = new System.Drawing.Point(9, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(410, 122);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown2.Location = new System.Drawing.Point(335, 29);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(60, 20);
            this.numericUpDown2.TabIndex = 13;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // numericUpDown1
            // 
            this.numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown1.Location = new System.Drawing.Point(262, 29);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(60, 20);
            this.numericUpDown1.TabIndex = 11;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // metroTextBox2
            // 
            this.metroTextBox2.CustomBackground = true;
            this.metroTextBox2.Location = new System.Drawing.Point(15, 74);
            this.metroTextBox2.Multiline = true;
            this.metroTextBox2.Name = "metroTextBox2";
            this.metroTextBox2.Size = new System.Drawing.Size(380, 33);
            this.metroTextBox2.TabIndex = 9;
            this.metroTextBox2.UseStyleColors = true;
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
            this.codigoChaveBox.Name = "codigoChaveBox";
            this.codigoChaveBox.ReadOnly = true;
            this.codigoChaveBox.Size = new System.Drawing.Size(64, 26);
            this.codigoChaveBox.TabIndex = 2;
            this.codigoChaveBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.codigoChaveBox.UseStyleColors = true;
            // 
            // groupDadosCliente
            // 
            this.groupDadosCliente.Controls.Add(this.comboClientes);
            this.groupDadosCliente.Controls.Add(this.addCliente);
            this.groupDadosCliente.Controls.Add(this.metroLabel10);
            this.groupDadosCliente.Controls.Add(this.boxDescDoc);
            this.groupDadosCliente.Controls.Add(this.metroLabel9);
            this.groupDadosCliente.Controls.Add(this.comboDocs);
            this.groupDadosCliente.Controls.Add(this.metroLabel7);
            this.groupDadosCliente.Controls.Add(this.metroLabel8);
            this.groupDadosCliente.Controls.Add(this.boxCpf);
            this.groupDadosCliente.Location = new System.Drawing.Point(9, 209);
            this.groupDadosCliente.Name = "groupDadosCliente";
            this.groupDadosCliente.Size = new System.Drawing.Size(410, 117);
            this.groupDadosCliente.TabIndex = 10;
            this.groupDadosCliente.TabStop = false;
            // 
            // comboClientes
            // 
            this.comboClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboClientes.FontSize = MetroFramework.MetroLinkSize.Small;
            this.comboClientes.FormattingEnabled = true;
            this.comboClientes.ItemHeight = 19;
            this.comboClientes.Location = new System.Drawing.Point(131, 26);
            this.comboClientes.Name = "comboClientes";
            this.comboClientes.Size = new System.Drawing.Size(225, 25);
            this.comboClientes.TabIndex = 10;
            // 
            // addCliente
            // 
            this.addCliente.AutoSize = true;
            this.addCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addCliente.Font = new System.Drawing.Font("Arial Rounded MT Bold", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCliente.ForeColor = System.Drawing.Color.SteelBlue;
            this.addCliente.Location = new System.Drawing.Point(354, 18);
            this.addCliente.Name = "addCliente";
            this.addCliente.Size = new System.Drawing.Size(37, 40);
            this.addCliente.TabIndex = 11;
            this.addCliente.Text = "+";
            this.addCliente.Click += new System.EventHandler(this.AddCliente_Click);
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
            // boxDescDoc
            // 
            this.boxDescDoc.CustomBackground = true;
            this.boxDescDoc.CustomForeColor = true;
            this.boxDescDoc.ForeColor = System.Drawing.Color.Gray;
            this.boxDescDoc.Location = new System.Drawing.Point(136, 75);
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
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel7.Location = new System.Drawing.Point(197, 10);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(92, 15);
            this.metroLabel7.TabIndex = 11;
            this.metroLabel7.Text = "Nome do Cliente";
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel8.Location = new System.Drawing.Point(42, 10);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(61, 15);
            this.metroLabel8.TabIndex = 10;
            this.metroLabel8.Text = "CPF cliente";
            // 
            // boxCpf
            // 
            this.boxCpf.CustomBackground = true;
            this.boxCpf.CustomForeColor = true;
            this.boxCpf.ForeColor = System.Drawing.Color.Gray;
            this.boxCpf.Location = new System.Drawing.Point(30, 26);
            this.boxCpf.Name = "boxCpf";
            this.boxCpf.Size = new System.Drawing.Size(85, 26);
            this.boxCpf.TabIndex = 10;
            this.boxCpf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.boxCpf.UseStyleColors = true;
            this.boxCpf.Leave += new System.EventHandler(this.BoxCpf_Leave);
            // 
            // CadastrarEmprestimo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(429, 449);
            this.Controls.Add(this.groupDadosCliente);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DisplayHeader = false;
            this.Name = "CadastrarEmprestimo";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.None;
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Text = "CadastrarEmprestimo";
            this.Load += new System.EventHandler(this.CadastrarEmprestimo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupDadosCliente.ResumeLayout(false);
            this.groupDadosCliente.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroRadioButton radioCliente;
        private MetroFramework.Controls.MetroRadioButton radioProprietario;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroLabel previsaoLabel;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.DateTimePicker datePrevisao;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox codigoChaveBox;
        private MetroFramework.Controls.MetroTextBox metroTextBox2;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private System.Windows.Forms.GroupBox groupDadosCliente;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTextBox boxCpf;
        private MetroFramework.Controls.MetroComboBox comboClientes;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroTextBox boxDescDoc;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroComboBox comboDocs;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private System.Windows.Forms.Label addCliente;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private MetroFramework.Controls.MetroLabel metroLabel11;
    }
}