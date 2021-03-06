using System;
using System.Data;
using Kvics.DBAccess;
using log4net;

namespace Kvics.HotMill.BL
{
	/// <summary>
	/// Summary description for T800.
	/// </summary>
    public class T800 : BaseBL
	{
        #region Static
        private static readonly ILog log = Kvics.DBAccess.Log.Instance.GetLogger(typeof(T800));

        public static readonly string   TABLE_NAME = "T800_仕上設定計算情報";
        public static readonly string   TRANSACTION_CODE = "00020001";
		public static readonly string	ID__COLUMN_NAME = "ID";
        public static readonly string R025__COLUMN_NAME = "R025_コイルＮｏ";
        public static readonly string R033__COLUMN_NAME = "R033_圧延日_年";
        public static readonly string R035__COLUMN_NAME = "R035_圧延日_月";
        public static readonly string R037__COLUMN_NAME = "R037_圧延日_日";
        public static readonly string R039__COLUMN_NAME = "R039_勤";
        public static readonly string R041__COLUMN_NAME = "R041_班";
        public static readonly string R043__COLUMN_NAME = "R043_圧延順";
        public static readonly string R043_1__COLUMN_NAME = "R043_スラブ番号";
        public static readonly string R053__COLUMN_NAME = "R053_圧延指令番号";
        public static readonly string R059__COLUMN_NAME = "R059_圧下位置差テーブル層別区分_板厚区分";
        public static readonly string R061__COLUMN_NAME = "R061_圧下位置差テーブル層別区分_板幅区分";
        public static readonly string R063__COLUMN_NAME = "R063_圧下位置差テーブル層別区分_強度区分";
        public static readonly string R065__COLUMN_NAME = "R065_同期スタンド";
        public static readonly string R067__COLUMN_NAME = "R067_材料判別コード";
        public static readonly string R069__COLUMN_NAME = "R069_Ｎｉ鋼フラグ";
        public static readonly string R073__COLUMN_NAME = "R073_鋼種名";
        public static readonly string R081__COLUMN_NAME = "R081_熱間強度";
        public static readonly string R071__COLUMN_NAME = "R071_仕上温度_ＦＤＴ";
        public static readonly string R073_1__COLUMN_NAME = "R073_粗出側温度_Ｒ５ＤＴ_上面";
        public static readonly string R075__COLUMN_NAME = "R075_Ｒ５ＤＴ平均温度";
        public static readonly string R077__COLUMN_NAME = "R077_仕上入側温度_ＦＥＴ";
        public static readonly string R079__COLUMN_NAME = "R079_ＦＳＢ入側温度";
        public static readonly string R081_1__COLUMN_NAME = "R081_ＦＳＢ出側温度";
        public static readonly string R111__COLUMN_NAME = "R111_ＥＨ使用フラグ";
        public static readonly string R113__COLUMN_NAME = "R113_ＲＢ幅";
        public static readonly string R115__COLUMN_NAME = "R115_ＲＢ厚";
        public static readonly string R117__COLUMN_NAME = "R117_ＨＣ幅";
        public static readonly string R119__COLUMN_NAME = "R119_ＨＣ厚";
        public static readonly string R163__COLUMN_NAME = "R163_通板速度";
        public static readonly string R701_1__COLUMN_NAME = "R701_ＨＣ目標クラウン";
		public static readonly string	LASTUPDATE__COLUMN_NAME = "LastUpdate";
		#endregion
        
		#region Protected	
		protected int	_ID;
		protected string	_R025;
		protected Int16	_R033;
		protected Int16	_R035;
		protected Int16	_R037;
		protected Int16	_R039;
		protected string	_R041;
        protected Int16 _R043;
		protected string	_R043_1;
		protected string	_R053;
		protected Int16	_R059;
		protected Int16	_R061;
		protected Int16	_R063;
		protected Int16	_R065;
		protected Int16	_R067;
		protected Int16	_R069;
        protected string _R073;
        protected Int16 _R081;
		protected Int16	_R071;
		protected Int16	_R073_1;
		protected Int16	_R075;
		protected Int16	_R077;
		protected Int16	_R079;
		protected Int16	_R081_1;
		protected Int16	_R111;
		protected Int16	_R113;
		protected Int16	_R115;
		protected Int16	_R117;
		protected Int16	_R119;
		protected Int16	_R163;
        protected Int16 _R701_1;
		protected DateTime	_LastUpdate;
        protected T_R_RowSet[] _RowsChild = new T_R_RowSet[T800_Mapping.RowsName.Length];
		#endregion
        
		#region Property	
		public int ID
		{
			get
			{
				return _ID;
			}
			set
			{
				_ID = value;
			}
		}

		public string R025
		{
			get
			{
				return _R025;
			}
			set
			{
				_R025 = Common.GetString(value, 0, 8, ' ', 2);
			}
		}

		public Int16 R033
		{
			get
			{
				return _R033;
			}
			set
			{
				_R033 = value;
			}
		}

		public Int16 R035
		{
			get
			{
				return _R035;
			}
			set
			{
				_R035 = value;
			}
		}

		public Int16 R037
		{
			get
			{
				return _R037;
			}
			set
			{
				_R037 = value;
			}
		}

		public Int16 R039
		{
			get
			{
				return _R039;
			}
			set
			{
				_R039 = value;
			}
		}

		public string R041
		{
			get
			{
				return _R041;
			}
			set
			{
				_R041 = value;
			}
		}
        
        public Int16 R043
        {
            get
            {
                return _R043;
            }
            set
            {
                _R043 = value;
            }
        }
        
		public string R043_1
		{
			get
			{
				return _R043_1;
			}
			set
			{
				_R043_1 = Common.GetString(value, 0, 10, ' ', 2);
			}
		}

		public string R053
		{
			get
			{
				return _R053;
			}
			set
			{
                _R053 = Common.GetString(value, 0, 6, ' ', 2);
			}
		}

		public Int16 R059
		{
			get
			{
				return _R059;
			}
			set
			{
				_R059 = value;
			}
		}

		public Int16 R061
		{
			get
			{
				return _R061;
			}
			set
			{
				_R061 = value;
			}
		}

		public Int16 R063
		{
			get
			{
				return _R063;
			}
			set
			{
				_R063 = value;
			}
		}

		public Int16 R065
		{
			get
			{
				return _R065;
			}
			set
			{
				_R065 = value;
			}
		}

		public Int16 R067
		{
			get
			{
				return _R067;
			}
			set
			{
				_R067 = value;
			}
		}

		public Int16 R069
		{
			get
			{
				return _R069;
			}
			set
			{
				_R069 = value;
			}
		}

        public string R073
        {
            get
            {
                return _R073;
            }
            set
            {
                _R073 = Common.GetString(value, 0, 8, ' ', 2);
            }
        }
        
        public Int16 R081
        {
            get
            {
                return _R081;
            }
            set
            {
                _R081 = value;
            }
        }
        
		public Int16 R071
		{
			get
			{
				return _R071;
			}
			set
			{
				_R071 = value;
			}
		}

		public Int16 R073_1
		{
			get
			{
				return _R073_1;
			}
			set
			{
				_R073_1 = value;
			}
		}

		public Int16 R075
		{
			get
			{
				return _R075;
			}
			set
			{
				_R075 = value;
			}
		}

		public Int16 R077
		{
			get
			{
				return _R077;
			}
			set
			{
				_R077 = value;
			}
		}

		public Int16 R079
		{
			get
			{
				return _R079;
			}
			set
			{
				_R079 = value;
			}
		}

		public Int16 R081_1
		{
			get
			{
				return _R081_1;
			}
			set
			{
				_R081_1 = value;
			}
		}

		public Int16 R111
		{
			get
			{
				return _R111;
			}
			set
			{
				_R111 = value;
			}
		}

		public Int16 R113
		{
			get
			{
				return _R113;
			}
			set
			{
				_R113 = value;
			}
		}

		public Int16 R115
		{
			get
			{
				return _R115;
			}
			set
			{
				_R115 = value;
			}
		}

		public Int16 R117
		{
			get
			{
				return _R117;
			}
			set
			{
				_R117 = value;
			}
		}

		public Int16 R119
		{
			get
			{
				return _R119;
			}
			set
			{
				_R119 = value;
			}
		}

		public Int16 R163
		{
			get
			{
				return _R163;
			}
			set
			{
				_R163 = value;
			}
		}

        public Int16 R701_1
        {
            get
            {
                return _R701_1;
            }
            set
            {
                _R701_1 = value;
            }
        }

		public DateTime LastUpdate
		{
			get
			{
				return _LastUpdate;
			}
			set
			{
				_LastUpdate = value;
			}
		}

        

        public T800_I2_07 R083
        {
            get
            {
                if (!_RowsChild[0].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[0].Row = null;
                    }
                    else
                    {
                        R083 = new T800_I2_07(_ID, T800_Mapping.GetRowID(T800_Mapping.R083));
                    }
                }
                return (T800_I2_07)_RowsChild[0].Row;
            }
            set
            {
                _RowsChild[0].Row = value;
                if (value != null)
                {
                    _RowsChild[0].Row.ParentID = _ID;
                    _RowsChild[0].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R083);
                }
                _RowsChild[0].R_Set = true;
            }
        }

        public T800_I2_07 R097
        {
            get
            {
                if (!_RowsChild[1].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[1].Row = null;
                    }
                    else
                    {
                        R097 = new T800_I2_07(_ID, T800_Mapping.GetRowID(T800_Mapping.R097));
                    }
                }
                return (T800_I2_07)_RowsChild[1].Row;
            }
            set
            {
                _RowsChild[1].Row = value;
                if (value != null)
                {
                    _RowsChild[1].Row.ParentID = _ID;
                    _RowsChild[1].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R097);
                }
                _RowsChild[1].R_Set = true;
            }
        }

        public T800_I2_07 R121
        {
            get
            {
                if (!_RowsChild[2].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[2].Row = null;
                    }
                    else
                    {
                        R121 = new T800_I2_07(_ID, T800_Mapping.GetRowID(T800_Mapping.R121));
                    }
                }
                return (T800_I2_07)_RowsChild[2].Row;
            }
            set
            {
                _RowsChild[2].Row = value;
                if (value != null)
                {
                    _RowsChild[2].Row.ParentID = _ID;
                    _RowsChild[2].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R121);
                }
                _RowsChild[2].R_Set = true;
            }
        }

        public T800_I2_07 R135
        {
            get
            {
                if (!_RowsChild[3].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[3].Row = null;
                    }
                    else
                    {
                        R135 = new T800_I2_07(_ID, T800_Mapping.GetRowID(T800_Mapping.R135));
                    }
                }
                return (T800_I2_07)_RowsChild[3].Row;
            }
            set
            {
                _RowsChild[3].Row = value;
                if (value != null)
                {
                    _RowsChild[3].Row.ParentID = _ID;
                    _RowsChild[3].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R135);
                }
                _RowsChild[3].R_Set = true;
            }
        }

        public T800_I2_07 R149
        {
            get
            {
                if (!_RowsChild[4].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[4].Row = null;
                    }
                    else
                    {
                        R149 = new T800_I2_07(_ID, T800_Mapping.GetRowID(T800_Mapping.R149));
                    }
                }
                return (T800_I2_07)_RowsChild[4].Row;
            }
            set
            {
                _RowsChild[4].Row = value;
                if (value != null)
                {
                    _RowsChild[4].Row.ParentID = _ID;
                    _RowsChild[4].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R149);
                }
                _RowsChild[4].R_Set = true;
            }
        }

        public T800_I2_07 R165
        {
            get
            {
                if (!_RowsChild[5].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[5].Row = null;
                    }
                    else
                    {
                        R165 = new T800_I2_07(_ID, T800_Mapping.GetRowID(T800_Mapping.R165));
                    }
                }
                return (T800_I2_07)_RowsChild[5].Row;
            }
            set
            {
                _RowsChild[5].Row = value;
                if (value != null)
                {
                    _RowsChild[5].Row.ParentID = _ID;
                    _RowsChild[5].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R165);
                }
                _RowsChild[5].R_Set = true;
            }
        }

        public T800_I2_07 R179
        {
            get
            {
                if (!_RowsChild[6].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[6].Row = null;
                    }
                    else
                    {
                        R179 = new T800_I2_07(_ID, T800_Mapping.GetRowID(T800_Mapping.R179));
                    }
                }
                return (T800_I2_07)_RowsChild[6].Row;
            }
            set
            {
                _RowsChild[6].Row = value;
                if (value != null)
                {
                    _RowsChild[6].Row.ParentID = _ID;
                    _RowsChild[6].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R179);
                }
                _RowsChild[6].R_Set = true;
            }
        }

        public T800_I2_07 R193
        {
            get
            {
                if (!_RowsChild[7].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[7].Row = null;
                    }
                    else
                    {
                        R193 = new T800_I2_07(_ID, T800_Mapping.GetRowID(T800_Mapping.R193));
                    }
                }
                return (T800_I2_07)_RowsChild[7].Row;
            }
            set
            {
                _RowsChild[7].Row = value;
                if (value != null)
                {
                    _RowsChild[7].Row.ParentID = _ID;
                    _RowsChild[7].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R193);
                }
                _RowsChild[7].R_Set = true;
            }
        }

        public T800_I2_07 R207
        {
            get
            {
                if (!_RowsChild[8].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[8].Row = null;
                    }
                    else
                    {
                        R207 = new T800_I2_07(_ID, T800_Mapping.GetRowID(T800_Mapping.R207));
                    }
                }
                return (T800_I2_07)_RowsChild[8].Row;
            }
            set
            {
                _RowsChild[8].Row = value;
                if (value != null)
                {
                    _RowsChild[8].Row.ParentID = _ID;
                    _RowsChild[8].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R207);
                }
                _RowsChild[8].R_Set = true;
            }
        }

        public T800_I2_07 R221
        {
            get
            {
                if (!_RowsChild[9].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[9].Row = null;
                    }
                    else
                    {
                        R221 = new T800_I2_07(_ID, T800_Mapping.GetRowID(T800_Mapping.R221));
                    }
                }
                return (T800_I2_07)_RowsChild[9].Row;
            }
            set
            {
                _RowsChild[9].Row = value;
                if (value != null)
                {
                    _RowsChild[9].Row.ParentID = _ID;
                    _RowsChild[9].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R221);
                }
                _RowsChild[9].R_Set = true;
            }
        }

        public T800_I2_07 R235
        {
            get
            {
                if (!_RowsChild[10].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[10].Row = null;
                    }
                    else
                    {
                        R235 = new T800_I2_07(_ID, T800_Mapping.GetRowID(T800_Mapping.R235));
                    }
                }
                return (T800_I2_07)_RowsChild[10].Row;
            }
            set
            {
                _RowsChild[10].Row = value;
                if (value != null)
                {
                    _RowsChild[10].Row.ParentID = _ID;
                    _RowsChild[10].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R235);
                }
                _RowsChild[10].R_Set = true;
            }
        }

        public T800_I2_07 R249
        {
            get
            {
                if (!_RowsChild[11].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[11].Row = null;
                    }
                    else
                    {
                        R249 = new T800_I2_07(_ID, T800_Mapping.GetRowID(T800_Mapping.R249));
                    }
                }
                return (T800_I2_07)_RowsChild[11].Row;
            }
            set
            {
                _RowsChild[11].Row = value;
                if (value != null)
                {
                    _RowsChild[11].Row.ParentID = _ID;
                    _RowsChild[11].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R249);
                }
                _RowsChild[11].R_Set = true;
            }
        }

        public T800_I2_07 R263
        {
            get
            {
                if (!_RowsChild[12].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[12].Row = null;
                    }
                    else
                    {
                        R263 = new T800_I2_07(_ID, T800_Mapping.GetRowID(T800_Mapping.R263));
                    }
                }
                return (T800_I2_07)_RowsChild[12].Row;
            }
            set
            {
                _RowsChild[12].Row = value;
                if (value != null)
                {
                    _RowsChild[12].Row.ParentID = _ID;
                    _RowsChild[12].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R263);
                }
                _RowsChild[12].R_Set = true;
            }
        }

        public T800_I2_07 R277
        {
            get
            {
                if (!_RowsChild[13].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[13].Row = null;
                    }
                    else
                    {
                        R277 = new T800_I2_07(_ID, T800_Mapping.GetRowID(T800_Mapping.R277));
                    }
                }
                return (T800_I2_07)_RowsChild[13].Row;
            }
            set
            {
                _RowsChild[13].Row = value;
                if (value != null)
                {
                    _RowsChild[13].Row.ParentID = _ID;
                    _RowsChild[13].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R277);
                }
                _RowsChild[13].R_Set = true;
            }
        }

        public T800_I2_07 R291
        {
            get
            {
                if (!_RowsChild[14].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[14].Row = null;
                    }
                    else
                    {
                        R291 = new T800_I2_07(_ID, T800_Mapping.GetRowID(T800_Mapping.R291));
                    }
                }
                return (T800_I2_07)_RowsChild[14].Row;
            }
            set
            {
                _RowsChild[14].Row = value;
                if (value != null)
                {
                    _RowsChild[14].Row.ParentID = _ID;
                    _RowsChild[14].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R291);
                }
                _RowsChild[14].R_Set = true;
            }
        }

        public T800_I2_07 R305
        {
            get
            {
                if (!_RowsChild[15].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[15].Row = null;
                    }
                    else
                    {
                        R305 = new T800_I2_07(_ID, T800_Mapping.GetRowID(T800_Mapping.R305));
                    }
                }
                return (T800_I2_07)_RowsChild[15].Row;
            }
            set
            {
                _RowsChild[15].Row = value;
                if (value != null)
                {
                    _RowsChild[15].Row.ParentID = _ID;
                    _RowsChild[15].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R305);
                }
                _RowsChild[15].R_Set = true;
            }
        }

        public T800_I2_06 R319
        {
            get
            {
                if (!_RowsChild[16].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[16].Row = null;
                    }
                    else
                    {
                        R319 = new T800_I2_06(_ID, T800_Mapping.GetRowID(T800_Mapping.R319));
                    }
                }
                return (T800_I2_06)_RowsChild[16].Row;
            }
            set
            {
                _RowsChild[16].Row = value;
                if (value != null)
                {
                    _RowsChild[16].Row.ParentID = _ID;
                    _RowsChild[16].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R319);
                }
                _RowsChild[16].R_Set = true;
            }
        }

        public T800_I2_06 R331
        {
            get
            {
                if (!_RowsChild[17].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[17].Row = null;
                    }
                    else
                    {
                        R331 = new T800_I2_06(_ID, T800_Mapping.GetRowID(T800_Mapping.R331));
                    }
                }
                return (T800_I2_06)_RowsChild[17].Row;
            }
            set
            {
                _RowsChild[17].Row = value;
                if (value != null)
                {
                    _RowsChild[17].Row.ParentID = _ID;
                    _RowsChild[17].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R331);
                }
                _RowsChild[17].R_Set = true;
            }
        }

        public T800_I2_07 R343
        {
            get
            {
                if (!_RowsChild[18].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[18].Row = null;
                    }
                    else
                    {
                        R343 = new T800_I2_07(_ID, T800_Mapping.GetRowID(T800_Mapping.R343));
                    }
                }
                return (T800_I2_07)_RowsChild[18].Row;
            }
            set
            {
                _RowsChild[18].Row = value;
                if (value != null)
                {
                    _RowsChild[18].Row.ParentID = _ID;
                    _RowsChild[18].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R343);
                }
                _RowsChild[18].R_Set = true;
            }
        }

        public T800_I2_07 R357
        {
            get
            {
                if (!_RowsChild[19].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[19].Row = null;
                    }
                    else
                    {
                        R357 = new T800_I2_07(_ID, T800_Mapping.GetRowID(T800_Mapping.R357));
                    }
                }
                return (T800_I2_07)_RowsChild[19].Row;
            }
            set
            {
                _RowsChild[19].Row = value;
                if (value != null)
                {
                    _RowsChild[19].Row.ParentID = _ID;
                    _RowsChild[19].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R357);
                }
                _RowsChild[19].R_Set = true;
            }
        }

        public T800_I2_07 R371
        {
            get
            {
                if (!_RowsChild[20].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[20].Row = null;
                    }
                    else
                    {
                        R371 = new T800_I2_07(_ID, T800_Mapping.GetRowID(T800_Mapping.R371));
                    }
                }
                return (T800_I2_07)_RowsChild[20].Row;
            }
            set
            {
                _RowsChild[20].Row = value;
                if (value != null)
                {
                    _RowsChild[20].Row.ParentID = _ID;
                    _RowsChild[20].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R371);
                }
                _RowsChild[20].R_Set = true;
            }
        }

        public T800_I2_07 R385
        {
            get
            {
                if (!_RowsChild[21].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[21].Row = null;
                    }
                    else
                    {
                        R385 = new T800_I2_07(_ID, T800_Mapping.GetRowID(T800_Mapping.R385));
                    }
                }
                return (T800_I2_07)_RowsChild[21].Row;
            }
            set
            {
                _RowsChild[21].Row = value;
                if (value != null)
                {
                    _RowsChild[21].Row.ParentID = _ID;
                    _RowsChild[21].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R385);
                }
                _RowsChild[21].R_Set = true;
            }
        }

        public T800_I2_07 R399
        {
            get
            {
                if (!_RowsChild[22].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[22].Row = null;
                    }
                    else
                    {
                        R399 = new T800_I2_07(_ID, T800_Mapping.GetRowID(T800_Mapping.R399));
                    }
                }
                return (T800_I2_07)_RowsChild[22].Row;
            }
            set
            {
                _RowsChild[22].Row = value;
                if (value != null)
                {
                    _RowsChild[22].Row.ParentID = _ID;
                    _RowsChild[22].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R399);
                }
                _RowsChild[22].R_Set = true;
            }
        }

        public T800_I2_07 R413
        {
            get
            {
                if (!_RowsChild[23].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[23].Row = null;
                    }
                    else
                    {
                        R413 = new T800_I2_07(_ID, T800_Mapping.GetRowID(T800_Mapping.R413));
                    }
                }
                return (T800_I2_07)_RowsChild[23].Row;
            }
            set
            {
                _RowsChild[23].Row = value;
                if (value != null)
                {
                    _RowsChild[23].Row.ParentID = _ID;
                    _RowsChild[23].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R413);
                }
                _RowsChild[23].R_Set = true;
            }
        }

        public T800_I2_06 R427
        {
            get
            {
                if (!_RowsChild[24].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[24].Row = null;
                    }
                    else
                    {
                        R427 = new T800_I2_06(_ID, T800_Mapping.GetRowID(T800_Mapping.R427));
                    }
                }
                return (T800_I2_06)_RowsChild[24].Row;
            }
            set
            {
                _RowsChild[24].Row = value;
                if (value != null)
                {
                    _RowsChild[24].Row.ParentID = _ID;
                    _RowsChild[24].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R427);
                }
                _RowsChild[24].R_Set = true;
            }
        }

        public T800_I2_10 R501
        {
            get
            {
                if (!_RowsChild[25].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[25].Row = null;
                    }
                    else
                    {
                        R501 = new T800_I2_10(_ID, T800_Mapping.GetRowID(T800_Mapping.R501));
                    }
                }
                return (T800_I2_10)_RowsChild[25].Row;
            }
            set
            {
                _RowsChild[25].Row = value;
                if (value != null)
                {
                    _RowsChild[25].Row.ParentID = _ID;
                    _RowsChild[25].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R501);
                }
                _RowsChild[25].R_Set = true;
            }
        }

        public T800_I2_10 R521
        {
            get
            {
                if (!_RowsChild[26].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[26].Row = null;
                    }
                    else
                    {
                        R521 = new T800_I2_10(_ID, T800_Mapping.GetRowID(T800_Mapping.R521));
                    }
                }
                return (T800_I2_10)_RowsChild[26].Row;
            }
            set
            {
                _RowsChild[26].Row = value;
                if (value != null)
                {
                    _RowsChild[26].Row.ParentID = _ID;
                    _RowsChild[26].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R521);
                }
                _RowsChild[26].R_Set = true;
            }
        }

        public T800_I2_10 R541
        {
            get
            {
                if (!_RowsChild[27].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[27].Row = null;
                    }
                    else
                    {
                        R541 = new T800_I2_10(_ID, T800_Mapping.GetRowID(T800_Mapping.R541));
                    }
                }
                return (T800_I2_10)_RowsChild[27].Row;
            }
            set
            {
                _RowsChild[27].Row = value;
                if (value != null)
                {
                    _RowsChild[27].Row.ParentID = _ID;
                    _RowsChild[27].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R541);
                }
                _RowsChild[27].R_Set = true;
            }
        }

        public T800_I2_07_10 R561
        {
            get
            {
                if (!_RowsChild[28].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[28].Row = null;
                    }
                    else
                    {
                        R561 = new T800_I2_07_10(_ID, T800_Mapping.GetRowID(T800_Mapping.R561));
                    }
                }
                return (T800_I2_07_10)_RowsChild[28].Row;
            }
            set
            {
                _RowsChild[28].Row = value;
                if (value != null)
                {
                    _RowsChild[28].Row.ParentID = _ID;
                    _RowsChild[28].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R561);
                }
                _RowsChild[28].R_Set = true;
            }
        }

        public T800_I2_07_10 R575
        {
            get
            {
                if (!_RowsChild[29].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[29].Row = null;
                    }
                    else
                    {
                        R575 = new T800_I2_07_10(_ID, T800_Mapping.GetRowID(T800_Mapping.R575));
                    }
                }
                return (T800_I2_07_10)_RowsChild[29].Row;
            }
            set
            {
                _RowsChild[29].Row = value;
                if (value != null)
                {
                    _RowsChild[29].Row.ParentID = _ID;
                    _RowsChild[29].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R575);
                }
                _RowsChild[29].R_Set = true;
            }
        }

        public T800_I2_07_10 R589
        {
            get
            {
                if (!_RowsChild[30].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[30].Row = null;
                    }
                    else
                    {
                        R589 = new T800_I2_07_10(_ID, T800_Mapping.GetRowID(T800_Mapping.R589));
                    }
                }
                return (T800_I2_07_10)_RowsChild[30].Row;
            }
            set
            {
                _RowsChild[30].Row = value;
                if (value != null)
                {
                    _RowsChild[30].Row.ParentID = _ID;
                    _RowsChild[30].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R589);
                }
                _RowsChild[30].R_Set = true;
            }
        }

        public T800_I2_07_10 R603
        {
            get
            {
                if (!_RowsChild[31].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[31].Row = null;
                    }
                    else
                    {
                        R603 = new T800_I2_07_10(_ID, T800_Mapping.GetRowID(T800_Mapping.R603));
                    }
                }
                return (T800_I2_07_10)_RowsChild[31].Row;
            }
            set
            {
                _RowsChild[31].Row = value;
                if (value != null)
                {
                    _RowsChild[31].Row.ParentID = _ID;
                    _RowsChild[31].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R603);
                }
                _RowsChild[31].R_Set = true;
            }
        }

        public T800_I2_07_10 R617
        {
            get
            {
                if (!_RowsChild[32].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[32].Row = null;
                    }
                    else
                    {
                        R617 = new T800_I2_07_10(_ID, T800_Mapping.GetRowID(T800_Mapping.R617));
                    }
                }
                return (T800_I2_07_10)_RowsChild[32].Row;
            }
            set
            {
                _RowsChild[32].Row = value;
                if (value != null)
                {
                    _RowsChild[32].Row.ParentID = _ID;
                    _RowsChild[32].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R617);
                }
                _RowsChild[32].R_Set = true;
            }
        }

        public T800_I2_07_10 R631
        {
            get
            {
                if (!_RowsChild[33].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[33].Row = null;
                    }
                    else
                    {
                        R631 = new T800_I2_07_10(_ID, T800_Mapping.GetRowID(T800_Mapping.R631));
                    }
                }
                return (T800_I2_07_10)_RowsChild[33].Row;
            }
            set
            {
                _RowsChild[33].Row = value;
                if (value != null)
                {
                    _RowsChild[33].Row.ParentID = _ID;
                    _RowsChild[33].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R631);
                }
                _RowsChild[33].R_Set = true;
            }
        }

        public T800_I2_07_10 R645
        {
            get
            {
                if (!_RowsChild[34].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[34].Row = null;
                    }
                    else
                    {
                        R645 = new T800_I2_07_10(_ID, T800_Mapping.GetRowID(T800_Mapping.R645));
                    }
                }
                return (T800_I2_07_10)_RowsChild[34].Row;
            }
            set
            {
                _RowsChild[34].Row = value;
                if (value != null)
                {
                    _RowsChild[34].Row.ParentID = _ID;
                    _RowsChild[34].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R645);
                }
                _RowsChild[34].R_Set = true;
            }
        }

        public T800_I2_07_10 R659
        {
            get
            {
                if (!_RowsChild[35].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[35].Row = null;
                    }
                    else
                    {
                        R659 = new T800_I2_07_10(_ID, T800_Mapping.GetRowID(T800_Mapping.R659));
                    }
                }
                return (T800_I2_07_10)_RowsChild[35].Row;
            }
            set
            {
                _RowsChild[35].Row = value;
                if (value != null)
                {
                    _RowsChild[35].Row.ParentID = _ID;
                    _RowsChild[35].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R659);
                }
                _RowsChild[35].R_Set = true;
            }
        }

        public T800_I2_07_10 R673
        {
            get
            {
                if (!_RowsChild[36].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[36].Row = null;
                    }
                    else
                    {
                        R673 = new T800_I2_07_10(_ID, T800_Mapping.GetRowID(T800_Mapping.R673));
                    }
                }
                return (T800_I2_07_10)_RowsChild[36].Row;
            }
            set
            {
                _RowsChild[36].Row = value;
                if (value != null)
                {
                    _RowsChild[36].Row.ParentID = _ID;
                    _RowsChild[36].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R673);
                }
                _RowsChild[36].R_Set = true;
            }
        }

        public T800_I2_07_10 R687
        {
            get
            {
                if (!_RowsChild[37].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[37].Row = null;
                    }
                    else
                    {
                        R687 = new T800_I2_07_10(_ID, T800_Mapping.GetRowID(T800_Mapping.R687));
                    }
                }
                return (T800_I2_07_10)_RowsChild[37].Row;
            }
            set
            {
                _RowsChild[37].Row = value;
                if (value != null)
                {
                    _RowsChild[37].Row.ParentID = _ID;
                    _RowsChild[37].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R687);
                }
                _RowsChild[37].R_Set = true;
            }
        }

        public T800_I2_07_10 R701
        {
            get
            {
                if (!_RowsChild[39].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[39].Row = null;
                    }
                    else
                    {
                        R701 = new T800_I2_07_10(_ID, T800_Mapping.GetRowID(T800_Mapping.R701));
                    }
                }
                return (T800_I2_07_10)_RowsChild[39].Row;
            }
            set
            {
                _RowsChild[39].Row = value;
                if (value != null)
                {
                    _RowsChild[39].Row.ParentID = _ID;
                    _RowsChild[39].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R701);
                }
                _RowsChild[39].R_Set = true;
            }
        }

        public T800_I2_07_10 R715
        {
            get
            {
                if (!_RowsChild[40].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[40].Row = null;
                    }
                    else
                    {
                        R715 = new T800_I2_07_10(_ID, T800_Mapping.GetRowID(T800_Mapping.R715));
                    }
                }
                return (T800_I2_07_10)_RowsChild[40].Row;
            }
            set
            {
                _RowsChild[40].Row = value;
                if (value != null)
                {
                    _RowsChild[40].Row.ParentID = _ID;
                    _RowsChild[40].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R715);
                }
                _RowsChild[40].R_Set = true;
            }
        }

        public T800_I2_07_10 R729
        {
            get
            {
                if (!_RowsChild[41].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[41].Row = null;
                    }
                    else
                    {
                        R729 = new T800_I2_07_10(_ID, T800_Mapping.GetRowID(T800_Mapping.R729));
                    }
                }
                return (T800_I2_07_10)_RowsChild[41].Row;
            }
            set
            {
                _RowsChild[41].Row = value;
                if (value != null)
                {
                    _RowsChild[41].Row.ParentID = _ID;
                    _RowsChild[41].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R729);
                }
                _RowsChild[41].R_Set = true;
            }
        }

        public T800_I2_07_10 R743
        {
            get
            {
                if (!_RowsChild[42].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[42].Row = null;
                    }
                    else
                    {
                        R743 = new T800_I2_07_10(_ID, T800_Mapping.GetRowID(T800_Mapping.R743));
                    }
                }
                return (T800_I2_07_10)_RowsChild[42].Row;
            }
            set
            {
                _RowsChild[42].Row = value;
                if (value != null)
                {
                    _RowsChild[42].Row.ParentID = _ID;
                    _RowsChild[42].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R743);
                }
                _RowsChild[42].R_Set = true;
            }
        }

        public T800_I2_07_10 R757
        {
            get
            {
                if (!_RowsChild[43].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[43].Row = null;
                    }
                    else
                    {
                        R757 = new T800_I2_07_10(_ID, T800_Mapping.GetRowID(T800_Mapping.R757));
                    }
                }
                return (T800_I2_07_10)_RowsChild[43].Row;
            }
            set
            {
                _RowsChild[43].Row = value;
                if (value != null)
                {
                    _RowsChild[43].Row.ParentID = _ID;
                    _RowsChild[43].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R757);
                }
                _RowsChild[43].R_Set = true;
            }
        }

        public T800_I2_07_10 R771
        {
            get
            {
                if (!_RowsChild[44].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[44].Row = null;
                    }
                    else
                    {
                        R771 = new T800_I2_07_10(_ID, T800_Mapping.GetRowID(T800_Mapping.R771));
                    }
                }
                return (T800_I2_07_10)_RowsChild[44].Row;
            }
            set
            {
                _RowsChild[44].Row = value;
                if (value != null)
                {
                    _RowsChild[44].Row.ParentID = _ID;
                    _RowsChild[44].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R771);
                }
                _RowsChild[44].R_Set = true;
            }
        }

        public T800_I2_07_10 R785
        {
            get
            {
                if (!_RowsChild[45].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[45].Row = null;
                    }
                    else
                    {
                        R785 = new T800_I2_07_10(_ID, T800_Mapping.GetRowID(T800_Mapping.R785));
                    }
                }
                return (T800_I2_07_10)_RowsChild[45].Row;
            }
            set
            {
                _RowsChild[45].Row = value;
                if (value != null)
                {
                    _RowsChild[45].Row.ParentID = _ID;
                    _RowsChild[45].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R785);
                }
                _RowsChild[45].R_Set = true;
            }
        }

        public T800_I2_07_10 R799
        {
            get
            {
                if (!_RowsChild[46].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[46].Row = null;
                    }
                    else
                    {
                        R799 = new T800_I2_07_10(_ID, T800_Mapping.GetRowID(T800_Mapping.R799));
                    }
                }
                return (T800_I2_07_10)_RowsChild[46].Row;
            }
            set
            {
                _RowsChild[46].Row = value;
                if (value != null)
                {
                    _RowsChild[46].Row.ParentID = _ID;
                    _RowsChild[46].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R799);
                }
                _RowsChild[46].R_Set = true;
            }
        }

        public T800_I2_07_10 R813
        {
            get
            {
                if (!_RowsChild[47].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[47].Row = null;
                    }
                    else
                    {
                        R813 = new T800_I2_07_10(_ID, T800_Mapping.GetRowID(T800_Mapping.R813));
                    }
                }
                return (T800_I2_07_10)_RowsChild[47].Row;
            }
            set
            {
                _RowsChild[47].Row = value;
                if (value != null)
                {
                    _RowsChild[47].Row.ParentID = _ID;
                    _RowsChild[47].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R813);
                }
                _RowsChild[47].R_Set = true;
            }
        }

        public T800_I2_07_10 R827
        {
            get
            {
                if (!_RowsChild[48].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[48].Row = null;
                    }
                    else
                    {
                        R827 = new T800_I2_07_10(_ID, T800_Mapping.GetRowID(T800_Mapping.R827));
                    }
                }
                return (T800_I2_07_10)_RowsChild[48].Row;
            }
            set
            {
                _RowsChild[48].Row = value;
                if (value != null)
                {
                    _RowsChild[48].Row.ParentID = _ID;
                    _RowsChild[48].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R827);
                }
                _RowsChild[48].R_Set = true;
            }
        }

        public T800_I2_07 R703
        {
            get
            {
                if (!_RowsChild[38].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[38].Row = null;
                    }
                    else
                    {
                        R703 = new T800_I2_07(_ID, T800_Mapping.GetRowID(T800_Mapping.R843));
                    }
                }
                return (T800_I2_07)_RowsChild[38].Row;
            }
            set
            {
                _RowsChild[38].Row = value;
                if (value != null)
                {
                    _RowsChild[38].Row.ParentID = _ID;
                    _RowsChild[38].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R843);
                }
                _RowsChild[38].R_Set = true;
            }
        }

        // HSS 4
        public T800_I2_10 R481
        {
            get
            {
                if (!_RowsChild[49].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[49].Row = null;
                    }
                    else
                    {
                        R481 = new T800_I2_10(_ID, T800_Mapping.GetRowID(T800_Mapping.R481));
                        if (_RowsChild[49].Row != null && _RowsChild[49].Row.ID < 1)
                        {
                            R481 = null;
                        }
                    }
                }
                return (T800_I2_10)_RowsChild[49].Row;
            }
            set
            {
                _RowsChild[49].Row = value;
                if (value != null)
                {
                    _RowsChild[49].Row.ParentID = _ID;
                    _RowsChild[49].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R481);
                }
                _RowsChild[49].R_Set = true;
            }
        }
        
        public T800_Extend_01 R857
        {
            get
            {
                if (!_RowsChild[50].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[50].Row = null;
                    }
                    else
                    {
                        R857 = new T800_Extend_01(_ID, T800_Mapping.GetRowID(T800_Mapping.R857));
                        if (_RowsChild[50].Row != null && _RowsChild[50].Row.ID < 1)
                        {
                            R857 = null;
                        }
                    }
                }
                return (T800_Extend_01)_RowsChild[50].Row;
            }
            set
            {
                _RowsChild[50].Row = value;
                if (value != null)
                {
                    _RowsChild[50].Row.ParentID = _ID;
                    _RowsChild[50].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R857);
                }
                _RowsChild[50].R_Set = true;
            }
        }
        // End HSS 4

        // HSS5
        public T800_Extend_02 R451
        {
            get
            {
                if (!_RowsChild[51].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[51].Row = null;
                    }
                    else
                    {
                        R451 = new T800_Extend_02(_ID, T800_Mapping.GetRowID(T800_Mapping.R451));
                        if (_RowsChild[51].Row != null && _RowsChild[51].Row.ID < 1)
                        {
                            R451 = null;
                        }
                    }
                }
                return (T800_Extend_02)_RowsChild[51].Row;
            }
            set
            {
                _RowsChild[51].Row = value;
                if (value != null)
                {
                    _RowsChild[51].Row.ParentID = _ID;
                    _RowsChild[51].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.R451);
                }
                _RowsChild[51].R_Set = true;
            }
        }
        // End HSS5
		#endregion

        protected void NewRowsChild()
        {
            for (int i = 0; i < _RowsChild.Length; i++)
            {
                _RowsChild[i] = new T_R_RowSet();
            }
        }

		#region Constructors
		public T800()
		{
            _ID = 0;
            NewRowsChild();
		}
        public T800(DBAccessor dbAccessor)
        {
            this.DBAccessor = dbAccessor;

            _ID = 0;
            NewRowsChild();
        }
        public T800(int iD)
        {
            NewRowsChild();
            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                WhereParameterCollection whereColl = new WhereParameterCollection();
                whereColl.Add(ID__COLUMN_NAME, iD, CompareType.Equal);
                DataSet ds = _DBAccessor.GetTable(TABLE_NAME, whereColl);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    FromDataRow(ds.Tables[0].Rows[0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!this.db_Set)
                {
                    _DBAccessor.Dispose();
                }
            }
        }
        public T800(DBAccessor dbAccessor, int iD)
        {
            this.DBAccessor = dbAccessor;
            NewRowsChild();
            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                WhereParameterCollection whereColl = new WhereParameterCollection();
                whereColl.Add(ID__COLUMN_NAME, iD, CompareType.Equal);
                DataSet ds = _DBAccessor.GetTable(TABLE_NAME, whereColl);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    FromDataRow(ds.Tables[0].Rows[0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!this.db_Set)
                {
                    _DBAccessor.Dispose();
                }
            }
        }
        public T800(int iD,
            string r025, Int16 r033, Int16 r035, Int16 r037, Int16 r039, 
            string r041, Int16 r043, string r043_1, string r053, Int16 r059, Int16 r061, 
            Int16 r063, Int16 r065, Int16 r067, Int16 r069, Int16 r071, 
            string r073, Int16 r081,
            Int16 r073_1, Int16 r075, Int16 r077, Int16 r079, Int16 r081_1,
            Int16 r111, Int16 r113, Int16 r115, Int16 r117, Int16 r119, 
            Int16 r163
            )
        {
            NewRowsChild();
            _ID = iD;
            _R025 = r025;
            _R033 = r033;
            _R035 = r035;
            _R037 = r037;
            _R039 = r039;
            _R041 = r041;
            _R043 = r043;
            _R043_1 = r043_1;
            _R053 = r053;
            _R059 = r059;
            _R061 = r061;
            _R063 = r063;
            _R065 = r065;
            _R067 = r067;
            _R069 = r069;
            _R073 = r073;
            _R081 = r081;
            _R071 = r071;
            _R073_1 = r073_1;
            _R075 = r075;
            _R077 = r077;
            _R079 = r079;
            _R081_1 = r081_1;
            _R111 = r111;
            _R113 = r113;
            _R115 = r115;
            _R117 = r117;
            _R119 = r119;
            _R163 = r163;
        }
        public T800(DBAccessor dbAccessor, int iD,
            string r025, Int16 r033, Int16 r035, Int16 r037, Int16 r039,
            string r041, Int16 r043, string r043_1, string r053, Int16 r059, Int16 r061,
            Int16 r063, Int16 r065, Int16 r067, Int16 r069, Int16 r071,
            string r073, Int16 r081,
            Int16 r073_1, Int16 r075, Int16 r077, Int16 r079, Int16 r081_1,
            Int16 r111, Int16 r113, Int16 r115, Int16 r117, Int16 r119,
            Int16 r163)
        {
            this.DBAccessor = dbAccessor;
            NewRowsChild();
            _ID = iD;
            _R025 = r025;
            _R033 = r033;
            _R035 = r035;
            _R037 = r037;
            _R039 = r039;
            _R041 = r041;
            _R043 = r043;
            _R043_1 = r043_1;
            _R053 = r053;
            _R059 = r059;
            _R061 = r061;
            _R063 = r063;
            _R065 = r065;
            _R067 = r067;
            _R069 = r069;
            _R073 = r073;
            _R081 = r081;
            _R071 = r071;
            _R073_1 = r073_1;
            _R075 = r075;
            _R077 = r077;
            _R079 = r079;
            _R081_1 = r081_1;
            _R111 = r111;
            _R113 = r113;
            _R115 = r115;
            _R117 = r117;
            _R119 = r119;
            _R163 = r163;
        }
		#endregion

        public static T800 FromCoilNo(string coilNo)
        {
            DBAccessor dbAccessor = null;
            try
            {
                dbAccessor = new DBAccessor();
                WhereParameterCollection whereColl = new WhereParameterCollection();
                whereColl.Add(R025__COLUMN_NAME, coilNo, CompareType.Like);
                object objID = dbAccessor.GetValue(TABLE_NAME, whereColl, ID__COLUMN_NAME);
                if (objID != null && objID != DBNull.Value)
                {
                    return new T800(Convert.ToInt32(objID));
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (dbAccessor != null)
                {
                    dbAccessor.Dispose();
                }
            }
        }
		
		#region Insert/Update/Delete
		public int Insert()
		{
			ParameterCollection coll = new ParameterCollection(); 
			coll.Add(R025__COLUMN_NAME, _R025);
			coll.Add(R033__COLUMN_NAME, _R033);
			coll.Add(R035__COLUMN_NAME, _R035);
			coll.Add(R037__COLUMN_NAME, _R037);
			coll.Add(R039__COLUMN_NAME, _R039);
			coll.Add(R041__COLUMN_NAME, _R041);
            coll.Add(R043__COLUMN_NAME, _R043);
			coll.Add(R043_1__COLUMN_NAME, _R043_1);
			coll.Add(R053__COLUMN_NAME, _R053);
			coll.Add(R059__COLUMN_NAME, _R059);
			coll.Add(R061__COLUMN_NAME, _R061);
			coll.Add(R063__COLUMN_NAME, _R063);
			coll.Add(R065__COLUMN_NAME, _R065);
			coll.Add(R067__COLUMN_NAME, _R067);
			coll.Add(R069__COLUMN_NAME, _R069);
            coll.Add(R073__COLUMN_NAME, _R073);
            coll.Add(R081__COLUMN_NAME, _R081);
			coll.Add(R071__COLUMN_NAME, _R071);
			coll.Add(R073_1__COLUMN_NAME, _R073_1);
			coll.Add(R075__COLUMN_NAME, _R075);
			coll.Add(R077__COLUMN_NAME, _R077);
			coll.Add(R079__COLUMN_NAME, _R079);
			coll.Add(R081_1__COLUMN_NAME, _R081_1);
			coll.Add(R111__COLUMN_NAME, _R111);
			coll.Add(R113__COLUMN_NAME, _R113);
			coll.Add(R115__COLUMN_NAME, _R115);
			coll.Add(R117__COLUMN_NAME, _R117);
			coll.Add(R119__COLUMN_NAME, _R119);
			coll.Add(R163__COLUMN_NAME, _R163);
            coll.Add(R701_1__COLUMN_NAME, _R701_1);
            coll.Add(LASTUPDATE__COLUMN_NAME, DateTime.Now);

            object obj = null;
			try 
			{
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                _DBAccessor.BeginTransaction();

                obj = _DBAccessor.InsertWithIdentity(TABLE_NAME, coll);

                _ID = Convert.ToInt32(obj);

                if (_RowsChild[0].Row == null)
                {
                    R083 = T800_I2_07.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R083));
                }
                _RowsChild[0].Row.ParentID = this.ID;
                _RowsChild[0].Row.DBAccessor = _DBAccessor;
                _RowsChild[0].Row.Insert();

                if (_RowsChild[1].Row == null)
                {
                    R097 = T800_I2_07.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R097));
                }
                _RowsChild[1].Row.ParentID = this.ID;
                _RowsChild[1].Row.DBAccessor = _DBAccessor;
                _RowsChild[1].Row.Insert();

                if (_RowsChild[2].Row == null)
                {
                    R121 = T800_I2_07.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R121));
                }
                _RowsChild[2].Row.ParentID = this.ID;
                _RowsChild[2].Row.DBAccessor = _DBAccessor;
                _RowsChild[2].Row.Insert();

                if (_RowsChild[3].Row == null)
                {
                    R135 = T800_I2_07.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R135));
                }
                _RowsChild[3].Row.ParentID = this.ID;
                _RowsChild[3].Row.DBAccessor = _DBAccessor;
                _RowsChild[3].Row.Insert();

                if (_RowsChild[4].Row == null)
                {
                    R149 = T800_I2_07.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R149));
                }
                _RowsChild[4].Row.ParentID = this.ID;
                _RowsChild[4].Row.DBAccessor = _DBAccessor;
                _RowsChild[4].Row.Insert();

                if (_RowsChild[5].Row == null)
                {
                    R165 = T800_I2_07.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R165));
                }
                _RowsChild[5].Row.ParentID = this.ID;
                _RowsChild[5].Row.DBAccessor = _DBAccessor;
                _RowsChild[5].Row.Insert();

                if (_RowsChild[6].Row == null)
                {
                    R179 = T800_I2_07.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R179));
                }
                _RowsChild[6].Row.ParentID = this.ID;
                _RowsChild[6].Row.DBAccessor = _DBAccessor;
                _RowsChild[6].Row.Insert();

                if (_RowsChild[7].Row == null)
                {
                    R193 = T800_I2_07.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R193));
                }
                _RowsChild[7].Row.ParentID = this.ID;
                _RowsChild[7].Row.DBAccessor = _DBAccessor;
                _RowsChild[7].Row.Insert();

                if (_RowsChild[8].Row == null)
                {
                    R207 = T800_I2_07.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R207));
                }
                _RowsChild[8].Row.ParentID = this.ID;
                _RowsChild[8].Row.DBAccessor = _DBAccessor;
                _RowsChild[8].Row.Insert();

                if (_RowsChild[9].Row == null)
                {
                    R221 = T800_I2_07.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R221));
                }
                _RowsChild[9].Row.ParentID = this.ID;
                _RowsChild[9].Row.DBAccessor = _DBAccessor;
                _RowsChild[9].Row.Insert();

                if (_RowsChild[10].Row == null)
                {
                    R235 = T800_I2_07.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R235));
                }
                _RowsChild[10].Row.ParentID = this.ID;
                _RowsChild[10].Row.DBAccessor = _DBAccessor;
                _RowsChild[10].Row.Insert();

                if (_RowsChild[11].Row == null)
                {
                    R249 = T800_I2_07.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R249));
                }
                _RowsChild[11].Row.ParentID = this.ID;
                _RowsChild[11].Row.DBAccessor = _DBAccessor;
                _RowsChild[11].Row.Insert();

                if (_RowsChild[12].Row == null)
                {
                    R263 = T800_I2_07.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R263));
                }
                _RowsChild[12].Row.ParentID = this.ID;
                _RowsChild[12].Row.DBAccessor = _DBAccessor;
                _RowsChild[12].Row.Insert();

                if (_RowsChild[13].Row == null)
                {
                    R277 = T800_I2_07.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R277));
                }
                _RowsChild[13].Row.ParentID = this.ID;
                _RowsChild[13].Row.DBAccessor = _DBAccessor;
                _RowsChild[13].Row.Insert();

                if (_RowsChild[14].Row == null)
                {
                    R291 = T800_I2_07.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R291));
                }
                _RowsChild[14].Row.ParentID = this.ID;
                _RowsChild[14].Row.DBAccessor = _DBAccessor;
                _RowsChild[14].Row.Insert();

                if (_RowsChild[15].Row == null)
                {
                    R305 = T800_I2_07.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R305));
                }
                _RowsChild[15].Row.ParentID = this.ID;
                _RowsChild[15].Row.DBAccessor = _DBAccessor;
                _RowsChild[15].Row.Insert();

                if (_RowsChild[16].Row == null)
                {
                    R319 = T800_I2_06.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R319));
                }
                _RowsChild[16].Row.ParentID = this.ID;
                _RowsChild[16].Row.DBAccessor = _DBAccessor;
                _RowsChild[16].Row.Insert();

                if (_RowsChild[17].Row == null)
                {
                    R331 = T800_I2_06.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R331));
                }
                _RowsChild[17].Row.ParentID = this.ID;
                _RowsChild[17].Row.DBAccessor = _DBAccessor;
                _RowsChild[17].Row.Insert();

                if (_RowsChild[18].Row == null)
                {
                    R343 = T800_I2_07.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R343));
                }
                _RowsChild[18].Row.ParentID = this.ID;
                _RowsChild[18].Row.DBAccessor = _DBAccessor;
                _RowsChild[18].Row.Insert();

                if (_RowsChild[19].Row == null)
                {
                    R357 = T800_I2_07.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R357));
                }
                _RowsChild[19].Row.ParentID = this.ID;
                _RowsChild[19].Row.DBAccessor = _DBAccessor;
                _RowsChild[19].Row.Insert();

                if (_RowsChild[20].Row == null)
                {
                    R371 = T800_I2_07.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R371));
                }
                _RowsChild[20].Row.ParentID = this.ID;
                _RowsChild[20].Row.DBAccessor = _DBAccessor;
                _RowsChild[20].Row.Insert();

                if (_RowsChild[21].Row == null)
                {
                    R385 = T800_I2_07.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R385));
                }
                _RowsChild[21].Row.ParentID = this.ID;
                _RowsChild[21].Row.DBAccessor = _DBAccessor;
                _RowsChild[21].Row.Insert();

                if (_RowsChild[22].Row == null)
                {
                    R399 = T800_I2_07.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R399));
                }
                _RowsChild[22].Row.ParentID = this.ID;
                _RowsChild[22].Row.DBAccessor = _DBAccessor;
                _RowsChild[22].Row.Insert();

                if (_RowsChild[23].Row == null)
                {
                    R413 = T800_I2_07.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R413));
                }
                _RowsChild[23].Row.ParentID = this.ID;
                _RowsChild[23].Row.DBAccessor = _DBAccessor;
                _RowsChild[23].Row.Insert();

                if (_RowsChild[24].Row == null)
                {
                    R427 = T800_I2_06.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R427));
                }
                _RowsChild[24].Row.ParentID = this.ID;
                _RowsChild[24].Row.DBAccessor = _DBAccessor;
                _RowsChild[24].Row.Insert();

                if (_RowsChild[25].Row == null)
                {
                    R501 = T800_I2_10.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R501));
                }
                _RowsChild[25].Row.ParentID = this.ID;
                _RowsChild[25].Row.DBAccessor = _DBAccessor;
                _RowsChild[25].Row.Insert();

                if (_RowsChild[26].Row == null)
                {
                    R521 = T800_I2_10.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R521));
                }
                _RowsChild[26].Row.ParentID = this.ID;
                _RowsChild[26].Row.DBAccessor = _DBAccessor;
                _RowsChild[26].Row.Insert();

                if (_RowsChild[27].Row == null)
                {
                    R541 = T800_I2_10.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R541));
                }
                _RowsChild[27].Row.ParentID = this.ID;
                _RowsChild[27].Row.DBAccessor = _DBAccessor;
                _RowsChild[27].Row.Insert();

                if (_RowsChild[28].Row == null)
                {
                    R561 = T800_I2_07_10.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R561));
                }
                _RowsChild[28].Row.ParentID = this.ID;
                _RowsChild[28].Row.DBAccessor = _DBAccessor;
                _RowsChild[28].Row.Insert();

                if (_RowsChild[29].Row == null)
                {
                    R575 = T800_I2_07_10.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R575));
                }
                _RowsChild[29].Row.ParentID = this.ID;
                _RowsChild[29].Row.DBAccessor = _DBAccessor;
                _RowsChild[29].Row.Insert();

                if (_RowsChild[30].Row == null)
                {
                    R589 = T800_I2_07_10.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R589));
                }
                _RowsChild[30].Row.ParentID = this.ID;
                _RowsChild[30].Row.DBAccessor = _DBAccessor;
                _RowsChild[30].Row.Insert();

                if (_RowsChild[31].Row == null)
                {
                    R603 = T800_I2_07_10.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R603));
                }
                _RowsChild[31].Row.ParentID = this.ID;
                _RowsChild[31].Row.DBAccessor = _DBAccessor;
                _RowsChild[31].Row.Insert();

                if (_RowsChild[32].Row == null)
                {
                    R617 = T800_I2_07_10.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R617));
                }
                _RowsChild[32].Row.ParentID = this.ID;
                _RowsChild[32].Row.DBAccessor = _DBAccessor;
                _RowsChild[32].Row.Insert();

                if (_RowsChild[33].Row == null)
                {
                    R631 = T800_I2_07_10.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R631));
                }
                _RowsChild[33].Row.ParentID = this.ID;
                _RowsChild[33].Row.DBAccessor = _DBAccessor;
                _RowsChild[33].Row.Insert();

                if (_RowsChild[34].Row == null)
                {
                    R645 = T800_I2_07_10.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R645));
                }
                _RowsChild[34].Row.ParentID = this.ID;
                _RowsChild[34].Row.DBAccessor = _DBAccessor;
                _RowsChild[34].Row.Insert();

                if (_RowsChild[35].Row == null)
                {
                    R659 = T800_I2_07_10.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R659));
                }
                _RowsChild[35].Row.ParentID = this.ID;
                _RowsChild[35].Row.DBAccessor = _DBAccessor;
                _RowsChild[35].Row.Insert();

                if (_RowsChild[36].Row == null)
                {
                    R673 = T800_I2_07_10.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R673));
                }
                _RowsChild[36].Row.ParentID = this.ID;
                _RowsChild[36].Row.DBAccessor = _DBAccessor;
                _RowsChild[36].Row.Insert();

                if (_RowsChild[37].Row == null)
                {
                    R687 = T800_I2_07_10.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R687));
                }
                _RowsChild[37].Row.ParentID = this.ID;
                _RowsChild[37].Row.DBAccessor = _DBAccessor;
                _RowsChild[37].Row.Insert();


                if (_RowsChild[39].Row == null)
                {
                    R701 = T800_I2_07_10.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R701));
                }
                _RowsChild[39].Row.ParentID = this.ID;
                _RowsChild[39].Row.DBAccessor = _DBAccessor;
                _RowsChild[39].Row.Insert();

                if (_RowsChild[40].Row == null)
                {
                    R715 = T800_I2_07_10.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R715));
                }
                _RowsChild[40].Row.ParentID = this.ID;
                _RowsChild[40].Row.DBAccessor = _DBAccessor;
                _RowsChild[40].Row.Insert();

                if (_RowsChild[41].Row == null)
                {
                    R729 = T800_I2_07_10.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R729));
                }
                _RowsChild[41].Row.ParentID = this.ID;
                _RowsChild[41].Row.DBAccessor = _DBAccessor;
                _RowsChild[41].Row.Insert();

                if (_RowsChild[42].Row == null)
                {
                    R743 = T800_I2_07_10.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R743));
                }
                _RowsChild[42].Row.ParentID = this.ID;
                _RowsChild[42].Row.DBAccessor = _DBAccessor;
                _RowsChild[42].Row.Insert();

                if (_RowsChild[43].Row == null)
                {
                    R757 = T800_I2_07_10.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R757));
                }
                _RowsChild[43].Row.ParentID = this.ID;
                _RowsChild[43].Row.DBAccessor = _DBAccessor;
                _RowsChild[43].Row.Insert();

                if (_RowsChild[44].Row == null)
                {
                    R771 = T800_I2_07_10.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R771));
                }
                _RowsChild[44].Row.ParentID = this.ID;
                _RowsChild[44].Row.DBAccessor = _DBAccessor;
                _RowsChild[44].Row.Insert();

                if (_RowsChild[45].Row == null)
                {
                    R785 = T800_I2_07_10.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R785));
                }
                _RowsChild[45].Row.ParentID = this.ID;
                _RowsChild[45].Row.DBAccessor = _DBAccessor;
                _RowsChild[45].Row.Insert();

                if (_RowsChild[46].Row == null)
                {
                    R799 = T800_I2_07_10.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R799));
                }
                _RowsChild[46].Row.ParentID = this.ID;
                _RowsChild[46].Row.DBAccessor = _DBAccessor;
                _RowsChild[46].Row.Insert();

                if (_RowsChild[47].Row == null)
                {
                    R813 = T800_I2_07_10.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R813));
                }
                _RowsChild[47].Row.ParentID = this.ID;
                _RowsChild[47].Row.DBAccessor = _DBAccessor;
                _RowsChild[47].Row.Insert();

                if (_RowsChild[48].Row == null)
                {
                    R827 = T800_I2_07_10.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R827));
                }
                _RowsChild[48].Row.ParentID = this.ID;
                _RowsChild[48].Row.DBAccessor = _DBAccessor;
                _RowsChild[48].Row.Insert();


                if (_RowsChild[38].Row == null)
                {
                    R703 = T800_I2_07.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R843));
                }
                _RowsChild[38].Row.ParentID = this.ID;
                _RowsChild[38].Row.DBAccessor = _DBAccessor;
                _RowsChild[38].Row.Insert();

                // HSS 4
                if (_RowsChild[39].Row == null)
                {
                    R481 = T800_I2_10.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R481));
                }
                _RowsChild[49].Row.ParentID = this.ID;
                _RowsChild[49].Row.DBAccessor = _DBAccessor;
                _RowsChild[49].Row.Insert();

                if (_RowsChild[50].Row == null)
                {
                    R857 = T800_Extend_01.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R857));
                }
                _RowsChild[50].Row.ParentID = this.ID;
                _RowsChild[50].Row.DBAccessor = _DBAccessor;
                _RowsChild[50].Row.Insert();
                // End HSS 4

                // End HSS5
                if (_RowsChild[51].Row == null)
                {
                    R451 = T800_Extend_02.NewObject(_ID, T800_Mapping.GetRowID(T800_Mapping.R451));
                }
                _RowsChild[51].Row.ParentID = this.ID;
                _RowsChild[51].Row.DBAccessor = _DBAccessor;
                _RowsChild[51].Row.Insert();
                // End HSS5

                this._DBAccessor.CommitTransaction();
			}
            catch (Exception ex)
            {
                if (this._DBAccessor != null)
                {
                    _DBAccessor.RollbackTransaction();
                }
                _ID = 0;
                throw ex;
            }
			finally
			{
                for (int i = 0; i < this._RowsChild.Length; i++)
                {
                    _RowsChild[i].Row.DBAccessor = null;
                }

                if (!this.db_Set && this._DBAccessor != null)
                {
                    _DBAccessor.Dispose();
                }
            }

            return _ID;
		}

		public int Update()
		{
			ParameterCollection coll = new ParameterCollection(); 
			coll.Add(R025__COLUMN_NAME, _R025);
			coll.Add(R033__COLUMN_NAME, _R033);
			coll.Add(R035__COLUMN_NAME, _R035);
			coll.Add(R037__COLUMN_NAME, _R037);
			coll.Add(R039__COLUMN_NAME, _R039);
			coll.Add(R041__COLUMN_NAME, _R041);
            coll.Add(R043__COLUMN_NAME, _R043);
            coll.Add(R043_1__COLUMN_NAME, _R043_1);
            coll.Add(R053__COLUMN_NAME, _R053);
            coll.Add(R059__COLUMN_NAME, _R059);
            coll.Add(R061__COLUMN_NAME, _R061);
            coll.Add(R063__COLUMN_NAME, _R063);
            coll.Add(R065__COLUMN_NAME, _R065);
            coll.Add(R067__COLUMN_NAME, _R067);
            coll.Add(R069__COLUMN_NAME, _R069);
            coll.Add(R073__COLUMN_NAME, _R073);
            coll.Add(R081__COLUMN_NAME, _R081);
			coll.Add(R071__COLUMN_NAME, _R071);
			coll.Add(R073_1__COLUMN_NAME, _R073_1);
			coll.Add(R075__COLUMN_NAME, _R075);
			coll.Add(R077__COLUMN_NAME, _R077);
			coll.Add(R079__COLUMN_NAME, _R079);
			coll.Add(R081_1__COLUMN_NAME, _R081_1);
			coll.Add(R111__COLUMN_NAME, _R111);
			coll.Add(R113__COLUMN_NAME, _R113);
			coll.Add(R115__COLUMN_NAME, _R115);
			coll.Add(R117__COLUMN_NAME, _R117);
			coll.Add(R119__COLUMN_NAME, _R119);
			coll.Add(R163__COLUMN_NAME, _R163);
            coll.Add(R701_1__COLUMN_NAME, _R701_1);
            coll.Add(LASTUPDATE__COLUMN_NAME, DateTime.Now);

			WhereParameterCollection whereColl = new WhereParameterCollection();
			whereColl.Add(ID__COLUMN_NAME, _ID, CompareType.Equal);

            int retValue = 0;
            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }

                this._DBAccessor.BeginTransaction();
                retValue = _DBAccessor.Update(TABLE_NAME, coll, whereColl);
                for (int i = 0; i < this._RowsChild.Length; i++)
                {
                    if (_RowsChild[i].Row != null)
                    {
                        _RowsChild[i].Row.ParentID = _ID;
                        _RowsChild[i].Row.RowID = T800_Mapping.GetRowID(T800_Mapping.RowsName[i]);
                        _RowsChild[i].Row.DBAccessor = this._DBAccessor;
                        _RowsChild[i].Row.Update();
                    }
                }
                this._DBAccessor.CommitTransaction();

            }
            catch (Exception ex)
            {
                this._DBAccessor.RollbackTransaction();
                _ID = 0;
                throw ex;
            }
            finally
            {
                for (int i = 0; i < this._RowsChild.Length; i++)
                {
                    if (_RowsChild[i].Row != null)
                    {
                        _RowsChild[i].Row.DBAccessor = null;
                    }
                }
                if (!this.db_Set && this._DBAccessor != null)
                {
                    _DBAccessor.Dispose();
                }
            }
            return retValue;
		}

		public int Delete()
		{
			WhereParameterCollection whereColl = new WhereParameterCollection();
			whereColl.Add(ID__COLUMN_NAME, _ID, CompareType.Equal);

			
			try 
			{
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                return _DBAccessor.Delete(TABLE_NAME, whereColl); 
			}
			catch(Exception)
			{
				return -1;
			}
			finally
			{
                if (!this.db_Set)
                {
                    _DBAccessor.Dispose();
                }
			}
		}
		#endregion

        public void FromDataRow(DataRow row)
        {
            _ID = (int)row[ID__COLUMN_NAME];
            _R025 = row[R025__COLUMN_NAME] == DBNull.Value ? null : (string)row[R025__COLUMN_NAME];
            _R033 = row[R033__COLUMN_NAME] == DBNull.Value ? (Int16)2000 : (Int16)row[R033__COLUMN_NAME];
            _R035 = row[R035__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R035__COLUMN_NAME];
            _R037 = row[R037__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R037__COLUMN_NAME];
            _R039 = row[R039__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R039__COLUMN_NAME];
            _R041 = row[R041__COLUMN_NAME] == DBNull.Value ? null : (string)row[R041__COLUMN_NAME];
            _R043 = row[R043__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R043__COLUMN_NAME];
            _R043_1 = row[R043_1__COLUMN_NAME] == DBNull.Value ? null : (string)row[R043_1__COLUMN_NAME];
            _R053 = row[R053__COLUMN_NAME] == DBNull.Value ? null : (string)row[R053__COLUMN_NAME];
            _R059 = row[R059__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R059__COLUMN_NAME];
            _R061 = row[R061__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R061__COLUMN_NAME];
            _R063 = row[R063__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R063__COLUMN_NAME];
            _R065 = row[R065__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R065__COLUMN_NAME];
            _R067 = row[R067__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R067__COLUMN_NAME];
            _R069 = row[R069__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R069__COLUMN_NAME];
            _R073 = row[R073__COLUMN_NAME] == DBNull.Value ? null : (string)row[R073__COLUMN_NAME];
            _R081 = row[R081__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R081__COLUMN_NAME];
            _R071 = row[R071__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R071__COLUMN_NAME];
            _R073_1 = row[R073_1__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R073_1__COLUMN_NAME];
            _R075 = row[R075__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R075__COLUMN_NAME];
            _R077 = row[R077__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R077__COLUMN_NAME];
            _R079 = row[R079__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R079__COLUMN_NAME];
            _R081_1 = row[R081_1__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R081_1__COLUMN_NAME];
            _R111 = row[R111__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R111__COLUMN_NAME];
            _R113 = row[R113__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R113__COLUMN_NAME];
            _R115 = row[R115__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R115__COLUMN_NAME];
            _R117 = row[R117__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R117__COLUMN_NAME];
            _R119 = row[R119__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R119__COLUMN_NAME];
            _R163 = row[R163__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R163__COLUMN_NAME];
            _R701_1 = row[R701_1__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R701_1__COLUMN_NAME];
            _LastUpdate = row[LASTUPDATE__COLUMN_NAME] == DBNull.Value ? DateTime.Now : (DateTime)row[LASTUPDATE__COLUMN_NAME];
        }

        public static T800 GetLast()
        {
            DBAccessor _DBAccessor = null;
            try
            {
                _DBAccessor = new DBAccessor();
                object obj = _DBAccessor.MaxValue(TABLE_NAME, ID__COLUMN_NAME);

                if (obj != null && obj != DBNull.Value)
                {
                    int maxId = Convert.ToInt32(obj);

                    return new T800(maxId);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _DBAccessor.Dispose();
            }
        }
        public static T800 GetLast(DBAccessor db)
        {
            object obj = db.MaxValue(TABLE_NAME, ID__COLUMN_NAME);

            if (obj != null && obj != DBNull.Value)
            {
                int maxId = Convert.ToInt32(obj);

                T800 t800 = new T800(db, maxId);
                t800.DBAccessor = null;
                return t800;
            }

            return null;
        }

        public static long RecordCount()
        {
            DBAccessor _DBAccessor = null;
            try
            {
                _DBAccessor = new DBAccessor();
                return _DBAccessor.RecordCount(TABLE_NAME);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _DBAccessor.Dispose();
            }
        }
        public static long RecordCount(DBAccessor db)
        {
            return db.RecordCount(TABLE_NAME);
        }

        public DataSet GetAll()
        {
            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                return _DBAccessor.GetTable(TABLE_NAME);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!this.db_Set)
                {
                    _DBAccessor.Dispose();
                }
            }
        }
        public DataSet GetAll(string sortCollumn, SortType sortType)
        {
            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }

                SortParameterCollection sortColl = new SortParameterCollection();
                sortColl.Add(sortCollumn, sortType);

                return _DBAccessor.GetTable(TABLE_NAME, sortColl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!this.db_Set)
                {
                    _DBAccessor.Dispose();
                }
            }
        }

        public static T800 Parse(Byte[] data)
        {
            if (data == null || data.Length != 984)
            {
                return null;
            }

            T800 t800 = new T800();

            t800.ID = 0;

            try
            {
                log.Debug("T800 Begin parse");

                t800.R025 = Common.GetString(data, 8, 8);
                t800.R033 = Common.ToInt16(data, 16);
                if (t800.R033 < 100)
                {
                    t800.R033 += 2000;
                    t800.R033 = (Int16)(t800.R033 > DateTime.Now.Year ? (t800.R033 - 100) : t800.R033);
                }
                t800.R035 = Common.ToInt16(data, 18);
                t800.R037 = Common.ToInt16(data, 20);
                t800.R039 = Common.ToInt16(data, 22);

                t800.R041 = Common.GetString(data, 24, 2);
                t800.R043 = Common.ToInt16(data, 26);
                t800.R043_1 = Common.GetString(data, 28, 10);
                t800.R053 = Common.GetString(data, 38, 6);
                t800.R059 = Common.ToInt16(data, 44);
                t800.R061 = Common.ToInt16(data, 46);
                t800.R063 = Common.ToInt16(data, 48);
                t800.R065 = Common.ToInt16(data, 50);
                t800.R067 = Common.ToInt16(data, 52);
                t800.R069 = Common.ToInt16(data, 54);
                t800.R073 = Common.GetString(data, 56, 8);
                t800.R081 = Common.ToInt16(data, 64);
                t800.R071 = Common.ToInt16(data, 66);
                t800.R073_1 = Common.ToInt16(data, 68);
                t800.R075 = Common.ToInt16(data, 70);
                t800.R077 = Common.ToInt16(data, 72);
                t800.R079 = Common.ToInt16(data, 74);
                t800.R081_1 = Common.ToInt16(data, 76);
                t800.R111 = Common.ToInt16(data, 106);
                t800.R113 = Common.ToInt16(data, 108);
                t800.R115 = Common.ToInt16(data, 110);
                t800.R117 = Common.ToInt16(data, 112);
                t800.R119 = Common.ToInt16(data, 114);
                t800.R163 = Common.ToInt16(data, 158);
                t800.R701_1 = Common.ToInt16(data, 840 - 16); // fixed

                log.Debug("T800 Begin parse children");

                t800.R083 = T800_I2_07.Parse(data, 78);
                t800.R097 = T800_I2_07.Parse(data, 92);
                t800.R121 = T800_I2_07.Parse(data, 116);
                t800.R135 = T800_I2_07.Parse(data, 130);
                t800.R149 = T800_I2_07.Parse(data, 144);
                t800.R165 = T800_I2_07.Parse(data, 160);
                t800.R179 = T800_I2_07.Parse(data, 174);
                t800.R193 = T800_I2_07.Parse(data, 188);
                t800.R207 = T800_I2_07.Parse(data, 202);
                t800.R221 = T800_I2_07.Parse(data, 216);
                t800.R235 = T800_I2_07.Parse(data, 230);
                t800.R249 = T800_I2_07.Parse(data, 244);
                t800.R263 = T800_I2_07.Parse(data, 258);
                t800.R277 = T800_I2_07.Parse(data, 272);
                t800.R291 = T800_I2_07.Parse(data, 186);
                t800.R305 = T800_I2_07.Parse(data, 300);
                t800.R319 = T800_I2_06.Parse(data, 314);
                t800.R331 = T800_I2_06.Parse(data, 326);
                t800.R343 = T800_I2_07.Parse(data, 338);
                t800.R357 = T800_I2_07.Parse(data, 352);
                t800.R371 = T800_I2_07.Parse(data, 366);
                t800.R385 = T800_I2_07.Parse(data, 380);
                t800.R399 = T800_I2_07.Parse(data, 394);
                t800.R413 = T800_I2_07.Parse(data, 408);
                t800.R427 = T800_I2_06.Parse(data, 422);
                t800.R501 = T800_I2_10.Parse(data, 484);
                t800.R521 = T800_I2_10.Parse(data, 504);
                t800.R541 = T800_I2_10.Parse(data, 524);
                t800.R561 = T800_I2_07_10.Parse(data, 544);
                t800.R575 = T800_I2_07_10.Parse(data, 558);
                t800.R589 = T800_I2_07_10.Parse(data, 572);
                t800.R603 = T800_I2_07_10.Parse(data, 586);
                t800.R617 = T800_I2_07_10.Parse(data, 600);
                t800.R631 = T800_I2_07_10.Parse(data, 614);
                t800.R645 = T800_I2_07_10.Parse(data, 628);
                t800.R659 = T800_I2_07_10.Parse(data, 642);
                t800.R673 = T800_I2_07_10.Parse(data, 656);
                t800.R687 = T800_I2_07_10.Parse(data, 670);

                t800.R701 = T800_I2_07_10.Parse(data, 700 - 16);
                t800.R715 = T800_I2_07_10.Parse(data, 714 - 16);
                t800.R729 = T800_I2_07_10.Parse(data, 728 - 16);
                t800.R743 = T800_I2_07_10.Parse(data, 742 - 16);
                t800.R757 = T800_I2_07_10.Parse(data, 756 - 16);
                t800.R771 = T800_I2_07_10.Parse(data, 770 - 16);
                t800.R785 = T800_I2_07_10.Parse(data, 784 - 16);
                t800.R799 = T800_I2_07_10.Parse(data, 798 - 16);
                t800.R813 = T800_I2_07_10.Parse(data, 812 - 16);
                t800.R827 = T800_I2_07_10.Parse(data, 826 - 16);

                t800.R703 = T800_I2_07.Parse(data, 842 - 16);

                log.Debug("T800 Begin parse HSS4 ");

                // HSS 4
                t800.R481 = T800_I2_10.Parse(data, 480 - 16);
                t800.R857 = T800_Extend_01.Parse(data, 856 - 16);
                // End HSS 4

                // HSS5
                t800.R451 = T800_Extend_02.Parse(data, 450 - 16);
                // End HSS5

                log.Debug("T800 End parse successful.");
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                log.Error("T800 parse error: " + ex.Message, ex);
                return null;
            }

            return t800;
        }
        public Byte[] GetBytes()
        {
            Byte[] data = new Byte[984];

            try
            {
                Buffer.BlockCopy(Common.GetBytes(TRANSACTION_CODE), 0, data, 0, 8);
                Buffer.BlockCopy(Common.GetBytes(_R025), 0, data, 8, 8);
                Buffer.BlockCopy(Common.GetBytes(((Int16)_R033 % 100)), 0, data, 16, 2);
                Buffer.BlockCopy(Common.GetBytes(_R035), 0, data, 18, 2);
                Buffer.BlockCopy(Common.GetBytes(_R037), 0, data, 20, 2);
                Buffer.BlockCopy(Common.GetBytes(_R039), 0, data, 22, 2);
                Buffer.BlockCopy(Common.GetBytes(_R041), 0, data, 24, 2);
                Buffer.BlockCopy(Common.GetBytes(_R043), 0, data, 26, 2);
                Buffer.BlockCopy(Common.GetBytes(_R043_1), 0, data, 28, 10);
                Buffer.BlockCopy(Common.GetBytes(_R053), 0, data, 38, 6);
                Buffer.BlockCopy(Common.GetBytes(_R059), 0, data, 44, 2);
                Buffer.BlockCopy(Common.GetBytes(_R061), 0, data, 46, 2);
                Buffer.BlockCopy(Common.GetBytes(_R063), 0, data, 48, 2);
                Buffer.BlockCopy(Common.GetBytes(_R065), 0, data, 50, 2);
                Buffer.BlockCopy(Common.GetBytes(_R067), 0, data, 52, 2);
                Buffer.BlockCopy(Common.GetBytes(_R069), 0, data, 54, 2);
                Buffer.BlockCopy(Common.GetBytes(_R073), 0, data, 56, 8);
                Buffer.BlockCopy(Common.GetBytes(_R081), 0, data, 64, 2);
                Buffer.BlockCopy(Common.GetBytes(_R071), 0, data, 66, 2);
                Buffer.BlockCopy(Common.GetBytes(_R073_1), 0, data, 68, 2);
                Buffer.BlockCopy(Common.GetBytes(_R075), 0, data, 70, 2);
                Buffer.BlockCopy(Common.GetBytes(_R077), 0, data, 72, 2);
                Buffer.BlockCopy(Common.GetBytes(_R079), 0, data, 74, 2);
                Buffer.BlockCopy(Common.GetBytes(_R081_1), 0, data, 76, 2);
                Buffer.BlockCopy(Common.GetBytes(_R111), 0, data, 106, 2);
                Buffer.BlockCopy(Common.GetBytes(_R113), 0, data, 108, 2);
                Buffer.BlockCopy(Common.GetBytes(_R115), 0, data, 110, 2);
                Buffer.BlockCopy(Common.GetBytes(_R117), 0, data, 112, 2);
                Buffer.BlockCopy(Common.GetBytes(_R119), 0, data, 114, 2);
                Buffer.BlockCopy(Common.GetBytes(_R163), 0, data, 158, 2);
                Buffer.BlockCopy(Common.GetBytes(_R701_1), 0, data, 684, 2);

                Buffer.BlockCopy(R083.GetBytes(), 0, data, 78, 14);
                Buffer.BlockCopy(R097.GetBytes(), 0, data, 92, 14);
                Buffer.BlockCopy(R121.GetBytes(), 0, data, 116, 14);
                Buffer.BlockCopy(R135.GetBytes(), 0, data, 130, 14);
                Buffer.BlockCopy(R149.GetBytes(), 0, data, 144, 14);
                Buffer.BlockCopy(R165.GetBytes(), 0, data, 160, 14);
                Buffer.BlockCopy(R179.GetBytes(), 0, data, 174, 14);
                Buffer.BlockCopy(R193.GetBytes(), 0, data, 188, 14);
                Buffer.BlockCopy(R207.GetBytes(), 0, data, 202, 14);
                Buffer.BlockCopy(R221.GetBytes(), 0, data, 216, 14);
                Buffer.BlockCopy(R235.GetBytes(), 0, data, 230, 14);
                Buffer.BlockCopy(R249.GetBytes(), 0, data, 244, 14);
                Buffer.BlockCopy(R263.GetBytes(), 0, data, 258, 14);
                Buffer.BlockCopy(R277.GetBytes(), 0, data, 272, 14);
                Buffer.BlockCopy(R291.GetBytes(), 0, data, 186, 14);
                Buffer.BlockCopy(R305.GetBytes(), 0, data, 300, 14);
                Buffer.BlockCopy(R319.GetBytes(), 0, data, 314, 12);
                Buffer.BlockCopy(R331.GetBytes(), 0, data, 326, 12);
                Buffer.BlockCopy(R343.GetBytes(), 0, data, 338, 14);
                Buffer.BlockCopy(R357.GetBytes(), 0, data, 352, 14);
                Buffer.BlockCopy(R371.GetBytes(), 0, data, 366, 14);
                Buffer.BlockCopy(R385.GetBytes(), 0, data, 380, 14);
                Buffer.BlockCopy(R399.GetBytes(), 0, data, 394, 14);
                Buffer.BlockCopy(R413.GetBytes(), 0, data, 408, 14);
                Buffer.BlockCopy(R427.GetBytes(), 0, data, 422, 12);
                Buffer.BlockCopy(R501.GetBytes(), 0, data, 484, 20);
                Buffer.BlockCopy(R521.GetBytes(), 0, data, 504, 20);
                Buffer.BlockCopy(R541.GetBytes(), 0, data, 524, 20);
                Buffer.BlockCopy(R561.GetBytes(), 0, data, 544, 14);
                Buffer.BlockCopy(R575.GetBytes(), 0, data, 558, 14);
                Buffer.BlockCopy(R589.GetBytes(), 0, data, 572, 14);
                Buffer.BlockCopy(R603.GetBytes(), 0, data, 586, 14);
                Buffer.BlockCopy(R617.GetBytes(), 0, data, 600, 14);
                Buffer.BlockCopy(R631.GetBytes(), 0, data, 614, 14);
                Buffer.BlockCopy(R645.GetBytes(), 0, data, 628, 14);
                Buffer.BlockCopy(R659.GetBytes(), 0, data, 642, 14);
                Buffer.BlockCopy(R673.GetBytes(), 0, data, 656, 14);
                Buffer.BlockCopy(R687.GetBytes(), 0, data, 670, 14);

                Buffer.BlockCopy(R701.GetBytes(), 0, data, 700 - 16, 14);
                Buffer.BlockCopy(R715.GetBytes(), 0, data, 714 - 16, 14);
                Buffer.BlockCopy(R729.GetBytes(), 0, data, 728 - 16, 14);
                Buffer.BlockCopy(R743.GetBytes(), 0, data, 742 - 16, 14);
                Buffer.BlockCopy(R757.GetBytes(), 0, data, 756 - 16, 14);
                Buffer.BlockCopy(R771.GetBytes(), 0, data, 770 - 16, 14);
                Buffer.BlockCopy(R785.GetBytes(), 0, data, 784 - 16, 14);
                Buffer.BlockCopy(R799.GetBytes(), 0, data, 798 - 16, 14);
                Buffer.BlockCopy(R813.GetBytes(), 0, data, 812 - 16, 14);
                Buffer.BlockCopy(R827.GetBytes(), 0, data, 826 - 16, 14);

                Buffer.BlockCopy(R703.GetBytes(), 0, data, 842 - 16, 14);

                // HSS 4
                Buffer.BlockCopy(R481.GetBytes(), 0, data, 480 - 16, 20);
                Buffer.BlockCopy(R857.GetBytes(), 0, data, 856 - 16, T800_Extend_01.EXTEND_PAKAGE_LENGTH);
                // End HSS 4

                // HSS5
                Buffer.BlockCopy(R451.GetBytes(), 0, data, 450 - 16, T800_Extend_02.EXTEND_PAKAGE_LENGTH);
                // End HSS5
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            return data;
        }

        public bool Equals(T800 t800)
        {
            try
            {
                if (t800 == null)
                {
                    return false;
                }
                if (
                    !_R025.Equals(t800.R025, StringComparison.OrdinalIgnoreCase) ||
                    _R033 != t800.R033 ||
                    _R035 != t800.R035 ||
                    _R037 != t800.R037 ||
                    _R039 != t800.R039 ||
                    !_R041.Equals(t800.R041, StringComparison.OrdinalIgnoreCase) ||
                    _R043 != t800.R043 ||
                    !_R043_1.Equals(t800.R043_1, StringComparison.OrdinalIgnoreCase) ||
                    !_R053.Equals(t800.R053, StringComparison.OrdinalIgnoreCase) ||
                    _R059 != t800.R059 ||
                    _R061 != t800.R061 ||
                    _R063 != t800.R063 ||
                    _R065 != t800.R065 ||
                    _R067 != t800.R067 ||
                    _R069 != t800.R069 ||
                    _R073 != t800.R073 ||
                    _R081 != t800.R081 ||
                    _R071 != t800.R071 ||
                    _R073_1 != t800.R073_1 ||
                    _R075 != t800.R075 ||
                    _R077 != t800.R077 ||
                    _R079 != t800.R079 ||
                    _R081_1 != t800.R081_1 ||
                    _R111 != t800.R111 ||
                    _R113 != t800.R113 ||
                    _R115 != t800.R115 ||
                    _R117 != t800.R117 ||
                    _R119 != t800.R119 ||
                    _R163 != t800.R163 ||
                    _R701_1 != t800.R701_1
                    )
                    return false;
                /*
                for (int i = 0; i < this._RowsChild.Length; i++)
                {
                    if ((_RowsChild[i].Row == null && t800._RowsChild[i].Row != null)
                        || (_RowsChild[i].Row != null && t800._RowsChild[i].Row == null)
                        || !_RowsChild[i].Row.Equals(t800._RowsChild[i]))
                    {
                        return false;
                    }
                }
                */
                /*
                if ((R083 == null && t800.R083 != null) || (R083 != null && t800.R083 == null) || !R083.Equals(t800.R083)) return false;
                if ((R097 == null && t800.R097 != null) || (R097 != null && t800.R097 == null) || !R097.Equals(t800.R097)) return false;
                if ((R121 == null && t800.R121 != null) || (R121 != null && t800.R121 == null) || !R121.Equals(t800.R121)) return false;
                if ((R135 == null && t800.R135 != null) || (R135 != null && t800.R135 == null) || !R135.Equals(t800.R135)) return false;
                if ((R149 == null && t800.R149 != null) || (R149 != null && t800.R149 == null) || !R149.Equals(t800.R149)) return false;
                if ((R165 == null && t800.R165 != null) || (R165 != null && t800.R165 == null) || !R165.Equals(t800.R165)) return false;
                if ((R179 == null && t800.R179 != null) || (R179 != null && t800.R179 == null) || !R179.Equals(t800.R179)) return false;
                if ((R193 == null && t800.R193 != null) || (R193 != null && t800.R193 == null) || !R193.Equals(t800.R193)) return false;
                if ((R207 == null && t800.R207 != null) || (R207 != null && t800.R207 == null) || !R207.Equals(t800.R207)) return false;
                if ((R221 == null && t800.R221 != null) || (R221 != null && t800.R221 == null) || !R221.Equals(t800.R221)) return false;
                if ((R235 == null && t800.R235 != null) || (R235 != null && t800.R235 == null) || !R235.Equals(t800.R235)) return false;
                if ((R249 == null && t800.R249 != null) || (R249 != null && t800.R249 == null) || !R249.Equals(t800.R249)) return false;
                if ((R263 == null && t800.R263 != null) || (R263 != null && t800.R263 == null) || !R263.Equals(t800.R263)) return false;
                if ((R277 == null && t800.R277 != null) || (R277 != null && t800.R277 == null) || !R277.Equals(t800.R277)) return false;
                if ((R291 == null && t800.R291 != null) || (R291 != null && t800.R291 == null) || !R291.Equals(t800.R291)) return false;
                if ((R305 == null && t800.R305 != null) || (R305 != null && t800.R305 == null) || !R305.Equals(t800.R305)) return false;
                if ((R319 == null && t800.R319 != null) || (R319 != null && t800.R319 == null) || !R319.Equals(t800.R319)) return false;
                if ((R331 == null && t800.R331 != null) || (R331 != null && t800.R331 == null) || !R331.Equals(t800.R331)) return false;
                if ((R343 == null && t800.R343 != null) || (R343 != null && t800.R343 == null) || !R343.Equals(t800.R343)) return false;
                if ((R357 == null && t800.R357 != null) || (R357 != null && t800.R357 == null) || !R357.Equals(t800.R357)) return false;
                if ((R371 == null && t800.R371 != null) || (R371 != null && t800.R371 == null) || !R371.Equals(t800.R371)) return false;
                if ((R385 == null && t800.R385 != null) || (R385 != null && t800.R385 == null) || !R385.Equals(t800.R385)) return false;
                if ((R399 == null && t800.R399 != null) || (R399 != null && t800.R399 == null) || !R399.Equals(t800.R399)) return false;
                if ((R413 == null && t800.R413 != null) || (R413 != null && t800.R413 == null) || !R413.Equals(t800.R413)) return false;
                if ((R427 == null && t800.R427 != null) || (R427 != null && t800.R427 == null) || !R427.Equals(t800.R427)) return false;
                if ((R501 == null && t800.R501 != null) || (R501 != null && t800.R501 == null) || !R501.Equals(t800.R501)) return false;
                if ((R521 == null && t800.R521 != null) || (R521 != null && t800.R521 == null) || !R521.Equals(t800.R521)) return false;
                if ((R541 == null && t800.R541 != null) || (R541 != null && t800.R541 == null) || !R541.Equals(t800.R541)) return false;
                if ((R561 == null && t800.R561 != null) || (R561 != null && t800.R561 == null) || !R561.Equals(t800.R561)) return false;
                if ((R575 == null && t800.R575 != null) || (R575 != null && t800.R575 == null) || !R575.Equals(t800.R575)) return false;
                if ((R589 == null && t800.R589 != null) || (R589 != null && t800.R589 == null) || !R589.Equals(t800.R589)) return false;
                if ((R603 == null && t800.R603 != null) || (R603 != null && t800.R603 == null) || !R603.Equals(t800.R603)) return false;
                if ((R617 == null && t800.R617 != null) || (R617 != null && t800.R617 == null) || !R617.Equals(t800.R617)) return false;
                if ((R631 == null && t800.R631 != null) || (R631 != null && t800.R631 == null) || !R631.Equals(t800.R631)) return false;
                if ((R645 == null && t800.R645 != null) || (R645 != null && t800.R645 == null) || !R645.Equals(t800.R645)) return false;
                if ((R659 == null && t800.R659 != null) || (R659 != null && t800.R659 == null) || !R659.Equals(t800.R659)) return false;
                if ((R673 == null && t800.R673 != null) || (R673 != null && t800.R673 == null) || !R673.Equals(t800.R673)) return false;
                if ((R687 == null && t800.R687 != null) || (R687 != null && t800.R687 == null) || !R687.Equals(t800.R687)) return false;
                if ((R703 == null && t800.R703 != null) || (R703 != null && t800.R703 == null) || !R703.Equals(t800.R703)) return false;
                */
                if ((R083 == null && t800.R083 != null) || (R083 != null && t800.R083 == null) || !R083.Equals(t800.R083)) return false;
                if ((R097 == null && t800.R097 != null) || (R097 != null && t800.R097 == null) || !R097.Equals(t800.R097)) return false;
                if ((R121 == null && t800.R121 != null) || (R121 != null && t800.R121 == null) || !R121.Equals(t800.R121)) return false;
                if ((R135 == null && t800.R135 != null) || (R135 != null && t800.R135 == null) || !R135.Equals(t800.R135)) return false;
                if ((R149 == null && t800.R149 != null) || (R149 != null && t800.R149 == null) || !R149.Equals(t800.R149)) return false;
                if ((R165 == null && t800.R165 != null) || (R165 != null && t800.R165 == null) || !R165.Equals(t800.R165)) return false;
                if ((R179 == null && t800.R179 != null) || (R179 != null && t800.R179 == null) || !R179.Equals(t800.R179)) return false;
                if ((R193 == null && t800.R193 != null) || (R193 != null && t800.R193 == null) || !R193.Equals(t800.R193)) return false;
                if ((R207 == null && t800.R207 != null) || (R207 != null && t800.R207 == null) || !R207.Equals(t800.R207)) return false;
                if ((R221 == null && t800.R221 != null) || (R221 != null && t800.R221 == null) || !R221.Equals(t800.R221)) return false;
                if ((R235 == null && t800.R235 != null) || (R235 != null && t800.R235 == null) || !R235.Equals(t800.R235)) return false;
                if ((R249 == null && t800.R249 != null) || (R249 != null && t800.R249 == null) || !R249.Equals(t800.R249)) return false;
                if ((R263 == null && t800.R263 != null) || (R263 != null && t800.R263 == null) || !R263.Equals(t800.R263)) return false;
                if ((R277 == null && t800.R277 != null) || (R277 != null && t800.R277 == null) || !R277.Equals(t800.R277)) return false;
                if ((R291 == null && t800.R291 != null) || (R291 != null && t800.R291 == null) || !R291.Equals(t800.R291)) return false;
                if ((R305 == null && t800.R305 != null) || (R305 != null && t800.R305 == null) || !R305.Equals(t800.R305)) return false;
                if ((R319 == null && t800.R319 != null) || (R319 != null && t800.R319 == null) || !R319.Equals(t800.R319)) return false;
                if ((R331 == null && t800.R331 != null) || (R331 != null && t800.R331 == null) || !R331.Equals(t800.R331)) return false;
                if ((R343 == null && t800.R343 != null) || (R343 != null && t800.R343 == null) || !R343.Equals(t800.R343)) return false;
                if ((R357 == null && t800.R357 != null) || (R357 != null && t800.R357 == null) || !R357.Equals(t800.R357)) return false;
                if ((R371 == null && t800.R371 != null) || (R371 != null && t800.R371 == null) || !R371.Equals(t800.R371)) return false;
                if ((R385 == null && t800.R385 != null) || (R385 != null && t800.R385 == null) || !R385.Equals(t800.R385)) return false;
                if ((R399 == null && t800.R399 != null) || (R399 != null && t800.R399 == null) || !R399.Equals(t800.R399)) return false;
                if ((R413 == null && t800.R413 != null) || (R413 != null && t800.R413 == null) || !R413.Equals(t800.R413)) return false;
                if ((R427 == null && t800.R427 != null) || (R427 != null && t800.R427 == null) || !R427.Equals(t800.R427)) return false;
                if ((R501 == null && t800.R501 != null) || (R501 != null && t800.R501 == null) || !R501.Equals(t800.R501)) return false;
                if ((R521 == null && t800.R521 != null) || (R521 != null && t800.R521 == null) || !R521.Equals(t800.R521)) return false;
                if ((R541 == null && t800.R541 != null) || (R541 != null && t800.R541 == null) || !R541.Equals(t800.R541)) return false;
                if ((R561 == null && t800.R561 != null) || (R561 != null && t800.R561 == null) || !R561.Equals(t800.R561)) return false;
                if ((R575 == null && t800.R575 != null) || (R575 != null && t800.R575 == null) || !R575.Equals(t800.R575)) return false;
                if ((R589 == null && t800.R589 != null) || (R589 != null && t800.R589 == null) || !R589.Equals(t800.R589)) return false;
                if ((R603 == null && t800.R603 != null) || (R603 != null && t800.R603 == null) || !R603.Equals(t800.R603)) return false;
                if ((R617 == null && t800.R617 != null) || (R617 != null && t800.R617 == null) || !R617.Equals(t800.R617)) return false;
                if ((R631 == null && t800.R631 != null) || (R631 != null && t800.R631 == null) || !R631.Equals(t800.R631)) return false;
                if ((R645 == null && t800.R645 != null) || (R645 != null && t800.R645 == null) || !R645.Equals(t800.R645)) return false;
                if ((R659 == null && t800.R659 != null) || (R659 != null && t800.R659 == null) || !R659.Equals(t800.R659)) return false;
                if ((R673 == null && t800.R673 != null) || (R673 != null && t800.R673 == null) || !R673.Equals(t800.R673)) return false;
                if ((R687 == null && t800.R687 != null) || (R687 != null && t800.R687 == null) || !R687.Equals(t800.R687)) return false;

                if ((R701 == null && t800.R701 != null) || (R701 != null && t800.R701 == null) || !R701.Equals(t800.R701)) return false;
                if ((R715 == null && t800.R715 != null) || (R715 != null && t800.R715 == null) || !R715.Equals(t800.R715)) return false;
                if ((R729 == null && t800.R729 != null) || (R729 != null && t800.R729 == null) || !R729.Equals(t800.R729)) return false;
                if ((R743 == null && t800.R743 != null) || (R743 != null && t800.R743 == null) || !R743.Equals(t800.R743)) return false;
                if ((R757 == null && t800.R757 != null) || (R757 != null && t800.R757 == null) || !R757.Equals(t800.R757)) return false;
                if ((R771 == null && t800.R771 != null) || (R771 != null && t800.R771 == null) || !R771.Equals(t800.R771)) return false;
                if ((R785 == null && t800.R785 != null) || (R785 != null && t800.R785 == null) || !R785.Equals(t800.R785)) return false;
                if ((R799 == null && t800.R799 != null) || (R799 != null && t800.R799 == null) || !R799.Equals(t800.R799)) return false;
                if ((R813 == null && t800.R813 != null) || (R813 != null && t800.R813 == null) || !R813.Equals(t800.R813)) return false;
                if ((R827 == null && t800.R827 != null) || (R827 != null && t800.R827 == null) || !R827.Equals(t800.R827)) return false;
                
                if ((R703 == null && t800.R703 != null) || (R703 != null && t800.R703 == null) || !R703.Equals(t800.R703)) return false;

                // HSS 4
                if ((R481 == null && t800.R481 != null) || (R481 != null && t800.R481 == null) || !R481.Equals(t800.R481)) return false;
                // End HSS 4

                // HSS5
                if ((R451 == null && t800.R451 != null) || (R451 != null && t800.R451 == null) || !R451.Equals(t800.R451)) return false;
                // End HSS5
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public T800 GetPreviousFinal()
        {
            if (_ID > 1)
            {
                WhereParameterCollection whereColl = new WhereParameterCollection();
                whereColl.Add(ID__COLUMN_NAME, _ID, CompareType.Less);
                //whereColl.Add(R025__COLUMN_NAME, R025, CompareType.Like);
                //whereColl.Add(R033__COLUMN_NAME, R033, CompareType.Equal);

                try
                {
                    if (!this.db_Set)
                    {
                        _DBAccessor = new DBAccessor();
                    }
                    object obj = _DBAccessor.MaxValue(TABLE_NAME, ID__COLUMN_NAME, whereColl);

                    if (obj != null && obj != DBNull.Value)
                    {
                        int preId = Convert.ToInt32(obj);

                        return new T800(preId);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (!this.db_Set)
                    {
                        _DBAccessor.Dispose();
                    }
                }
            }
            return null;
        }

        public static T800 GetCoilDetailOfYear(string coilNo, int year)
        {
            WhereParameterCollection whereColl = new WhereParameterCollection();
            whereColl.Add(R025__COLUMN_NAME, coilNo, CompareType.Equal);
            whereColl.Add(R033__COLUMN_NAME, year, CompareType.Equal);


            DBAccessor _DBAccessor = null;
            try
            {
                _DBAccessor = new DBAccessor();
                DataSet data_Set = _DBAccessor.GetTable(TABLE_NAME, whereColl);

                if (data_Set != null && data_Set.Tables[0].Rows.Count != 0)
                {
                    DataRow row = data_Set.Tables[0].Rows[0];
                    T800 t800 = new T800();
                    t800.FromDataRow(row);
                    return t800;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _DBAccessor.Dispose();
            }

        }

        public DataSet GetLast101CoilList()
        {
            WhereParameterCollection whereColl = new WhereParameterCollection();
            whereColl.Add(ID__COLUMN_NAME, _ID, CompareType.EqualOrLess);

            SortParameterCollection sortColl = new SortParameterCollection();
            sortColl.Add(ID__COLUMN_NAME, SortType.Decrease);

            DBAccessor _DBAccessor = null;
            try
            {
                _DBAccessor = new DBAccessor();
                DataSet ds = _DBAccessor.GetTop(TABLE_NAME, new string[] {R119__COLUMN_NAME, R117__COLUMN_NAME }, 101, whereColl, sortColl);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _DBAccessor.Dispose();
            }
        }
    }
}
