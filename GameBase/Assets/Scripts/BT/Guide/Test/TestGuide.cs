using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Game
{
    public class TestGuide : MonoBehaviour
    {
        void Start()
        {
            return;
            this.Invoke("Test", 3);
           // NavMeshAgent _agent = gameObject.GetComponent<NavMeshAgent>();
        }


        private void Init()
        {
            GuideSquenceNode _sequence = new GuideSquenceNode("guide sequence");

            GuideActionNodeClickBtn _node1 = new GuideActionNodeClickBtn("Button 1");
            _node1.AddEvent("GuideStart");
            GuideActionNodeClickBtn _node2 = new GuideActionNodeClickBtn("Button 2");
            _node2.AddEvent("GuideStart");
            GuideActionNodeClickBtn _node3 = new GuideActionNodeClickBtn("Button 3");
            _node3.AddEvent("GuideStart");
            GuideActionNodeClickBtn _node4 = new GuideActionNodeClickBtn("btn_stop");
            _node4.AddEvent("GuideStart");
            GuideActionNodeClickBtn _node5 = new GuideActionNodeClickBtn("btn_speed");
            _node5.AddEvent("GuideStart");

            _sequence.AddChild(_node1);
            _sequence.AddChild(_node2);
            _sequence.AddChild(_node3);
            _sequence.AddChild(_node4);
            _sequence.AddChild(_node5);
            _sequence.AddChild(_node1);
            _sequence.AddChild(_node2);
            _sequence.AddChild(_node3);
            _sequence.AddChild(_node4);
            _sequence.RunNode();
        }

        private void Test()
        {
            GuideSquenceNode _sequence = new GuideSquenceNode("guide sequence");

            GuideActionNodeMove _node1 = new GuideActionNodeMove("Button 1");
            GuideInputMove _input1 = new GuideInputMove();
            _input1.position = _node1._target.anchoredPosition; _input1.size = _node1._target.sizeDelta;
            _node1.input = _input1;

            GuideActionNodeMove _node2 = new GuideActionNodeMove("Button 2");
            GuideInputMove _input2 = new GuideInputMove();
            _input2.position = _node2._target.anchoredPosition; _input2.size = _node2._target.sizeDelta;
            _node2.input = _input2;

            GuideActionNodeMove _node3 = new GuideActionNodeMove("Button 3");
            GuideInputMove _input3 = new GuideInputMove();
            _input3.position = _node3._target.anchoredPosition; _input3.size = _node3._target.sizeDelta;
            _node3.input = _input3;

            GuideActionNodeMove _node4 = new GuideActionNodeMove("btn_stop");
            GuideInputMove _input4 = new GuideInputMove();
            _input4.position = _node4._target.anchoredPosition; _input4.size = _node4._target.sizeDelta;
            _node4.input = _input4;

            GuideActionNodeMove _node5 = new GuideActionNodeMove("btn_speed");
            GuideInputMove _input5 = new GuideInputMove();
            _input5.position = _node5._target.anchoredPosition; _input5.size = _node5._target.sizeDelta;
            _node5.input = _input5;

            _sequence.AddChild(_node1);
            _sequence.AddChild(_node2);
            _sequence.AddChild(_node3);
            _sequence.AddChild(_node4);
            _sequence.AddChild(_node5);
            _sequence.AddChild(_node1);
            _sequence.AddChild(_node2);
            _sequence.AddChild(_node3);
            _sequence.AddChild(_node4);
            _sequence.RunNode();
        }
    }
}
