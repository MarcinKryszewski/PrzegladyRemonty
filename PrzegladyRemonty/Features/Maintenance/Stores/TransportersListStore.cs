using PrzegladyRemonty.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PrzegladyRemonty.Features.Maintenance;

public class TransportersListStore
{
    private readonly ObservableCollection<Transporter> _transporters;

    public IEnumerable<Transporter> Transporters => _transporters;

    public TransportersListStore()
    {
        _transporters = new ObservableCollection<Transporter>();
    }

    public void AddTransporter(Transporter transporter)
    {
        if (_transporters.Any(t => t.Id == transporter.Id)) return;
        _transporters.Add(transporter);
    }

    public void RemoveTransporter(Transporter transporter)
    {
        _transporters.Remove(transporter);
    }

    public void Clear()
    {
        _transporters.Clear();
    }
}