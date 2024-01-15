using System.Collections.Generic;

namespace Homework.Screens.MainScreen;

public enum Crop
{
    Wheat,
    Potato,
    Carrot
}

public class GameState
{
    public string PlayerName { get; set; }
    public Crop SelectedCrop { get; set; }

    public Dictionary<Crop, int> CropStats { get; } =
        new() { { Crop.Wheat, 0 }, { Crop.Potato, 0 }, { Crop.Carrot, 0 } };
}
