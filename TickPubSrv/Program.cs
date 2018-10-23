using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolve.Common;

namespace TickPubSrv
{
    class Program
    {
        static void Main(string[] args)
        {

            ConfigFile _cfg = ConfigFile.GetConfigFile("TickPubSrv.cfg");

            int port_datasub = _cfg["SUBPORT"].AsInt();
            int port_datapub = _cfg["PUBPORT"].AsInt();
            int port_mgrreq = _cfg["MGRREQ"].AsInt();
            int port_mgrpub = _cfg["MGRPUB"].AsInt();

            TickServer tickSrv = new TickServer(port_datasub, port_datapub);
            tickSrv.Start();

            TickServerMgr tickSrvMgr= new TickServerMgr(port_mgrreq, port_mgrpub);
            tickSrvMgr.Join();


        }
    }
}
