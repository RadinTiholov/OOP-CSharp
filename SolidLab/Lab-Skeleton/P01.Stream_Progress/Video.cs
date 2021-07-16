using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class Video : IStream
    {
        private string name;

        public Video(string name, int length, int bytesSent)
        {
            this.name = name;
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public int Length { get; set; }

        public int BytesSent { get; set; }
    }
}
