﻿using UnityEngine;
using System.Collections;

//Author:ken@iamcoding.com  
public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// 寻路代理器
    /// </summary>
    private NavMeshAgent _navmeshAgent;
    
    void Start()
    {
        //获取组件  
        _navmeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //鼠标左键点击  
        if (Input.GetMouseButtonDown(0))
        {
            //摄像机到点击位置的的射线  
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //判断点击的是否地形  
                if (!hit.collider.name.Equals("Terrain"))
                {
                    return;
                }

                //点击位置坐标  
                Vector3 point = hit.point;
                //转向  
                transform.LookAt(new Vector3(point.x, transform.position.y, point.z));
                //设置寻路的目标点  
                _navmeshAgent.SetDestination(point);
            }
        }

        //播放动画，判断是否到达了目的地，播放空闲或者跑步动画  
        if (_navmeshAgent.remainingDistance == 0)
        {
            //animation.Play("idle");
        }
        else
        {
            //animation.Play("run");
        }
    }
}  
