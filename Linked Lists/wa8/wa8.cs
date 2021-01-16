#nullable enable
using System;
using static System.Console;
using MediCal;

namespace Bme121
{
    partial class LinkedList
    {
        // Method used to indicate a target Drug object when searching.
        
        public static bool IsTarget( Drug data ) 
        { 
            return data.Name.StartsWith( "FOSAMAX", StringComparison.OrdinalIgnoreCase ); 
        }
        
        // Method used to compare two Drug objects when sorting.
        // Return is -/0/+ for a<b/a=b/a>b, respectively.
        
        public static int Compare( Drug a, Drug b )
        {
            return string.Compare( a.Name, b.Name, StringComparison.OrdinalIgnoreCase );
        }
        
        // Method used to add a new Drug object to the linked list in sorted order.
        
        public void InsertInOrder( Drug newData )
        {
           
           // start with next one
           
           Node newNode = new Node( newData); 
           
           //Inserting into an empty list
           if(Count==0)
           {
                Tail = newNode;
                Head = newNode;
                Count= 1;
                return; 
           }
           
           //Inserting into list > 0 elements
           
           Node? prevNode = null; 
           Node? currNode = Head; 
           
           for(int i = 0; i<Count; i++)
           {
                if(Compare(newData,currNode!.Data)<0)// a<b
                {
                    if(currNode == Head)//inserts at beginning
                    {
                        Node oldHead = Head; 
                        newNode.Next = oldHead; 
                        Head = newNode; 
                        Count++; 
                        return; 
                    }
                    else //inserts in the middle
                    {
                       prevNode!.Next = newNode; 
                       newNode.Next = currNode; 
                       Count++; 
                       return;
                    }
                }
                
                prevNode = currNode; 
                currNode = currNode.Next;      
    
           }
           
            //Inserts at end
            
                Node? oldTail=Tail; 
                oldTail!.Next = newNode; 
                Tail= newNode; 
                Count++;
            
        }
    }
    
    static class Program
    {
        // Method to test operation of the linked list.
        
        static void Main( )
        {
            Drug[ ] drugArray = Drug.ArrayFromFile( "RXQT1503-100.txt" );
            
            LinkedList drugList = new LinkedList( );
            foreach( Drug d in drugArray ) drugList.InsertInOrder( d );
            
            WriteLine( "drugList.Count = {0}", drugList.Count );
            foreach( Drug d in drugList.ToArray( ) ) WriteLine( d );
        }
    }
}
