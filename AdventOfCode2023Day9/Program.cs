const string file = @"C:\Users\SaLiVa\source\repos\AdventOfCode2023Day9\AdventOfCode2023Day9\Day9Input.txt";

List<int []> startsequence = [];

using (var reader = File.OpenText(file))
{
    while (!reader.EndOfStream)
    {
        startsequence.Add(Array.ConvertAll(reader.ReadLine().Split(" "), int.Parse));
    }
}

List<List<List<int>>> sequences = [];

foreach (var s in startsequence)
{
    List<List<int>> deltasequences = [];
    List<int> deltas = s.ToList();
    deltasequences.Add(deltas);
    
    while (!deltas.All(x => x.Equals(0)))
    {
        deltas = calculateDeltas(deltas);
        deltasequences.Add(deltas);
    }
    sequences.Add(deltasequences);
}

var p1result = 0;
foreach (var s in sequences)
{
    var sequencetotal = 0;
    // Run back through the sequence
    for (int i = s.Count - 1; i >= 0; i--)
    {
        // Take the last value of each sequence
        var lastElement = s[i].Last();
        sequencetotal += lastElement;
    }

    p1result += sequencetotal;
}

Console.WriteLine(p1result);

var p2result = 0;
foreach (var s in sequences)
{
    var sequencetotal = 0;
    // Run back through the sequence
    for (int i = s.Count - 1; i >= 0; i--)
    {
        // Take the last value of each sequence
        var firstElement = s[i].First();
        sequencetotal = firstElement - sequencetotal;
    }

    p2result += sequencetotal;
}

Console.WriteLine(p2result);

List<int> calculateDeltas(List<int> sequence)
{
    List<int> result = [];
    for (var i = 1; i < sequence.Count; i++)
    {
        result.Add(sequence[i] - sequence[i - 1]);
    }

    return result;
}
