using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Kvics.Controls
{
    /// <summary>
    /// Summary description for TransPanel.
    /// </summary>
    public class TransparentLabel : Panel
    {
        private string _Text = "";

        public TransparentLabel() : base()
        {
            _Text = this.Name;
        }

        [System.ComponentModel.Browsable(true)]
        public override string Text
        {
            get
            {
                return _Text;
            }
            set
            {
                _Text = value;
                if (this.Parent != null)
                {
                    this.Parent.Refresh();
                }
                else
                {
                    Refresh();
                }
            }
        }

        protected void TickHandler(object sender, EventArgs e)
        {
            this.InvalidateEx();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT
                return cp;
            }
        }

        protected void InvalidateEx()
        {
            if (Parent == null)
                return;

            Rectangle rc = new Rectangle(this.Location, this.Size);
            Parent.Invalidate(rc, true);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //do not allow the background to be painted 
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SizeF textSize = g.MeasureString(this._Text, this.Font);
            float top = (this.Height - textSize.Height) / 2;
            float left = (this.Width - textSize.Width) / 2;

            SolidBrush b = new SolidBrush(this.ForeColor);
            g.DrawString(this._Text, this.Font, b, left, top);
            b.Dispose();
        }
    }
}