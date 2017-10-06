using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Kvics.PInvoke;
using System.ComponentModel;
using System.Diagnostics;

namespace Kvics.Communication
{
    /// <summary>
    /// ������
    /// </summary>
    public enum LineStatusType
    {
        StatusFailed,
        Disconnected,           // �R�l�N�V���������
        ConnectingRequest,      // �ڑ��v����
        EstablishingRequest,    // �R�l�N�V�����m����
        ModeConfirming,         // ���[�h�m�F��
        Connected,              // �ʐM�\���
        Unknown
    }

    #region DriverAdapter (Platform Invoke) for using EN&M Communication Driver
    /// <summary>
    /// 
    /// </summary>
    public sealed class DriverAdapter
    {
        /// <summary>
        /// Logger
        /// </summary>
        private static log4net.ILog LOGGER =
            Log.Instance.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 
        /// </summary>
        public const Int32 MAX_BUFF = 2048;

        /// <summary>
        /// 
        /// </summary>
        public const String DriverProcessName = "PcifDriver";

        /// <summary>
        /// ���M�v���֐�            pcifsend()
        /// �G�N�X�|�[�g�֐���      ?pcifsend@@YAHHPADH@Z
        /// 
        /// �w�肳�ꂽ����Ƀf�[�^�𑗐M�v���𔭍s����     
        /// 
        /// �R�[�����O�V�[�P���X
        ///     int pcifsend(
        ///        int line_no,
        ///        char *msg,
        ///        int leng,
        ///     );
        /// </summary>
        /// <param name="line_no">
        /// �y���z�f�[�^�𑗐M�������ԍ�
        /// </param>
        /// <param name="msg">
        /// �y���z���M�f�[�^�̐擪�A�h���X
        /// </param>
        /// <param name="leng">
        /// �y���z���M�f�[�^�̒����ybyte�z
        /// </param>
        /// <returns>
        /// ���M�v���������F�P
        /// ���M�v�����s���F�|�P
        /// </returns>
        /// <remarks>
        /// �w�肳�ꂽ����Ɏw�肳�ꂽ�f�[�^�𑗐M����B���̂Ƃ�������ڑ�����
        /// �Ă��Ȃ���Ή���ڑ����s���B
        /// �֐��̓f�[�^�̑��M�����A�������Ɋւ�炸�����ɏ������I������B
        /// �֐��̖߂�l�͑��M�o�b�t�@�ւ̏����݌��ʂ�Ԃ����̂ŁA�f�[�^�̑��M
        /// ���ʂ�\�����̂ł͂Ȃ��B
        /// </remarks>
        [DllImport("DriverDLL.dll", EntryPoint = "?pcifsend@@YAHHPADH@Z")]
        static extern Int32 pcifsend(Int32 line_no, String msg, Int32 leng);

        /// <summary>
        /// ���M�v���֐�            pcifsend()
        /// �G�N�X�|�[�g�֐���      ?pcifsend@@YAHHPADH@Z
        /// 
        /// �w�肳�ꂽ����Ƀf�[�^�𑗐M�v���𔭍s����     
        /// 
        /// �R�[�����O�V�[�P���X
        ///     int pcifsend(
        ///        int line_no,
        ///        char *msg,
        ///        int leng,
        ///     );
        /// </summary>
        /// <param name="line_no">
        /// �y���z�f�[�^�𑗐M�������ԍ�
        /// </param>
        /// <param name="msg">
        /// �y���z���M�f�[�^�̐擪�A�h���X
        /// </param>
        /// <param name="leng">
        /// �y���z���M�f�[�^�̒����ybyte�z
        /// </param>
        /// <returns>
        /// ���M�v���������F�P
        /// ���M�v�����s���F�|�P
        /// </returns>
        /// <remarks>
        /// �w�肳�ꂽ����Ɏw�肳�ꂽ�f�[�^�𑗐M����B���̂Ƃ�������ڑ�����
        /// �Ă��Ȃ���Ή���ڑ����s���B
        /// �֐��̓f�[�^�̑��M�����A�������Ɋւ�炸�����ɏ������I������B
        /// �֐��̖߂�l�͑��M�o�b�t�@�ւ̏����݌��ʂ�Ԃ����̂ŁA�f�[�^�̑��M
        /// ���ʂ�\�����̂ł͂Ȃ��B
        /// </remarks>
        [DllImport("DriverDLL.dll", EntryPoint = "?pcifsend@@YAHHPADH@Z")]
        static extern Int32 pcifsend(Int32 line_no, [In] Byte[] msg, Int32 leng);

        /// <summary>
        /// ��M�v���֐�        pcifrecv()
        /// �G�N�X�|�[�g�֐���  ?pcifrecv@@YAHHPADHPAHH@Z
        /// 
        /// �w�肳�ꂽ�������f�[�^����M����
        /// 
        /// �R�[�����O�V�P���X
        ///     int pcifrecv(
        ///         int line_no,
        ///         char *msg,
        ///         int max_leng,
        ///         int *leng,
        ///         int timeout,
        ///     );        
        /// </summary>
        /// <param name="line_no">
        /// �y���z�f�[�^����M�������ԍ�
        /// </param>
        /// <param name="msg">
        /// �y�o�z�f�[�^��M�̈�̐擪�A�h���X
        /// </param>
        /// <param name="max_leng">
        /// �y���z�ő��M��
        /// </param>
        /// <param name="leng">
        /// �y�o�z��M�f�[�^��
        /// </param>
        /// <param name="timeout">
        /// �y���z��M�҂��^�C���A�E�g���Ԃ��w�肷��ysec�z
        /// </param>
        /// <returns>
        /// ��M�������F�P
        /// ��M���s���F�|�P
        /// </returns>
        /// <remarks>
        /// �w�肳�ꂽ����ɂ���f�[�^����M����B���̂Ƃ���M�f�[�^�����݂���
        /// ���ꍇ�ɂ͊֐��͎w�肳�ꂽ�^�C���A�E�g���Ԃ܂Ŏ�M�҂��ƂȂ�B�^�C��
        /// �A�E�g���Ԃ̎w�肪�A�O�̏ꍇ�́A�i�v�ɑ҂B�������^�C���A�E�g������
        /// ���ɂ͊֐��́|�P��Ԃ��B
        /// </remarks>
        [DllImport("DriverDLL.dll", EntryPoint = "?pcifrecv@@YAHHPADHPAHH@Z")]
        static extern Int32 pcifrecv(Int32 line_no, StringBuilder msg, Int32 max_leng, ref IntPtr leng, Int32 timeout);

        /// <summary>
        /// ��M�v���֐�        pcifrecv()
        /// �G�N�X�|�[�g�֐���  ?pcifrecv@@YAHHPADHPAHH@Z
        /// 
        /// �w�肳�ꂽ�������f�[�^����M����
        /// 
        /// �R�[�����O�V�P���X
        ///     int pcifrecv(
        ///         int line_no,
        ///         char *msg,
        ///         int max_leng,
        ///         int *leng,
        ///         int timeout,
        ///     );        
        /// </summary>
        /// <param name="line_no">
        /// �y���z�f�[�^����M�������ԍ�
        /// </param>
        /// <param name="msg">
        /// �y�o�z�f�[�^��M�̈�̐擪�A�h���X
        /// </param>
        /// <param name="max_leng">
        /// �y���z�ő��M��
        /// </param>
        /// <param name="leng">
        /// �y�o�z��M�f�[�^��
        /// </param>
        /// <param name="timeout">
        /// �y���z��M�҂��^�C���A�E�g���Ԃ��w�肷��ysec�z
        /// </param>
        /// <returns>
        /// ��M�������F�P
        /// ��M���s���F�|�P
        /// </returns>
        /// <remarks>
        /// �w�肳�ꂽ����ɂ���f�[�^����M����B���̂Ƃ���M�f�[�^�����݂���
        /// ���ꍇ�ɂ͊֐��͎w�肳�ꂽ�^�C���A�E�g���Ԃ܂Ŏ�M�҂��ƂȂ�B�^�C��
        /// �A�E�g���Ԃ̎w�肪�A�O�̏ꍇ�́A�i�v�ɑ҂B�������^�C���A�E�g������
        /// ���ɂ͊֐��́|�P��Ԃ��B
        /// </remarks>
        [DllImport("DriverDLL.dll", EntryPoint = "?pcifrecv@@YAHHPADHPAHH@Z")]
        static extern Int32 pcifrecv(Int32 line_no, [In, Out] Byte[] msg, Int32 max_leng, ref IntPtr leng, Int32 timeout);

        /// <summary>
        /// ��M�f�[�^��o���֐�        pcifget()
        /// �G�N�X�|�[�g�֐���          ?pcifget@@YAHHPADHPAH@Z
        /// 
        /// �w�肳�ꂽ��������M�f�[�^�����o��        
        /// 
        /// �R�[�����O�V�P���X
        ///     int pcifget(
        ///         int line_no,
        ///         char *msg,
        ///         int max_leng,
        ///         int *leng,
        ///     );
        /// </summary>
        /// <param name="line_no">
        /// �y���z�f�[�^����M�������ԍ�
        /// </param>
        /// <param name="msg">
        /// �y�o�z�f�[�^��M�̈�̐擪�A�h���X
        /// </param>
        /// <param name="max_leng">
        /// �y���z�ő��M��
        /// </param>
        /// <param name="leng">
        /// �y�o�z��M�f�[�^��
        /// </param>
        /// <returns>
        /// �������F�P
        /// ���s���F�|�P
        /// </returns>
        /// <remarks>
        /// �w�肳�ꂽ����̎�M�o�b�t�@���A��M�f�[�^�����o���B���̂Ƃ���
        /// �M�f�[�^�����݂��Ȃ��ꍇ�ɂ͊֐��́|�P��Ԃ��B
        /// </remarks>
        [DllImport("DriverDLL.dll", EntryPoint = "?pcifget@@YAHHPADHPAH@Z")]
        static extern Int32 pcifget(Int32 line_no, StringBuilder msg, Int32 max_leng, ref IntPtr leng);

        /// <summary>
        /// ��M�f�[�^��o���֐�        pcifget()
        /// �G�N�X�|�[�g�֐���          ?pcifget@@YAHHPADHPAH@Z
        /// 
        /// �w�肳�ꂽ��������M�f�[�^�����o��        
        /// 
        /// �R�[�����O�V�P���X
        ///     int pcifget(
        ///         int line_no,
        ///         char *msg,
        ///         int max_leng,
        ///         int *leng,
        ///     );
        /// </summary>
        /// <param name="line_no">
        /// �y���z�f�[�^����M�������ԍ�
        /// </param>
        /// <param name="msg">
        /// �y�o�z�f�[�^��M�̈�̐擪�A�h���X
        /// </param>
        /// <param name="max_leng">
        /// �y���z�ő��M��
        /// </param>
        /// <param name="leng">
        /// �y�o�z��M�f�[�^��
        /// </param>
        /// <returns>
        /// �������F�P
        /// ���s���F�|�P
        /// </returns>
        /// <remarks>
        /// �w�肳�ꂽ����̎�M�o�b�t�@���A��M�f�[�^�����o���B���̂Ƃ���
        /// �M�f�[�^�����݂��Ȃ��ꍇ�ɂ͊֐��́|�P��Ԃ��B
        /// </remarks>
        [DllImport("DriverDLL.dll", EntryPoint = "?pcifget@@YAHHPADHPAH@Z")]
        static extern Int32 pcifget(Int32 line_no, [In, Out] Byte[] msg, Int32 max_leng, ref IntPtr leng);

        /// <summary>
        /// �h���C�o�[�����N���֐�  pcifstart()
        /// �G�N�X�|�[�g�֐���      ?pcifstart@@YAHXZ
        /// 
        /// �ʐM�h���C�o�[���N������
        /// 
        /// �R�[�����O�V�P���X
        ///     int pcifstart();
        /// </summary>
        /// <returns>
        /// �������F�P
        /// ���s���F�|�P
        /// </returns>
        /// <caution>
        /// ���֐����ʐM�h���C�o���N������ꍇ�́A�֐����Ăяo�������̃J����
        /// �g�f�B���N�g�����ɒʐM�h���C�o�[�����݂���K�v������B
        /// ���݂��Ȃ��ꍇ�ɂ́A���֐����Ăяo���O�ɁA�ʐM�h���C�o�[�����݂���
        /// �f�B���N�g���ɃJ�����g�f�B���N�g����ύX���Ă������ƁB
        /// </caution>
        [DllImport("DriverDLL.dll", EntryPoint = "?pcifstart@@YAHXZ")]
        static extern Int32 pcifstart();

        /// <summary>
        /// �h���C�o�[������~�֐�  pcifstop()
        /// �G�N�X�|�[�g�֐���      ?pcifstop@@YAHXZ
        /// 
        /// �ʐM�h���C�o�[���~����
        /// 
        /// �R�[�����O�V�P���X
        ///     int pcifstop();
        /// </summary>
        /// <returns>
        /// �������F�P
        /// ���s���F�|�P
        /// </returns>
        [DllImport("DriverDLL.dll", EntryPoint = "?pcifstop@@YAHXZ")]
        static extern Int32 pcifstop();
        
        /// <summary>
        /// ����������֐�          pcifinit()
        /// �G�N�X�|�[�g�֐���      ?pcifinit@@YAHH@Z
        /// 
        /// �w�肳�ꂽ����ԍ��̉��������������
        /// 
        /// �R�[�����O�V�[�P���X
        ///     int pcifinit(
        ///         int line_no,
        ///     );
        /// </summary>
        /// <param name="line_no">
        /// �y���z�������������ԍ�
        /// </param>
        /// <returns>
        /// �������������F�P
        /// ���������s���F�|�P
        /// </returns>
        /// <remarks>
        /// �������̏������i�ؒf���s���j�A����̐ڑ��̓f�[�^���M���ɍs����
        /// </remarks>
        [DllImport("DriverDLL.dll", EntryPoint = "?pcifinit@@YAHH@Z")]
        static extern Int32 pcifinit(Int32 line_no);

        /// <summary>
        /// �R�l�N�V�����m���v���֐�        pcifconc()
        /// �G�N�X�|�[�g�֐���              ?pcifconc@@YAHH@Z
        /// 
        /// �w�肳�ꂽ����ԍ��̃R�l�N�V�������m������
        /// 
        /// �R�[�����O�V�[�P���X
        ///     int pcifconc(
        ///         int line_no,
        ///     );
        /// </summary>
        /// <param name="line_no">
        /// �y���z�R�l�N�V�������m���������ԍ�
        /// </param>
        /// <returns>
        /// �������������F�P
        /// ���������s���F�|�P
        /// </returns>
        [DllImport("DriverDLL.dll", EntryPoint = "?pcifconc@@YAHH@Z")]
        static extern Int32 pcifconc(Int32 line_no);

        /// <summary>
        /// �����Ԏ�o���֐�          pcifstget()
        /// �G�N�X�|�[�g�֐���          ?pcifstget@@YAHHPAH@Z
        /// 
        /// �w�肳�ꂽ����̉����Ԃ����o��
        /// 
        /// �R�[�����O�V�P���X
        ///     int pcifstget(
        ///         int line_no,
        ///         int *st,
        ///     );
        /// </summary>
        /// <param name="line_no">
        /// �y���z�f�[�^����M�������ԍ�
        /// </param>
        /// <param name="st">
        /// �y�o�z������
        ///     �O�F�R�l�N�V���������
        ///     �P�F�ڑ��v����
        ///     �Q�F�R�l�N�V�����m����
        ///     �R�F���[�h�m�F��
        ///     �S�F�ʐM�\���
        /// </param>
        /// <returns>
        /// �������F�P
        /// ���s���F�|�P
        /// </returns>
        [DllImport("DriverDLL.dll", EntryPoint = "?pcifstget@@YAHHPAH@Z")]
        static extern Int32 pcifstget(Int32 line_no, ref IntPtr st);

        /// <summary>
        /// Check driver is running by process name
        /// </summary>
        /// <returns></returns>
        public static Boolean IsDriverProcessRunning()
        {
            try
            {
                Process[] processes = Process.GetProcessesByName(DriverProcessName);
                return (processes.Length > 0);
            }
            catch (ArgumentNullException ean)
            {
                LOGGER.Error(ean.Message);
            }
            catch (InvalidOperationException eio)
            {
                LOGGER.Error(eio.Message);
            }
            catch (Win32Exception ew32)
            {
                LOGGER.Error(ew32.Message);
            }
            catch (Exception e)
            {
                LOGGER.Error(e.Message);
            }
            return false;
        }

        /// <summary>
        /// �����Ԏ�o���֐�
        /// 
        /// �w�肳�ꂽ����̉����Ԃ����o��
        /// </summary>
        /// <param name="line">
        /// �y���z�f�[�^����M�������ԍ�
        /// </param>
        /// <returns>
        /// ������ enum
        /// </returns>
        /// <exception cref="DllNotFoundException"></exception>
        /// <exception cref="EntryPointNotFoundException"></exception>
        /// <exception cref="AccessViolationException"></exception>
        /// <exception cref="Win32Exception"></exception>
        /// <exception cref="Exception"></exception>
        public static LineStatusType GetStatus(Int32 line)
        {
            try
            {
                LineStatusType status = LineStatusType.StatusFailed;
                IntPtr nStatus = new IntPtr(-1);
                Int32 nRet = pcifstget(line, ref nStatus);
                if (nRet == -1)
                {
                    status = LineStatusType.StatusFailed;                    
                }
                else
                {
                    switch (nStatus.ToInt32())
                    {
                        case 0:
                            status = LineStatusType.Disconnected;
                            break;
                        case 1:
                            status = LineStatusType.ConnectingRequest;
                            break;
                        case 2:
                            status = LineStatusType.EstablishingRequest;
                            break;
                        case 3:
                            status = LineStatusType.ModeConfirming;
                            break;
                        case 4:
                            status = LineStatusType.Connected;
                            break;
                        default:
                            status = LineStatusType.Unknown;
                            break;
                    }
                }
                return status;
            }
            catch (DllNotFoundException ednf)
            {
                LOGGER.Error(ednf.Message);
            }
            catch (EntryPointNotFoundException eepnf)
            {
                LOGGER.Error(eepnf.Message);
            }
            catch (AccessViolationException eav)
            {
                LOGGER.Error(eav.Message);
            }
            catch (Win32Exception ew32)
            {
                LOGGER.Error(ew32.Message);
            }
            catch (Exception e)
            {
                LOGGER.Error(e.Message);
            }

            return LineStatusType.StatusFailed;
        }

        /// <summary>
        /// �����Ԏ�o���֐�
        /// </summary>
        /// <param name="line">
        /// �y���z�f�[�^����M�������ԍ�
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        public static String GetStatusDesc(Int32 line)
        {
            return GetStatus(line).ToString();
        }

        /// <summary>
        /// ���M�v���֐�
        /// 
        /// �w�肳�ꂽ����Ƀf�[�^�𑗐M�v���𔭍s����
        /// </summary>
        /// <param name="line">
        /// �y���z�f�[�^����M�������ԍ�
        /// </param>
        /// <param name="buff">
        /// �y���z���M�f�[�^�̐擪�A�h���X
        /// </param>
        /// <returns>
        /// ���M�v���������Ftrue
        /// ���M�v�����s���Ffalse
        /// </returns>
        /// <remarks>
        /// �w�肳�ꂽ����Ɏw�肳�ꂽ�f�[�^�𑗐M����B���̂Ƃ�������ڑ�����
        /// �Ă��Ȃ���Ή���ڑ����s���B
        /// �֐��̓f�[�^�̑��M�����A�������Ɋւ�炸�����ɏ������I������B
        /// �֐��̖߂�l�͑��M�o�b�t�@�ւ̏����݌��ʂ�Ԃ����̂ŁA�f�[�^�̑��M
        /// ���ʂ�\�����̂ł͂Ȃ��B
        /// </remarks>
        /// <exception cref="DllNotFoundException"></exception>
        /// <exception cref="EntryPointNotFoundException"></exception>
        /// <exception cref="AccessViolationException"></exception>
        /// <exception cref="Win32Exception"></exception>
        /// <exception cref="Exception"></exception>
        public static Boolean SendData(Int32 line, Byte[] buff)
        {
            try
            {
                LOGGER.Info("Sending " + buff.Length + " bytes to line #" + line.ToString());
                Int32 retval = pcifsend(line, buff, buff.Length);
                if (retval == -1)
                {
                    LOGGER.Info("Fail to send " + buff.Length + " bytes to line #" + line.ToString());
                    return false;
                }
                else
                {
                    LOGGER.Info("Success to send  " + buff.Length + " bytes to line #" + line.ToString());
                    return true;
                }
            }
            catch (DllNotFoundException ednf)
            {
                LOGGER.Error(ednf.Message);
            }
            catch (EntryPointNotFoundException eepnf)
            {
                LOGGER.Error(eepnf.Message);
            }
            catch (AccessViolationException eav)
            {
                LOGGER.Error(eav.Message);
            }
            catch (Win32Exception ew32)
            {
                LOGGER.Error(ew32.Message);
            }
            catch (Exception e)
            {
                LOGGER.Error(e.Message);
            }

            return false;
        }

        /// <summary>
        /// ���M�v���֐�
        /// 
        /// �w�肳�ꂽ����Ƀf�[�^�𑗐M�v���𔭍s����
        /// </summary>
        /// <param name="line">
        /// �y���z�f�[�^����M�������ԍ�
        /// </param>
        /// <param name="buff">
        /// �y���z���M�f�[�^�̐擪�A�h���X
        /// </param>
        /// <returns>
        /// ���M�v���������Ftrue
        /// ���M�v�����s���Ffalse
        /// </returns>
        /// <remarks>
        /// �w�肳�ꂽ����Ɏw�肳�ꂽ�f�[�^�𑗐M����B���̂Ƃ�������ڑ�����
        /// �Ă��Ȃ���Ή���ڑ����s���B
        /// �֐��̓f�[�^�̑��M�����A�������Ɋւ�炸�����ɏ������I������B
        /// �֐��̖߂�l�͑��M�o�b�t�@�ւ̏����݌��ʂ�Ԃ����̂ŁA�f�[�^�̑��M
        /// ���ʂ�\�����̂ł͂Ȃ��B
        /// </remarks>
        /// <exception cref="DllNotFoundException"></exception>
        /// <exception cref="EntryPointNotFoundException"></exception>
        /// <exception cref="AccessViolationException"></exception>
        /// <exception cref="Win32Exception"></exception>
        /// <exception cref="Exception"></exception>  
        public static Boolean SendData(Int32 line, String buff)
        {
            try
            {
                Int32 retval = pcifsend(line, buff, buff.Length);
                if (retval == -1)
                {
                    LOGGER.Info("Fail to send  " + buff.Length + " bytes to line #" + line.ToString());
                    return false;
                }
                else
                {
                    LOGGER.Info("Success to send  " + buff.Length + " bytes to line #" + line.ToString());
                    return true;
                }
            }
            catch (DllNotFoundException ednf)
            {
                LOGGER.Error(ednf.Message);
            }
            catch (EntryPointNotFoundException eepnf)
            {
                LOGGER.Error(eepnf.Message);
            }
            catch (AccessViolationException eav)
            {
                LOGGER.Error(eav.Message);
            }
            catch (Win32Exception ew32)
            {
                LOGGER.Error(ew32.Message);
            }
            catch (Exception e)
            {
                LOGGER.Error(e.Message);
            }

            return false;
        }

        /// <summary>
        /// ��M�v���֐�
        /// 
        /// �w�肳�ꂽ�������f�[�^����M����
        /// </summary>
        /// <param name="line">
        /// �y���z�f�[�^����M�������ԍ�
        /// </param>
        /// <param name="timeout">
        /// �y���z��M�҂��^�C���A�E�g���Ԃ��w�肷��ysec�z
        /// </param>
        /// <returns>        
        /// ��M�������F�f�[�^��M�̈�̐擪�A�h���X Byte array
        /// ��M���s���FByte[0]
        /// </returns>
        /// <remarks>
        /// �w�肳�ꂽ����ɂ���f�[�^����M����B���̂Ƃ���M�f�[�^�����݂���
        /// ���ꍇ�ɂ͊֐��͎w�肳�ꂽ�^�C���A�E�g���Ԃ܂Ŏ�M�҂��ƂȂ�B�^�C��
        /// �A�E�g���Ԃ̎w�肪�A�O�̏ꍇ�́A�i�v�ɑ҂B�������^�C���A�E�g������
        /// ���ɂ͊֐��́|�P��Ԃ��B
        /// </remarks>
        /// <exception cref="DllNotFoundException"></exception>
        /// <exception cref="EntryPointNotFoundException"></exception>
        /// <exception cref="AccessViolationException"></exception>
        /// <exception cref="Win32Exception"></exception>
        /// <exception cref="Exception"></exception>
        public static Byte[] ReceiveData(Int32 line, Int32 timeout)
        {
            try
            {
                IntPtr retsize = IntPtr.Zero;
                Byte[] buff = new Byte[MAX_BUFF];
                Int32 retval = pcifrecv(line, buff, MAX_BUFF, ref retsize, timeout);
                if (retsize.ToInt32() > 0 && retval != -1)
                {
                    Byte[] recv = new Byte[retsize.ToInt32()];
                    Array.Copy(buff, recv, retsize.ToInt32());

                    LOGGER.Info("Received " + retsize.ToInt32().ToString() + " bytes from line #" + line.ToString());
                    if (LOGGER.IsDebugEnabled)
                    {
                        LOGGER.Debug(Utilities.BytesToHexa(recv));
                    }
                    return recv;
                }
                return new Byte[0];
            }
            catch (DllNotFoundException ednf)
            {
                LOGGER.Error(ednf.Message);
            }
            catch (EntryPointNotFoundException eepnf)
            {
                LOGGER.Error(eepnf.Message);
            }
            catch (AccessViolationException eav)
            {
                LOGGER.Error(eav.Message);
            }
            catch (Win32Exception ew32)
            {
                LOGGER.Error(ew32.Message);
            }
            catch (Exception e)
            {
                LOGGER.Error(e.Message);
            }

            return new Byte[0];
        }

        /// <summary>
        /// ��M�f�[�^��o���֐�
        /// 
        /// �w�肳�ꂽ��������M�f�[�^�����o�� 
        /// </summary>
        /// <param name="line">
        /// �y���z�f�[�^����M�������ԍ�
        /// </param>
        /// <returns>        
        /// ��M�������F�f�[�^��M�̈�̐擪�A�h���X Byte array
        /// ��M���s���FByte[0]
        /// </returns>
        /// <remarks>
        /// �w�肳�ꂽ����̎�M�o�b�t�@���A��M�f�[�^�����o���B���̂Ƃ���
        /// �M�f�[�^�����݂��Ȃ��ꍇ�ɂ͊֐��́|�P��Ԃ��B
        /// </remarks>
        /// <exception cref="DllNotFoundException"></exception>
        /// <exception cref="EntryPointNotFoundException"></exception>
        /// <exception cref="AccessViolationException"></exception>
        /// <exception cref="Win32Exception"></exception>
        /// <exception cref="Exception"></exception>        
        public static Byte[] GetData(Int32 line)
        {
            try
            {
                IntPtr retsize = IntPtr.Zero;
                Byte[] buff = new Byte[MAX_BUFF];
                Int32 retval = pcifget(line, buff, MAX_BUFF, ref retsize);
                if (retsize.ToInt32() > 0 && retval != -1)
                {
                    Byte[] recv = new Byte[retsize.ToInt32()];
                    Array.Copy(buff, recv, retsize.ToInt32());

                    LOGGER.Info("Received " + retsize.ToInt32().ToString() + " bytes from line #" + line.ToString());
                    if (LOGGER.IsDebugEnabled)
                    {
                        LOGGER.Debug(Utilities.BytesToHexa(recv));
                    }
                    return recv;
                }

                return new Byte[0];
            }
            catch (DllNotFoundException ednf)
            {
                LOGGER.Error(ednf.Message);
            }
            catch (EntryPointNotFoundException eepnf)
            {
                LOGGER.Error(eepnf.Message);
            }
            catch (AccessViolationException eav)
            {
                LOGGER.Error(eav.Message);
            }
            catch (Win32Exception ew32)
            {
                LOGGER.Error(ew32.Message);
            }
            catch (Exception e)
            {
                LOGGER.Error(e.Message);
            }

            return new Byte[0];
        }

        /// <summary>
        /// �h���C�o�[�����N���֐�
        /// 
        /// �ʐM�h���C�o�[���N������
        /// </summary>
        /// <returns>
        /// True or False
        /// </returns>      
        /// <caution>
        /// ���֐����ʐM�h���C�o���N������ꍇ�́A�֐����Ăяo�������̃J����
        /// �g�f�B���N�g�����ɒʐM�h���C�o�[�����݂���K�v������B
        /// ���݂��Ȃ��ꍇ�ɂ́A���֐����Ăяo���O�ɁA�ʐM�h���C�o�[�����݂���
        /// �f�B���N�g���ɃJ�����g�f�B���N�g����ύX���Ă������ƁB
        /// </caution>
        /// <exception cref="DllNotFoundException"></exception>
        /// <exception cref="EntryPointNotFoundException"></exception>
        /// <exception cref="AccessViolationException"></exception>
        /// <exception cref="Win32Exception"></exception>
        /// <exception cref="Exception"></exception>        
        public static Boolean StartDriver()
        {
            try
            {
                // PcifDriver is not running
                if (!IsDriverProcessRunning())
                {                   
                    Int32 nRet = pcifstart();
                    if (nRet == -1)
                    {
                        LOGGER.Info("Try to start driver fail");
                        return false;
                    }
                    else
                    {
                        LOGGER.Info("Start driver success" + ", is running: " + IsDriverProcessRunning().ToString());
                        Trace.Assert(IsDriverProcessRunning());
                        return true;
                    }
                }
                else
                {
                    LOGGER.Info("Start driver fail, driver is running");
                    return false;
                }
            }
            catch (DllNotFoundException ednf)
            {
                LOGGER.Error(ednf.Message);
            }
            catch (EntryPointNotFoundException eepnf)
            {
                LOGGER.Error(eepnf.Message);
            }
            catch (AccessViolationException eav)
            {
                LOGGER.Error(eav.Message);
            }
            catch (Win32Exception ew32)
            {
                LOGGER.Error(ew32.Message);
            }
            catch (Exception e)
            {
                LOGGER.Error(e.Message);
            }

            return false;
        }

        /// <summary>
        /// �h���C�o�[������~�֐�
        /// 
        /// �ʐM�h���C�o�[���~����
        /// </summary>
        /// <returns>
        /// True or False
        /// </returns>
        /// <exception cref="DllNotFoundException"></exception>
        /// <exception cref="EntryPointNotFoundException"></exception>
        /// <exception cref="AccessViolationException"></exception>
        /// <exception cref="Win32Exception"></exception>
        /// <exception cref="Exception"></exception>        
        public static Boolean StopDriver()
        {
            try
            {
                // PcifDriver is running
                if (IsDriverProcessRunning())
                {
                    Int32 nRet = pcifstop();
                    if (nRet == -1)
                    {
                        LOGGER.Info("Try to stop driver fail");
                        return false;
                    }
                    else
                    {
                        LOGGER.Info("Stop driver success" + ", is running: " + IsDriverProcessRunning().ToString());
                        // Trace fail
                        // Trace.Assert(!IsDriverProcessRunning());
                        return true;
                    }
                }
                else
                {
                    LOGGER.Info("Stop driver fail, driver is not running");
                    return false;
                }
            }
            catch (DllNotFoundException ednf)
            {
                LOGGER.Error(ednf.Message);
            }
            catch (EntryPointNotFoundException eepnf)
            {
                LOGGER.Error(eepnf.Message);
            }
            catch (AccessViolationException eav)
            {
                LOGGER.Error(eav.Message);
            }
            catch (Win32Exception ew32)
            {
                LOGGER.Error(ew32.Message);
            }
            catch (Exception e)
            {
                LOGGER.Error(e.Message);
            }

            return false;
        }

        /// <summary>
        /// ����������֐�
        /// 
        /// �w�肳�ꂽ����ԍ��̉��������������
        /// </summary>
        /// <param name="line">
        /// �y���z�������������ԍ�
        /// </param>
        /// <returns>
        /// True or False
        /// </returns>
        /// <remarks>
        /// �������̏������i�ؒf���s���j�A����̐ڑ��̓f�[�^���M���ɍs����
        /// </remarks>
        /// <exception cref="DllNotFoundException"></exception>
        /// <exception cref="EntryPointNotFoundException"></exception>
        /// <exception cref="AccessViolationException"></exception>
        /// <exception cref="Win32Exception"></exception>
        /// <exception cref="Exception"></exception>        
        public static Boolean Init(Int32 line)
        {
            try
            {
                Int32 nRet = pcifinit(line);
                if (nRet == -1)
                {
                    LOGGER.Info("Init line #" + line.ToString() + " fail");
                    return false;
                }
                else
                {
                    LOGGER.Info("Init line #" + line.ToString() + " success" + ", line status: " + GetStatusDesc(line));
                    return true;
                }
            }
            catch (DllNotFoundException ednf)
            {
                LOGGER.Error(ednf.Message);
            }
            catch (EntryPointNotFoundException eepnf)
            {
                LOGGER.Error(eepnf.Message);
            }
            catch (AccessViolationException eav)
            {
                LOGGER.Error(eav.Message);
            }
            catch (Win32Exception ew32)
            {
                LOGGER.Error(ew32.Message);
            }
            catch (Exception e)
            {
                LOGGER.Error(e.Message);
            }

            return false;
        }

        /// <summary>
        /// �R�l�N�V�����m���v���֐�
        /// 
        /// �w�肳�ꂽ����ԍ��̃R�l�N�V�������m������
        /// </summary>
        /// <param name="line">
        /// �y���z�R�l�N�V�������m���������ԍ�
        /// </param>
        /// <returns>
        /// True or False
        /// </returns>
        /// <exception cref="DllNotFoundException"></exception>
        /// <exception cref="EntryPointNotFoundException"></exception>
        /// <exception cref="AccessViolationException"></exception>
        /// <exception cref="Win32Exception"></exception>
        /// <exception cref="Exception"></exception>        
        public static Boolean Connect(Int32 line)
        {
            try
            {
                Int32 nRet = pcifconc(line);
                if (nRet == -1)
                {
                    LOGGER.Info("Connect to line #" + line.ToString() + " fail");
                    return false;
                }
                else
                {
                    LOGGER.Info("Connect to line #" + line.ToString() + " success" + ", line status: " + GetStatusDesc(line));
                    return true;
                }
            }
            catch (DllNotFoundException ednf)
            {
                LOGGER.Error(ednf.Message);
            }
            catch (EntryPointNotFoundException eepnf)
            {
                LOGGER.Error(eepnf.Message);
            }
            catch (AccessViolationException eav)
            {
                LOGGER.Error(eav.Message);
            }
            catch (Win32Exception ew32)
            {
                LOGGER.Error(ew32.Message);
            }
            catch (Exception e)
            {
                LOGGER.Error(e.Message);
            }

            return false;
        }
        
        /*
        static unsafe void ByteCopy(Byte[] src, Int32 srcIndex,
            Byte[] dst, Int32 dstIndex, Int32 count)
        {
            if (src == null || srcIndex < 0 ||
                dst == null || dstIndex < 0 || count < 0)
            {
                throw new ArgumentException();
            }
            Int32 srcLen = src.Length;
            Int32 dstLen = dst.Length;
            if (srcLen - srcIndex < count ||
                dstLen - dstIndex < count)
            {
                throw new ArgumentException();
            }


            // The following fixed statement pins the location of
            // the src and dst objects in memory so that they will
            // not be moved by garbage collection.          
            fixed (Byte* pSrc = src, pDst = dst)
            {
                Byte* ps = pSrc;
                Byte* pd = pDst;

                // Loop over the count in blocks of 4 bytes, copying an
                // integer (4 bytes) at a time:
                for (Int32 n = 0; n < count / 4; n++)
                {
                    *((Int32*)pd) = *((Int32*)ps);
                    pd += 4;
                    ps += 4;
                }

                // Complete the copy by moving any bytes that weren't
                // moved in blocks of 4:
                for (Int32 n = 0; n < count % 4; n++)
                {
                    *pd = *ps;
                    pd++;
                    ps++;
                }
            }
        }
        */

        /// <summary>
        /// This routine returns TRUE if the caller's process 
        /// is a member of the Administrators local group. Caller is NOT expected 
        /// to be impersonating anyone and is expected to be able to open its own 
        /// process and process token.
        /// </summary>
        /// <returns>
        /// True - Caller has Administrators local group.
        /// False - Caller does not have Administrators local group. 
        /// </returns>      
        public static Boolean IsUserAdmin()
        {
            Boolean bResult = false;
            Byte[] SECURITY_NT_AUTHORITY = {
                Advapi32.SECURITY_NT_AUTHORITY_BYTE_0, 
                Advapi32.SECURITY_NT_AUTHORITY_BYTE_1, 
                Advapi32.SECURITY_NT_AUTHORITY_BYTE_2, 
                Advapi32.SECURITY_NT_AUTHORITY_BYTE_3, 
                Advapi32.SECURITY_NT_AUTHORITY_BYTE_4, 
                Advapi32.SECURITY_NT_AUTHORITY_BYTE_5, 
            };

            Advapi32.SID_IDENTIFIER_AUTHORITY NtAuthority = new Advapi32.SID_IDENTIFIER_AUTHORITY(SECURITY_NT_AUTHORITY);
            IntPtr AdministratorsGroup;

            bResult = Advapi32.AllocateAndInitializeSid(ref NtAuthority, 2, Advapi32.SECURITY_BUILTIN_DOMAIN_RID,
                            Advapi32.DOMAIN_ALIAS_RID_ADMINS, 0, 0, 0, 0, 0, 0, out AdministratorsGroup);
            if (bResult)
            {
                if (!Advapi32.CheckTokenMembership(IntPtr.Zero, AdministratorsGroup, out bResult))
                {
                    bResult = false;
                }
                Advapi32.FreeSid(AdministratorsGroup);
            }

            return bResult;
        }

        /// <summary>
        /// Determine OS is Win32NT and version > 5 (Windows 2000 NT or later)
        /// </summary>
        /// <returns>
        /// True - Is Windows 2000 NT or later
        /// False - Not a Windows 2000 NT or later
        /// </returns>
        public static Boolean IsWins2kOrLater()
        {
            // Win32NT The operating system is Windows NT or later. 
            return (Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major > 5);
        }
    }
    #endregion
}