using System;

[Serializable]
public class Node
{
    public object Data { get; set; }
    public Node Next { get; set; }

    public Node(object data)
    {
        Data = data;
        Next = null;
    }
}
