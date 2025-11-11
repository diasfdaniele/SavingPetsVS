namespace SavingPets
{
    partial class FrmGerenciarProcessoAdotivo
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDadosMedicos = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAgendamentos = new System.Windows.Forms.TextBox();
            this.txtRelatorioAdaptacao = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDataAdocao = new System.Windows.Forms.TextBox();
            this.txtIdAnimal = new System.Windows.Forms.TextBox();
            this.txtIdProcesso = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbIdAnimal = new System.Windows.Forms.RadioButton();
            this.txtPesquisaProcesso = new System.Windows.Forms.TextBox();
            this.rbIdProcesso = new System.Windows.Forms.RadioButton();
            this.btnPesquisarProcesso = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnEncerrarProcesso = new System.Windows.Forms.Button();
            this.btnEditarProcesso = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDadosMedicos);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtAgendamentos);
            this.groupBox2.Controls.Add(this.txtRelatorioAdaptacao);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtDataAdocao);
            this.groupBox2.Controls.Add(this.txtIdAnimal);
            this.groupBox2.Controls.Add(this.txtIdProcesso);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 387);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(637, 285);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informações";
            // 
            // txtDadosMedicos
            // 
            this.txtDadosMedicos.Location = new System.Drawing.Point(185, 237);
            this.txtDadosMedicos.Name = "txtDadosMedicos";
            this.txtDadosMedicos.Size = new System.Drawing.Size(430, 23);
            this.txtDadosMedicos.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(23, 322);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(0, 17);
            this.label14.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 237);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 17);
            this.label12.TabIndex = 23;
            this.label12.Text = "Dados médicos:";
            // 
            // txtAgendamentos
            // 
            this.txtAgendamentos.Location = new System.Drawing.Point(185, 196);
            this.txtAgendamentos.Name = "txtAgendamentos";
            this.txtAgendamentos.Size = new System.Drawing.Size(430, 23);
            this.txtAgendamentos.TabIndex = 21;
            this.txtAgendamentos.TextChanged += new System.EventHandler(this.txtTelefone_TextChanged);
            // 
            // txtRelatorioAdaptacao
            // 
            this.txtRelatorioAdaptacao.Location = new System.Drawing.Point(185, 150);
            this.txtRelatorioAdaptacao.Name = "txtRelatorioAdaptacao";
            this.txtRelatorioAdaptacao.Size = new System.Drawing.Size(428, 23);
            this.txtRelatorioAdaptacao.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 196);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 17);
            this.label11.TabIndex = 19;
            this.label11.Text = "Agendamentos:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 153);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(171, 17);
            this.label10.TabIndex = 18;
            this.label10.Text = "Relatório de adaptação:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Data da adoção:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "ID do animal:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "ID do processo:";
            // 
            // txtDataAdocao
            // 
            this.txtDataAdocao.Location = new System.Drawing.Point(185, 104);
            this.txtDataAdocao.Name = "txtDataAdocao";
            this.txtDataAdocao.Size = new System.Drawing.Size(428, 23);
            this.txtDataAdocao.TabIndex = 2;
            // 
            // txtIdAnimal
            // 
            this.txtIdAnimal.Location = new System.Drawing.Point(185, 64);
            this.txtIdAnimal.Name = "txtIdAnimal";
            this.txtIdAnimal.Size = new System.Drawing.Size(428, 23);
            this.txtIdAnimal.TabIndex = 1;
            // 
            // txtIdProcesso
            // 
            this.txtIdProcesso.Location = new System.Drawing.Point(185, 22);
            this.txtIdProcesso.Name = "txtIdProcesso";
            this.txtIdProcesso.Size = new System.Drawing.Size(428, 23);
            this.txtIdProcesso.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rbIdAnimal);
            this.groupBox1.Controls.Add(this.txtPesquisaProcesso);
            this.groupBox1.Controls.Add(this.rbIdProcesso);
            this.groupBox1.Controls.Add(this.btnPesquisarProcesso);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(487, 135);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consulta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID processo";
            // 
            // rbIdAnimal
            // 
            this.rbIdAnimal.AutoSize = true;
            this.rbIdAnimal.Location = new System.Drawing.Point(225, 85);
            this.rbIdAnimal.Name = "rbIdAnimal";
            this.rbIdAnimal.Size = new System.Drawing.Size(91, 21);
            this.rbIdAnimal.TabIndex = 5;
            this.rbIdAnimal.Text = "ID animal";
            this.rbIdAnimal.UseVisualStyleBackColor = true;
            // 
            // txtPesquisaProcesso
            // 
            this.txtPesquisaProcesso.Location = new System.Drawing.Point(116, 36);
            this.txtPesquisaProcesso.Name = "txtPesquisaProcesso";
            this.txtPesquisaProcesso.Size = new System.Drawing.Size(200, 23);
            this.txtPesquisaProcesso.TabIndex = 2;
            // 
            // rbIdProcesso
            // 
            this.rbIdProcesso.AutoSize = true;
            this.rbIdProcesso.Checked = true;
            this.rbIdProcesso.Location = new System.Drawing.Point(116, 85);
            this.rbIdProcesso.Name = "rbIdProcesso";
            this.rbIdProcesso.Size = new System.Drawing.Size(103, 21);
            this.rbIdProcesso.TabIndex = 4;
            this.rbIdProcesso.TabStop = true;
            this.rbIdProcesso.Text = "ID processo";
            this.rbIdProcesso.UseVisualStyleBackColor = true;
            // 
            // btnPesquisarProcesso
            // 
            this.btnPesquisarProcesso.Location = new System.Drawing.Point(339, 23);
            this.btnPesquisarProcesso.Name = "btnPesquisarProcesso";
            this.btnPesquisarProcesso.Size = new System.Drawing.Size(128, 49);
            this.btnPesquisarProcesso.TabIndex = 3;
            this.btnPesquisarProcesso.Text = "Pesquisar";
            this.btnPesquisarProcesso.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 162);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1116, 205);
            this.dataGridView1.TabIndex = 16;
            // 
            // btnEncerrarProcesso
            // 
            this.btnEncerrarProcesso.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnEncerrarProcesso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEncerrarProcesso.FlatAppearance.BorderSize = 0;
            this.btnEncerrarProcesso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncerrarProcesso.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncerrarProcesso.Location = new System.Drawing.Point(715, 560);
            this.btnEncerrarProcesso.Margin = new System.Windows.Forms.Padding(4);
            this.btnEncerrarProcesso.Name = "btnEncerrarProcesso";
            this.btnEncerrarProcesso.Size = new System.Drawing.Size(153, 43);
            this.btnEncerrarProcesso.TabIndex = 41;
            this.btnEncerrarProcesso.Text = "Encerrar";
            this.btnEncerrarProcesso.UseVisualStyleBackColor = false;
            // 
            // btnEditarProcesso
            // 
            this.btnEditarProcesso.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnEditarProcesso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarProcesso.FlatAppearance.BorderSize = 0;
            this.btnEditarProcesso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarProcesso.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarProcesso.Location = new System.Drawing.Point(715, 471);
            this.btnEditarProcesso.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditarProcesso.Name = "btnEditarProcesso";
            this.btnEditarProcesso.Size = new System.Drawing.Size(153, 43);
            this.btnEditarProcesso.TabIndex = 40;
            this.btnEditarProcesso.Text = "Editar";
            this.btnEditarProcesso.UseVisualStyleBackColor = false;
            // 
            // FrmGerenciarProcessoAdotivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.Controls.Add(this.btnEncerrarProcesso);
            this.Controls.Add(this.btnEditarProcesso);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmGerenciarProcessoAdotivo";
            this.Text = "Consultar Processo Adotivo";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDadosMedicos;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtAgendamentos;
        private System.Windows.Forms.TextBox txtRelatorioAdaptacao;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDataAdocao;
        private System.Windows.Forms.TextBox txtIdAnimal;
        private System.Windows.Forms.TextBox txtIdProcesso;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbIdAnimal;
        private System.Windows.Forms.TextBox txtPesquisaProcesso;
        private System.Windows.Forms.RadioButton rbIdProcesso;
        private System.Windows.Forms.Button btnPesquisarProcesso;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnEncerrarProcesso;
        private System.Windows.Forms.Button btnEditarProcesso;
    }
}