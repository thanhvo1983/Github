using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Kvics.HotMill.BL;
using Kvics.Utility;

using log4net;
using log4net.Config;


namespace Kvics.HotMill.Forms
{
    public partial class MainForm : SubFormFullScreen
    {
        public static MainForm MAIN_FORM = null;
        // for test only
        //private static readonly string T900_DATA_SAMPLE = "30303031303030313132333435362020090004001000010044201c004b43303835353731342032323231303302000200010007000000000058483139303557201e0032000b00be005a0028006400c201c800c80000000a000a00000000000a0000002600000000006c208d2a7b00122b8700930034295128ac27aa264d25f5238f22f62846283827d4256f24012308210100fa04c30cfa047a00e905d102a1011401c10088007a00530065005d004800430045003b0025026a04bd07c20b9a104316901a581b0b000c000d000e000f00100011001a0aa90833080308e3084608e807800ce40c480dac0d100e740ed80eb41418157c15e0154416a8160c17ad06c207d307b00731081709a90ae81c4c1db01d141e781edc1e401f1c258025e4254826ac2610277427502db42d182e7c2ee02e442fa82f8435e8354c36b03614377837dc37b83d1c3e803ee43e483fac3f10403d032102fd01490288025402690490020901980064002100ecffc8ffcdff0c00e2ff120005004a06be03a1020502ac0190019901ec455046b44618477c47e0474448204e844ee84e4c4fb04f145078501400e2ffd8ffb600b600b600b6003800380038003800380038003800000000000000000000000000000000000000000000000000000000000000000000000000000046313739592046313633592046313239592048313737482048313935592048313733482048373137412030393039303930393039303930384e3b0100762c0100fa160100c90f010094130100c40601006919010000000000000038ffd4fed4fe000000000000000000000000000000000000000000000000000000000000423039364b20423130374820423039344820423132314820423133354b20423131354b20423132384b20423131304b20423134304b20423133314b20423133324b20423131374b20423133384b20423132304b20000025350200783c0200c2340200945502001b7002007a4c020088620200803702003a73020094660200606d02000a470200de6f02005c4c020000000000000000000000000000000000000000000000000000000000000000000d0039005b0023004e000e003a00180044000200400009002000430000000000000000000000000000000000000000000000dc264a2b76283823cd221622ed20000000000000000000000000000000000000000000000000000000000000000000000000";
        //private static readonly string T800_DATA_SAMPLE = "30303032303030313132333435362020090004001000010044201C004B43303835353731342032323231303302000200010007000000000058483139303557201E006C208F2B1503122B6501710134295128AC27AA264D25F5238F22F62846283827D4256F24012308210100FA04C30CFA047A00E905D102A1011401C10088007A00530065005D004800430045003B0025026A04BD07C20B9A104316901A581B19001A001B001C001D001E001F001A0AA90833080308E3084608E807F8115C12C01224138813EC1350142C1A901AF41A581BBC1B201C841CAD06C207D307B00731081709A90A6022C42228238C23F0235424B824942AF82A5C2BC02B242C882CEC2CC8322C339033F4335834BC342035FC3A603BC43B283C8C3CF03C543D30439443F8435C44C044244588453D032102FD01490288025402690486020501960064002000ECFFC8FFCDFF0C00E2FF120005003806B103AC021602B3019201A601DB03D0003F006D00680069003B003600D6FE96FF33FEB3FE4BFFFCFF1400E2FFD8FFB600B600B600B600B401E601F001120112011201120123002F009A00D1008E009B009A002E0057008B00CF0017017A010000000000000000000000000000000000000000000000000000000000009803B603D403F20310042E044C046A048804A6043400350036003700380039003A003B003C003D003E003F0040004100420043004400450046004700480049004A004B004C004D004E004F0050005100520053005400550056005700580059005A005B005C005D005E005F0060006100620063006400650066006700680069006A006B006C006D006E006F0070007100720073007400750076007700780079007A007B007C007D007E007F0080008100820083008400850086008700880089008A008B008C008D008E008F00900091009200930094009500960097003701380139013A013B013C013D0141014201430144014501460147014B014C014D014E014F0150015101550156015701580159015A015B015F0160016101620163016401650169016A016B016C016D016E016F0173017401750176017701780179017D017E017F0180018101820183018701880189018A018B018C018D0191019201930194019501960197010C000A0014001E00280033003D00470001000000070001004000230000000000312032203320342035203120322033203420352015001B00210027002D00200026002C0032003800120010000F001700150014001C001A00190021001F004B0019002D000500000000005A005B005C005D005E005F00600061006200630000001F0033000B000100210035000D00020025003900110000000000000000000000";
        //private static readonly string T1800_DATA_SAMPLE = "30303033303030313132333435362020090004001000010044201c004b43303835353731342032323231303302000200010007000000000058483139303557201e0063201c2a5e28c027bc2666250b24a422b9200105c30c08057e00ed05fe05d602cd029e01a00114011401cb00c4009900920081007b0021025b049d07c00ba5101f16931a120ad80a2b09570911094109f2092e0a4b0a3e0a7e096a09e108ef088011f81157137a13be12701294111110df132614b4138516710d4f0f4a063906bd03ae03a102990208020002af01ac01960192019a0193011700e4ffdaffb200b300b200b200b101e401ee0116011501160116011e001b002a003500b400ae00c400d00086009a009b00a10092009b002e0057008b00eb003401970153002f007d002300c80019000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000180018001800180019001900190019001900190019001900190019001a001a001a001a001a001a001a001a001a001a001b001b001b001b001b001b001b001b001b001b001c001c001c001c001c001c001c001c001c001c001d001d001d001d001d001d001d001d001d001d001e001e001e001e001e001e001e001e001e001e001f001f001f001f001f001f001f001f001f001f0020002000200020002000200020002000200020002100210021002100210021002100210021002100220022002200220022002200220022002200220023002300230023002300230023002300230023002400240024002400240024002400240024002400250025002500250025002500250025002500250026002600260026002600260026002600260026002700270027002700270027002700270027002700280028002800280028002800280028002800280029002900290029002900290029002900290029002a002a002a002a002a002a002a002a002a002a002b002b002b002b002b002b002b002b002b002b002c002c002c002c002c002c002c002c002c002c002d002d002d002d002d002d002d002d002d002d002e002e002e002e002e002e002e002e002e002e002f002f002f002f002f002f002f002f002f002f0030003000300030003000300030003000300030003100310031003100310031003100310031003100320032003200320032003200320032003200320033003300330033003300330033003300330033003400340034003400340034003400340034003400350035003500350035003500350035003500350036003600360036003600360036003600360036003700370037003700370037003700370037003700380038003800380038003800380038003800380039003900390039003900390039003900390039003a003a003a003a003a003a003a003a003a003a003b003b003b003b003b003b003b003b003b003b003c003c003c003c003c003c003c003c003c003c003d003d003d003d003d003d003d003d003d003d003e003e003e003e003e003e003e003e003e003e003f003f003f003f003f003f003f003f003f003f0040004000400040004000400040004000400040004100410041004100410041004100410041004100420042004200420042004200420042004200420043004300430043004300430043004300430043004400440044004400440044004400440044004400450045004500450045004500450045004500450046004600460046004600460046004600460046004700470047004700470047004700470047004700480048004800480048004800480048004800480049004900490049004900490049004900490049004a004a004a004a004a004a004a004a004a004a004b004b004b004b004b004b004b004b004b004b004c004c004c004c004c004c004c004c004c004c004d004d004d004d004d004d004d004d004d004d004e004e004e004e004e004e004e004e004e004e004f004f004f004f004f004f004f004f004f004f005000500050005000500050005000500050005000510051005100510051005100510051005100510052005200520052005200520052005200520052005300530053005300530053005300530053005300540054005400540054005400540054005400540055005500550055005500550055005500550055005600560056005600560056005600560056005600570057005700570057005700b904cc05090018001800090019002a00090018001d00090019002e00090018002000090019002f0009001800210009001900300009001800220009001900310009001800230009001900310009001800240009001900320000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
        // end for test only

        private static readonly ILog log = Kvics.DBAccess.Log.Instance.GetLogger(typeof(MainForm));
        private static string FSU_ASSIST__FILE_PATH = @"D:\FSU_assist\FSU_assist.exe";
        private static string FSU_ASSIST__ABSOLUTE_PATH = @"D:\FSU_assist\rcv_dat\2007_12\";
        private static int WAIT_FOR_FSU_ASSIST_EXIT = 30000;
        //absolutePath

        public bool IsStandby = false;
        private FormPresetCalculator frmPreset = null;
        private FormSearchCoil frmSearchCoil = null;
        private FormPressureDifferenceTotal frmPressureDifferenceTotal = null;
        private FormSetParameter frmSetParameter = null;
        private FormWorker frmWorker = null;
        private FormFinishSupport1 frmSupport1 = null;
        private FormFinishSupport2 frmSupport2 = null;
        //private FormFinishSupport1_V4 frmSupport1_V4 = null;
        private FormFinishSupport1_V5 frmSupport1_V5 = null;

        private HotMillFormCollection _SubForm = new HotMillFormCollection();

        private bool _SetPresetFocus = true;

        private Communication.HGSReceiverWorker _Worker1 = null;
        private Communication.HGSReceiverWorker _Worker2 = null;

        private int _Line1 = 1;
        private int _Line2 = 2;
        private int _Line3 = 3;

        private int _SelectedWorkerID = -1;

        private bool _RequireExit = false;

        public MainForm()
        {
            InitializeComponent();

            try
            {
                FSU_ASSIST__FILE_PATH = System.Configuration.ConfigurationManager.AppSettings["FSU_ASSIST__FILE_PATH"];
                FSU_ASSIST__ABSOLUTE_PATH = System.Configuration.ConfigurationManager.AppSettings["FSU_ASSIST__ABSOLUTE_PATH"];
                WAIT_FOR_FSU_ASSIST_EXIT = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["WAIT_FOR_FSU_ASSIST_EXIT"]);
            }
            catch (Exception)
            {
                MessageBox.Show("Configファイルはエラーがあります。管理者に通知して下さい。");
                Close();
                return;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // for test only
            MainForm.MAIN_FORM = this;
            // end for test only

            if (!ValidateDatabase())
            {
                return;
            }

            InitCommunication();

            this.Width = SystemInformation.WorkingArea.Width;
            this.Height = SystemInformation.WorkingArea.Height;

            this.Top = SystemInformation.WorkingArea.Top;
            this.Left = (SystemInformation.WorkingArea.Width - this.Width) / 2;

            preSetButton_Click(null, null);

            this.frmPreset.Close();
        }

        private void InitCommunication()
        {
            Communication.DriverAdapter.StartDriver();

            _Worker1 = Kvics.Communication.HGSReceiverWorker.GetInstance(this._Line1);
            _Worker1.PacketArrived += new Kvics.Communication.PacketArrivedEventHandler(Worker1_PacketArrived);
            _Worker1.StartWorker();

            _Worker2 = Kvics.Communication.HGSReceiverWorker.GetInstance(this._Line2);
            _Worker2.PacketArrived += new Kvics.Communication.PacketArrivedEventHandler(Worker2_PacketArrived);
            _Worker2.StartWorker();
        }

        private void Worker1_PacketArrived(object sender, Kvics.Communication.PacketArrivedEventArgs e)
        {
            // Stop worker2
            /*
            if (this._Worker2 != null)
            {
                this._Worker2.CancelWorker();
                this._Worker2 = null;
            }
            */

            if (e.Data == null || e.Data.Buff == null || e.Data.Buff.Length == 0)
            {
                log.Error("Procon's data null.");
            }

            IsStandby = false;

            try
            {
                log.Debug("Sending data to standby. Data's length: " + e.Data.Buff.Length);
                SendData(e.Data.Buff);
            }
            catch (Exception ex)
            {
                log.Error("Sending fail.", ex);
                MessageBox.Show("待機系へのデータ送信中にエラーが発生しました。管理者に通知して下さい。");
                //Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.StackTrace);
            }

            try
            {
                // Store data and validate UI
                log.Debug("Storing data from Procon. Data's length: " + e.Data.Buff.Length);
                StoreDataAndValidate(e.Data.Buff);
            }
            catch (Exception ex)
            {
                log.Error("Storing fail from Procon.", ex);
                MessageBox.Show("データベースへのデータ格納中にエラーが発生しました。管理者に通知して下さい。");
                //Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.StackTrace);
            }
        }

        private void Worker2_PacketArrived(object sender, Kvics.Communication.PacketArrivedEventArgs e)
        {
            try
            {
                //System.IO.File.WriteAllBytes(@"C:\data_Worker2_" + e.Data.Buff.Length + "_" + DateTime.Now.ToLongTimeString().Replace(":", "_") + "_" + System.DateTime.Now.Millisecond.ToString() + ".dat", e.Data.Buff);

                // Send data to stanby system
                //SendData(e.Data.Buff);

                IsStandby = true;

                // Store data and validate UI
                StoreDataAndValidate(e.Data.Buff);
            }
            catch (Exception ex)
            {
                log.Error("Storing fail from Main.", ex);
                MessageBox.Show("データベースへのデータ格納中にエラーが発生しました。管理者に通知して下さい。");
                //Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.StackTrace);
            }
        }

        public void OnWorker_Changed(TWorker worker)
        {
            if (!IsStandby && worker != null && worker.ID > 0)
            {
                SendData(worker.GetBytes());
            }
        }

        protected void OnWorker_Selected(object sender, WorkerEventArgs e)
        {
            if (e != null && e.Worker != null)
            {
                _SelectedWorkerID = e.Worker.ID;

                OnWorker_Changed(e.Worker);

                /*
                if (this.frmSupport1 != null && !this.frmSupport1.IsDisposed)
                {
                    this.frmSupport1.SelectWorkerByID(e.Worker.ID);
                }
                */
                if (this.frmSupport1_V5 != null && !this.frmSupport1_V5.IsDisposed)
                {
                    this.frmSupport1_V5.SelectWorkerByID(e.Worker.ID);
                }

                if (this.frmSupport2 != null && !this.frmSupport2.IsDisposed)
                {
                    this.frmSupport2.SelectWorkerByID(e.Worker.ID);
                }

                if (this.frmPreset != null && !this.frmPreset.IsDisposed)
                {
                    this.frmPreset.SelectWorker(e.Worker.ID);
                }
            }
        }

        private void SendData(byte[] data)
        {
            try
            {
                bool sendingState = Kvics.Communication.DriverAdapter.SendData(this._Line3, data);
                Console.WriteLine(sendingState ? "Sending successful." : "Sending fail.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sending error:");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void StoreDataAndValidate(byte[] data)
        {
            if (data == null)
            {
                return;
            }
            try
            {
                switch (data.Length)
                {
                    case 10:
                        TWorker worker = TWorker.Parse(data);

                        if (worker != null && worker.ID > 0)
                        {
                            OnWorker_Selected(this, new WorkerEventArgs(worker));
                        }
                        log.Debug("Selected worker changed. Selected worker's ID: " + worker.ID.ToString());
                        break;
                    case 184:
                        log.Info("T200 begin Parse. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                        T200 t200 = T200.Parse(data);
                        log.Info("T200 end Parse. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));

                        if (t200 != null)
                        {
                            log.Info("T200 Begin insert. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            t200.Insert();
                            log.Info("T200 End insert. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            log.Info("T200 Begin LoadGamen. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            LoadGamen(t200);
                            log.Info("T200 End LoadGamen. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            log.Info("T200 Begin Reload Screen. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            log.Info("T200 Begin Reload frmSupport1. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            if (this.frmSupport1_V5 != null && !this.frmSupport1_V5.IsDisposed)
                            {
                                this.frmSupport1_V5.LoadData(DataPackages.Finished);
                            }
                            log.Info("T200 End Reload frmSupport1. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            log.Info("T200 End Reload Screen. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            log.Debug("T200 stored. CoilNo: " + t200.R025);
                        }
                        else
                        {
                            log.Error("Data cannot be parsed from T200. Data's length: " + data.Length);
                            log.Error("Data dump:" + System.Environment.NewLine + Kvics.Utility.HexEncoding.ToString(data));
                        }
                        break;
                    case 984:
                        log.Info("T800 begin Parse. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                        T800 t800 = T800.Parse(data);
                        log.Info("T800 end Parse. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                        if (t800 != null)
                        {
                            log.Info("T800 Begin insert. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            t800.Insert();
                            log.Info("T800 End insert. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            log.Info("T800 Begin LoadGamen. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            LoadGamen(t800);
                            log.Info("T800 End LoadGamen. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            log.Info("T800 Begin Reload Screen. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            log.Info("T800 Begin Reload frmPreset. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            if (this.frmPreset != null && !this.frmPreset.IsDisposed)
                            {
                                this.frmPreset.LoadData();
                            }
                            log.Info("T800 End Reload frmPreset. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            log.Info("T800 Begin Reload frmSupport1. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            /*
                            if (this.frmSupport1 != null && !this.frmSupport1.IsDisposed)
                            {
                                this.frmSupport1.LoadData(DataPackages.FinalSet);
                            }
                            */
                            if (this.frmSupport1_V5 != null && !this.frmSupport1_V5.IsDisposed)
                            {
                                this.frmSupport1_V5.LoadData(DataPackages.FinalSet);
                            }                            
                            log.Info("T800 End Reload frmSupport1. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            log.Info("T800 Begin Reload frmSupport2. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            if (this.frmSupport2 != null && !this.frmSupport2.IsDisposed)
                            {
                                this.frmSupport2.LoadData(DataPackages.FinalSet);
                            }
                            log.Info("T800 End Reload frmSupport2. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            log.Info("T800 End Reload Screen. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            log.Debug("T800 stored. CoilNo: " + t800.R025);
                        }
                        else
                        {
                            log.Error("Data cannot be parsed from T800. Data's length: " + data.Length);
                            log.Error("Data dump:" + System.Environment.NewLine + Kvics.Utility.HexEncoding.ToString(data));
                        }
                        break;
                    case 884:
                        log.Info("T900 begin Parse. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                        T900 t900 = T900.Parse(data);
                        log.Info("T900 end Parse. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                        if (t900 != null)
                        {
                            log.Info("T900 Begin insert. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            t900.Insert();
                            log.Info("T900 End insert. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            log.Info("T900 Begin LoadGamen. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            LoadGamen(t900);
                            log.Info("T900 End LoadGamen. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            log.Info("T900 Begin Reload Screen. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            log.Info("T900 Begin Reload frmPreset. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            if (this.frmPreset != null && !this.frmPreset.IsDisposed)
                            {
                                this.frmPreset.LoadData();
                            }
                            log.Info("T900 End Reload frmPreset. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            log.Info("T900 Begin Reload frmSupport1. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            /*
                            if (this.frmSupport1 != null && !this.frmSupport1.IsDisposed)
                            {
                                this.frmSupport1.LoadData(DataPackages.Preset);
                            }
                            */
                            if (this.frmSupport1_V5 != null && !this.frmSupport1_V5.IsDisposed)
                            {
                                this.frmSupport1_V5.LoadData(DataPackages.Preset);
                            }   
                            log.Info("T900 End Reload frmSupport1. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            log.Info("T900 Begin Reload frmSupport2. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            if (this.frmSupport2 != null && !this.frmSupport2.IsDisposed)
                            {
                                this.frmSupport2.LoadData(DataPackages.Preset);
                            }
                            log.Info("T900 End Reload frmSupport2. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            log.Info("T900 End Reload Screen. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            log.Debug("T900 stored. CoilNo: " + t900.R025);
                        }
                        else
                        {
                            log.Error("Data cannot be parsed from T900. Data's length: " + data.Length);
                            log.Error("Data dump:" + System.Environment.NewLine + Kvics.Utility.HexEncoding.ToString(data));
                        }
                        break;
                    case 1784:
                        log.Info("T1800 begin Parse. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                        T1800 t1800 = null;
                        try
                        {
                            t1800 = T1800.Parse(data);
                        }
                        catch (Exception ex)
                        {
                            log.Error("T1800.Parse() error.", ex);
                            throw ex;
                        }
                        log.Info("T1800 end Parse. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                        if (t1800 != null)
                        {
                            log.Debug("t1800.Worker_ID = frmPreset.GetSelectedWorkerID(); WorkerID = " + frmPreset.GetSelectedWorkerID().ToString());
                            t1800.Worker_ID = frmPreset.GetSelectedWorkerID();
                            log.Info("T1800 Begin insert. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            t1800.Insert();
                            log.Info("T1800 End insert. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            log.Info("T1800 Begin LoadGamen. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            LoadGamen(t1800);
                            log.Info("T1800 End LoadGamen. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            log.Info("T1800 Begin Reload Screen. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            log.Info("T1800 Begin Reload frmPreset. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            if (this.frmPreset != null && !this.frmPreset.IsDisposed)
                            {
                                this.frmPreset.LoadData();
                            }
                            log.Info("T1800 End Reload frmPreset. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            log.Info("T1800 Begin Reload frmSupport1. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            /*
                            if (this.frmSupport1 != null && !this.frmSupport1.IsDisposed)
                            {
                                this.frmSupport1.LoadData(DataPackages.Result);
                            }
                            */
                            if (this.frmSupport1_V5 != null && !this.frmSupport1_V5.IsDisposed)
                            {
                                this.frmSupport1_V5.LoadData(DataPackages.Result);
                            }   
                            log.Info("T1800 End Reload frmSupport1. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            log.Info("T1800 Begin Reload frmSupport2. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            if (this.frmSupport2 != null && !this.frmSupport2.IsDisposed)
                            {
                                this.frmSupport2.LoadData(DataPackages.Result);
                            }
                            log.Info("T1800 End Reload frmSupport2. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            log.Info("T1800 End Reload Screen. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            log.Debug("T1800 stored. CoilNo: " + t1800.R0025);
                        }
                        else
                        {
                            log.Error("Data cannot be parsed from T1800. Data's length: " + data.Length);
                            log.Error("Data dump:" + System.Environment.NewLine + Kvics.Utility.HexEncoding.ToString(data));
                        }
                        break;
                    default:
                        log.Error("Data not match with any package. Data's length: " + data.Length);
                        log.Error("Data dump:" + System.Environment.NewLine + Kvics.Utility.HexEncoding.ToString(data));
                        break;
                }
            }
            //catch (System.Data.SqlClient.SqlException ex)
            //{
            //    log.Error("Error while parsing and storing.", ex);
            //    log.Error("Data dump:" + System.Environment.NewLine + Kvics.Utility.HexEncoding.ToString(data));
            //    MessageBox.Show("データベースへのデータ格納中にエラーが発生しました。管理者に通知して下さい。");
            //}
            catch (Exception ex)
            {
                log.Error("Error while parsing and storing.", ex);
                log.Error("Data dump:" + System.Environment.NewLine + Kvics.Utility.HexEncoding.ToString(data));
                MessageBox.Show("データベースへのデータ格納中にエラーが発生しました。管理者に通知して下さい。");
            }
        }

        protected delegate void PacketArrived_Callback(object sender, Kvics.Communication.PacketArrivedEventArgs obj);

        private void guidanceTabPage_Resize(object sender, EventArgs e)
        {
            /*
            int width = guidanceTabPage.Width;
            int buttonWidth = Convert.ToInt32(((guidanceTabPage.Width - _DefaultSpacing * 4) * 1.0) / 3.0);
            
            
            resultButton.Left = buttonWidth + 2 * _DefaultSpacing;
            laminateDifferentialButton.Left = buttonWidth + 2 * _DefaultSpacing;

            searchButton.Left = 2 * buttonWidth + 3 * _DefaultSpacing;
            setButton.Left = 2 * buttonWidth + 3 * _DefaultSpacing;
            
            preSetButton.Width = buttonWidth;
            finalSetButton.Width = buttonWidth;

            resultButton.Width = buttonWidth;
            laminateDifferentialButton.Width = buttonWidth;

            searchButton.Width = buttonWidth;
            setButton.Width = buttonWidth;
            */
        }
        
        private void searchButton_Click(object sender, EventArgs e)
        {
            //this.btnSearch.BackColor = this._InactiveButtonColor;
            //this.btnSearch.FlatStyle = FlatStyle.Popup;

            if (frmSearchCoil != null)
            {
                frmSearchCoil.Focus();
            }
            else
            {
                frmSearchCoil = new FormSearchCoil();
                frmSearchCoil.FormClosing += new FormClosingEventHandler(FormSearchCoilClosing);
                frmSearchCoil.OnPuPd_Press += new FormFinishSupport_KeyEventHandler(ChildForm_KeyDown);
                _SubForm.Add(frmSearchCoil);
                frmSearchCoil.Show();
            }
        }

        private void preSetButton_Click(object sender, EventArgs e)
        {
            if (frmPreset == null)
            {
                frmPreset = new FormPresetCalculator();
                frmPreset.FormClosing += new FormClosingEventHandler(FormPresetClosing);
                frmPreset.OnWorker_Selected += new Worker_EventHandler(OnWorker_Selected);
                frmPreset.OnPuPd_Press += new FormFinishSupport_KeyEventHandler(ChildForm_KeyDown);
                frmPreset.MainForm = this;

                _SubForm.Add(frmPreset);

                frmPreset.PreloadAll();

                if (_SelectedWorkerID > 0)
                {
                    frmPreset.SelectWorker(_SelectedWorkerID);
                }
            }
            else if (frmPreset.IsDisposed)
            {
                _SubForm.Remove(frmPreset);
                frmPreset = null;
                preSetButton_Click(sender, e);

                return;
            }

            if (frmPreset.LoadingOK)
            {
                frmPreset.Show();

                if (frmPreset.WindowState == FormWindowState.Minimized)
                {
                    frmPreset.WindowState = FormWindowState.Normal;
                }
                frmPreset.Focus();
            }
            else
            {
                try
                {
                    frmPreset.Dispose();
                }
                catch (Exception)
                {
                }
            }
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (this._SetPresetFocus && this.frmPreset.Visible == true)
            {
                this.frmPreset.Focus();
            }
            this._SetPresetFocus = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_RequireExit && MessageBox.Show(this, "仕上支援システムを終了しますか。", "通知", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
            else
            {
                Communication.DriverAdapter.StopDriver();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormPresetClosing(object sender, CancelEventArgs e)
        {
            //this.btnPreSet.FlatStyle = FlatStyle.Standard;
            //this.btnPreSet.BackColor = _ActiveButtonColor;
        }

        private void FormSearchCoilClosing(object sender, CancelEventArgs e)
        {
            //this.btnSearch.FlatStyle = FlatStyle.Standard;
            //this.btnSearch.BackColor = _ActiveButtonColor;

            _SubForm.Remove(frmSearchCoil);
            frmSearchCoil = null;
        }

        private void FormPressureDifferenceTotalClosing(object sender, CancelEventArgs e)
        {
            //this.btnPressureDifferenceTotal.FlatStyle = FlatStyle.Standard;
            //this.btnPressureDifferenceTotal.BackColor = _ActiveButtonColor;

            _SubForm.Remove(frmPressureDifferenceTotal);
            frmPressureDifferenceTotal = null;
        }

        private void pressureDifferenceTotalButton_Click(object sender, EventArgs e)
        {
            //this.btnPressureDifferenceTotal.BackColor = this._InactiveButtonColor;
            //this.btnPressureDifferenceTotal.FlatStyle = FlatStyle.Popup;

            if (frmPressureDifferenceTotal != null)
            {
                frmPressureDifferenceTotal.Focus();
            }
            else
            {
                frmPressureDifferenceTotal = new FormPressureDifferenceTotal();
                frmPressureDifferenceTotal.FormClosing += new FormClosingEventHandler(FormPressureDifferenceTotalClosing);
                frmPressureDifferenceTotal.OnPuPd_Press += new FormFinishSupport_KeyEventHandler(ChildForm_KeyDown);
                _SubForm.Add(frmPressureDifferenceTotal);
                frmPressureDifferenceTotal.Show();
            }
        }

        private void FormSetParameterClosing(object sender, CancelEventArgs e)
        {
            //this.btnSetParameter.FlatStyle = FlatStyle.Standard;
            //this.btnSetParameter.BackColor = _ActiveButtonColor;

            _SubForm.Remove(frmSetParameter);
            frmSetParameter = null;
        }

        private void btnSetParameter_Click(object sender, EventArgs e)
        {
            //this.btnSetParameter.BackColor = this._InactiveButtonColor;
            //this.btnSetParameter.FlatStyle = FlatStyle.Popup;

            if (frmSetParameter != null)
            {
                frmSetParameter.Focus();
            }
            else
            {
                frmSetParameter = new FormSetParameter();
                frmSetParameter.FormClosing += new FormClosingEventHandler(FormSetParameterClosing);
                frmSetParameter.OnPuPd_Press += new FormFinishSupport_KeyEventHandler(ChildForm_KeyDown);
                _SubForm.Add(frmSetParameter);
                frmSetParameter.Show();
            }
        }

        private void btnDatabaseConfig_Click(object sender, EventArgs e)
        {
            if (!CloseAllChildsWithConfirm())
            {
                return;
            }

            string currentConnectionString = Kvics.DBAccess.DBAccessor.DefaultConnectionString;

            FormDatabaseConfig frm = new FormDatabaseConfig();
            frm.HotMillDatabaseConnectionString = Kvics.DBAccess.DBAccessor.DefaultConnectionString;
            while (frm.ShowDialog() == DialogResult.OK)
            {
                Kvics.DBAccess.DBAccessor.DefaultConnectionString = frm.HotMillDatabaseConnectionString;

                if (ValidateDatabaseConnection())
                {
                    FormDatabaseConfig.ApplyConnectionString(frm.HotMillDatabaseConnectionString);
                    return;
                }
            }

            Kvics.DBAccess.DBAccessor.DefaultConnectionString = currentConnectionString;
        }

        public static void ShowError(HotMillErrorType errorType)
        {
            switch (errorType)
            {
                case HotMillErrorType.DATABASE_ERROR:
                    MessageBox.Show("データベースに接続出来ません。若しくはデータベースは異常です。データベース又はデータベース構成を確認して下さい。");
                    break;
                case HotMillErrorType.UNKNOWN_ERROR:
                    MessageBox.Show("データベースからのデータ取得中にエラーが発生しました。管理者に通知して下さい。");
                    break;
                default:
                    break;
            }
        }

        private void btnWorker_Click(object sender, EventArgs e)
        {
            if (frmWorker != null)
            {
                frmWorker.Focus();
            }
            else
            {
                frmWorker = new FormWorker();
                frmWorker.FormClosing += new FormClosingEventHandler(FormWorkerClosing);
                frmWorker.OnWorker_Changed += new EventHandler(OnWorkers_Changed);
                frmWorker.OnPuPd_Press += new FormFinishSupport_KeyEventHandler(ChildForm_KeyDown);
                _SubForm.Add(frmWorker);
                frmWorker.Show();
            }
        }

        private void FormWorkerClosing(object sender, CancelEventArgs e)
        {
            //this.btnSetParameter.FlatStyle = FlatStyle.Standard;
            //this.btnSetParameter.BackColor = _ActiveButtonColor;

            _SubForm.Remove(frmWorker);
            frmWorker = null;
        }

        private void btnDriverConfig_Click(object sender, EventArgs e)
        {

        }

        private void btnFinishSupport1_Click(object sender, EventArgs e)
        {
            if (frmSupport1_V5 != null)
            {
                frmSupport1_V5.WindowState = FormWindowState.Normal;
                frmSupport1_V5.Focus();
            }
            else
            {
                frmSupport1_V5 = new FormFinishSupport1_V5();
                frmSupport1_V5.FormClosing += new FormClosingEventHandler(FormFinishSupport1Closing);
                frmSupport1_V5.OnWorker_Selected += new Worker_EventHandler(OnWorker_Selected);
                //frmSupport1_V4.OnSimulation_Calculate1 += new SimulationCalculate_EventHandler(SimulationCalculate1);
                //frmSupport1_V4.OnSimulation_Calculate2 += new SimulationCalculate_EventHandler(SimulationCalculate2);
                //frmSupport1_V4.OnSimulation_Clear += new SimulationCalculate_EventHandler(SimulationClear);
                frmSupport1_V5.OnPuPd_Press += new FormFinishSupport_KeyEventHandler(ChildForm_KeyDown);
                frmSupport1_V5.SelectedWorkerID = _SelectedWorkerID;

                _SubForm.Add(frmSupport1_V5);

                frmSupport1_V5.Show();

                //FormFinishSupport1 frm = new FormFinishSupport1();
                //frm.Show();
            }
            /*
            if (frmSupport1 != null)
            {
                frmSupport1.WindowState = FormWindowState.Normal;
                frmSupport1.Focus();
            }
            else
            {
                frmSupport1 = new FormFinishSupport1();
                frmSupport1.FormClosing += new FormClosingEventHandler(FormFinishSupport1Closing);
                frmSupport1.OnWorker_Selected += new Worker_EventHandler(OnWorker_Selected);
                frmSupport1.OnSimulation_Calculate1 += new SimulationCalculate_EventHandler(SimulationCalculate1);
                frmSupport1.OnSimulation_Calculate2 += new SimulationCalculate_EventHandler(SimulationCalculate2);
                frmSupport1.OnSimulation_Clear += new SimulationCalculate_EventHandler(SimulationClear);
                frmSupport1.OnPuPd_Press += new FormFinishSupport_KeyEventHandler(ChildForm_KeyDown);
                frmSupport1.SelectedWorkerID = _SelectedWorkerID;

                _SubForm.Add(frmSupport1);

                frmSupport1.Show();
            }
            */
        }

        private void FormFinishSupport1Closing(object sender, CancelEventArgs e)
        {
            /*
            _SubForm.Remove(frmSupport1);
            frmSupport1 = null;
            */
            _SubForm.Remove(frmSupport1_V5);
            frmSupport1_V5 = null;
        }

        private void btnFinishSupport2_Click(object sender, EventArgs e)
        {
            if (frmSupport2 != null)
            {
                frmSupport2.WindowState = FormWindowState.Normal;
                frmSupport2.Focus();
            }
            else
            {
                frmSupport2 = new FormFinishSupport2();
                frmSupport2.FormClosing += new FormClosingEventHandler(FormFinishSupport2Closing);
                frmSupport2.OnWorker_Selected += new Worker_EventHandler(OnWorker_Selected);
                frmSupport2.OnPuPd_Press += new FormFinishSupport_KeyEventHandler(ChildForm_KeyDown);
                frmSupport2.SelectedWorkerID = _SelectedWorkerID;
                
                _SubForm.Add(frmSupport2);
                
                frmSupport2.Show();
            }
        }

        private void FormFinishSupport2Closing(object sender, CancelEventArgs e)
        {
            _SubForm.Remove(frmSupport2);
            frmSupport2 = null;
        }

        private void OnWorkers_Changed(object sender, EventArgs e)
        {
            if (frmPreset == null)
            {
                preSetButton_Click(null, null);
            }
            frmPreset.PreloadAll();
        }

        private DataTable PrepareCSVData(T900 t900)
        {
            if (t900 == null)
            {
                return null;
            }
            DataTable tb = new DataTable();
            tb.Columns.Add("Data");

            tb.Rows.Add(t900.R025);
            tb.Rows.Add(t900.R033 % 100);
            tb.Rows.Add(t900.R035);
            tb.Rows.Add(t900.R037);
            tb.Rows.Add(t900.R039);
            tb.Rows.Add(t900.R041);
            tb.Rows.Add(t900.R043_1);
            tb.Rows.Add(t900.R053);
            tb.Rows.Add(t900.R059);
            tb.Rows.Add(t900.R061);
            tb.Rows.Add(t900.R063);
            tb.Rows.Add(t900.R065);
            tb.Rows.Add(t900.R067);
            tb.Rows.Add(t900.R069);
            tb.Rows.Add(t900.R071);
            tb.Rows.Add(t900.R079);
            tb.Rows.Add(t900.R081.R01);
            tb.Rows.Add(t900.R081.R02);
            tb.Rows.Add(t900.R081.R03);
            tb.Rows.Add(t900.R081.R04);
            tb.Rows.Add(t900.R081.R05);
            tb.Rows.Add(t900.R081.R06);
            tb.Rows.Add(t900.R081.R07);
            tb.Rows.Add(t900.R081.R08);
            tb.Rows.Add(t900.R081.R09);
            tb.Rows.Add(t900.R081.R10);
            tb.Rows.Add(t900.R081.R11);
            tb.Rows.Add(t900.R081.R12);
            tb.Rows.Add(t900.R081.R13);
            tb.Rows.Add(t900.R081.R14);
            tb.Rows.Add(t900.R081.R15);
            tb.Rows.Add(t900.R081.R16);
            tb.Rows.Add(t900.R081.R17);
            tb.Rows.Add(t900.R081.R18);
            tb.Rows.Add(t900.R081.R19);
            tb.Rows.Add(t900.R119);
            tb.Rows.Add(t900.R121);
            tb.Rows.Add(t900.R123);
            tb.Rows.Add(t900.R125);
            tb.Rows.Add(t900.R127);
            tb.Rows.Add(t900.R129);
            tb.Rows.Add(t900.R131.F1);
            tb.Rows.Add(t900.R131.F2);
            tb.Rows.Add(t900.R131.F3);
            tb.Rows.Add(t900.R131.F4);
            tb.Rows.Add(t900.R131.F5);
            tb.Rows.Add(t900.R131.F6);
            tb.Rows.Add(t900.R131.F7);
            tb.Rows.Add(t900.R145.F1);
            tb.Rows.Add(t900.R145.F2);
            tb.Rows.Add(t900.R145.F3);
            tb.Rows.Add(t900.R145.F4);
            tb.Rows.Add(t900.R145.F5);
            tb.Rows.Add(t900.R145.F6);
            tb.Rows.Add(t900.R145.F7);
            tb.Rows.Add(t900.R159);
            tb.Rows.Add(t900.R161);
            tb.Rows.Add(t900.R163);
            tb.Rows.Add(t900.R165);
            tb.Rows.Add(t900.R167);
            tb.Rows.Add(t900.R169.F1);
            tb.Rows.Add(t900.R169.F2);
            tb.Rows.Add(t900.R169.F3);
            tb.Rows.Add(t900.R169.F4);
            tb.Rows.Add(t900.R169.F5);
            tb.Rows.Add(t900.R169.F6);
            tb.Rows.Add(t900.R169.F7);
            tb.Rows.Add(t900.R183.F1);
            tb.Rows.Add(t900.R183.F2);
            tb.Rows.Add(t900.R183.F3);
            tb.Rows.Add(t900.R183.F4);
            tb.Rows.Add(t900.R183.F5);
            tb.Rows.Add(t900.R183.F6);
            tb.Rows.Add(t900.R183.F7);
            tb.Rows.Add(t900.R197.F1);
            tb.Rows.Add(t900.R197.F2);
            tb.Rows.Add(t900.R197.F3);
            tb.Rows.Add(t900.R197.F4);
            tb.Rows.Add(t900.R197.F5);
            tb.Rows.Add(t900.R197.F6);
            tb.Rows.Add(t900.R197.F7);
            tb.Rows.Add(t900.R211);
            tb.Rows.Add(t900.R213.F1);
            tb.Rows.Add(t900.R213.F2);
            tb.Rows.Add(t900.R213.F3);
            tb.Rows.Add(t900.R213.F4);
            tb.Rows.Add(t900.R213.F5);
            tb.Rows.Add(t900.R213.F6);
            tb.Rows.Add(t900.R213.F7);
            tb.Rows.Add(t900.R227.F1);
            tb.Rows.Add(t900.R227.F2);
            tb.Rows.Add(t900.R227.F3);
            tb.Rows.Add(t900.R227.F4);
            tb.Rows.Add(t900.R227.F5);
            tb.Rows.Add(t900.R227.F6);
            tb.Rows.Add(t900.R227.F7);
            tb.Rows.Add(t900.R241.F1);
            tb.Rows.Add(t900.R241.F2);
            tb.Rows.Add(t900.R241.F3);
            tb.Rows.Add(t900.R241.F4);
            tb.Rows.Add(t900.R241.F5);
            tb.Rows.Add(t900.R241.F6);
            tb.Rows.Add(t900.R241.F7);
            tb.Rows.Add(t900.R255.F1);
            tb.Rows.Add(t900.R255.F2);
            tb.Rows.Add(t900.R255.F3);
            tb.Rows.Add(t900.R255.F4);
            tb.Rows.Add(t900.R255.F5);
            tb.Rows.Add(t900.R255.F6);
            tb.Rows.Add(t900.R255.F7);
            tb.Rows.Add(t900.R269.F1);
            tb.Rows.Add(t900.R269.F2);
            tb.Rows.Add(t900.R269.F3);
            tb.Rows.Add(t900.R269.F4);
            tb.Rows.Add(t900.R269.F5);
            tb.Rows.Add(t900.R269.F6);
            tb.Rows.Add(t900.R269.F7);
            tb.Rows.Add(t900.R283.F1);
            tb.Rows.Add(t900.R283.F2);
            tb.Rows.Add(t900.R283.F3);
            tb.Rows.Add(t900.R283.F4);
            tb.Rows.Add(t900.R283.F5);
            tb.Rows.Add(t900.R283.F6);
            tb.Rows.Add(t900.R283.F7);
            tb.Rows.Add(t900.R297.F1);
            tb.Rows.Add(t900.R297.F2);
            tb.Rows.Add(t900.R297.F3);
            tb.Rows.Add(t900.R297.F4);
            tb.Rows.Add(t900.R297.F5);
            tb.Rows.Add(t900.R297.F6);
            tb.Rows.Add(t900.R297.F7);
            tb.Rows.Add(t900.R311.F1);
            tb.Rows.Add(t900.R311.F2);
            tb.Rows.Add(t900.R311.F3);
            tb.Rows.Add(t900.R311.F4);
            tb.Rows.Add(t900.R311.F5);
            tb.Rows.Add(t900.R311.F6);
            tb.Rows.Add(t900.R311.F7);
            tb.Rows.Add(t900.R325.F1);
            tb.Rows.Add(t900.R325.F2);
            tb.Rows.Add(t900.R325.F3);
            tb.Rows.Add(t900.R325.F4);
            tb.Rows.Add(t900.R325.F5);
            tb.Rows.Add(t900.R325.F6);
            tb.Rows.Add(t900.R325.F7);
            tb.Rows.Add(t900.R339.F1);
            tb.Rows.Add(t900.R339.F2);
            tb.Rows.Add(t900.R339.F3);
            tb.Rows.Add(t900.R339.F4);
            tb.Rows.Add(t900.R339.F5);
            tb.Rows.Add(t900.R339.F6);
            tb.Rows.Add(t900.R339.F7);
            tb.Rows.Add(t900.R353.F1);
            tb.Rows.Add(t900.R353.F2);
            tb.Rows.Add(t900.R353.F3);
            tb.Rows.Add(t900.R353.F4);
            tb.Rows.Add(t900.R353.F5);
            tb.Rows.Add(t900.R353.F6);
            tb.Rows.Add(t900.R353.F7);
            tb.Rows.Add(t900.R367.R1);
            tb.Rows.Add(t900.R367.R2);
            tb.Rows.Add(t900.R367.R3);
            tb.Rows.Add(t900.R367.R4);
            tb.Rows.Add(t900.R367.R5);
            tb.Rows.Add(t900.R367.R6);
            tb.Rows.Add(t900.R379.R1);
            tb.Rows.Add(t900.R379.R2);
            tb.Rows.Add(t900.R379.R3);
            tb.Rows.Add(t900.R379.R4);
            tb.Rows.Add(t900.R379.R5);
            tb.Rows.Add(t900.R379.R6);
            tb.Rows.Add(t900.R391.F1);
            tb.Rows.Add(t900.R391.F2);
            tb.Rows.Add(t900.R391.F3);
            tb.Rows.Add(t900.R391.F4);
            tb.Rows.Add(t900.R391.F5);
            tb.Rows.Add(t900.R391.F6);
            tb.Rows.Add(t900.R391.F7);
            tb.Rows.Add(t900.R801.F1);
            tb.Rows.Add(t900.R801.F2);
            tb.Rows.Add(t900.R801.F3);
            tb.Rows.Add(t900.R801.F4);
            tb.Rows.Add(t900.R801.F5);
            tb.Rows.Add(t900.R801.F6);
            tb.Rows.Add(t900.R801.F7);
            tb.Rows.Add(t900.R815.F1);
            tb.Rows.Add(t900.R815.F2);
            tb.Rows.Add(t900.R815.F3);
            tb.Rows.Add(t900.R815.F4);
            tb.Rows.Add(t900.R815.F5);
            tb.Rows.Add(t900.R815.F6);
            tb.Rows.Add(t900.R815.F7);
            tb.Rows.Add(t900.R405.F1);
            tb.Rows.Add(t900.R405.F2);
            tb.Rows.Add(t900.R405.F3);
            tb.Rows.Add(t900.R405.F4);
            tb.Rows.Add(t900.R405.F5);
            tb.Rows.Add(t900.R405.F6);
            tb.Rows.Add(t900.R405.F7);
            tb.Rows.Add(t900.R851.F1);
            tb.Rows.Add(t900.R851.F2);
            tb.Rows.Add(t900.R851.F3);
            tb.Rows.Add(t900.R851.F4);
            tb.Rows.Add(t900.R851.F5);
            tb.Rows.Add(t900.R851.F6);
            tb.Rows.Add(t900.R851.F7);
            tb.Rows.Add(t900.R419.F1);
            tb.Rows.Add(t900.R419.F2);
            tb.Rows.Add(t900.R419.F3);
            tb.Rows.Add(t900.R419.F4);
            tb.Rows.Add(t900.R419.F5);
            tb.Rows.Add(t900.R419.F6);
            tb.Rows.Add(t900.R419.F7);
            tb.Rows.Add(t900.R433.F1);
            tb.Rows.Add(t900.R433.F2);
            tb.Rows.Add(t900.R433.F3);
            tb.Rows.Add(t900.R433.F4);
            tb.Rows.Add(t900.R433.F5);
            tb.Rows.Add(t900.R433.F6);
            tb.Rows.Add(t900.R433.F7);
            tb.Rows.Add(t900.R447.F1);
            tb.Rows.Add(t900.R447.F2);
            tb.Rows.Add(t900.R447.F3);
            tb.Rows.Add(t900.R447.F4);
            tb.Rows.Add(t900.R447.F5);
            tb.Rows.Add(t900.R447.F6);
            tb.Rows.Add(t900.R447.F7);
            tb.Rows.Add(t900.R501.F1);
            tb.Rows.Add(t900.R501.F2);
            tb.Rows.Add(t900.R501.F3);
            tb.Rows.Add(t900.R501.F4);
            tb.Rows.Add(t900.R501.F5);
            tb.Rows.Add(t900.R501.F6);
            tb.Rows.Add(t900.R501.F7);
            tb.Rows.Add(t900.R543.F1);
            tb.Rows.Add(t900.R543.F2);
            tb.Rows.Add(t900.R543.F3);
            tb.Rows.Add(t900.R543.F4);
            tb.Rows.Add(t900.R543.F5);
            tb.Rows.Add(t900.R543.F6);
            tb.Rows.Add(t900.R543.F7);
            tb.Rows.Add(t900.R557.F1);
            tb.Rows.Add(t900.R557.F2);
            tb.Rows.Add(t900.R557.F3);
            tb.Rows.Add(t900.R557.F4);
            tb.Rows.Add(t900.R557.F5);
            tb.Rows.Add(t900.R557.F6);
            tb.Rows.Add(t900.R557.F7);
            tb.Rows.Add(t900.R585.F1);
            tb.Rows.Add(t900.R585.F2);
            tb.Rows.Add(t900.R585.F3);
            tb.Rows.Add(t900.R585.F4);
            tb.Rows.Add(t900.R585.F5);
            tb.Rows.Add(t900.R585.F6);
            tb.Rows.Add(t900.R585.F7);
            tb.Rows.Add(t900.R599.F1);
            tb.Rows.Add(t900.R599.F2);
            tb.Rows.Add(t900.R599.F3);
            tb.Rows.Add(t900.R599.F4);
            tb.Rows.Add(t900.R599.F5);
            tb.Rows.Add(t900.R599.F6);
            tb.Rows.Add(t900.R599.F7);
            tb.Rows.Add(t900.R613.F1);
            tb.Rows.Add(t900.R613.F2);
            tb.Rows.Add(t900.R613.F3);
            tb.Rows.Add(t900.R613.F4);
            tb.Rows.Add(t900.R613.F5);
            tb.Rows.Add(t900.R613.F6);
            tb.Rows.Add(t900.R613.F7);
            tb.Rows.Add(t900.R627.F1_1);
            tb.Rows.Add(t900.R627.F1_2);
            tb.Rows.Add(t900.R627.F2_1);
            tb.Rows.Add(t900.R627.F2_2);
            tb.Rows.Add(t900.R627.F3_1);
            tb.Rows.Add(t900.R627.F3_2);
            tb.Rows.Add(t900.R627.F4_1);
            tb.Rows.Add(t900.R627.F4_2);
            tb.Rows.Add(t900.R627.F5_1);
            tb.Rows.Add(t900.R627.F5_2);
            tb.Rows.Add(t900.R627.F6_1);
            tb.Rows.Add(t900.R627.F6_2);
            tb.Rows.Add(t900.R627.F7_1);
            tb.Rows.Add(t900.R627.F7_2);
            tb.Rows.Add(t900.R713.F1_1);
            tb.Rows.Add(t900.R713.F1_2);
            tb.Rows.Add(t900.R713.F2_1);
            tb.Rows.Add(t900.R713.F2_2);
            tb.Rows.Add(t900.R713.F3_1);
            tb.Rows.Add(t900.R713.F3_2);
            tb.Rows.Add(t900.R713.F4_1);
            tb.Rows.Add(t900.R713.F4_2);
            tb.Rows.Add(t900.R713.F5_1);
            tb.Rows.Add(t900.R713.F5_2);
            tb.Rows.Add(t900.R713.F6_1);
            tb.Rows.Add(t900.R713.F6_2);
            tb.Rows.Add(t900.R713.F7_1);
            tb.Rows.Add(t900.R713.F7_2);

            return tb;
        }

        private DataTable PrepareSimulation1CSVData(T900 t900)
        {
            if (t900 == null)
            {
                return null;
            }
            DataTable tb = new DataTable();
            tb.Columns.Add("Data");

            tb.Rows.Add(t900.R025);
            tb.Rows.Add("1");
            tb.Rows.Add(t900.R367.R1);
            tb.Rows.Add(t900.R367.R2);
            tb.Rows.Add(t900.R367.R3);
            tb.Rows.Add(t900.R367.R4);
            tb.Rows.Add(t900.R367.R5);
            tb.Rows.Add(t900.R367.R6);

            tb.Rows.Add(t900.R227.F1);
            tb.Rows.Add(t900.R227.F2);
            tb.Rows.Add(t900.R227.F3);
            tb.Rows.Add(t900.R227.F4);
            tb.Rows.Add(t900.R227.F5);
            tb.Rows.Add(t900.R227.F6);
            tb.Rows.Add(t900.R227.F7);

            return tb;
        }

        private DataTable PrepareSimulation2CSVData(T900 t900)
        {
            if (t900 == null)
            {
                return null;
            }
            DataTable tb = new DataTable();
            tb.Columns.Add("Data");

            tb.Rows.Add(t900.R025);
            tb.Rows.Add("2");
            tb.Rows.Add(t900.R367.R1);
            tb.Rows.Add(t900.R367.R2);
            tb.Rows.Add(t900.R367.R3);
            tb.Rows.Add(t900.R367.R4);
            tb.Rows.Add(t900.R367.R5);
            tb.Rows.Add(t900.R367.R6);

            tb.Rows.Add(t900.R227.F1);
            tb.Rows.Add(t900.R227.F2);
            tb.Rows.Add(t900.R227.F3);
            tb.Rows.Add(t900.R227.F4);
            tb.Rows.Add(t900.R227.F5);
            tb.Rows.Add(t900.R227.F6);
            tb.Rows.Add(t900.R227.F7);

            return tb;
        }

        private DataTable PrepareCSVData(T800 t800)
        {
            if (t800 == null)
            {
                return null;
            }
            DataTable tb = new DataTable();
            tb.Columns.Add("Data");

            tb.Rows.Add(t800.R025);
            tb.Rows.Add(t800.R033 % 100);
            tb.Rows.Add(t800.R035);
            tb.Rows.Add(t800.R037);
            tb.Rows.Add(t800.R039);
            tb.Rows.Add(t800.R041);
            tb.Rows.Add(t800.R043_1);
            tb.Rows.Add(t800.R053);
            tb.Rows.Add(t800.R059);
            tb.Rows.Add(t800.R061);
            tb.Rows.Add(t800.R063);
            tb.Rows.Add(t800.R065);
            tb.Rows.Add(t800.R067);
            tb.Rows.Add(t800.R069);
            tb.Rows.Add(t800.R071);
            tb.Rows.Add(t800.R073_1);
            tb.Rows.Add(t800.R075);
            tb.Rows.Add(t800.R077);
            tb.Rows.Add(t800.R079);
            tb.Rows.Add(t800.R081_1);
            tb.Rows.Add(t800.R083.F1);
            tb.Rows.Add(t800.R083.F2);
            tb.Rows.Add(t800.R083.F3);
            tb.Rows.Add(t800.R083.F4);
            tb.Rows.Add(t800.R083.F5);
            tb.Rows.Add(t800.R083.F6);
            tb.Rows.Add(t800.R083.F7);
            tb.Rows.Add(t800.R097.F1);
            tb.Rows.Add(t800.R097.F2);
            tb.Rows.Add(t800.R097.F3);
            tb.Rows.Add(t800.R097.F4);
            tb.Rows.Add(t800.R097.F5);
            tb.Rows.Add(t800.R097.F6);
            tb.Rows.Add(t800.R097.F7);
            tb.Rows.Add(t800.R111);
            tb.Rows.Add(t800.R113);
            tb.Rows.Add(t800.R115);
            tb.Rows.Add(t800.R117);
            tb.Rows.Add(t800.R119);
            tb.Rows.Add(t800.R121.F1);
            tb.Rows.Add(t800.R121.F2);
            tb.Rows.Add(t800.R121.F3);
            tb.Rows.Add(t800.R121.F4);
            tb.Rows.Add(t800.R121.F5);
            tb.Rows.Add(t800.R121.F6);
            tb.Rows.Add(t800.R121.F7);

            tb.Rows.Add(t800.R135.F1);
            tb.Rows.Add(t800.R135.F2);
            tb.Rows.Add(t800.R135.F3);
            tb.Rows.Add(t800.R135.F4);
            tb.Rows.Add(t800.R135.F5);
            tb.Rows.Add(t800.R135.F6);
            tb.Rows.Add(t800.R135.F7);

            tb.Rows.Add(t800.R149.F1);
            tb.Rows.Add(t800.R149.F2);
            tb.Rows.Add(t800.R149.F3);
            tb.Rows.Add(t800.R149.F4);
            tb.Rows.Add(t800.R149.F5);
            tb.Rows.Add(t800.R149.F6);
            tb.Rows.Add(t800.R149.F7);

            tb.Rows.Add(t800.R163);
            
            tb.Rows.Add(t800.R165.F1);
            tb.Rows.Add(t800.R165.F2);
            tb.Rows.Add(t800.R165.F3);
            tb.Rows.Add(t800.R165.F4);
            tb.Rows.Add(t800.R165.F5);
            tb.Rows.Add(t800.R165.F6);
            tb.Rows.Add(t800.R165.F7);

            tb.Rows.Add(t800.R179.F1);
            tb.Rows.Add(t800.R179.F2);
            tb.Rows.Add(t800.R179.F3);
            tb.Rows.Add(t800.R179.F4);
            tb.Rows.Add(t800.R179.F5);
            tb.Rows.Add(t800.R179.F6);
            tb.Rows.Add(t800.R179.F7);

            tb.Rows.Add(t800.R193.F1);
            tb.Rows.Add(t800.R193.F2);
            tb.Rows.Add(t800.R193.F3);
            tb.Rows.Add(t800.R193.F4);
            tb.Rows.Add(t800.R193.F5);
            tb.Rows.Add(t800.R193.F6);
            tb.Rows.Add(t800.R193.F7);

            tb.Rows.Add(t800.R207.F1);
            tb.Rows.Add(t800.R207.F2);
            tb.Rows.Add(t800.R207.F3);
            tb.Rows.Add(t800.R207.F4);
            tb.Rows.Add(t800.R207.F5);
            tb.Rows.Add(t800.R207.F6);
            tb.Rows.Add(t800.R207.F7);

            tb.Rows.Add(t800.R221.F1);
            tb.Rows.Add(t800.R221.F2);
            tb.Rows.Add(t800.R221.F3);
            tb.Rows.Add(t800.R221.F4);
            tb.Rows.Add(t800.R221.F5);
            tb.Rows.Add(t800.R221.F6);
            tb.Rows.Add(t800.R221.F7);

            tb.Rows.Add(t800.R235.F1);
            tb.Rows.Add(t800.R235.F2);
            tb.Rows.Add(t800.R235.F3);
            tb.Rows.Add(t800.R235.F4);
            tb.Rows.Add(t800.R235.F5);
            tb.Rows.Add(t800.R235.F6);
            tb.Rows.Add(t800.R235.F7);

            tb.Rows.Add(t800.R249.F1);
            tb.Rows.Add(t800.R249.F2);
            tb.Rows.Add(t800.R249.F3);
            tb.Rows.Add(t800.R249.F4);
            tb.Rows.Add(t800.R249.F5);
            tb.Rows.Add(t800.R249.F6);
            tb.Rows.Add(t800.R249.F7);

            tb.Rows.Add(t800.R263.F1);
            tb.Rows.Add(t800.R263.F2);
            tb.Rows.Add(t800.R263.F3);
            tb.Rows.Add(t800.R263.F4);
            tb.Rows.Add(t800.R263.F5);
            tb.Rows.Add(t800.R263.F6);
            tb.Rows.Add(t800.R263.F7);

            tb.Rows.Add(t800.R277.F1);
            tb.Rows.Add(t800.R277.F2);
            tb.Rows.Add(t800.R277.F3);
            tb.Rows.Add(t800.R277.F4);
            tb.Rows.Add(t800.R277.F5);
            tb.Rows.Add(t800.R277.F6);
            tb.Rows.Add(t800.R277.F7);

            tb.Rows.Add(t800.R291.F1);
            tb.Rows.Add(t800.R291.F2);
            tb.Rows.Add(t800.R291.F3);
            tb.Rows.Add(t800.R291.F4);
            tb.Rows.Add(t800.R291.F5);
            tb.Rows.Add(t800.R291.F6);
            tb.Rows.Add(t800.R291.F7);

            tb.Rows.Add(t800.R305.F1);
            tb.Rows.Add(t800.R305.F2);
            tb.Rows.Add(t800.R305.F3);
            tb.Rows.Add(t800.R305.F4);
            tb.Rows.Add(t800.R305.F5);
            tb.Rows.Add(t800.R305.F6);
            tb.Rows.Add(t800.R305.F7);

            tb.Rows.Add(t800.R319.R1);
            tb.Rows.Add(t800.R319.R2);
            tb.Rows.Add(t800.R319.R3);
            tb.Rows.Add(t800.R319.R4);
            tb.Rows.Add(t800.R319.R5);
            tb.Rows.Add(t800.R319.R6);

            tb.Rows.Add(t800.R331.R1);
            tb.Rows.Add(t800.R331.R2);
            tb.Rows.Add(t800.R331.R3);
            tb.Rows.Add(t800.R331.R4);
            tb.Rows.Add(t800.R331.R5);
            tb.Rows.Add(t800.R331.R6);

            tb.Rows.Add(t800.R343.F1);
            tb.Rows.Add(t800.R343.F2);
            tb.Rows.Add(t800.R343.F3);
            tb.Rows.Add(t800.R343.F4);
            tb.Rows.Add(t800.R343.F5);
            tb.Rows.Add(t800.R343.F6);
            tb.Rows.Add(t800.R343.F7);

            tb.Rows.Add(t800.R357.F1);
            tb.Rows.Add(t800.R357.F2);
            tb.Rows.Add(t800.R357.F3);
            tb.Rows.Add(t800.R357.F4);
            tb.Rows.Add(t800.R357.F5);
            tb.Rows.Add(t800.R357.F6);
            tb.Rows.Add(t800.R357.F7);

            tb.Rows.Add(t800.R371.F1);
            tb.Rows.Add(t800.R371.F2);
            tb.Rows.Add(t800.R371.F3);
            tb.Rows.Add(t800.R371.F4);
            tb.Rows.Add(t800.R371.F5);
            tb.Rows.Add(t800.R371.F6);
            tb.Rows.Add(t800.R371.F7);

            tb.Rows.Add(t800.R385.F1);
            tb.Rows.Add(t800.R385.F2);
            tb.Rows.Add(t800.R385.F3);
            tb.Rows.Add(t800.R385.F4);
            tb.Rows.Add(t800.R385.F5);
            tb.Rows.Add(t800.R385.F6);
            tb.Rows.Add(t800.R385.F7);

            tb.Rows.Add(t800.R399.F1);
            tb.Rows.Add(t800.R399.F2);
            tb.Rows.Add(t800.R399.F3);
            tb.Rows.Add(t800.R399.F4);
            tb.Rows.Add(t800.R399.F5);
            tb.Rows.Add(t800.R399.F6);
            tb.Rows.Add(t800.R399.F7);

            tb.Rows.Add(t800.R413.F1);
            tb.Rows.Add(t800.R413.F2);
            tb.Rows.Add(t800.R413.F3);
            tb.Rows.Add(t800.R413.F4);
            tb.Rows.Add(t800.R413.F5);
            tb.Rows.Add(t800.R413.F6);
            tb.Rows.Add(t800.R413.F7);

            tb.Rows.Add(t800.R427.R1);
            tb.Rows.Add(t800.R427.R2);
            tb.Rows.Add(t800.R427.R3);
            tb.Rows.Add(t800.R427.R4);
            tb.Rows.Add(t800.R427.R5);
            tb.Rows.Add(t800.R427.R6);

            tb.Rows.Add(t800.R701_1);

            tb.Rows.Add(t800.R703.F1);
            tb.Rows.Add(t800.R703.F2);
            tb.Rows.Add(t800.R703.F3);
            tb.Rows.Add(t800.R703.F4);
            tb.Rows.Add(t800.R703.F5);
            tb.Rows.Add(t800.R703.F6);
            tb.Rows.Add(t800.R703.F7);

            tb.Rows.Add(t800.R501.R01);
            tb.Rows.Add(t800.R501.R02);
            tb.Rows.Add(t800.R501.R03);
            tb.Rows.Add(t800.R501.R04);
            tb.Rows.Add(t800.R501.R05);
            tb.Rows.Add(t800.R501.R06);
            tb.Rows.Add(t800.R501.R07);
            tb.Rows.Add(t800.R501.R08);
            tb.Rows.Add(t800.R501.R09);
            tb.Rows.Add(t800.R501.R10);

            tb.Rows.Add(t800.R521.R01);
            tb.Rows.Add(t800.R521.R02);
            tb.Rows.Add(t800.R521.R03);
            tb.Rows.Add(t800.R521.R04);
            tb.Rows.Add(t800.R521.R05);
            tb.Rows.Add(t800.R521.R06);
            tb.Rows.Add(t800.R521.R07);
            tb.Rows.Add(t800.R521.R08);
            tb.Rows.Add(t800.R521.R09);
            tb.Rows.Add(t800.R521.R10);

            tb.Rows.Add(t800.R541.R01);
            tb.Rows.Add(t800.R541.R02);
            tb.Rows.Add(t800.R541.R03);
            tb.Rows.Add(t800.R541.R04);
            tb.Rows.Add(t800.R541.R05);
            tb.Rows.Add(t800.R541.R06);
            tb.Rows.Add(t800.R541.R07);
            tb.Rows.Add(t800.R541.R08);
            tb.Rows.Add(t800.R541.R09);
            tb.Rows.Add(t800.R541.R10);

            tb.Rows.Add(t800.R561.F1);
            tb.Rows.Add(t800.R561.F2);
            tb.Rows.Add(t800.R561.F3);
            tb.Rows.Add(t800.R561.F4);
            tb.Rows.Add(t800.R561.F5);
            tb.Rows.Add(t800.R561.F6);
            tb.Rows.Add(t800.R561.F7);

            tb.Rows.Add(t800.R575.F1);
            tb.Rows.Add(t800.R575.F2);
            tb.Rows.Add(t800.R575.F3);
            tb.Rows.Add(t800.R575.F4);
            tb.Rows.Add(t800.R575.F5);
            tb.Rows.Add(t800.R575.F6);
            tb.Rows.Add(t800.R575.F7);

            tb.Rows.Add(t800.R589.F1);
            tb.Rows.Add(t800.R589.F2);
            tb.Rows.Add(t800.R589.F3);
            tb.Rows.Add(t800.R589.F4);
            tb.Rows.Add(t800.R589.F5);
            tb.Rows.Add(t800.R589.F6);
            tb.Rows.Add(t800.R589.F7);

            tb.Rows.Add(t800.R603.F1);
            tb.Rows.Add(t800.R603.F2);
            tb.Rows.Add(t800.R603.F3);
            tb.Rows.Add(t800.R603.F4);
            tb.Rows.Add(t800.R603.F5);
            tb.Rows.Add(t800.R603.F6);
            tb.Rows.Add(t800.R603.F7);

            tb.Rows.Add(t800.R617.F1);
            tb.Rows.Add(t800.R617.F2);
            tb.Rows.Add(t800.R617.F3);
            tb.Rows.Add(t800.R617.F4);
            tb.Rows.Add(t800.R617.F5);
            tb.Rows.Add(t800.R617.F6);
            tb.Rows.Add(t800.R617.F7);

            tb.Rows.Add(t800.R631.F1);
            tb.Rows.Add(t800.R631.F2);
            tb.Rows.Add(t800.R631.F3);
            tb.Rows.Add(t800.R631.F4);
            tb.Rows.Add(t800.R631.F5);
            tb.Rows.Add(t800.R631.F6);
            tb.Rows.Add(t800.R631.F7);

            tb.Rows.Add(t800.R645.F1);
            tb.Rows.Add(t800.R645.F2);
            tb.Rows.Add(t800.R645.F3);
            tb.Rows.Add(t800.R645.F4);
            tb.Rows.Add(t800.R645.F5);
            tb.Rows.Add(t800.R645.F6);
            tb.Rows.Add(t800.R645.F7);

            tb.Rows.Add(t800.R659.F1);
            tb.Rows.Add(t800.R659.F2);
            tb.Rows.Add(t800.R659.F3);
            tb.Rows.Add(t800.R659.F4);
            tb.Rows.Add(t800.R659.F5);
            tb.Rows.Add(t800.R659.F6);
            tb.Rows.Add(t800.R659.F7);

            tb.Rows.Add(t800.R673.F1);
            tb.Rows.Add(t800.R673.F2);
            tb.Rows.Add(t800.R673.F3);
            tb.Rows.Add(t800.R673.F4);
            tb.Rows.Add(t800.R673.F5);
            tb.Rows.Add(t800.R673.F6);
            tb.Rows.Add(t800.R673.F7);

            tb.Rows.Add(t800.R687.F1);
            tb.Rows.Add(t800.R687.F2);
            tb.Rows.Add(t800.R687.F3);
            tb.Rows.Add(t800.R687.F4);
            tb.Rows.Add(t800.R687.F5);
            tb.Rows.Add(t800.R687.F6);
            tb.Rows.Add(t800.R687.F7);

            T800_Extend_01 t800_Extend = t800.R857;

            tb.Rows.Add(t800_Extend.R857);
            tb.Rows.Add(t800_Extend.R859);
            tb.Rows.Add(t800_Extend.R861);
            
            tb.Rows.Add(t800_Extend.R863);
            tb.Rows.Add(t800_Extend.R865);
            tb.Rows.Add(t800_Extend.R867);

            tb.Rows.Add(t800_Extend.R869);
            tb.Rows.Add(t800_Extend.R871);

            T800_Extend_01_C2_10 t800_R873 = t800_Extend.R873;
            tb.Rows.Add(t800_R873.R01);
            tb.Rows.Add(t800_R873.R02);
            tb.Rows.Add(t800_R873.R03);
            tb.Rows.Add(t800_R873.R04);
            tb.Rows.Add(t800_R873.R05);
            tb.Rows.Add(t800_R873.R06);
            tb.Rows.Add(t800_R873.R07);
            tb.Rows.Add(t800_R873.R08);
            tb.Rows.Add(t800_R873.R09);
            tb.Rows.Add(t800_R873.R10);

            T800_Extend_01_I2_10 t800_R893 = t800_Extend.R893;
            tb.Rows.Add(t800_R893.R01);
            tb.Rows.Add(t800_R893.R02);
            tb.Rows.Add(t800_R893.R03);
            tb.Rows.Add(t800_R893.R04);
            tb.Rows.Add(t800_R893.R05);
            tb.Rows.Add(t800_R893.R06);
            tb.Rows.Add(t800_R893.R07);
            tb.Rows.Add(t800_R893.R08);
            tb.Rows.Add(t800_R893.R09);
            tb.Rows.Add(t800_R893.R10);

            T800_Extend_01_I2_10 t800_R913 = t800_Extend.R913;
            tb.Rows.Add(t800_R913.R01);
            tb.Rows.Add(t800_R913.R02);
            tb.Rows.Add(t800_R913.R03);
            tb.Rows.Add(t800_R913.R04);
            tb.Rows.Add(t800_R913.R05);
            tb.Rows.Add(t800_R913.R06);
            tb.Rows.Add(t800_R913.R07);
            tb.Rows.Add(t800_R913.R08);
            tb.Rows.Add(t800_R913.R09);
            tb.Rows.Add(t800_R913.R10);

            tb.Rows.Add(t800_Extend.R933);
            tb.Rows.Add(t800_Extend.R935);
            tb.Rows.Add(t800_Extend.R937);
            tb.Rows.Add(t800_Extend.R939);
            tb.Rows.Add(t800_Extend.R941);
            tb.Rows.Add(t800_Extend.R943);
            tb.Rows.Add(t800_Extend.R945);

            T800_Extend_01_I2_10 t800_R947 = t800_Extend.R947;
            tb.Rows.Add(t800_R947.R01);
            tb.Rows.Add(t800_R947.R02);
            tb.Rows.Add(t800_R947.R03);
            tb.Rows.Add(t800_R947.R04);
            tb.Rows.Add(t800_R947.R05);
            tb.Rows.Add(t800_R947.R06);
            tb.Rows.Add(t800_R947.R07);
            tb.Rows.Add(t800_R947.R08);
            tb.Rows.Add(t800_R947.R09);
            tb.Rows.Add(t800_R947.R10);

            T800_Extend_01_I2_04 t800_R967 = t800_Extend.R967;
            tb.Rows.Add(t800_R967.R1);
            tb.Rows.Add(t800_R967.R2);
            tb.Rows.Add(t800_R967.R3);
            tb.Rows.Add(t800_R967.R4);

            T800_Extend_01_I2_04 t800_R975 = t800_Extend.R975;
            tb.Rows.Add(t800_R975.R1);
            tb.Rows.Add(t800_R975.R2);
            tb.Rows.Add(t800_R975.R3);
            tb.Rows.Add(t800_R975.R4);

            T800_Extend_01_I2_04 t800_R983 = t800_Extend.R983;
            tb.Rows.Add(t800_R983.R1);
            tb.Rows.Add(t800_R983.R2);
            tb.Rows.Add(t800_R983.R3);
            tb.Rows.Add(t800_R983.R4);

            T800_I2_10 t800_R481 = t800.R481;
            tb.Rows.Add(t800_R481.R01);
            tb.Rows.Add(t800_R481.R02);
            tb.Rows.Add(t800_R481.R03);
            tb.Rows.Add(t800_R481.R04);
            tb.Rows.Add(t800_R481.R05);
            tb.Rows.Add(t800_R481.R06);
            tb.Rows.Add(t800_R481.R07);
            tb.Rows.Add(t800_R481.R08);
            tb.Rows.Add(t800_R481.R09);
            tb.Rows.Add(t800_R481.R10);

            // HSS5
            T800_Extend_02 t800_R451 = t800.R451;
            tb.Rows.Add(t800_R451.R451);
            tb.Rows.Add(t800_R451.R453);
            tb.Rows.Add(t800_R451.R455);
            tb.Rows.Add(t800_R451.R457);
            tb.Rows.Add(t800_R451.R459);
            tb.Rows.Add(t800_R451.R461);
            tb.Rows.Add(t800_R451.R463);
            tb.Rows.Add(t800_R451.R465);
            // End HSS5

            return tb;
        }

        private DataTable PrepareCSVData(T1800 t1800, out DataTable rolkei)
        {
            rolkei = null;
            if (t1800 == null)
            {
                return null;
            }

            DataTable tb = new DataTable();
            tb.Columns.Add("Data");
            
            rolkei = new DataTable();
            for (int i = 0; i < 14; i++)
            {
                rolkei.Columns.Add("ｺｲﾙ番号" + i.ToString());
            }

            tb.Rows.Add(t1800.R0025);
            tb.Rows.Add(t1800.R0033 % 100);
            tb.Rows.Add(t1800.R0035);
            tb.Rows.Add(t1800.R0037);
            tb.Rows.Add(t1800.R0039);
            tb.Rows.Add(t1800.R0041);
            tb.Rows.Add(t1800.R0043_1);
            tb.Rows.Add(t1800.R0053);
            tb.Rows.Add(t1800.R0059);
            tb.Rows.Add(t1800.R0061);
            tb.Rows.Add(t1800.R0063);
            tb.Rows.Add(t1800.R0065);
            tb.Rows.Add(t1800.R0067);
            tb.Rows.Add(t1800.R0069);
            tb.Rows.Add(t1800.R0071);
            tb.Rows.Add(t1800.R0073_1);
            
            tb.Rows.Add(t1800.R0075.F1);
            tb.Rows.Add(t1800.R0075.F2);
            tb.Rows.Add(t1800.R0075.F3);
            tb.Rows.Add(t1800.R0075.F4);
            tb.Rows.Add(t1800.R0075.F5);
            tb.Rows.Add(t1800.R0075.F6);
            tb.Rows.Add(t1800.R0075.F7);

            tb.Rows.Add(t1800.R0089);
            tb.Rows.Add(t1800.R0091);
            tb.Rows.Add(t1800.R0093);
            tb.Rows.Add(t1800.R0095);

            tb.Rows.Add(t1800.R0097.F1_1);
            tb.Rows.Add(t1800.R0097.F2_1);
            tb.Rows.Add(t1800.R0097.F3_1);
            tb.Rows.Add(t1800.R0097.F4_1);
            tb.Rows.Add(t1800.R0097.F5_1);
            tb.Rows.Add(t1800.R0097.F6_1);
            tb.Rows.Add(t1800.R0097.F7_1);

            tb.Rows.Add(t1800.R0125.F1);
            tb.Rows.Add(t1800.R0125.F2);
            tb.Rows.Add(t1800.R0125.F3);
            tb.Rows.Add(t1800.R0125.F4);
            tb.Rows.Add(t1800.R0125.F5);
            tb.Rows.Add(t1800.R0125.F6);
            tb.Rows.Add(t1800.R0125.F7);

            tb.Rows.Add(t1800.R0139.F1_1);
            tb.Rows.Add(t1800.R0139.F2_1);
            tb.Rows.Add(t1800.R0139.F3_1);
            tb.Rows.Add(t1800.R0139.F4_1);
            tb.Rows.Add(t1800.R0139.F5_1);
            tb.Rows.Add(t1800.R0139.F6_1);
            tb.Rows.Add(t1800.R0139.F7_1);

            tb.Rows.Add(t1800.R0167.F1_1);
            tb.Rows.Add(t1800.R0167.F2_1);
            tb.Rows.Add(t1800.R0167.F3_1);
            tb.Rows.Add(t1800.R0167.F4_1);
            tb.Rows.Add(t1800.R0167.F5_1);
            tb.Rows.Add(t1800.R0167.F6_1);
            tb.Rows.Add(t1800.R0167.F7_1);

            tb.Rows.Add(t1800.R0195.F1_1);
            tb.Rows.Add(t1800.R0195.F2_1);
            tb.Rows.Add(t1800.R0195.F3_1);
            tb.Rows.Add(t1800.R0195.F4_1);
            tb.Rows.Add(t1800.R0195.F5_1);
            tb.Rows.Add(t1800.R0195.F6_1);
            tb.Rows.Add(t1800.R0195.F7_1);

            tb.Rows.Add(t1800.R0223.F1);
            tb.Rows.Add(t1800.R0223.F2);
            tb.Rows.Add(t1800.R0223.F3);
            tb.Rows.Add(t1800.R0223.F4);
            tb.Rows.Add(t1800.R0223.F5);
            tb.Rows.Add(t1800.R0223.F6);
            tb.Rows.Add(t1800.R0223.F7);

            tb.Rows.Add(t1800.R0237.F1);
            tb.Rows.Add(t1800.R0237.F2);
            tb.Rows.Add(t1800.R0237.F3);
            tb.Rows.Add(t1800.R0237.F4);
            tb.Rows.Add(t1800.R0237.F5);
            tb.Rows.Add(t1800.R0237.F6);
            tb.Rows.Add(t1800.R0237.F7);

            tb.Rows.Add(t1800.R0251.F1_1);
            tb.Rows.Add(t1800.R0251.F2_1);
            tb.Rows.Add(t1800.R0251.F3_1);
            tb.Rows.Add(t1800.R0251.F4_1);
            tb.Rows.Add(t1800.R0251.F5_1);
            tb.Rows.Add(t1800.R0251.F6_1);
            tb.Rows.Add(t1800.R0251.F7_1);

            tb.Rows.Add(t1800.R0279.R1);
            tb.Rows.Add(t1800.R0279.R2);
            tb.Rows.Add(t1800.R0279.R3);
            tb.Rows.Add(t1800.R0279.R4);
            tb.Rows.Add(t1800.R0279.R5);
            tb.Rows.Add(t1800.R0279.R6);
            // HSS5
            /*
             * Ver5 updated
             * 予備 / du bi, chuyen qua bang T200
            tb.Rows.Add(t1800.R0291.R1);
            tb.Rows.Add(t1800.R0291.R2);
            tb.Rows.Add(t1800.R0291.R3);
            tb.Rows.Add(t1800.R0291.R4);
            tb.Rows.Add(t1800.R0291.R5);
            tb.Rows.Add(t1800.R0291.R6);
            */
            tb.Rows.Add(0);
            tb.Rows.Add(0);
            tb.Rows.Add(0);
            tb.Rows.Add(0);
            tb.Rows.Add(0);
            tb.Rows.Add(0);
            // end HSS5

            // extend
            T1800_Extend_01 t1800_Extend = t1800.R1661;
            //tb.Rows.Add(1);
            tb.Rows.Add(this._SelectedWorkerID);
            for (int i = 0; i < t1800_Extend.Rows.Length; i++)
            {
                tb.Rows.Add(t1800_Extend.Rows[i]);
            }

            // HSS5
            // ＲＢ横ぶれ量　ＢＯＴＴＯＭ
            tb.Rows.Add(t1800.R1749.R1749);
            // 粗ミルWR圧延ton数
            tb.Rows.Add(t1800.R1749.R1753);
            tb.Rows.Add(t1800.R1749.R1757);
            // 仕上ミルWR圧延ton数
            tb.Rows.Add(t1800.R1749.R1761);
            tb.Rows.Add(t1800.R1749.R1765);
            tb.Rows.Add(t1800.R1749.R1769);
            tb.Rows.Add(t1800.R1749.R1773);
            tb.Rows.Add(t1800.R1749.R1777);
            tb.Rows.Add(t1800.R1749.R1781);
            tb.Rows.Add(t1800.R1749.R1785);
            // End HSS5

            //ROLKEI
            rolkei.Rows.Add(t1800.R0025, t1800.R0025, t1800.R0025, t1800.R0025, t1800.R0025, t1800.R0025, t1800.R0025, t1800.R0025, t1800.R0025, t1800.R0025, t1800.R0025, t1800.R0025, t1800.R0025, t1800.R0025);
            for (int i = 0; i < t1800.R0401.Rows.Length; i++)
            {
                rolkei.Rows.Add(t1800.R0401.Rows[i], t1800.R0491.Rows[i], t1800.R0581.Rows[i], t1800.R0671.Rows[i], t1800.R0761.Rows[i], t1800.R0851.Rows[i], t1800.R0941.Rows[i], 
                                t1800.R1031.Rows[i], t1800.R1121.Rows[i], t1800.R1211.Rows[i], t1800.R1301.Rows[i], t1800.R1391.Rows[i], t1800.R1481.Rows[i], t1800.R1571.Rows[i]);
            }
            //rolkei.Rows.Add(t1800.R0401.R01, t1800.R0491.R01, t1800.R0581.R01, t1800.R0671.R01, t1800.R0761.R01, t1800.R0851.R01, t1800.R0941.R01, t1800.R1031.R01, t1800.R1121.R01, t1800.R1211.R01, t1800.R1301.R01, t1800.R1391.R01, t1800.R1481.R01, t1800.R1571.R01);

            return tb;
        }

        private DataTable PrepareCSVData(T200 t200)
        {
            if (t200 == null)
            {
                return null;
            }

            DataTable tb = new DataTable();
            tb.Columns.Add("Data");
            
            //ｺｲﾙ番号
            tb.Rows.Add(t200.R025);
            // ＲＢ横ぶれ量　ＴＯＰ
            tb.Rows.Add(t200.R083);
            // HCクラウン（１スキャン目）
            tb.Rows.Add(t200.R085);
            tb.Rows.Add(t200.R087);
            tb.Rows.Add(t200.R089);
            tb.Rows.Add(t200.R091);
            tb.Rows.Add(t200.R093);
            tb.Rows.Add(t200.R095);
            // ベンダー力　同時点
            tb.Rows.Add(t200.R097);
            tb.Rows.Add(t200.R099);
            tb.Rows.Add(t200.R101);
            tb.Rows.Add(t200.R103);
            tb.Rows.Add(t200.R105);
            tb.Rows.Add(t200.R107);
            tb.Rows.Add(t200.R109);

            return tb;
        }

        private Gamen LoadGamen(T900 t900)
        {
            log.Info("LoadGamen(T900 t900) Begin . Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
            try
            {
                int coilIndex = Convert.ToInt32(t900.CoilIndex);
                string fileName = t900.R025.Trim() + "_IN_YOBI" + coilIndex.ToString("00") + ".csv";

                string absolutePath = GetAbsolutePath();

                DataTable tb = PrepareCSVData(t900);
                string csvData = CSVFileManager.GetCSVString(tb, false, ",");
                csvData += System.Environment.NewLine;

                CSVFileManager.WriteToFile(absolutePath + fileName, csvData, System.Text.Encoding.GetEncoding("Shift_JIS"));
                
                Gamen gamen = new Gamen();
                string gamenData = LoadGamen(FSU_ASSIST__FILE_PATH, FSU_ASSIST__ABSOLUTE_PATH, t900.R025, 1, coilIndex);
                gamen.MasterType = 1; //Preset
                gamen.MasterID = t900.ID;
                gamen.Values = gamenData;
                gamen.Insert();

                return gamen;
            }
            catch (Exception ex)
            {
                log.Error("Load Gamen file of T900 error.", ex);
            }
            log.Info("LoadGamen(T900 t900) End. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
            return null;
        }

        private Gamen LoadGamen(T800 t800)
        {
            log.Info("LoadGamen(T800 t800) Begin . Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
            try
            {
                string fileName = t800.R025.Trim() + "_IN_SETTEI.csv";

                string absolutePath = GetAbsolutePath();

                DataTable tb = PrepareCSVData(t800);
                string csvData = CSVFileManager.GetCSVString(tb, false, ",");
                csvData += System.Environment.NewLine;

                CSVFileManager.WriteToFile(absolutePath + fileName, csvData, System.Text.Encoding.GetEncoding("Shift_JIS"));

                Gamen gamen = new Gamen();
                string gamenData = LoadGamen(FSU_ASSIST__FILE_PATH, FSU_ASSIST__ABSOLUTE_PATH, t800.R025, 4, 0);
                gamen.MasterType = 2; //Finalset
                gamen.MasterID = t800.ID;
                gamen.Values = gamenData;
                gamen.Insert();

                return gamen;
            }
            catch (Exception ex)
            {
                log.Error("Load Gamen file of T800 error.", ex);
            }
            log.Info("LoadGamen(T800 t800) End . Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
            return null;
        }

        private Gamen LoadGamen(T1800 t1800)
        {
            log.Info("LoadGamen(T1800 t1800) Begin . Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
            try
            {
                string fileName = t1800.R0025.Trim() + "_IN_JISSEK.csv";

                string absolutePath = GetAbsolutePath();

                DataTable rolkei = null;
                DataTable tb = PrepareCSVData(t1800, out rolkei);
                string csvData = CSVFileManager.GetCSVString(tb, false, ",");
                csvData += System.Environment.NewLine;

                CSVFileManager.WriteToFile(absolutePath + fileName, csvData, System.Text.Encoding.GetEncoding("Shift_JIS"));

                fileName = t1800.R0025.Trim() + "_IN_ROLKEI.csv";
                csvData = CSVFileManager.GetCSVString(rolkei, false, ",");
                csvData += System.Environment.NewLine;

                CSVFileManager.WriteToFile(absolutePath + fileName, csvData, System.Text.Encoding.GetEncoding("Shift_JIS"));

                Gamen gamen = new Gamen();
                string gamenData = LoadGamen(FSU_ASSIST__FILE_PATH, FSU_ASSIST__ABSOLUTE_PATH, t1800.R0025, 5, 0);
                gamen.MasterType = 3; //Result
                gamen.MasterID = t1800.ID;
                gamen.Values = gamenData;
                gamen.Insert();

                return gamen;
            }
            catch (Exception ex)
            {
                log.Error("Load Gamen file of T1800 error.", ex);
            }
            log.Info("LoadGamen(T1800 t1800) End . Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
            return null;
        }

        private Gamen LoadGamen(T200 t200)
        {
            log.Info("LoadGamen(T200 t200) Begin . Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
            try
            {
                string fileName = t200.R025.Trim() + "_IN_DOJTEN.csv";

                string absolutePath = this.GetAbsolutePath();

                DataTable tb = this.PrepareCSVData(t200);
                string csvData = CSVFileManager.GetCSVString(tb, false, ",");
                csvData += System.Environment.NewLine;

                CSVFileManager.WriteToFile(absolutePath + fileName, csvData, System.Text.Encoding.GetEncoding("Shift_JIS"));

                Gamen gamen = new Gamen();
                string gamenData = LoadGamen(FSU_ASSIST__FILE_PATH, FSU_ASSIST__ABSOLUTE_PATH, t200.R025, 6, 0);
                gamen.MasterType = 4; //Finished
                gamen.MasterID = t200.ID;
                gamen.Values = gamenData;
                gamen.Insert();

                return gamen;
            }
            catch (Exception ex)
            {
                log.Error("Load Gamen file of T200 error.", ex);
                return null;
            }
            finally
            {
                log.Info("LoadGamen(T200 t200) End . Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
            }
        }

        private string LoadGamen(string exeFilePath, string absolutePath, string coilNo, int arg2, int arg3)
        {
            if (absolutePath.Length < 1)
            {
                return null;
            }

            try
            {
                absolutePath = absolutePath.Trim();
                absolutePath = absolutePath[absolutePath.Length - 1] == '\\' ? absolutePath : (absolutePath + @"\");
                absolutePath += DateTime.Now.ToString("yyyy_MM") + "\\" + DateTime.Now.ToString("dd") + "\\";

                log.Debug("LoadGamen exe file path: \"" + exeFilePath + "\", absolute path: \"" + absolutePath + "\", coilNo: " + coilNo + ", arg2: " + arg2.ToString() + ", arg3: " + arg3.ToString());

                string arguments = "\"" + absolutePath + coilNo.Trim() + "\"" + " " + arg2.ToString() + " " + arg3.ToString() + " ABC ABC ";
                log.Debug("LoadGamen exe arguments: " + arguments);

                log.Info("LoadGamen Begin Execute. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo(exeFilePath, arguments);
                info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                System.Diagnostics.Process pro = System.Diagnostics.Process.Start(info);
                pro.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                bool exitted = pro.WaitForExit(WAIT_FOR_FSU_ASSIST_EXIT);
                log.Info("LoadGamen End Execute. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                if (exitted)
                {
                    int exitCode = pro.ExitCode;
                    if (exitCode == 0)
                    {
                        // Successful
                        string gamenFilePath = exeFilePath.Substring(0, exeFilePath.LastIndexOf(@"\"));
                        gamenFilePath += @"\dsp_dat\GAMEN.csv";
                        // for test
                        try
                        {
                            log.Info("Reading Gamen.csv begin. " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                            string gamenData = System.IO.File.ReadAllText(gamenFilePath, System.Text.Encoding.GetEncoding("Shift_JIS"));
                            log.Info("Gamen Data: " +  gamenData.Replace(System.Environment.NewLine, "#"));
                            log.Info("Reading Gamen.csv successful. " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                        }
                        catch (Exception ex)
                        {
                            log.Error("Reading Gamen.csv error. " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"), ex);
                        }
                        finally
                        {
                            log.Info("Reading Gamen.csv end. " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                        }
                        // end test
                        StringBuilder strBuilder = new StringBuilder();
                        log.Info("LoadGamen Begin Read Gamen. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                        DataTable tb = CSVFileManager.Read(gamenFilePath, System.Text.Encoding.GetEncoding("Shift_JIS"), ",");
                        log.Info("LoadGamen End Read Gamen. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                        log.Info("LoadGamen Begin process string. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                        for (int i = 1; i < tb.Rows.Count; i++)
                        {
                            if (tb.Rows[i][1] != null)
                            {
                                string valueiString = tb.Rows[i][1].ToString().Trim();
                                // HSS5
                                /*
                                try
                                {
                                    double valueiDouble = Convert.ToDouble(valueiString);
                                    valueiString = valueiDouble.ToString("##0.0##");
                                }
                                catch (Exception)
                                {
                                }
                                */
                                // End HSS5
                                strBuilder.Append(valueiString);
                            }
                            else
                            {
                                strBuilder.Append("0");
                            }
                            if (i < tb.Rows.Count - 1)
                            {
                                strBuilder.Append(Gamen.VALUES__SEPARATOR);
                            }
                        }
                        log.Info("LoadGamen End process string. Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                        return strBuilder.ToString();
                    }
                    else
                    {
                        log.Error("Gamen exit Code: " + exitCode.ToString());
                    }
                }
                else
                {
                    log.Error("Gamen not exit.");
                }

                return null;
            }
            catch (Exception ex)
            {
                log.Error("LoadGamen error.", ex);
                return null;
            }
        }

        private Gamen SimulationCalculate1(object sender, SimulationCalculateEventArgs e)
        {
            if (e.Type != SimulationType.Simulation1)
            {
                return null;
            }

            try
            {
                T900 t900 = e.T900;
                int time = e.Time;

                string fileName = t900.R025.Trim() + "_IN_TEKA" + time.ToString("00") + ".csv";

                string absolutePath = GetAbsolutePath();

                DataTable tb = PrepareSimulation1CSVData(t900);
                string csvData = CSVFileManager.GetCSVString(tb, false, ",");
                csvData += System.Environment.NewLine;

                CSVFileManager.WriteToFile(absolutePath + fileName, csvData, System.Text.Encoding.GetEncoding("Shift_JIS"));

                Gamen gamen = new Gamen();
                string gamenData = LoadGamen(FSU_ASSIST__FILE_PATH, FSU_ASSIST__ABSOLUTE_PATH, t900.R025, 2, time);
                gamen.MasterType = 4; //Simulation1
                gamen.MasterID = t900.ID;
                gamen.Values = gamenData;

                return gamen;
            }
            catch (Exception ex)
            {
                log.Error("SimulationCalculate1 error. Detail:", ex);
            }

            return null;
        }

        private Gamen SimulationCalculate2(object sender, SimulationCalculateEventArgs e)
        {
            if (e.Type != SimulationType.Simulation2)
            {
                return null;
            }

            try
            {
                T900 t900 = e.T900;
                int time = e.Time;

                string fileName = t900.R025.Trim() + "_IN_TEKK" + time.ToString("00") + ".csv";

                string absolutePath = GetAbsolutePath();

                DataTable tb = PrepareSimulation2CSVData(t900);
                string csvData = CSVFileManager.GetCSVString(tb, false, ",");
                csvData += System.Environment.NewLine;

                CSVFileManager.WriteToFile(absolutePath + fileName, csvData, System.Text.Encoding.GetEncoding("Shift_JIS"));

                Gamen gamen = new Gamen();
                string gamenData = LoadGamen(FSU_ASSIST__FILE_PATH, FSU_ASSIST__ABSOLUTE_PATH, t900.R025, 3, time);
                gamen.MasterType = 5; //Simulation2
                gamen.MasterID = t900.ID;
                gamen.Values = gamenData;

                return gamen;
            }
            catch (Exception ex)
            {
                log.Error("SimulationCalculate2 error. Detail:", ex);
            }

            return null;
        }

        private Gamen SimulationClear(object sender, SimulationCalculateEventArgs e)
        {
            if (e.Type != SimulationType.Simulation1Clear && e.Type != SimulationType.Simulation2Clear)
            {
                return null;
            }

            try
            {   
                T900 t900 = e.T900;
                /*
                int time = e.Time;

                string fileName = t900.R025.Trim() + "_IN_TEKK" + time.ToString("00") + ".csv";

                string absolutePath = GetAbsolutePath();

                DataTable tb = PrepareSimulation2CSVData(t900);
                string csvData = CSVFileManager.GetCSVString(tb, false, ",");
                csvData += System.Environment.NewLine;

                CSVFileManager.WriteToFile(absolutePath + fileName, csvData, System.Text.Encoding.GetEncoding("Shift_JIS"));
                */
                Gamen gamen = new Gamen();
                string gamenData = LoadGamen(FSU_ASSIST__FILE_PATH, FSU_ASSIST__ABSOLUTE_PATH, t900.R025, 2, -1);
                gamen.MasterType = -1; //Clear
                gamen.MasterID = t900.ID;
                gamen.Values = gamenData;

                return gamen;
            }
            catch (Exception ex)
            {
                log.Error("SimulationCalculate2 error. Detail:", ex);
            }

            return null;
        }

        private string GetAbsolutePath()
        {
            string absolutePath = FSU_ASSIST__ABSOLUTE_PATH.Trim();
            absolutePath = absolutePath[absolutePath.Length - 1] == '\\' ? absolutePath : (absolutePath + @"\");
            absolutePath += DateTime.Now.ToString("yyyy_MM") + "\\" + DateTime.Now.ToString("dd") + "\\";

            if (!System.IO.Directory.Exists(absolutePath))
            {
                System.IO.Directory.CreateDirectory(absolutePath);
            }

            return absolutePath;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            ChildForm_KeyDown(this, keyData);
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ChildForm_KeyDown(object sender, Keys keyData)
        {
            if (keyData == Keys.PageUp)
            {
                btnFinishSupport1_Click(btnFinishSupport1, null);
            }
            else if (keyData == Keys.PageDown)
            {
                btnFinishSupport2_Click(btnFinishSupport2, null);
            }
            else if (keyData == Keys.Home)
            {
                this.Focus();
            }

            // test for refresh data
            try
            {
                if ((keyData & Keys.Control) == Keys.Control)
                {
                    Keys keyPressed = keyData & (~Keys.Control);
                    if (keyPressed == Keys.F5)
                    {
                        if (this.frmPreset != null)
                        {
                            this.frmPreset.LoadData();
                        }
                        if (this.frmSupport1 != null)
                        {
                            //this.frmSupport1.LoadData(DataPackages.Preset);
                            this.frmSupport1_V5.LoadData(DataPackages.Preset);
                        }
                        if (this.frmSupport2 != null)
                        {
                            this.frmSupport2.LoadData(DataPackages.Preset);
                        }
                    }
                    else if (keyPressed == Keys.F6)
                    {
                        if (this.frmPreset != null)
                        {
                            this.frmPreset.LoadData();
                        }
                        if (this.frmSupport1 != null)
                        {
                            //this.frmSupport1.LoadData(DataPackages.FinalSet);
                            this.frmSupport1_V5.LoadData(DataPackages.FinalSet);
                        }
                        if (this.frmSupport2 != null)
                        {
                            this.frmSupport2.LoadData(DataPackages.FinalSet);
                        }
                    }
                    else if (keyPressed == Keys.F7)
                    {
                        if (this.frmPreset != null)
                        {
                            this.frmPreset.LoadData();
                        }
                        if (this.frmSupport1 != null)
                        {
                            //this.frmSupport1.LoadData(DataPackages.Result);
                            this.frmSupport1_V5.LoadData(DataPackages.Result);
                        }
                        if (this.frmSupport2 != null)
                        {
                            this.frmSupport2.LoadData(DataPackages.Result);
                        }
                    }
                    else if (keyPressed == Keys.F8)
                    {
                        if (this.frmPreset != null)
                        {
                            this.frmPreset.LoadData();
                        }
                        /*
                        if (this.frmSupport1 != null)
                        {
                            this.frmSupport1.LoadData(DataPackages.Preset);
                            this.frmSupport1.LoadData(DataPackages.FinalSet);
                            this.frmSupport1.LoadData(DataPackages.Result);
                        }
                        */
                        if (this.frmSupport1_V5 != null)
                        {
                            this.frmSupport1_V5.LoadData(DataPackages.Preset);
                            this.frmSupport1_V5.LoadData(DataPackages.FinalSet);
                            this.frmSupport1_V5.LoadData(DataPackages.Result);
                        }
                        if (this.frmSupport2 != null)
                        {
                            this.frmSupport2.LoadData(DataPackages.Preset);
                            this.frmSupport2.LoadData(DataPackages.FinalSet);
                            this.frmSupport2.LoadData(DataPackages.Result);
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            // end test
        }

        private bool CloseAllChildsWithConfirm()
        {
            bool mustClose = false;
            foreach (Form subform in this._SubForm)
            {
                if (subform != null && subform.Visible == true)
                {
                    mustClose = true;
                    break;
                }
            }
            if (mustClose)
            {
                System.Windows.Forms.DialogResult dialogResult = MessageBox.Show(this, "データベースの構成の前にサブフォームをクローズしなければなりません。クローズしますか。", "通知", MessageBoxButtons.YesNoCancel);
                switch (dialogResult)
                {
                    case DialogResult.Cancel:
                        return false;
                    case DialogResult.No:
                        return false;
                    case DialogResult.Yes:
                        break;
                    default:
                        break;
                }

                for (int i = this._SubForm.Count - 1; i > -1; i--)
                {
                    Form frmSub = this._SubForm[i];
                    if (frmSub != null)
                    {
                        try
                        {
                            frmSub.Close();
                            this._SubForm.RemoveAt(i);
                        }
                        catch (Exception) { }
                    }
                }

                frmPreset = null;
                frmPressureDifferenceTotal = null;
                frmSearchCoil = null;
                frmSetParameter = null;
                frmSupport1 = null;
                frmSupport2 = null;
                frmWorker = null;
            }

            return true;
        }

        private bool RequireSetupDatabase()
        {
            if (!CloseAllChildsWithConfirm())
            {
                TerminalApplication();
                return false;
            }

            string currentConnectionString = Kvics.DBAccess.DBAccessor.DefaultConnectionString;

            FormDatabaseConfig frm = new FormDatabaseConfig();
            frm.HotMillDatabaseConnectionString = Kvics.DBAccess.DBAccessor.DefaultConnectionString;
            while (frm.ShowDialog() == DialogResult.OK)
            {
                Kvics.DBAccess.DBAccessor.DefaultConnectionString = frm.HotMillDatabaseConnectionString;

                if (ValidateDatabaseConnection())
                {
                    FormDatabaseConfig.ApplyConnectionString(frm.HotMillDatabaseConnectionString);
                    return true;
                }
            }

            TerminalApplication();
            return false;

            //Kvics.DBAccess.DBAccessor.DefaultConnectionString = currentConnectionString;
        }

        private void TerminalApplication()
        {
            _RequireExit = true;
            try
            {
                this.Close();
                Application.Exit();
            }
            catch (Exception) { }
        }

        private bool ValidateDatabase()
        {
            if (!ValidateDatabaseConnection())
            {
                if (!RequireSetupDatabase())
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidateDatabaseConnection()
        {
            FormPresetCalculator frmPresetTest = null;
            try
            {
                frmPresetTest = new FormPresetCalculator();
                frmPresetTest.MainForm = this;
                if (!frmPresetTest.PreloadAll())
                {
                    throw new Exception("Invalid database.");
                }

                TMapping.ReloadMapping();

                TMapping tmapping = new TMapping();
                DataSet ds = tmapping.GetAll();
                if (ds.Tables[0].Rows.Count != TMapping.MAPPING_COUNT)
                {
                    throw new Exception("Invalid mapping table.");
                }

                for (int i = 0; i < T900_Mapping.RowsName.Length; i++)
                {
                    if (T900_Mapping.GetRowID(T900_Mapping.RowsName[i]) < 0)
                    {
                        throw new Exception("Invalid T900 mapping table.");
                    }
                }

                for (int i = 0; i < T800_Mapping.RowsName.Length; i++)
                {
                    if (T800_Mapping.GetRowID(T800_Mapping.RowsName[i]) < 0)
                    {
                        throw new Exception("Invalid T800 mapping table.");
                    }
                }

                for (int i = 0; i < T1800_Mapping.RowsName.Length; i++)
                {
                    if (T1800_Mapping.GetRowID(T1800_Mapping.RowsName[i]) < 0)
                    {
                        throw new Exception("Invalid T1800 mapping table.");
                    }
                }

                // HSS 4
                for (int i = 0; i < T800_Extend_01_Mapping.RowsName.Length; i++)
                {
                    if (T800_Extend_01_Mapping.GetRowID(T800_Extend_01_Mapping.RowsName[i]) < 0)
                    {
                        throw new Exception("Invalid T800_Extend_01 mapping table.");
                    }
                }
                // End HSS 4
            }
            catch (Exception ex)
            {
                log.Error("ValidateDatabaseConnection error", ex);
                return false;
            }
            finally
            {
                if (frmPresetTest != null && !frmPresetTest.IsDisposed)
                {
                    frmPresetTest.Dispose();
                }
            }
            return true;
        }

        // for test only
        /*
        public void SetDataTest(DataPackages package)
        {
            int discarded = 0;
            byte[] bytes = null;
            string coilNo = "";

            if (_LastT900 == null)
            {
                _LastT900 = T900.Parse(Utility.HexEncoding.GetBytes(T900_DATA_SAMPLE, out discarded));
            }

            switch (package)
            {
                case DataPackages.Preset:
                    bytes = Utility.HexEncoding.GetBytes(T900_DATA_SAMPLE, out discarded);
                    Random ran = new Random();
                    coilNo = "A" + Common.GetString(Common.GetString(ran.Next(99999).ToString(), 0, 5, '0', 1), 0, 7, ' ', 2);
                    break;
                case DataPackages.FinalSet:
                    bytes = Utility.HexEncoding.GetBytes(T800_DATA_SAMPLE, out discarded);
                    coilNo = _LastT900.R025;
                    break;
                case DataPackages.Result:
                    bytes = Utility.HexEncoding.GetBytes(T1800_DATA_SAMPLE, out discarded);
                    coilNo = _LastT900.R025;
                    break;
                default:
                    return;
            }

            byte[] bytesCoilNo = System.Text.Encoding.ASCII.GetBytes(coilNo); //Utility.HexEncoding.GetBytes(coilNo, out discarded);
            Array.Copy(bytesCoilNo, 0, bytes, 8, bytesCoilNo.Length);

            if (package == DataPackages.Preset)
            {
                _LastT900 = T900.Parse(bytes);
            }

            Kvics.Communication.PacketArrivedEventArgs e = new Kvics.Communication.PacketArrivedEventArgs(new Kvics.Communication.DataPacket(bytes), 1);
            Worker1_PacketArrived(null, e);
        }
        */
        // end for test only

        //private T900 _LastT900 = null;

        private void tmrRemoveGamenData_Tick(object sender, EventArgs e)
        {
            log.Debug("Begin remove old GAMEN data, at: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
            try
            {
                log.Debug("Begin remove old GAMEN data of T900, at: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                Gamen.RemoveOldCoil(1, 800);
                log.Debug("Begin remove old GAMEN data of T800, at: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                Gamen.RemoveOldCoil(2, 100);
                log.Debug("Begin remove old GAMEN data of T1800, at: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                Gamen.RemoveOldCoil(3, 100);
                log.Debug("Begin remove old GAMEN data of T200, at: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                Gamen.RemoveOldCoil(4, 100);
            }
            catch (Exception ex)
            {
                log.Debug("tmrRemoveGamenData_Tick Error", ex);
            }
            finally
            {
                log.Debug("End remove old GAMEN data, at: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
            }
        }
    }

    public enum HotMillErrorType
    {
        DATABASE_ERROR,
        UNKNOWN_ERROR
    }

}
