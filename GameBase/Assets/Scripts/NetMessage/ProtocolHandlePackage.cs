/*
 * 背包协议处理类
 * zhao.yabo
 * creat   2014-12-8 
 * modefy  2014-12-8 
 */
//using LoRServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Game
{
    public class ProtocolHandlePackage : ProtocolHandleBase<ProtocolHandlePackage>
    {
        /*private static ProtocolHandlePackage _instance;

        public static ProtocolHandlePackage Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProtocolHandlePackage();
                }
                return _instance;
            }
        }*/

        /// <summary>
        /// 批量出售物品  DataProtocolHandle.Instance.RequestSellItem();
        /// </summary>
        /// <param name="itemList">{long id, int num}</param>
        /*public void RequestSellItem(ArticleData[] itemList)
        {
            UserActivityCollection.Instance.ImmediateActivity<UserActivity.BatchSellItemActivity>()
                .InvokeActivity(itemList)
                    .WhenCompleted(OnSynaSellItemInfoSucccell, OnErrorCode)
                    .TryOfflineInvoke(0);
        }*/

        private void OnSynaSellItemInfoSucccell(int obj)
        {
           // DataEventSource.Instance.FireEvent(ProtocolEventName.GET_SELL_ITEM, obj);
        }
        /// <summary>
        /// 使用物品
        /// </summary>
        /// <param name="itemList">{long id, int num}</param>
        /*public void RequestUseItem(ArticleData[] itemList)
        {
        }*/

        /*private void OnSynaUseItemSucccell(ArticleData[] obj)
        {
            DataEventSource.Instance.FireEvent(DataNetMessageEventName.GET_USE_ITEM, obj);
        }*/
        /// <summary>
        /// 穿装备 卸载装备
        /// </summary>
        /// <param name="itemGuid"></param>
        /// <param name="isOn">1装备 0卸载 </param>
        public void RequestChangeEquipment(long itemGuid, int isOn)
        {
        }

        private void OnSynaChangeEquipment()
        {
            //DataEventSource.Instance.FireEvent(ProtocolEventName.GET_EQUIPMENT_CHANGE, null);
        }
        /// <summary>
        /// 强化装备
        /// </summary>
        /// <param name="_items">[装备、材料、材料]</param>
        /// <param name="isCostDiamond">true 钻石 false 免费</param>
        /*public void RequestUpgradeEquipment(ArticleData[] _items,bool isCostDiamond = false)
        {
            / *UserActivityCollection.Instance.ImmediateActivity<UserActivity.UpgradeEquipmentLevelActivity>()
                .InvokeActivity(isCostDiamond,_items)
                    .WhenCompleted(OnEquipmentLevelUpSuccess, OnErrorCode)
                    .TryOfflineInvoke(2);* /
        }*/

        private void OnEquipmentLevelUpSuccess(int level)
        {
           // DataEventSource.Instance.FireEvent(ProtocolEventName.GET_EQUIPMENT_UPGRADE, level);
        }

    }
}
