using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AINode : MonoBehaviour
{
	public List<AINode> adjacent = new List<AINode>();
	public int x, y;

	public bool Equals(AINode other)
	{
		return x == other.x && y == other.y;
	}
}
