using Godot;
using System;

public partial class Main : Node2D
{
	private PipeManager _pipeManager = new PipeManager();
	private Flappy _flappy;
	private int _score = 0;
	private Label _scoreLabel;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetWindow().Size = new Vector2I(500,500);
		//DisplayServer.WindowSetSize(new Vector2I(500,500));

		_flappy = GetNode<Flappy>("Flappy");
		_scoreLabel = GetNode<Label>("Score");
		_scoreLabel.Text = Convert.ToString(_score);
		AddChild(_pipeManager);
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(_pipeManager.GetCollision())
		{
			_pipeManager.Pause();
			_flappy.Pause();
		}

		foreach(Pipes item in _pipeManager.GetPipes())
		{
			Pipe[] pipeArray = item.GetPipes();
			if(pipeArray[0].Position.X == _flappy.Position.X)
			{
				_score++;
				_scoreLabel.Text = Convert.ToString(_score);
			}
		}

		GD.Print(_score);
	}
}
