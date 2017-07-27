using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodes {

	public List<Nodes> adjacent = new List<Nodes>();
	public Nodes previous = null;
	public string label = "";

	public void Clear()
	{
		previous = null;
	}

}
