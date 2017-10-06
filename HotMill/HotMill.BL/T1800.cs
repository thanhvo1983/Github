using System;
using System.Data;
using System.Text;
using Kvics.DBAccess;

using log4net;
using log4net.Config;

namespace Kvics.HotMill.BL
{
    public class T1800 : BaseBL
    {
        #region Static
        protected static readonly ILog log = Log.Instance.GetLogger(typeof(T1800));

        public static readonly string TRANSACTION_CODE = "00030001";
        public static readonly string TABLE_NAME = "T1800_édè„äwèKåvéZèÓïÒ";
        public static readonly string ID__COLUMN_NAME = "ID";
        public static readonly string Worker_ID__COLUMN_NAME = "Worker_ID";
        public static readonly string R0025__COLUMN_NAME = "R0025_ÉRÉCÉãÇmÇè";
        public static readonly string R0033__COLUMN_NAME = "R0033_à≥âÑì˙_îN";
        public static readonly string R0035__COLUMN_NAME = "R0035_à≥âÑì˙_åé";
        public static readonly string R0037__COLUMN_NAME = "R0037_à≥âÑì˙_ì˙";
        public static readonly string R0039__COLUMN_NAME = "R0039_ãŒ";
        public static readonly string R0041__COLUMN_NAME = "R0041_î«";
        public static readonly string R0043__COLUMN_NAME = "R0043_à≥âÑèá";
        public static readonly string R0043_1__COLUMN_NAME = "R0043_ÉXÉâÉuî‘çÜ";
        public static readonly string R0053__COLUMN_NAME = "R0053_à≥âÑéwóﬂî‘çÜ";
        public static readonly string R0059__COLUMN_NAME = "R0059_à≥â∫à íuç∑ÉeÅ[ÉuÉãëwï ãÊï™_î¬å˙ãÊï™";
        public static readonly string R0061__COLUMN_NAME = "R0061_à≥â∫à íuç∑ÉeÅ[ÉuÉãëwï ãÊï™_î¬ïùãÊï™";
        public static readonly string R0063__COLUMN_NAME = "R0063_à≥â∫à íuç∑ÉeÅ[ÉuÉãëwï ãÊï™_ã≠ìxãÊï™";
        public static readonly string R0065__COLUMN_NAME = "R0065_ìØä˙ÉXÉ^ÉìÉh";
        public static readonly string R0067__COLUMN_NAME = "R0067_çﬁóøîªï ÉRÅ[Éh";
        public static readonly string R0069__COLUMN_NAME = "R0069_ÇmÇâç|ÉtÉâÉO";
        public static readonly string R0073__COLUMN_NAME = "R0073_ç|éÌñº";
        public static readonly string R0081__COLUMN_NAME = "R0081_îMä‘ã≠ìx";
        public static readonly string R0071__COLUMN_NAME = "R0071_édè„é¿ê—â∑ìx_FDT";
        public static readonly string R0073_1__COLUMN_NAME = "R0073_édè„ì¸ë§â∑ìx_FET";
        public static readonly string R0089__COLUMN_NAME = "R0089_ÇqÇaïù";
        public static readonly string R0091__COLUMN_NAME = "R0091_ÇqÇaå˙";
        public static readonly string R0093__COLUMN_NAME = "R0093_ÇgÇbïù";
        public static readonly string R0095__COLUMN_NAME = "R0095_ÇgÇbå˙";
        public static readonly string LASTUPDATE__COLUMN_NAME = "LastUpdate";

        public static readonly int MAX_WORKER = 8;

        #endregion

        #region Protected
        protected int _ID;
        protected int _Worker_ID;
        protected string _R0025;
        protected Int16 _R0033;
        protected Int16 _R0035;
        protected Int16 _R0037;
        protected Int16 _R0039;
        protected string _R0041;
        protected Int16 _R0043;
        protected string _R0043_1;
        protected string _R0053;
        protected Int16 _R0059;
        protected Int16 _R0061;
        protected Int16 _R0063;
        protected Int16 _R0065;
        protected Int16 _R0067;
        protected Int16 _R0069;
        protected string _R0073;
        protected Int16 _R0081;
        protected Int16 _R0071;
        protected Int16 _R0073_1;
        protected Int16 _R0089;
        protected Int16 _R0091;
        protected Int16 _R0093;
        protected Int16 _R0095;
        protected DateTime _LastUpdate;
        protected T_R_RowSet[] _RowsChild = new T_R_RowSet[T1800_Mapping.RowsName.Length];
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

        public int Worker_ID
        {
            get
            {
                return _Worker_ID;
            }
            set
            {
                _Worker_ID = value;
            }
        }

        public string R0025
        {
            get
            {
                return _R0025;
            }
            set
            {
                _R0025 = Common.GetString(value, 0, 8, ' ', 2);
            }
        }

        public Int16 R0033
        {
            get
            {
                return _R0033;
            }
            set
            {
                _R0033 = value;
            }
        }

        public Int16 R0035
        {
            get
            {
                return _R0035;
            }
            set
            {
                _R0035 = value;
            }
        }

        public Int16 R0037
        {
            get
            {
                return _R0037;
            }
            set
            {
                _R0037 = value;
            }
        }

        public Int16 R0039
        {
            get
            {
                return _R0039;
            }
            set
            {
                _R0039 = value;
            }
        }

        public string R0041
        {
            get
            {
                return _R0041;
            }
            set
            {
                _R0041 = value;
            }
        }

        public Int16 R0043
        {
            get
            {
                return _R0043;
            }
            set
            {
                _R0043 = value;
            }
        }

        public string R0043_1
        {
            get
            {
                return _R0043_1;
            }
            set
            {
                _R0043_1 = Common.GetString(value, 0, 10, ' ', 2);
            }
        }

        public string R0053
        {
            get
            {
                return _R0053;
            }
            set
            {
                _R0053 = Common.GetString(value, 0, 6, ' ', 2);
            }
        }

        public Int16 R0059
        {
            get
            {
                return _R0059;
            }
            set
            {
                _R0059 = value;
            }
        }

        public Int16 R0061
        {
            get
            {
                return _R0061;
            }
            set
            {
                _R0061 = value;
            }
        }

        public Int16 R0063
        {
            get
            {
                return _R0063;
            }
            set
            {
                _R0063 = value;
            }
        }

        public Int16 R0065
        {
            get
            {
                return _R0065;
            }
            set
            {
                _R0065 = value;
            }
        }

        public Int16 R0067
        {
            get
            {
                return _R0067;
            }
            set
            {
                _R0067 = value;
            }
        }

        public Int16 R0069
        {
            get
            {
                return _R0069;
            }
            set
            {
                _R0069 = value;
            }
        }

        public string R0073
        {
            get
            {
                return _R0073;
            }
            set
            {
                _R0073 = Common.GetString(value, 0, 8, ' ', 2);
            }
        }

        public Int16 R0081
        {
            get
            {
                return _R0081;
            }
            set
            {
                _R0081 = value;
            }
        }

        public Int16 R0071
        {
            get
            {
                return _R0071;
            }
            set
            {
                _R0071 = value;
            }
        }

        public Int16 R0073_1
        {
            get
            {
                return _R0073_1;
            }
            set
            {
                _R0073_1 = value;
            }
        }

        public Int16 R0089
        {
            get
            {
                return _R0089;
            }
            set
            {
                _R0089 = value;
            }
        }

        public Int16 R0091
        {
            get
            {
                return _R0091;
            }
            set
            {
                _R0091 = value;
            }
        }

        public Int16 R0093
        {
            get
            {
                return _R0093;
            }
            set
            {
                _R0093 = value;
            }
        }

        public Int16 R0095
        {
            get
            {
                return _R0095;
            }
            set
            {
                _R0095 = value;
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

        public T1800_I2_07 R0075
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
                        R0075 = new T1800_I2_07(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0075));
                    }
                }
                return (T1800_I2_07)_RowsChild[0].Row;
            }
            set
            {
                _RowsChild[0].Row = value;
                if (value != null)
                {
                    _RowsChild[0].Row.ParentID = _ID;
                    _RowsChild[0].Row.RowID = T1800_Mapping.GetRowID(T1800_Mapping.R0075);
                }
                _RowsChild[0].R_Set = true;
            }
        }

        public T1800_I2_14 R0097
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
                        R0097 = new T1800_I2_14(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0097));
                    }
                }
                return (T1800_I2_14)_RowsChild[1].Row;
            }
            set
            {
                _RowsChild[1].Row = value;
                if (value != null)
                {
                    _RowsChild[1].Row.ParentID = _ID;
                    _RowsChild[1].Row.RowID = T1800_Mapping.GetRowID(T1800_Mapping.R0097);
                }
                _RowsChild[1].R_Set = true;
            }
        }

        public T1800_I2_07 R0125
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
                        R0125 = new T1800_I2_07(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0125));
                    }
                }
                return (T1800_I2_07)_RowsChild[2].Row;
            }
            set
            {
                _RowsChild[2].Row = value;
                if (value != null)
                {
                    _RowsChild[2].Row.ParentID = _ID;
                    _RowsChild[2].Row.RowID = T1800_Mapping.GetRowID(T1800_Mapping.R0125);
                }
                _RowsChild[2].R_Set = true;
            }
        }

        public T1800_I2_14 R0139
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
                        R0139 = new T1800_I2_14(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0139));
                    }
                }
                return (T1800_I2_14)_RowsChild[3].Row;
            }
            set
            {
                _RowsChild[3].Row = value;
                if (value != null)
                {
                    _RowsChild[3].Row.ParentID = _ID;
                    _RowsChild[3].Row.RowID = T1800_Mapping.GetRowID(T1800_Mapping.R0139);
                }
                _RowsChild[3].R_Set = true;
            }
        }

        public T1800_I2_14 R0167
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
                        R0167 = new T1800_I2_14(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0167));
                    }
                }
                return (T1800_I2_14)_RowsChild[4].Row;
            }
            set
            {
                _RowsChild[4].Row = value;
                if (value != null)
                {
                    _RowsChild[4].Row.ParentID = _ID;
                    _RowsChild[4].Row.RowID = T1800_Mapping.GetRowID(T1800_Mapping.R0167);
                }
                _RowsChild[4].R_Set = true;
            }
        }

        public T1800_I2_14 R0195
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
                        R0195 = new T1800_I2_14(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0195));
                    }
                }
                return (T1800_I2_14)_RowsChild[5].Row;
            }
            set
            {
                _RowsChild[5].Row = value;
                if (value != null)
                {
                    _RowsChild[5].Row.ParentID = _ID;
                    _RowsChild[5].Row.RowID = T1800_Mapping.GetRowID(T1800_Mapping.R0195);
                }
                _RowsChild[5].R_Set = true;
            }
        }

        public T1800_I2_07 R0223
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
                        R0223 = new T1800_I2_07(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0223));
                    }
                }
                return (T1800_I2_07)_RowsChild[6].Row;
            }
            set
            {
                _RowsChild[6].Row = value;
                if (value != null)
                {
                    _RowsChild[6].Row.ParentID = _ID;
                    _RowsChild[6].Row.RowID = T1800_Mapping.GetRowID(T1800_Mapping.R0223);
                }
                _RowsChild[6].R_Set = true;
            }
        }

        public T1800_I2_07 R0237
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
                        R0237 = new T1800_I2_07(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0237));
                    }
                }
                return (T1800_I2_07)_RowsChild[7].Row;
            }
            set
            {
                _RowsChild[7].Row = value;
                if (value != null)
                {
                    _RowsChild[7].Row.ParentID = _ID;
                    _RowsChild[7].Row.RowID = T1800_Mapping.GetRowID(T1800_Mapping.R0237);
                }
                _RowsChild[7].R_Set = true;
            }
        }

        public T1800_I2_14 R0251
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
                        R0251 = new T1800_I2_14(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0251));
                    }
                }
                return (T1800_I2_14)_RowsChild[8].Row;
            }
            set
            {
                _RowsChild[8].Row = value;
                if (value != null)
                {
                    _RowsChild[8].Row.ParentID = _ID;
                    _RowsChild[8].Row.RowID = T1800_Mapping.GetRowID(T1800_Mapping.R0251);
                }
                _RowsChild[8].R_Set = true;
            }
        }
        
        public T1800_I2_06 R0279
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
                        R0279 = new T1800_I2_06(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0279));
                    }
                }
                return (T1800_I2_06)_RowsChild[9].Row;
            }
            set
            {
                _RowsChild[9].Row = value;
                if (value != null)
                {
                    _RowsChild[9].Row.ParentID = _ID;
                    _RowsChild[9].Row.RowID = T1800_Mapping.GetRowID(T1800_Mapping.R0279);
                }
                _RowsChild[9].R_Set = true;
            }
        }
        /* R0291
        public T1800_I2_06_1 R0291
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
                        R0291 = new T1800_I2_06_1(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0291));
                    }
                }
                return (T1800_I2_06_1)_RowsChild[10].Row;
            }
            set
            {
                _RowsChild[10].Row = value;
                if (value != null)
                {
                    _RowsChild[10].Row.ParentID = _ID;
                    _RowsChild[10].Row.RowID = T1800_Mapping.GetRowID(T1800_Mapping.R0291);
                }
                _RowsChild[10].R_Set = true;
            }
        }
        */
        public T1800_I2_45 R0401
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
                        R0401 = new T1800_I2_45(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0401));
                    }
                }
                return (T1800_I2_45)_RowsChild[11].Row;
            }
            set
            {
                _RowsChild[11].Row = value;
                if (value != null)
                {
                    _RowsChild[11].Row.ParentID = _ID;
                    _RowsChild[11].Row.RowID = T1800_Mapping.GetRowID(T1800_Mapping.R0401);
                }
                _RowsChild[11].R_Set = true;
            }
        }

        public T1800_I2_45 R0491
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
                        R0491 = new T1800_I2_45(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0491));
                    }
                }
                return (T1800_I2_45)_RowsChild[12].Row;
            }
            set
            {
                _RowsChild[12].Row = value;
                if (value != null)
                {
                    _RowsChild[12].Row.ParentID = _ID;
                    _RowsChild[12].Row.RowID = T1800_Mapping.GetRowID(T1800_Mapping.R0491);
                }
                _RowsChild[12].R_Set = true;
            }
        }

        public T1800_I2_45 R0581
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
                        R0581 = new T1800_I2_45(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0581));
                    }
                }
                return (T1800_I2_45)_RowsChild[13].Row;
            }
            set
            {
                _RowsChild[13].Row = value;
                if (value != null)
                {
                    _RowsChild[13].Row.ParentID = _ID;
                    _RowsChild[13].Row.RowID = T1800_Mapping.GetRowID(T1800_Mapping.R0581);
                }
                _RowsChild[13].R_Set = true;
            }
        }

        public T1800_I2_45 R0671
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
                        R0671 = new T1800_I2_45(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0671));
                    }
                }
                return (T1800_I2_45)_RowsChild[14].Row;
            }
            set
            {
                _RowsChild[14].Row = value;
                if (value != null)
                {
                    _RowsChild[14].Row.ParentID = _ID;
                    _RowsChild[14].Row.RowID = T1800_Mapping.GetRowID(T1800_Mapping.R0671);
                }
                _RowsChild[14].R_Set = true;
            }
        }

        public T1800_I2_45 R0761
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
                        R0761 = new T1800_I2_45(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0761));
                    }
                }
                return (T1800_I2_45)_RowsChild[15].Row;
            }
            set
            {
                _RowsChild[15].Row = value;
                if (value != null)
                {
                    _RowsChild[15].Row.ParentID = _ID;
                    _RowsChild[15].Row.RowID = T1800_Mapping.GetRowID(T1800_Mapping.R0761);
                }
                _RowsChild[15].R_Set = true;
            }
        }

        public T1800_I2_45 R0851
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
                        R0851 = new T1800_I2_45(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0851));
                    }
                }
                return (T1800_I2_45)_RowsChild[16].Row;
            }
            set
            {
                _RowsChild[16].Row = value;
                if (value != null)
                {
                    _RowsChild[16].Row.ParentID = _ID;
                    _RowsChild[16].Row.RowID = T1800_Mapping.GetRowID(T1800_Mapping.R0851);
                }
                _RowsChild[16].R_Set = true;
            }
        }

        public T1800_I2_45 R0941
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
                        R0941 = new T1800_I2_45(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0941));
                    }
                }
                return (T1800_I2_45)_RowsChild[17].Row;
            }
            set
            {
                _RowsChild[17].Row = value;
                if (value != null)
                {
                    _RowsChild[17].Row.ParentID = _ID;
                    _RowsChild[17].Row.RowID = T1800_Mapping.GetRowID(T1800_Mapping.R0941);
                }
                _RowsChild[17].R_Set = true;
            }
        }

        public T1800_I2_45 R1031
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
                        R1031 = new T1800_I2_45(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R1031));
                    }
                }
                return (T1800_I2_45)_RowsChild[18].Row;
            }
            set
            {
                _RowsChild[18].Row = value;
                if (value != null)
                {
                    _RowsChild[18].Row.ParentID = _ID;
                    _RowsChild[18].Row.RowID = T1800_Mapping.GetRowID(T1800_Mapping.R1031);
                }
                _RowsChild[18].R_Set = true;
            }
        }

        public T1800_I2_45 R1121
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
                        R1121 = new T1800_I2_45(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R1121));
                    }
                }
                return (T1800_I2_45)_RowsChild[19].Row;
            }
            set
            {
                _RowsChild[19].Row = value;
                if (value != null)
                {
                    _RowsChild[19].Row.ParentID = _ID;
                    _RowsChild[19].Row.RowID = T1800_Mapping.GetRowID(T1800_Mapping.R1121);
                }
                _RowsChild[19].R_Set = true;
            }
        }

        public T1800_I2_45 R1211
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
                        R1211 = new T1800_I2_45(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R1211));
                    }
                }
                return (T1800_I2_45)_RowsChild[20].Row;
            }
            set
            {
                _RowsChild[20].Row = value;
                if (value != null)
                {
                    _RowsChild[20].Row.ParentID = _ID;
                    _RowsChild[20].Row.RowID = T1800_Mapping.GetRowID(T1800_Mapping.R1211);
                }
                _RowsChild[20].R_Set = true;
            }
        }

        public T1800_I2_45 R1301
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
                        R1301 = new T1800_I2_45(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R1301));
                    }
                }
                return (T1800_I2_45)_RowsChild[21].Row;
            }
            set
            {
                _RowsChild[21].Row = value;
                if (value != null)
                {
                    _RowsChild[21].Row.ParentID = _ID;
                    _RowsChild[21].Row.RowID = T1800_Mapping.GetRowID(T1800_Mapping.R1301);
                }
                _RowsChild[21].R_Set = true;
            }
        }

        public T1800_I2_45 R1391
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
                        R1391 = new T1800_I2_45(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R1391));
                    }
                }
                return (T1800_I2_45)_RowsChild[22].Row;
            }
            set
            {
                _RowsChild[22].Row = value;
                if (value != null)
                {
                    _RowsChild[22].Row.ParentID = _ID;
                    _RowsChild[22].Row.RowID = T1800_Mapping.GetRowID(T1800_Mapping.R1391);
                }
                _RowsChild[22].R_Set = true;
            }
        }

        public T1800_I2_45 R1481
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
                        R1481 = new T1800_I2_45(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R1481));
                    }
                }
                return (T1800_I2_45)_RowsChild[23].Row;
            }
            set
            {
                _RowsChild[23].Row = value;
                if (value != null)
                {
                    _RowsChild[23].Row.ParentID = _ID;
                    _RowsChild[23].Row.RowID = T1800_Mapping.GetRowID(T1800_Mapping.R1481);
                }
                _RowsChild[23].R_Set = true;
            }
        }

        public T1800_I2_45 R1571
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
                        R1571 = new T1800_I2_45(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R1571));
                    }
                }
                return (T1800_I2_45)_RowsChild[24].Row;
            }
            set
            {
                _RowsChild[24].Row = value;
                if (value != null)
                {
                    _RowsChild[24].Row.ParentID = _ID;
                    _RowsChild[24].Row.RowID = T1800_Mapping.GetRowID(T1800_Mapping.R1571);
                }
                _RowsChild[24].R_Set = true;
            }
        }

        // HSS4 
        public T1800_Extend_01 R1661
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
                        R1661 = new T1800_Extend_01(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R1661));

                        if (_RowsChild[25].Row.ID < 1)
                        {
                            R1661 = null;
                        }
                    }
                }
                return (T1800_Extend_01)_RowsChild[25].Row;
            }
            set
            {
                _RowsChild[25].Row = value;
                if (value != null)
                {
                    _RowsChild[25].Row.ParentID = _ID;
                    _RowsChild[25].Row.RowID = T1800_Mapping.GetRowID(T1800_Mapping.R1661);
                }
                _RowsChild[25].R_Set = true;
            }
        }
        // End HSS4 

        // HSS5
        public T1800_Extend_02 R1749
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
                        R1749 = new T1800_Extend_02(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R1749));

                        if (_RowsChild[26].Row.ID < 1)
                        {
                            R1749 = null;
                        }
                    }
                }
                return (T1800_Extend_02)_RowsChild[26].Row;
            }
            set
            {
                _RowsChild[26].Row = value;
                if (value != null)
                {
                    _RowsChild[26].Row.ParentID = _ID;
                    _RowsChild[26].Row.RowID = T1800_Mapping.GetRowID(T1800_Mapping.R1749);
                }
                _RowsChild[26].R_Set = true;
            }
        }
        // End HSS5
        #endregion

        #region Constructors
        public T1800()
        {
            NewRowsChild();
            _ID = 0;
        }
        public T1800(int iD, int worker_ID,
            string r25, Int16 r33, Int16 r35, Int16 r37, Int16 r39, string r41,
            Int16 r43, string r43_1, string r53, Int16 r59, Int16 r61, Int16 r63,
            Int16 r65, Int16 r67, Int16 r69, string r73, Int16 r81, Int16 r71, Int16 r73_1,
            Int16 r89, Int16 r91, Int16 r93, Int16 r95)
        {
            NewRowsChild();
            _ID = iD;
            _Worker_ID = worker_ID;
            _R0025 = r25;
            _R0033 = r33;
            _R0035 = r35;
            _R0037 = r37;
            _R0039 = r39;
            _R0041 = r41;
            _R0043 = r43;
            _R0043_1 = r43_1;
            _R0053 = r53;
            _R0059 = r59;
            _R0061 = r61;
            _R0063 = r63;
            _R0065 = r65;
            _R0067 = r67;
            _R0069 = r69;
            _R0073 = r73;
            _R0081 = r81;
            _R0071 = r71;
            _R0073_1 = r73_1;
            _R0089 = r89;
            _R0091 = r91;
            _R0093 = r93;
            _R0095 = r95;
        }
        public T1800(int iD)
        {
            NewRowsChild();
            if (!this.db_Set)
            {
                _DBAccessor = new DBAccessor();
            }
            WhereParameterCollection whereColl = new WhereParameterCollection();
            whereColl.Add(ID__COLUMN_NAME, iD, CompareType.Equal);
            try
            {
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
        public T1800(DBAccessor db)
        {
            NewRowsChild();
            this.DBAccessor = db;
            _ID = 0;
        }
        public T1800(DBAccessor db, int iD, int worker_ID,
            string r25, Int16 r33, Int16 r35, Int16 r37, Int16 r39, string r41,
            Int16 r43, string r43_1, string r53, Int16 r59, Int16 r61, Int16 r63,
            Int16 r65, Int16 r67, Int16 r69, string r73, Int16 r81, Int16 r71, Int16 r73_1,
            Int16 r89, Int16 r91, Int16 r93, Int16 r95)
        {
            NewRowsChild();
            this.DBAccessor = db;
            _ID = iD;
            _Worker_ID = worker_ID;
            _R0025 = r25;
            _R0033 = r33;
            _R0035 = r35;
            _R0037 = r37;
            _R0039 = r39;
            _R0041 = r41;
            _R0043 = r43;
            _R0043_1 = r43_1;
            _R0053 = r53;
            _R0059 = r59;
            _R0061 = r61;
            _R0063 = r63;
            _R0065 = r65;
            _R0067 = r67;
            _R0069 = r69;
            _R0073 = r73;
            _R0081 = r81;
            _R0071 = r71;
            _R0073_1 = r73_1;
            _R0089 = r89;
            _R0091 = r91;
            _R0093 = r93;
            _R0095 = r95;
        }
        public T1800(DBAccessor db, int iD)
        {
            NewRowsChild();
            this.DBAccessor = db;

            if (!this.db_Set)
            {
                _DBAccessor = new DBAccessor();
            }
            WhereParameterCollection whereColl = new WhereParameterCollection();
            whereColl.Add(ID__COLUMN_NAME, iD, CompareType.Equal);
            try
            {
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
        #endregion

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
            coll.Add(new Parameter(Worker_ID__COLUMN_NAME, _Worker_ID));
            coll.Add(R0025__COLUMN_NAME, _R0025);
            coll.Add(R0033__COLUMN_NAME, _R0033);
            coll.Add(R0035__COLUMN_NAME, _R0035);
            coll.Add(R0037__COLUMN_NAME, _R0037);
            coll.Add(R0039__COLUMN_NAME, _R0039);
            coll.Add(R0041__COLUMN_NAME, _R0041);
            coll.Add(R0043__COLUMN_NAME, _R0043);
            coll.Add(R0043_1__COLUMN_NAME, _R0043_1);
            coll.Add(R0053__COLUMN_NAME, _R0053);
            coll.Add(R0059__COLUMN_NAME, _R0059);
            coll.Add(R0061__COLUMN_NAME, _R0061);
            coll.Add(R0063__COLUMN_NAME, _R0063);
            coll.Add(R0065__COLUMN_NAME, _R0065);
            coll.Add(R0067__COLUMN_NAME, _R0067);
            coll.Add(R0069__COLUMN_NAME, _R0069);
            coll.Add(R0073__COLUMN_NAME, _R0073);
            coll.Add(R0081__COLUMN_NAME, _R0081);
            coll.Add(R0071__COLUMN_NAME, _R0071);
            coll.Add(R0073_1__COLUMN_NAME, _R0073_1);
            coll.Add(R0089__COLUMN_NAME, _R0089);
            coll.Add(R0091__COLUMN_NAME, _R0091);
            coll.Add(R0093__COLUMN_NAME, _R0093);
            coll.Add(R0095__COLUMN_NAME, _R0095);
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
                    R0075 = T1800_I2_07.NewObject(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0075));
                }
                _RowsChild[0].Row.ParentID = this.ID;
                _RowsChild[0].Row.DBAccessor = _DBAccessor;
                _RowsChild[0].Row.Insert();

                if (_RowsChild[1].Row == null)
                {
                    R0097 = T1800_I2_14.NewObject(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0097));
                }
                _RowsChild[1].Row.ParentID = this.ID;
                _RowsChild[1].Row.DBAccessor = _DBAccessor;
                _RowsChild[1].Row.Insert();

                if (_RowsChild[2].Row == null)
                {
                    R0125 = T1800_I2_07.NewObject(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0125));
                }
                _RowsChild[2].Row.ParentID = this.ID;
                _RowsChild[2].Row.DBAccessor = _DBAccessor;
                _RowsChild[2].Row.Insert();

                if (_RowsChild[3].Row == null)
                {
                    R0139 = T1800_I2_14.NewObject(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0139));
                }
                _RowsChild[3].Row.ParentID = this.ID;
                _RowsChild[3].Row.DBAccessor = _DBAccessor;
                _RowsChild[3].Row.Insert();

                if (_RowsChild[4].Row == null)
                {
                    R0167 = T1800_I2_14.NewObject(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0167));
                }
                _RowsChild[4].Row.ParentID = this.ID;
                _RowsChild[4].Row.DBAccessor = _DBAccessor;
                _RowsChild[4].Row.Insert();

                if (_RowsChild[5].Row == null)
                {
                    R0195 = T1800_I2_14.NewObject(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0195));
                }
                _RowsChild[5].Row.ParentID = this.ID;
                _RowsChild[5].Row.DBAccessor = _DBAccessor;
                _RowsChild[5].Row.Insert();

                if (_RowsChild[6].Row == null)
                {
                    R0223 = T1800_I2_07.NewObject(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0223));
                }
                _RowsChild[6].Row.ParentID = this.ID;
                _RowsChild[6].Row.DBAccessor = _DBAccessor;
                _RowsChild[6].Row.Insert();

                if (_RowsChild[7].Row == null)
                {
                    R0237 = T1800_I2_07.NewObject(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0237));
                }
                _RowsChild[7].Row.ParentID = this.ID;
                _RowsChild[7].Row.DBAccessor = _DBAccessor;
                _RowsChild[7].Row.Insert();

                if (_RowsChild[8].Row == null)
                {
                    R0251 = T1800_I2_14.NewObject(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0251));
                }
                _RowsChild[8].Row.ParentID = this.ID;
                _RowsChild[8].Row.DBAccessor = _DBAccessor;
                _RowsChild[8].Row.Insert();
                
                if (_RowsChild[9].Row == null)
                {
                    R0279 = T1800_I2_06.NewObject(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0279));
                }
                _RowsChild[9].Row.ParentID = this.ID;
                _RowsChild[9].Row.DBAccessor = _DBAccessor;
                _RowsChild[9].Row.Insert();
                /*
                 * HSS5
                if (_RowsChild[10].Row == null)
                {
                    R0291 = T1800_I2_06_1.NewObject(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0291));
                }
                _RowsChild[10].Row.ParentID = this.ID;
                _RowsChild[10].Row.DBAccessor = _DBAccessor;
                _RowsChild[10].Row.Insert();
                 * End HSS5
                */
                if (_RowsChild[11].Row == null)
                {
                    R0401 = T1800_I2_45.NewObject(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0401));
                }
                _RowsChild[11].Row.ParentID = this.ID;
                _RowsChild[11].Row.DBAccessor = _DBAccessor;
                _RowsChild[11].Row.Insert();

                if (_RowsChild[12].Row == null)
                {
                    R0491 = T1800_I2_45.NewObject(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0491));
                }
                _RowsChild[12].Row.ParentID = this.ID;
                _RowsChild[12].Row.DBAccessor = _DBAccessor;
                _RowsChild[12].Row.Insert();

                if (_RowsChild[13].Row == null)
                {
                    R0581 = T1800_I2_45.NewObject(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0581));
                }
                _RowsChild[13].Row.ParentID = this.ID;
                _RowsChild[13].Row.DBAccessor = _DBAccessor;
                _RowsChild[13].Row.Insert();

                if (_RowsChild[14].Row == null)
                {
                    R0671 = T1800_I2_45.NewObject(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0671));
                }
                _RowsChild[14].Row.ParentID = this.ID;
                _RowsChild[14].Row.DBAccessor = _DBAccessor;
                _RowsChild[14].Row.Insert();

                if (_RowsChild[15].Row == null)
                {
                    R0761 = T1800_I2_45.NewObject(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0761));
                }
                _RowsChild[15].Row.ParentID = this.ID;
                _RowsChild[15].Row.DBAccessor = _DBAccessor;
                _RowsChild[15].Row.Insert();

                if (_RowsChild[16].Row == null)
                {
                    R0851 = T1800_I2_45.NewObject(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0851));
                }
                _RowsChild[16].Row.ParentID = this.ID;
                _RowsChild[16].Row.DBAccessor = _DBAccessor;
                _RowsChild[16].Row.Insert();

                if (_RowsChild[17].Row == null)
                {
                    R0941 = T1800_I2_45.NewObject(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R0941));
                }
                _RowsChild[17].Row.ParentID = this.ID;
                _RowsChild[17].Row.DBAccessor = _DBAccessor;
                _RowsChild[17].Row.Insert();

                if (_RowsChild[18].Row == null)
                {
                    R1031 = T1800_I2_45.NewObject(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R1031));
                }
                _RowsChild[18].Row.ParentID = this.ID;
                _RowsChild[18].Row.DBAccessor = _DBAccessor;
                _RowsChild[18].Row.Insert();

                if (_RowsChild[19].Row == null)
                {
                    R1121 = T1800_I2_45.NewObject(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R1121));
                }
                _RowsChild[19].Row.ParentID = this.ID;
                _RowsChild[19].Row.DBAccessor = _DBAccessor;
                _RowsChild[19].Row.Insert();

                if (_RowsChild[20].Row == null)
                {
                    R1211 = T1800_I2_45.NewObject(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R1211));
                }
                _RowsChild[20].Row.ParentID = this.ID;
                _RowsChild[20].Row.DBAccessor = _DBAccessor;
                _RowsChild[20].Row.Insert();

                if (_RowsChild[21].Row == null)
                {
                    R1301 = T1800_I2_45.NewObject(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R1301));
                }
                _RowsChild[21].Row.ParentID = this.ID;
                _RowsChild[21].Row.DBAccessor = _DBAccessor;
                _RowsChild[21].Row.Insert();

                if (_RowsChild[22].Row == null)
                {
                    R1391 = T1800_I2_45.NewObject(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R1391));
                }
                _RowsChild[22].Row.ParentID = this.ID;
                _RowsChild[22].Row.DBAccessor = _DBAccessor;
                _RowsChild[22].Row.Insert();

                if (_RowsChild[23].Row == null)
                {
                    R1481 = T1800_I2_45.NewObject(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R1481));
                }
                _RowsChild[23].Row.ParentID = this.ID;
                _RowsChild[23].Row.DBAccessor = _DBAccessor;
                _RowsChild[23].Row.Insert();

                if (_RowsChild[24].Row == null)
                {
                    R1571 = T1800_I2_45.NewObject(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R1571));
                }
                _RowsChild[24].Row.ParentID = this.ID;
                _RowsChild[24].Row.DBAccessor = _DBAccessor;
                _RowsChild[24].Row.Insert();

                // HSS4 
                if (_RowsChild[25].Row == null)
                {
                    R1661 = T1800_Extend_01.NewObject(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R1661));
                }
                _RowsChild[25].Row.ParentID = this.ID;
                _RowsChild[25].Row.DBAccessor = _DBAccessor;
                _RowsChild[25].Row.Insert();
                // End HSS4 

                // HSS5
                if (_RowsChild[26].Row == null)
                {
                    R1749 = T1800_Extend_02.NewObject(_ID, T1800_Mapping.GetRowID(T1800_Mapping.R1749));
                }
                _RowsChild[26].Row.ParentID = this.ID;
                _RowsChild[26].Row.DBAccessor = _DBAccessor;
                _RowsChild[26].Row.Insert();
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
                    if (_RowsChild[i] != null && _RowsChild[i].Row != null)
                    {
                        _RowsChild[i].Row.DBAccessor = null;
                    }
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
            coll.Add(new Parameter(Worker_ID__COLUMN_NAME, _Worker_ID));
            coll.Add(R0025__COLUMN_NAME, _R0025);
            coll.Add(R0033__COLUMN_NAME, _R0033);
            coll.Add(R0035__COLUMN_NAME, _R0035);
            coll.Add(R0037__COLUMN_NAME, _R0037);
            coll.Add(R0039__COLUMN_NAME, _R0039);
            coll.Add(R0041__COLUMN_NAME, _R0041);
            coll.Add(R0043__COLUMN_NAME, _R0043);
            coll.Add(R0043_1__COLUMN_NAME, _R0043_1);
            coll.Add(R0053__COLUMN_NAME, _R0053);
            coll.Add(R0059__COLUMN_NAME, _R0059);
            coll.Add(R0061__COLUMN_NAME, _R0061);
            coll.Add(R0063__COLUMN_NAME, _R0063);
            coll.Add(R0065__COLUMN_NAME, _R0065);
            coll.Add(R0067__COLUMN_NAME, _R0067);
            coll.Add(R0069__COLUMN_NAME, _R0069);
            coll.Add(R0073__COLUMN_NAME, _R0073);
            coll.Add(R0081__COLUMN_NAME, _R0081);
            coll.Add(R0071__COLUMN_NAME, _R0071);
            coll.Add(R0073_1__COLUMN_NAME, _R0073_1);
            coll.Add(R0089__COLUMN_NAME, _R0089);
            coll.Add(R0091__COLUMN_NAME, _R0091);
            coll.Add(R0093__COLUMN_NAME, _R0093);
            coll.Add(R0095__COLUMN_NAME, _R0095);
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
                        _RowsChild[i].Row.RowID = T1800_Mapping.GetRowID(T1800_Mapping.RowsName[i]);
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
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                if (!this.db_Set && this._DBAccessor != null)
                {
                    _DBAccessor.Dispose();
                }
            }
        }
        #endregion

        protected void FromDataRow(DataRow row)
        {
            _ID = (int)row[ID__COLUMN_NAME];
            _Worker_ID = row[Worker_ID__COLUMN_NAME] == DBNull.Value ? (int)0 : (int)(row[Worker_ID__COLUMN_NAME]);
            _R0025 = row[R0025__COLUMN_NAME] == DBNull.Value ? null : (string)row[R0025__COLUMN_NAME];
            _R0033 = row[R0033__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R0033__COLUMN_NAME];
            _R0035 = row[R0035__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R0035__COLUMN_NAME];
            _R0037 = row[R0037__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R0037__COLUMN_NAME];
            _R0039 = row[R0039__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R0039__COLUMN_NAME];
            _R0041 = row[R0041__COLUMN_NAME] == DBNull.Value ? null : (string)row[R0041__COLUMN_NAME];
            _R0043 = row[R0043__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R0043__COLUMN_NAME];
            _R0043_1 = row[R0043_1__COLUMN_NAME] == DBNull.Value ? null : (string)row[R0043_1__COLUMN_NAME];
            _R0053 = row[R0053__COLUMN_NAME] == DBNull.Value ? null : (string)row[R0053__COLUMN_NAME];
            _R0059 = row[R0059__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R0059__COLUMN_NAME];
            _R0061 = row[R0061__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R0061__COLUMN_NAME];
            _R0063 = row[R0063__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R0063__COLUMN_NAME];
            _R0065 = row[R0065__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R0065__COLUMN_NAME];
            _R0067 = row[R0067__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R0067__COLUMN_NAME];
            _R0069 = row[R0069__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R0069__COLUMN_NAME];
            _R0071 = row[R0071__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R0071__COLUMN_NAME];
            _R0073 = row[R0073__COLUMN_NAME] == DBNull.Value ? null : (string)row[R0073__COLUMN_NAME];
            _R0081 = row[R0081__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R0081__COLUMN_NAME];
            _R0073_1 = row[R0073_1__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R0073_1__COLUMN_NAME];
            _R0089 = row[R0089__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R0089__COLUMN_NAME];
            _R0091 = row[R0091__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R0091__COLUMN_NAME];
            _R0093 = row[R0093__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R0093__COLUMN_NAME];
            _R0095 = row[R0095__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R0095__COLUMN_NAME];
            _LastUpdate = row[LASTUPDATE__COLUMN_NAME] == DBNull.Value ? DateTime.Now : (DateTime)row[LASTUPDATE__COLUMN_NAME];
        }

        public static T1800 GetLast()
        {
            DBAccessor _DBAccessor = null;
            try
            {
                _DBAccessor = new DBAccessor();
                object obj = _DBAccessor.MaxValue(TABLE_NAME, ID__COLUMN_NAME);

                if (obj != null && obj != DBNull.Value)
                {
                    int maxId = Convert.ToInt32(obj);

                    return new T1800(maxId);
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
        public static T1800 GetLast(DBAccessor db)
        {
            object obj = db.MaxValue(TABLE_NAME, ID__COLUMN_NAME);

            if (obj != null && obj != DBNull.Value)
            {
                int maxId = Convert.ToInt32(obj);

                T1800 t1800 = new T1800(db, maxId);
                t1800.DBAccessor = null;
                return t1800;
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
            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                return _DBAccessor.GetTable(TABLE_NAME);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (!this.db_Set && this._DBAccessor != null)
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

        public static T1800 Parse(Byte[] data)
        {
            /*
            log.Debug("DefaultConnectionString: " + DBAccessor.DefaultConnectionString);
            try
            {
                DBAccessor db = new DBAccessor();
                log.Debug("CurrentConnectionString: " + db.ConnectionString);
                db.Dispose();
            }
            catch (Exception ex)
            {
                log.Debug("CurrentConnectionString error. ", ex);
            }
            */
            /*
            log.Debug("------------------------T1800_Mapping detail.------------------------");
            //T1800_Mapping.RowsName
            log.Debug("T1800_Mapping.RowsName.Length = " + T1800_Mapping.RowsName.Length.ToString());
            for(int i = 0; i < T1800_Mapping.RowsName.Length; i++) {
                string rowName = T1800_Mapping.RowsName[i];
                log.Debug("T1800_Mapping.RowsName[i] = " + rowName + ". RowID = " + T1800_Mapping.GetRowID(rowName));
            }
            log.Debug("------------------------T1800_Mapping detail End.------------------------");
            */
            log.Debug("Begin public static T1800 Parse(Byte[] data)");
            if (data == null || data.Length != 1784)
            {
                if (data == null)
                {
                    log.Debug("Data is null.");
                }
                else
                {
                    log.Debug("Data error. Data length: " + data.Length.ToString());
                }
                return null;
            }

            //log.Debug("T1800 t1800 = new T1800();");
            T1800 t1800 = new T1800();

            try
            {
                //log.Debug("t1800.ID = 0;");
                t1800.ID = 0;
                t1800.R0025 = Common.GetString(data, 8, 8);
                t1800.R0033 = Common.ToInt16(data, 16);
                if (t1800.R0033 < 100)
                {
                    t1800.R0033 += 2000;
                    t1800.R0033 = (Int16)(t1800.R0033 > DateTime.Now.Year ? (t1800.R0033 - 100) : t1800.R0033);
                }
                t1800.R0035 = Common.ToInt16(data, 18);
                t1800.R0037 = Common.ToInt16(data, 20);
                t1800.R0039 = Common.ToInt16(data, 22);
                t1800.R0041 = Common.GetString(data, 24, 2);
                t1800.R0043 = Common.ToInt16(data, 26);
                t1800.R0043_1 = Common.GetString(data, 28, 10);
                t1800.R0053 = Common.GetString(data, 38, 6);
                t1800.R0059 = Common.ToInt16(data, 44);
                t1800.R0061 = Common.ToInt16(data, 46);
                t1800.R0063 = Common.ToInt16(data, 48);
                t1800.R0065 = Common.ToInt16(data, 50);
                t1800.R0067 = Common.ToInt16(data, 52);
                t1800.R0069 = Common.ToInt16(data, 54);
                t1800.R0073 = Common.GetString(data, 56, 8);
                t1800.R0081 = Common.ToInt16(data, 64);
                t1800.R0071 = Common.ToInt16(data, 66);
                t1800.R0073_1 = Common.ToInt16(data, 68);
                t1800.R0089 = Common.ToInt16(data, 84);
                t1800.R0091 = Common.ToInt16(data, 86);
                t1800.R0093 = Common.ToInt16(data, 88);
                t1800.R0095 = Common.ToInt16(data, 90);
                //log.Debug("t1800.R0095 = Common.ToInt16(data, 90); Finished.");

                //log.Debug("t1800.R0075 = T1800_I2_07.Parse(data, 70);");
                t1800.R0075 = T1800_I2_07.Parse(data, 70);
                //log.Debug("t1800.R0097 = T1800_I2_14.Parse(data, 92);");
                t1800.R0097 = T1800_I2_14.Parse(data, 92);
                //log.Debug("t1800.R0125 = T1800_I2_07.Parse(data, 120);");
                t1800.R0125 = T1800_I2_07.Parse(data, 120);
                //log.Debug("t1800.R0139 = T1800_I2_14.Parse(data, 134);");
                t1800.R0139 = T1800_I2_14.Parse(data, 134);
                //log.Debug("t1800.R0167 = T1800_I2_14.Parse(data, 162);");
                t1800.R0167 = T1800_I2_14.Parse(data, 162);
                //log.Debug("t1800.R0195 = T1800_I2_14.Parse(data, 190);");
                t1800.R0195 = T1800_I2_14.Parse(data, 190);
                //log.Debug("t1800.R0223 = T1800_I2_07.Parse(data, 218);");
                t1800.R0223 = T1800_I2_07.Parse(data, 218);
                //log.Debug("t1800.R0237 = T1800_I2_07.Parse(data, 232);");
                t1800.R0237 = T1800_I2_07.Parse(data, 232);
                //log.Debug("t1800.R0251 = T1800_I2_14.Parse(data, 246);");
                t1800.R0251 = T1800_I2_14.Parse(data, 246);
                //log.Debug("t1800.R0279 = T1800_I2_06.Parse(data, 274);");
                t1800.R0279 = T1800_I2_06.Parse(data, 274);
                //log.Debug("t1800.R0291 = T1800_I2_06_1.Parse(data, 286);");
                //t1800.R0291 = T1800_I2_06_1.Parse(data, 286); // ó\îı // ÇgÇbÉNÉâÉEÉì // ÅiÇPÉXÉLÉÉÉìñ⁄Åj // ÇÕédè„é¿ê—èÓïÒÇ÷à⁄ìÆ
                //log.Debug("t1800.R0401 = T1800_I2_45.Parse(data, 384);");
                t1800.R0401 = T1800_I2_45.Parse(data, 384);
                //log.Debug("t1800.R0491 = T1800_I2_45.Parse(data, 474);");
                t1800.R0491 = T1800_I2_45.Parse(data, 474);
                //log.Debug("t1800.R0581 = T1800_I2_45.Parse(data, 564);");
                t1800.R0581 = T1800_I2_45.Parse(data, 564);
                //log.Debug("t1800.R0671 = T1800_I2_45.Parse(data, 654);");
                t1800.R0671 = T1800_I2_45.Parse(data, 654);
                //log.Debug("t1800.R0761 = T1800_I2_45.Parse(data, 744);");
                t1800.R0761 = T1800_I2_45.Parse(data, 744);
                //log.Debug("t1800.R0851 = T1800_I2_45.Parse(data, 834);");
                t1800.R0851 = T1800_I2_45.Parse(data, 834);
                //log.Debug("t1800.R0941 = T1800_I2_45.Parse(data, 924);");
                t1800.R0941 = T1800_I2_45.Parse(data, 924);
                //log.Debug("t1800.R1031 = T1800_I2_45.Parse(data, 1014);");
                t1800.R1031 = T1800_I2_45.Parse(data, 1014);
                //log.Debug("t1800.R1121 = T1800_I2_45.Parse(data, 1104);");
                t1800.R1121 = T1800_I2_45.Parse(data, 1104);
                //log.Debug("t1800.R1211 = T1800_I2_45.Parse(data, 1194);");
                t1800.R1211 = T1800_I2_45.Parse(data, 1194);
                //log.Debug("t1800.R1301 = T1800_I2_45.Parse(data, 1284);");
                t1800.R1301 = T1800_I2_45.Parse(data, 1284);
                //log.Debug("t1800.R1391 = T1800_I2_45.Parse(data, 1374);");
                t1800.R1391 = T1800_I2_45.Parse(data, 1374);
                //log.Debug("t1800.R1481 = T1800_I2_45.Parse(data, 1464);");
                t1800.R1481 = T1800_I2_45.Parse(data, 1464);
                //log.Debug("t1800.R1571 = T1800_I2_45.Parse(data, 1554);");
                t1800.R1571 = T1800_I2_45.Parse(data, 1554);
                // HSS4 
                //log.Debug("t1800.R1661 = T1800_Extend_01.Parse(data, 1644);");
                t1800.R1661 = T1800_Extend_01.Parse(data, 1644);
                // End HSS4 
                // HSS5
                //log.Debug("t1800.R1749 = T1800_Extend_02.Parse(data, 1732);");
                t1800.R1749 = T1800_Extend_02.Parse(data, 1732);
                // End HSS5

                log.Debug("T1800.Parse() finished.");
            }
            catch (Exception ex)
            {
                log.Error("T1800.Parse() error.", ex);
                Console.WriteLine(ex.Message);
                return null;
            }
            log.Debug("T1800.Parse() successfull.");
            return t1800;
        }
        public Byte[] GetBytes()
        {
            Byte[] data = new Byte[1784];

            try
            {
                Buffer.BlockCopy(Common.GetBytes(TRANSACTION_CODE), 0, data, 0, 8);
                Buffer.BlockCopy(Common.GetBytes(_R0025), 0, data, 8, 8);
                Buffer.BlockCopy(Common.GetBytes(((Int16)_R0033 % 100)), 0, data, 16, 2);
                Buffer.BlockCopy(Common.GetBytes(_R0035), 0, data, 18, 2);
                Buffer.BlockCopy(Common.GetBytes(_R0037), 0, data, 20, 2);
                Buffer.BlockCopy(Common.GetBytes(_R0039), 0, data, 22, 2);
                Buffer.BlockCopy(Common.GetBytes(_R0041), 0, data, 24, 2);
                Buffer.BlockCopy(Common.GetBytes(_R0043), 0, data, 26, 2);
                Buffer.BlockCopy(Common.GetBytes(_R0043_1), 0, data, 28, 10);
                Buffer.BlockCopy(Common.GetBytes(_R0053), 0, data, 38, 6);
                Buffer.BlockCopy(Common.GetBytes(_R0059), 0, data, 44, 2);
                Buffer.BlockCopy(Common.GetBytes(_R0061), 0, data, 46, 2);
                Buffer.BlockCopy(Common.GetBytes(_R0063), 0, data, 48, 2);
                Buffer.BlockCopy(Common.GetBytes(_R0065), 0, data, 50, 2);
                Buffer.BlockCopy(Common.GetBytes(_R0067), 0, data, 52, 2);
                Buffer.BlockCopy(Common.GetBytes(_R0069), 0, data, 54, 2);
                Buffer.BlockCopy(Common.GetBytes(_R0073), 0, data, 56, 8);
                Buffer.BlockCopy(Common.GetBytes(_R0081), 0, data, 64, 2);
                Buffer.BlockCopy(Common.GetBytes(_R0071), 0, data, 66, 2);
                Buffer.BlockCopy(Common.GetBytes(_R0073_1), 0, data, 68, 2);
                Buffer.BlockCopy(Common.GetBytes(_R0089), 0, data, 84, 2);
                Buffer.BlockCopy(Common.GetBytes(_R0091), 0, data, 86, 2);
                Buffer.BlockCopy(Common.GetBytes(_R0093), 0, data, 88, 2);
                Buffer.BlockCopy(Common.GetBytes(_R0095), 0, data, 90, 2);

                Buffer.BlockCopy(R0075.GetBytes(), 0, data, 70, 14);
                Buffer.BlockCopy(R0097.GetBytes(), 0, data, 92, 28);
                Buffer.BlockCopy(R0125.GetBytes(), 0, data, 120, 14);
                Buffer.BlockCopy(R0139.GetBytes(), 0, data, 134, 28);
                Buffer.BlockCopy(R0167.GetBytes(), 0, data, 162, 28);
                Buffer.BlockCopy(R0195.GetBytes(), 0, data, 190, 28);
                Buffer.BlockCopy(R0223.GetBytes(), 0, data, 218, 14);
                Buffer.BlockCopy(R0237.GetBytes(), 0, data, 232, 14);
                Buffer.BlockCopy(R0251.GetBytes(), 0, data, 246, 28);
                Buffer.BlockCopy(R0279.GetBytes(), 0, data, 274, 12);
                //Buffer.BlockCopy(R0291.GetBytes(), 0, data, 286, 12);
                Buffer.BlockCopy(R0401.GetBytes(), 0, data, 384, 90);
                Buffer.BlockCopy(R0491.GetBytes(), 0, data, 474, 90);
                Buffer.BlockCopy(R0581.GetBytes(), 0, data, 564, 90);
                Buffer.BlockCopy(R0671.GetBytes(), 0, data, 654, 90);
                Buffer.BlockCopy(R0761.GetBytes(), 0, data, 744, 90);
                Buffer.BlockCopy(R0851.GetBytes(), 0, data, 834, 90);
                Buffer.BlockCopy(R0941.GetBytes(), 0, data, 924, 90);
                Buffer.BlockCopy(R1031.GetBytes(), 0, data, 1014, 90);
                Buffer.BlockCopy(R1121.GetBytes(), 0, data, 1104, 90);
                Buffer.BlockCopy(R1211.GetBytes(), 0, data, 1194, 90);
                Buffer.BlockCopy(R1301.GetBytes(), 0, data, 1284, 90);
                Buffer.BlockCopy(R1391.GetBytes(), 0, data, 1374, 90);
                Buffer.BlockCopy(R1481.GetBytes(), 0, data, 1464, 90);
                Buffer.BlockCopy(R1571.GetBytes(), 0, data, 1554, 90);
                // HSS4 
                Buffer.BlockCopy(R1661.GetBytes(), 0, data, 1644, 88);
                // End HSS4 
                // HSS5
                Buffer.BlockCopy(R1749.GetBytes(), 0, data, 1732, T1800_Extend_02.EXTEND_PAKAGE_LENGTH);
                // End HSS5
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            return data;
        }

        public bool Equals(T1800 t1800)
        {
            if (t1800 == null)
            {
                return false;
            }
            if (
                !_R0025.Equals(t1800.R0025, StringComparison.OrdinalIgnoreCase) ||
            _R0033 != t1800.R0033 ||
            _R0035 != t1800.R0035 ||
            _R0037 != t1800.R0037 ||
            _R0039 != t1800.R0039 ||
            !_R0041.Equals(t1800.R0041, StringComparison.OrdinalIgnoreCase) ||
            _R0043 != t1800.R0043 ||
            !_R0043_1.Equals(t1800.R0043_1, StringComparison.OrdinalIgnoreCase) ||
            !_R0053.Equals(t1800.R0053, StringComparison.OrdinalIgnoreCase) ||
            _R0059 != t1800.R0059 ||
            _R0061 != t1800.R0061 ||
            _R0063 != t1800.R0063 ||
            _R0065 != t1800.R0065 ||
            _R0067 != t1800.R0067 ||
            _R0069 != t1800.R0069 ||
            _R0071 != t1800.R0071 ||
            !_R0073.Equals(t1800._R0073, StringComparison.OrdinalIgnoreCase) ||
            _R0081 != t1800._R0081 ||
            _R0073_1 != t1800.R0073_1 ||
            _R0089 != t1800.R0089 ||
            _R0091 != t1800.R0091 ||
            _R0093 != t1800.R0093 ||
            _R0095 != t1800.R0095)
                return false;
            /*
            for (int i = 0; i < this._RowsChild.Length; i++)
            {
                if ((_RowsChild[i].Row == null && t1800._RowsChild[i].Row != null)
                    || (_RowsChild[i].Row != null && t1800._RowsChild[i].Row == null)
                    || !_RowsChild[i].Row.Equals(t1800._RowsChild[i]))
                {
                    return false;
                }
            }
            */
            if ((R0075 == null && t1800.R0075 != null) || (R0075 != null && t1800.R0075 == null) || !R0075.Equals(t1800.R0075)) return false;
            if ((R0097 == null && t1800.R0097 != null) || (R0097 != null && t1800.R0097 == null) || !R0097.Equals(t1800.R0097)) return false;
            if ((R0125 == null && t1800.R0125 != null) || (R0125 != null && t1800.R0125 == null) || !R0125.Equals(t1800.R0125)) return false;
            if ((R0139 == null && t1800.R0139 != null) || (R0139 != null && t1800.R0139 == null) || !R0139.Equals(t1800.R0139)) return false;
            if ((R0167 == null && t1800.R0167 != null) || (R0167 != null && t1800.R0167 == null) || !R0167.Equals(t1800.R0167)) return false;
            if ((R0195 == null && t1800.R0195 != null) || (R0195 != null && t1800.R0195 == null) || !R0195.Equals(t1800.R0195)) return false;
            if ((R0223 == null && t1800.R0223 != null) || (R0223 != null && t1800.R0223 == null) || !R0223.Equals(t1800.R0223)) return false;
            if ((R0237 == null && t1800.R0237 != null) || (R0237 != null && t1800.R0237 == null) || !R0237.Equals(t1800.R0237)) return false;
            if ((R0251 == null && t1800.R0251 != null) || (R0251 != null && t1800.R0251 == null) || !R0251.Equals(t1800.R0251)) return false;
            if ((R0279 == null && t1800.R0279 != null) || (R0279 != null && t1800.R0279 == null) || !R0279.Equals(t1800.R0279)) return false;
            //if ((R0291 == null && t1800.R0291 != null) || (R0291 != null && t1800.R0291 == null) || !R0291.Equals(t1800.R0291)) return false;
            if ((R0401 == null && t1800.R0401 != null) || (R0401 != null && t1800.R0401 == null) || !R0401.Equals(t1800.R0401)) return false;
            if ((R0491 == null && t1800.R0491 != null) || (R0491 != null && t1800.R0491 == null) || !R0491.Equals(t1800.R0491)) return false;
            if ((R0581 == null && t1800.R0581 != null) || (R0581 != null && t1800.R0581 == null) || !R0581.Equals(t1800.R0581)) return false;
            if ((R0671 == null && t1800.R0671 != null) || (R0671 != null && t1800.R0671 == null) || !R0671.Equals(t1800.R0671)) return false;
            if ((R0761 == null && t1800.R0761 != null) || (R0761 != null && t1800.R0761 == null) || !R0761.Equals(t1800.R0761)) return false;
            if ((R0851 == null && t1800.R0851 != null) || (R0851 != null && t1800.R0851 == null) || !R0851.Equals(t1800.R0851)) return false;
            if ((R0941 == null && t1800.R0941 != null) || (R0941 != null && t1800.R0941 == null) || !R0941.Equals(t1800.R0941)) return false;
            if ((R1031 == null && t1800.R1031 != null) || (R1031 != null && t1800.R1031 == null) || !R1031.Equals(t1800.R1031)) return false;
            if ((R1121 == null && t1800.R1121 != null) || (R1121 != null && t1800.R1121 == null) || !R1121.Equals(t1800.R1121)) return false;
            if ((R1211 == null && t1800.R1211 != null) || (R1211 != null && t1800.R1211 == null) || !R1211.Equals(t1800.R1211)) return false;
            if ((R1301 == null && t1800.R1301 != null) || (R1301 != null && t1800.R1301 == null) || !R1301.Equals(t1800.R1301)) return false;
            if ((R1391 == null && t1800.R1391 != null) || (R1391 != null && t1800.R1391 == null) || !R1391.Equals(t1800.R1391)) return false;
            if ((R1481 == null && t1800.R1481 != null) || (R1481 != null && t1800.R1481 == null) || !R1481.Equals(t1800.R1481)) return false;
            if ((R1571 == null && t1800.R1571 != null) || (R1571 != null && t1800.R1571 == null) || !R1571.Equals(t1800.R1571)) return false;
            // HSS4
            if ((R1661 == null && t1800.R1661 != null) || (R1661 != null && t1800.R1661 == null) || !R1571.Equals(t1800.R1661)) return false;
            // End HSS4 
            // HSS5
            if ((R1749 == null && t1800.R1749 != null) || (R1749 != null && t1800.R1749 == null) || !R1749.Equals(t1800.R1749)) return false;
            // End HSS5
            return true;
        }

        public T1800 GetPreviousResult()
        {
            if (_ID > 1)
            {
                WhereParameterCollection whereColl = new WhereParameterCollection();
                whereColl.Add(ID__COLUMN_NAME, _ID, CompareType.Less);
                //whereColl.Add(R0025__COLUMN_NAME, R0025, CompareType.Like);
                //whereColl.Add(R0033__COLUMN_NAME, R0033, CompareType.Equal);

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

                        return new T1800(preId);
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


        /////////////////////////////////////////////////////////////////////////////
        public DataSet GetCoilSearchData(CoilSearchStructure coilSearchStructure, string orderByCol, out int notPagingItemsCount)
        {

            DateTime beginDate = coilSearchStructure.BeginDate != string.Empty ? DateTime.ParseExact(coilSearchStructure.BeginDate, "yy/MM/dd", null, System.Globalization.DateTimeStyles.NoCurrentDateDefault) : DateTime.MaxValue;
            DateTime endDate = coilSearchStructure.EndDate != string.Empty ? DateTime.ParseExact(coilSearchStructure.EndDate, "yy/MM/dd", null, System.Globalization.DateTimeStyles.NoCurrentDateDefault) : DateTime.MaxValue;
            double cacbonBegin = coilSearchStructure.CacbonBegin;
            double cacbonEnd = coilSearchStructure.CacbonEnd;
            double thickBegin = coilSearchStructure.ThickBegin;
            double thickEnd = coilSearchStructure.ThickEnd;
            double widthBegin = coilSearchStructure.WidthBegin;
            double widthEnd = coilSearchStructure.WidthEnd;
            double temperatureBegin = coilSearchStructure.TemperatureBegin;
            double temperatureEnd = coilSearchStructure.TemperatureEnd;
            string coilNo = coilSearchStructure.CoilNo;
            string steelName = coilSearchStructure.SteelName;
            int groupA = coilSearchStructure.Group.A == true ? 1 : 0;
            int groupB = coilSearchStructure.Group.B == true ? 1 : 0;
            int groupC = coilSearchStructure.Group.C == true ? 1 : 0;
            int groupD = coilSearchStructure.Group.D == true ? 1 : 0;
            int f4Material = 0;
            int f5Material = 0;
            int f6Material = 0;
            int f7Material = 0;
            int[] workerIDs = new int[8];
            
            switch (coilSearchStructure.F4Material)
            {
                case RollMaterialSearch.Haisu:
                    {
                        f4Material = 1;
                        break;
                    }
                case RollMaterialSearch.Other:
                    {
                        f4Material = 2;
                        break;
                    }
                case RollMaterialSearch.Unknown:
                    {
                        f4Material = 0;
                        break;
                    }
            }

            switch (coilSearchStructure.F5Material)
            {
                case RollMaterialSearch.Haisu:
                    {
                        f5Material = 1;
                        break;
                    }
                case RollMaterialSearch.Other:
                    {
                        f5Material = 2;
                        break;
                    }
                case RollMaterialSearch.Unknown:
                    {
                        f5Material = 0;
                        break;
                    }
            }

            switch (coilSearchStructure.F6Material)
            {
                case RollMaterialSearch.Haisu:
                    {
                        f6Material = 1;
                        break;
                    }
                case RollMaterialSearch.Other:
                    {
                        f6Material = 2;
                        break;
                    }
                case RollMaterialSearch.Unknown:
                    {
                        f6Material = 0;
                        break;
                    }
            }

            switch (coilSearchStructure.F7Material)
            {
                case RollMaterialSearch.Haisu:
                    {
                        f7Material = 1;
                        break;
                    }
                case RollMaterialSearch.Other:
                    {
                        f7Material = 2;
                        break;
                    }
                case RollMaterialSearch.Unknown:
                    {
                        f7Material = 0;
                        break;
                    }
            }

            for (int i = 0; i < MAX_WORKER; i++)
            {
                if (i < coilSearchStructure.WorkerList.Count)
                {
                    workerIDs[i] = coilSearchStructure.WorkerList[i].ID;
                }
                else
                {
                    workerIDs[i] = -1;
                }
            }
            //<Parameter>
            ParameterCollection paraColl = new ParameterCollection();
            paraColl.Add("BeginDate", beginDate);
            paraColl.Add("EndDate", endDate);
            paraColl.Add("CacbonBegin", cacbonBegin);
            paraColl.Add("CacbonEnd", cacbonEnd);
            paraColl.Add("ThickBegin", thickBegin);
            paraColl.Add("ThickEnd", thickEnd);
            paraColl.Add("WidthBegin", widthBegin);
            paraColl.Add("WidthEnd", widthEnd);
            paraColl.Add("TemperatureBegin", temperatureBegin);
            paraColl.Add("TemperatureEnd", temperatureEnd);
            paraColl.Add("CoilNo", coilNo);
            paraColl.Add("SteelName", steelName);
            paraColl.Add("GroupA", groupA);
            paraColl.Add("GroupB", groupB);
            paraColl.Add("GroupC", groupC);
            paraColl.Add("GroupD", groupD);
            paraColl.Add("F4Material", f4Material);
            paraColl.Add("F5Material", f5Material);
            paraColl.Add("F6Material", f6Material);
            paraColl.Add("F7Material", f7Material);

            for (int i = 1; i <= MAX_WORKER; i++)
            {
                paraColl.Add("Worker" + i.ToString(), workerIDs[i - 1]);

            }

            paraColl.Add("PageNo", coilSearchStructure.PageNo);
            paraColl.Add("PageSize", coilSearchStructure.PageSize);            
            paraColl.Add("OrderBy", orderByCol);

            //</Parameter>

            ParameterCollection paraColl2 = new ParameterCollection();
            paraColl2.Add("BeginDate", beginDate);
            paraColl2.Add("EndDate", endDate);
            paraColl2.Add("CacbonBegin", cacbonBegin);
            paraColl2.Add("CacbonEnd", cacbonEnd);
            paraColl2.Add("ThickBegin", thickBegin);
            paraColl2.Add("ThickEnd", thickEnd);
            paraColl2.Add("WidthBegin", widthBegin);
            paraColl2.Add("WidthEnd", widthEnd);
            paraColl2.Add("TemperatureBegin", temperatureBegin);
            paraColl2.Add("TemperatureEnd", temperatureEnd);
            paraColl2.Add("CoilNo", coilNo);
            paraColl2.Add("SteelName", steelName);
            paraColl2.Add("GroupA", groupA);
            paraColl2.Add("GroupB", groupB);
            paraColl2.Add("GroupC", groupC);
            paraColl2.Add("GroupD", groupD);
            paraColl2.Add("F4Material", f4Material);
            paraColl2.Add("F5Material", f5Material);
            paraColl2.Add("F6Material", f6Material);
            paraColl2.Add("F7Material", f7Material);
            for (int i = 1; i <= MAX_WORKER; i++)
            {
                paraColl2.Add("Worker" + i.ToString(), workerIDs[i - 1]);

            }


            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                notPagingItemsCount = (int)_DBAccessor.ExecuteQueryProcedure("SearchCoilItemsCount", paraColl2).Tables[0].Rows[0][0];                                    
                DataSet data_Set = _DBAccessor.ExecuteQueryProcedure("SearchCoil", paraColl);
                return data_Set;

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (!this.db_Set && this._DBAccessor != null)
                {
                    _DBAccessor.Dispose();
                }
            }


        }
        /////////////////////////////////////////////////////////////////////////////
        public static T1800 GetCoilDetailOfYear(string coilNo, int year)
        {
            WhereParameterCollection whereColl = new WhereParameterCollection();
            whereColl.Add(R0025__COLUMN_NAME, coilNo, CompareType.Equal);
            whereColl.Add(R0033__COLUMN_NAME, year, CompareType.Equal);


            DBAccessor _DBAccessor = null;
            try
            {
                _DBAccessor = new DBAccessor();
                DataSet data_Set = _DBAccessor.GetTable(TABLE_NAME, whereColl);

                if (data_Set != null && data_Set.Tables[0].Rows.Count != 0)
                {
                    DataRow row = data_Set.Tables[0].Rows[0];
                    T1800 t1800 = new T1800();
                    t1800.FromDataRow(row);
                    return t1800;
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
        public DataSet GetCoilSearchAll(CoilSearchStructure coilSearchStructure)
        {

            DateTime beginDate = coilSearchStructure.BeginDate != string.Empty ? DateTime.ParseExact(coilSearchStructure.BeginDate, "yy/MM/dd", null, System.Globalization.DateTimeStyles.NoCurrentDateDefault) : DateTime.MaxValue;
            DateTime endDate = coilSearchStructure.EndDate != string.Empty ? DateTime.ParseExact(coilSearchStructure.EndDate, "yy/MM/dd", null, System.Globalization.DateTimeStyles.NoCurrentDateDefault) : DateTime.MaxValue;
            double cacbonBegin = coilSearchStructure.CacbonBegin;
            double cacbonEnd = coilSearchStructure.CacbonEnd;
            double thickBegin = coilSearchStructure.ThickBegin;
            double thickEnd = coilSearchStructure.ThickEnd;
            double widthBegin = coilSearchStructure.WidthBegin;
            double widthEnd = coilSearchStructure.WidthEnd;
            double temperatureBegin = coilSearchStructure.TemperatureBegin;
            double temperatureEnd = coilSearchStructure.TemperatureEnd;
            string coilNo = coilSearchStructure.CoilNo;
            string steelName = coilSearchStructure.SteelName;
            int groupA = coilSearchStructure.Group.A == true ? 1 : 0;
            int groupB = coilSearchStructure.Group.B == true ? 1 : 0;
            int groupC = coilSearchStructure.Group.C == true ? 1 : 0;
            int groupD = coilSearchStructure.Group.D == true ? 1 : 0;
            int f4Material = 0;
            int f5Material = 0;
            int f6Material = 0;
            int f7Material = 0;
            int[] workerIDs = new int[8];

            switch (coilSearchStructure.F4Material)
            {
                case RollMaterialSearch.Haisu:
                    {
                        f4Material = 1;
                        break;
                    }
                case RollMaterialSearch.Other:
                    {
                        f4Material = 2;
                        break;
                    }
                case RollMaterialSearch.Unknown:
                    {
                        f4Material = 0;
                        break;
                    }
            }

            switch (coilSearchStructure.F5Material)
            {
                case RollMaterialSearch.Haisu:
                    {
                        f5Material = 1;
                        break;
                    }
                case RollMaterialSearch.Other:
                    {
                        f5Material = 2;
                        break;
                    }
                case RollMaterialSearch.Unknown:
                    {
                        f5Material = 0;
                        break;
                    }
            }

            switch (coilSearchStructure.F6Material)
            {
                case RollMaterialSearch.Haisu:
                    {
                        f6Material = 1;
                        break;
                    }
                case RollMaterialSearch.Other:
                    {
                        f6Material = 2;
                        break;
                    }
                case RollMaterialSearch.Unknown:
                    {
                        f6Material = 0;
                        break;
                    }
            }

            switch (coilSearchStructure.F7Material)
            {
                case RollMaterialSearch.Haisu:
                    {
                        f7Material = 1;
                        break;
                    }
                case RollMaterialSearch.Other:
                    {
                        f7Material = 2;
                        break;
                    }
                case RollMaterialSearch.Unknown:
                    {
                        f7Material = 0;
                        break;
                    }
            }

            for (int i = 0; i < MAX_WORKER; i++)
            {
                if (i < coilSearchStructure.WorkerList.Count)
                {
                    workerIDs[i] = coilSearchStructure.WorkerList[i].ID;
                }
                else
                {
                    workerIDs[i] = -1;
                }
            }
            //<Parameter>
            ParameterCollection paraColl = new ParameterCollection();
            paraColl.Add("BeginDate", beginDate);
            paraColl.Add("EndDate", endDate);
            paraColl.Add("CacbonBegin", cacbonBegin);
            paraColl.Add("CacbonEnd", cacbonEnd);
            paraColl.Add("ThickBegin", thickBegin);
            paraColl.Add("ThickEnd", thickEnd);
            paraColl.Add("WidthBegin", widthBegin);
            paraColl.Add("WidthEnd", widthEnd);
            paraColl.Add("TemperatureBegin", temperatureBegin);
            paraColl.Add("TemperatureEnd", temperatureEnd);
            paraColl.Add("CoilNo", coilNo);
            paraColl.Add("SteelName", steelName);
            paraColl.Add("GroupA", groupA);
            paraColl.Add("GroupB", groupB);
            paraColl.Add("GroupC", groupC);
            paraColl.Add("GroupD", groupD);
            paraColl.Add("F4Material", f4Material);
            paraColl.Add("F5Material", f5Material);
            paraColl.Add("F6Material", f6Material);
            paraColl.Add("F7Material", f7Material);

            for (int i = 1; i <= MAX_WORKER; i++)
            {
                paraColl.Add("Worker" + i.ToString(), workerIDs[i - 1]);

            }

            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                DataSet data_Set = _DBAccessor.ExecuteQueryProcedure("SearchCoilAll", paraColl);
                return data_Set;

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (!this.db_Set && this._DBAccessor != null)
                {
                    _DBAccessor.Dispose();
                }
            }


        }

        public DataSet GetCoilList(CoilPressureDifferenceTotalStructure coilSearchStructure)
        {
            DateTime beginDate = coilSearchStructure.BeginDate != string.Empty ? DateTime.ParseExact(coilSearchStructure.BeginDate, "yy/MM/dd", null) : DateTime.MaxValue;
            DateTime endDate = coilSearchStructure.EndDate != string.Empty ? DateTime.ParseExact(coilSearchStructure.EndDate, "yy/MM/dd", null) : DateTime.MaxValue;

            int materialType = (int)coilSearchStructure.MaterialType;
            int stand = (int)coilSearchStructure.Stand;

            int f5Material = (int)coilSearchStructure.F5Material;
            int f6Material = (int)coilSearchStructure.F6Material;
            int f7Material = (int)coilSearchStructure.F7Material;

            string group = "";
            group += coilSearchStructure.Group.A ? " A " : "";
            group += coilSearchStructure.Group.B ? " B " : "";
            group += coilSearchStructure.Group.C ? " C " : "";
            group += coilSearchStructure.Group.D ? " D " : "";

            int[] workerIDs = new int[8];

            for (int i = 0; i < 8; i++)
            {
                if (i < coilSearchStructure.WorkerList.Count)
                {
                    workerIDs[i] = coilSearchStructure.WorkerList[i].ID;
                }
                else
                {
                    workerIDs[i] = -1;
                }
            }
            //<Parameter>
            ParameterCollection paraColl = new ParameterCollection();
            paraColl.Add("BeginDate", beginDate);
            paraColl.Add("EndDate", endDate);
            paraColl.Add("Material", materialType);
            paraColl.Add("Stand", stand);
            paraColl.Add("RollMaterialF5", f5Material);
            paraColl.Add("RollMaterialF6", f6Material);
            paraColl.Add("RollMaterialF7", f7Material);
            paraColl.Add("Group", group);

            for (int i = 1; i <= 8; i++)
            {
                paraColl.Add("Worker" + i.ToString(), workerIDs[i - 1]);

            }

            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                DataSet data_Set = _DBAccessor.ExecuteQueryProcedure("PressureDifferenceTotal", paraColl);
                return data_Set;

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (!this.db_Set && this._DBAccessor != null)
                {
                    _DBAccessor.Dispose();
                }
            }


        }
    }
}
