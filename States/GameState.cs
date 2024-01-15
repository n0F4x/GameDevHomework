using System.Collections.Generic;

namespace Homework.States;

public enum Crop
{
    Wheat,
    Potato,
    Carrot
}

public class GameState
{
    public string PlayerName { get; init; }
    public Crop SelectedCrop { get; set; }

    public Dictionary<Crop, int> CropStats { get; set; } =
        new() { { Crop.Wheat, 8 }, { Crop.Potato, 0 }, { Crop.Carrot, 0 } };

    public Crop?[] Farms = new Crop?[8];
}
