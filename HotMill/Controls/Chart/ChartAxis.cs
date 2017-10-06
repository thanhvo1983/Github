using System.Drawing;

namespace Kvics.Controls.Chart
{
    public class ChartAxis
	{
		protected bool _Enable;

		public bool Enable
		{
			get { return _Enable; }
			set { _Enable = value; }
		}

        protected ChartText _Title;

        public ChartText Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

		protected bool _IsShowTitle;

		public bool IsShowTitle
		{
			get { return _IsShowTitle; }
			set { _IsShowTitle = value; }
		}

        protected ChartText _TextFormat;

        public ChartText TextFormat
        {
            get { return _TextFormat; }
            set { _TextFormat = value; }
        }

		protected Color _Color;

		public Color Color
		{
			get { return _Color; }
			set { _Color = value; }
		}

		protected int _Size;

		public int Size
		{
			get { return _Size; }
			set { _Size = value; }
		}

		protected int _Margin;

		public int Margin
		{
			get { return _Margin; }
			set { _Margin = value; }
		}

        protected TickMark _MajorTick;

        public TickMark MajorTick
        {
            get { return _MajorTick; }
            set { _MajorTick = value; }
        }

        protected TickMark _MinorTick;

        public TickMark MinorTick
        {
            get { return _MinorTick; }
            set { _MinorTick = value; }
        }

        protected bool _AutoPadding = true;

        public bool AutoPadding
        {
            get { return _AutoPadding; }
            set { _AutoPadding = value; }
        }

        public ChartAxis()
        {
            _Enable = true;
            _Title = new ChartText();
            _IsShowTitle = true;
            _TextFormat = new ChartText();

            _Color = Color.Lime;
            _Size = 2;
            _Margin = 2;

            _MajorTick = new TickMark();
            _MinorTick = new TickMark();
        }

        public ChartAxis(string title)
        {
            _Enable = true;
            _Title = new ChartText(title);
            _IsShowTitle = true;
            _TextFormat = new ChartText();

            _Size = 2;
            _Margin = 2;

            _MajorTick = new TickMark();
            _MinorTick = new TickMark();
        }
	}
}
