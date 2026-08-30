using Godot;
using System;
using System.Collections.Generic;

public partial class PipeManager : Node
{
	private PackedScene _pipeSpawner = GD.Load<PackedScene>("res://Scenes/pipes.tscn");

	private List<Pipes> _pipeList = new List<Pipes>();
	private float _distanceBetweenPipes = 200;
	private Random _random = new();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//Set the inital pipe
		float initialPipeX = 500.0f;
		Pipes pipe = _pipeSpawner.Instantiate<Pipes>();
		AddChild(pipe);
		pipe.SetPositionX(initialPipeX);
		_pipeList.Add(pipe);
		
		//populate the list with some more pipes
		PopulatePipes();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//move each pipe in the list
		foreach(Pipes item in _pipeList)
		{
			item.Move();
		}
		
		//Remove pipes after the leave the screen
		if(_pipeList[0].GetCurrentPos().X < -50)
		{
			RemoveChild(_pipeList[0]);
			RemovePipe(0);
			AddPipe();
		}
	}

	//adds enough pipes to fill the screen
	public void PopulatePipes()
	{
		for(int i = 0; i < 10; i++)
		{
			AddPipe();
		}
	}

	public void AddPipe()
	{
		Pipes newPipe = _pipeSpawner.Instantiate<Pipes>();
		AddChild(newPipe);

		//set X position of new pipe relative to the last pipe in list
		float lastPos = _pipeList[^1].GetCurrentPos().X;
		newPipe.SetPositionX(lastPos + _distanceBetweenPipes);

		//set Y position of new pipe randomly
		float randomYPos = _random.Next(-100,100);
		newPipe.SetPositionY(randomYPos);

		_pipeList.Add(newPipe);
	}

	public void RemovePipe(int i)
	{
		_pipeList.RemoveAt(i);
	}

	public List<Pipes> GetPipes()
	{
		return _pipeList;
	}

	//Stops all pipes to pause the game
	public void Pause()
	{
		foreach(Pipes item in _pipeList)
		{
			item.SetSpeed(0);
		}
	}

	public void Resume()
	{
		foreach(Pipes item in _pipeList)
		{
			item.SetSpeed(1);
		}
	}

	public void EndGame()
	{
		Pause();
	}

	public bool GetCollision()
	{
		foreach(Pipes item in _pipeList)
		{
			Pipe[] pipeArray = item.GetPipes();
			foreach(Pipe pipe in pipeArray)
			{
				if(pipe.GetCollisionFlag())
				{
					return true;
				}

			}
		}

		return false;
	}
}
