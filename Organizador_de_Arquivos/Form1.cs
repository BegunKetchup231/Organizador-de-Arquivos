using System.ComponentModel;
using System.Diagnostics;

namespace Organizador_de_Arquivos
{
    public partial class Form1 : Form
    {
        private string sourceFolder = "";
        private string outputFolder = "";
        private bool isDarkMode = false;

        public Form1()
        {
            InitializeComponent();

            // Definir o tamanho fixo da janela (não redimensionável)
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Configurar o BackgroundWorker para relatar progresso
            backgroundWorker1.WorkerReportsProgress = true;

            // Associar o evento DoWork ao manipulador de eventos backgroundWorker1_DoWork
#pragma warning disable CS8622 // A nulidade de tipos de referência no tipo de parâmetro não corresponde ao delegado de destino (possivelmente devido a atributos de nulidade).
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
#pragma warning restore CS8622 // A nulidade de tipos de referência no tipo de parâmetro não corresponde ao delegado de destino (possivelmente devido a atributos de nulidade).

            // Associar o evento btnModoEscuro_Click ao manipulador de eventos btnModoEscuro_Click
#pragma warning disable CS8622 // A nulidade de tipos de referência no tipo de parâmetro não corresponde ao delegado de destino (possivelmente devido a atributos de nulidade).
            btnModoEscuro.Click += btnModoEscuro_Click;
#pragma warning restore CS8622 // A nulidade de tipos de referência no tipo de parâmetro não corresponde ao delegado de destino (possivelmente devido a atributos de nulidade).

            // Chame o método para aplicar o modo inicial
            ApplyAppMode();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    sourceFolder = dialog.SelectedPath;
                    pictureBox2.Visible = true; // Mostra o ícone de "verificado"
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    outputFolder = dialog.SelectedPath;
                    pictureBox3.Visible = true; // Mostra o ícone de "verificado"
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string url = "https://keepo.io/begunketchup231/";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível abrir o link: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string url = "https://bento.me/zdesign";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível abrir o link: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string url = "https://streamelements.com/wellden840/tip";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível abrir o link: " + ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(sourceFolder))
            {
                MessageBox.Show("Selecione a pasta de origem (Botão 1) antes de organizar.");
                return;
            }

            if (string.IsNullOrEmpty(outputFolder))
            {
                MessageBox.Show("Selecione a pasta de saída (Botão 2) antes de organizar.");
                return;
            }

            OrganizeFiles(sourceFolder, outputFolder);

            // Reset a ProgressBar após a organização
            progressBar1.Value = 0;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false; // Esconde o ícone de "verificado"
            MessageBox.Show("Organização concluída com sucesso!", "Concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void OrganizeFiles(string sourceFolder, string outputFolder)
        {
            var files = Directory.GetFiles(sourceFolder);

            for (int i = 0; i < files.Length; i++)
            {
                var file = files[i];
                var extension = Path.GetExtension(file);

                if (string.IsNullOrEmpty(extension))
                {
                    continue; // Ignore files without extension
                }

                var destinationFolder = Path.Combine(outputFolder, "Arquivos", "Arquivos" + extension);
                Directory.CreateDirectory(destinationFolder);

                var fileName = Path.GetFileName(file);
                var destinationFile = Path.Combine(destinationFolder, fileName);

                File.Move(file, destinationFile);

                // Relatar o progresso
                int progressPercentage = (i + 1) * 100 / files.Length;
                backgroundWorker1.ReportProgress(progressPercentage);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            OrganizeFiles(sourceFolder, outputFolder);
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void btnModoEscuro_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;
            ApplyAppMode();
        }

        private void ApplyAppMode()
        {
            if (isDarkMode)
            {
                this.BackColor = System.Drawing.Color.Black;
                btnModoEscuro.Text = "Modo Claro";
                progressBar1.ForeColor = System.Drawing.Color.Green; // Ajuste de cor da barra de progresso

                label1.ForeColor = System.Drawing.Color.White;  // Ajuste de cor para o label1
                label2.ForeColor = System.Drawing.Color.White;  // Ajuste de cor para o label2
                label9.ForeColor = System.Drawing.Color.White;  // Ajuste de cor para o label9
                label5.ForeColor = System.Drawing.Color.White;  // Ajuste de cor para o label5
            }
            else
            {
                this.BackColor = System.Drawing.Color.White;
                btnModoEscuro.Text = "Modo Escuro";
                progressBar1.ForeColor = System.Drawing.Color.Green; // Ajuste de cor da barra de progresso

                label1.ForeColor = System.Drawing.Color.Indigo;  // Ajuste de cor para o label1
                label2.ForeColor = System.Drawing.Color.Indigo;  // Ajuste de cor para o label2
                label9.ForeColor = System.Drawing.Color.Indigo;  // Ajuste de cor para o label9
                label5.ForeColor = System.Drawing.Color.Indigo;  // Ajuste de cor para o label5
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnModoEscuro_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Resto do seu código
            pictureBox2.Visible = false; // Esconde o ícone de "verificado"
            pictureBox3.Visible = false;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}