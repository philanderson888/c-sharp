using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_04
{
    class Program
    {
        static void Main(string[] args)
        {
            var Container = new VideoPlayerShell();
            var CodecChooser = new VideoCodecs(); // fix codec
            CodecChooser.PlayWithFixedCodec();  // fix codec choice

            // Allow variety
            var inputChoice = 1;
            var delegateInstance01 = new VideoPlayerShell.myDelegate(CodecChooser.PlayWithCodec01);
            var delegateInstance02 = new VideoPlayerShell.myDelegate(CodecChooser.PlayWithCodec02);
            var success = 0;
            if (inputChoice == 1)
            {
                success = Container.PlayFile(delegateInstance01);
            }
            else{
                success = Container.PlayFile(delegateInstance02);
            }
            Console.WriteLine("Successful? {0} ",Convert.ToBoolean(success));
        }
    }

    class VideoPlayerShell
    {
        public delegate int myDelegate();  // USE TO PLAY VIDEOS BUT DON'T SPECIFY A METHOD YET

        public int PlayFile(VideoPlayerShell.myDelegate videoDelegateInstance)
        {
            return videoDelegateInstance();
        }

    }

    class VideoCodecs
    {
        public int PlayWithCodec01()
        {
            Console.WriteLine("Using Codec01");
            return 1;
        }

        public int PlayWithCodec02()
        {
            Console.WriteLine("Using Codec02");
            return 1;
        }

        public int PlayWithFixedCodec()
        {
            Console.WriteLine("Playing with fixed codec");
            return 1;
        }


    }






}
