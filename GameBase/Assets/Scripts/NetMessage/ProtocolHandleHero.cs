using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Game
{
    public class ProtocolHandleHero :ProtocolHandleBase<ProtocolHandleHero>
    {
        public override void RegisterHandler()
        {
            ProtocolManager.Instance.RegisterHandler(ProtocolEventName.GET_CHARACTER_LIST, ReceiveCharacterList);
            ProtocolManager.Instance.RegisterHandler(ProtocolEventName.GET_CREAT_CHARACTER, ReceiveCreatCharacter);
            ProtocolManager.Instance.RegisterHandler(ProtocolEventName.GET_RANDOM_NAME, ReceiveRandomName);
        }
        //请求角色列表
        public void RequestCharacterList()
        {
            if(NetClient.IsOffline)
            {
                /*List<Character> _list = new List<Character>();
                Character c = new Character();
                c.level = 1;
                c.name = "hero1";
                c.templateId = 1;
                //_list.Add(c);
                DataEventSource.Instance.FireEvent(ProtocolEventName.GET_CHARACTER_LIST, _list);*/
            }
            else
            {

            }
        }
        private void ReceiveCharacterList(MemoryStream ms)
        {
            //DataEventSource.Instance.FireEvent(ProtocolEventName.GET_CHARACTER_LIST, null);
        }

        public void RequestCreatCharacter(int characterId)
        {
            if(NetClient.IsOffline)
            {
                /*List<Character> _list = new List<Character>();
                Character c = new Character();
                c.level = 1;
                c.name = "hero1";
                c.templateId = 1;
                DataEventSource.Instance.FireEvent(ProtocolEventName.GET_CREAT_CHARACTER,_list);*/
            }else
            {

            }
        }

        private void ReceiveCreatCharacter(MemoryStream ms)
        {
            //DataEventSource.Instance.FireEvent(ProtocolEventName.GET_CHARACTER_LIST, null);
        }

        public void RequestRandomName()
        {
            if (NetClient.IsOffline)
            {
                //DataEventSource.Instance.FireEvent(ProtocolEventName.GET_RANDOM_NAME, "hero1");
            }
            else
            {

            }
        }

        private void ReceiveRandomName(MemoryStream ms)
        {
           // DataEventSource.Instance.FireEvent(ProtocolEventName.GET_RANDOM_NAME, null);
        }
    }
}
