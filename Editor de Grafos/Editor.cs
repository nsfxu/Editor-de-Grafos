using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Editor_de_Grafos
{
    public partial class Editor : Form
    {
        public Editor()
        {
            InitializeComponent(); 
        }

        #region Botoes de Algoritmo do Menu
        private void BtParesOrd_Click(object sender, EventArgs e)
        {
            MessageBox.Show(g.paresOrdenados(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtGrafoEuleriano_Click(object sender, EventArgs e)
        {
            if(g.isEuleriano())
                MessageBox.Show("O grafo é Euleriano!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("O grafo não é Euleriano!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtGrafoUnicursal_Click(object sender, EventArgs e)
        {
            if (g.isUnicursal())
                MessageBox.Show("O grafo é Unicursal!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("O grafo não é Unicursal!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtBuscaProfundidade_Click(object sender, EventArgs e)
        {
            int x;
            if (g.getVerticeMarcado() != null)
                x = g.getVerticeMarcado().getNum();
            else
            {
                MessageBox.Show("Marque um vertice para continuar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool[] visitado = new bool[g.getN()];
            g.removeFormatacao();
            g.profundidade(x, visitado);
        }

        private void btBuscaLargura_Click(object sender, EventArgs e)
        {            
            int x;
            if (g.getVerticeMarcado() != null)
                x = g.getVerticeMarcado().getNum();
            else
            {
                MessageBox.Show("Marque um vertice para continuar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            g.removeFormatacao();
            g.largura(x);            
        }

        private void btAGM_Click(object sender, EventArgs e)
        {
            int x;
            if (g.getVerticeMarcado() != null)
                x = g.getVerticeMarcado().getNum();
            else
            {
                MessageBox.Show("Marque um vertice para continuar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            g.removeFormatacao();
            MessageBox.Show("O valor do custo total é: " + g.AGM(x), "AGM", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btCaminhoMinimo_Click(object sender, EventArgs e)
        {
            int i, j;
            if (!int.TryParse(Interaction.InputBox("Digite o número do vértice de origem", "Caminho Mínimo", ""), out i))
            {
                MessageBox.Show("Digite um número!", "Caminho Mínimo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                g.getVertice(i);
            }
            catch (Exception)
            {
                MessageBox.Show("Esse vertice não existe!!", "Caminho Mínimo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                throw;
            }

            if (!int.TryParse(Interaction.InputBox("Digite o número do vértice de destino", "Caminho Mínimo", ""), out j))
            {
                MessageBox.Show("Digite um número!", "Caminho Mínimo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                g.getVertice(j);
            }
            catch (Exception)
            {
                MessageBox.Show("Esse vertice não existe!!", "Define Peso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                throw;
            }

            g.removeFormatacao();
            g.caminhoMinimo(i, j);
        }

        private void btNumCromatico_Click(object sender, EventArgs e)
        {
            g.removeFormatacao();            
            
            if (g.getN() == 0)
            {
                MessageBox.Show("Não existe grafo!!!!", "Define Peso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("O valor do número cromático é: " + g.numeroCromatico(), "Número Cromático", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        

        #endregion --------------------------------------------------------------------------------------------------

        #region botoes restantes do menu

        private void BtNovo_Click(object sender, EventArgs e)
        {
            g.limpar();
        }

        private void BtAbrir_Click(object sender, EventArgs e)
        {
            if(OPFile.ShowDialog() == DialogResult.OK)
            {
                g.abrirArquivo(OPFile.FileName);
                g.Refresh();
            }
        }

        private void BtSalvar_Click(object sender, EventArgs e)
        {
            if(SVFile.ShowDialog() == DialogResult.OK)
            {
                g.SalvarArquivo(SVFile.FileName);
            }
        }

        private void BtSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btDefineRotulo_Click(object sender, EventArgs e)
        {
            if (g.getVerticeMarcado() != null)
                g.getVerticeMarcado().setRotulo(Interaction.InputBox("Digite o nome do rótulo", "Define Rótulo", "Indefinido"));
            else
            {
                MessageBox.Show("Marque um vertice para continuar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void BtPeso_Click(object sender, EventArgs e)
        {
            if(BtPeso.Checked)
            {
                BtPeso.Checked = false;
                g.setExibirPesos(false);

            }
            else
            {
                BtPeso.Checked = true;
                g.setExibirPesos(true);
            }
            g.Refresh();
        }

        private void btDefinePeso_Click(object sender, EventArgs e)
        {
            // setAresta(int i, int j, int peso)
            // g.setAresta()
            int i, j, peso;

            if (!int.TryParse(Interaction.InputBox("Digite o número do vértice i", "Define Peso", ""), out i))
            {
                MessageBox.Show("Digite um número!", "Define Peso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                g.getVertice(i);
            }
            catch (Exception)
            {
                MessageBox.Show("Esse vertice não existe!!", "Define Peso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                throw;
            }

            if (!int.TryParse(Interaction.InputBox("Digite o número do vértice j", "Define Peso", ""), out j))
            {
                MessageBox.Show("Digite um número!", "Define Peso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                g.getVertice(j);
            }
            catch (Exception)
            {
                MessageBox.Show("Esse vertice não existe!!", "Define Peso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                throw;
            }

            if (!int.TryParse(Interaction.InputBox("Digite o peso da aresta de i, j", "Define Peso", ""), out peso))
            {
                MessageBox.Show("Digite um número!", "Define Peso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            g.setAresta(i, j, peso);
        }

        private void BtPesoAleatorio_Click(object sender, EventArgs e)
        {
            if(BtPesoAleatorio.Checked)
            {
                BtPesoAleatorio.Checked = false;
                g.setPesosAleatorios(false);
            }
            else
            {
                BtPesoAleatorio.Checked = true;
                g.setPesosAleatorios(true);
            }
        }
        private void completarGrafoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g.completarGrafo();
        }

        private void exibirNúmArestasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Divide por 2 porquê as arestas são paralelas
            int x = g.getNArestas() / 2;
            MessageBox.Show(x.ToString());
        }

        private void BtIsArvore_Click(object sender, EventArgs e)
        {
            if (g.getN() == 0)
                MessageBox.Show("Grafo inexistente", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {                
                if(g.isArvore())
                    MessageBox.Show("O grafo é uma árvore", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("O grafo não é uma árvore", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
        }

        private void btRemoveFormatacao_Click(object sender, EventArgs e)
        {
            g.removeFormatacao();
        }

        private void BtSobre_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Editor de Grafos - 2021/1\n\nDesenvolvido por: \nGiusier Ferreira Soares 72000635\nNatan Macedo de Magalhaes\nVirgilio Borges de Oliveira\n\nAlgoritmos e Estruturas de Dados II\nFaculdade COTEMIG\nSomente para fins didáticos.", "Sobre o Editor de Grafos...", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        #endregion --------------------------------------------------------------------------------------------------     

        
    }
}
