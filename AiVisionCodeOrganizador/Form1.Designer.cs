namespace AiVisionCodeOrganizador
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Button_Update = new System.Windows.Forms.Button();
            this.Modo_Cor = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.Button_Dev = new System.Windows.Forms.Button();
            this.Button_GitHub = new System.Windows.Forms.Button();
            this.Button_Discord = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.Button_Entrada = new System.Windows.Forms.Button();
            this.Button_Saida = new System.Windows.Forms.Button();
            this.Button_Organizar = new System.Windows.Forms.Button();
            this.PictureBox_Verify1 = new System.Windows.Forms.PictureBox();
            this.PictureBox_Verify2 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Verify1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Verify2)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.progressBar1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(316, 366);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.Button_Update, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Modo_Cor, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(310, 45);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // Button_Update
            // 
            this.Button_Update.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Button_Update.Location = new System.Drawing.Point(3, 19);
            this.Button_Update.Name = "Button_Update";
            this.Button_Update.Size = new System.Drawing.Size(97, 23);
            this.Button_Update.TabIndex = 0;
            this.Button_Update.Text = "Atualizar app";
            this.Button_Update.UseVisualStyleBackColor = true;
            this.Button_Update.Click += new System.EventHandler(this.Button_Update_Click);
            // 
            // Modo_Cor
            // 
            this.Modo_Cor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Modo_Cor.Location = new System.Drawing.Point(209, 19);
            this.Modo_Cor.Name = "Modo_Cor";
            this.Modo_Cor.Size = new System.Drawing.Size(98, 23);
            this.Modo_Cor.TabIndex = 1;
            this.Modo_Cor.Text = "Modo Escuro";
            this.Modo_Cor.UseVisualStyleBackColor = true;
            this.Modo_Cor.Click += new System.EventHandler(this.Modo_Cor_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(3, 347);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(310, 16);
            this.progressBar1.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.Button_Dev, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.Button_GitHub, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.Button_Discord, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 296);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(310, 45);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // Button_Dev
            // 
            this.Button_Dev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_Dev.Location = new System.Drawing.Point(3, 3);
            this.Button_Dev.Name = "Button_Dev";
            this.Button_Dev.Size = new System.Drawing.Size(97, 39);
            this.Button_Dev.TabIndex = 0;
            this.Button_Dev.Text = "Dev_";
            this.Button_Dev.UseVisualStyleBackColor = true;
            this.Button_Dev.Click += new System.EventHandler(this.Button_Dev_Click);
            // 
            // Button_GitHub
            // 
            this.Button_GitHub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_GitHub.Location = new System.Drawing.Point(106, 3);
            this.Button_GitHub.Name = "Button_GitHub";
            this.Button_GitHub.Size = new System.Drawing.Size(97, 39);
            this.Button_GitHub.TabIndex = 1;
            this.Button_GitHub.Text = "GitHub";
            this.Button_GitHub.UseVisualStyleBackColor = true;
            this.Button_GitHub.Click += new System.EventHandler(this.Button_GitHub_Click);
            // 
            // Button_Discord
            // 
            this.Button_Discord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_Discord.Location = new System.Drawing.Point(209, 3);
            this.Button_Discord.Name = "Button_Discord";
            this.Button_Discord.Size = new System.Drawing.Size(98, 39);
            this.Button_Discord.TabIndex = 2;
            this.Button_Discord.Text = "Discord";
            this.Button_Discord.UseVisualStyleBackColor = true;
            this.Button_Discord.Click += new System.EventHandler(this.Button_Discord_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Controls.Add(this.Button_Entrada, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.Button_Saida, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.Button_Organizar, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.PictureBox_Verify1, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.PictureBox_Verify2, 2, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 54);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(310, 236);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // Button_Entrada
            // 
            this.Button_Entrada.Dock = System.Windows.Forms.DockStyle.Top;
            this.Button_Entrada.Location = new System.Drawing.Point(106, 3);
            this.Button_Entrada.Name = "Button_Entrada";
            this.Button_Entrada.Size = new System.Drawing.Size(97, 50);
            this.Button_Entrada.TabIndex = 0;
            this.Button_Entrada.Text = "Pasta_Entrada";
            this.Button_Entrada.UseVisualStyleBackColor = true;
            this.Button_Entrada.Click += new System.EventHandler(this.Button_Entrada_Click);
            // 
            // Button_Saida
            // 
            this.Button_Saida.Dock = System.Windows.Forms.DockStyle.Top;
            this.Button_Saida.Location = new System.Drawing.Point(106, 81);
            this.Button_Saida.Name = "Button_Saida";
            this.Button_Saida.Size = new System.Drawing.Size(97, 50);
            this.Button_Saida.TabIndex = 1;
            this.Button_Saida.Text = "Pasta_Saida";
            this.Button_Saida.UseVisualStyleBackColor = true;
            this.Button_Saida.Click += new System.EventHandler(this.Button_Saida_Click);
            // 
            // Button_Organizar
            // 
            this.Button_Organizar.Dock = System.Windows.Forms.DockStyle.Top;
            this.Button_Organizar.Location = new System.Drawing.Point(106, 159);
            this.Button_Organizar.Name = "Button_Organizar";
            this.Button_Organizar.Size = new System.Drawing.Size(97, 50);
            this.Button_Organizar.TabIndex = 2;
            this.Button_Organizar.Text = "Button_Organizar";
            this.Button_Organizar.UseVisualStyleBackColor = true;
            this.Button_Organizar.Click += new System.EventHandler(this.Button_Organizar_Click);
            // 
            // PictureBox_Verify1
            // 
            this.PictureBox_Verify1.Location = new System.Drawing.Point(209, 3);
            this.PictureBox_Verify1.Name = "PictureBox_Verify1";
            this.PictureBox_Verify1.Size = new System.Drawing.Size(50, 50);
            this.PictureBox_Verify1.TabIndex = 3;
            this.PictureBox_Verify1.TabStop = false;
            // 
            // PictureBox_Verify2
            // 
            this.PictureBox_Verify2.Location = new System.Drawing.Point(209, 81);
            this.PictureBox_Verify2.Name = "PictureBox_Verify2";
            this.PictureBox_Verify2.Size = new System.Drawing.Size(50, 50);
            this.PictureBox_Verify2.TabIndex = 4;
            this.PictureBox_Verify2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 366);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Verify1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Verify2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button Button_Update;
        private System.Windows.Forms.Button Modo_Cor;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button Button_Dev;
        private System.Windows.Forms.Button Button_GitHub;
        private System.Windows.Forms.Button Button_Discord;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button Button_Entrada;
        private System.Windows.Forms.Button Button_Saida;
        private System.Windows.Forms.Button Button_Organizar;
        private System.Windows.Forms.PictureBox PictureBox_Verify1;
        private System.Windows.Forms.PictureBox PictureBox_Verify2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

