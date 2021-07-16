using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public interface IStream
    {
        public int Length { get; set; }

        public int BytesSent { get; set; }
    }
}
