using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Kvics.Controls
{
    public class KvicsCheckBox : CheckBox
    {
        public KvicsCheckBox()
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
                //SolidBrush blackBrush = new SolidBrush(Color.Black);
                SolidBrush foreBrush = new SolidBrush(this.ForeColor);
                SolidBrush backBrush = new SolidBrush(this.BackColor);
                Pen pen = new Pen(Color.FromArgb(28, 81, 128));

                g.FillRectangle(backBrush, pevent.ClipRectangle);

                Rectangle rec = new Rectangle();
                rec.X = 0;
                rec.Y = (int)(this.Height / 2 - textTempSize.Height / 2);
                rec.Width = rec.Height = (int)textTempSize.Height;

                g.FillRectangle(whiteBrush, rec);

                Rectangle recShape = new Rectangle();
                recShape.X = rec.X;
                recShape.Y = rec.Y;
                recShape.Width = recShape.Height = rec.Width - 1;
                g.DrawRectangle(pen, recShape);

                if (this.Checked)
                {
                    //int paddingRec = rec.Width / 4;
                    //paddingRec = paddingRec > paddingControl ? paddingRec : paddingControl;
                    //recShape.X += paddingRec;
                    //recShape.Y += paddingRec;
                    //recShape.Width = recShape.Height = rec.Width - paddingRec * 2;
                    //g.FillRectangle(new SolidBrush(Color.FromArgb(114, 192, 113)), recShape);
                    //g.FillRectangle(blackBrush, recShape);
                    Pen pen1 = new Pen(Color.Black, rec.Width / 6);
                    Point p1 = new Point();
                    p1.X = rec.X + rec.Width / 5;
                    p1.Y = rec.Y + 2 * rec.Width / 4;
                    Point p2 = new Point();
                    p2.X = rec.X + 2 * rec.Width / 5;
                    p2.Y = rec.Y + 3 * rec.Width / 4;
                    g.DrawLine(pen1, p1, p2);
                    p1.X = rec.X + 4 * rec.Width / 5;
                    p1.Y = rec.Y + rec.Width / 4;
                    g.DrawLine(pen1, p1, p2);
                    pen1.Dispose();
                }

                g.DrawString(this.Text, this.Font, foreBrush, rec.X + rec.Width + paddingControl, (int)(this.Height / 2 - textSize.Height / 2));

                whiteBrush.Dispose();
                //blackBrush.Dispose();
                foreBrush.Dispose();
                backBrush.Dispose();
                pen.Dispose();
            }
        }
    }
}
