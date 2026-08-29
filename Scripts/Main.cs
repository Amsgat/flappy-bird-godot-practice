using Godot;
using System;

public partial class Main : Node2D
{
	//[Export] private PackedScene _pipeSpawner;
	//private PackedScene _pipeSpawner = GD.Load<PackedScene>("res://Scenes/pipes.tscn");

	private Pipes _pipes;
	private Pipes _pipes2;
	//Pipes _pipes2;
	//private Pipes _pipes3 = new Pipes();
	private PipeManager _pipeManager = new PipeManager();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		/*
		//_pipes = new Pipes();
		//_pipes = GetNode<Pipes>("Pipes");
		_pipes = _pipeSpawner.Instantiate<Pipes>();
		AddChild(_pipes);
		_pipes.SetPositionX(1000);

		_pipes2 = _pipeSpawner.Instantiate<Pipes>();
		AddChild(_pipes2);
		_pipes2.SetPositionX(800);
		*/
		AddChild(_pipeManager);
		
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//_pipes.Move();
		//_pipes2.Move();
	}
}
