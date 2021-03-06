using System;
using System.Data;

using Kvics.DBAccess;


namespace Kvics.HotMill.BL
{
	/// <summary>
    /// Summary description for T900
	/// </summary>
    public class T900 : BaseBL
    {
        #region Static
        public static readonly string TABLE_NAME = "T900_仕上予備計算情報";
        public static readonly string ID__COLUMN_NAME = "ID";
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
        public static readonly string R071__COLUMN_NAME = "R071_鋼種名";
        public static readonly string R073__COLUMN_NAME = "R079_熱間強度";
        public static readonly string R119__COLUMN_NAME = "R119_仕上温度_ＦＤＴ";
        public static readonly string R121__COLUMN_NAME = "R121_粗出側温度_Ｒ５ＤＴ_上面";
        public static readonly string R123__COLUMN_NAME = "R123_Ｒ５ＤＴ平均温度";
        public static readonly string R125__COLUMN_NAME = "R125_仕上入側温度_ＦＥＴ";
        public static readonly string R127__COLUMN_NAME = "R127_ＦＳＢ入側温度";
        public static readonly string R129__COLUMN_NAME = "R129_ＦＳＢ出側温度";
        public static readonly string R159__COLUMN_NAME = "R159_ＥＨ使用フラグ";
        public static readonly string R161__COLUMN_NAME = "R161_ＲＢ幅";
        public static readonly string R163__COLUMN_NAME = "R163_ＲＢ厚";
        public static readonly string R165__COLUMN_NAME = "R165_ＨＣ幅";
        public static readonly string R167__COLUMN_NAME = "R167_ＨＣ厚";
        public static readonly string R211__COLUMN_NAME = "R211_通板速度";
        public static readonly string LASTUPDATE__COLUMN_NAME = "LastUpdate";
        public static readonly string TRANSACTION_CODE = "00010001";
        #endregion

        #region Protected
        protected int _ID;
        protected string _R025;
        protected Int16 _R033;
        protected Int16 _R035;
        protected Int16 _R037;
        protected Int16 _R039;
        protected string _R041;
        protected Int16 _R043;
        protected string _R043_1;
        protected string _R053;
        protected Int16 _R059;
        protected Int16 _R061;
        protected Int16 _R063;
        protected Int16 _R065;
        protected Int16 _R067;
        protected Int16 _R069;
        protected string _R071;
        protected Int16 _R079;
        protected Int16 _R119;
        protected Int16 _R121;
        protected Int16 _R123;
        protected Int16 _R125;
        protected Int16 _R127;
        protected Int16 _R129;
        protected Int16 _R159;
        protected Int16 _R161;
        protected Int16 _R163;
        protected Int16 _R165;
        protected Int16 _R167;
        protected Int16 _R211;
        protected DateTime _LastUpdate;
        protected T_R_RowSet[] _RowsChild = new T_R_RowSet[T900_Mapping.RowsName.Length];
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
                _R025 = value;
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
                _R043_1 = value;
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
                _R053 = value;
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
        public string R071
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
        public Int16 R121
        {
            get
            {
                return _R121;
            }
            set
            {
                _R121 = value;
            }
        }
        public Int16 R123
        {
            get
            {
                return _R123;
            }
            set
            {
                _R123 = value;
            }
        }
        public Int16 R125
        {
            get
            {
                return _R125;
            }
            set
            {
                _R125 = value;
            }
        }
        public Int16 R127
        {
            get
            {
                return _R127;
            }
            set
            {
                _R127 = value;
            }
        }
        public Int16 R129
        {
            get
            {
                return _R129;
            }
            set
            {
                _R129 = value;
            }
        }
        public Int16 R159
        {
            get
            {
                return _R159;
            }
            set
            {
                _R159 = value;
            }
        }
        public Int16 R161
        {
            get
            {
                return _R161;
            }
            set
            {
                _R161 = value;
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
        public Int16 R165
        {
            get
            {
                return _R165;
            }
            set
            {
                _R165 = value;
            }
        }
        public Int16 R167
        {
            get
            {
                return _R167;
            }
            set
            {
                _R167 = value;
            }
        }
        public Int16 R211
        {
            get
            {
                return _R211;
            }
            set
            {
                _R211 = value;
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

        public T900_I2_19 R081
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
                        R081 = new T900_I2_19(_ID, T900_Mapping.GetRowID(T900_Mapping.R081));
                    }
                }
                return (T900_I2_19)_RowsChild[0].Row;
            }
            set
            {
                _RowsChild[0].Row = value;
                if (value != null)
                {
                    _RowsChild[0].Row.ParentID = _ID;
                    _RowsChild[0].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R081);
                }
                _RowsChild[0].R_Set = true;
            }
        }

        public T900_I2_07 R131
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
                        R131 = new T900_I2_07(_ID, T900_Mapping.GetRowID(T900_Mapping.R131));
                    }
                }
                return (T900_I2_07)_RowsChild[1].Row;
            }
            set
            {
                _RowsChild[1].Row = value;
                if (value != null)
                {
                    _RowsChild[1].Row.ParentID = _ID;
                    _RowsChild[1].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R131);
                }
                _RowsChild[1].R_Set = true;
            }
        }

        public T900_I2_07 R145
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
                        R145 = new T900_I2_07(_ID, T900_Mapping.GetRowID(T900_Mapping.R145));
                    }
                }
                return (T900_I2_07)_RowsChild[2].Row;
            }
            set
            {
                _RowsChild[2].Row = value;
                if (value != null)
                {
                    _RowsChild[2].Row.ParentID = _ID;
                    _RowsChild[2].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R145);
                }
                _RowsChild[2].R_Set = true;
            }
        }

        public T900_I2_07 R169
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
                        R169 = new T900_I2_07(_ID, T900_Mapping.GetRowID(T900_Mapping.R169));
                    }
                }
                return (T900_I2_07)_RowsChild[3].Row;
            }
            set
            {
                _RowsChild[3].Row = value;
                if (value != null)
                {
                    _RowsChild[3].Row.ParentID = _ID;
                    _RowsChild[3].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R169);
                }
                _RowsChild[3].R_Set = true;
            }
        }

        public T900_I2_07 R183
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
                        R183 = new T900_I2_07(_ID, T900_Mapping.GetRowID(T900_Mapping.R183));
                    }
                }
                return (T900_I2_07)_RowsChild[4].Row;
            }
            set
            {
                _RowsChild[4].Row = value;
                if (value != null)
                {
                    _RowsChild[4].Row.ParentID = _ID;
                    _RowsChild[4].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R183);
                }
                _RowsChild[4].R_Set = true;
            }
        }

        public T900_I2_07 R197
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
                        R197 = new T900_I2_07(_ID, T900_Mapping.GetRowID(T900_Mapping.R197));
                    }
                }
                return (T900_I2_07)_RowsChild[5].Row;
            }
            set
            {
                _RowsChild[5].Row = value;
                if (value != null)
                {
                    _RowsChild[5].Row.ParentID = _ID;
                    _RowsChild[5].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R197);
                }
                _RowsChild[5].R_Set = true;
            }
        }

        public T900_I2_07 R213
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
                        R213 = new T900_I2_07(_ID, T900_Mapping.GetRowID(T900_Mapping.R213));
                    }
                }
                return (T900_I2_07)_RowsChild[6].Row;
            }
            set
            {
                _RowsChild[6].Row = value;
                if (value != null)
                {
                    _RowsChild[6].Row.ParentID = _ID;
                    _RowsChild[6].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R213);
                }
                _RowsChild[6].R_Set = true;
            }
        }

        public T900_I2_07 R227
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
                        R227 = new T900_I2_07(_ID, T900_Mapping.GetRowID(T900_Mapping.R227));
                    }
                }
                return (T900_I2_07)_RowsChild[7].Row;
            }
            set
            {
                _RowsChild[7].Row = value;
                if (value != null)
                {
                    _RowsChild[7].Row.ParentID = _ID;
                    _RowsChild[7].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R227);
                }
                _RowsChild[7].R_Set = true;
            }
        }

        public T900_I2_07 R241
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
                        R241 = new T900_I2_07(_ID, T900_Mapping.GetRowID(T900_Mapping.R241));
                    }
                }
                return (T900_I2_07)_RowsChild[8].Row;
            }
            set
            {
                _RowsChild[8].Row = value;
                if (value != null)
                {
                    _RowsChild[8].Row.ParentID = _ID;
                    _RowsChild[8].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R241);
                }
                _RowsChild[8].R_Set = true;
            }
        }

        public T900_I2_07 R255
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
                        R255 = new T900_I2_07(_ID, T900_Mapping.GetRowID(T900_Mapping.R255));
                    }
                }
                return (T900_I2_07)_RowsChild[9].Row;
            }
            set
            {
                _RowsChild[9].Row = value;
                if (value != null)
                {
                    _RowsChild[9].Row.ParentID = _ID;
                    _RowsChild[9].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R255);
                }
                _RowsChild[9].R_Set = true;
            }
        }

        public T900_I2_07 R269
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
                        R269 = new T900_I2_07(_ID, T900_Mapping.GetRowID(T900_Mapping.R269));
                    }
                }
                return (T900_I2_07)_RowsChild[10].Row;
            }
            set
            {
                _RowsChild[10].Row = value;
                if (value != null)
                {
                    _RowsChild[10].Row.ParentID = _ID;
                    _RowsChild[10].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R269);
                }
                _RowsChild[10].R_Set = true;
            }
        }

        public T900_I2_07 R283
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
                        R283 = new T900_I2_07(_ID, T900_Mapping.GetRowID(T900_Mapping.R283));
                    }
                }
                return (T900_I2_07)_RowsChild[11].Row;
            }
            set
            {
                _RowsChild[11].Row = value;
                if (value != null)
                {
                    _RowsChild[11].Row.ParentID = _ID;
                    _RowsChild[11].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R283);
                }
                _RowsChild[11].R_Set = true;
            }
        }

        public T900_I2_07 R297
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
                        R297 = new T900_I2_07(_ID, T900_Mapping.GetRowID(T900_Mapping.R297));
                    }
                }
                return (T900_I2_07)_RowsChild[12].Row;
            }
            set
            {
                _RowsChild[12].Row = value;
                if (value != null)
                {
                    _RowsChild[12].Row.ParentID = _ID;
                    _RowsChild[12].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R297);
                }
                _RowsChild[12].R_Set = true;
            }
        }

        public T900_I2_07 R311
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
                        R311 = new T900_I2_07(_ID, T900_Mapping.GetRowID(T900_Mapping.R311));
                    }
                }
                return (T900_I2_07)_RowsChild[13].Row;
            }
            set
            {
                _RowsChild[13].Row = value;
                if (value != null)
                {
                    _RowsChild[13].Row.ParentID = _ID;
                    _RowsChild[13].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R311);
                }
                _RowsChild[13].R_Set = true;
            }
        }

        public T900_I2_07 R325
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
                        R325 = new T900_I2_07(_ID, T900_Mapping.GetRowID(T900_Mapping.R325));
                    }
                }
                return (T900_I2_07)_RowsChild[14].Row;
            }
            set
            {
                _RowsChild[14].Row = value;
                if (value != null)
                {
                    _RowsChild[14].Row.ParentID = _ID;
                    _RowsChild[14].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R325);
                }
                _RowsChild[14].R_Set = true;
            }
        }

        public T900_I2_07 R339
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
                        R339 = new T900_I2_07(_ID, T900_Mapping.GetRowID(T900_Mapping.R339));
                    }
                }
                return (T900_I2_07)_RowsChild[15].Row;
            }
            set
            {
                _RowsChild[15].Row = value;
                if (value != null)
                {
                    _RowsChild[15].Row.ParentID = _ID;
                    _RowsChild[15].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R339);
                }
                _RowsChild[15].R_Set = true;
            }
        }

        public T900_I2_07 R353
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
                        R353 = new T900_I2_07(_ID, T900_Mapping.GetRowID(T900_Mapping.R353));
                    }
                }
                return (T900_I2_07)_RowsChild[16].Row;
            }
            set
            {
                _RowsChild[16].Row = value;
                if (value != null)
                {
                    _RowsChild[16].Row.ParentID = _ID;
                    _RowsChild[16].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R353);
                }
                _RowsChild[16].R_Set = true;
            }
        }

        public T900_I2_06 R367
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
                        R367 = new T900_I2_06(_ID, T900_Mapping.GetRowID(T900_Mapping.R367));
                    }
                }
                return (T900_I2_06)_RowsChild[17].Row;
            }
            set
            {
                _RowsChild[17].Row = value;
                if (value != null)
                {
                    _RowsChild[17].Row.ParentID = _ID;
                    _RowsChild[17].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R367);
                }
                _RowsChild[17].R_Set = true;
            }
        }

        public T900_I2_06 R379
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
                        R379 = new T900_I2_06(_ID, T900_Mapping.GetRowID(T900_Mapping.R379));
                    }
                }
                return (T900_I2_06)_RowsChild[18].Row;
            }
            set
            {
                _RowsChild[18].Row = value;
                if (value != null)
                {
                    _RowsChild[18].Row.ParentID = _ID;
                    _RowsChild[18].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R379);
                }
                _RowsChild[18].R_Set = true;
            }
        }

        public T900_I2_07 R391
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
                        R391 = new T900_I2_07(_ID, T900_Mapping.GetRowID(T900_Mapping.R391));
                    }
                }
                return (T900_I2_07)_RowsChild[19].Row;
            }
            set
            {
                _RowsChild[19].Row = value;
                if (value != null)
                {
                    _RowsChild[19].Row.ParentID = _ID;
                    _RowsChild[19].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R391);
                }
                _RowsChild[19].R_Set = true;
            }
        }

        public T900_I2_07 R405
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
                        R405 = new T900_I2_07(_ID, T900_Mapping.GetRowID(T900_Mapping.R405));
                    }
                }
                return (T900_I2_07)_RowsChild[20].Row;
            }
            set
            {
                _RowsChild[20].Row = value;
                if (value != null)
                {
                    _RowsChild[20].Row.ParentID = _ID;
                    _RowsChild[20].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R405);
                }
                _RowsChild[20].R_Set = true;
            }
        }

        public T900_I2_07 R419
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
                        R419 = new T900_I2_07(_ID, T900_Mapping.GetRowID(T900_Mapping.R419));
                    }
                }
                return (T900_I2_07)_RowsChild[21].Row;
            }
            set
            {
                _RowsChild[21].Row = value;
                if (value != null)
                {
                    _RowsChild[21].Row.ParentID = _ID;
                    _RowsChild[21].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R419);
                }
                _RowsChild[21].R_Set = true;
            }
        }

        public T900_I2_07 R433
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
                        R433 = new T900_I2_07(_ID, T900_Mapping.GetRowID(T900_Mapping.R433));
                    }
                }
                return (T900_I2_07)_RowsChild[22].Row;
            }
            set
            {
                _RowsChild[22].Row = value;
                if (value != null)
                {
                    _RowsChild[22].Row.ParentID = _ID;
                    _RowsChild[22].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R433);
                }
                _RowsChild[22].R_Set = true;
            }
        }

        public T900_I2_07 R447
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
                        R447 = new T900_I2_07(_ID, T900_Mapping.GetRowID(T900_Mapping.R447));
                    }
                }
                return (T900_I2_07)_RowsChild[23].Row;
            }
            set
            {
                _RowsChild[23].Row = value;
                if (value != null)
                {
                    _RowsChild[23].Row.ParentID = _ID;
                    _RowsChild[23].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R447);
                }
                _RowsChild[23].R_Set = true;
            }
        }

        public T900_C6_07 R501
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
                        R501 = new T900_C6_07(_ID, T900_Mapping.GetRowID(T900_Mapping.R501));
                    }
                }
                return (T900_C6_07)_RowsChild[24].Row;
            }
            set
            {
                _RowsChild[24].Row = value;
                if (value != null)
                {
                    _RowsChild[24].Row.ParentID = _ID;
                    _RowsChild[24].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R501);
                }
                _RowsChild[24].R_Set = true;
            }
        }

        public T900_C2_07 R543
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
                        R543 = new T900_C2_07(_ID, T900_Mapping.GetRowID(T900_Mapping.R543));
                    }
                }
                return (T900_C2_07)_RowsChild[25].Row;
            }
            set
            {
                _RowsChild[25].Row = value;
                if (value != null)
                {
                    _RowsChild[25].Row.ParentID = _ID;
                    _RowsChild[25].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R543);
                }
                _RowsChild[25].R_Set = true;
            }
        }

        public T900_I4_07 R557
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
                        R557 = new T900_I4_07(_ID, T900_Mapping.GetRowID(T900_Mapping.R557));
                    }
                }
                return (T900_I4_07)_RowsChild[26].Row;
            }
            set
            {
                _RowsChild[26].Row = value;
                if (value != null)
                {
                    _RowsChild[26].Row.ParentID = _ID;
                    _RowsChild[26].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R557);
                }
                _RowsChild[26].R_Set = true;
            }
        }

        public T900_I2_07 R585
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
                        R585 = new T900_I2_07(_ID, T900_Mapping.GetRowID(T900_Mapping.R585));
                    }
                }
                return (T900_I2_07)_RowsChild[27].Row;
            }
            set
            {
                _RowsChild[27].Row = value;
                if (value != null)
                {
                    _RowsChild[27].Row.ParentID = _ID;
                    _RowsChild[27].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R585);
                }
                _RowsChild[27].R_Set = true;
            }
        }

        public T900_I2_07 R599
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
                        R599 = new T900_I2_07(_ID, T900_Mapping.GetRowID(T900_Mapping.R599));
                    }
                }
                return (T900_I2_07)_RowsChild[28].Row;
            }
            set
            {
                _RowsChild[28].Row = value;
                if (value != null)
                {
                    _RowsChild[28].Row.ParentID = _ID;
                    _RowsChild[28].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R599);
                }
                _RowsChild[28].R_Set = true;
            }
        }

        public T900_I2_07 R613
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
                        R613 = new T900_I2_07(_ID, T900_Mapping.GetRowID(T900_Mapping.R613));
                    }
                }
                return (T900_I2_07)_RowsChild[29].Row;
            }
            set
            {
                _RowsChild[29].Row = value;
                if (value != null)
                {
                    _RowsChild[29].Row.ParentID = _ID;
                    _RowsChild[29].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R613);
                }
                _RowsChild[29].R_Set = true;
            }
        }

        public T900_C6_14 R627
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
                        R627 = new T900_C6_14(_ID, T900_Mapping.GetRowID(T900_Mapping.R627));
                    }
                }
                return (T900_C6_14)_RowsChild[30].Row;
            }
            set
            {
                _RowsChild[30].Row = value;
                if (value != null)
                {
                    _RowsChild[30].Row.ParentID = _ID;
                    _RowsChild[30].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R627);
                }
                _RowsChild[30].R_Set = true;
            }
        }

        public T900_I4_14 R713
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
                        R713 = new T900_I4_14(_ID, T900_Mapping.GetRowID(T900_Mapping.R713));
                    }
                }
                return (T900_I4_14)_RowsChild[31].Row;
            }
            set
            {
                _RowsChild[31].Row = value;
                if (value != null)
                {
                    _RowsChild[31].Row.ParentID = _ID;
                    _RowsChild[31].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R713);
                }
                _RowsChild[31].R_Set = true;
            }
        }

        public T900_I2_07 R801
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
                        R801 = new T900_I2_07(_ID, T900_Mapping.GetRowID(T900_Mapping.R801));
                    }
                }
                return (T900_I2_07)_RowsChild[32].Row;
            }
            set
            {
                _RowsChild[32].Row = value;
                if (value != null)
                {
                    _RowsChild[32].Row.ParentID = _ID;
                    _RowsChild[32].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R801);
                }
                _RowsChild[32].R_Set = true;
            }
        }

        public T900_I2_07 R815
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
                        R815 = new T900_I2_07(_ID, T900_Mapping.GetRowID(T900_Mapping.R815));
                    }
                }
                return (T900_I2_07)_RowsChild[33].Row;
            }
            set
            {
                _RowsChild[33].Row = value;
                if (value != null)
                {
                    _RowsChild[33].Row.ParentID = _ID;
                    _RowsChild[33].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R815);
                }
                _RowsChild[33].R_Set = true;
            }
        }

        public T900_I2_07 R851
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
                        R851 = new T900_I2_07(_ID, T900_Mapping.GetRowID(T900_Mapping.R851));
                    }
                }
                return (T900_I2_07)_RowsChild[34].Row;
            }
            set
            {
                _RowsChild[34].Row = value;
                if (value != null)
                {
                    _RowsChild[34].Row.ParentID = _ID;
                    _RowsChild[34].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.R851);
                }
                _RowsChild[34].R_Set = true;
            }
        }

        #endregion

        #region Constructors
        public T900()
        {
            _ID = 0;
            NewRowsChild();
        }

        public T900(DBAccessor dbAccessor)
        {
            this.DBAccessor = dbAccessor;
            _ID = 0;
            NewRowsChild();
        }

        public T900(int iD)
        {
            NewRowsChild();

            WhereParameterCollection whereColl = new WhereParameterCollection();
            whereColl.Add(ID__COLUMN_NAME, iD, CompareType.Equal);

            if (!this.db_Set)
            {
                _DBAccessor = new DBAccessor();
            }
            try
            {
                DataSet ds = _DBAccessor.GetTable(TABLE_NAME, whereColl);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    FromDataRow(row);
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

        public T900(DBAccessor dbAccessor, int iD)
        {
            NewRowsChild();

            this.DBAccessor = dbAccessor;

            WhereParameterCollection whereColl = new WhereParameterCollection();
            whereColl.Add(ID__COLUMN_NAME, iD, CompareType.Equal);

            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }

                DataSet ds = _DBAccessor.GetTable(TABLE_NAME, whereColl);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    FromDataRow(row);
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

        public T900(int iD, 
            string r25, Int16 r33, Int16 r35, Int16 r37, Int16 r39, string r41,
            Int16 r43, string r43_1, string r53, Int16 r59, Int16 r61, Int16 r63,
            Int16 r65, Int16 r67, Int16 r69, string r71, Int16 r73, Int16 r119,
            Int16 r121, Int16 r123, Int16 r125, Int16 r127, Int16 r129,
            Int16 r159, Int16 r161, Int16 r163, Int16 r165, Int16 r167, Int16 r211)
        {
            NewRowsChild();
            _ID = iD;
            _R025 = r25;
            _R033 = r33;
            _R035 = r35;
            _R037 = r37;
            _R039 = r39;
            _R041 = r41;
            _R043 = r43;
            _R043_1 = r43_1;
            _R053 = r53;
            _R059 = r59;
            _R061 = r61;
            _R063 = r63;
            _R065 = r65;
            _R067 = r67;
            _R069 = r69;
            _R071 = r71;
            _R079 = r73;
            _R119 = r119;
            _R121 = r121;
            _R123 = r123;
            _R125 = r125;
            _R127 = r127;
            _R129 = r129;
            _R159 = r159;
            _R161 = r161;
            _R163 = r163;
            _R165 = r165;
            _R167 = r167;
            _R211 = r211;
        }

        public T900(DBAccessor dbAccessor, int iD,
            string r25, Int16 r33, Int16 r35, Int16 r37, Int16 r39, string r41,
            Int16 r43, string r43_1, string r53, Int16 r59, Int16 r61, Int16 r63,
            Int16 r65, Int16 r67, Int16 r69, string r71, Int16 r73, Int16 r119,
            Int16 r121, Int16 r123, Int16 r125, Int16 r127, Int16 r129,
            Int16 r159, Int16 r161, Int16 r163, Int16 r165, Int16 r167, Int16 r211)
        {
            NewRowsChild();
            this.DBAccessor = dbAccessor;

            _ID = iD;
            _R025 = r25;
            _R033 = r33;
            _R035 = r35;
            _R037 = r37;
            _R039 = r39;
            _R041 = r41;
            _R043 = r43;
            _R043_1 = r43_1;
            _R053 = r53;
            _R059 = r59;
            _R061 = r61;
            _R063 = r63;
            _R065 = r65;
            _R067 = r67;
            _R069 = r69;
            _R071 = r71;
            _R079 = r73;
            _R119 = r119;
            _R121 = r121;
            _R123 = r123;
            _R125 = r125;
            _R127 = r127;
            _R129 = r129;
            _R159 = r159;
            _R161 = r161;
            _R163 = r163;
            _R165 = r165;
            _R167 = r167;
            _R211 = r211;
        }
        #endregion

        public static T900 FromCoilNo(string coilNo)
        {
            DBAccessor dbAccessor = null;
            try
            {
                dbAccessor = new DBAccessor();
                
                WhereParameterCollection whereColl = new WhereParameterCollection();
                whereColl.Add(R025__COLUMN_NAME, coilNo, CompareType.Like);

                SortParameterCollection sortColl = new SortParameterCollection();
                sortColl.Add(ID__COLUMN_NAME, SortType.Decrease);

                DataSet ds = dbAccessor.GetTable(TABLE_NAME, whereColl, sortColl);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    object objID = ds.Tables[0].Rows[0][ID__COLUMN_NAME];
                    
                    //object objID = dbAccessor.GetTable(TABLE_NAME, whereColl, sortColl);
                    if (objID != null && objID != DBNull.Value)
                    {
                        return new T900(Convert.ToInt32(objID));
                    }
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

        protected void NewRowsChild()
        {
            for (int i = 0; i < _RowsChild.Length; i++)
            {
                _RowsChild[i] = new T_R_RowSet();
            }
        }

        #region Insert/Update/Delete
        public int Insert()
        {
            ParameterCollection coll = new ParameterCollection();
            coll.Add(new Parameter(R025__COLUMN_NAME, _R025));
            coll.Add(new Parameter(R033__COLUMN_NAME, _R033));
            coll.Add(new Parameter(R035__COLUMN_NAME, _R035));
            coll.Add(new Parameter(R037__COLUMN_NAME, _R037));
            coll.Add(new Parameter(R039__COLUMN_NAME, _R039));
            coll.Add(new Parameter(R041__COLUMN_NAME, _R041));
            coll.Add(new Parameter(R043__COLUMN_NAME, _R043));
            coll.Add(new Parameter(R043_1__COLUMN_NAME, _R043_1));
            coll.Add(new Parameter(R053__COLUMN_NAME, _R053));
            coll.Add(new Parameter(R059__COLUMN_NAME, _R059));
            coll.Add(new Parameter(R061__COLUMN_NAME, _R061));
            coll.Add(new Parameter(R063__COLUMN_NAME, _R063));
            coll.Add(new Parameter(R065__COLUMN_NAME, _R065));
            coll.Add(new Parameter(R067__COLUMN_NAME, _R067));
            coll.Add(new Parameter(R069__COLUMN_NAME, _R069));
            coll.Add(new Parameter(R071__COLUMN_NAME, _R071));
            coll.Add(new Parameter(R073__COLUMN_NAME, _R079));
            coll.Add(new Parameter(R119__COLUMN_NAME, _R119));
            coll.Add(new Parameter(R121__COLUMN_NAME, _R121));
            coll.Add(new Parameter(R123__COLUMN_NAME, _R123));
            coll.Add(new Parameter(R125__COLUMN_NAME, _R125));
            coll.Add(new Parameter(R127__COLUMN_NAME, _R127));
            coll.Add(new Parameter(R129__COLUMN_NAME, _R129));
            coll.Add(new Parameter(R159__COLUMN_NAME, _R159));
            coll.Add(new Parameter(R161__COLUMN_NAME, _R161));
            coll.Add(new Parameter(R163__COLUMN_NAME, _R163));
            coll.Add(new Parameter(R165__COLUMN_NAME, _R165));
            coll.Add(new Parameter(R167__COLUMN_NAME, _R167));
            coll.Add(new Parameter(R211__COLUMN_NAME, _R211));
            coll.Add(new Parameter(LASTUPDATE__COLUMN_NAME, DateTime.Now));
            
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
                    R081 = new T900_I2_19(0, T900_Mapping.GetRowID(T900_Mapping.R081), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                }
                _RowsChild[0].Row.DBAccessor = this._DBAccessor;
                _RowsChild[0].Row.ParentID = _ID;
                _RowsChild[0].Row.Insert();

                if (_RowsChild[1].Row == null)
                {
                    R131 = new T900_I2_07(0, T900_Mapping.GetRowID(T900_Mapping.R131), 0, 0, 0, 0, 0, 0, 0);
                }
                _RowsChild[1].Row.DBAccessor = this._DBAccessor;
                _RowsChild[1].Row.ParentID = _ID;
                _RowsChild[1].Row.Insert();

                if (_RowsChild[2].Row == null)
                {
                    R145 = new T900_I2_07(0, T900_Mapping.GetRowID(T900_Mapping.R145), 0, 0, 0, 0, 0, 0, 0);
                }
                _RowsChild[2].Row.DBAccessor = this._DBAccessor;
                _RowsChild[2].Row.ParentID = _ID;
                _RowsChild[2].Row.Insert();

                if (_RowsChild[3].Row == null)
                {
                    R169 = new T900_I2_07(0, T900_Mapping.GetRowID(T900_Mapping.R169), 0, 0, 0, 0, 0, 0, 0);
                }
                _RowsChild[3].Row.DBAccessor = this._DBAccessor;
                _RowsChild[3].Row.ParentID = _ID;
                _RowsChild[3].Row.Insert();

                if (_RowsChild[4].Row == null)
                {
                    R183 = new T900_I2_07(0, T900_Mapping.GetRowID(T900_Mapping.R183), 0, 0, 0, 0, 0, 0, 0);
                }
                _RowsChild[4].Row.DBAccessor = this._DBAccessor;
                _RowsChild[4].Row.ParentID = _ID;
                _RowsChild[4].Row.Insert();

                if (_RowsChild[5].Row == null)
                {
                    R197 = new T900_I2_07(0, T900_Mapping.GetRowID(T900_Mapping.R197), 0, 0, 0, 0, 0, 0, 0);
                }
                _RowsChild[5].Row.DBAccessor = this._DBAccessor;
                _RowsChild[5].Row.ParentID = _ID;
                _RowsChild[5].Row.Insert();

                if (_RowsChild[6].Row == null)
                {
                    R213 = new T900_I2_07(0, T900_Mapping.GetRowID(T900_Mapping.R213), 0, 0, 0, 0, 0, 0, 0);
                }
                _RowsChild[6].Row.DBAccessor = this._DBAccessor;
                _RowsChild[6].Row.ParentID = _ID;
                _RowsChild[6].Row.Insert();

                if (_RowsChild[7].Row == null)
                {
                    R227 = new T900_I2_07(0, T900_Mapping.GetRowID(T900_Mapping.R227), 0, 0, 0, 0, 0, 0, 0);
                }
                _RowsChild[7].Row.DBAccessor = this._DBAccessor;
                _RowsChild[7].Row.ParentID = _ID;
                _RowsChild[7].Row.Insert();

                if (_RowsChild[8].Row == null)
                {
                    R241 = new T900_I2_07(0, T900_Mapping.GetRowID(T900_Mapping.R241), 0, 0, 0, 0, 0, 0, 0);
                }
                _RowsChild[8].Row.DBAccessor = this._DBAccessor;
                _RowsChild[8].Row.ParentID = _ID;
                _RowsChild[8].Row.Insert();

                if (_RowsChild[9].Row == null)
                {
                    R255 = new T900_I2_07(0, T900_Mapping.GetRowID(T900_Mapping.R255), 0, 0, 0, 0, 0, 0, 0);
                }
                _RowsChild[9].Row.DBAccessor = this._DBAccessor;
                _RowsChild[9].Row.ParentID = _ID;
                _RowsChild[9].Row.Insert();

                if (_RowsChild[10].Row == null)
                {
                    R269 = new T900_I2_07(0, T900_Mapping.GetRowID(T900_Mapping.R269), 0, 0, 0, 0, 0, 0, 0);
                }
                _RowsChild[10].Row.DBAccessor = this._DBAccessor;
                _RowsChild[10].Row.ParentID = _ID;
                _RowsChild[10].Row.Insert();

                if (_RowsChild[11].Row == null)
                {
                    R283 = new T900_I2_07(0, T900_Mapping.GetRowID(T900_Mapping.R283), 0, 0, 0, 0, 0, 0, 0);
                }
                _RowsChild[11].Row.DBAccessor = this._DBAccessor;
                _RowsChild[11].Row.ParentID = _ID;
                _RowsChild[11].Row.Insert();

                if (_RowsChild[12].Row == null)
                {
                    R297 = new T900_I2_07(0, T900_Mapping.GetRowID(T900_Mapping.R297), 0, 0, 0, 0, 0, 0, 0);
                }
                _RowsChild[12].Row.DBAccessor = this._DBAccessor;
                _RowsChild[12].Row.ParentID = _ID;
                _RowsChild[12].Row.Insert();

                if (_RowsChild[13].Row == null)
                {
                    R311 = new T900_I2_07(0, T900_Mapping.GetRowID(T900_Mapping.R311), 0, 0, 0, 0, 0, 0, 0);
                }
                _RowsChild[13].Row.DBAccessor = this._DBAccessor;
                _RowsChild[13].Row.ParentID = _ID;
                _RowsChild[13].Row.Insert();

                if (_RowsChild[14].Row == null)
                {
                    R325 = new T900_I2_07(0, T900_Mapping.GetRowID(T900_Mapping.R325), 0, 0, 0, 0, 0, 0, 0);
                }
                _RowsChild[14].Row.DBAccessor = this._DBAccessor;
                _RowsChild[14].Row.ParentID = _ID;
                _RowsChild[14].Row.Insert();

                if (_RowsChild[15].Row == null)
                {
                    R339 = new T900_I2_07(0, T900_Mapping.GetRowID(T900_Mapping.R339), 0, 0, 0, 0, 0, 0, 0);
                }
                _RowsChild[15].Row.DBAccessor = this._DBAccessor;
                _RowsChild[15].Row.ParentID = _ID;
                _RowsChild[15].Row.Insert();

                if (_RowsChild[16].Row == null)
                {
                    R353 = new T900_I2_07(0, T900_Mapping.GetRowID(T900_Mapping.R353), 0, 0, 0, 0, 0, 0, 0);
                }
                _RowsChild[16].Row.DBAccessor = this._DBAccessor;
                _RowsChild[16].Row.ParentID = _ID;
                _RowsChild[16].Row.Insert();

                if (_RowsChild[17].Row == null)
                {
                    R367 = new T900_I2_06(0, T900_Mapping.GetRowID(T900_Mapping.R367), 0, 0, 0, 0, 0, 0);
                }
                _RowsChild[17].Row.DBAccessor = this._DBAccessor;
                _RowsChild[17].Row.ParentID = _ID;
                _RowsChild[17].Row.Insert();

                if (_RowsChild[18].Row == null)
                {
                    R379 = new T900_I2_06(0, T900_Mapping.GetRowID(T900_Mapping.R379), 0, 0, 0, 0, 0, 0);
                }
                _RowsChild[18].Row.DBAccessor = this._DBAccessor;
                _RowsChild[18].Row.ParentID = _ID;
                _RowsChild[18].Row.Insert();

                if (_RowsChild[19].Row == null)
                {
                    R391 = new T900_I2_07(0, T900_Mapping.GetRowID(T900_Mapping.R391), 0, 0, 0, 0, 0, 0, 0);
                }
                _RowsChild[19].Row.DBAccessor = this._DBAccessor;
                _RowsChild[19].Row.ParentID = _ID;
                _RowsChild[19].Row.Insert();

                if (_RowsChild[20].Row == null)
                {
                    R405 = new T900_I2_07(0, T900_Mapping.GetRowID(T900_Mapping.R405), 0, 0, 0, 0, 0, 0, 0);
                }
                _RowsChild[20].Row.DBAccessor = this._DBAccessor;
                _RowsChild[20].Row.ParentID = _ID;
                _RowsChild[20].Row.Insert();

                if (_RowsChild[21].Row == null)
                {
                    R419 = new T900_I2_07(0, T900_Mapping.GetRowID(T900_Mapping.R419), 0, 0, 0, 0, 0, 0, 0);
                }
                _RowsChild[21].Row.DBAccessor = this._DBAccessor;
                _RowsChild[21].Row.ParentID = _ID;
                _RowsChild[21].Row.Insert();

                if (_RowsChild[22].Row == null)
                {
                    R433 = new T900_I2_07(0, T900_Mapping.GetRowID(T900_Mapping.R433), 0, 0, 0, 0, 0, 0, 0);
                }
                _RowsChild[22].Row.DBAccessor = this._DBAccessor;
                _RowsChild[22].Row.ParentID = _ID;
                _RowsChild[22].Row.Insert();

                if (_RowsChild[23].Row == null)
                {
                    R447 = new T900_I2_07(0, T900_Mapping.GetRowID(T900_Mapping.R447), 0, 0, 0, 0, 0, 0, 0);
                }
                _RowsChild[23].Row.DBAccessor = this._DBAccessor;
                _RowsChild[23].Row.ParentID = _ID;
                _RowsChild[23].Row.Insert();

                if (_RowsChild[24].Row == null)
                {
                    R501 = new T900_C6_07(0, T900_Mapping.GetRowID(T900_Mapping.R501), "      ", "      ", "      ", "      ", "      ", "      ", "      ");
                }
                _RowsChild[24].Row.DBAccessor = this._DBAccessor;
                _RowsChild[24].Row.ParentID = _ID;
                _RowsChild[24].Row.Insert();

                if (_RowsChild[25].Row == null)
                {
                    R543 = new T900_C2_07(0, T900_Mapping.GetRowID(T900_Mapping.R543), "  ", "  ", "  ", "  ", "  ", "  ", "  ");
                }
                _RowsChild[25].Row.DBAccessor = this._DBAccessor;
                _RowsChild[25].Row.ParentID = _ID;
                _RowsChild[25].Row.Insert();

                if (_RowsChild[26].Row == null)
                {
                    R557 = new T900_I4_07(0, T900_Mapping.GetRowID(T900_Mapping.R557), 0, 0, 0, 0, 0, 0, 0);
                }
                _RowsChild[26].Row.DBAccessor = this._DBAccessor;
                _RowsChild[26].Row.ParentID = _ID;
                _RowsChild[26].Row.Insert();

                if (_RowsChild[27].Row == null)
                {
                    R585 = new T900_I2_07(0, T900_Mapping.GetRowID(T900_Mapping.R585), 0, 0, 0, 0, 0, 0, 0);
                }
                _RowsChild[27].Row.DBAccessor = this._DBAccessor;
                _RowsChild[27].Row.ParentID = _ID;
                _RowsChild[27].Row.Insert();

                if (_RowsChild[28].Row == null)
                {
                    R599 = new T900_I2_07(0, T900_Mapping.GetRowID(T900_Mapping.R599), 0, 0, 0, 0, 0, 0, 0);
                }
                _RowsChild[28].Row.DBAccessor = this._DBAccessor;
                _RowsChild[28].Row.ParentID = _ID;
                _RowsChild[28].Row.Insert();

                if (_RowsChild[29].Row == null)
                {
                    R613 = new T900_I2_07(0, T900_Mapping.GetRowID(T900_Mapping.R613), 0, 0, 0, 0, 0, 0, 0);
                }
                _RowsChild[29].Row.DBAccessor = this._DBAccessor;
                _RowsChild[29].Row.ParentID = _ID;
                _RowsChild[29].Row.Insert();

                if (_RowsChild[30].Row == null)
                {
                    R627 = new T900_C6_14(0, T900_Mapping.GetRowID(T900_Mapping.R627), "      ", "      ", "      ", "      ", "      ", "      ", "      ", "      ", "      ", "      ", "      ", "      ", "      ", "      ");
                }
                _RowsChild[30].Row.DBAccessor = this._DBAccessor;
                _RowsChild[30].Row.ParentID = _ID;
                _RowsChild[30].Row.Insert();

                if (_RowsChild[31].Row == null)
                {
                    R713 = new T900_I4_14(0, T900_Mapping.GetRowID(T900_Mapping.R713), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                }
                _RowsChild[31].Row.DBAccessor = this._DBAccessor;
                _RowsChild[31].Row.ParentID = _ID;
                _RowsChild[31].Row.Insert();

                if (_RowsChild[32].Row == null)
                {
                    R801 = new T900_I2_07(0, T900_Mapping.GetRowID(T900_Mapping.R801), 0, 0, 0, 0, 0, 0, 0);
                }
                _RowsChild[32].Row.DBAccessor = this._DBAccessor;
                _RowsChild[32].Row.ParentID = _ID;
                _RowsChild[32].Row.Insert();

                if (_RowsChild[33].Row == null)
                {
                    R815 = new T900_I2_07(0, T900_Mapping.GetRowID(T900_Mapping.R815), 0, 0, 0, 0, 0, 0, 0);
                }
                _RowsChild[33].Row.DBAccessor = this._DBAccessor;
                _RowsChild[33].Row.ParentID = _ID;
                _RowsChild[33].Row.Insert();

                if (_RowsChild[34].Row == null)
                {
                    R851 = new T900_I2_07(0, T900_Mapping.GetRowID(T900_Mapping.R851), 0, 0, 0, 0, 0, 0, 0);
                }
                _RowsChild[34].Row.DBAccessor = this._DBAccessor;
                _RowsChild[34].Row.ParentID = _ID;
                _RowsChild[34].Row.Insert();

                this._DBAccessor.CommitTransaction();

            }
            catch (Exception ex)
            {
                if (this._DBAccessor != null)
                {
                    this._DBAccessor.RollbackTransaction();
                }
                _ID = 0;
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
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
            if (_ID < 1)
            {
                return 0;
            }
            ParameterCollection coll = new ParameterCollection();
            coll.Add(new Parameter(R025__COLUMN_NAME, _R025));
            coll.Add(new Parameter(R033__COLUMN_NAME, _R033));
            coll.Add(new Parameter(R035__COLUMN_NAME, _R035));
            coll.Add(new Parameter(R037__COLUMN_NAME, _R037));
            coll.Add(new Parameter(R039__COLUMN_NAME, _R039));
            coll.Add(new Parameter(R041__COLUMN_NAME, _R041));
            coll.Add(new Parameter(R043__COLUMN_NAME, _R043));
            coll.Add(new Parameter(R043_1__COLUMN_NAME, _R043_1));
            coll.Add(new Parameter(R053__COLUMN_NAME, _R053));
            coll.Add(new Parameter(R059__COLUMN_NAME, _R059));
            coll.Add(new Parameter(R061__COLUMN_NAME, _R061));
            coll.Add(new Parameter(R063__COLUMN_NAME, _R063));
            coll.Add(new Parameter(R065__COLUMN_NAME, _R065));
            coll.Add(new Parameter(R067__COLUMN_NAME, _R067));
            coll.Add(new Parameter(R069__COLUMN_NAME, _R069));
            coll.Add(new Parameter(R071__COLUMN_NAME, _R071));
            coll.Add(new Parameter(R073__COLUMN_NAME, _R079));
            coll.Add(new Parameter(R119__COLUMN_NAME, _R119));
            coll.Add(new Parameter(R121__COLUMN_NAME, _R121));
            coll.Add(new Parameter(R123__COLUMN_NAME, _R123));
            coll.Add(new Parameter(R125__COLUMN_NAME, _R125));
            coll.Add(new Parameter(R127__COLUMN_NAME, _R127));
            coll.Add(new Parameter(R129__COLUMN_NAME, _R129));
            coll.Add(new Parameter(R159__COLUMN_NAME, _R159));
            coll.Add(new Parameter(R161__COLUMN_NAME, _R161));
            coll.Add(new Parameter(R163__COLUMN_NAME, _R163));
            coll.Add(new Parameter(R165__COLUMN_NAME, _R165));
            coll.Add(new Parameter(R167__COLUMN_NAME, _R167));
            coll.Add(new Parameter(R211__COLUMN_NAME, _R211));
            coll.Add(new Parameter(LASTUPDATE__COLUMN_NAME, DateTime.Now));

            WhereParameterCollection whereColl = new WhereParameterCollection();
            whereColl.Add(new WhereParameter(ID__COLUMN_NAME, _ID, CompareType.Equal));

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
                        _RowsChild[i].Row.RowID = T900_Mapping.GetRowID(T900_Mapping.RowsName[i]);
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
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
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
            whereColl.Add(new WhereParameter(ID__COLUMN_NAME, _ID, CompareType.Equal));

            if (!this.db_Set)
            {
                _DBAccessor = new DBAccessor();
            }
            try
            {
                return _DBAccessor.Delete(TABLE_NAME, whereColl);
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
        #endregion

        protected void FromDataRow(DataRow row)
        {
            _ID = (int)row[ID__COLUMN_NAME];
            _R025 = row[R025__COLUMN_NAME] == DBNull.Value ? "" : (string)(row[R025__COLUMN_NAME]);
            _R033 = row[R033__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R033__COLUMN_NAME]);
            _R035 = row[R035__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R035__COLUMN_NAME]);
            _R037 = row[R037__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R037__COLUMN_NAME]);
            _R039 = row[R039__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R039__COLUMN_NAME]);
            _R041 = row[R041__COLUMN_NAME] == DBNull.Value ? "" : (string)(row[R041__COLUMN_NAME]);
            _R043 = row[R043__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R043__COLUMN_NAME]);
            _R043_1 = row[R043_1__COLUMN_NAME] == DBNull.Value ? "" : (string)(row[R043_1__COLUMN_NAME]);
            _R053 = row[R053__COLUMN_NAME] == DBNull.Value ? "" : (string)(row[R053__COLUMN_NAME]);
            _R059 = row[R059__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R059__COLUMN_NAME]);
            _R061 = row[R061__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R061__COLUMN_NAME]);
            _R063 = row[R063__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R063__COLUMN_NAME]);
            _R065 = row[R065__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R065__COLUMN_NAME]);
            _R067 = row[R067__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R067__COLUMN_NAME]);
            _R069 = row[R069__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R069__COLUMN_NAME]);
            _R071 = row[R071__COLUMN_NAME] == DBNull.Value ? "" : (string)(row[R071__COLUMN_NAME]);
            _R079 = row[R073__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R073__COLUMN_NAME]);
            _R119 = row[R119__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R119__COLUMN_NAME]);
            _R121 = row[R121__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R121__COLUMN_NAME]);
            _R123 = row[R123__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R123__COLUMN_NAME]);
            _R125 = row[R125__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R125__COLUMN_NAME]);
            _R127 = row[R127__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R127__COLUMN_NAME]);
            _R129 = row[R129__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R129__COLUMN_NAME]);
            _R159 = row[R159__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R159__COLUMN_NAME]);
            _R161 = row[R161__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R161__COLUMN_NAME]);
            _R163 = row[R163__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R163__COLUMN_NAME]);
            _R165 = row[R165__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R165__COLUMN_NAME]);
            _R167 = row[R167__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R167__COLUMN_NAME]);
            _R211 = row[R211__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R211__COLUMN_NAME]);
            _LastUpdate = row[LASTUPDATE__COLUMN_NAME] == DBNull.Value ? DateTime.Now : (DateTime)row[LASTUPDATE__COLUMN_NAME];
        }

        public static T900 GetLast()
        {
            DBAccessor db = null;
            try
            {
                db = new DBAccessor();
                object obj = db.MaxValue(TABLE_NAME, ID__COLUMN_NAME);

                if (obj != null && obj != DBNull.Value)
                {
                    int maxId = Convert.ToInt32(obj);

                    return new T900(maxId);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db != null)
                {
                    db.Dispose();
                }
            }
        }
        public static T900 GetLast(DBAccessor db)
        {
            object obj = db.MaxValue(TABLE_NAME, ID__COLUMN_NAME);

            if (obj != null && obj != DBNull.Value)
            {
                int maxId = Convert.ToInt32(obj);

                T900 t900 = new T900(db, maxId);
                t900.DBAccessor = null;
                return t900;
            }

            return null;
        }

        public static long RecordCount()
        {
            DBAccessor db = null;
            try
            {
                db = new DBAccessor();
                return db.RecordCount(TABLE_NAME);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db != null)
                {
                    db.Dispose();
                }
            }
        }
        public static long RecordCount(DBAccessor db)
        {
            return db.RecordCount(TABLE_NAME);
        }

        public DataSet GetAll()
        {
            if (!this.db_Set)
            {
                _DBAccessor = new DBAccessor();
            }
            try
            {
                DataSet ds = _DBAccessor.GetTable(TABLE_NAME);
                return ds;
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

        public static T900 Parse(Byte[] data)
        {
            if (data == null || data.Length != 884)
            {
                return null;
            }

            T900 t900 = new T900();

            t900.ID = 0;

            try
            {
                t900.R025 = Common.GetString(data, 8, 8);
                t900.R033 = Common.ToInt16(data, 16);
                if (t900.R033 < 100)
                {
                    t900.R033 += 2000;
                    t900.R033 = (Int16)(t900.R033 > DateTime.Now.Year ? (t900.R033 - 100) : t900.R033);
                }
                t900.R035 = Common.ToInt16(data, 18);
                t900.R037 = Common.ToInt16(data, 20);
                t900.R039 = Common.ToInt16(data, 22);
                t900.R041 = Common.GetString(data, 24, 2);
                t900.R043 = Common.ToInt16(data, 26);
                t900.R043_1 = Common.GetString(data, 28, 10);
                t900.R053 = Common.GetString(data, 38, 6);
                t900.R059 = Common.ToInt16(data, 44);
                t900.R061 = Common.ToInt16(data, 46);
                t900.R063 = Common.ToInt16(data, 48);
                t900.R065 = Common.ToInt16(data, 50);
                t900.R067 = Common.ToInt16(data, 52);
                t900.R069 = Common.ToInt16(data, 54);

                t900.R071 = Common.GetString(data, 56, 8);
                t900.R079 = Common.ToInt16(data, 64);

                t900.R081 = T900_I2_19.Parse(data, 66);

                t900.R119 = Common.ToInt16(data, 104);
                t900.R121 = Common.ToInt16(data, 106);
                t900.R123 = Common.ToInt16(data, 108);
                t900.R125 = Common.ToInt16(data, 110);
                t900.R127 = Common.ToInt16(data, 112);
                t900.R129 = Common.ToInt16(data, 114);

                t900.R131 = T900_I2_07.Parse(data, 116);
                t900.R145 = T900_I2_07.Parse(data, 130);

                t900.R159 = Common.ToInt16(data, 144);
                t900.R161 = Common.ToInt16(data, 146);
                t900.R163 = Common.ToInt16(data, 148);
                t900.R165 = Common.ToInt16(data, 150);
                t900.R167 = Common.ToInt16(data, 152);

                t900.R169 = T900_I2_07.Parse(data, 154);
                t900.R183 = T900_I2_07.Parse(data, 168);
                t900.R197 = T900_I2_07.Parse(data, 182);
                t900.R211 = Common.ToInt16(data, 196);
                t900.R213 = T900_I2_07.Parse(data, 198);
                t900.R227 = T900_I2_07.Parse(data, 212);
                t900.R241 = T900_I2_07.Parse(data, 226);
                t900.R255 = T900_I2_07.Parse(data, 240);
                t900.R269 = T900_I2_07.Parse(data, 254);
                t900.R283 = T900_I2_07.Parse(data, 278);
                t900.R297 = T900_I2_07.Parse(data, 282);
                t900.R311 = T900_I2_07.Parse(data, 296);
                t900.R325 = T900_I2_07.Parse(data, 310);
                t900.R339 = T900_I2_07.Parse(data, 324);
                t900.R353 = T900_I2_07.Parse(data, 338);
                t900.R367 = T900_I2_06.Parse(data, 352);
                t900.R379 = T900_I2_06.Parse(data, 364);
                t900.R391 = T900_I2_07.Parse(data, 376);
                t900.R405 = T900_I2_07.Parse(data, 390);
                t900.R419 = T900_I2_07.Parse(data, 404);
                t900.R433 = T900_I2_07.Parse(data, 418);
                t900.R447 = T900_I2_07.Parse(data, 432);

                t900.R501 = T900_C6_07.Parse(data, 484);

                t900.R543 = T900_C2_07.Parse(data, 526);

                t900.R557 = T900_I4_07.Parse(data, 540);

                t900.R585 = T900_I2_07.Parse(data, 568);
                t900.R599 = T900_I2_07.Parse(data, 582);
                t900.R613 = T900_I2_07.Parse(data, 596);

                t900.R627 = T900_C6_14.Parse(data, 610);

                t900.R713 = T900_I4_14.Parse(data, 696);

                t900.R801 = T900_I2_07.Parse(data, 784);
                t900.R815 = T900_I2_07.Parse(data, 798);
                t900.R851 = T900_I2_07.Parse(data, 834);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            return t900;
        }
        public Byte[] GetBytes()
        {

            Byte[] data = new Byte[884];

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

                Buffer.BlockCopy(Common.GetBytes(_R071), 0, data, 56, 8);

                Buffer.BlockCopy(Common.GetBytes(_R079), 0, data, 64, 2);

                Buffer.BlockCopy(R081.GetBytes(), 0, data, 66, 38);

                Buffer.BlockCopy(Common.GetBytes(_R119), 0, data, 104, 2);
                Buffer.BlockCopy(Common.GetBytes(_R121), 0, data, 106, 2);
                Buffer.BlockCopy(Common.GetBytes(_R123), 0, data, 108, 2);
                Buffer.BlockCopy(Common.GetBytes(_R125), 0, data, 110, 2);
                Buffer.BlockCopy(Common.GetBytes(_R127), 0, data, 112, 2);
                Buffer.BlockCopy(Common.GetBytes(_R129), 0, data, 114, 2);

                Buffer.BlockCopy(R131.GetBytes(), 0, data, 116, 14);
                Buffer.BlockCopy(R145.GetBytes(), 0, data, 130, 14);

                Buffer.BlockCopy(Common.GetBytes(R159), 0, data, 144, 2);
                Buffer.BlockCopy(Common.GetBytes(R161), 0, data, 146, 2);
                Buffer.BlockCopy(Common.GetBytes(R163), 0, data, 148, 2);
                Buffer.BlockCopy(Common.GetBytes(R165), 0, data, 150, 2);
                Buffer.BlockCopy(Common.GetBytes(R167), 0, data, 152, 2);

                Buffer.BlockCopy(R169.GetBytes(), 0, data, 154, 14);
                Buffer.BlockCopy(R183.GetBytes(), 0, data, 168, 14);
                Buffer.BlockCopy(R197.GetBytes(), 0, data, 182, 14);

                Buffer.BlockCopy(Common.GetBytes(R211), 0, data, 196, 2);

                Buffer.BlockCopy(R213.GetBytes(), 0, data, 198, 14);
                Buffer.BlockCopy(R227.GetBytes(), 0, data, 212, 14);
                Buffer.BlockCopy(R241.GetBytes(), 0, data, 226, 14);
                Buffer.BlockCopy(R255.GetBytes(), 0, data, 240, 14);
                Buffer.BlockCopy(R269.GetBytes(), 0, data, 254, 14);
                Buffer.BlockCopy(R283.GetBytes(), 0, data, 268, 14);
                Buffer.BlockCopy(R297.GetBytes(), 0, data, 282, 14);
                Buffer.BlockCopy(R311.GetBytes(), 0, data, 296, 14);
                Buffer.BlockCopy(R325.GetBytes(), 0, data, 310, 14);
                Buffer.BlockCopy(R339.GetBytes(), 0, data, 324, 14);
                Buffer.BlockCopy(R353.GetBytes(), 0, data, 338, 14);
                Buffer.BlockCopy(R367.GetBytes(), 0, data, 352, 12);
                Buffer.BlockCopy(R379.GetBytes(), 0, data, 364, 12);
                Buffer.BlockCopy(R391.GetBytes(), 0, data, 376, 14);
                Buffer.BlockCopy(R405.GetBytes(), 0, data, 390, 14);
                Buffer.BlockCopy(R419.GetBytes(), 0, data, 404, 14);
                Buffer.BlockCopy(R433.GetBytes(), 0, data, 418, 14);
                Buffer.BlockCopy(R447.GetBytes(), 0, data, 432, 14);

                Buffer.BlockCopy(R501.GetBytes(), 0, data, 484, 42);

                Buffer.BlockCopy(R543.GetBytes(), 0, data, 526, 14);

                Buffer.BlockCopy(R557.GetBytes(), 0, data, 540, 28);

                Buffer.BlockCopy(R585.GetBytes(), 0, data, 568, 14);
                Buffer.BlockCopy(R599.GetBytes(), 0, data, 582, 14);
                Buffer.BlockCopy(R613.GetBytes(), 0, data, 596, 14);

                Buffer.BlockCopy(R627.GetBytes(), 0, data, 610, 84);

                Buffer.BlockCopy(R713.GetBytes(), 0, data, 696, 56);

                Buffer.BlockCopy(R801.GetBytes(), 0, data, 784, 14);
                Buffer.BlockCopy(R815.GetBytes(), 0, data, 798, 14);
                Buffer.BlockCopy(R851.GetBytes(), 0, data, 834, 14);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            return data;
        }

        public bool Equals(T900 t900)
        {
            if (t900 == null)
            {
                return false;
            }
            if (
                !_R025.Equals(t900.R025) ||
                _R033 != t900.R033 ||
                _R035 != t900.R035 ||
                _R037 != t900.R037 ||
                _R039 != t900.R039 ||
                !_R041.Equals(t900.R041) ||
                _R043 != t900.R043 ||
                !_R043_1.Equals(t900.R043_1) ||
                !_R053.Equals(t900.R053) ||
                _R059 != t900.R059 ||
                _R061 != t900.R061 ||
                _R063 != t900.R063 ||
                _R065 != t900.R065 ||
                _R067 != t900.R067 ||
                _R069 != t900.R069 ||
                !_R071.Equals(t900.R071) ||
                _R079 != t900.R079 ||
                _R119 != t900.R119 ||
                _R121 != t900.R121 ||
                _R123 != t900.R123 ||
                _R125 != t900.R125 ||
                _R127 != t900.R127 ||
                _R129 != t900.R129 ||
                _R159 != t900.R159 ||
                _R161 != t900.R161 ||
                _R163 != t900.R163 ||
                _R165 != t900.R165 ||
                _R167 != t900.R167 ||
                _R211 != t900.R211)
                return false;
            
            if ((R081 == null && t900.R081 != null) || (R081 != null && t900.R081 == null) || !R081.Equals(t900.R081)) return false;
            if ((R131 == null && t900.R131 != null) || (R131 != null && t900.R131 == null) || !R131.Equals(t900.R131)) return false;
            if ((R145 == null && t900.R145 != null) || (R145 != null && t900.R145 == null) || !R145.Equals(t900.R145)) return false;
            if ((R169 == null && t900.R169 != null) || (R169 != null && t900.R169 == null) || !R169.Equals(t900.R169)) return false;
            if ((R183 == null && t900.R183 != null) || (R183 != null && t900.R183 == null) || !R183.Equals(t900.R183)) return false;
            if ((R197 == null && t900.R197 != null) || (R197 != null && t900.R197 == null) || !R197.Equals(t900.R197)) return false;
            if ((R213 == null && t900.R213 != null) || (R213 != null && t900.R213 == null) || !R213.Equals(t900.R213)) return false;
            if ((R227 == null && t900.R227 != null) || (R227 != null && t900.R227 == null) || !R227.Equals(t900.R227)) return false;
            if ((R241 == null && t900.R241 != null) || (R241 != null && t900.R241 == null) || !R241.Equals(t900.R241)) return false;
            if ((R255 == null && t900.R255 != null) || (R255 != null && t900.R255 == null) || !R255.Equals(t900.R255)) return false;
            if ((R269 == null && t900.R269 != null) || (R269 != null && t900.R269 == null) || !R269.Equals(t900.R269)) return false;
            if ((R283 == null && t900.R283 != null) || (R283 != null && t900.R283 == null) || !R283.Equals(t900.R283)) return false;
            if ((R297 == null && t900.R297 != null) || (R297 != null && t900.R297 == null) || !R297.Equals(t900.R297)) return false;
            if ((R311 == null && t900.R311 != null) || (R311 != null && t900.R311 == null) || !R311.Equals(t900.R311)) return false;
            if ((R325 == null && t900.R325 != null) || (R325 != null && t900.R325 == null) || !R325.Equals(t900.R325)) return false;
            if ((R339 == null && t900.R339 != null) || (R339 != null && t900.R339 == null) || !R339.Equals(t900.R339)) return false;
            if ((R353 == null && t900.R353 != null) || (R353 != null && t900.R353 == null) || !R353.Equals(t900.R353)) return false;
            if ((R367 == null && t900.R367 != null) || (R367 != null && t900.R367 == null) || !R367.Equals(t900.R367)) return false;
            if ((R379 == null && t900.R379 != null) || (R379 != null && t900.R379 == null) || !R379.Equals(t900.R379)) return false;
            if ((R391 == null && t900.R391 != null) || (R391 != null && t900.R391 == null) || !R391.Equals(t900.R391)) return false;
            if ((R405 == null && t900.R405 != null) || (R405 != null && t900.R405 == null) || !R405.Equals(t900.R405)) return false;
            if ((R419 == null && t900.R419 != null) || (R419 != null && t900.R419 == null) || !R419.Equals(t900.R419)) return false;
            if ((R433 == null && t900.R433 != null) || (R433 != null && t900.R433 == null) || !R433.Equals(t900.R433)) return false;
            if ((R447 == null && t900.R447 != null) || (R447 != null && t900.R447 == null) || !R447.Equals(t900.R447)) return false;
            if ((R501 == null && t900.R501 != null) || (R501 != null && t900.R501 == null) || !R501.Equals(t900.R501)) return false;
            if ((R543 == null && t900.R543 != null) || (R543 != null && t900.R543 == null) || !R543.Equals(t900.R543)) return false;
            if ((R557 == null && t900.R557 != null) || (R557 != null && t900.R557 == null) || !R557.Equals(t900.R557)) return false;
            if ((R585 == null && t900.R585 != null) || (R585 != null && t900.R585 == null) || !R585.Equals(t900.R585)) return false;
            if ((R599 == null && t900.R599 != null) || (R599 != null && t900.R599 == null) || !R599.Equals(t900.R599)) return false;
            if ((R613 == null && t900.R613 != null) || (R613 != null && t900.R613 == null) || !R613.Equals(t900.R613)) return false;
            if ((R627 == null && t900.R627 != null) || (R627 != null && t900.R627 == null) || !R627.Equals(t900.R627)) return false;
            if ((R713 == null && t900.R713 != null) || (R713 != null && t900.R713 == null) || !R713.Equals(t900.R713)) return false;
            if ((R801 == null && t900.R801 != null) || (R801 != null && t900.R801 == null) || !R801.Equals(t900.R801)) return false;
            if ((R815 == null && t900.R815 != null) || (R815 != null && t900.R815 == null) || !R815.Equals(t900.R815)) return false;
            if ((R851 == null && t900.R851 != null) || (R851 != null && t900.R851 == null) || !R851.Equals(t900.R851)) return false;
            
            return true;
        }

        public T900 GetPreviousPreset()
        {
            if (_ID > 1)
            {
                WhereParameterCollection whereColl = new WhereParameterCollection();
                whereColl.Add(ID__COLUMN_NAME, _ID, CompareType.Less);
                whereColl.Add(R025__COLUMN_NAME, R025, CompareType.NotLike);
                whereColl.Add(R033__COLUMN_NAME, R033, CompareType.Equal);

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

                        return new T900(preId);
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

        public static T900 GetCoilDetailOfYear(string coilNo, int year)
        {
            WhereParameterCollection whereColl = new WhereParameterCollection();
            whereColl.Add(R025__COLUMN_NAME, coilNo, CompareType.Equal);
            whereColl.Add(R033__COLUMN_NAME, year, CompareType.Equal);

            SortParameterCollection sortColl = new SortParameterCollection();
            sortColl.Add(ID__COLUMN_NAME, SortType.Decrease);

            DBAccessor _DBAccessor = null;
            try
            {
                _DBAccessor = new DBAccessor();
                DataSet data_Set = _DBAccessor.GetTable(TABLE_NAME, whereColl, sortColl);

                if (data_Set != null && data_Set.Tables[0].Rows.Count != 0)
                {
                    DataRow row = data_Set.Tables[0].Rows[0];
                    T900 t900 = new T900();
                    t900.FromDataRow(row);
                    return t900;
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

        public long CoilIndex
        {
            get
            {
                if (_ID < 1)
                {
                    return -1;
                }

                WhereParameterCollection whereColl = new WhereParameterCollection();
                whereColl.Add(ID__COLUMN_NAME, _ID, CompareType.Less);
                whereColl.Add(R025__COLUMN_NAME, R025, CompareType.Like);
                whereColl.Add(R033__COLUMN_NAME, R033, CompareType.Equal);

                try
                {
                    if (!this.db_Set)
                    {
                        _DBAccessor = new DBAccessor();
                    }
                    return _DBAccessor.RecordCount(TABLE_NAME, whereColl) + 1;
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
        }
    }
}
