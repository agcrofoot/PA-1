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
        //Established getters and setters
       public int ID{get; set;}
       public string Text{get; set;}
       public string Timestamp{get; set;}

       //Uses the IComparable to compare Timestamps of each post
       public int CompareTo(Posts temp)
       {
           return temp.Timestamp.CompareTo(this.Timestamp);
       }

       //Gets the posts ready to be saved to the file
       public string ToFile()
       {
           return ID + "#" + Text + "#" + Timestamp;
       }

       //Uses the IEquatable to see if one ID is equal to another
       public bool Equals(Posts temp)
       {
           if(temp == null) return false;
           return (this.ID.Equals(temp.ID));
       }
    }
}
