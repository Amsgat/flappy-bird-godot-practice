using Godot;
using System;

public partial class Main : Node2D
{
	private PipeManager _pipeManager = new PipeManager();
	private GroundManager _groundManager = new GroundManager();
	private Flappy _flappy;
	private int _score = 0;
	private int _latestScore = 0;
	private Label _scoreLabel;
	private Sprite2D _gameOverMessage;
	private bool _endGameFlag = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetWindow().Size = new Vector2I(500,500);

		_flappy = GetNode<Flappy>("Flappy");
		_scoreLabel = GetNode<Label>("Score");
		_scoreLabel.Text = $"Score: {_score}";
		_gameOverMessage = GetNode<Sprite2D>("GameOver");

		AddChild(_pipeManager);
		AddChild(_groundManager);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(_endGameFlag == false) {

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

			//Set all speeds to 0 when flappy touches the pipes
			//set _endGameFlag to true running the loop through the end game branch
			if(_pipeManager.GetCollision() || _groundManager.GetCollision())
			{
				_flappy.Pause();
				_pipeManager.Pause();
				_groundManager.Pause();
				_latestScore = _score;

				//remove _pipeManager and free space
				RemoveChild(_pipeManager);
				_pipeManager.QueueFree();

				//Move gameover message into screen
				//move score label beneath gameover message
				_gameOverMessage.Position = new Vector2(250,250);
				_scoreLabel.Position = new Vector2(250,300);
				_endGameFlag = true;
			}
		}

		if(_endGameFlag == true)
		{
			//when user inputs 'f' the game is reset
			//creating a new _pipeManager and _groundManager
			//resets flappys position
			if(Input.IsKeyPressed(Key.F))
			{
				RemoveChild(_groundManager);

				_pipeManager = new PipeManager();
				AddChild(_pipeManager);
				_groundManager = new GroundManager();
				AddChild(_groundManager);

				_gameOverMessage.Position = new Vector2(-500,250);
				_scoreLabel.Position = new Vector2(94,15);
				_score = 0;

				_flappy.Position = new Vector2(71,62);
				_flappy.Resume();

				_endGameFlag = false;
			}
		}
	}
}
