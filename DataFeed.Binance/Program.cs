using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Common.Logging;
using Evolve.Common;



namespace DataFeed.Binance
{
    class Program
    {
        static ILog logger = LogManager.GetLogger("main");

        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            ConfigFile _cfg = ConfigFile.GetConfigFile("Handler.cfg");


            string masterSrv = _cfg["TICKSERVER"].AsString();
            int port_datasub = _cfg["DATASUBPORT"].AsInt();
            int port_cmdpub = _cfg["DATACMDPORT"].AsInt();
            int port_qry = _cfg["QRYPORT"].AsInt();


            TickPot tickpot = new TickPot(masterSrv, port_datasub);
            tickpot.Start();
            System.Threading.Thread.Sleep(1000);

            DataFeedBase datafeed = new BinanceFeed(tickpot, masterSrv, port_qry);
            datafeed.Start();
            System.Threading.Thread.Sleep(1000);


            TickPortMgr tickpotmgr = new TickPortMgr(masterSrv, port_cmdpub);


            //注册TickPot和DataFeed
            tickpotmgr.RegisterTickPort(tickpot);
            tickpotmgr.RegisterDataFeed(datafeed);

            tickpotmgr.Join();

            //feed.Subscribe("ETH/USDT");





        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            logger.Error("UnhandledException:" + ex.ToString());
        }

    }
}
