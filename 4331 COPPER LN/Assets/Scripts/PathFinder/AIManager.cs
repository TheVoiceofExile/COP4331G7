using UnityEngine;

public class AIManager : MonoBehaviour
{
	public float speed = 50f;

	private bool chase = false;

	// start is the node that the player is closest to, finish is the ai
	private AINode start, finish;
	private Transform player;
	private BreadCrumb path;
	private GameObject[,] world = new GameObject[11, 6];

	// Use this for initialization
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		GameObject[] nodes = GameObject.FindGameObjectsWithTag("Node");
		foreach(GameObject node in nodes)
		{
			AINode point = node.GetComponent<AINode>();
			world[point.x, point.y] = node;
		}
		start = world[7, 0].GetComponent<AINode>();
		finish = world[6, 5].GetComponent<AINode>();
	}
	
	// Update is called once per frame
	void Update()
	{
		if(path != null)
		{
			if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f || Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
			{
				if(path.x == start.x && path.y == start.y)
				{
					transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
					chase = true;
				}
				else
				{
					transform.position = Vector3.MoveTowards(transform.position, world[path.x, path.y].transform.position, speed * Time.deltaTime);
					chase = false;
				}
			}
			if(!chase && Vector2.Distance(transform.position, world[path.x, path.y].transform.position) < 5f)
			{
				path = path.next;
				finish = world[path.x, path. y].GetComponent<AINode>();
			}
		}
	}

	void FixedUpdate()
	{
		if(UpdateNode(player, ref start))
		{
			path = FindPath();
		}

	}

	private bool UpdateNode(Transform entity, ref AINode closest)
	{
		int low = int.MaxValue;
		int dist = (int)Vector2.Distance(entity.position, closest.transform.position);
		AINode other = null;

		foreach(AINode node in closest.adjacent)
		{
			int temp = (int)Vector2.Distance(entity.position, node.transform.position);
			if(temp < low)
			{
				low = temp;
				other = node;
			}
		}

		if(low < dist)
		{
			closest = other;
			return true;
		}
		return false;
	}

	// Find the shortest path from AINodes start to finish, Dijkstra based
	private BreadCrumb FindPath()
	{
		Debug.Log("Finding Path");
		MinHeap<BreadCrumb> heap = new MinHeap<BreadCrumb>(256);
		BreadCrumb[,] crumbs = new BreadCrumb[11, 6];
		BreadCrumb goal = new BreadCrumb(finish);
		BreadCrumb current = new BreadCrumb(start);
		BreadCrumb node;
		int cost;

		if(current.Equals(goal))
			return current;
		current.cost = 0;
		crumbs[current.x, current.y] = current;
		heap.Add(current);

		while(heap.Count() > 0)
		{
			// Find best item and switch it to the 'closedList'
			current = heap.GetHead();
			current.visited = true;
			Debug.Log(current.x + " " + current.y);

			// Check neighbors
			foreach(AINode neighbor in current.neighbors)
			{
				// Check if we've already examined a neighbor, if not create a new node for it.
				if(crumbs[neighbor.x, neighbor.y] == null)
				{
					node = new BreadCrumb(neighbor);
					crumbs[neighbor.x, neighbor.y] = node;
				}
				else
				{
					node = crumbs[neighbor.x, neighbor.y];
				}

				// If the node has not been removed from the heap, check it's new cost, keep the best
				if(!node.visited)
				{
					int toGoal = (int)Vector2.Distance(new Vector2(goal.x, goal.y), new Vector2(node.x, node.y));
					int toNode = (int)Vector2.Distance(new Vector2(current.x, current.y), new Vector2(node.x, node.y));
					cost = current.cost + toNode + toGoal;

					if(cost < node.cost)
					{
						node.cost = cost;
						node.next = current;
					}

					// If the node wasn't in the heap yet, add it 
					if(!node.seen)
					{
						// Check to see if we're done
						if(node.Equals(goal))
						{
							Debug.Log("Path Found");
							node.next = current;
							return node;
						}
						node.seen = true;
						heap.Add(node);
					}
				}
			}
		}
		// No path was found
		Debug.Log("No Path Found");
		return null;
	}
}
