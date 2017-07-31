using System;

public class MinHeap<T> where T : IComparable<T>
{
	private int count;
	private int capacity;
	private T temp;
	private T mheap;
	private T[] array;
	private T[] tempArray;

	public MinHeap(int capacity)
	{
		this.count = 0;
		this.capacity = capacity;
		array = new T[capacity];
	}

	public int Count()
	{
		return this.count;
	}
	
	public T GetHead()
	{
		temp = this.array[0];
		this.array[0] = this.array[this.count - 1];
		this.count--;
		this.MinHeapify(0);
		return temp;
	}

	public void Add(T item)
	{
		this.count++;
		int position = this.count - 1;
		int parentPosition = ((position - 1) >> 1);
		if(this.count > this.capacity)
		{
			DoubleArray();
		}

		this.array[position] = item;
		while(position > 0 && array[parentPosition].CompareTo(array[position]) > 0)
		{
			temp = this.array[position];
			this.array[position] = this.array[parentPosition];
			this.array[parentPosition] = temp;
			position = parentPosition;
			parentPosition = ((position - 1) >> 1);
		}
	}

	private void DoubleArray()
	{
		this.capacity <<= 1;
		tempArray = new T[this.capacity];
		CopyArray(this.array, tempArray);
		this.array = tempArray;
	}

	private void CopyArray(T[] source, T[] destination)
	{
		int index;
		for(index = 0; index < source.Length; index++)
		{
			destination[index] = source[index];
		}
	}

	private void MinHeapify(int position)
	{
		do
		{
			int left = ((position << 1) + 1);
			int right = left + 1;
			int minPosition = position;
			bool compare;

			if(left < count)
			{
				compare = array[left].CompareTo(array[position]) < 0;
				minPosition = left < count && compare ? left : position;
			}
			if(right < count)
			{
				compare = array[right].CompareTo(array[minPosition]) < 0;
				minPosition = right < count && compare ? right : minPosition;
			}

			if(minPosition != position)
			{
				mheap = this.array[position];
				this.array[position] = this.array[minPosition];
				this.array[minPosition] = mheap;
				position = minPosition;
			}
			else
			{
				return;
			}
		} while(true);
	}
}