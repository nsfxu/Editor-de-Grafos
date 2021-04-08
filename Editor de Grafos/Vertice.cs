using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Editor_de_Grafos
{

   [ToolboxItem(false)]
    public class Vertice : Control
    {
        private int numero; // nº do vértice
        private bool marcado; // define se o vértice está marcado ou não
        private Color cor; // cor do vértice desmarcado
        private Color corMarcado; // cor do vértice marcado
        private GrafoBase f;

        public Vertice(int num, string rot, int x, int y, GrafoBase form)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer| ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Text = rot;
            numero = num;
            marcado = false;
            cor = Color.Chocolate; // define a cor padrão 
            corMarcado = Color.GreenYellow; // define a cor do vértice marcado 
            Cursor = Cursors.Hand;
            setXY(x, y);
            Width = x;
            Height = y;
            f = form;            
        }

        public void setXY(int x, int y)
        {
            Location = new Point(x, y);
            Refresh();
        }

        public int getX()
        {
            return Location.X;
        }

         public int getY()
         {
            return Location.Y;
         }

        public void marcar()
        {
            marcado = true;
            Refresh();
        }

        public void desmarcar()
        {
            marcado = false;
            Refresh();
        }

        public bool getMarcado()
        {
            return marcado;
        }

        /* DEFINE O RÓTULO DO VÉRTICE */
        public void setRotulo(string rot)
        {
            Text = rot;
            Refresh();
        }

        /* DEFINE O NÚMERO DO VÉRTICE */
        public void setNum(int num)
        {
            numero = num;
            Refresh();
        }

        /* RETORNA O NÚMERO DO VÉRTICE */
        public int getNum()
        {
            return numero;
        }

        /* DEFINE A COR DO VÉRTICE */
        public void setCor(Color cor)
        {
            this.cor = cor;
            Refresh();
        }

        /* RETORNA A COR DO VÉRTICE */
        public Color getCor()
        {
            return cor;
        }

        /* DEFINE A COR DO VÉRTICE MARCADO */
        public void setCorMarcado(Color cor)
        {
            corMarcado = cor;
            Refresh();
        }

        /* RETORNA A COR DO VÉRTICE MARCADO */
        public Color getCorMarcado()
        {
            return corMarcado;
        }

        public string getRotulo()
        {
            return Text;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            Color cor = getMarcado() ? getCorMarcado() : getCor();
            e.Graphics.FillEllipse(new SolidBrush(cor), 0, 0, 10, 10);
            e.Graphics.DrawString(Text, new Font(Font.Name, 10, FontStyle.Regular), new SolidBrush(Color.Black),0, 12);
            float tam = e.Graphics.MeasureString(Text, new Font(Font.Name, 10, FontStyle.Regular)).Width;
            SetBounds(getX(), getY(), (int)tam, 25);
        }

        Point lastClick;
        bool drag = false; 

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            lastClick = new Point(e.X, e.Y); 
           
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if(e.Button == MouseButtons.Left) 
            {
                drag = true;    
                this.Left += e.X - lastClick.X;
                this.Top += e.Y - lastClick.Y;
                f.Refresh();
            }
        
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            drag = false;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if(!drag)
            f.clicouVertice(this);
          
        }
    }
}
