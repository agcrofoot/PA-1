using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA1
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        public static void Menu()
        {
            Console.Clear();
            int menuChoice = 0;
            while(menuChoice != 4)
            {
                Console.WriteLine("Enter '1' to show all posts.");
                Console.WriteLine("Enter '2' to add a post.");
                Console.WriteLine("Enter '3' to delete a post.");
                Console.WriteLine("Enter '4' to exit.");
                try
                {
                    menuChoice = int.Parse(Console.ReadLine());
                    if(menuChoice < 1 || menuChoice > 4)
                    {
                        throw new Exception("Please enter a valid input.");
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Press any key to return to the Menu.");
                    Console.ReadKey();
                    Menu();
                }
                finally
                {
                    if(menuChoice == 1)
                    {
                        Console.Clear();
                        List<Posts> BigAlsPosts = PostFile.GetPosts();
                        BigAlsPosts.Sort();
                        foreach(Posts post in BigAlsPosts)
                        {
                            Console.WriteLine("Post ID " + post.ID + " " + post.Text + " " + post.Timestamp);
                        }

                        Console.WriteLine("Press any key to return to the Menu.");
                        Console.ReadKey();
                        Menu();
                    }
                    else if(menuChoice == 2)
                    {
                        Console.Clear();
                        List<Posts> BigAlsPosts = PostFile.GetPosts();
                        List<int> postIDs = new List<int>();
                        if(BigAlsPosts.Count == 0)
                        {
                            Console.WriteLine("Enter your post.");
                            Posts newPost = new Posts(){ID = 1, Text = Console.ReadLine(), Timestamp = DateTime.Now.ToString()};
                            Console.WriteLine("Post ID " + newPost.ID + " " + newPost.Text + " " + newPost.Timestamp);
                            PostFile.SavePost(newPost);
                        }
                        else
                        {
                            foreach(Posts post in BigAlsPosts)
                            {
                                postIDs.Add(post.ID);
                            }
                            int lastPost = postIDs.Max();
                            int currentPost = lastPost + 1;
                            Console.WriteLine("Enter your post.");
                            Posts newPost = new Posts(){ID = currentPost, Text = Console.ReadLine(), Timestamp = DateTime.Now.ToString()};
                            Console.WriteLine("Post ID " + newPost.ID + " " + newPost.Text + " " + newPost.Timestamp);
                            PostFile.SavePost(newPost);

                        }
                        
                        Console.WriteLine("Press any key to return to the Menu.");
                        Console.ReadKey();
                        Menu();
           
                    }
                    else if(menuChoice == 3)
                    {
                        Console.Clear();
                        List<Posts> BigAlsPosts = PostFile.GetPosts();
                        List<int> postIDs = new List<int>();
                        if(BigAlsPosts.Count == 0)
                        {
                            Console.WriteLine("There are no posts to delete.");
                        }
                        else
                        {
                            BigAlsPosts.Sort();
                            foreach(Posts post in BigAlsPosts)
                            {
                                Console.WriteLine("Post ID " + post.ID + " " + post.Text + " " + post.Timestamp);
                                postIDs.Add(post.ID);
                            }
                            while(true)
                            {
                                Console.WriteLine("Enter the ID of the post you wish to delete.");
                                try
                                {
                                    int deleteID = int.Parse(Console.ReadLine());
                                    int lastPost = postIDs.Max();
                                    int firstPost = postIDs.Min();
                                    if(deleteID < firstPost || deleteID > lastPost)
                                    {
                                        throw new Exception("Please enter a valid ID.");
                                    }
                                    else
                                    {
                                        BigAlsPosts.Remove(new Posts(){ID = deleteID, Text = " ", Timestamp = " "});
                                        foreach(Posts post in BigAlsPosts)
                                        {
                                            Console.WriteLine("Post ID " + post.ID + " " + post.Text + " " + post.Timestamp);
                                        }
                                        PostFile.Save(BigAlsPosts);
                                        Console.WriteLine("Press any key to return to the Menu.");
                                        Console.ReadKey();
                                        break;
                                    }
                                }
                                catch(Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                    continue;
                                }
                            }
                        }
                    }
                    else if(menuChoice == 4)
                    {
                        Console.Clear();
                        System.Environment.Exit(0);
                    }
                }
            }
        }
    }
}