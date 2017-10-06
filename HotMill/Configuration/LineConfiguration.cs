using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Net;

namespace Kvics.Configuration
{
    /// <summary>
    /// 受信区分
    /// １：ＡＰ受渡し，２：ＡＰ取込み
    /// </summary>
    public enum ReceptionType
    {
        Unknown = 0,
        APDelivery = 1,
        APTaking = 2
    }

    /// <summary>
    /// 削除フラグ
    /// １：データ保持，２：データ削除
    /// </summary>
    public enum DeletionFlag
    {
        Unknown = 0,
        DataHold = 1,
        DataDeletion = 2
    }

    public interface IReadOnlyLineConfiguration : ICloneable
    {
        /// <summary>
        /// 回線番号
        /// </summary>
        Int32 LineCode
        {
            get;
        }

        /// <summary>
        /// 接続先１～５ ＩＰアドレス
        /// </summary>
        IPEndPoint ConnectIPEndPoint1
        {
            get;
        }

        /// <summary>
        /// 接続先１～５ ＩＰアドレス
        /// </summary>
        IPEndPoint ConnectIPEndPoint2
        {
            get;
        }

        /// <summary>
        /// 接続先１～５ ＩＰアドレス
        /// </summary>
        IPEndPoint ConnectIPEndPoint3
        {
            get;
        }

        /// <summary>
        /// 接続先１～５ ＩＰアドレス
        /// </summary>
        IPEndPoint ConnectIPEndPoint4
        {
            get;
        }

        /// <summary>
        /// 接続先１～５ ＩＰアドレス
        /// </summary>
        IPEndPoint ConnectIPEndPoint5
        {
            get;
        }

        /// <summary>
        /// 回線再接続待機時間
        /// </summary>
        Int32 ReconnectTimeout
        {
            get;
        }

        /// <summary>
        /// モード確認応答待ち時間
        /// </summary>
        Int32 ReplyModeTimeout
        {
            get;
        }

        /// <summary>
        /// 受信区分
        /// </summary>
        ReceptionType ReceptionType
        {
            get;
        }
        
        DeletionFlag DeletionFlag
        {
            get;
        }

        /// <summary>
        /// モード確認要求（送信用）
        /// </summary>
        String TransmittedDemand
        {
            get;
        }

        /// <summary>
        /// モード確認応答（送信用）
        /// </summary>
        String TransmittedResponse
        {
            get;
        }

        /// <summary>
        /// モード確認要求（受信用）
        /// </summary>
        String ReceivedResponse
        {
            get;
        }

        /// <summary>
        /// モード確認応答（受信用）
        /// </summary>
        String ReceivedDemand
        {
            get;
        }
    }

    public sealed class LineConfiguration : IReadOnlyLineConfiguration
    {
        public const Int32 ENTRIES = 14;

        /// <summary>
        /// Mode confirmation regex pattern
        /// </summary>
        public const String ModeConfirmationRegexPattern = "^[\\da-zA-Z]{8}$";

        private Boolean _IsReadOnly = false;

        public Boolean IsReadOnly
        {
            get
            {
                return this._IsReadOnly;
            }
            set
            {
                VerifyNotReadOnly();
                if (this._IsReadOnly == value)
                {
                    return;
                }

                this._IsReadOnly = value;
            }
        }

        private void VerifyNotReadOnly()
        {
            if (this._IsReadOnly)
            {
                throw new InvalidOperationException("Operation not allowed.");
            }
        }

        //////////////////////////////////////////////////////////////////////////
        // 設定ファイル [PcifDriver.info]
        //////////////////////////////////////////////////////////////////////////        

        #region LineCode 回線番号
        /// <summary>
        /// 回線番号
        /// </summary>
        private Int32 _LineCode;

        /// <summary>
        /// 回線番号
        /// </summary>
        public Int32 LineCode
        {
            get
            {
                return this._LineCode;
            }
            set
            {
                VerifyNotReadOnly();
                if (CheckLineCode(value))
                {
                    this._LineCode = value;
                }
            }
        }
        #endregion

        #region ConnectIPEndPoints 接続先１～５ ＩＰアドレス
        /// <summary>
        /// 接続先１～５ ＩＰアドレス
        /// </summary>
        private IPEndPoint _ConnectIPEndPoint1;

        /// <summary>
        /// 接続先１～５ ＩＰアドレス
        /// </summary>
        public IPEndPoint ConnectIPEndPoint1
        {
            get
            {
                return this._ConnectIPEndPoint1;
            }
            set
            {
                VerifyNotReadOnly();
                this._ConnectIPEndPoint1 = value;
            }
        }

        /// <summary>
        /// 接続先１～５ ＩＰアドレス
        /// </summary>
        private IPEndPoint _ConnectIPEndPoint2;

        /// <summary>
        /// 接続先１～５ ＩＰアドレス
        /// </summary>
        public IPEndPoint ConnectIPEndPoint2
        {
            get
            {
                return this._ConnectIPEndPoint2;
            }
            set
            {
                VerifyNotReadOnly();
                this._ConnectIPEndPoint2 = value;
            }
        }

        /// <summary>
        /// 接続先１～５ ＩＰアドレス
        /// </summary>
        private IPEndPoint _ConnectIPEndPoint3;

        /// <summary>
        /// 接続先１～５ ＩＰアドレス
        /// </summary>
        public IPEndPoint ConnectIPEndPoint3
        {
            get
            {
                return this._ConnectIPEndPoint3;
            }
            set
            {
                VerifyNotReadOnly();
                this._ConnectIPEndPoint3 = value;
            }
        }

        /// <summary>
        /// 接続先１～５ ＩＰアドレス
        /// </summary>
        private IPEndPoint _ConnectIPEndPoint4;

        /// <summary>
        /// 接続先１～５ ＩＰアドレス
        /// </summary>
        public IPEndPoint ConnectIPEndPoint4
        {
            get
            {
                return this._ConnectIPEndPoint4;
            }
            set
            {
                VerifyNotReadOnly();
                this._ConnectIPEndPoint4 = value;
            }
        }

        /// <summary>
        /// 接続先１～５ ＩＰアドレス
        /// </summary>
        private IPEndPoint _ConnectIPEndPoint5;

        /// <summary>
        /// 接続先１～５ ＩＰアドレス
        /// </summary>
        public IPEndPoint ConnectIPEndPoint5
        {
            get
            {
                return this._ConnectIPEndPoint5;
            }
            set
            {
                VerifyNotReadOnly();
                this._ConnectIPEndPoint5 = value;
            }
        }
        #endregion

        #region ReconnectTimeout 回線再接続待機時間
        /// <summary>
        /// 回線再接続待機時間
        /// </summary>
        private Int32 _ReconnectTimeout;

        /// <summary>
        /// 回線再接続待機時間
        /// </summary>
        public Int32 ReconnectTimeout
        {
            get
            {
                return this._ReconnectTimeout;
            }
            set
            {
                VerifyNotReadOnly();
                if (CheckReconnectTimeout(value))
                {
                    this._ReconnectTimeout = value;
                }
            }
        }
        #endregion

        #region ReplyModeTimeout モード確認応答待ち時間
        /// <summary>
        /// モード確認応答待ち時間
        /// </summary>
        private Int32 _ReplyModeTimeout;

        /// <summary>
        /// モード確認応答待ち時間
        /// </summary>
        public Int32 ReplyModeTimeout
        {
            get
            {
                return this._ReplyModeTimeout;
            }
            set
            {
                VerifyNotReadOnly();
                if (CheckReplyModeTimeout(value))
                {
                    this._ReplyModeTimeout = value;
                }
            }
        }
        #endregion

        #region ReceptionType 受信区分
        /// <summary>
        /// 受信区分
        /// </summary>
        private ReceptionType _ReceptionType = ReceptionType.Unknown;

        /// <summary>
        /// 受信区分
        /// </summary>
        public ReceptionType ReceptionType
        {
            get
            {
                return this._ReceptionType;
            }
            set
            {
                VerifyNotReadOnly();
                if (CheckReceptionType((Int32)value))
                {
                    this._ReceptionType = value;
                }
            }
        }
        #endregion

        #region DeletionFlag 削除フラグ
        /// <summary>
        /// 削除フラグ
        /// </summary>
        private DeletionFlag _DeletionFlag = DeletionFlag.Unknown;

        /// <summary>
        /// 削除フラグ
        /// </summary>
        public DeletionFlag DeletionFlag
        {
            get
            {
                return this._DeletionFlag;
            }
            set
            {
                VerifyNotReadOnly();
                if (CheckDeletionFlag((Int32)value))
                {
                    this._DeletionFlag = value;
                }
            }
        }
        #endregion

        #region TransmittedDemand モード確認要求（送信用）
        /// <summary>
        /// モード確認要求（送信用）
        /// </summary>
        private String _TransmittedDemand;

        /// <summary>
        /// モード確認要求（送信用）
        /// </summary>
        public String TransmittedDemand
        {
            get
            {
                return this._TransmittedDemand;
            }
            set
            {
                VerifyNotReadOnly();
                if (CheckModeConfirm(value))
                {
                    this._TransmittedDemand = value;
                }
            }
        }
        #endregion

        #region TransmittedResponse モード確認応答（送信用）
        /// <summary>
        /// モード確認応答（送信用）
        /// </summary>
        private String _TransmittedResponse;

        /// <summary>
        /// モード確認応答（送信用）
        /// </summary>
        public String TransmittedResponse
        {
            get
            {
                return this._TransmittedResponse;
            }
            set
            {
                VerifyNotReadOnly();
                if (CheckModeConfirm(value))
                {
                    this._TransmittedResponse = value;
                }
            }
        }
        #endregion

        #region ReceivedResponse モード確認要求（受信用）
        /// <summary>
        /// モード確認要求（受信用）
        /// </summary>
        private String _ReceivedResponse;

        /// <summary>
        /// モード確認要求（受信用）
        /// </summary>
        public String ReceivedResponse
        {
            get
            {
                return this._ReceivedResponse;
            }
            set
            {
                VerifyNotReadOnly();
                if (CheckModeConfirm(value))
                {
                    this._ReceivedResponse = value;
                }
            }
        }
        #endregion

        #region ReceivedDemand モード確認応答（受信用）
        /// <summary>
        /// モード確認応答（受信用）
        /// </summary>
        private String _ReceivedDemand;

        /// <summary>
        /// モード確認応答（受信用）
        /// </summary>
        public String ReceivedDemand
        {
            get
            {
                return this._ReceivedDemand;
            }
            set
            {
                VerifyNotReadOnly();
                if (CheckModeConfirm(value))
                {
                    this._ReceivedDemand = value;
                }
            }
        }
        #endregion

        public LineConfiguration(String config)
        {
            ReadConfigInfo(config);
        }

        private LineConfiguration(LineConfiguration cfg)
        {
            this._LineCode = cfg.LineCode;
            this._ConnectIPEndPoint1 = cfg.ConnectIPEndPoint1;
            this._ConnectIPEndPoint2 = cfg.ConnectIPEndPoint2;
            this._ConnectIPEndPoint3 = cfg.ConnectIPEndPoint3;
            this._ConnectIPEndPoint4 = cfg.ConnectIPEndPoint4;
            this._ConnectIPEndPoint5 = cfg.ConnectIPEndPoint5;
            this._ReconnectTimeout = cfg.ReconnectTimeout;
            this._ReplyModeTimeout = cfg.ReplyModeTimeout;
            this._ReceptionType = cfg.ReceptionType;
            this._DeletionFlag = cfg.DeletionFlag;
            this._TransmittedDemand = cfg.TransmittedDemand;
            this._TransmittedResponse = cfg.TransmittedResponse;
            this._ReceivedDemand = cfg.ReceivedDemand;
            this._ReceivedResponse = cfg.ReceivedResponse;
            this._IsReadOnly = cfg.IsReadOnly;
        }

        public LineConfiguration(IReadOnlyLineConfiguration cfg)
        {
            this._LineCode = cfg.LineCode;
            this._ConnectIPEndPoint1 = cfg.ConnectIPEndPoint1;
            this._ConnectIPEndPoint2 = cfg.ConnectIPEndPoint2;
            this._ConnectIPEndPoint3 = cfg.ConnectIPEndPoint3;
            this._ConnectIPEndPoint4 = cfg.ConnectIPEndPoint4;
            this._ConnectIPEndPoint5 = cfg.ConnectIPEndPoint5;
            this._ReconnectTimeout = cfg.ReconnectTimeout;
            this._ReplyModeTimeout = cfg.ReplyModeTimeout;
            this._ReceptionType = cfg.ReceptionType;
            this._DeletionFlag = cfg.DeletionFlag;
            this._TransmittedDemand = cfg.TransmittedDemand;
            this._TransmittedResponse = cfg.TransmittedResponse;
            this._ReceivedDemand = cfg.ReceivedDemand;
            this._ReceivedResponse = cfg.ReceivedResponse;
        }

        public Object Clone()
        {
            return new LineConfiguration(this);
        }

        public IReadOnlyLineConfiguration CloneReadOnly()
        {
            LineConfiguration cfg = (LineConfiguration)Clone();
            cfg.IsReadOnly = true;
            return cfg;
        }

        private void ReadConfigInfo(String config)
        {
            Hashtable hashConfig = ParseConfigInfo(config);
            this._LineCode = (Int32)hashConfig["LineCode"];
            this._ConnectIPEndPoint1 = (IPEndPoint)hashConfig["ConnectIPEndPoint1"];
            this._ConnectIPEndPoint2 = (IPEndPoint)hashConfig["ConnectIPEndPoint2"];
            this._ConnectIPEndPoint3 = (IPEndPoint)hashConfig["ConnectIPEndPoint3"];
            this._ConnectIPEndPoint4 = (IPEndPoint)hashConfig["ConnectIPEndPoint4"];
            this._ConnectIPEndPoint5 = (IPEndPoint)hashConfig["ConnectIPEndPoint5"];
            this._ReconnectTimeout = (Int32)hashConfig["ReconnectTimeout"];
            this._ReplyModeTimeout = (Int32)hashConfig["ReplyModeTimeout"];
            this._ReceptionType = (ReceptionType)hashConfig["ReceptionType"];
            this._DeletionFlag = (DeletionFlag)hashConfig["DeletionFlag"];
            this._TransmittedDemand = (String)hashConfig["TransmittedDemand"];
            this._TransmittedResponse = (String)hashConfig["TransmittedResponse"];
            this._ReceivedDemand = (String)hashConfig["ReceivedDemand"];
            this._ReceivedResponse = (String)hashConfig["ReceivedResponse"];
        }

        public static Hashtable ParseConfigInfo(String config)
        {
            Hashtable hashRet = new Hashtable();
            if (String.IsNullOrEmpty(config))
            {
                throw new ArgumentException("Line config can not be null or empty");
            }

            String[] info = config.Split(',');

            if (info.Length != ENTRIES)
            {
                throw new InvalidOperationException("Entries count in line config is invalid");
            }

            hashRet.Add("LineCode", ParseLineCode(info[0]));

            if (!String.IsNullOrEmpty(info[1]))
            {
                hashRet.Add("ConnectIPEndPoint1", ParseIPEndPoint(info[1]));
            }

            if (!String.IsNullOrEmpty(info[2]))
            {
                hashRet.Add("ConnectIPEndPoint2", ParseIPEndPoint(info[2]));
            }

            if (!String.IsNullOrEmpty(info[3]))
            {
                hashRet.Add("ConnectIPEndPoint3", ParseIPEndPoint(info[3]));
            }

            if (!String.IsNullOrEmpty(info[4]))
            {
                hashRet.Add("ConnectIPEndPoint4", ParseIPEndPoint(info[4]));
            }

            if (!String.IsNullOrEmpty(info[5]))
            {
                hashRet.Add("ConnectIPEndPoint5", ParseIPEndPoint(info[5]));
            }

            hashRet.Add("ReconnectTimeout", ParseReconnectTimeout(info[6]));
            hashRet.Add("ReplyModeTimeout", ParseReplyModeTimeout(info[7]));
            hashRet.Add("ReceptionType", ParseReceptionType(info[8]));
            hashRet.Add("DeletionFlag", ParseDeletionFlag(info[9]));
            hashRet.Add("TransmittedDemand", ParseModeConfirm(info[10]));
            hashRet.Add("TransmittedResponse", ParseModeConfirm(info[11]));
            hashRet.Add("ReceivedDemand", ParseModeConfirm(info[12]));
            hashRet.Add("ReceivedResponse", ParseModeConfirm(info[13]));

            return hashRet;
        }

        public String GetConfigInfo()
        {
            StringBuilder buff = new StringBuilder();
            buff.Append(this._LineCode.ToString() + ",");

            if (this._ConnectIPEndPoint1 == null)
            {
                buff.Append(",");
            }
            else
            {
                buff.Append(this._ConnectIPEndPoint1.ToString() + ",");
            }

            if (this._ConnectIPEndPoint2 == null)
            {
                buff.Append(",");
            }
            else
            {
                buff.Append(this._ConnectIPEndPoint2.ToString() + ",");
            }

            if (this._ConnectIPEndPoint3 == null)
            {
                buff.Append(",");
            }
            else
            {
                buff.Append(this._ConnectIPEndPoint3.ToString() + ",");
            }

            if (this._ConnectIPEndPoint4 == null)
            {
                buff.Append(",");
            }
            else
            {
                buff.Append(this._ConnectIPEndPoint4.ToString() + ",");
            }

            if (this._ConnectIPEndPoint5 == null)
            {
                buff.Append(",");
            }
            else
            {
                buff.Append(this._ConnectIPEndPoint5.ToString() + ",");
            }

            buff.Append(this._ReconnectTimeout.ToString() + ",");
            buff.Append(this._ReplyModeTimeout.ToString() + ",");
            buff.Append(((Int32)this._ReceptionType).ToString() + ",");
            buff.Append(((Int32)this._DeletionFlag).ToString() + ",");
            buff.Append(this._TransmittedDemand.ToString() + ",");
            buff.Append(this._TransmittedResponse.ToString() + ",");
            buff.Append(this._ReceivedDemand.ToString() + ",");
            buff.Append(this._ReceivedResponse.ToString());
            return buff.ToString();
        }

        public static System.Net.IPEndPoint ParseIPEndPoint(String value)
        {
            try
            {
                String[] addr = value.Split(':');
                if (addr.Length != 2)
                {
                    throw new InvalidOperationException();
                }

                try
                {
                    if (!System.Text.RegularExpressions.Regex.IsMatch(addr[0], "\\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\b"))
                    {
                        throw new InvalidOperationException();
                    }
                }
                catch (ArgumentException)
                {
                    // Syntax error in the regular expression
                }

                return new System.Net.IPEndPoint(System.Net.IPAddress.Parse(addr[0]),
                                                            Int32.Parse(addr[1]));
            }
            catch (Exception)
            {
                throw new ArgumentException("IP endpoint in line config is invalid");
            }
        }

        public static Boolean TryParseIPEndPoint(String value, out System.Net.IPEndPoint ret)
        {
            ret = null;
            Boolean bRet = true;
            try
            {
                ret = ParseIPEndPoint(value);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckIPEndPoint(String value)
        {
            Boolean bRet = true;
            try
            {
                ParseIPEndPoint(value);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static DeletionFlag ParseDeletionFlag(Int32 deletionFlag)
        {
            if (!(deletionFlag == (Int32)DeletionFlag.DataDeletion || deletionFlag == (Int32)DeletionFlag.DataHold))
            {
                throw new NotSupportedException("DeletionFlag value is invalid");
            }
            return (DeletionFlag)deletionFlag;
        }

        public static DeletionFlag ParseDeletionFlag(String deletionFlag)
        {
            try
            {
                return ParseDeletionFlag(Int32.Parse(deletionFlag));
            }
            catch (Exception)
            {
                throw new ArgumentException("DeletionFlag is not a integer");
            }
        }

        public static Boolean TryParseDeletionFlag(String deletionFlag, out DeletionFlag ret)
        {
            ret = DeletionFlag.Unknown;
            Boolean bRet = true;
            try
            {
                ret = ParseDeletionFlag(deletionFlag);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean TryParseDeletionFlag(Int32 deletionFlag, out DeletionFlag ret)
        {
            ret = DeletionFlag.Unknown;
            Boolean bRet = true;
            try
            {
                ret = ParseDeletionFlag(deletionFlag);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckDeletionFlag(String deletionFlag)
        {
            Boolean bRet = true;
            try
            {
                ParseDeletionFlag(deletionFlag);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckDeletionFlag(Int32 deletionFlag)
        {
            Boolean bRet = true;
            try
            {
                ParseDeletionFlag(deletionFlag);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static ReceptionType ParseReceptionType(Int32 receptionType)
        {
            if (!(receptionType == (Int32)ReceptionType.APDelivery || receptionType == (Int32)ReceptionType.APTaking))
            {
                throw new NotSupportedException("ReceptionType in line config is invalid");
            }
            return (ReceptionType)receptionType;
        }

        public static ReceptionType ParseReceptionType(String receptionType)
        {
            try
            {
                return ParseReceptionType(Int32.Parse(receptionType));
            }
            catch (Exception)
            {
                throw new ArgumentException("ReceptionType in line config is invalid");
            }
        }

        public static Boolean TryParseReceptionType(Int32 receptionType, out ReceptionType ret)
        {
            ret = ReceptionType.Unknown;
            Boolean bRet = true;
            try
            {
                ret = ParseReceptionType(receptionType);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean TryParseReceptionType(String receptionType, out ReceptionType ret)
        {
            ret = ReceptionType.Unknown;
            Boolean bRet = true;
            try
            {
                ret = ParseReceptionType(receptionType);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckReceptionType(Int32 receptionType)
        {
            Boolean bRet = true;
            try
            {
                ParseReceptionType(receptionType);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckReceptionType(String receptionType)
        {
            Boolean bRet = true;
            try
            {
                ParseReceptionType(receptionType);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Int32 ParseLineCode(Int32 lineCode)
        {
            if (lineCode <= 0)
            {
                throw new ArgumentOutOfRangeException("LineCode in line config is invalid");
            }
            return lineCode;
        }

        public static Int32 ParseLineCode(String lineCode)
        {
            try
            {
                return ParseLineCode(Int32.Parse(lineCode));
            }
            catch (Exception)
            {
                throw new ArgumentException("LineCode in line config is invalid");
            }
        }

        public static Boolean TryParseLineCode(Int32 lineCode, out Int32 ret)
        {
            ret = 0;
            Boolean bRet = true;
            try
            {
                ret = ParseLineCode(lineCode);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean TryParseLineCode(String lineCode, out Int32 ret)
        {
            ret = 0;
            Boolean bRet = true;
            try
            {
                ret = ParseLineCode(lineCode);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckLineCode(Int32 lineCode)
        {
            Boolean bRet = true;
            try
            {
                ParseLineCode(lineCode);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckLineCode(String lineCode)
        {
            Boolean bRet = true;
            try
            {
                ParseLineCode(lineCode);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Int32 ParseReconnectTimeout(Int32 reconnTimeout)
        {

            if (reconnTimeout < 0)
            {
                throw new ArgumentOutOfRangeException("ReconnectTimeout can not less than zero");
            }
            return reconnTimeout;
        }

        public static Int32 ParseReconnectTimeout(String reconnTimeout)
        {
            try
            {
                return ParseReconnectTimeout(Int32.Parse(reconnTimeout));
            }
            catch (Exception)
            {
                throw new ArgumentException("ReconnectTimeout in line config is invalid");
            }
        }

        public static Boolean TryParseReconnectTimeout(Int32 reconnTimeout, out Int32 ret)
        {
            ret = 0;
            Boolean bRet = true;
            try
            {
                ret = ParseReconnectTimeout(reconnTimeout);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean TryParseReconnectTimeout(String reconnTimeout, out Int32 ret)
        {
            ret = 0;
            Boolean bRet = true;
            try
            {
                ret = ParseReconnectTimeout(reconnTimeout);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckReconnectTimeout(Int32 reconnTimeout)
        {
            Boolean bRet = true;
            try
            {
                ParseReconnectTimeout(reconnTimeout);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckReconnectTimeout(String reconnTimeout)
        {
            Boolean bRet = true;
            try
            {
                ParseReconnectTimeout(reconnTimeout);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Int32 ParseReplyModeTimeout(Int32 replyModeTimeout)
        {

            if (replyModeTimeout < 0)
            {
                throw new ArgumentOutOfRangeException("ReplyModeTimeout can not less than zero");
            }
            return replyModeTimeout;
        }

        public static Int32 ParseReplyModeTimeout(String replyModeTimeout)
        {
            try
            {
                return ParseReplyModeTimeout(Int32.Parse(replyModeTimeout));
            }
            catch (Exception)
            {
                throw new ArgumentException("ReplyModeTimeout in line config is invalid");
            }
        }

        public static Boolean TryParseReplyModeTimeout(Int32 replyModeTimeout, out Int32 ret)
        {
            ret = 0;
            Boolean bRet = true;
            try
            {
                ret = ParseReplyModeTimeout(replyModeTimeout);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean TryParseReplyModeTimeout(String replyModeTimeout, out Int32 ret)
        {
            ret = 0;
            Boolean bRet = true;
            try
            {
                ret = ParseReplyModeTimeout(replyModeTimeout);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckReplyModeTimeout(Int32 replyModeTimeout)
        {
            Boolean bRet = true;
            try
            {
                ParseReplyModeTimeout(replyModeTimeout);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckReplyModeTimeout(String replyModeTimeout)
        {
            Boolean bRet = true;
            try
            {
                ParseReplyModeTimeout(replyModeTimeout);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static String ParseModeConfirm(String confirm)
        {
            if (String.IsNullOrEmpty(confirm))
            {
                throw new ArgumentException("ModeConfirm can not be null or empty");
            }
            else
            {
                confirm = confirm.Trim();
                try
                {
                    if (!System.Text.RegularExpressions.Regex.IsMatch(confirm, ModeConfirmationRegexPattern))
                    {
                        throw new ArgumentException("ModeConfirm is not match mode confirmation pattern");
                    }
                }
                catch (Exception)
                {
                    throw new ArgumentException("ModeConfirm in line config is invalid");
                }
            }

            return confirm;
        }

        public static Boolean TryParseModeConfirm(String confirm, out String ret)
        {
            ret = null;
            Boolean bRet = true;
            try
            {
                ret = ParseModeConfirm(confirm);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckModeConfirm(String confirm)
        {
            Boolean bRet = true;
            try
            {
                ParseModeConfirm(confirm);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }
    }
}