using System.Reflection;
using System.Windows.Forms;

namespace Editor_de_Grafos
{
    partial class Editor
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
            if(disposing && (components != null))
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtNovo = new System.Windows.Forms.ToolStripMenuItem();
            this.BtAbrir = new System.Windows.Forms.ToolStripMenuItem();
            this.BtSalvar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtSair = new System.Windows.Forms.ToolStripMenuItem();
            this.algoritmosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtGrafoEuleriano = new System.Windows.Forms.ToolStripMenuItem();
            this.BtGrafoUnicursal = new System.Windows.Forms.ToolStripMenuItem();
            this.BtParesOrd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BtBuscaProfundidade = new System.Windows.Forms.ToolStripMenuItem();
            this.btBuscaLargura = new System.Windows.Forms.ToolStripMenuItem();
            this.btAGM = new System.Windows.Forms.ToolStripMenuItem();
            this.btCaminhoMinimo = new System.Windows.Forms.ToolStripMenuItem();
            this.ferramentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btDefineRotulo = new System.Windows.Forms.ToolStripMenuItem();
            this.BtPeso = new System.Windows.Forms.ToolStripMenuItem();
            this.btDefinePeso = new System.Windows.Forms.ToolStripMenuItem();
            this.BtPesoAleatorio = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.completarGrafoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtIsArvore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exibirNúmArestasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btRemoveFormatacao = new System.Windows.Forms.ToolStripMenuItem();
            this.sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtSobre = new System.Windows.Forms.ToolStripMenuItem();
            this.OPFile = new System.Windows.Forms.OpenFileDialog();
            this.SVFile = new System.Windows.Forms.SaveFileDialog();
            this.g = new Editor_de_Grafos.Grafo();
            this.btNumCromatico = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.algoritmosToolStripMenuItem,
            this.ferramentasToolStripMenuItem,
            this.sToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(631, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtNovo,
            this.BtAbrir,
            this.BtSalvar,
            this.toolStripSeparator1,
            this.BtSair});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "&Arquivo";
            // 
            // BtNovo
            // 
            this.BtNovo.Name = "BtNovo";
            this.BtNovo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.BtNovo.Size = new System.Drawing.Size(180, 22);
            this.BtNovo.Text = "Novo";
            this.BtNovo.Click += new System.EventHandler(this.BtNovo_Click);
            // 
            // BtAbrir
            // 
            this.BtAbrir.Name = "BtAbrir";
            this.BtAbrir.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.BtAbrir.Size = new System.Drawing.Size(180, 22);
            this.BtAbrir.Text = "Abrir";
            this.BtAbrir.Click += new System.EventHandler(this.BtAbrir_Click);
            // 
            // BtSalvar
            // 
            this.BtSalvar.Name = "BtSalvar";
            this.BtSalvar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.BtSalvar.Size = new System.Drawing.Size(180, 22);
            this.BtSalvar.Text = "Salvar";
            this.BtSalvar.Click += new System.EventHandler(this.BtSalvar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // BtSair
            // 
            this.BtSair.Name = "BtSair";
            this.BtSair.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.BtSair.Size = new System.Drawing.Size(180, 22);
            this.BtSair.Text = "Sair";
            this.BtSair.Click += new System.EventHandler(this.BtSair_Click);
            // 
            // algoritmosToolStripMenuItem
            // 
            this.algoritmosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtGrafoEuleriano,
            this.BtGrafoUnicursal,
            this.BtParesOrd,
            this.toolStripSeparator2,
            this.BtBuscaProfundidade,
            this.btBuscaLargura,
            this.btAGM,
            this.btCaminhoMinimo,
            this.btNumCromatico});
            this.algoritmosToolStripMenuItem.Name = "algoritmosToolStripMenuItem";
            this.algoritmosToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.algoritmosToolStripMenuItem.Text = "&Algoritmos";
            // 
            // BtGrafoEuleriano
            // 
            this.BtGrafoEuleriano.Name = "BtGrafoEuleriano";
            this.BtGrafoEuleriano.Size = new System.Drawing.Size(180, 22);
            this.BtGrafoEuleriano.Text = "Grafo Euleriano";
            this.BtGrafoEuleriano.Click += new System.EventHandler(this.BtGrafoEuleriano_Click);
            // 
            // BtGrafoUnicursal
            // 
            this.BtGrafoUnicursal.Name = "BtGrafoUnicursal";
            this.BtGrafoUnicursal.Size = new System.Drawing.Size(180, 22);
            this.BtGrafoUnicursal.Text = "Grafo Unicursal";
            this.BtGrafoUnicursal.Click += new System.EventHandler(this.BtGrafoUnicursal_Click);
            // 
            // BtParesOrd
            // 
            this.BtParesOrd.Name = "BtParesOrd";
            this.BtParesOrd.Size = new System.Drawing.Size(180, 22);
            this.BtParesOrd.Text = "Pares Ordenados";
            this.BtParesOrd.Click += new System.EventHandler(this.BtParesOrd_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // BtBuscaProfundidade
            // 
            this.BtBuscaProfundidade.Name = "BtBuscaProfundidade";
            this.BtBuscaProfundidade.Size = new System.Drawing.Size(180, 22);
            this.BtBuscaProfundidade.Text = "Profundidade";
            this.BtBuscaProfundidade.Click += new System.EventHandler(this.BtBuscaProfundidade_Click);
            // 
            // btBuscaLargura
            // 
            this.btBuscaLargura.Name = "btBuscaLargura";
            this.btBuscaLargura.Size = new System.Drawing.Size(180, 22);
            this.btBuscaLargura.Text = "Largura";
            this.btBuscaLargura.Click += new System.EventHandler(this.btBuscaLargura_Click);
            // 
            // btAGM
            // 
            this.btAGM.Name = "btAGM";
            this.btAGM.Size = new System.Drawing.Size(180, 22);
            this.btAGM.Text = "AGM";
            this.btAGM.Click += new System.EventHandler(this.btAGM_Click);
            // 
            // btCaminhoMinimo
            // 
            this.btCaminhoMinimo.Name = "btCaminhoMinimo";
            this.btCaminhoMinimo.Size = new System.Drawing.Size(180, 22);
            this.btCaminhoMinimo.Text = "Caminho Mínino";
            this.btCaminhoMinimo.Click += new System.EventHandler(this.btCaminhoMinimo_Click);
            // 
            // ferramentasToolStripMenuItem
            // 
            this.ferramentasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btDefineRotulo,
            this.BtPeso,
            this.btDefinePeso,
            this.BtPesoAleatorio,
            this.toolStripSeparator3,
            this.completarGrafoToolStripMenuItem,
            this.BtIsArvore,
            this.toolStripSeparator4,
            this.exibirNúmArestasToolStripMenuItem,
            this.btRemoveFormatacao});
            this.ferramentasToolStripMenuItem.Name = "ferramentasToolStripMenuItem";
            this.ferramentasToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.ferramentasToolStripMenuItem.Tag = "";
            this.ferramentasToolStripMenuItem.Text = "&Ferramentas";
            // 
            // btDefineRotulo
            // 
            this.btDefineRotulo.Name = "btDefineRotulo";
            this.btDefineRotulo.Size = new System.Drawing.Size(228, 22);
            this.btDefineRotulo.Text = "Definir Rotulo";
            this.btDefineRotulo.Click += new System.EventHandler(this.btDefineRotulo_Click);
            // 
            // BtPeso
            // 
            this.BtPeso.Name = "BtPeso";
            this.BtPeso.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.BtPeso.Size = new System.Drawing.Size(228, 22);
            this.BtPeso.Text = "Exibir Pesos";
            this.BtPeso.Click += new System.EventHandler(this.BtPeso_Click);
            // 
            // btDefinePeso
            // 
            this.btDefinePeso.Name = "btDefinePeso";
            this.btDefinePeso.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.btDefinePeso.Size = new System.Drawing.Size(228, 22);
            this.btDefinePeso.Text = "Definir Peso";
            this.btDefinePeso.Click += new System.EventHandler(this.btDefinePeso_Click);
            // 
            // BtPesoAleatorio
            // 
            this.BtPesoAleatorio.Name = "BtPesoAleatorio";
            this.BtPesoAleatorio.Size = new System.Drawing.Size(228, 22);
            this.BtPesoAleatorio.Text = "Gerar Pesos Aleatorios";
            this.BtPesoAleatorio.Click += new System.EventHandler(this.BtPesoAleatorio_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(225, 6);
            // 
            // completarGrafoToolStripMenuItem
            // 
            this.completarGrafoToolStripMenuItem.Name = "completarGrafoToolStripMenuItem";
            this.completarGrafoToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.completarGrafoToolStripMenuItem.Text = "Completar Grafo";
            this.completarGrafoToolStripMenuItem.Click += new System.EventHandler(this.completarGrafoToolStripMenuItem_Click);
            // 
            // BtIsArvore
            // 
            this.BtIsArvore.Name = "BtIsArvore";
            this.BtIsArvore.Size = new System.Drawing.Size(228, 22);
            this.BtIsArvore.Text = "Árvore";
            this.BtIsArvore.Click += new System.EventHandler(this.BtIsArvore_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(225, 6);
            // 
            // exibirNúmArestasToolStripMenuItem
            // 
            this.exibirNúmArestasToolStripMenuItem.Name = "exibirNúmArestasToolStripMenuItem";
            this.exibirNúmArestasToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.exibirNúmArestasToolStripMenuItem.Text = "Exibir Núm. Arestas";
            this.exibirNúmArestasToolStripMenuItem.Click += new System.EventHandler(this.exibirNúmArestasToolStripMenuItem_Click);
            // 
            // btRemoveFormatacao
            // 
            this.btRemoveFormatacao.Name = "btRemoveFormatacao";
            this.btRemoveFormatacao.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.btRemoveFormatacao.Size = new System.Drawing.Size(228, 22);
            this.btRemoveFormatacao.Text = "Remover Formatação";
            this.btRemoveFormatacao.Click += new System.EventHandler(this.btRemoveFormatacao_Click);
            // 
            // sToolStripMenuItem
            // 
            this.sToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtSobre});
            this.sToolStripMenuItem.Name = "sToolStripMenuItem";
            this.sToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.sToolStripMenuItem.Text = "Ajuda";
            // 
            // BtSobre
            // 
            this.BtSobre.Name = "BtSobre";
            this.BtSobre.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.BtSobre.Size = new System.Drawing.Size(180, 22);
            this.BtSobre.Text = "Sobre";
            this.BtSobre.Click += new System.EventHandler(this.BtSobre_Click);
            // 
            // OPFile
            // 
            this.OPFile.DefaultExt = "*.grf";
            this.OPFile.Filter = "Grafo Files|*.grf";
            this.OPFile.Title = "Selecione o Arquivo do Grafo";
            // 
            // SVFile
            // 
            this.SVFile.DefaultExt = "*.grf";
            this.SVFile.Filter = "Grafo Files|*.grf";
            this.SVFile.Title = "Defina local para salvar";
            // 
            // g
            // 
            this.g.AutoScroll = true;
            this.g.Dock = System.Windows.Forms.DockStyle.Fill;
            this.g.Location = new System.Drawing.Point(0, 24);
            this.g.Name = "g";
            this.g.Size = new System.Drawing.Size(631, 401);
            this.g.TabIndex = 1;
            // 
            // btNumCromatico
            // 
            this.btNumCromatico.Name = "btNumCromatico";
            this.btNumCromatico.Size = new System.Drawing.Size(180, 22);
            this.btNumCromatico.Text = "Número Cromático";
            this.btNumCromatico.Click += new System.EventHandler(this.btNumCromatico_Click);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(631, 425);
            this.Controls.Add(this.g);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Editor";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor de Grafos - 2021/1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BtNovo;
        private System.Windows.Forms.ToolStripMenuItem BtAbrir;
        private System.Windows.Forms.ToolStripMenuItem BtSalvar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem BtSair;
        private System.Windows.Forms.ToolStripMenuItem algoritmosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ferramentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BtParesOrd;
        private System.Windows.Forms.ToolStripMenuItem BtGrafoEuleriano;
        private System.Windows.Forms.ToolStripMenuItem BtGrafoUnicursal;
        private System.Windows.Forms.ToolStripMenuItem BtPeso;
        private System.Windows.Forms.ToolStripMenuItem BtPesoAleatorio;
        private System.Windows.Forms.ToolStripMenuItem BtSobre;
        public Grafo g;
        private System.Windows.Forms.OpenFileDialog OPFile;
        private SaveFileDialog SVFile;
        private ToolStripMenuItem completarGrafoToolStripMenuItem;
        private ToolStripMenuItem exibirNúmArestasToolStripMenuItem;
        private ToolStripMenuItem BtBuscaProfundidade;
        private ToolStripMenuItem BtIsArvore;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem btBuscaLargura;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem btRemoveFormatacao;
        private ToolStripMenuItem btDefinePeso;
        private ToolStripMenuItem btDefineRotulo;
        private ToolStripMenuItem btAGM;
        private ToolStripMenuItem btCaminhoMinimo;
        private ToolStripMenuItem btNumCromatico;
    }
}

