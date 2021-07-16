using System;
using System.Collections.Generic;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            List<IStream> streams = new List<IStream>();
            Video video = new Video("asd", 12, 101);
            Music music = new Music("asd","tba", 12, 101);
            File gosho_exe = new File("asd", 12, 101);
            StreamProgressInfo musicProgressInfo = new StreamProgressInfo(music);
            StreamProgressInfo videoProgressInfo = new StreamProgressInfo(video);
            StreamProgressInfo fileProgressInfo = new StreamProgressInfo(gosho_exe);
            
        }
    }
}
