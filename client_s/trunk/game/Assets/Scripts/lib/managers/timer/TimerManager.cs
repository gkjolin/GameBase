using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace XingLuoTianXia.lib 
{
    /// <summary>
    /// 时间管理器
    /// </summary>
    public class TimerManager : MonoBehaviour
    {


        /// <summary>
        /// 监听者容器
        /// </summary>
        private static List<TimerListener> _listeners = new List<TimerListener>();

        /// <summary>
        /// 时间
        /// </summary>
        private float oldTime = 0;
        private float newTime = 0;

        /// <summary>
        /// 是否运行
        /// </summary>
        public static bool isRunning = false;

        /// <summary>
        /// 单例
        /// </summary>
        private static TimerManager _instance = null;


        /// <summary>
        /// 单例
        /// </summary>
        /// <returns></returns>
        public static TimerManager getInstance()
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<TimerManager>();
            }
            return _instance;
        }


        /// <summary>
        /// 计时开始
        /// </summary>
        public void start()
        {
            isRunning = true;
            newTime = 0;
            oldTime = 0;
            StartCoroutine(run());
        }


        /// <summary>
        /// 停止计时
        /// </summary>
        public void stop()
        {
            isRunning = false;
            StopAllCoroutines();
        }


        /// <summary>
        /// 开始运行，最小计时单位是1秒
        /// </summary>
        /// <returns></returns>
        private IEnumerator run()
        {
            while (isRunning)
            {
                newTime += Time.deltaTime;

                while (newTime > 1)
                {
                    newTime--;
                    oldTime++;
                    check();
                }

                yield return null;
            }
        }


        /// <summary>
        /// 添加监听者
        /// </summary>
        /// <param name="listener"></param>
        /// <returns></returns>
        public bool addListener(TimerListener listener)
        {
            //如果已有，返回添加失败
            if (_listeners.Contains(listener))
            {
                return false;
            }

            //添加到列表
            _listeners.Add(listener);

            //如果没有运行，开始运行
            if (!isRunning)
            {
                start();
            }

            return true;
        }


        /// <summary>
        /// 移除监听者
        /// </summary>
        /// <param name="listener"></param>
        /// <returns></returns>
        public bool removeListener(TimerListener listener)
        {
            //是否有此监听者
            if (_listeners.Contains(listener))
            {
                //移除监听者
                _listeners.Remove(listener);

                //如果没有监听者，停止运行
                if (_listeners.Count == 0)
                {
                    stop();
                }

                //返回移除成功
                return true;
            }

            //没有此监听者，返回移除失败
            return false;
        }


        /// <summary>
        /// 检测所有监听者
        /// </summary>
        private void check()
        {
            //遍历所有监听者
            for (int i = 0; i < _listeners.Count; i++)
            {
                //监听者是否接受计时
                if (_listeners[i].isRunning)
                {
                    //执行回调
                    _listeners[i].listener.timerHandler(0);

                    //更新执行次数
                    if (_listeners[i].number != 0)
                    {
                        //执行次数减1
                        _listeners[i].number--;

                        //移除执行次数完成的监听者
                        if (_listeners[i].number == 0)
                        {
                            removeListener(_listeners[i]);
                        }
                    }
                }
            }
        }
    }
}
