using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeSerialize
{
    internal class RacesSerialize: ContentSerialize<List<Race>>
    {
        public async override Task<List<Race>> GetRacesAsync(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                var races = new List<Race>();
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    if (line.Contains('|'))
                    {
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(line))
                    {

                        var _ = line.Split(',');
                        int id = int.Parse(_[0].Trim());
                        var fullName = _[1].Trim();
                        var country = _[2].Trim();
                        double points = double.Parse(_[3].Trim());
                        var typeRace = _[4].Trim().TrimEnd(';');



                        var race = new Race()
                        {
                            Id = id,
                            Player = new Player() { FullName = fullName, Country = country },
                            TypeRace = typeRace,
                            Points = points,
                        };

                        races.Add(race);
                    }

                }

                return races;
            }
        }
    }
}
