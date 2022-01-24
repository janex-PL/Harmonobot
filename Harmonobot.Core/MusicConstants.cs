namespace Harmonobot.Core
{
    public static class MusicConstants
    {
        public static int OctaveCount = Enum.GetValues<Octave>().Length - 1;

        public static int PitchCount = Enum.GetValues<Pitch>().Length - 1;
        public static int IntervalRollover = Enum.GetValues<Interval>().Length;
    }
}
