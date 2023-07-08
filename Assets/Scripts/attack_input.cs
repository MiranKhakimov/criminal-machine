using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class attack_input : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform FirePointTransform;
    private Vector2 FirePoint;

    List<List<int>> input_matrix = new List<List<int>> {new List<int> {7, 8, 9}, new List<int> {4, 5, 6}, new List<int> {1, 2, 3}};
    List<int> frames_input = Enumerable.Repeat(5, 50).ToList();
    List<int> input_for_cast;
    int x, y;
    // Start is called before the first frame update
    void Start()
    {
        FirePoint = FirePointTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        FirePoint = FirePointTransform.position;
        if (Input.GetKeyDown(KeyCode.P))
        {
            Input_Update();
            Debug.Log(string.Join(",", input_for_cast.ToArray()));
            Debug.Log(string.Join(",", frames_input.ToArray()));
            for (int i = 0; i < input_for_cast.Capacity - 2; i++) 
            {
                if (IsSublist(input_for_cast, new List<int>{2, 1, 4}) || IsSublist(input_for_cast, new List<int>{2, 3, 6}))
                {
                    var fireball = Instantiate(fireballPrefab, FirePoint, Quaternion.identity);
                    fireball.GetComponent<FireballMovement>().SetOrientation(GetComponent<movement>().faceRight);
                    break;
                }
            }
        }
    }

    void Input_Update() 
    {
        input_for_cast = new List<int>();
        input_for_cast.Add(frames_input[0]);
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
    }

    void FixedUpdate()
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

    static bool IsSublist<T>(IEnumerable<T> list1, IEnumerable<T> list2)
    {
        int count1 = list1.Count();
        int count2 = list2.Count();

        if (count2 > count1)
            return false;

        for (int i = 0; i <= count1 - count2; i++)
        {
            if (Enumerable.Range(i, count2).Select(index => list1.ElementAt(index)).SequenceEqual(list2))
                return true;
        }

        return false;
    }
}
