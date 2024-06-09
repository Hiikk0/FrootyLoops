using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FrootyLoops.Services;

namespace FrootyLoops.UserControls.SettingsContent
{
    /// <summary>
    /// Логика взаимодействия для WhatsNew.xaml
    /// </summary>
    public partial class WhatsNew : UserControl
    {
        public WhatsNew()
        {
            InitializeComponent();
            Load();
        }

        public void Load()
        {
            flowDocumentViewer.Document = MarkdownWorker.MarkdownRender(App.STDPATH + "/Data/Info/ChangeLog.md");
        }
    }
}
