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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGerenciarProcessoAdotivo));
            this.btnVoltar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIdProcesso = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataAdocao = new System.Windows.Forms.DateTimePicker();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomeAnimal = new System.Windows.Forms.TextBox();
            this.txtNomeTutor = new System.Windows.Forms.TextBox();
            this.dgvProcessos = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbIdAnimal = new System.Windows.Forms.RadioButton();
            this.rbIdTutor = new System.Windows.Forms.RadioButton();
            this.rbIdProcesso = new System.Windows.Forms.RadioButton();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.rbNomeAnimal = new System.Windows.Forms.RadioButton();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.rbNomeTutor = new System.Windows.Forms.RadioButton();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcessos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoltar.FlatAppearance.BorderSize = 0;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Location = new System.Drawing.Point(681, 505);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(115, 35);
            this.btnVoltar.TabIndex = 41;
            this.btnVoltar.Text = "VOLTAR";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(281, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(401, 36);
            this.label4.TabIndex = 40;
            this.label4.Text = "Consultar Processo Adotivo";
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
            this.txtIdProcesso.Size = new System.Drawing.Size(54, 26);
            this.txtIdProcesso.TabIndex = 36;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtIdProcesso);
            this.groupBox2.Controls.Add(this.dataAdocao);
            this.groupBox2.Controls.Add(this.txtTelefone);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtEndereco);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtNomeAnimal);
            this.groupBox2.Controls.Add(this.txtNomeTutor);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(90, 324);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(585, 233);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informações";
            // 
            // dataAdocao
            // 
            this.dataAdocao.CalendarFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataAdocao.Enabled = false;
            this.dataAdocao.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataAdocao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataAdocao.Location = new System.Drawing.Point(368, 87);
            this.dataAdocao.Name = "dataAdocao";
            this.dataAdocao.Size = new System.Drawing.Size(174, 26);
            this.dataAdocao.TabIndex = 35;
            // 
            // txtTelefone
            // 
            this.txtTelefone.Enabled = false;
            this.txtTelefone.Location = new System.Drawing.Point(149, 186);
            this.txtTelefone.Margin = new System.Windows.Forms.Padding(2);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(393, 26);
            this.txtTelefone.TabIndex = 13;
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
            this.label12.Location = new System.Drawing.Point(8, 186);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 20);
            this.label12.TabIndex = 23;
            this.label12.Text = "Telefone:";
            // 
            // txtEndereco
            // 
            this.txtEndereco.Enabled = false;
            this.txtEndereco.Location = new System.Drawing.Point(149, 131);
            this.txtEndereco.Margin = new System.Windows.Forms.Padding(2);
            this.txtEndereco.Multiline = true;
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(393, 42);
            this.txtEndereco.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 131);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 20);
            this.label11.TabIndex = 19;
            this.label11.Text = "Endereço:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(226, 87);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(137, 20);
            this.label10.TabIndex = 18;
            this.label10.Text = "Data da adoção:";
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
            // dgvProcessos
            // 
            this.dgvProcessos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcessos.Location = new System.Drawing.Point(90, 153);
            this.dgvProcessos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvProcessos.Name = "dgvProcessos";
            this.dgvProcessos.RowHeadersWidth = 51;
            this.dgvProcessos.RowTemplate.Height = 24;
            this.dgvProcessos.Size = new System.Drawing.Size(706, 167);
            this.dgvProcessos.TabIndex = 37;
            this.dgvProcessos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProcessos_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbIdAnimal);
            this.groupBox1.Controls.Add(this.rbIdTutor);
            this.groupBox1.Controls.Add(this.rbIdProcesso);
            this.groupBox1.Controls.Add(this.btnPesquisar);
            this.groupBox1.Controls.Add(this.lblFiltro);
            this.groupBox1.Controls.Add(this.rbNomeAnimal);
            this.groupBox1.Controls.Add(this.txtPesquisar);
            this.groupBox1.Controls.Add(this.rbNomeTutor);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(90, 56);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(705, 93);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consulta";
            // 
            // rbIdAnimal
            // 
            this.rbIdAnimal.AutoSize = true;
            this.rbIdAnimal.Location = new System.Drawing.Point(428, 58);
            this.rbIdAnimal.Margin = new System.Windows.Forms.Padding(2);
            this.rbIdAnimal.Name = "rbIdAnimal";
            this.rbIdAnimal.Size = new System.Drawing.Size(95, 24);
            this.rbIdAnimal.TabIndex = 42;
            this.rbIdAnimal.Text = "ID animal";
            this.rbIdAnimal.UseVisualStyleBackColor = true;
            // 
            // rbIdTutor
            // 
            this.rbIdTutor.AutoSize = true;
            this.rbIdTutor.Location = new System.Drawing.Point(152, 58);
            this.rbIdTutor.Margin = new System.Windows.Forms.Padding(2);
            this.rbIdTutor.Name = "rbIdTutor";
            this.rbIdTutor.Size = new System.Drawing.Size(81, 24);
            this.rbIdTutor.TabIndex = 41;
            this.rbIdTutor.Text = "ID tutor";
            this.rbIdTutor.UseVisualStyleBackColor = true;
            // 
            // rbIdProcesso
            // 
            this.rbIdProcesso.AutoSize = true;
            this.rbIdProcesso.Location = new System.Drawing.Point(551, 58);
            this.rbIdProcesso.Margin = new System.Windows.Forms.Padding(2);
            this.rbIdProcesso.Name = "rbIdProcesso";
            this.rbIdProcesso.Size = new System.Drawing.Size(114, 24);
            this.rbIdProcesso.TabIndex = 40;
            this.rbIdProcesso.Text = "ID processo";
            this.rbIdProcesso.UseVisualStyleBackColor = true;
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
            this.rbNomeAnimal.Location = new System.Drawing.Point(271, 58);
            this.rbNomeAnimal.Margin = new System.Windows.Forms.Padding(2);
            this.rbNomeAnimal.Name = "rbNomeAnimal";
            this.rbNomeAnimal.Size = new System.Drawing.Size(123, 24);
            this.rbNomeAnimal.TabIndex = 5;
            this.rbNomeAnimal.Text = "Nome animal";
            this.rbNomeAnimal.UseVisualStyleBackColor = true;
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisar.Location = new System.Drawing.Point(172, 27);
            this.txtPesquisar.Margin = new System.Windows.Forms.Padding(2);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(382, 26);
            this.txtPesquisar.TabIndex = 2;
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
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Location = new System.Drawing.Point(680, 342);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(115, 35);
            this.btnEditar.TabIndex = 42;
            this.btnEditar.Text = "EDITAR";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcluir.FlatAppearance.BorderSize = 0;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Location = new System.Drawing.Point(681, 447);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(115, 35);
            this.btnExcluir.TabIndex = 43;
            this.btnExcluir.Text = "EXCLUIR";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(680, 396);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(115, 35);
            this.btnSalvar.TabIndex = 44;
            this.btnSalvar.Text = "SALVAR";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // FrmGerenciarProcessoAdotivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 609);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvProcessos);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmGerenciarProcessoAdotivo";
            this.Text = "Consultar Processo Adotivo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmGerenciarProcessoAdotivo_FormClosing);
            this.Load += new System.EventHandler(this.FrmGerenciarProcessoAdotivo_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcessos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIdProcesso;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dataAdocao;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomeAnimal;
        private System.Windows.Forms.TextBox txtNomeTutor;
        private System.Windows.Forms.DataGridView dgvProcessos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbIdAnimal;
        private System.Windows.Forms.RadioButton rbIdTutor;
        private System.Windows.Forms.RadioButton rbIdProcesso;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.RadioButton rbNomeAnimal;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.RadioButton rbNomeTutor;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnSalvar;
    }
}