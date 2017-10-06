using System.Drawing;

namespace Kvics.Controls.Chart
{
    public class ChartText
    {
        private string _Text;

        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }

        private Font _Font;

        public Font Font
        {
            get { return _Font; }
            set { _Font = value; }
        }

        private Color _Color;

        public Color Color
        {
            get { return _Color; }
            set { _Color = value; }
        }

        public ChartText()
        {
            _Text = "";
            _Font = SystemFonts.DefaultFont;            
            _Color = Color.Lime;
        }

        public ChartText(string text)
        {
            _Text = text;
            _Font = SystemFonts.DefaultFont;
            _Color = Color.Lime;
        }

        public ChartText(string text, Font font, Color color)
        {
            _Text = text;
            _Font = font;
            _Color = color;
        }
    }
}
