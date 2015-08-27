/*
 *GM 命令协议
 *zhao.yabo
 *creat 2014-12-23
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class ProtocolHandleCMD : ProtocolHandleBase<ProtocolHandleCMD>
    {
        /// <summary>
        /// 获得一个物品
        /// </summary>
        /// <param name="itemTemplateId"></param>
        /// <param name="num"></param>
        public void RequestGetItem(int itemTemplateId,int num = 1)
        {
            //UserActivityCollection.Instance.ImmediateActivity(UserActivity.Get)
        }
    }
}
