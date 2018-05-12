using System;
using System.Collections.Generic;
using IronWebScraper;

namespace SafeWebScrapper.Example
{
    public class JobBoerseScraper : WebScraper
    {
        private const string FooterMenuSlector = "div.klicksucheliste ul.liste li span.klicksucheeintrag a[href]";
        private const string ContentTableSelector = "table#tabellenanfang tbody tr td:first-child a[href] span";
        private const string TablePageSelector = "div.ergebnisPaginierung a[href] img[src='images/icons/paginierung_rechts_aktiv.gif'][title]";
        private readonly string _url;

        public JobBoerseScraper(string url)
        {
            _url = url;
        }

        public override void Init()
        {
            LoggingLevel = LogLevel.All;

            Request(_url, Parse);
        }

        public override void Parse(Response response)
        {
            //footer menus
            if (response.CssExists(FooterMenuSlector))
            {
                var footerMenus = response.Css(FooterMenuSlector);

                foreach (var footerMenu in footerMenus)
                {
                    var url = footerMenu.Attributes["href"];
                    var text = footerMenu.TextContentClean;

                    Scrape(new ScrapedData { { "Menu", text }, { "Url", url } });

                    Request(url, Parse);
                }
            }
            else
            {
                //content table
                if (response.CssExists(ContentTableSelector))
                {
                    foreach (var contentCell in response.Css(ContentTableSelector))
                    {
                        var text = contentCell.TextContentClean;
                        var url = contentCell.ParentNode.Attributes["href"];

                        Scrape(new ScrapedData { { "Title", text }, { "Url", url } });
                    }
                }

                //table page
                if (response.CssExists(TablePageSelector))
                {
                    foreach (var tablePage in response.Css(TablePageSelector))
                    {
                        var url = tablePage.ParentNode.Attributes["href"];
                        var text = tablePage.Attributes["title"];

                        Scrape(new ScrapedData { { "Page", text }, { "Url", url } });

                        Request(url, Parse);
                    }
                }
            }

        }

    }
}