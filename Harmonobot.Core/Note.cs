namespace Harmonobot.Core
{
    public class Note
    {
        public Pitch Pitch { get; private set; }
        public Octave Octave { get; private set; }
        public byte Value { get; private set; }
        public string ScientificName { get; private set; } = string.Empty;
        public string HelmholtzName { get; private set; } = string.Empty;
        public string PitchName { get; private set; } = string.Empty;

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
            UpdateNames();
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
            UpdateNames();
        }

        private void UpdateNames()
        {
            if (Pitch == Pitch.None)
            {
                throw new InvalidOperationException(
                    $"Property '{nameof(Pitch)}' must be different than default value");
            }

            if (Octave == Octave.None)
            {
                throw new InvalidOperationException(
                    $"Property '{nameof(Octave)}' must be different than default value");
            }

            PitchName = NoteDictionary.GetPitchName(Pitch);
            ScientificName = NoteDictionary.GetNoteScientificName(Pitch, Octave);
            HelmholtzName = NoteDictionary.GetNoteHelmholtzName(Pitch, Octave);
        }

    }
}
