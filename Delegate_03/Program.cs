using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_03
{
    class Program
    {
        static void Main(string[] args)
        {
            var MediaStorageInstance = new MediaStorage();
            var AudioPlayerInstance = new AudioPlayer();
            var AudioPlayerDelegateInstance = new MediaStorage.PlayMedia(AudioPlayerInstance.PlayAudioFile);
            MediaStorageInstance.ReportResult(AudioPlayerDelegateInstance);
        }
    }

    
    class MediaStorage
    {
        public delegate int PlayMedia();

        public void ReportResult(PlayMedia delegateInstanceVariable)
        {
            if (delegateInstanceVariable() == 0)
            {
                Console.WriteLine("Test play file - all good");
            }
            else
            {
                Console.WriteLine("Cannot play file");
            }
        }

       
    }

    class AudioPlayer
    {
        private int audioPlayerStatus;

        public int PlayAudioFile()
        {
            Console.WriteLine("Playing File");
            audioPlayerStatus = 0;
            return audioPlayerStatus;
        }
    }
}
