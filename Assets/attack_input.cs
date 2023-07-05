using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class attack_input : MonoBehaviour
{
    List<List<int>> input_matrix = new List<List<int>> {new List<int> {7, 8, 9}, new List<int> {4, 5, 6}, new List<int> {1, 2, 3}};
    List<int> frames_input = new List<int>{5 * 20};
    int x, y;
    // Start is called before the first frame update
    void Start()
    {
        x = 1;
        y = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            x += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            x -= 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            y -= 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            y += 1;
        }
        frames_input.RemoveRange(0, 1); 
        frames_input.Add(input_matrix[y][x]);
    }
}
