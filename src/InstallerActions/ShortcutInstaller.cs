using System.Collections;
using System.ComponentModel;

namespace InstallerActions
{
    [RunInstaller(true)]
    public partial class ShortcutInstaller : System.Configuration.Install.Installer
    {
        public ShortcutInstaller()
        {
            InitializeComponent();
        }
        protected override void OnCommitted(IDictionary savedState)
        {
            base.OnCommitted(savedState);
            IWshRuntimeLibrary.WshShell WshShell = new IWshRuntimeLibrary.WshShell();
            object strDesktop = (object)"Desktop";
            string shortcutAddress = (string)WshShell.SpecialFolders.Item(ref strDesktop)
                                     + @"\Shortcut to my application.lnk";
            IWshRuntimeLibrary.IWshShortcut oShellLink = 
                (IWshRuntimeLibrary.IWshShortcut)WshShell.CreateShortcut(shortcutAddress);
            oShellLink.Hotkey = "Ctrl+Alt+A";
            oShellLink.Save();
        }
    }
}
