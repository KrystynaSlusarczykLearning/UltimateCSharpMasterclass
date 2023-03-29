namespace Polymorphism.Extensions
{
    public static class SeasonExtensions
    {
        public static Season Next(this Season season)
        {
            int seasonAsInt = (int)season;
            int nextSeason = (seasonAsInt + 1) % 4;
            return (Season)nextSeason;
        }
    }
}
