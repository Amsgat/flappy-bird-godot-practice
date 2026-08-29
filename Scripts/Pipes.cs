using Godot;
using System;

public partial class Pipes : Node2D
{

	private float _speed = 1.0f;
	private Vector2 _direction = new Vector2(-1,0);
	private Vector2 _startPos = new Vector2(500,0);
	private Vector2 _currentPos;
	private Area2D _pipe;
	private Area2D _pipe2;
	private Random _random = new Random();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Hello");
		_pipe = GetNode<Area2D>("Pipe");
		_pipe2 = GetNode<Area2D>("Pipe2");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	public void SetSpeed(float speed)
	{
		_speed = speed;
	}

	public float GetSpeed()
	{
		return _speed;
	}

	public Vector2 GetCurrentPos()
	{
		//return _currentPos;
		return _pipe.Position;
	}

	public void SetPositionX(float x)
	{
		_currentPos.X = x;
		_pipe.Position = new Vector2(x, _pipe.Position.Y);
		_pipe2.Position = new Vector2(x, _pipe2.Position.Y);
	}

	public void SetPositionY(float y)
	{
		_currentPos.Y = y;
		float randomHeight = _random.Next(100);
		_pipe.Position = new Vector2(_pipe.Position.X, _pipe.Position.Y + randomHeight);
		_pipe2.Position = new Vector2(_pipe2.Position.X, _pipe2.Position.Y + randomHeight);
	}

	public void Move()
	{
		_pipe.Position += _direction * _speed;
		_pipe2.Position += _direction * _speed;
	}
}
