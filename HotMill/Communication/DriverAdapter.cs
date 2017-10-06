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
    /// 回線状態
    /// </summary>
    public enum LineStatusType
    {
        StatusFailed,
        Disconnected,           // コネクション解放中
        ConnectingRequest,      // 接続要求中
        EstablishingRequest,    // コネクション確立中
        ModeConfirming,         // モード確認中
        Connected,              // 通信可能状態
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
        /// 送信要求関数            pcifsend()
        /// エクスポート関数名      ?pcifsend@@YAHHPADH@Z
        /// 
        /// 指定された回線にデータを送信要求を発行する     
        /// 
        /// コーリングシーケンス
        ///     int pcifsend(
        ///        int line_no,
        ///        char *msg,
        ///        int leng,
        ///     );
        /// </summary>
        /// <param name="line_no">
        /// 【入】データを送信する回線番号
        /// </param>
        /// <param name="msg">
        /// 【入】送信データの先頭アドレス
        /// </param>
        /// <param name="leng">
        /// 【入】送信データの長さ【byte】
        /// </param>
        /// <returns>
        /// 送信要求成功時：１
        /// 送信要求失敗時：－１
        /// </returns>
        /// <remarks>
        /// 指定された回線に指定されたデータを送信する。このとき回線が接続され
        /// ていなければ回線接続を行う。
        /// 関数はデータの送信完了、未完了に関わらず即座に処理を終了する。
        /// 関数の戻り値は送信バッファへの書込み結果を返すもので、データの送信
        /// 結果を表すものではない。
        /// </remarks>
        [DllImport("DriverDLL.dll", EntryPoint = "?pcifsend@@YAHHPADH@Z")]
        static extern Int32 pcifsend(Int32 line_no, String msg, Int32 leng);

        /// <summary>
        /// 送信要求関数            pcifsend()
        /// エクスポート関数名      ?pcifsend@@YAHHPADH@Z
        /// 
        /// 指定された回線にデータを送信要求を発行する     
        /// 
        /// コーリングシーケンス
        ///     int pcifsend(
        ///        int line_no,
        ///        char *msg,
        ///        int leng,
        ///     );
        /// </summary>
        /// <param name="line_no">
        /// 【入】データを送信する回線番号
        /// </param>
        /// <param name="msg">
        /// 【入】送信データの先頭アドレス
        /// </param>
        /// <param name="leng">
        /// 【入】送信データの長さ【byte】
        /// </param>
        /// <returns>
        /// 送信要求成功時：１
        /// 送信要求失敗時：－１
        /// </returns>
        /// <remarks>
        /// 指定された回線に指定されたデータを送信する。このとき回線が接続され
        /// ていなければ回線接続を行う。
        /// 関数はデータの送信完了、未完了に関わらず即座に処理を終了する。
        /// 関数の戻り値は送信バッファへの書込み結果を返すもので、データの送信
        /// 結果を表すものではない。
        /// </remarks>
        [DllImport("DriverDLL.dll", EntryPoint = "?pcifsend@@YAHHPADH@Z")]
        static extern Int32 pcifsend(Int32 line_no, [In] Byte[] msg, Int32 leng);

        /// <summary>
        /// 受信要求関数        pcifrecv()
        /// エクスポート関数名  ?pcifrecv@@YAHHPADHPAHH@Z
        /// 
        /// 指定された回線からデータを受信する
        /// 
        /// コーリングシケンス
        ///     int pcifrecv(
        ///         int line_no,
        ///         char *msg,
        ///         int max_leng,
        ///         int *leng,
        ///         int timeout,
        ///     );        
        /// </summary>
        /// <param name="line_no">
        /// 【入】データを受信する回線番号
        /// </param>
        /// <param name="msg">
        /// 【出】データ受信領域の先頭アドレス
        /// </param>
        /// <param name="max_leng">
        /// 【入】最大受信長
        /// </param>
        /// <param name="leng">
        /// 【出】受信データ長
        /// </param>
        /// <param name="timeout">
        /// 【入】受信待ちタイムアウト時間を指定する【sec】
        /// </param>
        /// <returns>
        /// 受信成功時：１
        /// 受信失敗時：－１
        /// </returns>
        /// <remarks>
        /// 指定された回線にからデータを受信する。このとき受信データが存在しな
        /// い場合には関数は指定されたタイムアウト時間まで受信待ちとなる。タイム
        /// アウト時間の指定が、０の場合は、永久に待つ。処理がタイムアウトした場
        /// 合には関数は－１を返す。
        /// </remarks>
        [DllImport("DriverDLL.dll", EntryPoint = "?pcifrecv@@YAHHPADHPAHH@Z")]
        static extern Int32 pcifrecv(Int32 line_no, StringBuilder msg, Int32 max_leng, ref IntPtr leng, Int32 timeout);

        /// <summary>
        /// 受信要求関数        pcifrecv()
        /// エクスポート関数名  ?pcifrecv@@YAHHPADHPAHH@Z
        /// 
        /// 指定された回線からデータを受信する
        /// 
        /// コーリングシケンス
        ///     int pcifrecv(
        ///         int line_no,
        ///         char *msg,
        ///         int max_leng,
        ///         int *leng,
        ///         int timeout,
        ///     );        
        /// </summary>
        /// <param name="line_no">
        /// 【入】データを受信する回線番号
        /// </param>
        /// <param name="msg">
        /// 【出】データ受信領域の先頭アドレス
        /// </param>
        /// <param name="max_leng">
        /// 【入】最大受信長
        /// </param>
        /// <param name="leng">
        /// 【出】受信データ長
        /// </param>
        /// <param name="timeout">
        /// 【入】受信待ちタイムアウト時間を指定する【sec】
        /// </param>
        /// <returns>
        /// 受信成功時：１
        /// 受信失敗時：－１
        /// </returns>
        /// <remarks>
        /// 指定された回線にからデータを受信する。このとき受信データが存在しな
        /// い場合には関数は指定されたタイムアウト時間まで受信待ちとなる。タイム
        /// アウト時間の指定が、０の場合は、永久に待つ。処理がタイムアウトした場
        /// 合には関数は－１を返す。
        /// </remarks>
        [DllImport("DriverDLL.dll", EntryPoint = "?pcifrecv@@YAHHPADHPAHH@Z")]
        static extern Int32 pcifrecv(Int32 line_no, [In, Out] Byte[] msg, Int32 max_leng, ref IntPtr leng, Int32 timeout);

        /// <summary>
        /// 受信データ取出し関数        pcifget()
        /// エクスポート関数名          ?pcifget@@YAHHPADHPAH@Z
        /// 
        /// 指定された回線から受信データを取り出す        
        /// 
        /// コーリングシケンス
        ///     int pcifget(
        ///         int line_no,
        ///         char *msg,
        ///         int max_leng,
        ///         int *leng,
        ///     );
        /// </summary>
        /// <param name="line_no">
        /// 【入】データを受信する回線番号
        /// </param>
        /// <param name="msg">
        /// 【出】データ受信領域の先頭アドレス
        /// </param>
        /// <param name="max_leng">
        /// 【入】最大受信長
        /// </param>
        /// <param name="leng">
        /// 【出】受信データ長
        /// </param>
        /// <returns>
        /// 成功時：１
        /// 失敗時：－１
        /// </returns>
        /// <remarks>
        /// 指定された回線の受信バッファより、受信データを取り出す。このとき受
        /// 信データが存在しない場合には関数は－１を返す。
        /// </remarks>
        [DllImport("DriverDLL.dll", EntryPoint = "?pcifget@@YAHHPADHPAH@Z")]
        static extern Int32 pcifget(Int32 line_no, StringBuilder msg, Int32 max_leng, ref IntPtr leng);

        /// <summary>
        /// 受信データ取出し関数        pcifget()
        /// エクスポート関数名          ?pcifget@@YAHHPADHPAH@Z
        /// 
        /// 指定された回線から受信データを取り出す        
        /// 
        /// コーリングシケンス
        ///     int pcifget(
        ///         int line_no,
        ///         char *msg,
        ///         int max_leng,
        ///         int *leng,
        ///     );
        /// </summary>
        /// <param name="line_no">
        /// 【入】データを受信する回線番号
        /// </param>
        /// <param name="msg">
        /// 【出】データ受信領域の先頭アドレス
        /// </param>
        /// <param name="max_leng">
        /// 【入】最大受信長
        /// </param>
        /// <param name="leng">
        /// 【出】受信データ長
        /// </param>
        /// <returns>
        /// 成功時：１
        /// 失敗時：－１
        /// </returns>
        /// <remarks>
        /// 指定された回線の受信バッファより、受信データを取り出す。このとき受
        /// 信データが存在しない場合には関数は－１を返す。
        /// </remarks>
        [DllImport("DriverDLL.dll", EntryPoint = "?pcifget@@YAHHPADHPAH@Z")]
        static extern Int32 pcifget(Int32 line_no, [In, Out] Byte[] msg, Int32 max_leng, ref IntPtr leng);

        /// <summary>
        /// ドライバー処理起動関数  pcifstart()
        /// エクスポート関数名      ?pcifstart@@YAHXZ
        /// 
        /// 通信ドライバーを起動する
        /// 
        /// コーリングシケンス
        ///     int pcifstart();
        /// </summary>
        /// <returns>
        /// 成功時：１
        /// 失敗時：－１
        /// </returns>
        /// <caution>
        /// 当関数より通信ドライバを起動する場合は、関数を呼び出す処理のカレン
        /// トディレクトリ内に通信ドライバーが存在する必要がある。
        /// 存在しない場合には、当関数を呼び出す前に、通信ドライバーが存在する
        /// ディレクトリにカレントディレクトリを変更しておくこと。
        /// </caution>
        [DllImport("DriverDLL.dll", EntryPoint = "?pcifstart@@YAHXZ")]
        static extern Int32 pcifstart();

        /// <summary>
        /// ドライバー処理停止関数  pcifstop()
        /// エクスポート関数名      ?pcifstop@@YAHXZ
        /// 
        /// 通信ドライバーを停止する
        /// 
        /// コーリングシケンス
        ///     int pcifstop();
        /// </summary>
        /// <returns>
        /// 成功時：１
        /// 失敗時：－１
        /// </returns>
        [DllImport("DriverDLL.dll", EntryPoint = "?pcifstop@@YAHXZ")]
        static extern Int32 pcifstop();
        
        /// <summary>
        /// 回線初期化関数          pcifinit()
        /// エクスポート関数名      ?pcifinit@@YAHH@Z
        /// 
        /// 指定された回線番号の回線を初期化する
        /// 
        /// コーリングシーケンス
        ///     int pcifinit(
        ///         int line_no,
        ///     );
        /// </summary>
        /// <param name="line_no">
        /// 【入】初期化する回線番号
        /// </param>
        /// <returns>
        /// 初期化成功時：１
        /// 初期化失敗時：－１
        /// </returns>
        /// <remarks>
        /// 特定回線の初期化（切断を行う）、回線の接続はデータ送信時に行われる
        /// </remarks>
        [DllImport("DriverDLL.dll", EntryPoint = "?pcifinit@@YAHH@Z")]
        static extern Int32 pcifinit(Int32 line_no);

        /// <summary>
        /// コネクション確立要求関数        pcifconc()
        /// エクスポート関数名              ?pcifconc@@YAHH@Z
        /// 
        /// 指定された回線番号のコネクションを確立する
        /// 
        /// コーリングシーケンス
        ///     int pcifconc(
        ///         int line_no,
        ///     );
        /// </summary>
        /// <param name="line_no">
        /// 【入】コネクションを確立する回線番号
        /// </param>
        /// <returns>
        /// 初期化成功時：１
        /// 初期化失敗時：－１
        /// </returns>
        [DllImport("DriverDLL.dll", EntryPoint = "?pcifconc@@YAHH@Z")]
        static extern Int32 pcifconc(Int32 line_no);

        /// <summary>
        /// 回線状態取出し関数          pcifstget()
        /// エクスポート関数名          ?pcifstget@@YAHHPAH@Z
        /// 
        /// 指定された回線の回線状態を取り出す
        /// 
        /// コーリングシケンス
        ///     int pcifstget(
        ///         int line_no,
        ///         int *st,
        ///     );
        /// </summary>
        /// <param name="line_no">
        /// 【入】データを受信する回線番号
        /// </param>
        /// <param name="st">
        /// 【出】回線状態
        ///     ０：コネクション解放中
        ///     １：接続要求中
        ///     ２：コネクション確立中
        ///     ３：モード確認中
        ///     ４：通信可能状態
        /// </param>
        /// <returns>
        /// 成功時：１
        /// 失敗時：－１
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
        /// 回線状態取出し関数
        /// 
        /// 指定された回線の回線状態を取り出す
        /// </summary>
        /// <param name="line">
        /// 【入】データを受信する回線番号
        /// </param>
        /// <returns>
        /// 回線状態 enum
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
        /// 回線状態取出し関数
        /// </summary>
        /// <param name="line">
        /// 【入】データを受信する回線番号
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        public static String GetStatusDesc(Int32 line)
        {
            return GetStatus(line).ToString();
        }

        /// <summary>
        /// 送信要求関数
        /// 
        /// 指定された回線にデータを送信要求を発行する
        /// </summary>
        /// <param name="line">
        /// 【入】データを受信する回線番号
        /// </param>
        /// <param name="buff">
        /// 【入】送信データの先頭アドレス
        /// </param>
        /// <returns>
        /// 送信要求成功時：true
        /// 送信要求失敗時：false
        /// </returns>
        /// <remarks>
        /// 指定された回線に指定されたデータを送信する。このとき回線が接続され
        /// ていなければ回線接続を行う。
        /// 関数はデータの送信完了、未完了に関わらず即座に処理を終了する。
        /// 関数の戻り値は送信バッファへの書込み結果を返すもので、データの送信
        /// 結果を表すものではない。
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
        /// 送信要求関数
        /// 
        /// 指定された回線にデータを送信要求を発行する
        /// </summary>
        /// <param name="line">
        /// 【入】データを受信する回線番号
        /// </param>
        /// <param name="buff">
        /// 【入】送信データの先頭アドレス
        /// </param>
        /// <returns>
        /// 送信要求成功時：true
        /// 送信要求失敗時：false
        /// </returns>
        /// <remarks>
        /// 指定された回線に指定されたデータを送信する。このとき回線が接続され
        /// ていなければ回線接続を行う。
        /// 関数はデータの送信完了、未完了に関わらず即座に処理を終了する。
        /// 関数の戻り値は送信バッファへの書込み結果を返すもので、データの送信
        /// 結果を表すものではない。
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
        /// 受信要求関数
        /// 
        /// 指定された回線からデータを受信する
        /// </summary>
        /// <param name="line">
        /// 【入】データを受信する回線番号
        /// </param>
        /// <param name="timeout">
        /// 【入】受信待ちタイムアウト時間を指定する【sec】
        /// </param>
        /// <returns>        
        /// 受信成功時：データ受信領域の先頭アドレス Byte array
        /// 受信失敗時：Byte[0]
        /// </returns>
        /// <remarks>
        /// 指定された回線にからデータを受信する。このとき受信データが存在しな
        /// い場合には関数は指定されたタイムアウト時間まで受信待ちとなる。タイム
        /// アウト時間の指定が、０の場合は、永久に待つ。処理がタイムアウトした場
        /// 合には関数は－１を返す。
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
        /// 受信データ取出し関数
        /// 
        /// 指定された回線から受信データを取り出す 
        /// </summary>
        /// <param name="line">
        /// 【入】データを受信する回線番号
        /// </param>
        /// <returns>        
        /// 受信成功時：データ受信領域の先頭アドレス Byte array
        /// 受信失敗時：Byte[0]
        /// </returns>
        /// <remarks>
        /// 指定された回線の受信バッファより、受信データを取り出す。このとき受
        /// 信データが存在しない場合には関数は－１を返す。
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
        /// ドライバー処理起動関数
        /// 
        /// 通信ドライバーを起動する
        /// </summary>
        /// <returns>
        /// True or False
        /// </returns>      
        /// <caution>
        /// 当関数より通信ドライバを起動する場合は、関数を呼び出す処理のカレン
        /// トディレクトリ内に通信ドライバーが存在する必要がある。
        /// 存在しない場合には、当関数を呼び出す前に、通信ドライバーが存在する
        /// ディレクトリにカレントディレクトリを変更しておくこと。
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
        /// ドライバー処理停止関数
        /// 
        /// 通信ドライバーを停止する
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
        /// 回線初期化関数
        /// 
        /// 指定された回線番号の回線を初期化する
        /// </summary>
        /// <param name="line">
        /// 【入】初期化する回線番号
        /// </param>
        /// <returns>
        /// True or False
        /// </returns>
        /// <remarks>
        /// 特定回線の初期化（切断を行う）、回線の接続はデータ送信時に行われる
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
        /// コネクション確立要求関数
        /// 
        /// 指定された回線番号のコネクションを確立する
        /// </summary>
        /// <param name="line">
        /// 【入】コネクションを確立する回線番号
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