using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA1
{
    public class Posts : IComparable<Posts>, IEquatable<Posts>
    {
       public int ID{get; set;}
       public string Text{get; set;}
       public string Timestamp{get; set;}

       public int CompareTo(Posts temp)
       {
           return temp.Timestamp.CompareTo(this.Timestamp);
       }

       public string ToFile()
       {
           return ID + "#" + Text + "#" + Timestamp;
       }

       public bool Equals(Posts temp)
       {
           if(temp == null) return false;
           return (this.ID.Equals(temp.ID));
       }
    }
}