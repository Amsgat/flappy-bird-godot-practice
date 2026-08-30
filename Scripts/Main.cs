using Godot;
using System;

public partial class Main : Node2D
{
	private PipeManager _pipeManager = new PipeManager();
	private GroundManager _groundManager = new GroundManager();
	private Flappy _flappy;
	private int _score = 0;
	private Label _scoreLabel;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetWindow().Size = new Vector2I(500,500);

		_flappy = GetNode<Flappy>("Flappy");
		_scoreLabel = GetNode<Label>("Score");
		_scoreLabel.Text = $"Score: {_score}";

		AddChild(_pipeManager);
		AddChild(_groundManager);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//Set all speeds to 0 when flappy touches the pipes
		if(_pipeManager.GetCollision() || _groundManager.GetCollision())
		{
			_flappy.Pause();
			_pipeManager.Pause();
			_groundManager.Pause();
		}

		//increment score when pipe passes flappy
		foreach(Pipes item in _pipeManager.GetPipes())
		{
			Pipe[] pipeArray = item.GetPipes();
			if(pipeArray[0].Position.X == _flappy.Position.X)
			{
				_score++;
				_scoreLabel.Text = $"Score: {_score}";
			}
		}
	}
}
