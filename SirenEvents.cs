/**
 * Siren
 * Simple event notifyer
 * 
 * Created by SharpDevelop.
 * User: Enikeishik
 * Date: 19.12.2017
 * Time: 16:07
 * 
 * @copyright   Copyright (C) 2005 - 2017 Enikeishik <enikeishik@gmail.com>. All rights reserved.
 * @author      Enikeishik <enikeishik@gmail.com>
 * @license     GNU General Public License version 2 or later; see LICENSE.txt
 */

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Siren
{
    /// <summary>
    /// Siren events collection class.
    /// </summary>
    public class SirenEvents : System.Collections.IEnumerable
    {
        protected string storageFilePath;
        protected List<SirenEvent> items;
            
        public SirenEvents(string storageFilePath)
        {
            this.storageFilePath = storageFilePath;
            items = GetSirenEvents(GetEventsRaw(storageFilePath));
        }
        
        public void Add(SirenEvent se)
        {
            items.Add(se);
        }
        
        public void Add(Int32 timestamp, string text)
        {
            Add(new SirenEvent(timestamp, text));
        }
        
        public void Add(DateTime dtm, string text)
        {
            Add(new SirenEvent(dtm, text));
        }
        
        public SirenEvent Find(Int32 timestamp)
        {
            foreach (SirenEvent se in items) {
                if (se.Timestamp == timestamp)
                    return se;
            }
            return null;
        }
        
        public SirenEvent FindExpired()
        {
            Int32 timestamp = SirenEvent.GetCurretnTimestamp();
            foreach (SirenEvent se in items) {
                if (se.Timestamp <= timestamp)
                    return se;
            }
            return null;
        }
        
        public bool Remove(Int32 timestamp)
        {
            return items.Remove(Find(timestamp));
        }
        
        public void Flush()
        {
            StringBuilder sb = new StringBuilder(items.Count * 100);
            foreach (SirenEvent se in items) {
                sb.AppendLine(se.Timestamp.ToString() + '\t' + se.EventText);
            }
            SaveEventsRaw(storageFilePath, sb.ToString());
        }
        
        public void Sort()
        {
            items.Sort();
        }
        
        #region protected members
        protected static void SaveEventsRaw(string storageFilePath, string eventsRaw)
        {
            File.WriteAllText(storageFilePath, eventsRaw);
        }
        
        protected static string GetEventsRaw(string storageFilePath)
        {
            try {
                return File.ReadAllText(storageFilePath);
            } catch (FileNotFoundException) {
                File.WriteAllText(storageFilePath, "");
                return "";
            }
        }
        
        protected static List<SirenEvent> GetSirenEvents(string eventsRaw)
        {
            if ("" == eventsRaw)
                return new List<SirenEvent>();
            
            string[] items = eventsRaw.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            
            List<SirenEvent> sirenEvents = new List<SirenEvent>();
            
            foreach (string item in items) {
                string[] fields = item.Split('\t');
                if (2 != fields.Length)
                    continue;
                
                int timestamp = 0;
                if (!Int32.TryParse(fields[0], out timestamp))
                    continue;
                
                sirenEvents.Add(new SirenEvent(timestamp, fields[1]));
            }
            
            return sirenEvents;
        }
        #endregion
        
        #region IEnumerable implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
           return (IEnumerator) GetEnumerator();
        }
    
        public SirenEventsEnum GetEnumerator()
        {
            return new SirenEventsEnum(items.ToArray());
        }
        #endregion
    }
    
    public class SirenEventsEnum : IEnumerator
    {
        public SirenEvent[] items;
    
        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;
    
        public SirenEventsEnum(SirenEvent[] list)
        {
            items = list;
        }
    
        public bool MoveNext()
        {
            position++;
            return (position < items.Length);
        }
    
        public void Reset()
        {
            position = -1;
        }
    
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
    
        public SirenEvent Current
        {
            get
            {
                try
                {
                    return items[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
