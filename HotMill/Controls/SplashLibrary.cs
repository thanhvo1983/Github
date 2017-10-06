using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Kvics.Controls.SplashLibrary
{
    public delegate void SafeSendMessageCallback(String message);

    public delegate void ApplicationInitCallback(String[] args,
        SafeSendMessageCallback sendMessageCallback);

    public delegate Form UIInitCallback(String[] args,
        SafeSendMessageCallback sendMessageCallback);

    public interface IDynamicSplashScreen
    {
        void SendStatusMessage(String message);
    }

    [global::System.Serializable]
    public class InitializationException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public InitializationException() { }
        public InitializationException(String message) : base(message) { }
        public InitializationException(String message, Exception inner) : base(message, inner) { }
        protected InitializationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

    public class SplashScreenContext
        : ApplicationContext
    {
        #region Helper
        delegate void ToggleToMainFormCallback(UIInitCallback uitInitMethod, String[] args);
        delegate void ShutdownUIThreadCallback();

        struct ApplicationInitData
        {
            public AutoResetEvent FinishedEvent;
            public ApplicationInitCallback InitCallback;
            public String[] CommandlineArgs;
        }
        #endregion

        #region Fields (access from first thread)
        int _minimalSplashDuration;
        ApartmentState _apartmentState = ApartmentState.STA;
        int _maxWaitForInitDuration = 2;
        bool _running = false;
        #endregion

        #region Fields (synchronization)
        AutoResetEvent _initReadyEvent = null;
        AutoResetEvent _uiReadyEvent = null;
        InitializationException _initException = null;
        #endregion

        #region Properties
        public ApartmentState UIThreadApartmentState
        {
            get { return _apartmentState; }
            set
            {
                if (_running)
                {
                    throw new ApplicationException("Application already running.");
                }
                if (value != ApartmentState.MTA &&
                    value != ApartmentState.STA &&
                    value != ApartmentState.Unknown)
                {
                    throw new ArgumentException("Illegal value");
                }
                _apartmentState = value;
            }
        }

        public int MinimumSplashDuration
        {
            get { return _minimalSplashDuration; }
            set
            {
                if (_running)
                {
                    throw new ApplicationException("Application already running.");
                }
                if (value < 0)
                {
                    _minimalSplashDuration = 0;
                }
                else
                {
                    _minimalSplashDuration = value;
                }
            }
        }

        public int MaxWaitForInitDuration
        {
            get { return _maxWaitForInitDuration; }
            set
            {
                if (_running)
                {
                    throw new ApplicationException("Application already running.");
                }
                if (value < 0)
                {
                    _maxWaitForInitDuration = 0;
                }
                else
                {
                    _maxWaitForInitDuration = value;
                }
            }
        }
        #endregion
        #region Public instance methods
        public void Run(String[] args,
            Type splashFormType,
            ApplicationInitCallback applicationInitMethod,
            UIInitCallback uiInitMethod)
        {
            _running = true;
            Thread.CurrentThread.Name = "Initial Thread";

            // Create wait handle for minimum splash duration
            _initReadyEvent = new AutoResetEvent(false);
            _uiReadyEvent = new AutoResetEvent(false);

            // Create the UI thread and start it, 
            // displays the splash screen on its own thread
            Thread uiThread = new Thread(UIThreadMethod);
            uiThread.Name = "UI Thread";
            uiThread.SetApartmentState(_apartmentState);
            uiThread.Start(splashFormType);

            // now wait for UI to be ready (will probably be almost instantaneous)
            // otherwise messages to the splash screen will fail
            if (_uiReadyEvent.WaitOne(
                new TimeSpan(0, 1, 0), false) == false)
            {
                ShutdownUIThread();
                throw new ApplicationException("The UI did not initialize in a timely fashion.");
            }

            // Create initialization data
            ApplicationInitData initData = new ApplicationInitData();
            initData.FinishedEvent = _initReadyEvent;
            initData.InitCallback = applicationInitMethod;
            initData.CommandlineArgs = (String[])args.Clone();
            // Fire up initialization thread
            Thread initializationThread = new Thread(ApplicationInitMethod);
            initializationThread.Name = "Application Init Thread";
            initializationThread.Start(initData);

            // now wait for minimum duration
            if (_minimalSplashDuration > 0)
            {
                Thread.Sleep(_minimalSplashDuration);
            }
            // now wait for init to complete
            if (_initReadyEvent.WaitOne(
                new TimeSpan(0, _maxWaitForInitDuration, 0), false) == false)
            {
                throw new ApplicationException("The application did not initialize in a timely fashion.");
            }
            if (_initException != null)
            {
                ShutdownUIThread();
                throw _initException;
            }
            MainForm.Invoke(new ToggleToMainFormCallback(ToggleToMainForm),
                uiInitMethod, args);
            if (_initException != null)
            {
                ShutdownUIThread();
                throw _initException;
            }
        }
        #endregion

        #region Private instance methods
        // Runs on UI thread
        void UIThreadMethod(object parameter)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form splashForm = (Form)Activator.CreateInstance((Type)parameter);
            MainForm = splashForm;
            _uiReadyEvent.Set();
            Application.Run(this);

        }

        // Runs on non-UI thread
        void ApplicationInitMethod(object parameter)
        {
            ApplicationInitData initData = (ApplicationInitData)parameter;
            try
            {
                initData.InitCallback(initData.CommandlineArgs,
                    new SafeSendMessageCallback(SafeSendMessage));
            }
            catch (Exception e)
            {
                _initException = new InitializationException(
                    "An error occurred during application initialization",
                    e);
            }
            initData.FinishedEvent.Set();
        }

        void ShutdownUIThread()
        {
            if (MainForm != null)
            {
                if (MainForm.InvokeRequired)
                {
                    MainForm.Invoke(
                        new ShutdownUIThreadCallback(ShutdownUIThread));
                }
                else
                {
                    MainForm.Close();
                    MainForm.Dispose();
                }
            }
        }

        void ToggleToMainForm(UIInitCallback uiInitMethod, String[] args)
        {
            Form splashForm = MainForm;
            try
            {
                MainForm = uiInitMethod(args, new SafeSendMessageCallback(SafeSendMessageFromUIThread));
            }
            catch (Exception e)
            {
                _initException = new InitializationException(
                    "An error occurred during UI initialization",
                    e);
                return;
            }
            MainForm.Shown +=
                delegate(object sender, EventArgs e)
                {
                    splashForm.Close();
                    splashForm.Dispose();
                    splashForm = null;
                };
            MainForm.Show();
        }

        void SafeSendMessage(String message)
        {
            if (MainForm.InvokeRequired)
            {
                MainForm.Invoke(
                    new SafeSendMessageCallback(SafeSendMessage), message);
            }
            else
            {
                if (MainForm is IDynamicSplashScreen)
                {
                    ((IDynamicSplashScreen)MainForm).SendStatusMessage(message);
                }
            }
        }

        void SafeSendMessageFromUIThread(String message)
        {
            SafeSendMessage(message);
            Application.DoEvents();
        }
        #endregion
    }
}
