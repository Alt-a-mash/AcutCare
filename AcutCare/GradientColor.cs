using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcutCare
{
    public class GradientColor : Panel
    {
        public Color Color1 { get; set; }
        public Color Color3 { get; set; }
        public Color Color2 { get; set; }
        public Color Color4 { get; set; }
        protected override void OnPaint(PaintEventArgs e)
        {
            LinearGradientBrush lgb = new LinearGradientBrush(this.ClientRectangle, this.Color1, this.Color2, 90F);
            LinearGradientBrush tgb = new LinearGradientBrush(this.ClientRectangle, this.Color3, this.Color4, 180F);

            Graphics g = e.Graphics;
            g.FillRectangle(lgb, this.ClientRectangle);

            Graphics gr = e.Graphics;
            gr.FillRectangle(tgb, this.ClientRectangle);

            base.OnPaint(e);
        }
    }

    public class GradientColors : Panel
    {
        public Color Color1 { get; set; }
        public Color Color3 { get; set; }
        public Color Color2 { get; set; }
        public Color Color4 { get; set; }
        protected override void OnPaint(PaintEventArgs e)
        {
            LinearGradientBrush lgb = new LinearGradientBrush(this.ClientRectangle, this.Color1, this.Color2, 270F);
            LinearGradientBrush tgb = new LinearGradientBrush(this.ClientRectangle, this.Color3, this.Color4, 360F);

            Graphics g = e.Graphics;
            g.FillRectangle(lgb, this.ClientRectangle);

            Graphics gr = e.Graphics;
            gr.FillRectangle(tgb, this.ClientRectangle);

            base.OnPaint(e);
        }
    }
}
