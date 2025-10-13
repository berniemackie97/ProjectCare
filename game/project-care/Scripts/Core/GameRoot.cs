using Godot;

namespace ProjectCare.Scripts.Core;

public partial class GameRoot : Node
{
    private Node _holder;
    private Node _current;

    private PackedScene _titleScene = GD.Load<PackedScene>("res://Scenes/Title/TitleScreen.tscn");
    private PackedScene _gameScene  = GD.Load<PackedScene>("res://Scenes/Game/Game.tscn");

    public override void _Ready() 
    {
        _holder = GetNode("SceneHolder");
        LoadTitle();
    }

    private void SwapTo(PackedScene scene)
    {
        _current?.QueueFree();
        _current = scene.Instantiate();
        _holder.AddChild(_current);
    }

    public void LoadTitle() => SwapTo(_titleScene);
    public void LoadGame()  => SwapTo(_gameScene);
    
}