using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Kvics.Controls.Chart
{
    public enum LegendPosition
	{
		NONE,
		TOP,
		BOTTOM
	}

	public class Legend
	{
		protected bool _Enable;

		public bool Enable
		{
			get { return _Enable; }
			set { _Enable = value; }
		}

        protected bool _ShowBar;

        public bool ShowBar
        {
            get { return _ShowBar; }
            set { _ShowBar = value; }
        }

        protected bool _ShowUpdateBar;

        public bool ShowUpdateBar
        {
            get { return _ShowUpdateBar; }
            set { _ShowUpdateBar = value; }
        }
        protected bool _ShowLine;

        public bool ShowLine
        {
            get { return _ShowLine; }
            set { _ShowLine = value; }
        }

		protected LegendPosition _Position;

		public LegendPosition Position
		{
			get { return _Position; }
			set { _Position = value; }
		}

        protected ChartText _SampleText;

        public ChartText SampleText
        {
            get { return _SampleText; }
            set { _SampleText = value; }
        }

        protected Size _SampeSize;

        public Size SampeSize
        {
            get { return _SampeSize; }
            set { _SampeSize = value; }
        }

        protected Padding _Margin;

        public Padding Margin
        {
            get { return _Margin; }
            set { _Margin = value; }
        }

        public Legend()
        {
            _Enable = false;
            _ShowBar = false;
            _ShowUpdateBar = false;
            _ShowLine = false;
            _Position = LegendPosition.TOP;
            _SampleText = new ChartText();
            _SampeSize = new Size(20, 10);
            _Margin = new Padding(10, 3, 10, 3);
        }

	}
}
