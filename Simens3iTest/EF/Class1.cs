using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simens3iTest.EF
{
    public class DiskSpaceWarningEventArgs : EventArgs
    {
        private long currentFreeSpace;
        private long currentTotalSpace;
        private string driveName;

        public DiskSpaceWarningEventArgs(string name, long freeSpace, long totalSpace)
        {
            this.driveName = name;
            this.currentFreeSpace = freeSpace;
            this.currentTotalSpace = totalSpace;
        }

        public string Name
        {
            get { return this.driveName; }
        }

        public long FreeSpace
        {
            get { return this.currentFreeSpace; }
        }

        public long TotalSpace
        {
            get { return this.currentTotalSpace; }
        }
    }

    public delegate void DiskSpaceWarningEventHandler(object sender,
                                                      DiskSpaceWarningEventArgs e);

    public class DiskSpaceMonitor
    {
        public event DiskSpaceWarningEventHandler DiskSpaceWarning;
        private decimal threshhold;

        public DiskSpaceMonitor()
        {
            // Retrieve threshhold to fire event from configuration file.
            try
            {
                NameValueCollection settings = ConfigurationManager.AppSettings;
                this.threshhold = Convert.ToDecimal(settings["Threshhold"]);
            }
            // If there is no configuration file, provide a default value.
            catch (ConfigurationErrorsException)
            {
                this.threshhold = 10m;
            }
            catch (InvalidCastException)
            {
                this.threshhold = 10m;
            }
        }

        public void CheckFreeSpace()
        {
            // Get drives present on system.
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    if (drive.TotalFreeSpace / drive.TotalSize <= this.threshhold)
                        OnDiskSpaceWarning(new DiskSpaceWarningEventArgs(drive.Name,
                                           drive.TotalFreeSpace, drive.TotalSize));
                }
            }
        }

        protected void OnDiskSpaceWarning(DiskSpaceWarningEventArgs e)
        {
            if (DiskSpaceWarning != null)
                DiskSpaceWarning(this, e);
        }
    }
}
