namespace SavingPets
{
    partial class Ocorrencia
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
            this.label8 = new System.Windows.Forms.Label();
            this.rbNaoCastrado = new System.Windows.Forms.RadioButton();
            this.rbCastrado = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnCadAnimal = new System.Windows.Forms.Button();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdTutor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.txtIdOcorrencia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProvidencia = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(136, 616);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(318, 16);
            this.label8.TabIndex = 27;
            this.label8.Text = "AAANO - Associação Amigos dos Animais de Nova Odessa";
            // 
            // rbNaoCastrado
            // 
            this.rbNaoCastrado.AutoSize = true;
            this.rbNaoCastrado.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNaoCastrado.Location = new System.Drawing.Point(90, 20);
            this.rbNaoCastrado.Name = "rbNaoCastrado";
            this.rbNaoCastrado.Size = new System.Drawing.Size(64, 21);
            this.rbNaoCastrado.TabIndex = 1;
            this.rbNaoCastrado.TabStop = true;
            this.rbNaoCastrado.Text = "Media";
            this.rbNaoCastrado.UseVisualStyleBackColor = true;
            // 
            // rbCastrado
            // 
            this.rbCastrado.AutoSize = true;
            this.rbCastrado.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCastrado.Location = new System.Drawing.Point(6, 20);
            this.rbCastrado.Name = "rbCastrado";
            this.rbCastrado.Size = new System.Drawing.Size(58, 21);
            this.rbCastrado.TabIndex = 0;
            this.rbCastrado.TabStop = true;
            this.rbCastrado.Text = "Baixa";
            this.rbCastrado.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButton1);
            this.groupBox5.Controls.Add(this.rbNaoCastrado);
            this.groupBox5.Controls.Add(this.rbCastrado);
            this.groupBox5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(179, 249);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(243, 44);
            this.groupBox5.TabIndex = 23;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Gravidade:";
            // 
            // btnCadAnimal
            // 
            this.btnCadAnimal.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnCadAnimal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCadAnimal.FlatAppearance.BorderSize = 0;
            this.btnCadAnimal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadAnimal.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadAnimal.Location = new System.Drawing.Point(239, 379);
            this.btnCadAnimal.Name = "btnCadAnimal";
            this.btnCadAnimal.Size = new System.Drawing.Size(115, 35);
            this.btnCadAnimal.TabIndex = 26;
            this.btnCadAnimal.Text = "Cadastrar";
            this.btnCadAnimal.UseVisualStyleBackColor = false;
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDescricao.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(179, 172);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(245, 23);
            this.txtDescricao.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(176, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Descrição do ocorrido:";
            // 
            // txtIdTutor
            // 
            this.txtIdTutor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtIdTutor.Enabled = false;
            this.txtIdTutor.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdTutor.Location = new System.Drawing.Point(179, 124);
            this.txtIdTutor.Name = "txtIdTutor";
            this.txtIdTutor.Size = new System.Drawing.Size(245, 23);
            this.txtIdTutor.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(176, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "ID do tutor:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(133, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(355, 36);
            this.label1.TabIndex = 14;
            this.label1.Text = "Registro de Ocorrências";
            // 
            // txtData
            // 
            this.txtData.AcceptsReturn = true;
            this.txtData.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtData.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtData.Location = new System.Drawing.Point(179, 220);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(245, 23);
            this.txtData.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(178, 201);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 17);
            this.label9.TabIndex = 28;
            this.label9.Text = "Data do Ocorrido:";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(173, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(51, 21);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Alta";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // txtIdOcorrencia
            // 
            this.txtIdOcorrencia.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtIdOcorrencia.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdOcorrencia.Location = new System.Drawing.Point(179, 78);
            this.txtIdOcorrencia.Name = "txtIdOcorrencia";
            this.txtIdOcorrencia.Size = new System.Drawing.Size(245, 23);
            this.txtIdOcorrencia.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(176, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 17);
            this.label4.TabIndex = 30;
            this.label4.Text = "ID da ocorrência:";
            // 
            // txtProvidencia
            // 
            this.txtProvidencia.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtProvidencia.Enabled = false;
            this.txtProvidencia.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProvidencia.Location = new System.Drawing.Point(179, 315);
            this.txtProvidencia.Name = "txtProvidencia";
            this.txtProvidencia.Size = new System.Drawing.Size(245, 23);
            this.txtProvidencia.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(176, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 17);
            this.label5.TabIndex = 32;
            this.label5.Text = "Providência tomada:";
            // 
            // Ocorrencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(564, 641);
            this.Controls.Add(this.txtProvidencia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtIdOcorrencia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnCadAnimal);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIdTutor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Ocorrencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ocorrencia";
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rbNaoCastrado;
        private System.Windows.Forms.RadioButton rbCastrado;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnCadAnimal;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdTutor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox txtIdOcorrencia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProvidencia;
        private System.Windows.Forms.Label label5;
    }
}