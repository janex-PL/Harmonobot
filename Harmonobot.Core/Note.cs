namespace Harmonobot.Core
{
    public class Note
    {
        public Pitch Pitch { get; private set; }
        public Octave Octave { get; private set; }
        public byte Value { get; private set; }

        public string ScientificName => NoteDictionary.GetNoteScientificName(Pitch, Octave);
        public string HelmholtzName => NoteDictionary.GetNoteHelmholtzName(Pitch, Octave);

        public Note()
        {
            SetValue(Pitch.C, Octave.OneLine);
        }
        public Note(byte noteValue)
        {
            SetValue(noteValue);
        }

        public Note(Pitch pitch, Octave octave)
        {
            SetValue(pitch, octave);
        }

        public void SetValue(byte noteValue)
        {
            var pitchCount = MusicConstants.PitchCount;
            var octaveCount = MusicConstants.OctaveCount;

            if (noteValue > pitchCount * octaveCount)
            {
                throw new ArgumentOutOfRangeException(nameof(noteValue));
            }

            Value = noteValue;
            Pitch = (Pitch)(Value % pitchCount);
            Octave = (Octave)(Value / octaveCount);
        }

        public void SetValue(Pitch pitch, Octave octave)
        {
            if (pitch == Pitch.None)
            {
                throw new ArgumentOutOfRangeException(nameof(pitch));
            }

            if (octave == Octave.None)
            {
                throw new ArgumentOutOfRangeException(nameof(octave));
            }

            Pitch = pitch;
            Octave = octave;
            Value = (byte)((byte)octave * MusicConstants.PitchCount + pitch);
        }

    }
}
