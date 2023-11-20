using PrzegladyRemonty.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PrzegladyRemonty;

public class Brewery
{
    private readonly ObservableCollection<Line> _lines;

    public IEnumerable<Line> Lines => _lines;

    public Brewery()
    {
        _lines = new ObservableCollection<Line>();
    }

    public void AddLine(Line line)
    {
        _lines.Add(line);
    }
}
