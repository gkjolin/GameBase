using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


namespace XingLuoTianXia.lib 
{
    /// <summary>
    /// UI管理器
    /// </summary>
    public class UIManager
    {

        /// <summary>
        /// Canvas
        /// </summary>
        public GameObject canvas;


        private Dictionary<string, UIPanelBase> _panels = new Dictionary<string, UIPanelBase>();
        /// <summary>
        /// 界面容器
        /// </summary>
        public Dictionary<string, UIPanelBase> Panels
        {
            set { _panels = value; }
            get { return _panels; }
        }

        /// <summary>
        /// 单例
        /// </summary>
        private static UIManager _instance = null;

        /// <summary>
        /// 单例
        /// </summary>
        /// <returns></returns>
        public static UIManager getInstance()
        {
            if (_instance == null)
            {
                _instance = new UIManager();
            }
            return _instance;
        }


        /// <summary>
        /// 添加面板
        /// </summary>
        /// <param name="panel"></param>
        /// <returns></returns>
        public bool addPanel(UIPanelBase panel)
        {
            //不存在，返回失败
            if (panel == null)
            {
                return false;
            }

            //已经存在返回添加失败
            if (Panels.ContainsKey(panel.panelName))
            {
                return false;
            }

            //不可见
            panel.gameObject.SetActive(false);

            //添加到容器
            Panels.Add(panel.panelName, panel);

            //返回添加成功
            return true;
        }

        /// <summary>
        /// 添加面板
        /// </summary>
        /// <param name="panelName"></param>
        /// <returns></returns>
        public bool addPanel(string panelName)
        {
            //已有，返回添加失败
            if (Panels.ContainsKey(panelName))
            {
                return false;
            }

            //没有，实例化一个
            GameObject panel = ResourceManager.getInstance().getGameObject(panelName);
            if (panel == null)
            {
                return false;
            }

            //取得面板类
            UIPanelBase uiPanelBase = panel.GetComponent<UIPanelBase>();
            if (uiPanelBase == null)
            {
                return false;
            }

            //设置面板名
            uiPanelBase.panelName = panelName;


            if (canvas == null)
            {
                canvas = GameObject.Find("Canvas");
            }
            //实例化canvas
            if (canvas == null)
            {
                canvas = ResourceManager.getInstance().getGameObject("Canvas");
                canvas.name = "Canvas";
            }

            //设置canvas为父容器
            uiPanelBase.transform.SetParent(canvas.transform, false);

            //添加到canvas里
            RectTransform rt = (uiPanelBase.gameObject.transform as RectTransform);
            rt.anchoredPosition = Vector2.zero;
            uiPanelBase.gameObject.transform.localScale = Vector3.one;

            //不可见
            panel.gameObject.SetActive(false);

            //添加到容器
            Panels.Add(panelName, uiPanelBase);

            //返回添加成功
            return true;
        }

        /// <summary>
        /// 取得面板
        /// </summary>
        /// <param name="panelName"></param>
        /// <returns></returns>
        public UIPanelBase getPanel(string panelName)
        {
            //不存在，返回null
            if (!Panels.ContainsKey(panelName))
            {
                return null;
            }

            //返回面板
            return Panels[panelName];
        }

        /// <summary>
        /// 移除一个面板
        /// </summary>
        /// <param name="panelName"></param>
        /// <returns></returns>
        public bool removePanel(string panelName)
        {
            //如果不存在这个面板，返回移除失败
            if (!Panels.ContainsKey(panelName))
            {
                return false;
            }

            //根据面板名移除面板
            Panels.Remove(panelName);

            //返回移除成功
            return true;
        }

        /// <summary>
        /// 销毁一个面板
        /// </summary>
        /// <param name="panelName"></param>
        /// <returns></returns>
        public bool destroyPanel(string panelName)
        {
            //面板不存在，返回销毁失败
            if (!Panels.ContainsKey(panelName))
            {
                return false;
            }

            //销毁面板
            GameObject.Destroy(Panels[panelName].gameObject);

            //返回销毁成功
            return true;
        }

        /// <summary>
        /// 销毁所有面板
        /// </summary>
        /// <returns></returns>
        public bool destroyAllPanel()
        {
            //是否全部销毁
            bool isComplete = true;

            //销毁所有面板
            foreach (string key in Panels.Keys)
            {
                isComplete = isComplete ? destroyPanel(key) : false;
            }

            //返回销毁结果
            return isComplete;
        }


        /// <summary>
        /// 打开面板
        /// </summary>
        /// <param name="panelName"></param>
        /// <returns></returns>
        public bool openPanel(string panelName)
        {
            //if (canvas == null)
            //{
            //    canvas = GameObject.Find("Canvas");
            //}
            ////实例化canvas
            //if (canvas == null)
            //{
            //    canvas = ResourceManager.getInstance().getGameObject("Canvas");
            //    canvas.name = "Canvas";
            //}

            //如果不存在这个面板，返回打开失败
            if (!Panels.ContainsKey(panelName))
            {
                return false;
            }

            //设置canvas为父容器
            //Panels[panelName].transform.SetParent(canvas.transform, false);

            //打开面板
            Panels[panelName].gameObject.SetActive(true);
            //RectTransform rt = (Panels[panelName].gameObject.transform as RectTransform);
            //rt.anchoredPosition = Vector2.zero;
            //Panels[panelName].gameObject.transform.localScale = Vector3.one;

            //返回打开成功
            return true;
        }


        /// <summary>
        /// 关闭面板
        /// </summary>
        /// <param name="panelName"></param>
        /// <returns></returns>
        public bool closePanel(string panelName)
        {
            //如果不存在这个面板，返回关闭失败
            if (!Panels.ContainsKey(panelName))
            {
                return false;
            }

            //设置父容器为空
            //Panels[panelName].transform.parent = null;

            //关闭面板
            Panels[panelName].gameObject.SetActive(false);

            //返回关闭成功
            return true;
        }



    }
}
