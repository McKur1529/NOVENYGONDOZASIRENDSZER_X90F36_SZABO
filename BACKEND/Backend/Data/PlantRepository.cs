using Backend.Model;
using Backend.Models;

namespace Backend.Data
{
    public class PlantRepository : IPlantRepository
    {
        private List<Plant> _plants = new();

        public void Create(Plant plant)
        {
            _plants.Add(plant);
        }

        public List<Plant> Read()
        {
            return _plants;
        }

        public void Delete(string name)
        {
            var target = _plants.FirstOrDefault(p => p.Name == name);
            if (target != null)
            {
                _plants.Remove(target);
            }
        }

        public void DeleteAll()
        {
            _plants.Clear();
        }

        public Schedule GenerateSchedule()
        {
            var days = new[] { "Hétfő", "Kedd", "Szerda", "Csütörtök", "Péntek", "Szombat", "Vasárnap" };

            var weeklySchedule = new Dictionary<string, List<string>>();
            var waterUsage = new Dictionary<string, double>();
            var workload = days.ToDictionary(day => day, day => 0);

            foreach (var plant in _plants)
            {
                var scheduledDays = new List<string>();
                double totalWater = 0;

                for (int i = 0; i < 7; i++)
                {
                    if (i % plant.Frequency == 0)
                    {
                        scheduledDays.Add(days[i]);
                        totalWater += plant.Water;
                        workload[days[i]]++;
                    }
                }

                weeklySchedule[plant.Name] = scheduledDays;
                waterUsage[plant.Name] = totalWater;
            }

            return new Schedule
            {
                WeeklySchedule = weeklySchedule,
                WeeklyWaterConsumption = waterUsage,
                DailyWorkload = workload
            };
        }
    }
}

