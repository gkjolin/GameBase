using UnityEngine;
using System.Collections;

using XingLuoTianXia.lib;

/// <summary>
/// 暂停面板
/// </summary>
public class PausePanel : UIPanelBase
{
    public void ColsePanel()
    {
        GamePanel gamePanel = UIManager.getInstance().getPanel(PanelConfig.GAMEPANEL) as GamePanel;
        if (gamePanel != null)
        {
            gamePanel.Resume();
        }
    }
}
