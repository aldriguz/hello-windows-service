using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.Timers;

namespace HelloWindowsService
{
    public partial class HelloService : ServiceBase
    {
        private int eventId = 0;
        public HelloService()
        {
            InitializeComponent();
            myEventLog = new EventLog();
            var source = nameof(HelloService);
            var logName = $"{source}Log";
            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, logName);
            }
            myEventLog.Source = source;
            myEventLog.Log = logName;
        }

        protected override void OnStart(string[] args)
        {
            myEventLog.WriteEntry("Service started!", EventLogEntryType.Information, ++eventId);
        }

        protected override void OnStop()
        {
            myEventLog.WriteEntry("Here comes the end! :c", EventLogEntryType.Information, ++eventId);
        }

        
        //No common events added

        protected override void OnPause()
        {
            base.OnPause();
        }

        protected override void OnContinue()
        {
            base.OnContinue();
        }

        protected override void OnShutdown()
        {
            base.OnShutdown();
        }


        #region private methods
        private void SetPollingMechanism()
        {
            Timer timer = new Timer();
            timer.Interval = TimeSpan.FromHours(1).TotalMilliseconds; //in milliseconds
            timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }

        private void OnTimer(object sender, ElapsedEventArgs args)
        {
            //TODO: Insert monitoring or alert code here
            myEventLog.WriteEntry("Bang!!!! OnTimer event executed...", EventLogEntryType.Information, ++eventId);
        }
        #endregion
    }
}
