using Godot;
using System;

public partial class Main : Node2D
{
	private PipeManager _pipeManager = new PipeManager();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		AddChild(_pipeManager);
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
}
