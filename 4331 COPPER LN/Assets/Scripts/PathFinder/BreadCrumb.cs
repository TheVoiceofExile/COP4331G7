using System;
using System.Collections.Generic;

public class BreadCrumb : IComparable<BreadCrumb>
{
	public List<AINode> neighbors;
	public BreadCrumb next;
	public int x, y, cost;
	public bool seen = false;
	public bool visited = false;

	public BreadCrumb(AINode node)
	{
		x = node.x;
		y = node.y;
		neighbors = node.adjacent;
		cost = int.MaxValue;
	}

	public bool Equals(BreadCrumb other)
	{
		return x == other.x && y == other.y;
	}

	public int CompareTo(BreadCrumb other)
	{
		return cost - other.cost;
	}
}
