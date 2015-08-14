namespace PathDefence.GamePlay
{
    public class PointsManager
    {
        public int Points { get; private set; }

        public void Initialize()
        {
            Points = 0;
        }

        public void AddPoints(int points)
        {
            if(points > 0)
            {
                Points += points;
            }
        }
    }
}
