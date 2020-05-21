namespace situacaoChavesGolden
{
    partial class ImprimirEtiquetas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImprimirEtiquetas));
            this.gridFrom = new System.Windows.Forms.DataGridView();
            this.gridTo = new System.Windows.Forms.DataGridView();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.descImovel = new System.Windows.Forms.TextBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnSelecTudo = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.imgTexto = new System.Windows.Forms.PictureBox();
            this.btnPassSelec = new System.Windows.Forms.PictureBox();
            this.imagem = new System.Windows.Forms.PictureBox();
            this.btnSelecTudoTo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tamFonte = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.descCod = new System.Windows.Forms.TextBox();
            this.descTipo = new System.Windows.Forms.TextBox();
            this.imgCod = new System.Windows.Forms.PictureBox();
            this.imgTipo = new System.Windows.Forms.PictureBox();
            this.contPlacas = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTexto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPassSelec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagem)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tamFonte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTipo)).BeginInit();
            this.SuspendLayout();
            // 
            // gridFrom
            // 
            this.gridFrom.AllowUserToAddRows = false;
            this.gridFrom.AllowUserToDeleteRows = false;
            this.gridFrom.AllowUserToResizeColumns = false;
            this.gridFrom.AllowUserToResizeRows = false;
            this.gridFrom.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(234)))), ((int)(((byte)(242)))));
            this.gridFrom.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridFrom.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridFrom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridFrom.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridFrom.GridColor = System.Drawing.Color.White;
            this.gridFrom.Location = new System.Drawing.Point(23, 92);
            this.gridFrom.Name = "gridFrom";
            this.gridFrom.ReadOnly = true;
            this.gridFrom.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridFrom.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridFrom.RowHeadersVisible = false;
            this.gridFrom.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridFrom.RowTemplate.ReadOnly = true;
            this.gridFrom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridFrom.Size = new System.Drawing.Size(262, 325);
            this.gridFrom.TabIndex = 46;
            // 
            // gridTo
            // 
            this.gridTo.AllowUserToAddRows = false;
            this.gridTo.AllowUserToDeleteRows = false;
            this.gridTo.AllowUserToResizeColumns = false;
            this.gridTo.AllowUserToResizeRows = false;
            this.gridTo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(234)))), ((int)(((byte)(242)))));
            this.gridTo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridTo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridTo.ColumnHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridTo.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridTo.GridColor = System.Drawing.Color.White;
            this.gridTo.Location = new System.Drawing.Point(329, 92);
            this.gridTo.Name = "gridTo";
            this.gridTo.ReadOnly = true;
            this.gridTo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTo.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridTo.RowHeadersVisible = false;
            this.gridTo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridTo.RowTemplate.ReadOnly = true;
            this.gridTo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTo.Size = new System.Drawing.Size(262, 325);
            this.gridTo.TabIndex = 47;
            this.gridTo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GridTo_CellFormatting);
            this.gridTo.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTo_CellValueChanged);
            this.gridTo.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.gridTo_RowsAdded);
            this.gridTo.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.gridTo_RowsRemoved);
            this.gridTo.SelectionChanged += new System.EventHandler(this.GridTo_SelectionChanged);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // descImovel
            // 
            this.descImovel.Enabled = false;
            this.descImovel.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.descImovel.Location = new System.Drawing.Point(625, 295);
            this.descImovel.Margin = new System.Windows.Forms.Padding(0);
            this.descImovel.MaxLength = 100;
            this.descImovel.Multiline = true;
            this.descImovel.Name = "descImovel";
            this.descImovel.Size = new System.Drawing.Size(129, 71);
            this.descImovel.TabIndex = 50;
            this.descImovel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.descImovel.TextChanged += new System.EventHandler(this.DescImovel_TextChanged);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(625, 239);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(134, 20);
            this.btnEditar.TabIndex = 52;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Enabled = false;
            this.btnSalvar.Location = new System.Drawing.Point(625, 397);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(129, 20);
            this.btnSalvar.TabIndex = 53;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // btnSelecTudo
            // 
            this.btnSelecTudo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnSelecTudo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecTudo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnSelecTudo.Location = new System.Drawing.Point(23, 423);
            this.btnSelecTudo.Name = "btnSelecTudo";
            this.btnSelecTudo.Size = new System.Drawing.Size(262, 23);
            this.btnSelecTudo.TabIndex = 54;
            this.btnSelecTudo.Text = "Selecionar Tudo";
            this.btnSelecTudo.UseVisualStyleBackColor = true;
            this.btnSelecTudo.Click += new System.EventHandler(this.BtnSelecTudo_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(107)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(86)))), ((int)(((byte)(122)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnCancelar.Location = new System.Drawing.Point(596, 476);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 58;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnImprimir.Enabled = false;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(107)))));
            this.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(86)))), ((int)(((byte)(122)))));
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(696, 477);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 57;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // imgTexto
            // 
            this.imgTexto.Location = new System.Drawing.Point(625, 129);
            this.imgTexto.Name = "imgTexto";
            this.imgTexto.Size = new System.Drawing.Size(134, 74);
            this.imgTexto.TabIndex = 51;
            this.imgTexto.TabStop = false;
            this.imgTexto.Click += new System.EventHandler(this.ImgTexto_Click);
            // 
            // btnPassSelec
            // 
            this.btnPassSelec.BackColor = System.Drawing.Color.White;
            this.btnPassSelec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPassSelec.Image = global::situacaoChavesGolden.Properties.Resources.PassTo;
            this.btnPassSelec.Location = new System.Drawing.Point(293, 239);
            this.btnPassSelec.Name = "btnPassSelec";
            this.btnPassSelec.Size = new System.Drawing.Size(30, 30);
            this.btnPassSelec.TabIndex = 49;
            this.btnPassSelec.TabStop = false;
            this.btnPassSelec.Click += new System.EventHandler(this.btnPassSelec_Click);
            // 
            // imagem
            // 
            this.imagem.Location = new System.Drawing.Point(771, 476);
            this.imagem.Name = "imagem";
            this.imagem.Size = new System.Drawing.Size(797, 1122);
            this.imagem.TabIndex = 48;
            this.imagem.TabStop = false;
            this.imagem.Visible = false;
            // 
            // btnSelecTudoTo
            // 
            this.btnSelecTudoTo.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnSelecTudoTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecTudoTo.ForeColor = System.Drawing.Color.Red;
            this.btnSelecTudoTo.Location = new System.Drawing.Point(329, 423);
            this.btnSelecTudoTo.Name = "btnSelecTudoTo";
            this.btnSelecTudoTo.Size = new System.Drawing.Size(201, 23);
            this.btnSelecTudoTo.TabIndex = 55;
            this.btnSelecTudoTo.Text = "Limpar";
            this.btnSelecTudoTo.UseVisualStyleBackColor = true;
            this.btnSelecTudoTo.Click += new System.EventHandler(this.BtnSelecTudoTo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tamFonte);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.descCod);
            this.groupBox1.Controls.Add(this.descTipo);
            this.groupBox1.Controls.Add(this.imgCod);
            this.groupBox1.Controls.Add(this.imgTipo);
            this.groupBox1.Controls.Add(this.contPlacas);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(756, 447);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // tamFonte
            // 
            this.tamFonte.Enabled = false;
            this.tamFonte.Location = new System.Drawing.Point(675, 57);
            this.tamFonte.Name = "tamFonte";
            this.tamFonte.Size = new System.Drawing.Size(70, 20);
            this.tamFonte.TabIndex = 65;
            this.tamFonte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tamFonte.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.tamFonte.ValueChanged += new System.EventHandler(this.TamFonte_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(629, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 64;
            this.label3.Text = "Fonte:";
            // 
            // descCod
            // 
            this.descCod.Enabled = false;
            this.descCod.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.descCod.Location = new System.Drawing.Point(611, 348);
            this.descCod.Margin = new System.Windows.Forms.Padding(0);
            this.descCod.MaxLength = 75;
            this.descCod.Multiline = true;
            this.descCod.Name = "descCod";
            this.descCod.Size = new System.Drawing.Size(129, 23);
            this.descCod.TabIndex = 62;
            this.descCod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.descCod.TextChanged += new System.EventHandler(this.DescCod_TextChanged);
            // 
            // descTipo
            // 
            this.descTipo.Enabled = false;
            this.descTipo.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.descTipo.Location = new System.Drawing.Point(611, 246);
            this.descTipo.Margin = new System.Windows.Forms.Padding(0);
            this.descTipo.MaxLength = 75;
            this.descTipo.Multiline = true;
            this.descTipo.Name = "descTipo";
            this.descTipo.Size = new System.Drawing.Size(129, 23);
            this.descTipo.TabIndex = 60;
            this.descTipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.descTipo.TextChanged += new System.EventHandler(this.DescTipo_TextChanged);
            this.descTipo.Leave += new System.EventHandler(this.DescTipo_Leave);
            // 
            // imgCod
            // 
            this.imgCod.Location = new System.Drawing.Point(611, 187);
            this.imgCod.Name = "imgCod";
            this.imgCod.Size = new System.Drawing.Size(134, 24);
            this.imgCod.TabIndex = 61;
            this.imgCod.TabStop = false;
            this.imgCod.Click += new System.EventHandler(this.PictureBox2_Click);
            // 
            // imgTipo
            // 
            this.imgTipo.Location = new System.Drawing.Point(611, 83);
            this.imgTipo.Name = "imgTipo";
            this.imgTipo.Size = new System.Drawing.Size(134, 24);
            this.imgTipo.TabIndex = 60;
            this.imgTipo.TabStop = false;
            // 
            // contPlacas
            // 
            this.contPlacas.AutoSize = true;
            this.contPlacas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contPlacas.Location = new System.Drawing.Point(538, 403);
            this.contPlacas.Name = "contPlacas";
            this.contPlacas.Size = new System.Drawing.Size(24, 15);
            this.contPlacas.TabIndex = 2;
            this.contPlacas.Text = "0/0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(385, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chaves selecionadas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(56, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chaves à serem selecionadas";
            // 
            // ImprimirEtiquetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 507);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnSelecTudoTo);
            this.Controls.Add(this.btnSelecTudo);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.imgTexto);
            this.Controls.Add(this.descImovel);
            this.Controls.Add(this.btnPassSelec);
            this.Controls.Add(this.imagem);
            this.Controls.Add(this.gridTo);
            this.Controls.Add(this.gridFrom);
            this.Controls.Add(this.groupBox1);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImprimirEtiquetas";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Text = "ImprimirEtiquetas";
            this.Load += new System.EventHandler(this.ImprimirEtiquetas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTexto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPassSelec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagem)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tamFonte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTipo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridFrom;
        private System.Windows.Forms.DataGridView gridTo;
        private System.Windows.Forms.PictureBox imagem;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PictureBox btnPassSelec;
        private System.Windows.Forms.TextBox descImovel;
        private System.Windows.Forms.PictureBox imgTexto;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnSelecTudo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnSelecTudoTo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label contPlacas;
        private System.Windows.Forms.TextBox descTipo;
        private System.Windows.Forms.PictureBox imgCod;
        private System.Windows.Forms.PictureBox imgTipo;
        private System.Windows.Forms.TextBox descCod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown tamFonte;
    }
}