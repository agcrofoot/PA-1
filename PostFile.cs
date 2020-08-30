using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA1
{
    public class PostFile
    {
        public static List<Posts> GetPosts()
        {
            List<Posts> BigAlsPosts = new List<Posts>();
            StreamReader inFile = null;
            try
            {
                inFile = new StreamReader(@"C:\Users\birdc\source\repos\PA1\posts.txt");
            }
            catch
            {
                Console.WriteLine("Something went wrong.");
            }

            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split("#");
                int id = int.Parse(temp[0]);
                BigAlsPosts.Add(new Posts(){ID = id, Text = temp[1], Timestamp = temp[2]});
                line = inFile.ReadLine();
            }

            inFile.Close();

            return BigAlsPosts;
        }

        public static void SavePost(Posts newPost)
        {
            StreamWriter outFile = File.AppendText(@"C:\Users\birdc\source\repos\PA1\posts.txt");
            outFile.WriteLine(newPost.ToFile());
            outFile.Close();
        }

        public static void Save(List<Posts> BigAlsPosts)
        {
            StreamWriter outFile = new StreamWriter(@"C:\Users\birdc\source\repos\PA1\posts.txt");
            foreach(Posts post in BigAlsPosts)
            {
                outFile.WriteLine(post.ToFile());
            }
            outFile.Close();
        }
    }
}