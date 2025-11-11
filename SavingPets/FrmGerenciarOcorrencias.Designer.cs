namespace SavingPets
{
    partial class FrmGerenciarOcorrencias
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
            this.label1 = new System.Windows.Forms.Label();
            this.rbIdOcorrencia = new System.Windows.Forms.RadioButton();
            this.txtPesquisarOcorrencias = new System.Windows.Forms.TextBox();
            this.rbIdTutor = new System.Windows.Forms.RadioButton();
            this.btnPesquisar_Ocorrencia = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtGravidade = new System.Windows.Forms.TextBox();
            this.txtDataOcorrido = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProvidenciaTomada = new System.Windows.Forms.TextBox();
            this.txtDescricaoOcorrido = new System.Windows.Forms.TextBox();
            this.txtIdOcorrencia = new System.Windows.Forms.TextBox();
            this.txtIdTutor = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rbIdOcorrencia);
            this.groupBox1.Controls.Add(this.txtPesquisarOcorrencias);
            this.groupBox1.Controls.Add(this.rbIdTutor);
            this.groupBox1.Controls.Add(this.btnPesquisar_Ocorrencia);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(497, 135);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consulta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID tutor";
            // 
            // rbIdOcorrencia
            // 
            this.rbIdOcorrencia.AutoSize = true;
            this.rbIdOcorrencia.Location = new System.Drawing.Point(217, 85);
            this.rbIdOcorrencia.Name = "rbIdOcorrencia";
            this.rbIdOcorrencia.Size = new System.Drawing.Size(116, 21);
            this.rbIdOcorrencia.TabIndex = 5;
            this.rbIdOcorrencia.Text = "ID ocorrência";
            this.rbIdOcorrencia.UseVisualStyleBackColor = true;
            // 
            // txtPesquisarOcorrencias
            // 
            this.txtPesquisarOcorrencias.Location = new System.Drawing.Point(86, 37);
            this.txtPesquisarOcorrencias.Name = "txtPesquisarOcorrencias";
            this.txtPesquisarOcorrencias.Size = new System.Drawing.Size(247, 23);
            this.txtPesquisarOcorrencias.TabIndex = 2;
            // 
            // rbIdTutor
            // 
            this.rbIdTutor.AutoSize = true;
            this.rbIdTutor.Checked = true;
            this.rbIdTutor.Location = new System.Drawing.Point(86, 85);
            this.rbIdTutor.Name = "rbIdTutor";
            this.rbIdTutor.Size = new System.Drawing.Size(77, 21);
            this.rbIdTutor.TabIndex = 4;
            this.rbIdTutor.TabStop = true;
            this.rbIdTutor.Text = "ID tutor";
            this.rbIdTutor.UseVisualStyleBackColor = true;
            // 
            // btnPesquisar_Ocorrencia
            // 
            this.btnPesquisar_Ocorrencia.Location = new System.Drawing.Point(349, 24);
            this.btnPesquisar_Ocorrencia.Name = "btnPesquisar_Ocorrencia";
            this.btnPesquisar_Ocorrencia.Size = new System.Drawing.Size(128, 49);
            this.btnPesquisar_Ocorrencia.TabIndex = 3;
            this.btnPesquisar_Ocorrencia.Text = "Pesquisar";
            this.btnPesquisar_Ocorrencia.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 162);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1116, 205);
            this.dataGridView1.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtProvidenciaTomada);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtGravidade);
            this.groupBox2.Controls.Add(this.txtDataOcorrido);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtDescricaoOcorrido);
            this.groupBox2.Controls.Add(this.txtIdOcorrencia);
            this.groupBox2.Controls.Add(this.txtIdTutor);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 387);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(619, 285);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informações";
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
            this.label12.Size = new System.Drawing.Size(147, 17);
            this.label12.TabIndex = 23;
            this.label12.Text = "Providência tomada:";
            // 
            // txtGravidade
            // 
            this.txtGravidade.Location = new System.Drawing.Point(176, 191);
            this.txtGravidade.Name = "txtGravidade";
            this.txtGravidade.Size = new System.Drawing.Size(430, 23);
            this.txtGravidade.TabIndex = 21;
            // 
            // txtDataOcorrido
            // 
            this.txtDataOcorrido.Location = new System.Drawing.Point(176, 147);
            this.txtDataOcorrido.Name = "txtDataOcorrido";
            this.txtDataOcorrido.Size = new System.Drawing.Size(428, 23);
            this.txtDataOcorrido.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 196);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 17);
            this.label11.TabIndex = 19;
            this.label11.Text = "Gravidade:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 153);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 17);
            this.label10.TabIndex = 18;
            this.label10.Text = "Data do ocorrido:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(157, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Descrição do ocorrido:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "ID da ocorrência:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "ID do tutor:";
            // 
            // txtProvidenciaTomada
            // 
            this.txtProvidenciaTomada.Location = new System.Drawing.Point(176, 237);
            this.txtProvidenciaTomada.Name = "txtProvidenciaTomada";
            this.txtProvidenciaTomada.Size = new System.Drawing.Size(430, 23);
            this.txtProvidenciaTomada.TabIndex = 13;
            // 
            // txtDescricaoOcorrido
            // 
            this.txtDescricaoOcorrido.Location = new System.Drawing.Point(176, 104);
            this.txtDescricaoOcorrido.Name = "txtDescricaoOcorrido";
            this.txtDescricaoOcorrido.Size = new System.Drawing.Size(428, 23);
            this.txtDescricaoOcorrido.TabIndex = 2;
            // 
            // txtIdOcorrencia
            // 
            this.txtIdOcorrencia.Location = new System.Drawing.Point(176, 63);
            this.txtIdOcorrencia.Name = "txtIdOcorrencia";
            this.txtIdOcorrencia.Size = new System.Drawing.Size(428, 23);
            this.txtIdOcorrencia.TabIndex = 1;
            // 
            // txtIdTutor
            // 
            this.txtIdTutor.Location = new System.Drawing.Point(176, 22);
            this.txtIdTutor.Name = "txtIdTutor";
            this.txtIdTutor.Size = new System.Drawing.Size(428, 23);
            this.txtIdTutor.TabIndex = 0;
            // 
            // FrmGerenciarOcorrencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmGerenciarOcorrencias";
            this.Text = "Consultar Ocorrências";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbIdOcorrencia;
        private System.Windows.Forms.TextBox txtPesquisarOcorrencias;
        private System.Windows.Forms.RadioButton rbIdTutor;
        private System.Windows.Forms.Button btnPesquisar_Ocorrencia;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtGravidade;
        private System.Windows.Forms.TextBox txtDataOcorrido;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProvidenciaTomada;
        private System.Windows.Forms.TextBox txtDescricaoOcorrido;
        private System.Windows.Forms.TextBox txtIdOcorrencia;
        private System.Windows.Forms.TextBox txtIdTutor;
    }
}