using UnityEngine;
using System.Collections;

namespace XingLuoTianXia.lib 
{
    /// <summary>
    /// shard管理器
    /// 
    /// 使用方法：
    /// battleLine.GetComponent<Renderer>().material = new Material(ShardManager.getShard(ShardManager.ShardText.NULL));
    /// 
    /// </summary>
    public class ShardManager
    {
        public enum ShardText : byte
        {
            NULL = 0,
        }

        /// <summary>
        /// 取得指定的ShardText
        /// </summary>
        /// <param name="shardName"></param>
        /// <returns></returns>
        public static string getShard(ShardText shardName)
        {
            string str =
            " Shader \"Alpha Additive\" {" +
            "Properties { _Color (\"Main Color \", Color ) = (1,1,1,0) }" +
            "SubShader {" +
            "    Tags { \"Queue\" = \"Transparent\" }" +
            "    Pass {" +
            "      Blend One One ZWrite Off ColorMask RGB" +
            "      Material { Diffuse [_Color] Ambient [_Color] }" +
            "      Lighting On" +
            "      SetTexture [_Dummy] { combine primary double, primary }" +
            "    }" +
            "}" +
            "}";

            return str;
        }
    }
}
