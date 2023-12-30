using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examSubtitles
{
    class Subtitles
    {
        public Time Start { get; set; }
        public Time End { get; set; }
        public Location Location { get; set; }
        public Color Color { get; set; }
        public string Title { get; set; }
         
        public Subtitles()
        {
            Start = new Time();
            End = new Time();
            Location = Location.Bottom;
            Color = Color.White;
            Title = "*empty*";
        }
        public Subtitles(Time _start, Time _end, string _title)
        {
            Start = _start;
            End = _end;
            Title = _title;
        }
        public Subtitles(Time _start, Time _end, Location _location, Color _color, string _title)
        {
            Start = _start;
            End = _end;
            Location = _location;
            Color = _color;
            Title = _title;
        }

        public override string ToString()
        {
            return $"{Start} - {End} [{Location}, {Color}] {Title}";    
        }
        
        public static void Print(Subtitles subs)
        {
            Console.WriteLine(subs.Start);
            Console.WriteLine(subs.End);
            Console.WriteLine(subs.Location);
            Console.WriteLine(subs.Color);
            Console.WriteLine(subs.Title);
        }
    }

    class Time
    {
        //fields
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        //constructor
        public Time()
        {
            Minutes = 0;
            Seconds = 0;
        }
        public Time(int _minutes, int _seconds)
        {
            Minutes = _minutes; Seconds = _seconds;
        }

        public override string ToString()
        {
            if (Seconds.ToString().Length == 1 && Minutes.ToString().Length == 1)
            {
                return $"0{Minutes}:0{Seconds}";
            }
            else if (Seconds.ToString().Length != 1 && Minutes.ToString().Length == 1)
            {
                return $"0{Minutes}:{Seconds}";
            }
            else if (Seconds.ToString().Length == 1 && Minutes.ToString().Length != 1)
            {
                return $"{Minutes}:0{Seconds}";
            }
            return $"{Minutes}:{Seconds}";
            
        }
    }

    public enum Color
    {
        White,
        Red,
        Green,
        Blue,
    };
    public enum Location
    {
        Bottom,
        Top,
        Right,
        Left
    };
}
