using Godot;
using System;

public partial class Ground : Node2D
{
	private float _speed = 1.0f;
	private Vector2 _direction = new Vector2(-1,0);
	private bool _collisionFlag = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	public void Move()
	{
		Position += _direction * _speed;
	}

	public void SetSpeed(float x)
	{
		_speed = x;
	}

	public void _on_body_entered(Node2D body)
	{
		_collisionFlag = true;
	}

	public bool GetCollisionFlag()
	{
		return _collisionFlag;
	}
}
