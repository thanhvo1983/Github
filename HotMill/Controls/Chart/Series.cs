namespace Kvics.Controls.Chart
{
	public class Series
	{
		protected string _Name;

		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		protected DoubleCollection _Values;

		public virtual DoubleCollection Values
		{
			get { return _Values; }
			set { _Values = value; }
		}

        public Series()
        {
            _Name = "";
            _Values = new DoubleCollection();
        }

        public Series(string name)
        {
            _Name = name;
            _Values = new DoubleCollection();
        }

        public Series(string name, DoubleCollection value)
        {
            _Name = name;
            _Values = value;
        }

	}
}
