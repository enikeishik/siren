/**
 * Siren
 * Simple event notifyer
 * 
 * Created by SharpDevelop.
 * User: Enikeishik
 * Date: 19.12.2017
 * Time: 11:05
 * 
 * @copyright   Copyright (C) 2005 - 2017 Enikeishik <enikeishik@gmail.com>. All rights reserved.
 * @author      Enikeishik <enikeishik@gmail.com>
 * @license     GNU General Public License version 2 or later; see LICENSE.txt
 */

using System;

namespace Siren
{
    /// <summary>
    /// Siren event representation class.
    /// </summary>
    public class SirenEvent : IComparable
    {
        public static readonly DateTime dtmUnixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).ToLocalTime();
        public int Timestamp;
        public string EventText;
        
        public static Int32 GetCurretnTimestamp()
        {
            return (Int32) (DateTime.Now.Subtract(dtmUnixStart)).TotalSeconds;
        }
        
        public static DateTime GetDateTimeFromTimestamp(Int32 timestamp)
        {
            return dtmUnixStart.AddSeconds(timestamp).ToLocalTime();
        }
        
        public static Int32 GetTimestampFromDateTime(DateTime dtm)
        {
            return (Int32) (dtm.Subtract(dtmUnixStart)).TotalSeconds;
        }
        
        public DateTime DateTimeFromTimestamp
        {
            get
            {
                return GetDateTimeFromTimestamp(Timestamp);
            }
        }
        
        public bool Expired
        {
            get
            {
                return Timestamp <= GetCurretnTimestamp();
            }
        }
        
        public SirenEvent(Int32 t, string s)
        {
            Timestamp = t;
            EventText = s;
        }
        
        public SirenEvent(DateTime dtm, string s)
        {
            Timestamp = GetTimestampFromDateTime(dtm);
            EventText = s;
        }
        
        #region IComparable implementation
        public int CompareTo(object obj)
        {
            if (null == obj)
                return 1;
            
            SirenEvent otherSirenEvent = obj as SirenEvent;
            if (otherSirenEvent != null)
                return this.Timestamp.CompareTo(otherSirenEvent.Timestamp);
            
            throw new ArgumentException("Object is not a SirenEvent");
        }
        #endregion
    }

}
