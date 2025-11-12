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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGerenciarOcorrencias));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbIdOcorrencia = new System.Windows.Forms.RadioButton();
            this.rbIdProcesso = new System.Windows.Forms.RadioButton();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.rbNomeAnimal = new System.Windows.Forms.RadioButton();
            this.txtPesquisarOcorrencias = new System.Windows.Forms.TextBox();
            this.rbNomeTutor = new System.Windows.Forms.RadioButton();
            this.dgvOcorrencias = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIdOcorrencia = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIdProcesso = new System.Windows.Forms.TextBox();
            this.dataOcorrencia = new System.Windows.Forms.DateTimePicker();
            this.txtProvidencia = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtGravidade = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtNomeAnimal = new System.Windows.Forms.TextBox();
            this.txtNomeTutor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOcorrencias)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbIdOcorrencia);
            this.groupBox1.Controls.Add(this.rbIdProcesso);
            this.groupBox1.Controls.Add(this.btnPesquisar);
            this.groupBox1.Controls.Add(this.lblFiltro);
            this.groupBox1.Controls.Add(this.rbNomeAnimal);
            this.groupBox1.Controls.Add(this.txtPesquisarOcorrencias);
            this.groupBox1.Controls.Add(this.rbNomeTutor);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 36);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(585, 93);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consulta";
            // 
            // rbIdOcorrencia
            // 
            this.rbIdOcorrencia.AutoSize = true;
            this.rbIdOcorrencia.Location = new System.Drawing.Point(441, 58);
            this.rbIdOcorrencia.Margin = new System.Windows.Forms.Padding(2);
            this.rbIdOcorrencia.Name = "rbIdOcorrencia";
            this.rbIdOcorrencia.Size = new System.Drawing.Size(129, 24);
            this.rbIdOcorrencia.TabIndex = 41;
            this.rbIdOcorrencia.Text = "ID ocorrência";
            this.rbIdOcorrencia.UseVisualStyleBackColor = true;
            this.rbIdOcorrencia.CheckedChanged += new System.EventHandler(this.rbIdOcorrencia_CheckedChanged);
            // 
            // rbIdProcesso
            // 
            this.rbIdProcesso.AutoSize = true;
            this.rbIdProcesso.Location = new System.Drawing.Point(307, 58);
            this.rbIdProcesso.Margin = new System.Windows.Forms.Padding(2);
            this.rbIdProcesso.Name = "rbIdProcesso";
            this.rbIdProcesso.Size = new System.Drawing.Size(114, 24);
            this.rbIdProcesso.TabIndex = 40;
            this.rbIdProcesso.Text = "ID processo";
            this.rbIdProcesso.UseVisualStyleBackColor = true;
            this.rbIdProcesso.CheckedChanged += new System.EventHandler(this.rbIdProcesso_CheckedChanged);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.Color.Transparent;
            this.btnPesquisar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.BackgroundImage")));
            this.btnPesquisar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Location = new System.Drawing.Point(551, 27);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(29, 26);
            this.btnPesquisar.TabIndex = 39;
            this.btnPesquisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(15, 30);
            this.lblFiltro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(95, 20);
            this.lblFiltro.TabIndex = 1;
            this.lblFiltro.Text = "Nome tutor:";
            // 
            // rbNomeAnimal
            // 
            this.rbNomeAnimal.AutoSize = true;
            this.rbNomeAnimal.Location = new System.Drawing.Point(158, 58);
            this.rbNomeAnimal.Margin = new System.Windows.Forms.Padding(2);
            this.rbNomeAnimal.Name = "rbNomeAnimal";
            this.rbNomeAnimal.Size = new System.Drawing.Size(123, 24);
            this.rbNomeAnimal.TabIndex = 5;
            this.rbNomeAnimal.Text = "Nome animal";
            this.rbNomeAnimal.UseVisualStyleBackColor = true;
            this.rbNomeAnimal.CheckedChanged += new System.EventHandler(this.rbNomeAnimal_CheckedChanged);
            // 
            // txtPesquisarOcorrencias
            // 
            this.txtPesquisarOcorrencias.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisarOcorrencias.Location = new System.Drawing.Point(172, 27);
            this.txtPesquisarOcorrencias.Margin = new System.Windows.Forms.Padding(2);
            this.txtPesquisarOcorrencias.Name = "txtPesquisarOcorrencias";
            this.txtPesquisarOcorrencias.Size = new System.Drawing.Size(382, 26);
            this.txtPesquisarOcorrencias.TabIndex = 2;
            // 
            // rbNomeTutor
            // 
            this.rbNomeTutor.AutoSize = true;
            this.rbNomeTutor.Checked = true;
            this.rbNomeTutor.Location = new System.Drawing.Point(18, 58);
            this.rbNomeTutor.Margin = new System.Windows.Forms.Padding(2);
            this.rbNomeTutor.Name = "rbNomeTutor";
            this.rbNomeTutor.Size = new System.Drawing.Size(109, 24);
            this.rbNomeTutor.TabIndex = 4;
            this.rbNomeTutor.TabStop = true;
            this.rbNomeTutor.Text = "Nome tutor";
            this.rbNomeTutor.UseVisualStyleBackColor = true;
            this.rbNomeTutor.CheckedChanged += new System.EventHandler(this.rbNomeTutor_CheckedChanged);
            // 
            // dgvOcorrencias
            // 
            this.dgvOcorrencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOcorrencias.Location = new System.Drawing.Point(11, 133);
            this.dgvOcorrencias.Margin = new System.Windows.Forms.Padding(2);
            this.dgvOcorrencias.Name = "dgvOcorrencias";
            this.dgvOcorrencias.RowHeadersWidth = 51;
            this.dgvOcorrencias.RowTemplate.Height = 24;
            this.dgvOcorrencias.Size = new System.Drawing.Size(706, 167);
            this.dgvOcorrencias.TabIndex = 13;
            this.dgvOcorrencias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOcorrencias_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtIdOcorrencia);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtIdProcesso);
            this.groupBox2.Controls.Add(this.dataOcorrencia);
            this.groupBox2.Controls.Add(this.txtProvidencia);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtGravidade);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtDescricao);
            this.groupBox2.Controls.Add(this.txtNomeAnimal);
            this.groupBox2.Controls.Add(this.txtNomeTutor);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(11, 304);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(585, 267);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informações";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(303, 89);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 20);
            this.label6.TabIndex = 39;
            this.label6.Text = "ID Ocorrência:";
            // 
            // txtIdOcorrencia
            // 
            this.txtIdOcorrencia.Enabled = false;
            this.txtIdOcorrencia.Location = new System.Drawing.Point(425, 87);
            this.txtIdOcorrencia.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdOcorrencia.Name = "txtIdOcorrencia";
            this.txtIdOcorrencia.Size = new System.Drawing.Size(117, 26);
            this.txtIdOcorrencia.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 87);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 37;
            this.label5.Text = "ID Processo:";
            // 
            // txtIdProcesso
            // 
            this.txtIdProcesso.Enabled = false;
            this.txtIdProcesso.Location = new System.Drawing.Point(149, 86);
            this.txtIdProcesso.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdProcesso.Name = "txtIdProcesso";
            this.txtIdProcesso.Size = new System.Drawing.Size(117, 26);
            this.txtIdProcesso.TabIndex = 36;
            // 
            // dataOcorrencia
            // 
            this.dataOcorrencia.CalendarFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataOcorrencia.Enabled = false;
            this.dataOcorrencia.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataOcorrencia.Location = new System.Drawing.Point(197, 158);
            this.dataOcorrencia.Name = "dataOcorrencia";
            this.dataOcorrencia.Size = new System.Drawing.Size(345, 26);
            this.dataOcorrencia.TabIndex = 35;
            // 
            // txtProvidencia
            // 
            this.txtProvidencia.Enabled = false;
            this.txtProvidencia.Location = new System.Drawing.Point(197, 228);
            this.txtProvidencia.Margin = new System.Windows.Forms.Padding(2);
            this.txtProvidencia.Name = "txtProvidencia";
            this.txtProvidencia.Size = new System.Drawing.Size(345, 26);
            this.txtProvidencia.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 262);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(0, 20);
            this.label14.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 228);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(164, 20);
            this.label12.TabIndex = 23;
            this.label12.Text = "Providência tomada:";
            // 
            // txtGravidade
            // 
            this.txtGravidade.Enabled = false;
            this.txtGravidade.Location = new System.Drawing.Point(197, 194);
            this.txtGravidade.Margin = new System.Windows.Forms.Padding(2);
            this.txtGravidade.Name = "txtGravidade";
            this.txtGravidade.Size = new System.Drawing.Size(345, 26);
            this.txtGravidade.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 197);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 20);
            this.label11.TabIndex = 19;
            this.label11.Text = "Gravidade:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 162);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(140, 20);
            this.label10.TabIndex = 18;
            this.label10.Text = "Data do ocorrido:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 124);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(179, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Descrição do ocorrido:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 57);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Nome do animal:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Nome do tutor:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Enabled = false;
            this.txtDescricao.Location = new System.Drawing.Point(197, 121);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(345, 26);
            this.txtDescricao.TabIndex = 2;
            // 
            // txtNomeAnimal
            // 
            this.txtNomeAnimal.Enabled = false;
            this.txtNomeAnimal.Location = new System.Drawing.Point(149, 56);
            this.txtNomeAnimal.Margin = new System.Windows.Forms.Padding(2);
            this.txtNomeAnimal.Name = "txtNomeAnimal";
            this.txtNomeAnimal.Size = new System.Drawing.Size(393, 26);
            this.txtNomeAnimal.TabIndex = 1;
            // 
            // txtNomeTutor
            // 
            this.txtNomeTutor.Enabled = false;
            this.txtNomeTutor.Location = new System.Drawing.Point(149, 23);
            this.txtNomeTutor.Margin = new System.Windows.Forms.Padding(2);
            this.txtNomeTutor.Name = "txtNomeTutor";
            this.txtNomeTutor.Size = new System.Drawing.Size(393, 26);
            this.txtNomeTutor.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(202, -2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(330, 36);
            this.label4.TabIndex = 16;
            this.label4.Text = "Consultar Ocorrências";
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoltar.FlatAppearance.BorderSize = 0;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Location = new System.Drawing.Point(601, 532);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(115, 35);
            this.btnVoltar.TabIndex = 36;
            this.btnVoltar.Text = "VOLTAR";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // FrmGerenciarOcorrencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(728, 609);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvOcorrencias);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmGerenciarOcorrencias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Ocorrências";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOcorrencias)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.RadioButton rbNomeAnimal;
        private System.Windows.Forms.TextBox txtPesquisarOcorrencias;
        private System.Windows.Forms.RadioButton rbNomeTutor;
        private System.Windows.Forms.DataGridView dgvOcorrencias;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtGravidade;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProvidencia;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtNomeAnimal;
        private System.Windows.Forms.TextBox txtNomeTutor;
        private System.Windows.Forms.DateTimePicker dataOcorrencia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIdOcorrencia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIdProcesso;
        private System.Windows.Forms.RadioButton rbIdOcorrencia;
        private System.Windows.Forms.RadioButton rbIdProcesso;
        private System.Windows.Forms.Button btnVoltar;
    }
}