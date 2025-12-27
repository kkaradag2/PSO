using PSO_Sample.Models;

class Program
{
    static void Main()
    {
        // Yüklenecek malzemelerin ağırlık ve değerleri (weight, value)
        var items = new List<Item>
        {
            new Item(12, 4),
            new Item(2, 2),
            new Item(4, 2),
            new Item(1, 1),
            new Item(4, 10),
            new Item(4, 14),
            new Item(2, 1),
            new Item(6, 12),
            new Item(5, 7),
            new Item(2, 5),
            new Item(7, 14),
            new Item(9, 16),
        };

        // Bir konteynerin kapasitesi
        int capacity = 25;

        // LOG'u açtık: enableLogging: true
        // debugParticles: loglanacak particle indeksleri (0-tab bazlı) -> {0,1} = 1. ve 2. particle
        // maxLoggedIterations: kaç iterasyon loglansın (ör: 1 = sadece 1. iterasyon)
        var pso = new BinaryPSO(
            items,
            capacity,
            swarmSize: 80,
            maxIter: 400,
            enableLogging: true,
            debugParticles: new int[] { 0, 1 },
            maxLoggedIterations: 400
        );

        pso.Run();

        var (pos, totalValue, totalWeight) = pso.GetBestSolution();

        Console.WriteLine("\nPSO ile bulunan en iyi çözüm:");
        Console.WriteLine($"Toplam Değer: {totalValue}, Toplam Ağırlık: {totalWeight}, Kapasite: {capacity}");
        Console.WriteLine("Seçilen öğeler (index: weight,value):");
        for (int i = 0; i < items.Count; i++)
        {
            if (pos[i] == 1)
                Console.WriteLine($"  {i}: ({items[i].Weight}, {items[i].Value})");
        }
    }
}