using Godot;
using System;
using System.Collections.Generic;

public partial class GroundManager : Node
{
	private PackedScene _groundSpawner = GD.Load<PackedScene>("res://Scenes/ground.tscn");
	private List<Ground> _groundList = new();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//Add initial ground to _groundList
		float winHeight = GetWindow().Size.Y;
		Ground initialGround = _groundSpawner.Instantiate<Ground>();
		AddChild(initialGround);
		initialGround.Position = new Vector2(-50,-45);
		_groundList.Add(initialGround);

		//further populate _groundList
		PopulateGround();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//move every ground node in _groundList
		foreach(Ground item in _groundList)
		{
			item.Move();
		}

		//Remove ground node from tree and _groundList when offscreen
		if(_groundList[0].Position.X < -400)
		{
			RemoveChild(_groundList[0]);
			RemoveGround(0);
			AddGround();
		}
	}

	public void AddGround()
	{
		Ground ground = _groundSpawner.Instantiate<Ground>();
		AddChild(ground);
		ground.Position = new Vector2(_groundList[^1].Position.X + 336, _groundList[^1].Position.Y);
		_groundList.Add(ground);
	}

	public void RemoveGround(int i)
	{
		_groundList.RemoveAt(i);
	}

	public void PopulateGround()
	{
		for(int i = 0; i < 5; i++)
		{
			AddGround();
		}
	}

	public void Pause()
	{
		foreach(Ground item in _groundList)
		{
			item.SetSpeed(0);
		}
	}

	public void Resume()
	{
		foreach(Ground item in _groundList)
		{
			item.SetSpeed(1);
		}
	}

	public bool GetCollision()
	{
		foreach(Ground item in _groundList)
		{
			if(item.GetCollisionFlag())
			{
				return true;
			}
		}

		return false;
	}
}
