using Godot;
using System;

public partial class WorldCamera : Camera2D
{
	// We probably dont need this... Godot may do this automatically
	// since right now this is our only camera but until we test it here it is
	public override void _Ready() => MakeCurrent();
}
