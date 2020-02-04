namespace Sandbox.Models
{
    using System;

    public class LyricModel
    {
        public string artist { get; set; }

        public string song { get; set; }

        public string link { get; set; }

        public string text { get; set; }

        public override string ToString()
        {
            return $"Artist - {artist} | Song {song}{Environment.NewLine}Text {text}Environment.NewLine"; 
        }
    }
}
