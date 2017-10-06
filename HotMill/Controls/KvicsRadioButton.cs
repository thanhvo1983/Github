using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Kvics.Controls
{
    public class KvicsRadioButton : RadioButton
    {
        public KvicsRadioButton()
            : base()
        {
            this.AutoSize = false;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            if (this.AutoSize)
            {
                base.OnPaint(pevent);
            }
            else
            {
                Graphics g = pevent.Graphics;
                SizeF textSize = g.MeasureString(this.Text, this.Font);
                SizeF textTempSize = g.MeasureString("abcdefABCDEF", this.Font);
                textTempSize.Height = 2 * textTempSize.Height / 3;
                int paddingControl = 3;

                SolidBrush whiteBrush = new SolidBrush(Color.White);
                SolidBrush blackBrush = new SolidBrush(Color.Black);
                SolidBrush foreBrush = new SolidBrush(this.ForeColor);
                SolidBrush backBrush = new SolidBrush(this.BackColor);
                Pen pen = new Pen(Color.FromArgb(28, 81, 128));

                g.FillRectangle(backBrush, pevent.ClipRectangle);

                Rectangle rec = new Rectangle();
                rec.X = 0;
                rec.Y = (int)(this.Height / 2 - textTempSize.Height / 2);
                rec.Width = rec.Height = (int)textTempSize.Height;
                g.FillEllipse(whiteBrush, rec);
                //g.FillRectangle(new SolidBrush(Color.White), rec);

                Rectangle recShape = new Rectangle();
                recShape.X = rec.X;
                recShape.Y = rec.Y;
                recShape.Width = recShape.Height = rec.Width;
                g.DrawEllipse(pen, recShape);

                if (this.Checked)
                {
                    int paddingRec = rec.Width / 4;
                    paddingRec = paddingRec > paddingControl ? paddingRec : paddingControl;
                    recShape.X += paddingRec;
                    recShape.Y += paddingRec;
                    recShape.Width = recShape.Height = rec.Width - paddingRec * 2;
                    //g.FillEllipse(new SolidBrush(Color.FromArgb(114, 192, 113)), recShape);
                    g.FillEllipse(blackBrush, recShape);
                }

                g.DrawString(this.Text, this.Font, foreBrush, rec.X + rec.Width + paddingControl, (int)(this.Height / 2 - textSize.Height / 2));

                whiteBrush.Dispose();
                blackBrush.Dispose();
                foreBrush.Dispose();
                backBrush.Dispose();
                pen.Dispose();
            }
        }
    }
}
