using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class attack_input : MonoBehaviour
{
    List<List<int>> input_matrix = new List<List<int>> {new List<int> {7, 8, 9}, new List<int> {4, 5, 6}, new List<int> {1, 2, 3}};
    List<int> frames_input = Enumerable.Repeat(5, 20).ToList();
    int x, y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            List<int> input_for_cast = new List<int>(frames_input[0]);
            for (int i = 1; i < frames_input.Count - 1; i++)
            {
                if (frames_input[i] != 5)
                {
                    if (frames_input[i] != frames_input[i - 1])
                    {
                        input_for_cast.Add(frames_input[i]);
                    }
                }
            }
            Debug.Log(string.Join(",", input_for_cast.ToArray()));
            Debug.Log(string.Join(",", frames_input.ToArray()));
        }
        
    }

    private void FixedUpdate()
    {
        x = 1;
        y = 1;
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
        
        frames_input.RemoveAt(0); 
        frames_input.Add(input_matrix[y][x]);

    }
}
