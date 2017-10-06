using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace Kvics.Configuration
{
    /// <summary>
    /// ���[�h�m�F�p�̃}�V�����[�h
    /// �P�F�{�ԁC�Q�F�e�X�g
    /// </summary>
    public enum MachineMode
    {
        Unknown = 0,
        Online = 1,
        Test = 2
    }

    /// <summary>
    /// �R�l�N�V�����ُ��̍Đڑ��L���w��
    /// �O�F�Đڑ��Ȃ��C�P�F�Đڑ�����
    /// </summary>
    public enum ConnectErrorAction
    {
        Unknown = -1,
        Reconnect = 0,
        NoReconnect = 1
    }

    /// <summary>
    /// Read only hash table for line definitions
    /// </summary>
    public class ReadOnlyLineDefinitions
    {
        Hashtable _Definitions = new Hashtable();

        public ReadOnlyLineDefinitions(Hashtable defs)
        {
            if (defs == null)
            {
                throw new ArgumentNullException();
            }
            this._Definitions = defs;
        }

        /// <summary>
        /// Collection values
        /// </summary>
        public ICollection Values
        {
            get
            {
                return this._Definitions.Values;
            }
        }

        /// <summary>
        /// Collection keys
        /// </summary>
        public ICollection Keys
        {
            get
            {
                return this._Definitions.Keys;
            }
        }

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="lineCode">Line code</param>
        /// <returns>Read only Line definition</returns>
        public IReadOnlyLineDefinition this[Int32 lineCode]
        {
            get
            {
                return ((LineDefinition)this._Definitions[lineCode]).CloneReadOnly();
            }
        }
    }

    public class ReadOnlyLineConfigurations
    {
        Hashtable _Configurations = new Hashtable();

        public ReadOnlyLineConfigurations(Hashtable cfgs)
        {
            if (cfgs == null)
            {
                throw new ArgumentNullException();
            }
            this._Configurations = cfgs;
        }

        public ICollection Values
        {
            get
            {
                return this._Configurations.Values;
            }
        }

        public ICollection Keys
        {
            get
            {
                return this._Configurations.Keys;
            }
        }

        public IReadOnlyLineConfiguration this[Int32 lineCode]
        {
            get
            {
                return ((LineConfiguration)this._Configurations[lineCode]).CloneReadOnly();
            }
        }
    }

    public interface IReadOnlyDriverInfo : ICloneable
    {
        ReadOnlyLineDefinitions ReadOnlyLineDefinitions
        {
            get;
        }

        ReadOnlyLineConfigurations ReadOnlyLineConfigurations
        {
            get;
        }

        IniFile IniFile
        {
            get;
        }

        /// <summary>
        /// �}�V�����[�h MachineMode
        /// </summary>
        MachineMode MachineMode
        {
            get;
        }

        /// <summary>
        /// ����ő吔 LineNumMax
        /// </summary>
        Int32 LineNumMax
        {
            get;
        }

        /// <summary>
        /// �����`���ݒ�t�@�C������ LineInfoName
        /// </summary>
        String LineInfoName
        {
            get;
        }

        /// <summary>
        /// �R�l�N�V���������i���M�j�e�[�u������ ConnectTblSendMax
        /// </summary>
        Int32 ConnectTblSendMax
        {
            get;
        }

        /// <summary>
        /// �R�l�N�V���������i��M�j�e�[�u������ ConnectTblRecvMax
        /// </summary>
        Int32 ConnectTblRecvMax
        {
            get;
        }

        /// <summary>
        /// �R�l�N�V�����ُ��Đڑ��L�� ConnectErrAction
        /// </summary>
        ConnectErrorAction ConnectErrAction
        {
            get;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public sealed class DriverInfo : IReadOnlyDriverInfo
    {
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

        private IniFile _IniFile;
        public IniFile IniFile
        {
            get
            {
                return this._IniFile;
            }
        }

        public ReadOnlyLineDefinitions ReadOnlyLineDefinitions
        {
            get
            {
                return (new ReadOnlyLineDefinitions(this._LineDefinitions));
            }
        }

        private Hashtable _LineDefinitions = new Hashtable();
        public Hashtable LineDefinitions
        {
            get
            {
                return this._LineDefinitions;
            }
        }

        public ReadOnlyLineConfigurations ReadOnlyLineConfigurations
        {
            get
            {
                return (new ReadOnlyLineConfigurations(this._LineConfigurations));
            }
        }

        private Hashtable _LineConfigurations = new Hashtable();       
        public Hashtable LineConfigurations
        {
            get
            {
                return this._LineConfigurations;
            }
        }

        //////////////////////////////////////////////////////////////////////////        
        // �V�X�e���ݒ���Z�N�V���� [PcifDriverSystemConstant]         
        //////////////////////////////////////////////////////////////////////////        

        /// <summary>
        /// �}�V�����[�h MachineMode
        /// </summary>
        private MachineMode _MachineMode = MachineMode.Unknown;

        /// <summary>
        /// �}�V�����[�h MachineMode
        /// </summary>
        public MachineMode MachineMode
        {
            get
            {
                return this._MachineMode;
            }
            set
            {
                VerifyNotReadOnly();
                if (CheckMachineMode((Int32)value))
                {
                    UpdateMachineMode(value, false);
                }
            }
        }

        /// <summary>
        /// ����ő吔 LineNumMax
        /// </summary>
        private Int32 _LineNumMax;

        /// <summary>
        /// ����ő吔 LineNumMax
        /// </summary>
        public Int32 LineNumMax
        {
            get
            {
                return this._LineNumMax;
            }
            set
            {
                VerifyNotReadOnly();
                if (CheckLineNumMax(value))
                {
                    UpdateLineNumMax(value, false);
                }
            }
        }

        /// <summary>
        /// �����`���ݒ�t�@�C������ LineInfoName
        /// </summary>
        private String _LineInfoName;

        /// <summary>
        /// �����`���ݒ�t�@�C������ LineInfoName
        /// </summary>
        public String LineInfoName
        {
            get
            {
                return this._LineInfoName;
            }
            set
            {
                VerifyNotReadOnly();
                if (CheckLineInfoName(value))
                {
                    UpdateLineInfoName(value, false);
                }
            }
        }

        /// <summary>
        /// �R�l�N�V���������i���M�j�e�[�u������ ConnectTblSendMax
        /// </summary>
        private Int32 _ConnectTblSendMax;

        /// <summary>
        /// �R�l�N�V���������i���M�j�e�[�u������ ConnectTblSendMax
        /// </summary>
        public Int32 ConnectTblSendMax
        {
            get
            {
                return this._ConnectTblSendMax;
            }
            set
            {
                VerifyNotReadOnly();
                if (CheckConnectTblSendMax(value))
                {
                    UpdateConnectTblSendMax(value, false);
                }
            }
        }

        /// <summary>
        /// �R�l�N�V���������i��M�j�e�[�u������ ConnectTblRecvMax
        /// </summary>
        private Int32 _ConnectTblRecvMax;

        /// <summary>
        /// �R�l�N�V���������i��M�j�e�[�u������ ConnectTblRecvMax
        /// </summary>
        public Int32 ConnectTblRecvMax
        {
            get
            {
                return this._ConnectTblRecvMax;
            }
            set
            {
                VerifyNotReadOnly();
                if (CheckConnectTblRecvMax(value))
                {
                    UpdateConnectTblRecvMax(value, false);
                }
            }
        }

        /// <summary>
        /// �R�l�N�V�����ُ��Đڑ��L�� ConnectErrAction
        /// </summary>
        private ConnectErrorAction _ConnectErrAction = ConnectErrorAction.Unknown;

        /// <summary>
        /// �R�l�N�V�����ُ��Đڑ��L�� ConnectErrAction
        /// </summary>
        public ConnectErrorAction ConnectErrAction
        {
            get
            {
                return this._ConnectErrAction;
            }
            set
            {
                VerifyNotReadOnly();
                if (CheckConnectErrAction((Int32)value))
                {
                    UpdateConnectErrAction(value, false);
                }
            }
        }

        public DriverInfo(String fn)
        {
            this._IniFile = new IniFile(fn);
            Initialize();
        }

        private DriverInfo(DriverInfo inf)
        {
            this._ConnectErrAction = inf.ConnectErrAction;
            this._ConnectTblRecvMax = inf.ConnectTblRecvMax;
            this._ConnectTblSendMax = inf.ConnectTblSendMax;
            this._IniFile = new IniFile(inf.IniFile);
            this._LineInfoName = inf.LineInfoName;
            this._LineNumMax = inf.LineNumMax;
            this._MachineMode = inf.MachineMode;
            this._IsReadOnly = inf.IsReadOnly;
            this._LineDefinitions = new Hashtable(inf.LineDefinitions);
            this._LineConfigurations = new Hashtable(inf.LineConfigurations);
        }

        public DriverInfo(IReadOnlyDriverInfo inf)
        {
            this._ConnectErrAction = inf.ConnectErrAction;
            this._ConnectTblRecvMax = inf.ConnectTblRecvMax;
            this._ConnectTblSendMax = inf.ConnectTblSendMax;
            this._IniFile = new IniFile(inf.IniFile.FileName);
            this._LineInfoName = inf.LineInfoName;
            this._LineNumMax = inf.LineNumMax;
            this._MachineMode = inf.MachineMode;
            foreach(Object en in inf.ReadOnlyLineDefinitions.Keys) 
            {
                IReadOnlyLineDefinition def = inf.ReadOnlyLineDefinitions[(Int32)en];
                this._LineDefinitions.Add(def.LineCode, new LineDefinition(def));
            }

            foreach (Object en in inf.ReadOnlyLineConfigurations.Keys)
            {
                IReadOnlyLineConfiguration cfg = inf.ReadOnlyLineConfigurations[(Int32)en];
                this._LineConfigurations.Add(cfg.LineCode, new LineConfiguration(cfg));
            }
        }

        public Object Clone()
        {
            return new DriverInfo(this);
        }

        public IReadOnlyDriverInfo CloneReadOnly()
        {
            DriverInfo inf = (DriverInfo)Clone();
            inf.IsReadOnly = true;
            inf.IniFile.IsReadOnly = true;
            return inf;
        }

        private void Initialize()
        {
            EnumerateLineDefinitions();

            ReadMachineMode();
            ReadLineNumMax();
            ReadLineInfoName();
            ReadConnectTblSendMax();
            ReadConnectTblRecvMax();
            ReadConnectErrAction();

            ReadLineConfiguration();
        }

        public void Validate()
        {
            VerifyNotReadOnly();
            Initialize();
        }

        public void SaveLineDefinitions()
        {
            VerifyNotReadOnly();
            // Clear definition
            LineDefinition def = null;
            foreach (DictionaryEntry en in this.LineDefinitions)
            {
                def = (LineDefinition)en.Value;
                if (def.Valid)
                {
                    this._IniFile.SetValue("PcifDriverSystemConstant", "ConnectIpSetFile" + def.LineCode, def.ConnectIpSetFile);
                    this._IniFile.SetValue("PcifDriverBufferConstant", "SndBufSize" + def.LineCode, def.SndBufSize);
                    this._IniFile.SetValue("PcifDriverBufferConstant", "RcvBufSize" + def.LineCode, def.RcvBufSize);
                    this._IniFile.SetValue("PcifDriverTraceConstant", "LogFileName" + def.LineCode, def.LogFileName);
                    this._IniFile.SetValue("PcifDriverTraceConstant", "TrcNoFileName" + def.LineCode, def.TrcNoFileName);
                    this._IniFile.SetValue("PcifDriverTraceConstant", "TrcFileMax" + def.LineCode, def.TrcFileMax);
                    this._IniFile.SetValue("PcifDriverTraceConstant", "TrcMemMax" + def.LineCode, def.TrcMemMax);
                    this._IniFile.SetValue("PcifDriverTraceConstant", "TrcDiskMax" + def.LineCode, def.TrcDiskMax);
                    this._IniFile.SetValue("PcifDriverTraceConstant", "TrcWriteInt" + def.LineCode, def.TrcWriteInt);
                    this._IniFile.SetValue("PcifDriverTraceConstant", "TrcEditMode" + def.LineCode, (Int32)def.TrcEditMode);
                }
            }
        }

        public void SaveLineConfigurations()
        {
            VerifyNotReadOnly();
            using (System.IO.StreamWriter st = new System.IO.StreamWriter(this._LineInfoName,false))
            {
                foreach (DictionaryEntry en in this.LineConfigurations)
                {
                    LineConfiguration cfg = (LineConfiguration)en.Value;
                    st.WriteLine(cfg.GetConfigInfo());
                }
            }
        }

        public void SaveDriverInfo()
        {
            UpdateConnectErrAction(this._ConnectErrAction, true);
            UpdateConnectTblRecvMax(this._ConnectTblRecvMax, true);
            UpdateConnectTblSendMax(this._ConnectTblSendMax, true);
            UpdateLineInfoName(this._LineInfoName, true);
            UpdateLineNumMax(this._LineNumMax, true);
            UpdateMachineMode(this._MachineMode, true);            
        }

        public static MachineMode ParseMachineMode(Int32 machineMode)
        {
            if (!(machineMode == (Int32)MachineMode.Online || machineMode == (Int32)MachineMode.Test))
            {
                throw new InvalidOperationException();
            }
            return (MachineMode)machineMode;
        }

        public static MachineMode ParseMachineMode(String machineMode)
        {
            try
            {
                return ParseMachineMode(Int32.Parse(machineMode));
            }
            catch (Exception)
            {
                throw new ArgumentException("MachineMode in line config is invalid");
            }
        }

        public static Boolean TryParseMachineMode(Int32 machineMode, out MachineMode ret)
        {
            ret = MachineMode.Unknown;
            Boolean bRet = true;
            try
            {
                ret = ParseMachineMode(machineMode);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean TryParseMachineMode(String machineMode, out MachineMode ret)
        {
            ret = MachineMode.Unknown;
            Boolean bRet = true;
            try
            {
                ret = ParseMachineMode(machineMode);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckMachineMode(Int32 machineMode)
        {
            Boolean bRet = true;
            try
            {
                ParseMachineMode(machineMode);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckMachineMode(String machineMode)
        {
            Boolean bRet = true;
            try
            {
                ParseMachineMode(machineMode);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Int32 ParseLineNumMax(Int32 lineNum)
        {
            if (lineNum <= 0)
            {
                throw new ArgumentOutOfRangeException("LineNumMax in line config is invalid");
            }
            return lineNum;
        }

        public static Int32 ParseLineNumMax(String lineNum)
        {
            try
            {
                return ParseLineNumMax(Int32.Parse(lineNum));
            }
            catch (Exception)
            {
                throw new ArgumentException("LineNumMax in line config is invalid");
            }
        }

        public static Boolean TryParseLineNumMax(Int32 lineNum, out Int32 ret)
        {
            ret = 0;
            Boolean bRet = true;
            try
            {
                ret = ParseLineNumMax(lineNum);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean TryParseLineNumMax(String lineNum, out Int32 ret)
        {
            ret = 0;
            Boolean bRet = true;
            try
            {
                ret = ParseLineNumMax(lineNum);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckLineNumMax(Int32 lineNum)
        {
            Boolean bRet = true;
            try
            {
                ParseLineNumMax(lineNum);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckLineNumMax(String lineNum)
        {
            Boolean bRet = true;
            try
            {
                ParseLineNumMax(lineNum);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Int32 ParseConnectTblSendMax(Int32 sendMax)
        {
            if (sendMax <= 0)
            {
                throw new ArgumentOutOfRangeException("ConnectTblSendMax in line config is invalid");
            }
            return sendMax;
        }

        public static Int32 ParseConnectTblSendMax(String sendMax)
        {
            try
            {
                return ParseConnectTblSendMax(Int32.Parse(sendMax));
            }
            catch (Exception)
            {
                throw new ArgumentException("ConnectTblSendMax in line config is invalid");
            }
        }

        public static Boolean TryParseConnectTblSendMax(Int32 sendMax, out Int32 ret)
        {
            ret = 0;
            Boolean bRet = true;
            try
            {
                ret = ParseConnectTblSendMax(sendMax);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean TryParseConnectTblSendMax(String sendMax, out Int32 ret)
        {
            ret = 0;
            Boolean bRet = true;
            try
            {
                ret = ParseConnectTblSendMax(sendMax);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckConnectTblSendMax(Int32 sendMax)
        {
            Boolean bRet = true;
            try
            {
                ParseConnectTblSendMax(sendMax);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckConnectTblSendMax(String sendMax)
        {
            Boolean bRet = true;
            try
            {
                ParseConnectTblSendMax(sendMax);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Int32 ParseConnectTblRecvMax(Int32 recvMax)
        {
            if (recvMax <= 0)
            {
                throw new ArgumentOutOfRangeException("ConnectTblRecvMax in line config is invalid");
            }
            return recvMax;
        }

        public static Int32 ParseConnectTblRecvMax(String recvMax)
        {
            try
            {
                return ParseConnectTblRecvMax(Int32.Parse(recvMax));
            }
            catch (Exception)
            {
                throw new ArgumentException("ConnectTblRecvMax in line config is invalid");
            }
        }

        public static Boolean TryParseConnectTblSRecvMax(Int32 recvMax, out Int32 ret)
        {
            ret = 0;
            Boolean bRet = true;
            try
            {
                ret = ParseConnectTblRecvMax(recvMax);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean TryParseConnectTblRecvMax(String recvMax, out Int32 ret)
        {
            ret = 0;
            Boolean bRet = true;
            try
            {
                ret = ParseConnectTblRecvMax(recvMax);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckConnectTblRecvMax(Int32 recvMax)
        {
            Boolean bRet = true;
            try
            {
                ParseConnectTblRecvMax(recvMax);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckConnectTblRecvMax(String recvMax)
        {
            Boolean bRet = true;
            try
            {
                ParseConnectTblRecvMax(recvMax);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static ConnectErrorAction ParseConnectErrAction(Int32 errAction)
        {
            if (!(errAction == (Int32)ConnectErrorAction.Reconnect || errAction == (Int32)ConnectErrorAction.NoReconnect))
            {
                throw new InvalidOperationException();
            }
            return (ConnectErrorAction)errAction;
        }

        public static ConnectErrorAction ParseConnectErrAction(String errAction)
        {
            try
            {
                return ParseConnectErrAction(Int32.Parse(errAction));
            }
            catch (Exception)
            {
                throw new ArgumentException("ConnectErrAction in line config is invalid");
            }
        }

        public static Boolean TryParseConnectErrActione(Int32 errAction, out ConnectErrorAction ret)
        {
            ret = ConnectErrorAction.Unknown;
            Boolean bRet = true;
            try
            {
                ret = ParseConnectErrAction(errAction);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean TryParseConnectErrAction(String errAction, out ConnectErrorAction ret)
        {
            ret = ConnectErrorAction.Unknown;
            Boolean bRet = true;
            try
            {
                ret = ParseConnectErrAction(errAction);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckConnectErrAction(Int32 errAction)
        {
            Boolean bRet = true;
            try
            {
                ParseConnectErrAction(errAction);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckConnectErrAction(String errAction)
        {
            Boolean bRet = true;
            try
            {
                ParseConnectErrAction(errAction);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        private void ReadMachineMode()
        {
            // �V�X�e���ݒ���Z�N�V����
            String section = "PcifDriverSystemConstant";
            // �}�V�����[�h
            String key = "MachineMode";

            this._MachineMode = ParseMachineMode(this._IniFile.GetValue(section, key).ToString());
        }

        private void UpdateMachineMode(MachineMode machineMode, Boolean save)
        {
            if (save)
            {
                // �V�X�e���ݒ���Z�N�V����
                String section = "PcifDriverSystemConstant";
                // �}�V�����[�h
                String key = "MachineMode";

                this._IniFile.SetValue(section, key, (Int32)machineMode);
                // Update MachineMode
                ReadMachineMode();
                Trace.Assert(machineMode.Equals(this._MachineMode));
            }
            else
            {
                this._MachineMode = machineMode;
            }
        }

        private void ReadLineNumMax()
        {
            // �V�X�e���ݒ���Z�N�V����
            String section = "PcifDriverSystemConstant";
            // ����ő吔
            String key = "LineNumMax";

            this._LineNumMax = ParseLineNumMax(this._IniFile.GetValue(section, key).ToString());
        }

        private void UpdateLineNumMax(Int32 numMax, Boolean save)
        {
            if (save)
            {
                // �V�X�e���ݒ���Z�N�V����
                String section = "PcifDriverSystemConstant";
                // ����ő吔
                String key = "LineNumMax";

                this._IniFile.SetValue(section, key, numMax);
                // Update LineNumMax
                ReadLineNumMax();
                Trace.Assert(numMax.Equals(this._LineNumMax));
            }
            else
            {
                this._LineNumMax = numMax;
            }
        }

        private void ReadLineInfoName()
        {
            // �V�X�e���ݒ���Z�N�V����
            String section = "PcifDriverSystemConstant";
            // �����`���ݒ�t�@�C������
            String key = "LineInfoName";

            String value = this._IniFile.GetValue(section, key, String.Empty);
            if (!CheckLineInfoName(value))
            {
                throw new System.IO.FileNotFoundException("LineInfoName not found");
            }

            this._LineInfoName = value;
        }

        public static Boolean CheckLineInfoName(String fn)
        {
            return System.IO.File.Exists(fn);
        }

        public void UpdateLineInfoName(String fn, Boolean save)
        {
            if (save)
            {
                // �V�X�e���ݒ���Z�N�V����
                String section = "PcifDriverSystemConstant";
                // �����`���ݒ�t�@�C������
                String key = "LineInfoName";

                this._IniFile.SetValue(section, key, fn);
                // Update LineInfoName
                ReadLineInfoName();
                Trace.Assert(fn.Equals(this._LineInfoName));
            }
            else
            {
                this._LineInfoName = fn;
            }

            // Update line configuration
            ReadLineConfiguration();
        }

        private void ReadConnectTblSendMax()
        {
            // �V�X�e���ݒ���Z�N�V����
            String section = "PcifDriverSystemConstant";
            // �R�l�N�V���������i���M�j�e�[�u������
            String key = "ConnectTblSendMax";

            this._ConnectTblSendMax = ParseConnectTblSendMax(this._IniFile.GetValue(section, key).ToString());
        }

        private void UpdateConnectTblSendMax(Int32 size, Boolean save)
        {
            if (save)
            {
                // �V�X�e���ݒ���Z�N�V����
                String section = "PcifDriverSystemConstant";
                // �R�l�N�V���������i���M�j�e�[�u������
                String key = "ConnectTblSendMax";

                this._IniFile.SetValue(section, key, size);
                // Update ConnectTblSendMax
                ReadConnectTblSendMax();
                Trace.Assert(size.Equals(this._ConnectTblSendMax));
            }
            else
            {
                this._ConnectTblSendMax = size;
            }
        }

        private void ReadConnectTblRecvMax()
        {
            // �V�X�e���ݒ���Z�N�V����
            String section = "PcifDriverSystemConstant";
            // �R�l�N�V���������i��M�j�e�[�u������
            String key = "ConnectTblRecvMax";

            this._ConnectTblRecvMax = ParseConnectTblRecvMax(this._IniFile.GetValue(section, key).ToString());
        }

        private void UpdateConnectTblRecvMax(Int32 size, Boolean save)
        {
            if (save)
            {
                // �V�X�e���ݒ���Z�N�V����
                String section = "PcifDriverSystemConstant";
                // �R�l�N�V���������i��M�j�e�[�u������
                String key = "ConnectTblRecvMax";

                this._IniFile.SetValue(section, key, size);
                // Update ConnectTblSendMax
                ReadConnectTblRecvMax();
                Trace.Assert(size.Equals(this._ConnectTblRecvMax));
            }
            else
            {
                this._ConnectTblRecvMax = size;
            }
        }

        private void ReadConnectErrAction()
        {
            // �V�X�e���ݒ���Z�N�V����
            String section = "PcifDriverSystemConstant";
            // �R�l�N�V�����ُ��Đڑ��L��
            String key = "ConnectErrAction";

            this._ConnectErrAction = ParseConnectErrAction(this._IniFile.GetValue(section, key).ToString());
        }

        private void UpdateConnectErrAction(ConnectErrorAction errAction, Boolean save)
        {
            if (save)
            {
                // �V�X�e���ݒ���Z�N�V����
                String section = "PcifDriverSystemConstant";
                // �R�l�N�V�����ُ��Đڑ��L��
                String key = "ConnectErrAction";

                this._IniFile.SetValue(section, key, (Int32)errAction);
                // Update ConnectErrAction
                ReadConnectErrAction();
                Trace.Assert(errAction.Equals(this._ConnectErrAction));
            }
            else
            {
                this._ConnectErrAction = errAction;
            }
        }

        private void ReadLineConfiguration()
        {
            this._LineConfigurations.Clear();
            if (!System.IO.File.Exists(this._LineInfoName))
            {
                throw new ArgumentException("LineInfoName is not exists");
            }

            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            using (System.IO.StreamReader sr = new System.IO.StreamReader(this._LineInfoName))
            {
                String line;
                LineConfiguration cfg = null;
                LineDefinition def = null;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    cfg = new LineConfiguration(line);
                    def = (LineDefinition)this._LineDefinitions[cfg.LineCode];

                    /*
                    if (def == null)
                    {
                        // throw new InvalidOperationException("Have no line definition");
                    }
                    else if (!def.Valid)
                    {
                        // throw new InvalidOperationException("Associated line definition is not valid");
                    }
                    else
                    {
                        // Get valid definition line only
                        this._LineConfigurations.Add(cfg.LineCode, cfg);
                    }
                    */
                    // Add all
                    this._LineConfigurations.Add(cfg.LineCode, cfg);
                }

                if (this._LineConfigurations.Count <= 0 || this._LineConfigurations.Count > this._LineNumMax)
                {
                    throw new ArgumentOutOfRangeException("LineCount can not greater than LineNumMax or less than or equal zero");
                }
            }
        }

        private void ReadLineDefinition(String section, String pattern)
        {
            System.Text.RegularExpressions.Match match = null;
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(pattern);
            LineDefinition def = null;
            String[] keys = this._IniFile.GetKeys(section);

            Int32 code;
            foreach (String key in keys)
            {
                try
                {
                    match = regex.Match(key.Trim());
                    if (match.Success)
                    {
                        code = Int32.Parse(match.Groups[1].Value);
                        if (this._LineDefinitions[code] == null)
                        {
                            try
                            {
                                def = new LineDefinition(code, this._IniFile.CloneReadOnly());
                            }
                            catch (Exception)
                            {

                            }

                            if (def != null)
                            {
                                this._LineDefinitions.Add(code, def);
                            }
                        }
                    }
                }
                catch (ArgumentException)
                {
                    // Syntax error in the regular expression
                }
            }
        }

        private void EnumerateLineDefinitions()
        {
            String section = String.Empty;
            String pattern = String.Empty;

            //////////////////////////////////////////////////////////////////////////            
            // Enumerate �V�X�e���ݒ���Z�N�V����
            //////////////////////////////////////////////////////////////////////////

            section = "PcifDriverSystemConstant";
            pattern = "^ConnectIpSetFile([1-9]\\d?)$";
            ReadLineDefinition(section, pattern);

            //////////////////////////////////////////////////////////////////////////            
            // Enumerate �o�b�t�@�ݒ���Z�N�V����
            //////////////////////////////////////////////////////////////////////////

            section = "PcifDriverBufferConstant";
            pattern = "^SndBufSize([1-9]\\d?)$";
            ReadLineDefinition(section, pattern);

            pattern = "^RcvBufSize([1-9]\\d?)$";
            ReadLineDefinition(section, pattern);

            //////////////////////////////////////////////////////////////////////////            
            // Enumerate �g���[�X�ݒ���Z�N�V����
            //////////////////////////////////////////////////////////////////////////

            section = "PcifDriverTraceConstant";
            pattern = "^LogFileName([1-9]\\d?)$";
            ReadLineDefinition(section, pattern);

            pattern = "^TrcNoFileName([1-9]\\d?)$";
            ReadLineDefinition(section, pattern);

            pattern = "^TrcFileMax([1-9]\\d?)$";
            ReadLineDefinition(section, pattern);

            pattern = "^TrcMemMax([1-9]\\d?)$";
            ReadLineDefinition(section, pattern);

            pattern = "^TrcDiskMax([1-9]\\d?)$";
            ReadLineDefinition(section, pattern);

            pattern = "^TrcWriteInt([1-9]\\d?)$";
            ReadLineDefinition(section, pattern);
        }
    }
}