/*
 * 副本协议处理类
 * zhao.yabo
 * creat   2014-12-8 
 * modefy  2014-12-8 
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Game
{
    public class ProtocolHandleWorld:ProtocolHandleBase<ProtocolHandleWorld>
    {

        public override void RegisterHandler()
        {
            ProtocolManager.Instance.RegisterHandler(ProtocolEventName.GET_WORLD_PROGRESS, RecWorldProgress);
        }

        private void RecWorldProgress(MemoryStream ms)
        {
        }
        public void RequestWorldProgress()
        {
            /*ProtoWorldProgress wp = new ProtoWorldProgress();
            MemoryStreamEx mx = this.ProtobufSerialize<ProtoWorldProgress>(wp);
            CClientNetworkCtrl.Instance.SendMessage(mx);*/
        }

        private void OnSyncWorldProgressInfoSuccess(int[] progress)
        {
           // DataEventSource.Instance.FireEvent(ProtocolEventName.GET_WORLD_PROGRESS, progress);
        }

        public void RequestExitWorld(int worldid,int result)
        {
            /*LoRServer.CombatData data = new LoRServer.CombatData();
            data.money = 0;
            data.worldID = 10101;
            data.experience = 100;
            data.items = new LoRServer.ArticleData[]{};
            data.lotteryItems = new LoRServer.ArticleData[] { };

            UserActivityCollection.Instance.ImmediateActivity<UserActivity.ExitWorldActivity>()
                .InvokeActivity(worldid, 0)
                    .WhenCompleted(OnGetWorldResult, OnErrorCode)
                    .TryOfflineInvoke(data);*/
        }

        /*private void OnGetWorldResult(LoRServer.CombatData data)
        {
            Debug.Log(" diamond : " + data.diamond + ".money : " + data.money
                     + " .itemsLength : " + data.items.Length + ".lotteryItmeslength : "
                     + data.lotteryItems.Length + ".exp:" + data.experience);
            DataEventSource.Instance.FireEvent(DataNetMessageEventName.GET_WORLD_RESULT, data);

        }*/

        /// <summary>
        /// 发送副本星级
        /// </summary>
        /// <param name="worldId"></param>
        /// <param name="starLevel"></param>
        public void RequestWorldStarLevel(int worldId,int starLevel)
        {

        }

    }
}
