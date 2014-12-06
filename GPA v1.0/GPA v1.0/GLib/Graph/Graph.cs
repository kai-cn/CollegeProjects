using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace GPA
{
    //图的邻接表的表示方法
    class Graph
    {

        //链表中的表节点的信息
        public class Node
        {
            public int adjver;
            public Node next;

            public Node(int value)
            {
                adjver=value;
            }
            
        }
        //链表中的表头节点的信息

        public class Vertex
        {
            public int data;
            public Node firstEdge;

            public Vertex(int value)
            {
                data = value;
            }
        }

        ArrayList items;    //图的顶点集合

        public Graph()
        {
            items = new ArrayList();
        }


    }
}
