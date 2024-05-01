using Fungus;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Flowchart_start : MonoBehaviour
{
    [SerializeField] private string start_block_name;
    private Flowchart chart;
    private interact_item item;
    private void Awake()
    {
        chart = GetComponent<Flowchart>();
        item = GetComponent<interact_item>();
        if (item != null )
        {
            item.OnInteraction.AddListener(Start_flow);
        }
    }

    private void Start_flow()
    {
        chart.ExecuteBlock(start_block_name);
    }
}
