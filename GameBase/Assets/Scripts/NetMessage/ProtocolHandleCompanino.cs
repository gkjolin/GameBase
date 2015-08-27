/*
 *宠物模块协议处理
 *zhao.yabo 
 * 
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Game
{
    public class ProtocolHandleCompanino:ProtocolHandleBase<ProtocolHandleCompanino>
    {
        /// <summary>
        /// 宠物召唤
        /// </summary>
        /// <param name="templateId"></param>
        public void RequestCallCompanino(int templateId)
        {
            /*ProtoCompanino pc = new ProtoCompanino();
            pc.companinoTemplateId = templateId;
            MemoryStreamEx ms= this.ProtobufSerialize<ProtoCompanino>(pc);
            CClientNetworkCtrl.Instance.SendMessage(ms);*/
#if OFFLINE
            DataEventSource.Instance.FireEvent(ProtocolEventName.GET_WORLD_PROGRESS,pc);
#endif

        }


        private void OnCallCompanino()
        {
            //DataEventSource.Instance.FireEvent(ProtocolEventName.GET_CALL_COMPANINO, null);
        }
    }
}
