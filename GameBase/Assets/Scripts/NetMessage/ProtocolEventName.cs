/*
 * 协议事件，用于监听事件发送
 * example:  DataEventSource.Instance.AddEventListener(ProtocolEventName.GET_LOGIN, ReceiveLogin);
 * zhao.yabo
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class ProtocolEventName
    {
        
        public const string GET_ERROR_CODE = "get_error_code"; //获取错误码
        public const string GET_CONNECT_SERVER = "get_connect_server";//连接服务端的反馈
        public const string GET_GAME_SERVER_LIST = "get_game_server_list"; //游戏服务器列表

        public const string GET_LOGIN = "get_login";//登陆
        public const string GET_REGISTER = "get_register"; //注册
        public const string GET_ENTER_GAME = "get_enter_game"; //进入游戏
        public const string GET_RANDOM_NAME = "get_random_name";//获取随机名字
        public const string GET_CREAT_CHARACTER = "get_creat_character";//创建角色
        public const string GET_CHARACTER_LIST = "get_character_list";//获取角色列表

        public const string GET_WORLD_PROGRESS = "get_world_progress";       //获取副本进度
        public const string GET_WORLD_RESULT = "get_world_result";       //获取副本战斗结果

        public const string GET_SELL_ITEM = "get_sell_item";  //获取出售物品的反馈
        public const string GET_USE_ITEM = "get_use_item"; //使用物品的反馈
        public const string GET_ITEM = "get_item";//获取一个物品时候的反馈
        public const string GET_EQUIPMENT_CHANGE = "get_equipment_change"; //装备变化
        public const string GET_EQUIPMENT_UPGRADE = "get_equipment_upgrade"; //装备强化

        public const string GET_CALL_COMPANINO = "get_call_companino"; //召唤宠物的反馈

    }
}
