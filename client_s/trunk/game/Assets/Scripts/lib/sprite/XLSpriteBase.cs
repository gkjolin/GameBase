using UnityEngine;
using System.Collections;

namespace XingLuoTianXia.lib 
{
    /// <summary>
    /// 精灵基类
    /// @author CJC
    /// @date 2015-05
    /// </summary>
    public abstract class XLSpriteBase : MonoBehaviour
    {
        /// <summary>
        /// 数据
        /// </summary>
        public SoldierDataBase _data;

        /// <summary>
        /// 势力
        /// </summary>
        public Defaults.Country Country
        {
            get { return _data.Country; }
        }

        /// <summary>
        /// 当前状态
        /// </summary>
        protected XLStateBase _currentState;
        public XLStateBase CurrentState
        {
            get { return _currentState; }
        }

        /// <summary>
        /// 上一个状态
        /// </summary>
        protected XLStateBase _preState;
        public XLStateBase PreState
        {
            get { return _preState; }
        }

        public void Awake()
        {
            spriteInit();
        }

        /// <summary>
        /// 精灵暂停时的逻辑
        /// </summary>
        public virtual void pause()
        {

        }

        /// <summary>
        /// 精灵恢复时的逻辑
        /// </summary>
        public virtual void resume()
        {

        }

        /// <summary>
        /// 逻辑更新
        /// </summary>
        public void Update()
        {
            if (frameLogic())
            {
                return;
            }

            if (_currentState != null)
            {
                _currentState.update();
            }
        }

        /// <summary>
        /// 设置新状态
        /// </summary>
        /// <param name="newState"></param>
        /// <returns></returns>
        public virtual bool setState(XLStateBase newState)
        {
            if (newState == null || _currentState == newState)
            {
                return false;
            }

            if (_preState != null)
            {
                _preState.stop();
            }

            _preState = _currentState;
            _currentState = newState;

            newState.init();
            return true;
        }

        /// <summary>
        /// 恢复前一个状态
        /// </summary>
        /// <returns></returns>
        public bool setToPreState()
        {
            if (_preState == null)
            {
                return false;
            }

            _preState.resume();
            setState(_preState);
            return true;
        }

        /// <summary>
        /// 当前状态是否是指定状态
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool isCurrentState(XLStateBase state)
        {
            return (_currentState == state);
        }

        /// <summary>
        /// 精灵初始化
        /// </summary>
        public virtual void spriteInit()
        {

        }

        /// <summary>
        /// 是否能作为别的人目标
        /// </summary>
        /// <returns></returns>
        public virtual bool isCanBeTarget()
        {
            return false;
        }

        /// <summary>
        /// 调度逻辑
        /// </summary>
        /// <returns></returns>
        public abstract bool frameLogic();
    }
}

