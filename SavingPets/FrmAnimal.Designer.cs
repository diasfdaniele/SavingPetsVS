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
            this.checkBox2 = new System.Windows.Forms.CheckBox();
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
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(189, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(390, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadastro de animais";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(223, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID:";
            // 
            // txtIdAnimal
            // 
            this.txtIdAnimal.BackColor = System.Drawing.Color.Gainsboro;
            this.txtIdAnimal.Enabled = false;
            this.txtIdAnimal.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdAnimal.Location = new System.Drawing.Point(227, 91);
            this.txtIdAnimal.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdAnimal.Name = "txtIdAnimal";
            this.txtIdAnimal.ReadOnly = true;
            this.txtIdAnimal.Size = new System.Drawing.Size(325, 27);
            this.txtIdAnimal.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(223, 126);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nome:";
            // 
            // txtNomeAnimal
            // 
            this.txtNomeAnimal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNomeAnimal.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeAnimal.Location = new System.Drawing.Point(227, 150);
            this.txtNomeAnimal.Margin = new System.Windows.Forms.Padding(4);
            this.txtNomeAnimal.Name = "txtNomeAnimal";
            this.txtNomeAnimal.Size = new System.Drawing.Size(325, 27);
            this.txtNomeAnimal.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbGato);
            this.groupBox1.Controls.Add(this.rbCachorro);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(227, 191);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(327, 63);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Espécie";
            // 
            // rbGato
            // 
            this.rbGato.AutoSize = true;
            this.rbGato.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbGato.Location = new System.Drawing.Point(200, 27);
            this.rbGato.Margin = new System.Windows.Forms.Padding(4);
            this.rbGato.Name = "rbGato";
            this.rbGato.Size = new System.Drawing.Size(68, 24);
            this.rbGato.TabIndex = 1;
            this.rbGato.Text = "Gato";
            this.rbGato.UseVisualStyleBackColor = true;
            // 
            // rbCachorro
            // 
            this.rbCachorro.AutoSize = true;
            this.rbCachorro.BackColor = System.Drawing.Color.Transparent;
            this.rbCachorro.Checked = true;
            this.rbCachorro.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCachorro.Location = new System.Drawing.Point(12, 28);
            this.rbCachorro.Margin = new System.Windows.Forms.Padding(4);
            this.rbCachorro.Name = "rbCachorro";
            this.rbCachorro.Size = new System.Drawing.Size(101, 24);
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
            this.groupBox2.Location = new System.Drawing.Point(227, 256);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(327, 54);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sexo";
            // 
            // rbFemea
            // 
            this.rbFemea.AutoSize = true;
            this.rbFemea.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFemea.Location = new System.Drawing.Point(200, 21);
            this.rbFemea.Margin = new System.Windows.Forms.Padding(4);
            this.rbFemea.Name = "rbFemea";
            this.rbFemea.Size = new System.Drawing.Size(80, 24);
            this.rbFemea.TabIndex = 1;
            this.rbFemea.Text = "Fêmea";
            this.rbFemea.UseVisualStyleBackColor = true;
            // 
            // rbMacho
            // 
            this.rbMacho.AutoSize = true;
            this.rbMacho.Checked = true;
            this.rbMacho.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMacho.Location = new System.Drawing.Point(12, 22);
            this.rbMacho.Margin = new System.Windows.Forms.Padding(4);
            this.rbMacho.Name = "rbMacho";
            this.rbMacho.Size = new System.Drawing.Size(84, 24);
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
            this.groupBox3.Controls.Add(this.checkBox2);
            this.groupBox3.Controls.Add(this.cbPoli8);
            this.groupBox3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(227, 318);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(327, 167);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Vacinas";
            // 
            // cbPoli5
            // 
            this.cbPoli5.AutoSize = true;
            this.cbPoli5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPoli5.Location = new System.Drawing.Point(168, 138);
            this.cbPoli5.Margin = new System.Windows.Forms.Padding(4);
            this.cbPoli5.Name = "cbPoli5";
            this.cbPoli5.Size = new System.Drawing.Size(136, 24);
            this.cbPoli5.TabIndex = 10;
            this.cbPoli5.Text = "Polivalente V5";
            this.cbPoli5.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(36, 23);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(239, 21);
            this.label6.TabIndex = 8;
            this.label6.Text = "Obrigatória - Cães e Gatos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(201, 73);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "Gatos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 73);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cães";
            // 
            // cbAntirabica
            // 
            this.cbAntirabica.AutoSize = true;
            this.cbAntirabica.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAntirabica.Location = new System.Drawing.Point(99, 47);
            this.cbAntirabica.Margin = new System.Windows.Forms.Padding(4);
            this.cbAntirabica.Name = "cbAntirabica";
            this.cbAntirabica.Size = new System.Drawing.Size(120, 25);
            this.cbAntirabica.TabIndex = 4;
            this.cbAntirabica.Text = "Antirábica";
            this.cbAntirabica.UseVisualStyleBackColor = true;
            // 
            // cbPoli4
            // 
            this.cbPoli4.AutoSize = true;
            this.cbPoli4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPoli4.Location = new System.Drawing.Point(168, 117);
            this.cbPoli4.Margin = new System.Windows.Forms.Padding(4);
            this.cbPoli4.Name = "cbPoli4";
            this.cbPoli4.Size = new System.Drawing.Size(136, 24);
            this.cbPoli4.TabIndex = 5;
            this.cbPoli4.Text = "Polivalente V4";
            this.cbPoli4.UseVisualStyleBackColor = true;
            // 
            // cbPoli10
            // 
            this.cbPoli10.AutoSize = true;
            this.cbPoli10.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPoli10.Location = new System.Drawing.Point(3, 133);
            this.cbPoli10.Margin = new System.Windows.Forms.Padding(4);
            this.cbPoli10.Name = "cbPoli10";
            this.cbPoli10.Size = new System.Drawing.Size(144, 24);
            this.cbPoli10.TabIndex = 3;
            this.cbPoli10.Text = "Polivalente V10";
            this.cbPoli10.UseVisualStyleBackColor = true;
            // 
            // cbPoli3
            // 
            this.cbPoli3.AutoSize = true;
            this.cbPoli3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPoli3.Location = new System.Drawing.Point(168, 97);
            this.cbPoli3.Margin = new System.Windows.Forms.Padding(4);
            this.cbPoli3.Name = "cbPoli3";
            this.cbPoli3.Size = new System.Drawing.Size(136, 24);
            this.cbPoli3.TabIndex = 2;
            this.cbPoli3.Text = "Polivalente V3";
            this.cbPoli3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(344, 130);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(122, 25);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // cbPoli8
            // 
            this.cbPoli8.AutoSize = true;
            this.cbPoli8.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPoli8.Location = new System.Drawing.Point(3, 103);
            this.cbPoli8.Margin = new System.Windows.Forms.Padding(4);
            this.cbPoli8.Name = "cbPoli8";
            this.cbPoli8.Size = new System.Drawing.Size(140, 24);
            this.cbPoli8.TabIndex = 0;
            this.cbPoli8.Text = "Polivalente V8 ";
            this.cbPoli8.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbNaoVermifugado);
            this.groupBox4.Controls.Add(this.rbVermifugado);
            this.groupBox4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(227, 486);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(324, 54);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Vermifugado";
            // 
            // rbNaoVermifugado
            // 
            this.rbNaoVermifugado.AutoSize = true;
            this.rbNaoVermifugado.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNaoVermifugado.Location = new System.Drawing.Point(200, 25);
            this.rbNaoVermifugado.Margin = new System.Windows.Forms.Padding(4);
            this.rbNaoVermifugado.Name = "rbNaoVermifugado";
            this.rbNaoVermifugado.Size = new System.Drawing.Size(61, 24);
            this.rbNaoVermifugado.TabIndex = 1;
            this.rbNaoVermifugado.Text = "Não";
            this.rbNaoVermifugado.UseVisualStyleBackColor = true;
            // 
            // rbVermifugado
            // 
            this.rbVermifugado.AutoSize = true;
            this.rbVermifugado.Checked = true;
            this.rbVermifugado.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbVermifugado.Location = new System.Drawing.Point(9, 25);
            this.rbVermifugado.Margin = new System.Windows.Forms.Padding(4);
            this.rbVermifugado.Name = "rbVermifugado";
            this.rbVermifugado.Size = new System.Drawing.Size(53, 24);
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
            this.groupBox5.Location = new System.Drawing.Point(227, 545);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(324, 54);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Castrado";
            // 
            // rbNaoCastrado
            // 
            this.rbNaoCastrado.AutoSize = true;
            this.rbNaoCastrado.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNaoCastrado.Location = new System.Drawing.Point(197, 25);
            this.rbNaoCastrado.Margin = new System.Windows.Forms.Padding(4);
            this.rbNaoCastrado.Name = "rbNaoCastrado";
            this.rbNaoCastrado.Size = new System.Drawing.Size(61, 24);
            this.rbNaoCastrado.TabIndex = 1;
            this.rbNaoCastrado.Text = "Não";
            this.rbNaoCastrado.UseVisualStyleBackColor = true;
            // 
            // rbCastrado
            // 
            this.rbCastrado.AutoSize = true;
            this.rbCastrado.Checked = true;
            this.rbCastrado.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCastrado.Location = new System.Drawing.Point(8, 25);
            this.rbCastrado.Margin = new System.Windows.Forms.Padding(4);
            this.rbCastrado.Name = "rbCastrado";
            this.rbCastrado.Size = new System.Drawing.Size(53, 24);
            this.rbCastrado.TabIndex = 0;
            this.rbCastrado.TabStop = true;
            this.rbCastrado.Text = "Sim";
            this.rbCastrado.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(225, 607);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 21);
            this.label7.TabIndex = 10;
            this.label7.Text = "Histórico de saúde:";
            // 
            // txtHistorico
            // 
            this.txtHistorico.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtHistorico.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHistorico.Location = new System.Drawing.Point(227, 630);
            this.txtHistorico.Margin = new System.Windows.Forms.Padding(4);
            this.txtHistorico.Name = "txtHistorico";
            this.txtHistorico.Size = new System.Drawing.Size(325, 27);
            this.txtHistorico.TabIndex = 11;
            // 
            // btnCadAnimal
            // 
            this.btnCadAnimal.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnCadAnimal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCadAnimal.FlatAppearance.BorderSize = 0;
            this.btnCadAnimal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadAnimal.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadAnimal.Location = new System.Drawing.Point(227, 681);
            this.btnCadAnimal.Margin = new System.Windows.Forms.Padding(4);
            this.btnCadAnimal.Name = "btnCadAnimal";
            this.btnCadAnimal.Size = new System.Drawing.Size(153, 43);
            this.btnCadAnimal.TabIndex = 12;
            this.btnCadAnimal.Text = "Cadastrar";
            this.btnCadAnimal.UseVisualStyleBackColor = false;
            this.btnCadAnimal.Click += new System.EventHandler(this.btnCadAnimal_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(168, 757);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(404, 19);
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
            this.btnVoltar.Location = new System.Drawing.Point(400, 681);
            this.btnVoltar.Margin = new System.Windows.Forms.Padding(4);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(153, 43);
            this.btnVoltar.TabIndex = 14;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // FrmAnimal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(752, 789);
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmAnimal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar Novo Animal";
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
        private System.Windows.Forms.CheckBox checkBox2;
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
    }
}