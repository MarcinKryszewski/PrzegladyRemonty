using System.Collections.Generic;
using System.Collections.ObjectModel;
using PrzegladyRemonty.Models;

namespace PrzegladyRemonty.Features.Maintenance;

public class TransportersListStore
{
    private readonly ObservableCollection<Transporter> _transporters;

    public IEnumerable<Transporter> Transporters => _transporters;

    public void AddTransporter(Transporter transporter)
    {
        _transporters.Add(transporter);
    }
}