using Godot;
using System;

public partial class Flappy : CharacterBody2D
{
	public const float Speed = 300.0f;
	private float _jumpVelocity = -400.0f;
	private float _gravity = 9.8f;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		
		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
			//velocity += new Vector2(0,_gravity);
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("jump"))
		{
			velocity.Y = _jumpVelocity;
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	public void Pause()
	{
		//set jumpvelocity, gravity, and overall velocity to 0;
		_jumpVelocity = 0;
		PhysicsServer2D.AreaSetParam(GetViewport().FindWorld2D().Space, PhysicsServer2D.AreaParameter.Gravity, 0);
		Velocity = new Vector2(0,0);
	}

	public void Resume()
	{
		//set all velocity and gravity back to their original value
		PhysicsServer2D.AreaSetParam(GetViewport().FindWorld2D().Space, PhysicsServer2D.AreaParameter.Gravity, 980);
		_jumpVelocity = -400.0f;
	}

	public void EndGame()
	{
		Pause();
	}

	public Vector2 GetFlappyPosition()
	{
		return Position;
	}
}
