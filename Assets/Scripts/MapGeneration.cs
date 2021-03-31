using System;
using System.Collections;
using UnityEngine;


public class MapGeneration : MonoBehaviour {

    public Transform nodePrefab;
    public Transform roadPrefab;
    bool[,] is_road = new bool[10, 10];
    System.Random rand = new System.Random();
    // Use this for initialization
    public Transform pos;
	void Start () {
        //pos.position = new Vector3(-150, 0, 2);
        int naming = 0;
        int road_naming = 0;
        
        for(int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
                is_road[i, j] = false;
        }
        road_setting(is_road, 10, 10);
        for (int i = 0; i < 10; i++)
        {
            for(int j = 0; j < 10; j++)
            {
                pos.position = new Vector3(-150 + 5 * j, 0, 2 + 5 * i);
                if (is_road[i, j] == false)
                {
                    Transform cloneNode = Instantiate(nodePrefab, pos.position, pos.rotation);
                    cloneNode.name = "TestNode" + naming;
                    naming++;
                }
                else
                {
                    Transform cloneRoad = Instantiate(roadPrefab, pos.position, pos.rotation);
                    cloneRoad.name = "TestRoad" + road_naming;
                    road_naming++;
                }
            }
        }
        Debug.Log(rand.Next(4));
	}


    void road_setting(bool[,] node, int size_h, int size_v)
    {
        int left = rand.Next(8);
        int right = rand.Next(8) + 6;
        int up = rand.Next(8) + 6;
        int down = rand.Next(8);
        int dir;
        int test = 0;
        int ptr_i = 1;
        int ptr_j = 1;
        node[1, 1] = true;
        node[size_v - 2, size_h - 2] = true;
        
        while (ptr_i != size_v - 2 || ptr_j != size_h - 2)
        {
            if (ptr_i == 1)
                down = -1;
            if (ptr_i == size_v - 2)
                up = -1;
            if (ptr_j == 1)
                left = -1;
            if (ptr_j == size_h - 2)
                right = -1;
            dir = max(left, right, up, down);
            if(dir == 1 && node[ptr_i, ptr_j - 1] == false)
            {
                ptr_j = ptr_j - 1;
                node[ptr_i, ptr_j] = true;
            }
            else if(dir == 2 && node[ptr_i, ptr_j + 1] == false)
            {
                ptr_j = ptr_j + 1;
                node[ptr_i, ptr_j] = true;
            }
            else if(dir == 3 && node[ptr_i + 1, ptr_j] == false)
            {
                ptr_i = ptr_i + 1;
                node[ptr_i, ptr_j] = true;
            }
            else if(dir == 4 && node[ptr_i - 1, ptr_j] == false)
            {
                ptr_i = ptr_i - 1;
                node[ptr_i, ptr_j] = true;
            }
            left = rand.Next(8);
            right = rand.Next(8)+6;
            up = rand.Next(8)+6;
            down = rand.Next(8);
            test++;
            if (test == 100)
                break;
        }
        Debug.Log("Left = " + left);
        Debug.Log("Right = " + right);
        Debug.Log("forward = " + up);
    }

    int max(int a, int b, int c, int d)
    {
        if (a > b && a > c && a > d)
            return 1;
        else if (b > a && b > c && b > d)
            return 2;
        else if (c > a && c > b && c > d)
            return 3;
        else if (d > a && d > b && d > c)
            return 4;
        else
            return 0;     
    }
}