using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Game
{
    public class EnemyEnity
    {
        private Enity _myEnity;

        public Enity MyEnity
        {
            get { return _myEnity; }
        }

        public EnemyEnity()
        {
            Init();
        }

        private void Init()
        {
            _myEnity = new Enity();
            _myEnity.SetProperty("name", "enemy");
            _myEnity.Go = LoadModel();
            _myEnity.AddComponent("display", new DisplayComponent());
            _myEnity.AddComponent("actionComponent", new ActionComponent());
            _myEnity.AddComponent("transformComponent", new TransformComponent());
            _myEnity.AddComponent("lifeBarComponent", new LifeBarComponent());

            PatrolComponent patrolComponent = new PatrolComponent();
            _myEnity.AddComponent("patrolComponent", patrolComponent);

            EnityData _enityData = new EnityData();
            _myEnity.AddProperty("enityData", _enityData);
            _myEnity.Transform.gameObject.AddComponent<EnityBind>().Owner = _myEnity;

            GameInput.Instance.OnUpdate += patrolComponent.Update;

 
        }

        /// <summary>
        /// 测试放在这里 添加，将来可以 以 component 形式添加
        /// </summary>
        /// <returns></returns>
        private GameObject LoadModel()
        {
            GameObject root = new GameObject(_myEnity.GetProperty("name").ToString());
            GameObject go = GameObject.Instantiate(Resources.Load("HeroModel/Hero/A_JS_PuTong_A_001")) as GameObject;
            go.transform.SetParent(root.transform);

            CapsuleCollider collider = root.AddComponent<CapsuleCollider>();
            collider.height = 2;
            collider.center = new Vector3(0, 1, 0);
            //Rigidbody rigidbody = root.AddComponent<Rigidbody>();
            //rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
            return root;
        }
    }
}
