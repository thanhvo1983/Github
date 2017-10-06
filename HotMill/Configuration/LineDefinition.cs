using System;
using System.Collections.Generic;
using System.Text;

namespace Kvics.Configuration
{
    /// <summary>
    /// �g���[�X���̎���@
    /// �O�F�ʐM�g���[�X�C�P�F�h���C�o�[�g���[�X
    /// </summary>
    public enum TraceEditMode
    {
        Unknown = -1,
        Communication = 0,
        Driver = 1
    }

    public interface IReadOnlyLineDefinition : ICloneable
    {
        Boolean Valid
        {
            get;
        }

        /// <summary>
        /// ����ԍ�
        /// </summary>
        Int32 LineCode
        {
            get;
        }

        /// <summary>
        /// �R�l�N�V�����m���h�o�A�h���X�i�[�t�@�C������
        /// </summary>
        String ConnectIpSetFile
        {
            get;
        }

        /// <summary>
        /// ���M�o�b�t�@�T�C�Y
        /// </summary>
        Int32 SndBufSize
        {
            get;
        }

        /// <summary>
        /// ��M�o�b�t�@�T�C�Y
        /// </summary>
        Int32 RcvBufSize
        {
            get;
        }

        /// <summary>
        /// ���O�̎�t�@�C������
        /// </summary>
        String LogFileName
        {
            get;
        }

        /// <summary>
        /// �g���[�X�t�@�C���ԍ��i�[�t�@�C����
        /// </summary>
        String TrcNoFileName
        {
            get;
        }

        /// <summary>
        /// �g���[�X�t�@�C���ő吔
        /// </summary>
        Int32 TrcFileMax
        {
            get;
        }

        /// <summary>
        /// �g���[�X�o�b�t�@�ő匏���i�������[�j
        /// </summary>
        Int32 TrcMemMax
        {
            get;
        }

        /// <summary>
        /// �g���[�X�o�b�t�@�ő匏���i�f�B�X�N�j
        /// </summary>
        Int32 TrcDiskMax
        {
            get;
        }

        /// <summary>
        /// �g���[�X�f�[�^�����݊Ԋu�i�b�j
        /// </summary>
        Int32 TrcWriteInt
        {
            get;
        }
        /// <summary>
        /// �g���[�X���̎���@
        /// </summary>
        TraceEditMode TrcEditMode
        {
            get;
        }
    }

    public sealed class LineDefinition : IReadOnlyLineDefinition
    {
        Boolean _Valid = true;
        public Boolean Valid
        {
            get
            {
                return this._Valid;
            }
            set
            {
                this._Valid = value;
            }
        }

        Boolean _IsReadOnly = false;

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
                throw new InvalidOperationException("Because ReadOnly. Operation not allowed.");
            }
        }

        //////////////////////////////////////////////////////////////////////////
        // �ݒ�t�@�C�� [PcifDriver.info]
        //////////////////////////////////////////////////////////////////////////        

        #region LineCode ����ԍ�
        /// <summary>
        /// ����ԍ�
        /// </summary>
        private Int32 _LineCode = 0;

        /// <summary>
        /// ����ԍ�
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

        //////////////////////////////////////////////////////////////////////////
        // �����`�t�@�C�� [Driver.ini]
        //////////////////////////////////////////////////////////////////////////        

        //////////////////////////////////////////////////////////////////////////
        // �V�X�e���ݒ���Z�N�V���� [PcifDriverSystemConstant]
        //////////////////////////////////////////////////////////////////////////

        #region ConnectIpSetFile �R�l�N�V�����m���h�o�A�h���X�i�[�t�@�C������
        /// <summary>
        /// �R�l�N�V�����m���h�o�A�h���X�i�[�t�@�C������
        /// </summary>
        private String _ConnectIpSetFile = null;

        /// <summary>
        /// �R�l�N�V�����m���h�o�A�h���X�i�[�t�@�C������
        /// </summary>
        public String ConnectIpSetFile
        {
            get
            {
                return this._ConnectIpSetFile;
            }
            set
            {
                VerifyNotReadOnly();
                if (CheckConnectIpSetFile(value))
                {
                    this._ConnectIpSetFile = value;
                }
            }
        }
        #endregion

        //////////////////////////////////////////////////////////////////////////        
        // �o�b�t�@�ݒ���Z�N�V���� [PcifDriverBufferConstant]
        //////////////////////////////////////////////////////////////////////////        

        #region SndBufSize ���M�o�b�t�@�T�C�Y
        /// <summary>
        /// ���M�o�b�t�@�T�C�Y
        /// </summary>
        private Int32 _SndBufSize = 0;

        /// <summary>
        /// ���M�o�b�t�@�T�C�Y
        /// </summary>
        public Int32 SndBufSize
        {
            get
            {
                return this._SndBufSize;
            }
            set
            {
                VerifyNotReadOnly();
                if (CheckSndBufSize(value))
                {
                    this._SndBufSize = value;
                }
            }
        }
        #endregion

        #region RcvBufSize ��M�o�b�t�@�T�C�Y
        /// <summary>
        /// ��M�o�b�t�@�T�C�Y
        /// </summary>
        private Int32 _RcvBufSize = 0;

        /// <summary>
        /// ��M�o�b�t�@�T�C�Y
        /// </summary>
        public Int32 RcvBufSize
        {
            get
            {
                return this._RcvBufSize;
            }
            set
            {
                VerifyNotReadOnly();
                if (CheckRcvBufSize(value))
                {
                    this._RcvBufSize = value;
                }
            }
        }
        #endregion

        //////////////////////////////////////////////////////////////////////////        
        // �g���[�X�ݒ���Z�N�V���� [PcifDriverTraceConstant]
        //////////////////////////////////////////////////////////////////////////        

        #region LogFileName ���O�̎�t�@�C������
        /// <summary>
        /// ���O�̎�t�@�C������
        /// </summary>
        private String _LogFileName = null;

        /// <summary>
        /// ���O�̎�t�@�C������
        /// </summary>
        public String LogFileName
        {
            get
            {
                return this._LogFileName;
            }
            set
            {
                VerifyNotReadOnly();
                if (CheckLogFileName(value))
                {
                    this._LogFileName = value;
                }
            }
        }
        #endregion

        #region TrcNoFileName �g���[�X�t�@�C���ԍ��i�[�t�@�C����
        /// <summary>
        /// �g���[�X�t�@�C���ԍ��i�[�t�@�C����
        /// </summary>
        private String _TrcNoFileName = null;

        /// <summary>
        /// �g���[�X�t�@�C���ԍ��i�[�t�@�C����
        /// </summary>
        public String TrcNoFileName
        {
            get
            {
                return this._TrcNoFileName;
            }
            set
            {
                VerifyNotReadOnly();
                if (CheckTrcNoFileName(value))
                {
                    this._TrcNoFileName = value;
                }
            }
        }
        #endregion

        #region TrcFileMax �g���[�X�t�@�C���ő吔
        /// <summary>
        /// �g���[�X�t�@�C���ő吔
        /// </summary>
        private Int32 _TrcFileMax = 0;

        public Int32 TrcFileMax
        {
            get
            {
                return this._TrcFileMax;
            }
            set
            {
                VerifyNotReadOnly();
                if (CheckTrcFileMax(value))
                {
                    this._TrcFileMax = value;
                }
            }
        }
        #endregion

        #region TrcMemMax �g���[�X�o�b�t�@�ő匏���i�������[�j
        /// <summary>
        /// �g���[�X�o�b�t�@�ő匏���i�������[�j
        /// </summary>
        private Int32 _TrcMemMax = 0;

        public Int32 TrcMemMax
        {
            get
            {
                return this._TrcMemMax;
            }
            set
            {
                VerifyNotReadOnly();
                if (CheckTrcMemMax(value))
                {
                    this._TrcMemMax = value;
                }
            }
        }
        #endregion

        #region TrcDiskMax �g���[�X�o�b�t�@�ő匏���i�f�B�X�N�j
        /// <summary>
        /// �g���[�X�o�b�t�@�ő匏���i�f�B�X�N�j
        /// </summary>
        private Int32 _TrcDiskMax = 0;

        public Int32 TrcDiskMax
        {
            get
            {
                return this._TrcDiskMax;
            }
            set
            {
                VerifyNotReadOnly();
                if (CheckTrcDiskMax(value))
                {
                    this._TrcDiskMax = value;
                }
            }
        }
        #endregion

        #region TrcWriteInt �g���[�X�f�[�^�����݊Ԋu�i�b�j
        /// <summary>
        /// �g���[�X�f�[�^�����݊Ԋu�i�b�j
        /// </summary>
        private Int32 _TrcWriteInt = 0;

        public Int32 TrcWriteInt
        {
            get
            {
                return this._TrcWriteInt;
            }
            set
            {
                VerifyNotReadOnly();
                if (CheckTrcWriteInt(value))
                {
                    this._TrcWriteInt = value;
                }
            }
        }
        #endregion

        #region TrcEditMode �g���[�X���̎���@
        /// <summary>
        /// �g���[�X���̎���@
        /// </summary>
        private TraceEditMode _TrcEditMode = TraceEditMode.Unknown;

        public TraceEditMode TrcEditMode
        {
            get
            {
                return this._TrcEditMode;
            }
            set
            {
                VerifyNotReadOnly();
                if (CheckTrcEditMode((Int32)value))
                {
                    this._TrcEditMode = value;
                }
            }
        }
        #endregion

        public LineDefinition(Int32 lineCode, IReadOnlyProfile ini)
        {
            this._LineCode = ParseLineCode(lineCode.ToString());
            if (ini == null)
            {
                throw new ArgumentNullException("Ini file can not be null");
            }
            ReadLineDefine(ini);
        }

        private LineDefinition(LineDefinition def)
        {
            this._LineCode = def.LineCode;
            this._ConnectIpSetFile = def.ConnectIpSetFile;
            this._LogFileName = def.LogFileName;
            this._RcvBufSize = def.RcvBufSize;
            this._SndBufSize = def.SndBufSize;
            this._TrcDiskMax = def.TrcDiskMax;
            this._TrcEditMode = def.TrcEditMode;
            this._TrcFileMax = def.TrcFileMax;
            this._TrcMemMax = def.TrcMemMax;
            this._TrcNoFileName = def.TrcNoFileName;
            this._TrcWriteInt = def.TrcWriteInt;
            this._Valid = def.Valid;
            this._IsReadOnly = def.IsReadOnly;
        }

        public LineDefinition(IReadOnlyLineDefinition def)
        {
            this._LineCode = def.LineCode;
            this._ConnectIpSetFile = def.ConnectIpSetFile;
            this._LogFileName = def.LogFileName;
            this._RcvBufSize = def.RcvBufSize;
            this._SndBufSize = def.SndBufSize;
            this._TrcDiskMax = def.TrcDiskMax;
            this._TrcEditMode = def.TrcEditMode;
            this._TrcFileMax = def.TrcFileMax;
            this._TrcMemMax = def.TrcMemMax;
            this._TrcNoFileName = def.TrcNoFileName;
            this._TrcWriteInt = def.TrcWriteInt;
            this._Valid = def.Valid;
        }

        public Object Clone()
        {
            return new LineDefinition(this);
        }

        public IReadOnlyLineDefinition CloneReadOnly()
        {
            LineDefinition cfg = (LineDefinition)Clone();
            cfg.IsReadOnly = true;
            return cfg;
        }

        private void ReadLineDefine(IReadOnlyProfile ini)
        {
            try
            {
                ReadConnectIpSetFile(ini);
            }
            catch
            {
                this._Valid &= false;
            }

            try
            {
                ReadSndBufSize(ini);
            }
            catch
            {
                this._Valid &= false;
            }

            try
            {
                ReadRcvBufSize(ini);
            }
            catch
            {
                this._Valid &= false;
            }

            try
            {
                ReadLogFileName(ini);
            }
            catch
            {
                this._Valid &= false;
            }

            try
            {
                ReadTrcNoFileName(ini);
            }
            catch
            {
                this._Valid &= false;
            }

            try
            {
                ReadTrcFileMax(ini);
            }
            catch
            {
                this._Valid &= false;
            }

            try
            {
                ReadTrcMemMax(ini);
            }
            catch
            {
                this._Valid &= false;
            }

            try
            {
                ReadTrcDiskMax(ini);
            }
            catch
            {
                this._Valid &= false;
            }

            try
            {
                ReadTrcWriteInt(ini);
            }
            catch
            {
                this._Valid &= false;
            }

            try
            {
                ReadTrcEditMode(ini);
            }
            catch
            {
                this._Valid &= false;
                this._TrcEditMode = TraceEditMode.Unknown;
            }
        }

        public static Boolean CheckConnectIpSetFile(String fn)
        {
            return CheckFileName(fn);
        }

        public static Int32 ParseSndBufSize(Int32 bufSize)
        {
            if (bufSize <= 0)
            {
                throw new ArgumentOutOfRangeException("SndBufSize can not less than or equal zero");
            }
            return bufSize;
        }

        public static Int32 ParseSndBufSize(String bufSize)
        {
            try
            {
                return ParseSndBufSize(Int32.Parse(bufSize));
            }
            catch (Exception)
            {
                throw new ArgumentException("SndBufSize is not valid");
            }
        }

        public static Boolean TryParseSndBufSize(Int32 bufSize, out Int32 ret)
        {
            ret = 0;
            Boolean bRet = true;
            try
            {
                ret = ParseSndBufSize(bufSize);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean TryParseSndBufSize(String bufSize, out Int32 ret)
        {
            ret = 0;
            Boolean bRet = true;
            try
            {
                ret = ParseSndBufSize(bufSize);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckSndBufSize(Int32 bufSize)
        {
            Boolean bRet = true;
            try
            {
                ParseSndBufSize(bufSize);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckSndBufSize(String bufSize)
        {
            Boolean bRet = true;
            try
            {
                ParseSndBufSize(bufSize);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Int32 ParseRcvBufSize(Int32 bufSize)
        {
            if (bufSize <= 0)
            {
                throw new ArgumentOutOfRangeException("RcvBufSize can not less than or equal zero");
            }
            return bufSize;
        }

        public static Int32 ParseRcvBufSize(String bufSize)
        {
            try
            {
                return ParseRcvBufSize(Int32.Parse(bufSize));
            }
            catch (Exception)
            {
                throw new ArgumentException("RcvBufSize is not valid");
            }
        }

        public static Boolean TryParseRcvBufSize(Int32 bufSize, out Int32 ret)
        {
            ret = 0;
            Boolean bRet = true;
            try
            {
                ret = ParseRcvBufSize(bufSize);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean TryParseRcvBufSize(String bufSize, out Int32 ret)
        {
            ret = 0;
            Boolean bRet = true;
            try
            {
                ret = ParseRcvBufSize(bufSize);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckRcvBufSize(Int32 bufSize)
        {
            Boolean bRet = true;
            try
            {
                ParseRcvBufSize(bufSize);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckRcvBufSize(String bufSize)
        {
            Boolean bRet = true;
            try
            {
                ParseRcvBufSize(bufSize);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckLogFileName(String fn)
        {
            return true;
        }

        public static Boolean CheckTrcNoFileName(String fn)
        {
            return true;
        }

        public static Int32 ParseTrcFileMax(Int32 fileMax)
        {
            if (fileMax <= 0)
            {
                throw new ArgumentOutOfRangeException("TrcFileMax can not less than or equal zero");
            }
            return fileMax;
        }

        public static Int32 ParseTrcFileMax(String fileMax)
        {
            try
            {
                return ParseTrcFileMax(Int32.Parse(fileMax));
            }
            catch (Exception)
            {
                throw new ArgumentException("TrcFileMax is not valid");
            }
        }

        public static Boolean TryParseTrcFileMax(Int32 fileMax, out Int32 ret)
        {
            ret = 0;
            Boolean bRet = true;
            try
            {
                ret = ParseTrcFileMax(fileMax);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean TryParseTrcFileMax(String fileMax, out Int32 ret)
        {
            ret = 0;
            Boolean bRet = true;
            try
            {
                ret = ParseTrcFileMax(fileMax);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckTrcFileMax(Int32 fileMax)
        {
            Boolean bRet = true;
            try
            {
                ParseTrcFileMax(fileMax);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckTrcFileMax(String fileMax)
        {
            Boolean bRet = true;
            try
            {
                ParseTrcFileMax(fileMax);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Int32 ParseTrcMemMax(Int32 memMax)
        {
            if (memMax <= 0)
            {
                throw new ArgumentOutOfRangeException("TrcMemMax can not less than or equal zero");
            }
            return memMax;
        }

        public static Int32 ParseTrcMemMax(String memMax)
        {
            try
            {
                return ParseTrcMemMax(Int32.Parse(memMax));
            }
            catch (Exception)
            {
                throw new ArgumentException("TrcMemMax is not valid");
            }
        }

        public static Boolean TryParseTrcMemMax(Int32 memMax, out Int32 ret)
        {
            ret = 0;
            Boolean bRet = true;
            try
            {
                ret = ParseTrcMemMax(memMax);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean TryParseTrcMemMax(String memMax, out Int32 ret)
        {
            ret = 0;
            Boolean bRet = true;
            try
            {
                ret = ParseTrcMemMax(memMax);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckTrcMemMax(Int32 memMax)
        {
            Boolean bRet = true;
            try
            {
                ParseTrcMemMax(memMax);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckTrcMemMax(String memMax)
        {
            Boolean bRet = true;
            try
            {
                ParseTrcMemMax(memMax);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Int32 ParseTrcDiskMax(Int32 diskMax)
        {
            if (diskMax <= 0)
            {
                throw new ArgumentOutOfRangeException("TrcDiskMax can not less than or equal zero");
            }
            return diskMax;
        }

        public static Int32 ParseTrcDiskMax(String diskMax)
        {
            try
            {
                return ParseTrcDiskMax(Int32.Parse(diskMax));
            }
            catch (Exception)
            {
                throw new ArgumentException("TrcDiskMax is not valid");
            }
        }

        public static Boolean TryParseTrcDiskMax(Int32 diskMax, out Int32 ret)
        {
            ret = 0;
            Boolean bRet = true;
            try
            {
                ret = ParseTrcDiskMax(diskMax);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean TryParseTrcDiskMax(String diskMax, out Int32 ret)
        {
            ret = 0;
            Boolean bRet = true;
            try
            {
                ret = ParseTrcDiskMax(diskMax);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckTrcDiskMax(Int32 diskMax)
        {
            Boolean bRet = true;
            try
            {
                ParseTrcDiskMax(diskMax);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckTrcDiskMax(String diskMax)
        {
            Boolean bRet = true;
            try
            {
                ParseTrcDiskMax(diskMax);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Int32 ParseTrcWriteInt(Int32 writeInt)
        {
            if (writeInt <= 0)
            {
                throw new ArgumentOutOfRangeException("TrcWriteInt can not less than or equal zero");
            }
            return writeInt;
        }

        public static Int32 ParseTrcWriteInt(String writeInt)
        {
            try
            {
                return ParseTrcWriteInt(Int32.Parse(writeInt));
            }
            catch (Exception)
            {
                throw new ArgumentException("TrcWriteInt is not valid");
            }
        }

        public static Boolean TryParseTrcWriteInt(Int32 writeInt, out Int32 ret)
        {
            ret = 0;
            Boolean bRet = true;
            try
            {
                ret = ParseTrcWriteInt(writeInt);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean TryParseTrcWriteInt(String writeInt, out Int32 ret)
        {
            ret = 0;
            Boolean bRet = true;
            try
            {
                ret = ParseTrcWriteInt(writeInt);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckTrcWriteInt(Int32 writeInt)
        {
            Boolean bRet = true;
            try
            {
                ParseTrcWriteInt(writeInt);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckTrcWriteInt(String writeInt)
        {
            Boolean bRet = true;
            try
            {
                ParseTrcWriteInt(writeInt);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static TraceEditMode ParseTrcEditMode(Int32 editMode)
        {
            if (!(editMode == (Int32)TraceEditMode.Communication || editMode == (Int32)TraceEditMode.Driver))
            {
                throw new NotSupportedException("TrcEditMode value is invalid");
            }
            return (TraceEditMode)editMode;
        }

        public static TraceEditMode ParseTrcEditMode(String editMode)
        {
            try
            {
                return ParseTrcEditMode(Int32.Parse(editMode));
            }
            catch (Exception)
            {
                throw new ArgumentException("TrcEditMode is not valid");
            }
        }

        public static Boolean TryParseTrcEditMode(Int32 editMode, out TraceEditMode ret)
        {
            ret = TraceEditMode.Unknown;
            Boolean bRet = true;
            try
            {
                ret = ParseTrcEditMode(editMode);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean TryParseTrcEditMode(String editMode, out TraceEditMode ret)
        {
            ret = TraceEditMode.Unknown;
            Boolean bRet = true;
            try
            {
                ret = ParseTrcEditMode(editMode);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckTrcEditMode(Int32 editMode)
        {
            Boolean bRet = true;
            try
            {
                ParseTrcEditMode(editMode);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckTrcEditMode(String editMode)
        {
            Boolean bRet = true;
            try
            {
                ParseTrcEditMode(editMode);
            }
            catch (Exception)
            {
                bRet = false;
            }

            return bRet;
        }

        public static Boolean CheckFileName(String fn)
        {
            return System.IO.File.Exists(fn);
        }

        public static Int32 ParseLineCode(Int32 lineCode)
        {

            if (lineCode <= 0)
            {
                throw new ArgumentOutOfRangeException("LineCode can not less than or equal zero");
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
                throw new ArgumentException("LineCode is not valid");
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

        private void ReadConnectIpSetFile(IReadOnlyProfile ini)
        {
            // �V�X�e���ݒ���Z�N�V����
            String section = "PcifDriverSystemConstant";
            // �R�l�N�V�����m��
            String key = "ConnectIpSetFile";

            String value = ini.GetValue(section, key + this._LineCode.ToString(), String.Empty);
            if (!CheckConnectIpSetFile(value))
            {
                throw new System.IO.FileNotFoundException("ConnectIpSetFile not found");
            }

            this._ConnectIpSetFile = value;
        }

        private void ReadSndBufSize(IReadOnlyProfile ini)
        {
            // �o�b�t�@�ݒ���Z�N�V����
            String section = "PcifDriverBufferConstant";
            // ���M�o�b�t�@�T�C�Y
            String key = "SndBufSize";

            this._SndBufSize = ParseSndBufSize(ini.GetValue(section, key +
                this._LineCode.ToString()).ToString());
        }

        private void ReadRcvBufSize(IReadOnlyProfile ini)
        {
            // �o�b�t�@�ݒ���Z�N�V����
            String section = "PcifDriverBufferConstant";
            // ��M�o�b�t�@�T�C�Y
            String key = "RcvBufSize";

            this._RcvBufSize = ParseRcvBufSize(ini.GetValue(section, key +
                this._LineCode.ToString()).ToString());
        }

        private void ReadLogFileName(IReadOnlyProfile ini)
        {
            // �g���[�X�ݒ���Z�N�V����
            String section = "PcifDriverTraceConstant";
            // ���O�t�@�C����
            String key = "LogFileName";

            String value = ini.GetValue(section, key +
                this._LineCode.ToString(), String.Empty);

            if (!CheckLogFileName(value))
            {
                throw new InvalidOperationException();
            }

            this._LogFileName = value;
        }

        private void ReadTrcFileMax(IReadOnlyProfile ini)
        {
            // �g���[�X�ݒ���Z�N�V����
            String section = "PcifDriverTraceConstant";
            // �g���[�X�t�@�C���ő吔
            String key = "TrcFileMax";

            this._TrcFileMax = ParseTrcFileMax(ini.GetValue(section, key +
                this._LineCode.ToString()).ToString());
        }

        private void ReadTrcNoFileName(IReadOnlyProfile ini)
        {
            // �g���[�X�ݒ���Z�N�V����
            String section = "PcifDriverTraceConstant";
            // �g���[�X�t�@�C���ԍ��i�[�t�@�C����
            String key = "TrcNoFileName";

            String value = ini.GetValue(section, key +
                this._LineCode.ToString(), String.Empty);

            if (!CheckTrcNoFileName(value))
            {
                throw new InvalidOperationException();
            }

            this._TrcNoFileName = value;
        }

        private void ReadTrcMemMax(IReadOnlyProfile ini)
        {
            // �g���[�X�ݒ���Z�N�V����
            String section = "PcifDriverTraceConstant";
            // �g���[�X�o�b�t�@�ő匏���i�������[�j
            String key = "TrcMemMax";

            this._TrcMemMax = ParseTrcMemMax(ini.GetValue(section, key +
                this._LineCode.ToString()).ToString());
        }

        private void ReadTrcDiskMax(IReadOnlyProfile ini)
        {
            // �g���[�X�ݒ���Z�N�V����
            String section = "PcifDriverTraceConstant";
            // �g���[�X�o�b�t�@�ő匏���i�f�B�X�N�j
            String key = "TrcDiskMax";

            this._TrcDiskMax = ParseTrcDiskMax(ini.GetValue(section, key +
                this._LineCode.ToString()).ToString());
        }

        private void ReadTrcWriteInt(IReadOnlyProfile ini)
        {
            // �g���[�X�ݒ���Z�N�V����
            String section = "PcifDriverTraceConstant";
            // �g���[�X�f�[�^�����݊Ԋu�i�b�j
            String key = "TrcWriteInt";

            this._TrcWriteInt = ParseTrcWriteInt(ini.GetValue(section, key +
                this._LineCode.ToString()).ToString());
        }

        private void ReadTrcEditMode(IReadOnlyProfile ini)
        {
            // �g���[�X�ݒ���Z�N�V����
            String section = "PcifDriverTraceConstant";
            // �g���[�X���̎���@
            String key = "TrcEditMode";

            this._TrcEditMode = ParseTrcEditMode(ini.GetValue(section, key +
                this._LineCode.ToString()).ToString());
        }
    }
}
