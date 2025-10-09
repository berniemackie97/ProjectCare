using Godot;

namespace ProjectCare.Scripts.Core.ScreenControl;

public partial class TitleScreenControl : Control
{
    public override void _Ready()
    {
        Button startButton = GetNode<Button>("CenterContainer/VBoxContainer/StartButton");
        startButton.Pressed += OnStartPressed;
    }

    private void OnStartPressed()
    {
        GameRoot gameRoot = GetTree().Root.GetNode<GameRoot>("GameRoot");
        gameRoot.LoadGame();
    }
}