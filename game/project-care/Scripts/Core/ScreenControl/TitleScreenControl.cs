using Godot;

namespace ProjectCare.Scripts.Core.ScreenControl;

public partial class TitleScreenControl : Control
{
    public override void _Ready()
    {
        Button startButton = GetNode<Button>("CenterContainer/VBoxContainer/StartButton");
        Button settingsButton = GetNode<Button>("CenterContainer/VBoxContainer/SettingsButton");
        
        startButton.Pressed += OnStartPressed;
        settingsButton.Pressed += onSettingsPressed;
    }

    private void OnStartPressed()
    {
        GameRoot gameRoot = GetTree().Root.GetNode<GameRoot>("GameRoot");
        gameRoot.LoadGame();
    }

    private void onSettingsPressed()
    {
        //Todo add settings screem
    }
    
}