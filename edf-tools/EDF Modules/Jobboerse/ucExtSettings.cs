using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using WheelsScraper;

namespace Databox.Libs.Jobboerse
{
    public partial class ucExtSettings : XtraUserControl
    {
        private ScraperSettings _sett;

        public ucExtSettings()
        {
            InitializeComponent();
        }

        public ExtSettings ExtSett
        {
            get
            {
                return (ExtSettings)Sett.SpecialSettings;
            }
        }


        public ScraperSettings Sett
        {
            get { return _sett; }
            set
            {
                _sett = value;
                if (_sett != null) RefreshBindings();
            }
        }

        protected void RefreshBindings()
        {
             
        }

        private void ucExtSettings_Load(object sender, EventArgs e)
        {
        }
    }
}
