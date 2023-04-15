using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace QuanLySanXuatJuKi
{
    public class TimerScan
    {
        #region bien 
        private readonly System.Timers.Timer _timer;
        private DateTime _lastScanTime;
        public TimeSpan ScanTime { get; private set; }
        public event EventHandler ValuesRefreshed;


        private static readonly Lazy<TimerScan> _instance = new Lazy<TimerScan>(() => new TimerScan());
        public static TimerScan Instance
        {
            get
            {
                return _instance.Value;
            }
        }
        #endregion

        public TimerScan()
        {
            _timer = new System.Timers.Timer();
            //_timer.Interval = Properties.Settings.Default.TimerScan;
            //thời gian quét
            _timer.Interval = 500;

            _timer.Start();
            _timer.Elapsed += OnTimerElapsed;
        }

        #region ham trong plc
        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                _timer.Stop();
                ScanTime = DateTime.Now - _lastScanTime;
                OnValuesRefreshed();
            }
            finally
            {
                _timer.Start();
            }
            _lastScanTime = DateTime.Now;
        }
        private void OnValuesRefreshed()
        {
            ValuesRefreshed?.Invoke(this, new EventArgs());
        }
        #endregion
    }
    public class TimerScan3s
    {
        #region bien 
        private readonly System.Timers.Timer _timer;
        private DateTime _lastScanTime;
        public TimeSpan ScanTime { get; private set; }
        public event EventHandler ValuesRefreshed;


        private static readonly Lazy<TimerScan3s> _instance = new Lazy<TimerScan3s>(() => new TimerScan3s());
        public static TimerScan3s Instance
        {
            get
            {
                return _instance.Value;
            }
        }
        #endregion

        public TimerScan3s()
        {
            _timer = new System.Timers.Timer();
            //_timer.Interval = Properties.Settings.Default.TimerScan3s;
            //thời gian quét
            _timer.Interval = 3000;

            _timer.Start();
            _timer.Elapsed += OnTimerElapsed;
        }

        #region ham trong plc
        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                _timer.Stop();
                ScanTime = DateTime.Now - _lastScanTime;
                OnValuesRefreshed();
            }
            finally
            {
                _timer.Start();
            }
            _lastScanTime = DateTime.Now;
        }





        private void OnValuesRefreshed()
        {
            ValuesRefreshed?.Invoke(this, new EventArgs());
        }


        #endregion




    }


}
