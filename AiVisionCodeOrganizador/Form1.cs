using Ookii.Dialogs.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Media;
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

            // Define o estilo de borda como FixedDialog
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Size = new Size(331, 405);

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;


            PictureBox_Verify1.Visible = false;
            PictureBox_Verify2.Visible = false;

            // Desativar o TabStop para todos os botões
            Button_Update.TabStop = false;
            Button_Entrada.TabStop = false;
            Button_Saida.TabStop = false;
            Button_Organizar.TabStop = false;
            Button_Dev.TabStop = false;
            Button_Discord.TabStop = false;
            Button_GitHub.TabStop = false;

            // Desativar o TabStop para a Barra_De_Progresso
            Barra_De_Progresso.TabStop = false;

            // Corrigir bug do foco dos botões
            Button_Update.Click += Botao_Fake_Click;
            Button_Entrada.Click += Botao_Fake_Click;
            Button_Saida.Click += Botao_Fake_Click;
            Button_Organizar.Click += Botao_Fake_Click;
            Button_Dev.Click += Botao_Fake_Click;
            Button_Discord.Click += Botao_Fake_Click;
            Button_GitHub.Click += Botao_Fake_Click;
        }

        private void Botao_Fake_Click(object sender, EventArgs e)
        {
            // Mover o foco para o próximo controle no formulário
            SelectNextControl((Control)sender, true, true, true, true);
        }

        private void ExibirDialogoSelecaoPasta(string folderVariable, PictureBox pictureBox)
        {
            var dialogoPasta = new VistaFolderBrowserDialog
            {
                // Configurações opcionais
                Description = "Selecione uma pasta",
                UseDescriptionForTitle = true
            };

            // Exibe o diálogo e verifica se o usuário pressionou OK
            bool? resultado = dialogoPasta.ShowDialog();

            if (resultado.GetValueOrDefault())  // Verifica se o resultado é true ou se é null (cancelado)
            {
                // Atualiza a variável de pasta correspondente
                if (folderVariable.Equals("sourceFolder"))
                {
                    sourceFolder = dialogoPasta.SelectedPath;
                }
                else if (folderVariable.Equals("outputFolder"))
                {
                    outputFolder = dialogoPasta.SelectedPath;
                }

                // Atualiza o PictureBox fornecido para torná-lo visível
                pictureBox.Visible = true;
            }
        }

        private void Button_Entrada_Click(object sender, EventArgs e)
        {
            ExibirDialogoSelecaoPasta("sourceFolder", PictureBox_Verify1);
        }


        private void Button_Saida_Click(object sender, EventArgs e)
        {
            ExibirDialogoSelecaoPasta("outputFolder", PictureBox_Verify2);
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            OrganizeFiles(sourceFolder, outputFolder);
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Barra_De_Progresso.Value = e.ProgressPercentage;

            // Verifica se o progresso atingiu 100%
            if (e.ProgressPercentage == 100)
            {
                // Mostra a mensagem quando a organização estiver concluída
                MessageBox.Show("Organização concluída com sucesso!", "Concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset a ProgressBar após a organização
                Barra_De_Progresso.Value = 0;

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

            backgroundWorker1.RunWorkerAsync();
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Organização concluída com sucesso!", "Concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Barra_De_Progresso.Value = 0;
            PictureBox_Verify1.Visible = false;
            PictureBox_Verify2.Visible = false;
            sourceFolder = "";
            outputFolder = "";
        }

        private void OpenUrlInBrowser(string url)
        {
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
                MessageBox.Show($"Não foi possível abrir o link: {ex.Message}");
                MessageBox.Show("Contate o desenvolvedor");
            }
        }

        private void Button_Dev_Click(object sender, EventArgs e)
        {
            OpenUrlInBrowser("https://keepo.io/begunketchup231/");
        }

        private void Button_GitHub_Click(object sender, EventArgs e)
        {
            OpenUrlInBrowser("https://github.com/BegunKetchup231");
        }

        private void Button_Discord_Click(object sender, EventArgs e)
        {
            OpenUrlInBrowser("https://discord.com/invite/Tq8gmMpu5C");
        }

        private void Button_Update_Click(object sender, EventArgs e)
        {
            OpenUrlInBrowser("https://github.com/BegunKetchup231/Organizador_2");
        }
    }
}
