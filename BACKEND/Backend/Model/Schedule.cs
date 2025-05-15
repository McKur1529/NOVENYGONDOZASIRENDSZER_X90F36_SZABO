namespace Backend.Model
{
    public class Schedule
    {
        public Dictionary<string, List<string>> WeeklySchedule { get; set; }
        public Dictionary<string, double> WeeklyWaterConsumption { get; set; }
        public Dictionary<string, int> DailyWorkload { get; set; }

        public Schedule() { }

        public Schedule(Dictionary<string, List<string>> weeklySchedule, Dictionary<string, double> weeklyWaterConsumption, Dictionary<string, int> dailyWorkload)
        {
            WeeklySchedule = weeklySchedule;
            WeeklyWaterConsumption = weeklyWaterConsumption;
            DailyWorkload = dailyWorkload;
        }
    }
}
