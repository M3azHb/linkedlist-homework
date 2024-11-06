
using System;



public class ListNode<T>
{
    public T Value { get; set; }
    public ListNode<T> Next { get; set; }

    public ListNode(T value)
    {
        Value = value;
        Next = null;
    }
}

public class SLinkedList<T>
{
    private ListNode<T> head;

    public SLinkedList()
    {
        head = null;
    }

    //ميثود تضيف عقدة في البداية
    public void Prepend(T value)
    {
        ListNode<T> newNode = new ListNode<T>(value);
        newNode.Next = head;
        head = newNode;
    }

    // ميثود تضبف عقدة في النهاية
    public void Append(T value)
    {
        ListNode<T> newNode = new ListNode<T>(value);
        if (head == null)
        {
            head = newNode;
            return;
        }

        ListNode<T> current = head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = newNode;
    }

    // ميثود تدخل عقدة في فهرس محدد
    public void InsertAt(T value, int index)
    {
        if (index < 0) throw new ArgumentOutOfRangeException("Index must be non-negative");

        if (index == 0)
        {
            Prepend(value);
            return;
        }

        ListNode<T> newNode = new ListNode<T>(value);
        ListNode<T> current = head;

        for (int i = 0; i < index - 1; i++)
        {
            if (current == null) throw new ArgumentOutOfRangeException("Index exceeds list length");
            current = current.Next;
        }

        newNode.Next = current.Next;
        current.Next = newNode;
    }

    //مثود تزبل العقدة الاولى 
    public void RemoveFirst()
    {
        if (head == null) throw new InvalidOperationException("List is empty");
        head = head.Next;
    }

    //مثود تزبل العقدة الاخيرة 
    public void RemoveLast()
    {
        if (head == null) throw new InvalidOperationException("List is empty");

        if (head.Next == null)
        {
            head = null;
            return;
        }

        ListNode<T> current = head;
        while (current.Next.Next != null)
        {
            current = current.Next;
        }
        current.Next = null;
    }

    // مثود تزيل عقدة في فهرس محدد
    public void RemoveAt(int index)
    {
        if (index < 0) throw new ArgumentOutOfRangeException("Index must be non-negative");

        if (index == 0)
        {
            RemoveFirst();
            return;
        }

        ListNode<T> current = head;

        for (int i = 0; i < index - 1; i++)
        {
            if (current == null || current.Next == null) throw new ArgumentOutOfRangeException("Index exceeds list length");
            current = current.Next;
        }

        if (current.Next == null) throw new ArgumentOutOfRangeException("Index exceeds list length");

        current.Next = current.Next.Next;
    }

    // عرض كل العقد في القائمة
    public void PrintList()
    {
        ListNode<T> current = head;
        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        SLinkedList<string> linkedList = new SLinkedList<string>();

        linkedList.Append("A");
        linkedList.Append("B");
        linkedList.Prepend("C");

        Console.WriteLine("Current List:");
        linkedList.PrintList(); 

        linkedList.InsertAt("D", 1);

        Console.WriteLine("After Inserting D at index 1:");
        linkedList.PrintList(); 

        linkedList.RemoveLast();

        Console.WriteLine("After Removing Last:"); linkedList.PrintList(); 

        linkedList.RemoveAt(0);

        Console.WriteLine("After Removing at Index 0:");
        linkedList.PrintList(); 
    }
}