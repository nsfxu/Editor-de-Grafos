using System.Drawing;
using System.Windows.Forms;

namespace Editor_de_Grafos
{
    public class Aresta
    {
        private int peso;
        private Color cor;
        Panel ed;

        public Aresta(int peso,Color cor,Panel ed)
        {
            this.peso = peso;
            this.cor = cor;
            this.ed = ed;
        }

        /* DEFINE O PESO */
        public void setPeso(int peso)
        {
            this.peso = peso;
            ed.Refresh();
        }

        /* RETORNA O PESO */
        public int getPeso()
        {
            return this.peso;
        }

        /* DEFINE A COR DA ARESTA */
        public void setCor(Color cor)
        {
            this.cor = cor;
            ed.Refresh();
        }

        /* RETORNA A COR DA ARESTA */
        public Color getCor()
        {
            return this.cor;
        }
    }
}
