using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using Scraper.Shared;
using System.Web;
using System.Windows.Forms;
using HtmlAgilityPack;
using Jobboerse;
using Databox.Libs.Jobboerse;

namespace WheelsScraper
{
    public sealed class Jobboerse : BaseScraper
    {
        public Jobboerse()
        {
            Name = "Jobboerse";
            Url = "http://jobboerse.arbeitsagentur.de/vamJB/stellenangeboteFinden.html";
            PageRetriever.Referer = Url;
            WareInfoList = new List<ExtWareInfo>();
            Wares.Clear();
            BrandItemType = 2;
            SpecialSettings = new ExtSettings();

        }

        private ExtSettings extSett
        {
            get
            {
                var ctrl = (ucExtSettings)SettingsTab;

                return ctrl.ExtSett;
            }
        }

        public override Type[] GetTypesForXmlSerialization()
        {
            return new Type[] { typeof(ExtSettings) };
        }

        public override Control SettingsTab
        {
            get
            {
                var frm = new ucExtSettings
                {
                    Sett = Settings
                };

                return frm;
            }
        }

        public override WareInfo WareInfoType
        {
            get
            {
                return new ExtWareInfo();
            }
        }

        protected override bool Login()
        {
            return true;
        }

        protected override void RealStartProcess()
        {
            lstProcessQueue.Add(new ProcessQueueItem
            {
                URL = Url,
                ItemType = 1
            });
            StartOrPushPropertiesThread();
        }

        private void ProcessBrandsListPage(ProcessQueueItem pqi)
        {
            if (cancel)
                return;

            pqi.Processed = true;
            MessagePrinter.PrintMessage("Brands list processed");
            StartOrPushPropertiesThread();
        }

        protected override Action<ProcessQueueItem> GetItemProcessor(ProcessQueueItem item)
        {

            Action<ProcessQueueItem> act;

            if (item.ItemType == 1)
                act = ProcessBrandsListPage;

            else act = null;

            return act;
        }
    }
}
