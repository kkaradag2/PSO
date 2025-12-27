namespace PSO_Sample.Models
{
    public class Particle
    {
        public int[] Position;
        public double[] Velocity;
        public int[] BestPosition;
        public int BestFitness;
        public Particle(int dimensions)
        {
            Position = new int[dimensions];
            Velocity = new double[dimensions];
            BestPosition = new int[dimensions];
            BestFitness = int.MinValue;
        }
    }
}
