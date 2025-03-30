using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Assignment_3_skeleton;
using System.Xml.Linq;

[Serializable]
public class SLL : ILinkedListADT
{
    private Node head;
    private int size;

    public SLL()
    {
        head = null;
        size = 0;
    }

    public bool IsEmpty() => size == 0;

    public void Clear()
    {
        head = null;
        size = 0;
    }

    public void Append(object data)
    {
        Node newNode = new Node(data);
        if (IsEmpty())
        {
            head = newNode;
        }
        else
        {
            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
        size++;
    }

    public void Prepend(object data)
    {
        Node newNode = new Node(data) { Next = head };
        head = newNode;
        size++;
    }

    public void Insert(object data, int index)
    {
        if (index < 0 || index > size) throw new ArgumentOutOfRangeException();
        if (index == 0) { Prepend(data); return; }

        Node newNode = new Node(data);
        Node current = head;
        for (int i = 0; i < index - 1; i++)
            current = current.Next;

        newNode.Next = current.Next;
        current.Next = newNode;
        size++;
    }

    public void Replace(object data, int index)
    {
        if (index < 0 || index >= size) throw new ArgumentOutOfRangeException();
        Node current = head;
        for (int i = 0; i < index; i++)
            current = current.Next;

        current.Data = data;
    }

    public int Size() => size;

    public void Delete(int index)
    {
        if (index < 0 || index >= size) throw new ArgumentOutOfRangeException();
        if (index == 0) { head = head.Next; size--; return; }

        Node current = head;
        for (int i = 0; i < index - 1; i++)
            current = current.Next;

        current.Next = current.Next?.Next;
        size--;
    }

    public object Retrieve(int index)
    {
        if (index < 0 || index >= size) throw new ArgumentOutOfRangeException();
        Node current = head;
        for (int i = 0; i < index; i++)
            current = current.Next;

        return current.Data;
    }

    public int IndexOf(object data)
    {
        Node current = head;
        int index = 0;
        while (current != null)
        {
            if (current.Data == data) return index;
            current = current.Next;
            index++;
        }
        return -1;
    }

    public bool Contains(object data) => IndexOf(data) != -1;

    public Node ReverseList(Node head)
    {
        Node current = head;
        Node previous = null;
        Node next;
    
        while (current != null)
        {
            next = current.Next;
            current.Next = previous;
            previous = current;
            current = next;
        }
        return previous;
    }

    // Serialization
    public byte[] Serialize()
    {
        using (MemoryStream stream = new MemoryStream())
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            return stream.ToArray();
        }
    }

    public static SLL Deserialize(byte[] data)
    {
        using (MemoryStream stream = new MemoryStream(data))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            return (SLL)formatter.Deserialize(stream);
        }
    }

 
}
