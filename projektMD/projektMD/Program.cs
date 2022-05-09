Console.WriteLine("Podaj ilość wierzchołków");
int rozmiarMacierzy = Convert.ToInt32(Console.ReadLine());
int[][] macierz = new int[rozmiarMacierzy][];
using StreamWriter file = new("WriteLines2.txt", append: true);
for (int liczba = 0; liczba < 100; liczba++)
{
    int kolejno = liczba + 1;
    string kolejnoS = Convert.ToString(kolejno);
    await file.WriteLineAsync("Graf #" + kolejnoS);
    for (int i = 0; i < rozmiarMacierzy; i++)
{
    macierz[i] = new int[rozmiarMacierzy];
    for (int j = 0; j < rozmiarMacierzy; j++)
    {
        macierz[i][j] = 0;
    }
}
Random rand = new Random();
for (int i = 0; i < rozmiarMacierzy; i++)
{
    for (int j = 1 + i; j < rozmiarMacierzy; j++)
    {
        macierz[i][j] = rand.Next(0, 2);
        macierz[j][i] = macierz[i][j];
    }
}
await file.WriteLineAsync("Punkty grafu");
for (int i = 0; i < rozmiarMacierzy; i++)
{
    int liczby = i + 1;
    string słowa = Convert.ToString(liczby);
    await file.WriteAsync(słowa + "\t");
}
await file.WriteLineAsync();
await file.WriteLineAsync("Macierz grafu");

for (int i = 0; i < rozmiarMacierzy; i++)
{
    for (int j = 0; j < rozmiarMacierzy; j++)
    {
        string słowa = Convert.ToString(macierz[i][j]);
        await file.WriteAsync(słowa + "\t");
    }
    await file.WriteLineAsync();
}
await file.WriteLineAsync("Stopnie wierzchołków");
for (int i = 0; i < rozmiarMacierzy; i++)
{
    int k = 0;
    for (int j = 0; j < rozmiarMacierzy; j++)
    {
        k += macierz[i][j];
    }
    await file.WriteAsync(k + "\t");
}
await file.WriteLineAsync();
await file.WriteLineAsync("Krawędzie");
int waga = 0;
for (int i = 0; i < rozmiarMacierzy; i++)
{
    for (int j = 1 + i; j < rozmiarMacierzy; j++)
    {
        if (macierz[i][j] == 1)
        {
            int k = i + 1;
            int l = j + 1;
            int wagakrawędzi = rand.Next(1, 10);
            string słowa = Convert.ToString(k + "-" + l + " waga " + wagakrawędzi);  
            await file.WriteLineAsync(słowa);
            waga+=wagakrawędzi;
        }
    }
}
string wagaS = Convert.ToString(waga);
await file.WriteLineAsync("Waga drzewa: " + wagaS);
    await file.WriteLineAsync("-----------------------------------------------");
}