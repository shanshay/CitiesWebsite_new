using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitiesWebsite_new.Models;

namespace CitiesWebsite_new.Services
{
    public interface ICityProvider : IEnumerable<KeyValuePair<string, City>>
    {
        City this[string name] { get; }
    }
}
