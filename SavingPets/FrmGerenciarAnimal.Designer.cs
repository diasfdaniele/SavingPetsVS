namespace SavingPets
{
    partial class FrmGerenciarAnimal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGerenciarAnimal));
            this.dgvAnimais = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPesquisarAnimal = new System.Windows.Forms.TextBox();
            this.btnPesquisar_Animal = new System.Windows.Forms.Button();
            this.rbIDAnimal = new System.Windows.Forms.RadioButton();
            this.rbNomeAnimal = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtHistoricoSaude = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCastrado = new System.Windows.Forms.TextBox();
            this.txtVermifugado = new System.Windows.Forms.TextBox();
            this.txtVacinas = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSexoAnimal = new System.Windows.Forms.TextBox();
            this.txtEspecie = new System.Windows.Forms.TextBox();
            this.txtNomeAnimal = new System.Windows.Forms.TextBox();
            this.txtIdAnimal = new System.Windows.Forms.TextBox();
            this.btnExcluir_Animal = new System.Windows.Forms.Button();
            this.btnEditar_Animal = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnimais)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAnimais
            // 
            this.dgvAnimais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnimais.Location = new System.Drawing.Point(16, 145);
            this.dgvAnimais.Margin = new System.Windows.Forms.Padding(2);
            this.dgvAnimais.Name = "dgvAnimais";
            this.dgvAnimais.RowHeadersWidth = 51;
            this.dgvAnimais.RowTemplate.Height = 24;
            this.dgvAnimais.Size = new System.Drawing.Size(764, 167);
            this.dgvAnimais.TabIndex = 0;
            this.dgvAnimais.SelectionChanged += new System.EventHandler(this.dgvAnimais_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID animal";
            // 
            // txtPesquisarAnimal
            // 
            this.txtPesquisarAnimal.Location = new System.Drawing.Point(79, 31);
            this.txtPesquisarAnimal.Margin = new System.Windows.Forms.Padding(2);
            this.txtPesquisarAnimal.Name = "txtPesquisarAnimal";
            this.txtPesquisarAnimal.Size = new System.Drawing.Size(187, 22);
            this.txtPesquisarAnimal.TabIndex = 2;
            // 
            // btnPesquisar_Animal
            // 
            this.btnPesquisar_Animal.Location = new System.Drawing.Point(292, 20);
            this.btnPesquisar_Animal.Margin = new System.Windows.Forms.Padding(2);
            this.btnPesquisar_Animal.Name = "btnPesquisar_Animal";
            this.btnPesquisar_Animal.Size = new System.Drawing.Size(96, 40);
            this.btnPesquisar_Animal.TabIndex = 3;
            this.btnPesquisar_Animal.Text = "Pesquisar";
            this.btnPesquisar_Animal.UseVisualStyleBackColor = true;
            this.btnPesquisar_Animal.Click += new System.EventHandler(this.btnPesquisar_Animal_Click);
            // 
            // rbIDAnimal
            // 
            this.rbIDAnimal.AutoSize = true;
            this.rbIDAnimal.Checked = true;
            this.rbIDAnimal.Location = new System.Drawing.Point(72, 69);
            this.rbIDAnimal.Margin = new System.Windows.Forms.Padding(2);
            this.rbIDAnimal.Name = "rbIDAnimal";
            this.rbIDAnimal.Size = new System.Drawing.Size(81, 21);
            this.rbIDAnimal.TabIndex = 4;
            this.rbIDAnimal.TabStop = true;
            this.rbIDAnimal.Text = "ID animal";
            this.rbIDAnimal.UseVisualStyleBackColor = true;
            this.rbIDAnimal.CheckedChanged += new System.EventHandler(this.rbIDAnimal_CheckedChanged);
            // 
            // rbNomeAnimal
            // 
            this.rbNomeAnimal.AutoSize = true;
            this.rbNomeAnimal.Location = new System.Drawing.Point(166, 69);
            this.rbNomeAnimal.Margin = new System.Windows.Forms.Padding(2);
            this.rbNomeAnimal.Name = "rbNomeAnimal";
            this.rbNomeAnimal.Size = new System.Drawing.Size(65, 21);
            this.rbNomeAnimal.TabIndex = 5;
            this.rbNomeAnimal.Text = "Nome ";
            this.rbNomeAnimal.UseVisualStyleBackColor = true;
            this.rbNomeAnimal.CheckedChanged += new System.EventHandler(this.rbNomeAnimal_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rbNomeAnimal);
            this.groupBox1.Controls.Add(this.txtPesquisarAnimal);
            this.groupBox1.Controls.Add(this.rbIDAnimal);
            this.groupBox1.Controls.Add(this.btnPesquisar_Animal);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 24);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(407, 110);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consulta";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtHistoricoSaude);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtCastrado);
            this.groupBox2.Controls.Add(this.txtVermifugado);
            this.groupBox2.Controls.Add(this.txtVacinas);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtSexoAnimal);
            this.groupBox2.Controls.Add(this.txtEspecie);
            this.groupBox2.Controls.Add(this.txtNomeAnimal);
            this.groupBox2.Controls.Add(this.txtIdAnimal);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(16, 317);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(229, 283);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informações";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 262);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 16);
            this.label14.TabIndex = 26;
            this.label14.Text = "saúde:";
            // 
            // txtHistoricoSaude
            // 
            this.txtHistoricoSaude.Location = new System.Drawing.Point(81, 249);
            this.txtHistoricoSaude.Margin = new System.Windows.Forms.Padding(2);
            this.txtHistoricoSaude.Name = "txtHistoricoSaude";
            this.txtHistoricoSaude.Size = new System.Drawing.Size(135, 20);
            this.txtHistoricoSaude.TabIndex = 25;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 245);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 16);
            this.label13.TabIndex = 24;
            this.label13.Text = "Histórico de";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 212);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 16);
            this.label12.TabIndex = 23;
            this.label12.Text = "Castrado:";
            // 
            // txtCastrado
            // 
            this.txtCastrado.Location = new System.Drawing.Point(81, 211);
            this.txtCastrado.Margin = new System.Windows.Forms.Padding(2);
            this.txtCastrado.Name = "txtCastrado";
            this.txtCastrado.Size = new System.Drawing.Size(135, 20);
            this.txtCastrado.TabIndex = 22;
            // 
            // txtVermifugado
            // 
            this.txtVermifugado.Location = new System.Drawing.Point(81, 177);
            this.txtVermifugado.Margin = new System.Windows.Forms.Padding(2);
            this.txtVermifugado.Name = "txtVermifugado";
            this.txtVermifugado.Size = new System.Drawing.Size(137, 20);
            this.txtVermifugado.TabIndex = 21;
            // 
            // txtVacinas
            // 
            this.txtVacinas.Location = new System.Drawing.Point(81, 147);
            this.txtVacinas.Margin = new System.Windows.Forms.Padding(2);
            this.txtVacinas.Name = "txtVacinas";
            this.txtVacinas.Size = new System.Drawing.Size(137, 20);
            this.txtVacinas.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 180);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 16);
            this.label11.TabIndex = 19;
            this.label11.Text = "Vermifugado:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 149);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 16);
            this.label10.TabIndex = 18;
            this.label10.Text = "Vacinas:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 119);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 16);
            this.label9.TabIndex = 17;
            this.label9.Text = "Sexo:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 88);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "Espécie:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Nome:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "ID:";
            // 
            // txtSexoAnimal
            // 
            this.txtSexoAnimal.Location = new System.Drawing.Point(81, 118);
            this.txtSexoAnimal.Margin = new System.Windows.Forms.Padding(2);
            this.txtSexoAnimal.Name = "txtSexoAnimal";
            this.txtSexoAnimal.Size = new System.Drawing.Size(135, 20);
            this.txtSexoAnimal.TabIndex = 13;
            // 
            // txtEspecie
            // 
            this.txtEspecie.Location = new System.Drawing.Point(81, 82);
            this.txtEspecie.Margin = new System.Windows.Forms.Padding(2);
            this.txtEspecie.Name = "txtEspecie";
            this.txtEspecie.Size = new System.Drawing.Size(135, 20);
            this.txtEspecie.TabIndex = 2;
            // 
            // txtNomeAnimal
            // 
            this.txtNomeAnimal.Location = new System.Drawing.Point(81, 50);
            this.txtNomeAnimal.Margin = new System.Windows.Forms.Padding(2);
            this.txtNomeAnimal.Name = "txtNomeAnimal";
            this.txtNomeAnimal.Size = new System.Drawing.Size(135, 20);
            this.txtNomeAnimal.TabIndex = 1;
            // 
            // txtIdAnimal
            // 
            this.txtIdAnimal.Location = new System.Drawing.Point(81, 23);
            this.txtIdAnimal.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdAnimal.Name = "txtIdAnimal";
            this.txtIdAnimal.Size = new System.Drawing.Size(137, 20);
            this.txtIdAnimal.TabIndex = 0;
            // 
            // btnExcluir_Animal
            // 
            this.btnExcluir_Animal.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnExcluir_Animal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcluir_Animal.FlatAppearance.BorderSize = 0;
            this.btnExcluir_Animal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir_Animal.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir_Animal.Location = new System.Drawing.Point(308, 462);
            this.btnExcluir_Animal.Name = "btnExcluir_Animal";
            this.btnExcluir_Animal.Size = new System.Drawing.Size(115, 35);
            this.btnExcluir_Animal.TabIndex = 37;
            this.btnExcluir_Animal.Text = "Excluir";
            this.btnExcluir_Animal.UseVisualStyleBackColor = false;
            this.btnExcluir_Animal.Click += new System.EventHandler(this.btnExcluir_Animal_Click);
            // 
            // btnEditar_Animal
            // 
            this.btnEditar_Animal.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnEditar_Animal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar_Animal.FlatAppearance.BorderSize = 0;
            this.btnEditar_Animal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar_Animal.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar_Animal.Location = new System.Drawing.Point(308, 392);
            this.btnEditar_Animal.Name = "btnEditar_Animal";
            this.btnEditar_Animal.Size = new System.Drawing.Size(115, 35);
            this.btnEditar_Animal.TabIndex = 36;
            this.btnEditar_Animal.Text = "Editar";
            this.btnEditar_Animal.UseVisualStyleBackColor = false;
            this.btnEditar_Animal.Click += new System.EventHandler(this.btnEditar_Animal_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoltar.FlatAppearance.BorderSize = 0;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Location = new System.Drawing.Point(308, 529);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(115, 35);
            this.btnVoltar.TabIndex = 38;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(428, 34);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(137, 90);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 6;
            this.pictureBox5.TabStop = false;
            // 
            // FrmGerenciarAnimal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 609);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnExcluir_Animal);
            this.Controls.Add(this.btnEditar_Animal);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvAnimais);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmGerenciarAnimal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Animal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmGerenciarAnimal_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnimais)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAnimais;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPesquisarAnimal;
        private System.Windows.Forms.Button btnPesquisar_Animal;
        private System.Windows.Forms.RadioButton rbIDAnimal;
        private System.Windows.Forms.RadioButton rbNomeAnimal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtEspecie;
        private System.Windows.Forms.TextBox txtNomeAnimal;
        private System.Windows.Forms.TextBox txtIdAnimal;
        private System.Windows.Forms.TextBox txtSexoAnimal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCastrado;
        private System.Windows.Forms.TextBox txtVermifugado;
        private System.Windows.Forms.TextBox txtVacinas;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtHistoricoSaude;
        private System.Windows.Forms.Button btnExcluir_Animal;
        private System.Windows.Forms.Button btnEditar_Animal;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}