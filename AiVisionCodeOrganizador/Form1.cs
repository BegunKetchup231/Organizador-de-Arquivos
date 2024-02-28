using Ookii.Dialogs.Wpf;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
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

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Size = new Size(335, 407);

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += BackgroundWorker1_ProgressChanged;

            Button_Entrada.Image = Properties.Resources.icon_entrada;
            Button_Saida.Image = Properties.Resources.icon_saida;

            Button_Entrada.TabStop = false;
            Button_Saida.TabStop = false;
            Button_Organizar.TabStop = false;
            Button_Dev.TabStop = false;
            Button_Discord.TabStop = false;
            Button_GitHub.TabStop = false;

            Barra_De_Progresso.TabStop = false;

            Button_Entrada.Click += Botao_Fake_Click;
            Button_Saida.Click += Botao_Fake_Click;
            Button_Organizar.Click += Botao_Fake_Click;
            Button_Dev.Click += Botao_Fake_Click;
            Button_Discord.Click += Botao_Fake_Click;
            Button_GitHub.Click += Botao_Fake_Click;
        }

        private void Botao_Fake_Click(object sender, EventArgs e)
        {
            SelectNextControl((Control)sender, true, true, true, true);
        }

        private void ExibirDialogoSelecaoPasta(string folderVariable)
        {
            var dialogoPasta = new VistaFolderBrowserDialog
            {
                Description = "Selecione uma pasta",
                UseDescriptionForTitle = true
            };

            bool? resultado = dialogoPasta.ShowDialog();

            if (resultado.GetValueOrDefault())
            {
                string selectedFolder = dialogoPasta.SelectedPath;
                if (folderVariable.Equals("sourceFolder"))
                {
                    sourceFolder = selectedFolder;
                    AtualizarImagemDoBotao(Button_Entrada, selectedFolder);
                }
                else if (folderVariable.Equals("outputFolder"))
                {
                    outputFolder = selectedFolder;
                    AtualizarImagemDoBotao2(Button_Saida, selectedFolder);
                }
            }
        }

        private void AtualizarImagemDoBotao(Button botao, string selectedFolder)
        {
            if (!string.IsNullOrEmpty(selectedFolder))
            {
                Image imagemOkay = Properties.Resources.okay;
                Image imagemRedimensionada = new Bitmap(imagemOkay, new Size(40, 40));
                botao.Image = imagemRedimensionada;
            }
            else
            {
                Image imagemIconPasta = Properties.Resources.icon_entrada;
                Image imagemRedimensionada = new Bitmap(imagemIconPasta, new Size(40, 40));
                botao.Image = imagemRedimensionada;

            }
        }

        private void AtualizarImagemDoBotao2(Button botao, string selectedFolder)
        {
            if (!string.IsNullOrEmpty(selectedFolder))
            {
                Image imagemOkay = Properties.Resources.okay;
                Image imagemRedimensionada = new Bitmap(imagemOkay, new Size(40, 40));
                botao.Image = imagemRedimensionada;
            }
            else
            {
                Image imagemIconPasta = Properties.Resources.icon_saida;
                Image imagemRedimensionada = new Bitmap(imagemIconPasta, new Size(40, 40));
                botao.Image = imagemRedimensionada;

            }
        }

        private void Button_Entrada_Click(object sender, EventArgs e)
        {
            ExibirDialogoSelecaoPasta("sourceFolder");
        }

        private void Button_Saida_Click(object sender, EventArgs e)
        {
            ExibirDialogoSelecaoPasta("outputFolder");
        }


        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            OrganizeFiles(sourceFolder, outputFolder);
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Barra_De_Progresso.Value = e.ProgressPercentage;
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
            sourceFolder = "";
            outputFolder = "";
            Button_Entrada.Image = Properties.Resources.icon_entrada;
            Button_Saida.Image = Properties.Resources.icon_saida;
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
    }
}
