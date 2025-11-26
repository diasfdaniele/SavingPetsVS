namespace SavingPets
{
    partial class FrmAnimal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnimal));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdAnimal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNomeAnimal = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbGato = new System.Windows.Forms.RadioButton();
            this.rbCachorro = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbFemea = new System.Windows.Forms.RadioButton();
            this.rbMacho = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbPoli5 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbAntirabica = new System.Windows.Forms.CheckBox();
            this.cbPoli4 = new System.Windows.Forms.CheckBox();
            this.cbPoli10 = new System.Windows.Forms.CheckBox();
            this.cbPoli3 = new System.Windows.Forms.CheckBox();
            this.cbPoli8 = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbNaoVermifugado = new System.Windows.Forms.RadioButton();
            this.rbVermifugado = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbNaoCastrado = new System.Windows.Forms.RadioButton();
            this.rbCastrado = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHistorico = new System.Windows.Forms.TextBox();
            this.btnCadAnimal = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.txtRaca = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(158, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadastro de animais";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(154, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID:";
            // 
            // txtIdAnimal
            // 
            this.txtIdAnimal.BackColor = System.Drawing.Color.Gainsboro;
            this.txtIdAnimal.Enabled = false;
            this.txtIdAnimal.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdAnimal.Location = new System.Drawing.Point(157, 74);
            this.txtIdAnimal.Name = "txtIdAnimal";
            this.txtIdAnimal.ReadOnly = true;
            this.txtIdAnimal.Size = new System.Drawing.Size(49, 23);
            this.txtIdAnimal.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(209, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nome:";
            // 
            // txtNomeAnimal
            // 
            this.txtNomeAnimal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNomeAnimal.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeAnimal.Location = new System.Drawing.Point(212, 75);
            this.txtNomeAnimal.Name = "txtNomeAnimal";
            this.txtNomeAnimal.Size = new System.Drawing.Size(245, 23);
            this.txtNomeAnimal.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbGato);
            this.groupBox1.Controls.Add(this.rbCachorro);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(157, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 51);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Espécie";
            // 
            // rbGato
            // 
            this.rbGato.AutoSize = true;
            this.rbGato.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbGato.Location = new System.Drawing.Point(173, 22);
            this.rbGato.Name = "rbGato";
            this.rbGato.Size = new System.Drawing.Size(60, 21);
            this.rbGato.TabIndex = 1;
            this.rbGato.Text = "Gato";
            this.rbGato.UseVisualStyleBackColor = true;
            // 
            // rbCachorro
            // 
            this.rbCachorro.AutoSize = true;
            this.rbCachorro.BackColor = System.Drawing.Color.Transparent;
            this.rbCachorro.Checked = true;
            this.rbCachorro.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCachorro.Location = new System.Drawing.Point(22, 22);
            this.rbCachorro.Name = "rbCachorro";
            this.rbCachorro.Size = new System.Drawing.Size(88, 21);
            this.rbCachorro.TabIndex = 0;
            this.rbCachorro.TabStop = true;
            this.rbCachorro.Text = "Cachorro";
            this.rbCachorro.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbFemea);
            this.groupBox2.Controls.Add(this.rbMacho);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(157, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 44);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sexo";
            // 
            // rbFemea
            // 
            this.rbFemea.AutoSize = true;
            this.rbFemea.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFemea.Location = new System.Drawing.Point(173, 17);
            this.rbFemea.Name = "rbFemea";
            this.rbFemea.Size = new System.Drawing.Size(70, 21);
            this.rbFemea.TabIndex = 1;
            this.rbFemea.Text = "Fêmea";
            this.rbFemea.UseVisualStyleBackColor = true;
            // 
            // rbMacho
            // 
            this.rbMacho.AutoSize = true;
            this.rbMacho.Checked = true;
            this.rbMacho.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMacho.Location = new System.Drawing.Point(22, 17);
            this.rbMacho.Name = "rbMacho";
            this.rbMacho.Size = new System.Drawing.Size(71, 21);
            this.rbMacho.TabIndex = 0;
            this.rbMacho.TabStop = true;
            this.rbMacho.Text = "Macho";
            this.rbMacho.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbPoli5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cbAntirabica);
            this.groupBox3.Controls.Add(this.cbPoli4);
            this.groupBox3.Controls.Add(this.cbPoli10);
            this.groupBox3.Controls.Add(this.cbPoli3);
            this.groupBox3.Controls.Add(this.cbPoli8);
            this.groupBox3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(157, 258);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(300, 136);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Vacinas";
            // 
            // cbPoli5
            // 
            this.cbPoli5.AutoSize = true;
            this.cbPoli5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPoli5.Location = new System.Drawing.Point(171, 112);
            this.cbPoli5.Name = "cbPoli5";
            this.cbPoli5.Size = new System.Drawing.Size(119, 21);
            this.cbPoli5.TabIndex = 10;
            this.cbPoli5.Text = "Polivalente V5";
            this.cbPoli5.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(60, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(183, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Obrigatória - Cães e Gatos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(196, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Gatos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cães";
            // 
            // cbAntirabica
            // 
            this.cbAntirabica.AutoSize = true;
            this.cbAntirabica.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAntirabica.Location = new System.Drawing.Point(107, 38);
            this.cbAntirabica.Name = "cbAntirabica";
            this.cbAntirabica.Size = new System.Drawing.Size(94, 21);
            this.cbAntirabica.TabIndex = 4;
            this.cbAntirabica.Text = "Antirábica";
            this.cbAntirabica.UseVisualStyleBackColor = true;
            // 
            // cbPoli4
            // 
            this.cbPoli4.AutoSize = true;
            this.cbPoli4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPoli4.Location = new System.Drawing.Point(171, 95);
            this.cbPoli4.Name = "cbPoli4";
            this.cbPoli4.Size = new System.Drawing.Size(119, 21);
            this.cbPoli4.TabIndex = 5;
            this.cbPoli4.Text = "Polivalente V4";
            this.cbPoli4.UseVisualStyleBackColor = true;
            // 
            // cbPoli10
            // 
            this.cbPoli10.AutoSize = true;
            this.cbPoli10.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPoli10.Location = new System.Drawing.Point(13, 108);
            this.cbPoli10.Name = "cbPoli10";
            this.cbPoli10.Size = new System.Drawing.Size(126, 21);
            this.cbPoli10.TabIndex = 3;
            this.cbPoli10.Text = "Polivalente V10";
            this.cbPoli10.UseVisualStyleBackColor = true;
            // 
            // cbPoli3
            // 
            this.cbPoli3.AutoSize = true;
            this.cbPoli3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPoli3.Location = new System.Drawing.Point(171, 79);
            this.cbPoli3.Name = "cbPoli3";
            this.cbPoli3.Size = new System.Drawing.Size(119, 21);
            this.cbPoli3.TabIndex = 2;
            this.cbPoli3.Text = "Polivalente V3";
            this.cbPoli3.UseVisualStyleBackColor = true;
            // 
            // cbPoli8
            // 
            this.cbPoli8.AutoSize = true;
            this.cbPoli8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPoli8.Location = new System.Drawing.Point(13, 84);
            this.cbPoli8.Name = "cbPoli8";
            this.cbPoli8.Size = new System.Drawing.Size(123, 21);
            this.cbPoli8.TabIndex = 0;
            this.cbPoli8.Text = "Polivalente V8 ";
            this.cbPoli8.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbNaoVermifugado);
            this.groupBox4.Controls.Add(this.rbVermifugado);
            this.groupBox4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(157, 395);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(300, 44);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Vermifugado";
            // 
            // rbNaoVermifugado
            // 
            this.rbNaoVermifugado.AutoSize = true;
            this.rbNaoVermifugado.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNaoVermifugado.Location = new System.Drawing.Point(150, 20);
            this.rbNaoVermifugado.Name = "rbNaoVermifugado";
            this.rbNaoVermifugado.Size = new System.Drawing.Size(54, 21);
            this.rbNaoVermifugado.TabIndex = 1;
            this.rbNaoVermifugado.Text = "Não";
            this.rbNaoVermifugado.UseVisualStyleBackColor = true;
            // 
            // rbVermifugado
            // 
            this.rbVermifugado.AutoSize = true;
            this.rbVermifugado.Checked = true;
            this.rbVermifugado.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbVermifugado.Location = new System.Drawing.Point(7, 20);
            this.rbVermifugado.Name = "rbVermifugado";
            this.rbVermifugado.Size = new System.Drawing.Size(48, 21);
            this.rbVermifugado.TabIndex = 0;
            this.rbVermifugado.TabStop = true;
            this.rbVermifugado.Text = "Sim";
            this.rbVermifugado.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rbNaoCastrado);
            this.groupBox5.Controls.Add(this.rbCastrado);
            this.groupBox5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(157, 443);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(300, 44);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Castrado";
            // 
            // rbNaoCastrado
            // 
            this.rbNaoCastrado.AutoSize = true;
            this.rbNaoCastrado.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNaoCastrado.Location = new System.Drawing.Point(148, 20);
            this.rbNaoCastrado.Name = "rbNaoCastrado";
            this.rbNaoCastrado.Size = new System.Drawing.Size(54, 21);
            this.rbNaoCastrado.TabIndex = 1;
            this.rbNaoCastrado.Text = "Não";
            this.rbNaoCastrado.UseVisualStyleBackColor = true;
            // 
            // rbCastrado
            // 
            this.rbCastrado.AutoSize = true;
            this.rbCastrado.Checked = true;
            this.rbCastrado.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCastrado.Location = new System.Drawing.Point(6, 20);
            this.rbCastrado.Name = "rbCastrado";
            this.rbCastrado.Size = new System.Drawing.Size(48, 21);
            this.rbCastrado.TabIndex = 0;
            this.rbCastrado.TabStop = true;
            this.rbCastrado.Text = "Sim";
            this.rbCastrado.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(160, 499);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Histórico de saúde:";
            // 
            // txtHistorico
            // 
            this.txtHistorico.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtHistorico.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHistorico.Location = new System.Drawing.Point(157, 519);
            this.txtHistorico.Name = "txtHistorico";
            this.txtHistorico.Size = new System.Drawing.Size(300, 23);
            this.txtHistorico.TabIndex = 11;
            // 
            // btnCadAnimal
            // 
            this.btnCadAnimal.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnCadAnimal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCadAnimal.FlatAppearance.BorderSize = 0;
            this.btnCadAnimal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadAnimal.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadAnimal.Location = new System.Drawing.Point(170, 553);
            this.btnCadAnimal.Name = "btnCadAnimal";
            this.btnCadAnimal.Size = new System.Drawing.Size(115, 35);
            this.btnCadAnimal.TabIndex = 12;
            this.btnCadAnimal.Text = "Cadastrar";
            this.btnCadAnimal.UseVisualStyleBackColor = false;
            this.btnCadAnimal.Click += new System.EventHandler(this.btnCadAnimal_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(126, 615);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(387, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "AAANO - Associação Amigos dos Animais de Nova Odessa";
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoltar.FlatAppearance.BorderSize = 0;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Location = new System.Drawing.Point(300, 553);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(115, 35);
            this.btnVoltar.TabIndex = 14;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // txtRaca
            // 
            this.txtRaca.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtRaca.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRaca.Location = new System.Drawing.Point(157, 224);
            this.txtRaca.Name = "txtRaca";
            this.txtRaca.Size = new System.Drawing.Size(300, 23);
            this.txtRaca.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(160, 204);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 17);
            this.label9.TabIndex = 15;
            this.label9.Text = "Raça:";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(435, -6);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(137, 90);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 17;
            this.pictureBox5.TabStop = false;
            // 
            // FrmAnimal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(564, 609);
            this.Controls.Add(this.txtRaca);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnCadAnimal);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.txtHistorico);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtNomeAnimal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIdAnimal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAnimal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar Novo Animal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAnimal_FormClosing);
            this.Load += new System.EventHandler(this.FrmAnimal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdAnimal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNomeAnimal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbGato;
        private System.Windows.Forms.RadioButton rbCachorro;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbFemea;
        private System.Windows.Forms.RadioButton rbMacho;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbPoli4;
        private System.Windows.Forms.CheckBox cbAntirabica;
        private System.Windows.Forms.CheckBox cbPoli10;
        private System.Windows.Forms.CheckBox cbPoli3;
        private System.Windows.Forms.CheckBox cbPoli8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbNaoVermifugado;
        private System.Windows.Forms.RadioButton rbVermifugado;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbNaoCastrado;
        private System.Windows.Forms.RadioButton rbCastrado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbPoli5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHistorico;
        private System.Windows.Forms.Button btnCadAnimal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.TextBox txtRaca;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}