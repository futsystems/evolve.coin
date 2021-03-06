﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolve.Common
{
    public class Utils
    {

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public static DateTime JavaTimeStampToDateTime(double javaTimeStamp)
        {
            // Java timestamp is milliseconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(javaTimeStamp).ToLocalTime();
            return dtDateTime;
        }


        #region TLDate and TLTime
        /// <summary>
        /// Converts date to DateTime (eg 20070926 to "DateTime.Mon = 9, DateTime.Day = 26, DateTime.ShortDate = Sept 29, 2007"
        /// </summary>
        /// <param name="TradeLinkDate"></param>
        /// <returns></returns>
        public static DateTime TLD2DT(int TradeLinkDate)
        {
            if (TradeLinkDate < 10000) throw new Exception("Not a date, or invalid date provided");
            return ToDateTime(TradeLinkDate, 0);
        }
        /// <summary>
        /// Converts  Time to DateTime.  If not using seconds, put a zero.
        /// </summary>
        /// <param name="TradeLinkTime"></param>
        /// <param name="TradeLinkSec"></param>
        /// <returns></returns>
        public static DateTime TLT2DT(int TradeLinkTime)
        {
            return ToDateTime(0, TradeLinkTime);
        }



        public static DateTime ToDateTime(long tldatetime)
        {
            int date = (int)(tldatetime / 1000000);
            int time = (int)(tldatetime - date * 1000000);
            return ToDateTime(date, time);
        }

        /// <summary>
        /// Converts TradeLink Date and Time format to a DateTime. 
        /// eg DateTime ticktime = ToDateTime(tick.date,tick.time);
        /// </summary>
        /// <param name="TradeLinkDate"></param>
        /// <param name="TradeLinkTime"></param>
        /// <param name="TradeLinkSec"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(int TradeLinkDate, int TradeLinkTime)
        {
            int sec = TradeLinkTime % 100;
            int hm = TradeLinkTime % 10000;
            int hour = (int)((TradeLinkTime - hm) / 10000);
            int min = (TradeLinkTime - (hour * 10000)) / 100;
            if (sec > 59) { sec -= 60; min++; }
            if (min > 59) { hour++; min -= 60; }
            int year = 1, day = 1, month = 1;
            if (TradeLinkDate != 0)
            {
                int ym = (TradeLinkDate % 10000);
                year = (int)((TradeLinkDate - ym) / 10000);
                int mm = ym % 100;
                month = (int)((ym - mm) / 100);
                day = mm;
            }
            return new DateTime(year, month, day, hour, min, sec);
        }

        /// <summary>
        /// gets fasttime/tradelink time for now
        /// </summary>
        /// <returns></returns>
        public static int DT2FT() { return DT2FT(DateTime.Now); }
        /// <summary>
        /// converts datetime to fasttime format
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static int DT2FT(DateTime d) { return TL2FT(d.Hour, d.Minute, d.Second); }
        /// <summary>
        /// converts tradelink time to fasttime
        /// </summary>
        /// <param name="hour"></param>
        /// <param name="min"></param>
        /// <param name="sec"></param>
        /// <returns></returns>
        public static int TL2FT(int hour, int min, int sec) { return hour * 10000 + min * 100 + sec; }
        /// <summary>
        /// gets fasttime from a tradelink tick
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static int TL2FT(Tick t) { return t.Time; }
        /// <summary>
        /// gets elapsed seconds between two fasttimes
        /// </summary>
        /// <param name="firsttime"></param>
        /// <param name="latertime"></param>
        /// <returns></returns>
        public static int FTDIFF(int firsttime, int latertime)
        {
            int span1 = FT2FTS(firsttime);
            int span2 = FT2FTS(latertime);
            return span2 - span1;
        }
        /// <summary>
        /// converts fasttime to fasttime span, or elapsed seconds
        /// 获得fasttime对应的秒数
        /// </summary>
        /// <param name="fasttime"></param>
        /// <returns></returns>
        public static int FT2FTS(int fasttime)
        {
            int s1 = fasttime % 100;
            int m1 = ((fasttime - s1) / 100) % 100;
            int h1 = (int)((fasttime - (m1 * 100) - s1) / 10000);
            return h1 * 3600 + m1 * 60 + s1;
        }
        /// <summary>
        /// adds fasttime and fasttimespan (in seconds).  does not rollover 24hr periods.
        /// </summary>
        /// <param name="firsttime"></param>
        /// <param name="secondtime"></param>
        /// <returns></returns>
        public static int FTADD(int firsttime, int fasttimespaninseconds)
        {
            int s1 = firsttime % 100;
            int m1 = ((firsttime - s1) / 100) % 100;
            int h1 = (int)((firsttime - m1 * 100 - s1) / 10000);
            s1 += fasttimespaninseconds;
            if (s1 >= 60)
            {
                m1 += (int)(s1 / 60);
                s1 = s1 % 60;
            }
            if (m1 >= 60)
            {
                h1 += (int)(m1 / 60);
                m1 = m1 % 60;
            }
            int sum = h1 * 10000 + m1 * 100 + s1;
            return sum;


        }
        /// <summary>
        /// converts fasttime to a datetime
        /// </summary>
        /// <param name="ftime"></param>
        /// <returns></returns>
        public static DateTime FT2DT(int ftime)
        {
            int s = ftime % 100;
            int m = ((ftime - s) / 100) % 100;
            int h = (int)((ftime - m * 100 - s) / 10000);
            return new DateTime(1, 1, 1, h, m, s);
        }



        public static long ToTLDateTime(int tldate, int tltime) { return (long)tldate * 1000000 + (long)tltime; }

        
        /// <summary>
        /// get long for date + time
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static long ToTLDateTime(DateTime dt)
        {
            if (dt == DateTime.MinValue) return long.MinValue;
            if (dt == DateTime.MaxValue) return long.MaxValue;

            return ((long)ToTLDate(dt) * 1000000) + (long)ToTLTime(dt);
        }

       
        /// <summary>
        /// Converts a DateTime to TradeLink Date (eg July 11, 2006 = 20060711)
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static int ToTLDate(DateTime dt)
        {

            return (dt.Year * 10000) + (dt.Month * 100) + dt.Day;
        }
        /// <summary>
        /// Converts a DateTime.Ticks values to TLDate (eg 8million milliseconds since 1970 ~= 19960101 (new years 1996)
        /// </summary>
        /// <param name="DateTimeTicks"></param>
        /// <returns></returns>
        public static int ToTLDate(long DateTimeTicks)
        {
            return ToTLDate(new DateTime(DateTimeTicks));
        }
       
        /// <summary>
        /// gets tradelink time from date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int ToTLTime(DateTime date)
        {
            return DT2FT(date);
        }


        /// <summary>
        /// Converts a TLDate integer format into an array of ints
        /// </summary>
        /// <param name="fulltime">The fulltime.</param>
        /// <returns>int[3] { year, month, day}</returns>
        static int[] TLDateSplit(int fulltime)
        {
            int[] splittime = new int[3]; // year, month, day
            splittime[2] = (int)((double)fulltime / 10000);
            splittime[1] = (int)((double)(fulltime - (splittime[2] * 10000)) / 100);
            double tmp = (int)((double)fulltime / 100);
            double tmp2 = (double)fulltime / 100;
            splittime[0] = (int)(Math.Round(tmp2 - tmp, 2, MidpointRounding.AwayFromZero) * 100);
            return splittime;
        }





        #endregion
    }
}
