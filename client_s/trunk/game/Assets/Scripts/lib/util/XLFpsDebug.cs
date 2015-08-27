using UnityEngine;
using System.Collections;

namespace XingLuoTianXia.lib 
{
    /// <summary>
    /// 测试用的显示FPS的代码
    /// @author CJC
    /// @date 2015-0713
    /// </summary>
    public class XLFpsDebug : MonoBehaviour
    {
        /// <summary>
        /// 字符串常量
        /// </summary>
        private const string TEXT_ENTER = "\n\n";
        private const string TEXT_FPS = "FPS:";
        private const string TEXT_MEMORY = "Memory:";
        private const string TEXT_VERTEX = "Vertex Count:";
        private const string TEXT_MESH_COUNT = "Mesh Count:";
        private const string TEXT_BORNS_COUNT = "Borns Count:";

        /// <summary>
        /// 显示fps
        /// </summary>
        public Rect startRect = new Rect(8, 8, 150, 50); // The rect the window is initially displayed at.
        public bool updateColor = true; // Do you want the color to change if the FPS gets low
        public bool allowDrag = true; // Do you want to allow the dragging of the FPS window
        public float frequency = 0.5F; // The update frequency of the fps
        public int nbDecimal = 1; // How many decimal do you want to display

        private float accum = 0f; // FPS accumulated over the interval
        private int frames = 0; // Frames drawn over the interval
        private Color color = Color.white; // The color of the GUI, depending of the FPS ( R < 10, Y < 30, G >= 30 )
        private string _fps = ""; // The fps formatted into a string.
        private GUIStyle style; // The style the text will be displayed at, based en defaultSkin.label.

        void Start()
        {
            StartCoroutine(FPS());
        }

        void Update()
        {
            accum += Time.timeScale / Time.deltaTime;
            ++frames;
        }

        IEnumerator FPS()
        {
            // Infinite loop executed every "frenquency" secondes.
            while (true)
            {
                // Update the FPS
                float fps = accum / frames;
                _fps = fps.ToString("f" + Mathf.Clamp(nbDecimal, 0, 10));

                //Update the color
                color = (fps >= 30) ? Color.green : ((fps > 10) ? Color.red : Color.yellow);

                accum = 0.0F;
                frames = 0;

                yield return new WaitForSeconds(frequency);
            }
        }

        void OnGUI()
        {
            // Copy the default label skin, change the color and the alignement
            if (style == null)
            {
                style = new GUIStyle(GUI.skin.label);
                style.normal.textColor = Color.white;
                style.alignment = TextAnchor.MiddleCenter;
                style.fontSize = 16;
            }

            GUI.color = updateColor ? color : Color.white;

            startRect = GUI.Window(0, startRect, DoMyWindow, "");
        }

        private void DoMyWindow(int windowID)
        {
            string fpsInfo = TEXT_FPS + _fps;
            //         string memoryInfo = TEXT_MEMORY + "?";
            //         string vertexInfo = TEXT_VERTEX + "?";
            //         string bornInfo = TEXT_BORNS_COUNT + "?";
            //         string meshInfo = TEXT_MESH_COUNT + "?";
            string infoStr = fpsInfo;// +TEXT_ENTER + memoryInfo + TEXT_ENTER + vertexInfo + TEXT_ENTER + meshInfo + TEXT_ENTER + bornInfo;

            GUI.Label(new Rect(0, 0, startRect.width, startRect.height), infoStr, style);
            if (allowDrag)
            {
                GUI.DragWindow(new Rect(0, 0, Screen.width, Screen.height));
            }
        }

        //	public float f_UpdateInterval = 0.5F;
        //	
        //	private float f_LastInterval;
        //	
        //	private int i_Frames = 0;
        //	
        //	private float f_Fps;
        //	
        //	void Start() 
        //	{
        //		//可以手动调节帧数
        //		//Application.targetFrameRate=60;
        //		
        //		f_LastInterval = Time.realtimeSinceStartup;
        //		
        //		i_Frames = 0;
        //	}
        //	
        //	void OnGUI() 
        //	{
        //		GUI.Label(new Rect(0, 0, 200, 200), "FPS:" + f_Fps.ToString("f2"));
        //	}
        //	
        //	void Update() 
        //	{
        //		++i_Frames;
        //		
        //		if (Time.realtimeSinceStartup > f_LastInterval + f_UpdateInterval) 
        //		{
        //			f_Fps = i_Frames / (Time.realtimeSinceStartup - f_LastInterval);
        //			
        //			i_Frames = 0;
        //			
        //			f_LastInterval = Time.realtimeSinceStartup;
        //		}
        //	}
    }
}