using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ')
                     .Select(w => new Word(w))
                     .ToList();
    }

    public void HideRandomWords(int count)
    {
        Random random = new Random();
        int hidden = 0;

        // Hide until desired count or all visible words hidden
        while (hidden < count && _words.Any(w => !w.IsHidden()))
        {
            int index = random.Next(_words.Count);
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hidden++;
            }
        }
    }

    public bool AllHidden() => _words.All(w => w.IsHidden());

    public string GetDisplayText()
    {
        string body = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()} - {body}";
    }

    // Reveals the complete scripture text
    public string GetFullText()
    {
        string body = string.Join(" ", _words.Select(w => w.OriginalText));
        return $"{_reference.GetDisplayText()} - {body}";
    }
}




