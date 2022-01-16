namespace Harmonobot.Core;

public static class NoteDictionary
{
    public static readonly string[] PitchNames = {"C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"};

    public static readonly string[] ScientificOctaveNames = {"-1", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};

    public static readonly string[] HelmholtzOctaveNames =
        {",,,", ",,", ",", "", "'", "''", "'''", "''''", "'''''", "''''''"};

    public static string GetPitchName(Pitch pitch) => pitch != Pitch.None
        ? PitchNames[(int) pitch]
        : throw new ArgumentOutOfRangeException(nameof(pitch));

    public static string GetScientificOctaveName(Octave octave) => octave != Octave.None
        ? ScientificOctaveNames[(int) octave]
        : throw new ArgumentOutOfRangeException(nameof(octave));

    public static string GetHelmholtzOctaveName(Octave octave) => octave != Octave.None
        ? HelmholtzOctaveNames[(int)octave]
        : throw new ArgumentOutOfRangeException(nameof(octave));

    public static string GetNoteScientificName(Pitch pitch, Octave octave) =>
        GetPitchName(pitch) + GetScientificOctaveName(octave);
    public static string GetNoteHelmholtzName(Pitch pitch, Octave octave) =>
        GetPitchName(pitch) + GetHelmholtzOctaveName(octave);
}