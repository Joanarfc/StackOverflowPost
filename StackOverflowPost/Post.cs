using System;
using System.Collections.Generic;

namespace StackOverflowPost
{
    public class Post
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTimeCreated { get; private set; }

        private readonly List<int> VotesCounter = new List<int>();

        public Post()
        {
            DateTimeCreated = DateTime.Now;
        }

        public Post(string title, string description) : this()
        {
            Title = title;
            Description = description;
        }

        public string DisplayPost()
        {
            if (!String.IsNullOrWhiteSpace(Title) || !String.IsNullOrWhiteSpace(Description))
            {
                string fullPost = Title + " " + Description + " " + DateTimeCreated;
                return fullPost;
            }
            else
            {
                throw new InvalidOperationException("No post was inserted.");
            }

        }

        public void UpVote()
        {
            VotesCounter.Add(1);
        }

        public void DownVote()
        {
            VotesCounter.Remove(1);
        }

        public int TotalVotes()
        {
            return VotesCounter.Count;
        }
    }
}
