using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmonobot.Core
{
    public class NoteCollection
    {
        public List<Note> Notes { get; private set; }
        public List<Interval> AbsoluteIntervals { get; private set; }
        public List<Interval> RelativeIntervals { get; private set; }
        public Note RootNote =>
            Notes.FirstOrDefault() ?? throw new InvalidOperationException("Collection of notes is empty");

        public NoteCollection()
        {
            Notes = new List<Note>();
            AbsoluteIntervals = new List<Interval>();
            RelativeIntervals = new List<Interval>();
        }

        public void AddNote(Note newNote)
        {
            if (Notes.Any(n => n.Value == newNote.Value))
                throw new ArgumentException("Note already exists in collection", nameof(newNote));

            Notes.Add(newNote);

            SortNotes();
            
            CalculateIntervalsFromNotes();
        }

        public void AddAbsoluteInterval(Interval newInterval)
        {
            if (newInterval == Interval.None)
                throw new ArgumentException("Interval must have specified value", nameof(newInterval));
        }

        private void CalculateIntervalsFromNotes()
        {
            if (!Notes.Any())
                throw new InvalidOperationException("Collection of notes is empty");

            AbsoluteIntervals = Notes.Select(n => (Interval)((n.Value - Notes.First().Value) % MusicConstants.IntervalRollover)).ToList();
        }

        private void SortNotes()
        {
            Notes = Notes.OrderBy(n => n.Octave).ThenBy(n => n.Pitch).ToList();
        }
    }
}
