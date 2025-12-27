using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO_Sample.Models
{
    public class BinaryPSO
    {
        readonly List<Item> items;
        readonly int capacity;
        readonly int swarmSize;
        readonly int maxIter;
        readonly double w, c1, c2;
        readonly double velMax = 4.0;
        readonly double velMin = -4.0;
        readonly Random rnd = new Random();

        List<Particle> swarm;
        int[] globalBestPosition;
        int globalBestFitness;

        // Yeni: logging için alanlar
        readonly bool enableLogging;
        readonly int[] debugParticles; // indeksler (0-tab bazlı)
        readonly int maxLoggedIterations;

        // Yeni: early stop (patience)
        readonly int earlyStopPatience;
        int iterationsSinceLastImprovement;
        int bestFoundAtIteration;
        int iterationsRun;

        public BinaryPSO(List<Item> items, int capacity, int swarmSize = 50, int maxIter = 200,
                         double inertia = 0.72, double cognitive = 1.49, double social = 1.49,
                         bool enableLogging = false, int[] debugParticles = null, int maxLoggedIterations = 1,
                         int earlyStopPatience = 10)
        {
            this.items = items;
            this.capacity = capacity;
            this.swarmSize = swarmSize;
            this.maxIter = maxIter;
            w = inertia; c1 = cognitive; c2 = social;
            swarm = new List<Particle>();

            this.enableLogging = enableLogging;
            this.debugParticles = debugParticles ?? new int[] { 0, 1 }; // default: ilk iki particle
            this.maxLoggedIterations = Math.Max(0, maxLoggedIterations);

            this.earlyStopPatience = Math.Max(1, earlyStopPatience);
            this.iterationsSinceLastImprovement = 0;
            this.bestFoundAtIteration = 0;
            this.iterationsRun = 0;
        }

        // Dışarıdan okunabilir bilgi
        public int BestFoundAtIteration => bestFoundAtIteration;
        public int IterationsRun => iterationsRun;
        public int EarlyStopPatience => earlyStopPatience;

        public void Run()
        {
            InitializeSwarm();
            // İlk bulunan global best başlangıçta (iterasyon 0)
            bestFoundAtIteration = 0;
            iterationsSinceLastImprovement = 0;

            for (int iter = 0; iter < maxIter; iter++)
            {
                bool iterImproved = false;

                if (enableLogging && iter < maxLoggedIterations)
                    Console.WriteLine($"\n==== Iterasyon {iter + 1} / {maxIter} ====");

                // particle'ları indeks ile dolaş (log için)
                for (int pi = 0; pi < swarm.Count; pi++)
                {
                    var p = swarm[pi];

                    bool shouldLogThisParticle = enableLogging && iter < maxLoggedIterations && debugParticles.Contains(pi);

                    if (shouldLogThisParticle)
                    {
                        Console.WriteLine($"\n-- Particle #{pi + 1} (başlangıç) --");
                        Console.WriteLine($"Position: {FormatIntArray(p.Position)}");
                        Console.WriteLine($"Velocity: {FormatDoubleArray(p.Velocity)}");
                        Console.WriteLine($"PersonalBestFitness: {p.BestFitness}");
                    }

                    // Update velocity
                    for (int d = 0; d < items.Count; d++)
                    {
                        int pBestDiff = p.BestPosition[d] - p.Position[d]; // -1,0,1
                        int gBestDiff = globalBestPosition[d] - p.Position[d]; // -1,0,1

                        double r1 = rnd.NextDouble();
                        double r2 = rnd.NextDouble();

                        p.Velocity[d] = w * p.Velocity[d]
                                        + c1 * r1 * pBestDiff
                                        + c2 * r2 * gBestDiff;

                        // clamp
                        if (p.Velocity[d] > velMax) p.Velocity[d] = velMax;
                        if (p.Velocity[d] < velMin) p.Velocity[d] = velMin;
                    }

                    if (shouldLogThisParticle)
                    {
                        Console.WriteLine($"Velocity (güncellendi): {FormatDoubleArray(p.Velocity)}");
                    }

                    // Update position via sigmoid
                    for (int d = 0; d < items.Count; d++)
                    {
                        double s = Sigmoid(p.Velocity[d]);
                        p.Position[d] = rnd.NextDouble() < s ? 1 : 0;
                    }

                    // Repair to satisfy capacity
                    Repair(p.Position);

                    // Evaluate
                    int fitness = Evaluate(p.Position);
                    int weight = ComputeWeight(p.Position);

                    if (shouldLogThisParticle)
                    {
                        Console.WriteLine($"Position (güncellendi ve repair uygulandı): {FormatIntArray(p.Position)}");
                        Console.WriteLine($"Weight: {weight}, Fitness: {(fitness == int.MinValue ? int.MinValue : fitness)}");
                    }

                    // Update personal best
                    if (fitness > p.BestFitness)
                    {
                        Array.Copy(p.Position, p.BestPosition, items.Count);
                        p.BestFitness = fitness;

                        if (shouldLogThisParticle)
                            Console.WriteLine($"Personal best güncellendi: {p.BestFitness}");
                    }

                    // Update global best
                    bool globalUpdated = false;
                    if (fitness > globalBestFitness)
                    {
                        Array.Copy(p.Position, globalBestPosition, items.Count);
                        globalBestFitness = fitness;
                        globalUpdated = true;

                        // En iyi bulunduğunda anında işaretle
                        bestFoundAtIteration = iter + 1; // 1-tab bazlı
                        iterationsSinceLastImprovement = 0;
                        iterImproved = true;
                    }

                    if (shouldLogThisParticle)
                    {
                        Console.WriteLine($"PersonalBestPosition: {FormatIntArray(p.BestPosition)}");
                        if (globalUpdated)
                        {
                            Console.WriteLine($"!!! global best güncellendi -> gBestFitness: {globalBestFitness}");
                            Console.WriteLine($"gBestPosition: {FormatIntArray(globalBestPosition)}");
                        }
                    }
                }

                // Iterasyon sonunda patience kontrolü
                if (!iterImproved)
                {
                    iterationsSinceLastImprovement++;
                }
                else
                {
                    iterationsSinceLastImprovement = 0;
                }

                iterationsRun = iter + 1;

                if (enableLogging && iter < maxLoggedIterations)
                {
                    int gbWeight = ComputeWeight(globalBestPosition);
                    Console.WriteLine($"\n== Iterasyon {iter + 1} özeti: gBestFitness={globalBestFitness}, gBestWeight={gbWeight}");
                    Console.WriteLine($"gBestPosition: {FormatIntArray(globalBestPosition)}");
                    Console.WriteLine($"(Patience: {earlyStopPatience}, ItersSinceLastImprovement: {iterationsSinceLastImprovement})");
                }

                if (iterationsSinceLastImprovement >= earlyStopPatience)
                {
                    if (enableLogging)
                        Console.WriteLine($"\nEarly stop: Son {earlyStopPatience} iterasyonda gBest iyileşmedi -> Döngü sonlandırıldı (iterasyon {iterationsRun}).");
                    break;
                }
            }
        }

        void InitializeSwarm()
        {
            swarm.Clear();
            globalBestFitness = int.MinValue;
            globalBestPosition = new int[items.Count];

            for (int i = 0; i < swarmSize; i++)
            {
                var p = new Particle(items.Count);

                // Random initial position then repair to be feasible
                for (int d = 0; d < items.Count; d++)
                {
                    p.Position[d] = rnd.Next(2); // 0 or 1
                    p.Velocity[d] = (rnd.NextDouble() - 0.5) * 2; // small initial velocity
                }

                Repair(p.Position);
                p.BestFitness = Evaluate(p.Position);
                Array.Copy(p.Position, p.BestPosition, items.Count);

                if (p.BestFitness > globalBestFitness)
                {
                    globalBestFitness = p.BestFitness;
                    Array.Copy(p.Position, globalBestPosition, items.Count);
                }

                swarm.Add(p);
            }
        }

        int Evaluate(int[] position)
        {
            int totalW = 0, totalV = 0;
            for (int i = 0; i < items.Count; i++)
            {
                if (position[i] == 1)
                {
                    totalW += items[i].Weight;
                    totalV += items[i].Value;
                }
            }
            if (totalW > capacity) return int.MinValue; // infeasible (should not happen due to repair)
            return totalV;
        }

        int ComputeWeight(int[] position)
        {
            int totalW = 0;
            for (int i = 0; i < items.Count; i++)
                if (position[i] == 1) totalW += items[i].Weight;
            return totalW;
        }

        void Repair(int[] position)
        {
            // If overweight, remove items with worst value/weight ratio first
            int totalW = 0;
            for (int i = 0; i < items.Count; i++) totalW += position[i] * items[i].Weight;
            if (totalW <= capacity) return;

            var included = new List<int>();
            for (int i = 0; i < items.Count; i++) if (position[i] == 1) included.Add(i);

            // sort by value/weight ascending (least efficient removed first)
            included.Sort((a, b) =>
            {
                double ra = items[a].Value / (double)items[a].Weight;
                double rb = items[b].Value / (double)items[b].Weight;
                int cmp = ra.CompareTo(rb);
                if (cmp != 0) return cmp;
                return items[a].Value.CompareTo(items[b].Value);
            });

            int idx = 0;
            while (totalW > capacity && idx < included.Count)
            {
                int remove = included[idx];
                if (position[remove] == 1)
                {
                    position[remove] = 0;
                    totalW -= items[remove].Weight;
                }
                idx++;
            }

            // If still overweight (very rare), remove randomly until feasible
            idx = 0;
            while (totalW > capacity)
            {
                int i = rnd.Next(items.Count);
                if (position[i] == 1)
                {
                    position[i] = 0;
                    totalW -= items[i].Weight;
                }
                if (++idx > items.Count * 2) break;
            }
        }

        double Sigmoid(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x));
        }

        // For external use: return best solution found
        public (int[] Position, int TotalValue, int TotalWeight) GetBestSolution()
        {
            int wsum = 0, vsum = 0;
            for (int i = 0; i < items.Count; i++)
            {
                if (globalBestPosition[i] == 1)
                {
                    wsum += items[i].Weight;
                    vsum += items[i].Value;
                }
            }
            return (globalBestPosition, vsum, wsum);
        }

        // Yardımcı formatlama
        string FormatIntArray(int[] arr)
        {
            return "[" + string.Join(",", arr) + "]";
        }

        string FormatDoubleArray(double[] arr)
        {
            return "[" + string.Join(",", arr.Select(v => v.ToString("F3"))) + "]";
        }
    }

}