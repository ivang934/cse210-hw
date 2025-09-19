using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    /// <summary>
    /// Represents the scripture reference (e.g., "John 3:16" or "Proverbs 3:5-6")
    /// </summary>
    public class Reference
    {
        private string _book;
        private int _chapter;
        private int _verse;
        private int? _endVerse;

        // Single verse constructor
        public Reference(string book, int chapter, int verse)
        {
            _book = book;
            _chapter = chapter;
            _verse = verse;
            _endVerse = null;
        }

        // Verse range constructor
        public Reference(string book, int chapter, int startVerse, int endVerse)
        {
            _book = book;
            _chapter = chapter;
            _verse = startVerse;
            _endVerse = endVerse;
        }

        public string GetDisplayText()
        {
            return _endVerse.HasValue
                ? $"{_book} {_chapter}:{_verse}-{_endVerse.Value}"
                : $"{_book} {_chapter}:{_verse}";
        }
    }

    /// <summary>
    /// Represents a word in the scripture. Handles hiding (replacing with underscores).
    /// </summary>
    public class Word
    {
        private string _text;
        private bool _isHidden;

        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        public void Hide() => _isHidden = true;
        public void Show() => _isHidden = false;
        public bool IsHidden() => _isHidden;

        public string GetDisplayText()
        {
            if (!_isHidden) return _text;

            // Replace only letters with underscores, keep punctuation
            char[] arr = _text.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (char.IsLetter(arr[i]))
                    arr[i] = '_';
            }
            return new string(arr);
        }
    }

    /// <summary>
    /// Represents the full scripture (reference + list of words).
    /// </summary>
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
        private static Random _random = new Random();

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            var tokens = text.Split(' ');
            _words = tokens.Select(t => new Word(t)).ToList();
        }

        /// <summary>
        /// Hide a number of random words (only those not already hidden).
        /// </summary>
        public void HideRandomWords(int numberToHide)
        {
            var visibleIndices = _words
                .Select((w, i) => new { w, i })
                .Where(x => !x.w.IsHidden())
                .Select(x => x.i)
                .ToList();

            if (visibleIndices.Count == 0) return;

            int hideCount = Math.Min(numberToHide, visibleIndices.Count);

            for (int k = 0; k < hideCount; k++)
            {
                int idx = _random.Next(visibleIndices.Count);
                int wordIndex = visibleIndices[idx];
                _words[wordIndex].Hide();
                visibleIndices.RemoveAt(idx);
            }
        }

        public string GetDisplayText()
        {
            var text = string.Join(" ", _words.Select(w => w.GetDisplayText()));
            return $"{_reference.GetDisplayText()}\n{text}";
        }

        public bool IsCompletelyHidden()
        {
            return _words.All(w => w.IsHidden());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
          

            var scriptures = new List<Scripture>
            {
                new Scripture(new Reference("John", 3, 16),
                    "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish but have everlasting life."),
                new Scripture(new Reference("Proverbs", 3, 5, 6),
                    "Trust in the LORD with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
                new Scripture(new Reference("Psalm", 23, 1),
                    "The LORD is my shepherd; I shall not want.")
            };

            var rnd = new Random();
            var scripture = scriptures[rnd.Next(scriptures.Count)];

            Console.WriteLine("Press ENTER to hide words, type 'quit' to exit, or type a number to hide that many words.");
            Console.WriteLine("Press ENTER to begin...");
            Console.ReadLine();

            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());

                if (scripture.IsCompletelyHidden())
                {
                    Console.WriteLine("\n-- All words are hidden. Program finished. --");
                    break;
                }

                Console.Write("\nPress ENTER to hide more words (or type 'quit'): ");
                string input = Console.ReadLine()?.Trim().ToLower();

                if (input == "quit") break;

                int numberToHide = 3; // default
                if (int.TryParse(input, out int n) && n > 0)
                {
                    numberToHide = n;
                }

                scripture.HideRandomWords(numberToHide);
            }
        }
    }
}
