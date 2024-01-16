using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Homework.States;

public class StateManager
{
    public GameState CurrentState { get; private set; } = new();

    public void LoadState(string playerName)
    {
        foreach (var filepath in Directory.GetFiles("Resources/Players"))
        {
            if (Path.GetFileNameWithoutExtension(filepath) != playerName) continue;

            LoadStateFromFile(filepath, playerName);

            return;
        }

        CurrentState = new GameState { PlayerName = playerName };
    }

    public void SaveStateToFile()
    {
        File.WriteAllLines("Resources/Players/" + CurrentState.PlayerName + ".txt", GenerateLines());
    }

    private void LoadStateFromFile(string filepath, string playerName)
    {
        var lines = File.ReadAllLines(filepath);
        List<int> numbers = new();
        foreach (var line in lines)
        {
            numbers.AddRange(line.TrimEnd().Split(" ").Select(int.Parse));
        }

        CurrentState = new GameState
        {
            PlayerName = playerName,
            Money = numbers[0],
            CropStats = new Dictionary<CropType, int>
                { { CropType.Wheat, numbers[1] }, { CropType.Potato, numbers[2] }, { CropType.Carrot, numbers[3] } },
            Farms = ParseFarm(numbers.Skip(4).Take(8).ToList())
        };
    }

    private static CropType?[] ParseFarm(IReadOnlyList<int> cropCodes)
    {
        var result = new CropType?[8];

        for (var i = 0; i < result.Length; i++)
        {
            result[i] = cropCodes[i] != 0 ? (CropType)(cropCodes[i] - 1) : null;
        }

        return result;
    }

    private IEnumerable<string> GenerateLines()
    {
        List<string> result = new()
        {
            CurrentState.Money.ToString(),
            CurrentState.CropStats[CropType.Wheat]
            + " "
            + CurrentState.CropStats[CropType.Potato]
            + " "
            + CurrentState.CropStats[CropType.Carrot]
        };

        var farms = "";
        foreach (var farm in CurrentState.Farms)
        {
            farms += farm != null ? ((int)farm + 1).ToString() : 0;
            farms += " ";
        }

        result.Add(farms.TrimEnd());

        return result;
    }
}
