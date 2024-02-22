using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AiVisionCodeOrganizador
{
    public partial class Form1 : Form
    {
        private string sourceFolder = "";
        private string outputFolder = "";

        public Form1()
        {
            InitializeComponent();

            this.Size = new Size(331, 405);

            backgroundWorker1.WorkerReportsProgress = true;

            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
        }

        private void Button_Entrada_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                sourceFolder = dialog.SelectedPath;
                PictureBox_Verify1.Visible = true; // Mostra o ícone de "verificado"
            }
        }

        private void Button_Saida_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                outputFolder = dialog.SelectedPath;
                PictureBox_Verify2.Visible = true; // Mostra o ícone de "verificado"
            }

        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            OrganizeFiles(sourceFolder, outputFolder);
        }
        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;

            // Verifica se o progresso atingiu 100%
            if (e.ProgressPercentage == 100)
            {
                // Mostra a mensagem quando a organização estiver concluída
                MessageBox.Show("Organização concluída com sucesso!", "Concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset a ProgressBar após a organização
                progressBar1.Value = 0;

                // Esconde o ícone de "verificado"
                PictureBox_Verify1.Visible = false;
                PictureBox_Verify2.Visible = false;

                // Reset das pastas de entrada e saída
                sourceFolder = "";
                outputFolder = "";
            }
        }

        private void OrganizeFiles(string sourceFolder, string outputFolder)
        {
            var allFiles = Directory.GetFiles(sourceFolder, "*", SearchOption.TopDirectoryOnly)
                        .Where(file => !new FileInfo(file).Attributes.HasFlag(FileAttributes.Hidden))
                        .ToArray();

            int totalFiles = allFiles.Length;
            int processedFiles = 0;

            var arquivosFolder = Path.Combine(outputFolder, "Arquivos");
            var destinationSubfolder = Path.Combine(arquivosFolder, "Arquivos.pasta");
            Directory.CreateDirectory(destinationSubfolder);

            var folders = Directory.GetDirectories(sourceFolder)
                                  .Where(folder => !new DirectoryInfo(folder).Attributes.HasFlag(FileAttributes.Hidden));

            foreach (var folder in folders)
            {
                var folderName = new DirectoryInfo(folder).Name;

                if (folderName.Equals("Arquivos"))
                    continue;

                var destinationFolder = Path.Combine(destinationSubfolder, folderName);
                Directory.Move(folder, destinationFolder);
            }

            foreach (var file in allFiles)
            {
                var extension = Path.GetExtension(file);

                if (string.IsNullOrEmpty(extension))
                {
                    continue;
                }

                var destinationFolder = Path.Combine(arquivosFolder, "Arquivos" + extension);
                Directory.CreateDirectory(destinationFolder);

                var fileName = Path.GetFileName(file);
                var destinationFile = Path.Combine(destinationFolder, fileName);

                if (File.Exists(destinationFile))
                {
                    int suffix = 1;
                    string originalFileName = Path.GetFileNameWithoutExtension(file);
                    string newFileName = $"{originalFileName}_{suffix}{extension}";

                    while (File.Exists(Path.Combine(destinationFolder, newFileName)))
                    {
                        suffix++;
                        newFileName = $"{originalFileName}_{suffix}{extension}";
                    }

                    destinationFile = Path.Combine(destinationFolder, newFileName);
                }

                File.Move(file, destinationFile);

                processedFiles++;
                int progressPercentage = processedFiles * 100 / totalFiles;

                // Relatar o progresso pra progressbar
                backgroundWorker1.ReportProgress(progressPercentage);
            }
        }

        private void Button_Organizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(sourceFolder))
            {
                MessageBox.Show("Selecione a pasta de entrada (Botão 1) primeiro!");
                return;
            }

            if (string.IsNullOrEmpty(outputFolder))
            {
                MessageBox.Show("Selecione a pasta de saída (Botão 2) antes de organizar.");
                return;
            }

            OrganizeFiles(sourceFolder, outputFolder);

        }

        private void Botao_Dev_Click(object sender, EventArgs e)
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
                MessageBox.Show("Contate o desenvolvedor");
            }
        }

        private void Button_Dev_Click(object sender, EventArgs e)
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
                MessageBox.Show("Contate o desenvolvedor");
            }
        }

        private void Button_GitHub_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/BegunKetchup231";

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
                MessageBox.Show("Contate o desenvolvedor");
            }
        }

        private void Button_Discord_Click(object sender, EventArgs e)
        {
            var url = "https://discord.com/invite/Tq8gmMpu5C";

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
                MessageBox.Show("Contate o desenvolvedor");
            }
        }

        private void Button_Update_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/BegunKetchup231/Organizador_2";

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
                MessageBox.Show("Contate o desenvolvedor");
            }
        }

        private void Modo_Cor_Click(object sender, EventArgs e)
        {

        }
    }
}
