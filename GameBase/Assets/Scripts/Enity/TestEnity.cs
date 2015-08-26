using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Game
{
    public class TestEnity
    {
        private Enity _myEnity;

        public Enity MyEnity
        {
            get { return _myEnity; }
        }

        public TestEnity()
        {
            Init();
        }
        public void Init()
        {
            _myEnity = new Enity();
            _myEnity.AddProperty("name", "hero");
            _myEnity.Go = LoadModel();
            _animator = _myEnity.Go.GetComponentInChildren<Animator>();
            _myEnity.AddComponent("display", new DisplayComponent());
            _myEnity.AddComponent("actionComponent", new ActionComponent());
            _myEnity.AddComponent("transformComponent", new TransformComponent());
            _myEnity.AddComponent("titleComponent", new TitleComponent());
            //_myEnity.AddComponent("mouseInteractiveComponent", new MouseInteractiveComponent());
            _myEnity.AddComponent("lifeBarComponent", new LifeBarComponent());

            /*PatrolComponent patrolComponent = new PatrolComponent();
            _myEnity.AddComponent("patrolComponent", patrolComponent);*/
            EnityData _enityData = new EnityData();
            _myEnity.AddProperty("enityData", _enityData);
            _myEnity.Transform.gameObject.AddComponent<EnityBind>().Owner = _myEnity;

            //GameInput.Instance.OnUpdate += patrolComponent.Update;
            GetCamera();
        }
        /// <summary>
        /// 测试放在这里 添加，将来可以 以 component 形式添加
        /// </summary>f
        /// <returns></returns>
        private GameObject LoadModel()
        {
            GameObject root = new GameObject(_myEnity.GetProperty("name").ToString());
            GameObject go = GameObject.Instantiate(Resources.Load("HeroModel/Hero/A_JS_PuTong_A_001")) as GameObject;
            go.transform.SetParent(root.transform);
            CapsuleCollider collider = root.AddComponent<CapsuleCollider>();
            collider.height = 2;
            collider.center = new Vector3(0, 1, 0);
            //collider.isTrigger = true;
            Rigidbody rigidbody = root.AddComponent<Rigidbody>();
            rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
            return root;
        }

        private Transform GetCamera()
        {
            Transform _t = GameObject.Find("Hero/Camera").transform;
            Camera _camera = _t.GetComponent<Camera>();
            //_camera.targetTexture = Resources.Load("Texture/RT", typeof(RenderTexture)) as RenderTexture;
            _t.SetParent(_myEnity.Transform);
            //Enity.AddProperty("camera", _t.GetComponent<Camera>());
            return _t;
        }

        private Animator _animator;

        public Animator Animator
        {
            get { return _animator; }
        }
   
    }
}
