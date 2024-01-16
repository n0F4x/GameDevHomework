using System.Collections.Generic;

namespace Homework.States;

public enum CropType
{
    Wheat,
    Potato,
    Carrot
}

public class GameState
{
    public string PlayerName { get; init; }
    public int Money { get; set; }
    public CropType SelectedCropType { get; set; }

    public Dictionary<CropType, int> CropStats { get; init; } =
        new() { { CropType.Wheat, 8 }, { CropType.Potato, 0 }, { CropType.Carrot, 0 } };

    public CropType?[] Farms = new CropType?[8];
}
