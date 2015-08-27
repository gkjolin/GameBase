
/// <summary>
/// 子弹数据类
/// </summary>
public class BulletData
{
    /// <summary>
    /// 飞行速度
    /// </summary>
    public int speed = 20;

    /// <summary>
    /// 攻击力
    /// </summary>
    public int ATK = 1;

    /// <summary>
    /// 被攻击后的僵直时间
    /// </summary>
    public int hurtCD = 50;

    /// <summary>
    /// 单例
    /// </summary>
    private static BulletData _instance = null;
    public static BulletData getInstance()
    {
        if(_instance == null)
        {
            _instance = new BulletData();
        }
        return _instance;
    }
}
