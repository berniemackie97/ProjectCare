using Godot;
using System;
using ProjectCare.Scripts.Enums;

public partial class Pet : CharacterBody2D
{
	[Export] public int MaxStat { get; set; } = 100;
	[Export] public float DecayPerMinute { get; set; } = 2f;
	[Export] public NodePath StatsLabelPath { get; set; }
	[Export] public float MoveSpeed { get; set; } = 200f;

	private Label _label;
	public float Happiness { get; private set; }
	public float Energy { get; private set; }
	public float Health { get; private set; }
	public float Focus { get; private set; }
	
	public float Coins { get; private set; }



	private double _accum;
	
	public override void _Ready()
	{
		_label = GetNodeOrNull<Label>(StatsLabelPath);
		Happiness = Energy = Health = Focus = MaxStat;
		UpdateUi();
	}
	
	public override void _Process(double delta)
	{
		_accum += delta;
		if (_accum >= 60.0)
		{
			float ticks = (float)(_accum / 60.0);
			DecayAll(ticks * DecayPerMinute);
			_accum = 0.0;
		}
	}
	
	public override void _PhysicsProcess(double delta)
	{
		Vector2 direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");
		Velocity = direction * MoveSpeed;
		MoveAndSlide();
	}
	
	private void DecayAll(float amount)
	{
		Happiness = Mathf.Max(0, Happiness - amount);
		Energy = Mathf.Max(0, Energy - amount);
		Health = Mathf.Max(0, Health - amount);
		Focus = Mathf.Max(0, Focus - amount);
		UpdateUi();
	}
	
	
	
	public void DoTaskBoost(TaskType task, float amount = 10f)
	{
		
		switch (task)
		{
			case TaskType.Hydrate: Health = Mathf.Min(MaxStat, Health + amount); break;
			case TaskType.Stretch: Energy = Mathf.Min(MaxStat, Energy + amount); break;
			case TaskType.Journal: Focus  = Mathf.Min(MaxStat, Focus + amount); break;
			default: Happiness = Mathf.Min(MaxStat, Happiness + amount); break;
		}
		UpdateUi();
	}
	

	
	private void UpdateUi()
	{
		if (_label != null)
			_label.Text = $"HPY:{(int)Happiness} EN:{(int)Energy} HL:{(int)Health} FO:{(int)Focus}";
	}
}
