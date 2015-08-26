/*
public class Game : MonoBehaviour
{
    // Fields
    public static bool _bOBBCheck;
    private CommandHelper _CommandHelper;
    private bool _inExitConfirmation;
    private AsyncOperation _loadingSceneOp;
    private AsyncOperation _loadingTransitionSceneOp;
    public int _pendingInitializations;
    private bool _resetRequested;
    private GameObject _uiLoading;
    private bool _updateServerInfoSuccessfully;
    private bool _updateUabSuccessfully;
    private bool _versionCompatible;
    public string Battleid = string.Empty;
    public bool IsUTF8StringReady;
    public static float LOAD_SCENE_RATIO = 0.7f;
    private bool m_bHelperInit;
    private bool m_bLoadingScene;
    private bool m_bLoadWithoutUI;
    private ELevel m_eCurScene;
    private ELevel m_eLastBattleScene = ELevel.LVL_BattleField_0;
    private SceneLoadParams m_eLastScene = new SceneLoadParams();
    private ulong m_iFrame;
    public int m_iUID;
    public int m_iUID_DEBUG;
    private ulong m_iWaitStep;
    private ulong m_iWaitTime;
    private Battlefield m_kBattlefield;
    private NetConnector m_kConnector;
    private static Game m_kGame;
    private UIGuideManager m_kGuide;
    private NetReciever m_kReciever;
    private GameObject m_kSceneInitObject;
    private NetSender m_kSender;
    private GameObject m_kShadowPool;
    private ShadowPool m_kShadowPoolScript;
    public string m_strPlayerName;
    public string RecordUrl = string.Empty;
    public SdkRecordUrl sdkUrl;

    // Methods
    [DebuggerHidden]
    private IEnumerator _CheckObb()
    {
        return new <_CheckObb>c__Iterator28 { <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator _CheckVersion()
    {
        return new <_CheckVersion>c__Iterator2B { <>f__this = this };
    }

    private void _CreateCallbackObject()
    {
        GameObject target = GameObject.Find("AndroidCallbackObject");
        if (target == null)
        {
            target = new GameObject("AndroidCallbackObject");
            Object.DontDestroyOnLoad(target);
        }
        if ((target != null) && (target.GetComponent<SdkCallback>() == null))
        {
            target.AddComponent<SdkCallback>();
        }
    }

    private void _Debug()
    {
        if (Application.isEditor)
        {
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                Time.timeScale = 4f;
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                Time.timeScale = 1f;
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                Time.timeScale = 0.1f;
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                Time.timeScale = 10f;
            }
            if ((this._CommandHelper == null) || !this._CommandHelper.ShouldIgnoreOtherDebugInput())
            {
                if (Input.GetKeyUp(KeyCode.T))
                {
                    Singleton<UIManager>.Instance().ShowTuituUI();
                }
                if (Input.GetKeyUp(KeyCode.V))
                {
                    Singleton<UIManager>.Instance().ShowUI(FULLSCREENUI.UI_MAIL);
                }
                if (Input.GetKeyUp(KeyCode.F1))
                {
                    Singleton<UIManager>.Instance().ShowSMarketUI(1);
                }
                else if (Input.GetKeyUp(KeyCode.F2))
                {
                    Singleton<UIManager>.Instance().ShowSMarketUI(2);
                }
                else if (Input.GetKeyUp(KeyCode.F3))
                {
                    Singleton<UIManager>.Instance().ShowSMarketUI(3);
                }
                else if (Input.GetKeyUp(KeyCode.F4))
                {
                    Singleton<UIManager>.Instance().ShowSMarketUI(4);
                }
                else if (Input.GetKeyUp(KeyCode.F5))
                {
                    Singleton<UIManager>.Instance().ShowSMarketUI(5);
                }
                else if (Input.GetKeyUp(KeyCode.F6))
                {
                    Singleton<UIManager>.Instance().ShowSMarketUI(9);
                }
                else if (Input.GetKeyUp(KeyCode.F7))
                {
                    Singleton<UIManager>.Instance().ShowRanking();
                }
                else if (Input.GetKeyUp(KeyCode.P))
                {
                    Singleton<UIManager>.Instance().ShowCupTeam();
                }
                else if (Input.GetKeyUp(KeyCode.K))
                {
                    Singleton<UIManager>.Instance().ShowKakaoFriend();
                }
                else if (Input.GetKeyUp(KeyCode.R))
                {
                    Singleton<UIManager>.Instance().ShowUI(FULLSCREENUI.UI_Robot);
                }
                else if (Input.GetKeyUp(KeyCode.L))
                {
                    Singleton<SYSGuildAndGlobleInterface>.Instance().isInGuildBattle = true;
                    Instance().LoadScene(ELevel.LVL_Guild_Battle, true, false, 0);
                }
                else if (Input.GetKeyUp(KeyCode.Z))
                {
                    Singleton<SdkInterface>.Instance().PostLogout();
                }
            }
        }
    }

    private void _DeInitEvents()
    {
        MessageHelper.RemoveListener(MessageName.MN_ExitBattlefield, new MessageHandler(this._OnBattleFinished));
    }

    [DebuggerHidden]
    private IEnumerator _DownloadUabInfoLists(UabInfoListType[] types)
    {
        return new <_DownloadUabInfoLists>c__Iterator30 { types = types, <$>types = types, <>f__this = this };
    }

    [DebuggerHidden]
    public IEnumerator _GetLanServerList()
    {
        return new <_GetLanServerList>c__Iterator2C();
    }

    private bool _GetVersionInfo(string version, out int majorVersion, out int minorVersion, out int level3Version)
    {
        majorVersion = 0;
        minorVersion = 0;
        level3Version = 0;
        char[] separator = new char[] { '.' };
        string[] strArray = version.Split(separator);
        if (strArray.Length != 3)
        {
            return false;
        }
        majorVersion = Convert.ToInt32(strArray[0]);
        minorVersion = Convert.ToInt32(strArray[1]);
        level3Version = Convert.ToInt32(strArray[2]);
        return true;
    }

    [DebuggerHidden]
    public IEnumerator _GetWanServerList()
    {
        return new <_GetWanServerList>c__Iterator2D { <>f__this = this };
    }

    private void _InitEvents()
    {
        MessageHelper.AddListener(MessageName.MN_ExitBattlefield, new MessageHandler(this._OnBattleFinished));
    }

    [DebuggerHidden]
    private IEnumerator _Initialize()
    {
        return new <_Initialize>c__Iterator27 { <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator _LoadAnnouncement()
    {
        return new <_LoadAnnouncement>c__Iterator2E { <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator _LoadObbs()
    {
        return new <_LoadObbs>c__Iterator29 { <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator _LoadScene(int nLevel)
    {
        return new <_LoadScene>c__Iterator37 { nLevel = nLevel, <$>nLevel = nLevel, <>f__this = this };
    }

    private void _OnBattleFinished()
    {
        if (!Singleton<SYSGuildAndGlobleInterface>.Instance().m_bFighting)
        {
            int lastCityMapID = Singleton<GameGlobalData>.Instance().GetLastCityMapID();
            this.LoadScene((ELevel) lastCityMapID, false, false, 0);
        }
        else
        {
            Singleton<SYSGuildAndGlobleInterface>.Instance().m_bFighting = false;
            Singleton<SYSGuildAndGlobleInterface>.Instance().ReEntryWar();
        }
    }

    private void _OnDisconncet()
    {
        Debug.LogError("X+X disconnect from server");
        this.m_iWaitStep = 1L;
        this.m_iWaitTime = Singleton<UT_TimeSystem>.Instance().GetServerTime();
    }

    private void _onRequestQuitGame(int result)
    {
        if (result < 0)
        {
            Singleton<SdkInterface>.Instance().PreExit();
            Singleton<SdkInterface>.Instance().CallSdkMethod(SdkExtensionMethod.SdkOnDestroy, new object[0]);
            Application.Quit();
        }
    }

    private void _OnRequestUpdateDeferredRes(int result)
    {
        if (result == 0)
        {
            base.StartCoroutine(this._UpdateDeferredUabs());
        }
    }

    private void _OnRequestUpdateGame(int result)
    {
        if (result == 0)
        {
            Singleton<SdkInterface>.Instance().InstallNewGame();
        }
    }

    private void _OnShadowPoolDestroy()
    {
        this.m_kShadowPool = null;
        this.m_kShadowPoolScript = null;
    }

    [DebuggerHidden]
    private IEnumerator _PreloadCsvAssets()
    {
        return new <_PreloadCsvAssets>c__Iterator33 { <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator _PreloadUtf8StringsAndInitialization()
    {
        return new <_PreloadUtf8StringsAndInitialization>c__Iterator34 { <>f__this = this };
    }

    private void _RequestVersionUpdate()
    {
        if (Singleton<SdkInterface>.Instance().ShouldUseDefaultUpgradingDialog())
        {
            this.ShowAskUpdateVersion();
        }
        this.InitializationDesc = ConstString.InitializationDescGameUpdateRequested;
    }

    private void _ShowDisconnectUI()
    {
        AudioPlayer.Instance().Stop(AUDIO_TYPE.AT_SCENE_BGM);
        this.LoadScene(ELevel.LVL_Disconnection, true, true, 0);
    }

    [DebuggerHidden]
    private IEnumerator _TestObbs()
    {
        return new <_TestObbs>c__Iterator2A();
    }

    [DebuggerHidden]
    private IEnumerator _UpdateCriticalUabs()
    {
        return new <_UpdateCriticalUabs>c__Iterator2F { <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator _UpdateDeferredUabs()
    {
        return new <_UpdateDeferredUabs>c__Iterator32();
    }

    [DebuggerHidden]
    private IEnumerator _UpdateEssentialUabs()
    {
        return new <_UpdateEssentialUabs>c__Iterator31 { <>f__this = this };
    }

    public void ActivateSceneInitObject()
    {
        if ((this.m_kSceneInitObject != null) && !this.m_kSceneInitObject.activeSelf)
        {
            this.m_kSceneInitObject.SetActive(true);
            this.m_kSceneInitObject = null;
        }
    }

    public void ApplyChannelAward()
    {
        base.StartCoroutine(Singleton<SdkInterface>.Instance().ApplyAward());
    }

    private void Awake()
    {
        this.GTest();
        this.UiCamera = GameObject.Find("UI_CAMERA_Prefab");
        this.PrintLogInBegining = true;
        Debug.Log(string.Format("PrintLogInBegining begin: {0}", Platform.GetSystemTime()));
        EnumDefines.Instance();
        if (m_kGame != null)
        {
            Debug.Break();
        }
        m_kGame = this;
        Object.DontDestroyOnLoad(base.gameObject);
        Application.runInBackground = true;
        Screen.sleepTimeout = -1;
        this.IsInitialized = false;
        this.AnnouncementContent = string.Empty;
        this.InitializationPercentage = 0f;
        this.InitializationDesc = string.Empty;
        this.InitializationDescPercentage = -1f;
        base.StartCoroutine(this._Initialize());
    }

    public void ClearLoadingObject()
    {
        Object.Destroy(this._uiLoading);
        this._uiLoading = null;
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }

    public void Disconnect()
    {
        this.m_kConnector.Logout();
        this.m_kConnector.Disconnect();
    }

    public Battlefield GetBattlefield()
    {
        return this.m_kBattlefield;
    }

    public NetConnector GetConnector()
    {
        return this.m_kConnector;
    }

    public ELevel GetCurScene()
    {
        return this.m_eCurScene;
    }

    public UIGuideManager GetGuide()
    {
        if (this.m_kGuide == null)
        {
            this.m_kGuide = base.gameObject.AddComponent<UIGuideManager>();
        }
        return this.m_kGuide;
    }

    public NetSender GetNetMsgSender()
    {
        return this.m_kSender;
    }

    public ShadowPool GetShadowPool()
    {
        return this.m_kShadowPoolScript;
    }

    private void GTest()
    {
    }

    public static Game Instance()
    {
        return m_kGame;
    }

    public bool IsLoadingScene()
    {
        return (this._uiLoading != null);
    }

    public void LoadBattleScene()
    {
        if ((this.m_eLastBattleScene < ELevel.LVL_BattleField_0) || (this.m_eLastBattleScene > ELevel.LVL_BattleField_1))
        {
            this.m_eLastBattleScene = ELevel.LVL_BattleField_1;
        }
        this.LoadScene(this.m_eLastBattleScene, true, false, 0);
        if (this.m_eLastBattleScene == ELevel.LVL_BattleField_0)
        {
            this.m_eLastBattleScene = ELevel.LVL_BattleField_1;
        }
        else if (this.m_eLastBattleScene == ELevel.LVL_BattleField_1)
        {
            this.m_eLastBattleScene = ELevel.LVL_BattleField_0;
        }
        Debug.Log("loading scene .. battle");
    }

    public bool LoadLastScene()
    {
        if ((this.m_eLastScene.eLevel > ELevel.LVL_Start) && (this.m_eLastScene.eLevel < ELevel.LVL_Count))
        {
            this.LoadScene(this.m_eLastScene.eLevel, this.m_eLastScene.bAutoDestroy, this.m_eLastScene.bWithoutUI, this.m_eLastScene.nType);
            return true;
        }
        return false;
    }

    public void LoadScene(ELevel eLevel, bool bAutoDestroy = false, bool bWithoutUI = false, int nType = 0)
    {
        if ((this.m_eCurScene == eLevel) || this.m_bLoadingScene)
        {
            Debug.LogError("[Loading scene]" + eLevel.ToString() + " Twice!!");
        }
        else
        {
            this.m_eLastScene.eLevel = this.m_eCurScene;
            this.m_eLastScene.bAutoDestroy = bAutoDestroy;
            this.m_eLastScene.bWithoutUI = bWithoutUI;
            this.m_eLastScene.nType = nType;
            Debug.Log("[Loading scene] .. " + eLevel.ToString());
            this.m_bLoadWithoutUI = bWithoutUI;
            if (this._uiLoading == null)
            {
                this._uiLoading = ResourceMgr.LoadUIResources("UI/UI_LOADING_Prefab");
            }
            UILoading component = this._uiLoading.GetComponent<UILoading>();
            if (!bWithoutUI)
            {
                if (bAutoDestroy)
                {
                    component.EnableAutoDestroy();
                }
                Object.DontDestroyOnLoad(this._uiLoading);
            }
            component.SetType(nType);
            Singleton<UIManager>.Instance().ClearUI();
            base.StartCoroutine(this._LoadScene((int) eLevel));
        }
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        Singleton<SdkInterface>.Instance().ShowOrHideFloatingIcon(!pauseStatus);
        if (!pauseStatus)
        {
            if (!Singleton<SdkInterface>.Instance().InSdkView)
            {
                Singleton<SdkInterface>.Instance().PostResumeGame();
            }
            else
            {
                Singleton<SdkInterface>.Instance().InSdkView = false;
            }
        }
        else
        {
            PlayerData.Instance().IncreaseDirtyFlag(DataTypeIndex.DTI_PauseGame);
        }
    }

    private void OnApplicationQuit()
    {
        base.StartCoroutine(this.SendLogToPHP(EClientLogType.ECLT_ClickBtnCount));
        base.StartCoroutine(this.SendLogToPHP(EClientLogType.ECLT_ErrorLog));
        if (this.m_kConnector != null)
        {
            this.m_kConnector.Logout();
        }
    }

    public void OnConnectionLost()
    {
        this._resetRequested = true;
        this.m_iWaitTime = 0L;
        this.m_iWaitStep = 0L;
    }

    private void OnDestroy()
    {
        this.m_kShadowPool = null;
        this.m_kShadowPoolScript = null;
        this._DeInitEvents();
        Singleton<SysResProduce>.Instance().Exit();
        SYSAreaPathSystem.Instance().Exit();
        Singleton<SYSLevelSystem>.Instance().Exit();
        Singleton<SYSTaskSystem>.Instance().Exit();
        Singleton<SYSLotteryCard>.Instance().Exit();
        Singleton<SYSSensitiveWord>.Instance().Exit();
        Singleton<SYSShopSystem>.Instance().Exit();
        Player.GameEnd();
    }

    private void OnGUI()
    {
        Singleton<DebugOutput>.Instance().Update();
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level != 10)
        {
            this.m_bLoadingScene = false;
            MessageHelper.Broadcast<float>(MessageName.MN_LevelLoadedPercent, 1f * LOAD_SCENE_RATIO);
            if (Singleton<SYSSceneHelp>.Instance().GetPlayerSceneType(level) == SceneType.ST_CITY)
            {
                Singleton<UIManager>.Instance().ShowMainUI();
                Debug.Log("city scene loaded");
            }
            else if (Singleton<SYSSceneHelp>.Instance().GetPlayerSceneType(level) == SceneType.ST_BATTLEFIELD)
            {
                Singleton<GameGlobalData>.Instance().SetPlayerLocation(ELocationType.LT_BattleScene, Singleton<GameGlobalData>.Instance().GetSelectedLevel());
            }
            else if (Singleton<SYSSceneHelp>.Instance().GetPlayerSceneType(level) == SceneType.ST_Guild)
            {
                Singleton<UIManager>.Instance().ShowUI(FULLSCREENUI.UI_Guild_Scene);
                MessageHelper.Broadcast<float>(MessageName.MN_LevelLoadedPercent, 1f);
            }
            else if (Singleton<SYSSceneHelp>.Instance().GetPlayerSceneType(level) == SceneType.ST_Guild_War)
            {
                MessageHelper.Broadcast<float>(MessageName.MN_LevelLoadedPercent, 1f);
            }
            this.m_kSceneInitObject = GameObject.Find("InitObject");
            if (((this.m_kSceneInitObject != null) && this.m_kSceneInitObject.activeSelf) && !this.m_bLoadWithoutUI)
            {
                this.m_kSceneInitObject.SetActive(false);
            }
            Singleton<GameGlobalData>.Instance().SetLastMapID((int) this.m_eCurScene);
            this.m_eCurScene = (ELevel) level;
            this.m_bLoadWithoutUI = false;
            MessageHelper.Broadcast<ELevel>(MessageName.MN_SceneChanged, (ELevel) level);
            this._loadingSceneOp = null;
        }
        else
        {
            MessageHelper.Broadcast<float>(MessageName.MN_LevelLoadedPercent, (1f * LOAD_SCENE_RATIO) / 2f);
            this._loadingTransitionSceneOp = null;
        }
    }

    public void OnLoginSuccessed()
    {
        if (PlayerData.Instance().GetCharAvatarID() == SanguoDef.INVALID_CHARID)
        {
            this.LoadScene(ELevel.LVL_CharCreate, true, true, 0);
        }
        else
        {
            SCPositionAsset dataObject = PlayerData.Instance().GetDataObject<SCPositionAsset>(DataTypeIndex.DTI_PositionAsset);
            if (dataObject == null)
            {
                this.LoadScene(ELevel.LVL_Jinzhou, false, false, 0);
            }
            else
            {
                int iMapID = dataObject.iMapID;
                if (this.m_eCurScene != iMapID)
                {
                    this.LoadScene((ELevel) iMapID, false, false, 0);
                }
            }
            this.ApplyChannelAward();
            Singleton<SdkInterface>.Instance().CallSdkMethod(SdkExtensionMethod.InitAppStorePayment, new object[0]);
        }
    }

    private void OnRequestQuitGame()
    {
        this._onRequestQuitGame(-1);
    }

    private void OnRequestUpdateDeferredRes()
    {
        this._OnRequestUpdateDeferredRes(0);
    }

    private void OnRequestUpdateGame()
    {
        this._OnRequestUpdateGame(0);
    }

    public void OpenHelperLog()
    {
        if (!this.m_bHelperInit)
        {
            this.m_bHelperInit = true;
            this.StartCommandHelper();
            this._CommandHelper.ShowLogOnScreen(Singleton<SdkInterface>.Instance().Data.ResourceRootUrl + " (no error)", null, LogType.Error);
        }
    }

    [DebuggerHidden]
    private IEnumerator PostCrashLogToPHP(EClientLogType eType)
    {
        return new <PostCrashLogToPHP>c__Iterator36 { eType = eType, <$>eType = eType };
    }

    public void ReportLog(EClientLogType eType)
    {
        base.StartCoroutine(this.SendLogToPHP(eType));
    }

    [DebuggerHidden]
    private IEnumerator SendLogToPHP(EClientLogType eType)
    {
        return new <SendLogToPHP>c__Iterator35 { eType = eType, <$>eType = eType };
    }

    public void SetBattlefield(Battlefield kBF)
    {
        this.m_kBattlefield = kBF;
    }

    private void ShowAskQuit()
    {
        Singleton<UIManager>.Instance().ShowConfirmAskUI(ConstString.ConfirmExit, ConstString.ConfirmExitYes, new UIMessageBoxConfirm.OnConfirm(this.OnRequestQuitGame), null);
    }

    private void ShowAskUpdateFiles(float deferredUabTotalSize)
    {
        float num = (deferredUabTotalSize / 1024f) / 1024f;
        Singleton<UIManager>.Instance().ShowConfirmAskUI(string.Format(ConstString.InitializationUpdateDeferredResRequest, num.ToString("F1")), ConstString.InitializationUpdateDeferredResOk, new UIMessageBoxConfirm.OnConfirm(this.OnRequestUpdateDeferredRes), null);
    }

    private void ShowAskUpdateVersion()
    {
        Singleton<UIManager>.Instance().ShowConfirmAskUI(ConstString.GameUpdateRequested, ConstString.GameUpdateGo, new UIMessageBoxConfirm.OnConfirm(this.OnRequestUpdateGame), null);
    }

    private void ShowNetWorkFailure()
    {
        Singleton<UIManager>.Instance().ShowMessageUI("Network Failure!", new UIMessageBox.OnExternMsgBtnClick(this.OnRequestQuitGame));
    }

    private void StartCommandHelper()
    {
        GameObject target = ResourceMgr.LoadUIResources("UI/UI_CommandHelper_Prefab");
        Object.DontDestroyOnLoad(target);
        this._CommandHelper = target.GetComponent<CommandHelper>();
        Application.RegisterLogCallback(new Application.LogCallback(this._CommandHelper.ShowLogOnScreen));
    }

    private void Update()
    {
        Singleton<UT_IniConfigSystem>.Instance().Update();
        this.m_iFrame += (ulong) 1L;
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            GameObject topUI = Singleton<UIManager>.Instance().GetTopUI();
            if ((this.m_kGuide != null) && this.m_kGuide.m_bRunning)
            {
                this.m_kGuide.Close();
            }
            else if (topUI != null)
            {
                topUI.BroadcastMessage("OnReturn");
            }
            else if (!this._inExitConfirmation && !Singleton<SYSSceneHelp>.Instance().IsInBattleScene((int) Instance().GetCurScene()))
            {
                this._inExitConfirmation = true;
                if (Singleton<SdkInterface>.Instance().SdkHasExit())
                {
                    Singleton<SdkInterface>.Instance().PreExit();
                }
                else
                {
                    this.ShowAskQuit();
                }
            }
        }
        else
        {
            this._inExitConfirmation = false;
        }
        if (this.IsInitialized)
        {
            this.m_kConnector.Update();
            this.m_kReciever.Update();
            this.m_kSender.Update();
            Singleton<QualityManager>.Instance().Update();
            if ((Time.frameCount % 30) == 0)
            {
                SYSInfoSystem.Instance().Update();
                Singleton<SYSLevelSystem>.Instance().Update();
                Singleton<SYSCardSystem>.Instance().Update();
                Singleton<SYSActivitySystem>.Instance().Update();
                Singleton<SYSGuildBattleSystem>.Instance().Update();
                Singleton<SYSGlobalBattleSystem>.Instance().Update();
            }
            Singleton<SYSAdventureSystem>.Instance().Update();
            Singleton<SYSTaskSystem>.Instance().Update();
            Singleton<SYSRemotePlayerSystem>.Instance().Update();
            Singleton<SYSBroadcastSystem>.Instance().Update();
            Singleton<SYSDefeatGuideSystem>.Instance().Update();
            Singleton<SYSFriendSystem>.Instance().Update();
            SYSBuduiSystem.updateOssLog();
            Singleton<SYSBattleSystem>.Instance().Update();
            Singleton<SYSArenaSystem>.Instance().Update();
            TechSystem.UpdateOssLog();
            Singleton<SYSOther>.Instance().Update();
            Singleton<SYSChallengeSystem>.Instance().Update();
            Singleton<SYSCompetitor>.Instance().Update();
            Singleton<SYSTeamBattleSystem>.Instance().Update();
            Singleton<SYSFriendSystemKK>.Instance().Update();
            Singleton<SYSLotteryCard>.Instance().Update();
            Singleton<SYSBuduiSystem>.Instance().Update();
            Singleton<SYSGuildTeamBattleSystem>.Instance().Update();
            if (this.m_bLoadingScene)
            {
                if (this._loadingTransitionSceneOp != null)
                {
                    MessageHelper.Broadcast<float>(MessageName.MN_LevelLoadedPercent, (this._loadingTransitionSceneOp.progress * LOAD_SCENE_RATIO) / 2f);
                }
                else if (this._loadingSceneOp != null)
                {
                    MessageHelper.Broadcast<float>(MessageName.MN_LevelLoadedPercent, ((1f + this._loadingSceneOp.progress) * LOAD_SCENE_RATIO) / 2f);
                }
            }
            if (this._resetRequested)
            {
                this._resetRequested = false;
                this._OnDisconncet();
            }
            else if (((this.m_iWaitTime != 0) && (this.m_eCurScene != ELevel.LVL_Disconnection)) && !this.GetConnector().IsConnected())
            {
                if (this.m_iWaitStep > 5L)
                {
                    this.m_iWaitTime = 0L;
                    this.m_iWaitStep = 0L;
                    this._ShowDisconnectUI();
                }
                else if (Singleton<UT_TimeSystem>.Instance().GetServerTime() >= (this.m_iWaitTime + (this.m_iWaitStep * ((ulong) 5L))))
                {
                    Singleton<SYSLogin>.Instance().Login(1);
                    Debug.LogError("try auto reconnect " + this.m_iWaitStep);
                    this.m_iWaitStep += (ulong) 1L;
                }
            }
            this._Debug();
        }
    }

    // Properties
    public string AnnouncementContent { get; private set; }

    public string InitializationDesc { get; private set; }

    public float InitializationDescPercentage { get; private set; }

    public float InitializationPercentage { get; private set; }

    public bool IsInitialized { get; private set; }

    public int LoadFileCount { get; private set; }

    public bool PrintLogInBegining { get; protected set; }

    public GameObject UiCamera { get; private set; }

    // Nested Types
    [CompilerGenerated]
    private sealed class <_CheckObb>c__Iterator28 : IEnumerator, IDisposable, IEnumerator<object>
    {
        // Fields
        internal object $current;
        internal int $PC;
        internal Game <>f__this;
        internal HttpDownloader <hd>__0;
        internal string <obbInfo>__1;
        internal int <obbLevel3Version>__7;
        internal int <obbMajorVersion>__5;
        internal int <obbMinorVersion>__6;
        internal string[] <obbParts>__2;
        internal string <obbUrl>__3;
        internal string <obbVersion>__4;

        // Methods
        [DebuggerHidden]
        public void Dispose()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 1:
                    try
                    {
                    }
                    finally
                    {
                        if (this.<hd>__0 != null)
                        {
                            this.<hd>__0.Dispose();
                        }
                    }
                    break;
            }
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            bool flag = false;
            switch (num)
            {
                case 0:
                    this.<hd>__0 = new HttpDownloader();
                    num = 0xfffffffd;
                    break;

                case 1:
                    break;

                default:
                    goto Label_01A4;
            }
            try
            {
                switch (num)
                {
                    case 1:
                    {
                        if (!this.<hd>__0.IsDone)
                        {
                            break;
                        }
                        this.<obbInfo>__1 = this.<hd>__0.GetDataAsText();
                        char[] separator = new char[] { '|' };
                        this.<obbParts>__2 = this.<obbInfo>__1.Split(separator);
                        this.<obbUrl>__3 = Singleton<SdkInterface>.Instance().Data.ResourceRootUrl + this.<obbParts>__2[0];
                        Debug.Log("--------OBB " + this.<obbUrl>__3);
                        this.<obbVersion>__4 = this.<obbParts>__2[1];
                        this.<>f__this._GetVersionInfo(this.<obbVersion>__4, out this.<obbMajorVersion>__5, out this.<obbMinorVersion>__6, out this.<obbLevel3Version>__7);
                        GooglePlayDownloader.ObbMajorVersion = this.<obbMajorVersion>__5;
                        GooglePlayDownloader.ObbMinorVersion = this.<obbMinorVersion>__6;
                        GooglePlayDownloader.ObbLevel3Version = this.<obbLevel3Version>__7;
                        GooglePlayDownloader.ObbSize = Convert.ToInt32(this.<obbParts>__2[2]);
                        GooglePlayDownloader.ObbUrl = this.<obbUrl>__3;
                        goto Label_018A;
                    }
                    default:
                        this.$current = this.<>f__this.StartCoroutine(this.<hd>__0.Download(Singleton<SdkInterface>.Instance().Data.ObbUrl));
                        this.$PC = 1;
                        flag = true;
                        return true;
                }
                this.<>f__this.ShowNetWorkFailure();
            }
            finally
            {
                if (!flag)
                {
                }
                if (this.<hd>__0 != null)
                {
                    this.<hd>__0.Dispose();
                }
            }
        Label_018A:
            this.<>f__this._pendingInitializations--;
            this.$PC = -1;
        Label_01A4:
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        // Properties
        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <_CheckVersion>c__Iterator2B : IEnumerator, IDisposable, IEnumerator<object>
    {
        // Fields
        internal object $current;
        internal int $PC;
        internal Game <>f__this;
        internal HttpDownloader <hd>__0;
        internal int <localLevel3Version>__8;
        internal int <localMajorVersion>__6;
        internal int <localMinorVersion>__7;
        internal string <localVersion>__5;
        internal int <newLevel3Version>__4;
        internal int <newMajorVersion>__2;
        internal int <newMinorVersion>__3;
        internal string <newVersion>__1;

        // Methods
        [DebuggerHidden]
        public void Dispose()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 1:
                    try
                    {
                    }
                    finally
                    {
                        if (this.<hd>__0 != null)
                        {
                            this.<hd>__0.Dispose();
                        }
                    }
                    break;
            }
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            bool flag = false;
            switch (num)
            {
                case 0:
                    this.<hd>__0 = new HttpDownloader();
                    num = 0xfffffffd;
                    break;

                case 1:
                    break;

                default:
                    goto Label_0232;
            }
            try
            {
                switch (num)
                {
                    case 1:
                        if (!this.<hd>__0.IsDone)
                        {
                            goto Label_01E8;
                        }
                        this.<newVersion>__1 = this.<hd>__0.GetDataAsText();
                        this.<>f__this._GetVersionInfo(this.<newVersion>__1, out this.<newMajorVersion>__2, out this.<newMinorVersion>__3, out this.<newLevel3Version>__4);
                        this.<localVersion>__5 = Singleton<SdkInterface>.Instance().Version;
                        this.<>f__this._GetVersionInfo(this.<localVersion>__5, out this.<localMajorVersion>__6, out this.<localMinorVersion>__7, out this.<localLevel3Version>__8);
                        Debug.Log("Game bundle version check: " + this.<localVersion>__5 + " -> " + this.<newVersion>__1);
                        if (this.<newMajorVersion>__2 >= this.<localMajorVersion>__6)
                        {
                            break;
                        }
                        this.<>f__this.InitializationDesc = ConstString.InitializationDescGameTooNew;
                        goto Label_0218;

                    default:
                        Debug.Log(Singleton<SdkInterface>.Instance().Data.MajorVersionUrl);
                        this.$current = this.<>f__this.StartCoroutine(this.<hd>__0.Download(Singleton<SdkInterface>.Instance().Data.MajorVersionUrl));
                        this.$PC = 1;
                        flag = true;
                        return true;
                }
                if (this.<newMajorVersion>__2 == this.<localMajorVersion>__6)
                {
                    if (this.<newMinorVersion>__3 < this.<localMinorVersion>__7)
                    {
                        this.<>f__this.InitializationDesc = ConstString.InitializationDescGameTooNew;
                    }
                    else if (this.<newMinorVersion>__3 == this.<localMinorVersion>__7)
                    {
                        if (this.<newLevel3Version>__4 < this.<localLevel3Version>__8)
                        {
                            this.<>f__this.InitializationDesc = ConstString.InitializationDescGameTooNew;
                        }
                        else
                        {
                            this.<>f__this._versionCompatible = true;
                        }
                    }
                    else
                    {
                        this.<>f__this._RequestVersionUpdate();
                    }
                }
                else
                {
                    this.<>f__this._RequestVersionUpdate();
                }
                goto Label_0218;
            Label_01E8:
                this.<>f__this.InitializationDesc = ConstString.InitializationDescGettingMajorVersionFailed;
            }
            finally
            {
                if (!flag)
                {
                }
                if (this.<hd>__0 != null)
                {
                    this.<hd>__0.Dispose();
                }
            }
        Label_0218:
            this.<>f__this._pendingInitializations--;
            this.$PC = -1;
        Label_0232:
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        // Properties
        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <_DownloadUabInfoLists>c__Iterator30 : IEnumerator, IDisposable, IEnumerator<object>
    {
        // Fields
        internal object $current;
        internal int $PC;
        internal UabInfoListType[] <$>types;
        internal Game <>f__this;
        internal SyncOperation <loc>__0;
        internal UabInfoListType[] types;

        // Methods
        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    this.<loc>__0 = new SyncOperation();
                    this.<>f__this.StartCoroutine(Singleton<UabManager>.Instance().DownloadUabInfoLists(this.types, this.<loc>__0));
                    break;

                case 1:
                    break;

                default:
                    goto Label_0090;
            }
            if (!this.<loc>__0.IsDone)
            {
                this.$current = null;
                this.$PC = 1;
                return true;
            }
            this.<>f__this._pendingInitializations--;
            this.$PC = -1;
        Label_0090:
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        // Properties
        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <_GetLanServerList>c__Iterator2C : IEnumerator, IDisposable, IEnumerator<object>
    {
        // Fields
        internal object $current;
        internal int $PC;
        internal JsonData <jsonData>__1;
        internal byte[] <postData>__2;
        internal float <startTime>__0;
        internal WWW <www>__3;

        // Methods
        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    this.<startTime>__0 = Time.timeSinceLevelLoad;
                    this.<jsonData>__1 = new JsonData();
                    this.<jsonData>__1["channeltype"] = (JsonData) Singleton<SdkInterface>.Instance().Data.ChannelType;
                    this.<jsonData>__1["version"] = Singleton<SdkInterface>.Instance().Version;
                    this.<postData>__2 = Encoding.UTF8.GetBytes(this.<jsonData>__1.ToJson());
                    Debug.Log("LAN Server Post Data " + this.<jsonData>__1.ToJson());
                    this.<www>__3 = new WWW("http://192.168.1.46/info.php", this.<postData>__2);
                    this.$current = this.<www>__3;
                    this.$PC = 1;
                    goto Label_019A;

                case 1:
                case 2:
                    if (!this.<www>__3.isDone)
                    {
                        if ((Time.timeSinceLevelLoad - this.<startTime>__0) <= 1f)
                        {
                            this.$current = new WaitForEndOfFrame();
                            this.$PC = 2;
                            goto Label_019A;
                        }
                        break;
                    }
                    if ((this.<www>__3.isDone && (this.<www>__3.error == null)) && (this.<www>__3.text != string.Empty))
                    {
                        SYSServerSystem.Instance().UpdateServerInfo(this.<www>__3.text, ServerGroupType.SGT_LAN);
                    }
                    else
                    {
                        Debug.Log("Lan Server List is Null");
                    }
                    Debug.Log("LAN Server List Get End!!");
                    this.$PC = -1;
                    break;
            }
            return false;
        Label_019A:
            return true;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        // Properties
        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <_GetWanServerList>c__Iterator2D : IEnumerator, IDisposable, IEnumerator<object>
    {
        // Fields
        internal object $current;
        internal int $PC;
        internal Game <>f__this;
        internal HttpDownloader <hd>__2;
        internal JsonData <jsonData>__0;
        internal byte[] <postData>__1;

        // Methods
        [DebuggerHidden]
        public void Dispose()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 1:
                    try
                    {
                    }
                    finally
                    {
                        if (this.<hd>__2 != null)
                        {
                            this.<hd>__2.Dispose();
                        }
                    }
                    break;
            }
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            bool flag = false;
            switch (num)
            {
                case 0:
                    this.<>f__this.InitializationDesc = ConstString.InitializationDescConnectingServer;
                    this.<jsonData>__0 = new JsonData();
                    this.<jsonData>__0["channeltype"] = (JsonData) Singleton<SdkInterface>.Instance().Data.ChannelType;
                    this.<jsonData>__0["version"] = Singleton<SdkInterface>.Instance().Version;
                    this.<jsonData>__0["os"] = ((int) Application.platform).ToString();
                    this.<postData>__1 = Encoding.UTF8.GetBytes(this.<jsonData>__0.ToJson());
                    Debug.Log("WAN Server " + Singleton<SdkInterface>.Instance().Data.ServerListUrl + " | Post Data " + this.<jsonData>__0.ToJson());
                    this.<hd>__2 = new HttpDownloader();
                    num = 0xfffffffd;
                    break;

                case 1:
                    break;

                default:
                    goto Label_01F4;
            }
            try
            {
                switch (num)
                {
                    case 1:
                        if (!this.<hd>__2.IsDone || !(this.<hd>__2.GetDataAsText() != string.Empty))
                        {
                            break;
                        }
                        SYSServerSystem.Instance().UpdateServerInfo(this.<hd>__2.GetDataAsText(), ServerGroupType.SGT_WAN);
                        goto Label_01A4;

                    default:
                        this.$current = this.<>f__this.StartCoroutine(this.<hd>__2.Download(Singleton<SdkInterface>.Instance().Data.ServerListUrl, this.<postData>__1));
                        this.$PC = 1;
                        flag = true;
                        return true;
                }
                Debug.Log("Wan Server List is Null");
                this.<>f__this.InitializationDesc = ConstString.InitializationDescConnectServerFailed;
            Label_01A4:
                this.<>f__this._updateServerInfoSuccessfully = true;
            }
            finally
            {
                if (!flag)
                {
                }
                if (this.<hd>__2 != null)
                {
                    this.<hd>__2.Dispose();
                }
            }
            Debug.Log("WAN Server List Get End!!");
            this.<>f__this._pendingInitializations--;
            this.$PC = -1;
        Label_01F4:
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        // Properties
        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <_Initialize>c__Iterator27 : IEnumerator, IDisposable, IEnumerator<object>
    {
        // Fields
        internal object $current;
        internal int $PC;
        internal Game <>f__this;
        internal bool <bFlag>__2;
        internal bool <bMusic>__7;
        internal GameObject <camera>__3;
        internal float <deferredUabTotalSize>__9;
        internal RegionLanguage <lang>__10;
        internal string <strEndGetWanServerList>__1;
        internal string <strEndPreloadUtf8StringsAndInitialization>__5;
        internal string <strEndPrintLogInBegining>__8;
        internal string <strEndSdkInit>__6;
        internal string <strEndUpdateCriticalUabs>__4;
        internal string <strStartGetWanServerList>__0;

        // Methods
        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    this.<>f__this._CreateCallbackObject();
                    if (Singleton<SdkInterface>.Instance().HasVideoRecorder() && !Singleton<ConfigSystem>.Instance().GetBool(ConfigSystem.ConfigType.Toggle_Aipai, false))
                    {
                        Singleton<SdkInterface>.Instance().HideAipaiToolbar();
                    }
                    if (!Singleton<SdkInterface>.Instance().HasObb())
                    {
                        ConstString.InitialiseLocalText();
                    }
                    this.<strStartGetWanServerList>__0 = Platform.GetSystemTime();
                    this.<>f__this.StartCoroutine(this.<>f__this._GetLanServerList());
                    this.<>f__this.StartCoroutine(this.<>f__this._GetWanServerList());
                    this.<>f__this._pendingInitializations++;
                    break;

                case 1:
                    break;

                case 2:
                    goto Label_01A6;

                case 3:
                    goto Label_020D;

                case 4:
                    goto Label_02E8;

                case 5:
                    goto Label_0370;

                case 6:
                    goto Label_044A;

                case 7:
                    goto Label_04B9;

                case 8:
                    goto Label_0558;

                case 9:
                    goto Label_0656;

                default:
                    goto Label_0994;
            }
            while (this.<>f__this._pendingInitializations > 0)
            {
                this.$current = null;
                this.$PC = 1;
                goto Label_0996;
            }
            this.<strEndGetWanServerList>__1 = Platform.GetSystemTime();
            if (!this.<>f__this._updateServerInfoSuccessfully)
            {
                this.<>f__this.ShowNetWorkFailure();
                goto Label_0994;
            }
            this.<>f__this._updateUabSuccessfully = false;
            Debug.Log(string.Format("Start Check OBB Url {0}", Singleton<SdkInterface>.Instance().Data.ObbUrl));
            if (!Singleton<SdkInterface>.Instance().HasObb())
            {
                goto Label_0232;
            }
            this.<>f__this.StartCoroutine(this.<>f__this._CheckObb());
            this.<>f__this._pendingInitializations++;
        Label_01A6:
            while (this.<>f__this._pendingInitializations > 0)
            {
                this.$current = null;
                this.$PC = 2;
                goto Label_0996;
            }
            Debug.Log(string.Format("End _pending _CheckObb. {0}", Platform.GetSystemTime()));
            this.<>f__this.StartCoroutine(this.<>f__this._LoadObbs());
            this.<>f__this._pendingInitializations++;
        Label_020D:
            while (this.<>f__this._pendingInitializations > 0)
            {
                this.$current = null;
                this.$PC = 3;
                goto Label_0996;
            }
            Debug.Log(string.Format("End _pending _LoadObbs. {0}", Platform.GetSystemTime()));
        Label_0232:
            Game._bOBBCheck = true;
            this.<bFlag>__2 = Singleton<ConfigSystem>.Instance().GetBool(ConfigSystem.ConfigType.CommandHelper_Flag, false);
            if (SYSServerSystem.Instance().BeConnectLan && this.<bFlag>__2)
            {
                this.<>f__this.OpenHelperLog();
            }
            this.<camera>__3 = GameObject.Find("UI_CAMERA_Prefab");
            if (this.<camera>__3 == null)
            {
                Debug.LogError("fatal issue: UI_CAMERA_Prefab isn't found!");
            }
            Object.DontDestroyOnLoad(this.<camera>__3);
            this.<>f__this.StartCoroutine(this.<>f__this._UpdateCriticalUabs());
            this.<>f__this._pendingInitializations++;
        Label_02E8:
            while (this.<>f__this._pendingInitializations > 0)
            {
                this.$current = null;
                this.$PC = 4;
                goto Label_0996;
            }
            this.<strEndUpdateCriticalUabs>__4 = Platform.GetSystemTime();
            if (!this.<>f__this._updateUabSuccessfully)
            {
                Debug.LogError("fail to update critical uabs");
                this.<>f__this.ShowNetWorkFailure();
                goto Label_0994;
            }
            this.<>f__this.StartCoroutine(this.<>f__this._PreloadUtf8StringsAndInitialization());
            this.<>f__this._pendingInitializations++;
        Label_0370:
            while (this.<>f__this._pendingInitializations > 0)
            {
                this.$current = null;
                this.$PC = 5;
                goto Label_0996;
            }
            this.<strEndPreloadUtf8StringsAndInitialization>__5 = Platform.GetSystemTime();
            this.<>f__this.IsUTF8StringReady = true;
            this.<>f__this.StartCoroutine(this.<>f__this._CheckVersion());
            this.<>f__this._pendingInitializations++;
            UabInfoListType[] types = new UabInfoListType[] { UabInfoListType.Essential, UabInfoListType.Deferred };
            this.<>f__this.StartCoroutine(this.<>f__this._DownloadUabInfoLists(types));
            this.<>f__this._pendingInitializations++;
            this.<>f__this.StartCoroutine(this.<>f__this._LoadAnnouncement());
            Singleton<SdkInterface>.Instance().InitSdk();
            Singleton<PushInterface>.Instance().InitPush();
            Singleton<PushInterface>.Instance().BindPush();
        Label_044A:
            while (!Singleton<SdkInterface>.Instance().Data.IsSdkInited)
            {
                this.$current = null;
                this.$PC = 6;
                goto Label_0996;
            }
            this.<strEndSdkInit>__6 = Platform.GetSystemTime();
            Singleton<ConfigSystem>.Instance();
            this.<bMusic>__7 = Singleton<ConfigSystem>.Instance().GetBool(ConfigSystem.ConfigType.Effect_SoundSwitch, true);
            AudioListener.volume = !this.<bMusic>__7 ? 0f : 1f;
        Label_04B9:
            while (this.<>f__this._pendingInitializations > 0)
            {
                this.$current = null;
                this.$PC = 7;
                goto Label_0996;
            }
            this.<strEndPrintLogInBegining>__8 = Platform.GetSystemTime();
            if (!Singleton<SdkInterface>.Instance().Data.IsCommandLineVisible)
            {
                this.<>f__this.PrintLogInBegining = false;
            }
            if (!this.<>f__this._versionCompatible)
            {
                goto Label_0994;
            }
            this.<>f__this._updateUabSuccessfully = false;
            this.<>f__this.StartCoroutine(this.<>f__this._UpdateEssentialUabs());
            this.<>f__this._pendingInitializations++;
        Label_0558:
            while (this.<>f__this._pendingInitializations > 0)
            {
                this.$current = null;
                this.$PC = 8;
                goto Label_0996;
            }
            if (!this.<>f__this._updateUabSuccessfully)
            {
                goto Label_0994;
            }
            this.<deferredUabTotalSize>__9 = Singleton<UabManager>.Instance().GetNewUabTotalSize(UabInfoListType.Deferred);
            Debug.Log("deferredUabTotalSize " + this.<deferredUabTotalSize>__9.ToString());
            if (this.<deferredUabTotalSize>__9 > 0f)
            {
                this.<lang>__10 = Singleton<SdkInterface>.Instance().Data.Language;
                if ((Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork) && (this.<lang>__10 != RegionLanguage.Japanese))
                {
                    this.<>f__this.ShowAskUpdateFiles(this.<deferredUabTotalSize>__9);
                }
                else
                {
                    this.<>f__this.StartCoroutine(this.<>f__this._UpdateDeferredUabs());
                }
            }
            this.<>f__this.StartCoroutine(this.<>f__this._PreloadCsvAssets());
            this.<>f__this._pendingInitializations++;
        Label_0656:
            while (this.<>f__this._pendingInitializations > 0)
            {
                this.$current = null;
                this.$PC = 9;
                goto Label_0996;
            }
            Singleton<UT_IniConfigSystem>.Instance().Load("INI/config");
            Singleton<ScriptMgr>.Instance().Init();
            this.<>f__this.m_kConnector = new NetConnector();
            this.<>f__this.m_kReciever = new NetReciever();
            this.<>f__this.m_kReciever.SetConnector(this.<>f__this.m_kConnector);
            this.<>f__this.m_kConnector.SetReciever(this.<>f__this.m_kReciever);
            this.<>f__this.m_kSender = new NetSender();
            this.<>f__this.m_kSender.SetConnector(this.<>f__this.m_kConnector);
            Singleton<QualityManager>.Instance();
            Singleton<DebugOutput>.Instance();
            PlayerData.Instance().Init();
            Singleton<UT_TimeSystem>.Instance().Init();
            Singleton<GameGlobalData>.Instance().Init();
            Singleton<UIManager>.Instance().Init();
            TechSystem.Init();
            Singleton<SYSBroadcastSystem>.Instance().Init();
            Singleton<SYSCardSystem>.Instance().Init();
            Singleton<SYSTaskSystem>.Instance().Init();
            SYSInfoSystem.Instance().Init();
            Singleton<SYSBattleSystem>.Instance().Init();
            Singleton<SysResProduce>.Instance().Init();
            SYSAreaPathSystem.Instance().Init();
            Singleton<SYSLevelSystem>.Instance().Init();
            Singleton<SYSLotteryCard>.Instance().Init();
            Singleton<SYSRemotePlayerSystem>.Instance().Init();
            Singleton<SYSDefeatGuideSystem>.Instance().Init();
            Singleton<SYSActivitySystem>.Instance().Init();
            Singleton<SYSSensitiveWord>.Instance().Init();
            Singleton<SYSFriendSystem>.Instance().Init();
            Singleton<SYSFriendSystemKK>.Instance().Init();
            Singleton<SYSShopSystem>.Instance().Init();
            Singleton<SYSArenaSystem>.Instance().Init();
            Singleton<SYSNoticeSystem>.Instance().Init();
            Singleton<SYSChat>.Instance().Init();
            Singleton<SYSRemoteEventSystem>.Instance().Init();
            Singleton<SYSOther>.Instance().Init();
            Singleton<SYSChallengeSystem>.Instance().Init();
            SYSServerMessage.Instance().Init();
            Singleton<SYSMagicWeapon>.Instance().Init();
            Singleton<SYSSMarket>.Instance().Init();
            Singleton<SYSRankingSystem>.Instance().Init();
            Singleton<SYSGuild>.Instance().Init();
            Singleton<SYSCompetitor>.Instance().Init();
            Singleton<SYSTeamBattleSystem>.Instance().Init();
            Singleton<SysDispatch>.Instance().Init();
            Singleton<SysAdventureEvent>.Instance().Init();
            Singleton<SYSGuildBattleSystem>.Instance().Init();
            Singleton<SYSGlobalBattleSystem>.Instance().Init();
            Singleton<SYSBuduiSystem>.Instance().Init();
            Singleton<SYSEquipmentSystem>.Instance().Init();
            Singleton<SYSGuildTeamBattleSystem>.Instance().Init();
            this.<>f__this.m_kShadowPool = ResourceMgr.LoadResources("ShadowPoolPrefab");
            Object.DontDestroyOnLoad(this.<>f__this.m_kShadowPool);
            this.<>f__this.m_kShadowPoolScript = this.<>f__this.m_kShadowPool.GetComponent<ShadowPool>();
            this.<>f__this._InitEvents();
            Player.GameStart();
            Player.SetAccountID();
            this.<>f__this.IsInitialized = true;
            string[] textArray1 = new string[] { "StartGetWanList=", this.<strStartGetWanServerList>__0, "|EndGetWanList=", this.<strEndGetWanServerList>__1, "|EndUpdateUabs=", this.<strEndUpdateCriticalUabs>__4, "|EndUpdateUtf8=", this.<strEndPreloadUtf8StringsAndInitialization>__5, "|SdkInitSuccess=", this.<strEndSdkInit>__6, "|EndPrintLogInBegining=", this.<strEndPrintLogInBegining>__8, "|" };
            SYSInfoSystem.Instance().AddClientLog(EClientLogType.ECLT_LoadingTime, string.Concat(textArray1));
            this.$PC = -1;
        Label_0994:
            return false;
        Label_0996:
            return true;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        // Properties
        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <_LoadAnnouncement>c__Iterator2E : IEnumerator, IDisposable, IEnumerator<object>
    {
        // Fields
        internal object $current;
        internal int $PC;
        internal Game <>f__this;
        internal HttpDownloader <hd>__0;

        // Methods
        [DebuggerHidden]
        public void Dispose()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 1:
                    try
                    {
                    }
                    finally
                    {
                        if (this.<hd>__0 != null)
                        {
                            this.<hd>__0.Dispose();
                        }
                    }
                    break;
            }
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            bool flag = false;
            switch (num)
            {
                case 0:
                    this.<hd>__0 = new HttpDownloader();
                    num = 0xfffffffd;
                    break;

                case 1:
                    break;

                default:
                    goto Label_00C3;
            }
            try
            {
                switch (num)
                {
                    case 1:
                        break;

                    default:
                        this.$current = this.<>f__this.StartCoroutine(this.<hd>__0.Download(Singleton<SdkInterface>.Instance().Data.AnnouncementUrl));
                        this.$PC = 1;
                        flag = true;
                        return true;
                }
                if (this.<hd>__0.IsDone)
                {
                    this.<>f__this.AnnouncementContent = this.<hd>__0.GetDataAsText();
                }
            }
            finally
            {
                if (!flag)
                {
                }
                if (this.<hd>__0 != null)
                {
                    this.<hd>__0.Dispose();
                }
            }
            this.$PC = -1;
        Label_00C3:
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        // Properties
        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <_LoadObbs>c__Iterator29 : IEnumerator, IDisposable, IEnumerator<object>
    {
        // Fields
        internal object $current;
        internal int $PC;
        internal Game <>f__this;
        internal string <expPath>__0;
        internal string <mainPath>__1;

        // Methods
        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    this.<expPath>__0 = GooglePlayDownloader.GetExpansionFilePath();
                    if (this.<expPath>__0 == null)
                    {
                        break;
                    }
                    this.<mainPath>__1 = GooglePlayDownloader.GetMainOBBPath(this.<expPath>__0);
                    if (this.<mainPath>__1 != null)
                    {
                        break;
                    }
                    GooglePlayDownloader.FetchOBB();
                    this.$current = this.<>f__this.StartCoroutine(this.<>f__this._TestObbs());
                    this.$PC = 1;
                    return true;

                case 1:
                    break;

                default:
                    goto Label_009A;
            }
            this.<>f__this._pendingInitializations--;
            this.$PC = -1;
        Label_009A:
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        // Properties
        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <_LoadScene>c__Iterator37 : IEnumerator, IDisposable, IEnumerator<object>
    {
        // Fields
        internal object $current;
        internal int $PC;
        internal int <$>nLevel;
        internal Game <>f__this;
        internal AsyncOperation <locAsyncOp>__0;
        internal int nLevel;

        // Methods
        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    this.<>f__this.m_bLoadingScene = true;
                    this.<locAsyncOp>__0 = null;
                    if (this.<>f__this._uiLoading == null)
                    {
                        break;
                    }
                    this.<>f__this._loadingTransitionSceneOp = Application.LoadLevelAsync(10);
                    this.$current = this.<>f__this._loadingTransitionSceneOp;
                    this.$PC = 1;
                    goto Label_0127;

                case 1:
                    this.<locAsyncOp>__0 = Resources.UnloadUnusedAssets();
                    this.$current = this.<locAsyncOp>__0;
                    this.$PC = 2;
                    goto Label_0127;

                case 2:
                    GC.Collect();
                    break;

                case 3:
                    if (this.<>f__this._uiLoading == null)
                    {
                        goto Label_011E;
                    }
                    this.<locAsyncOp>__0 = Resources.UnloadUnusedAssets();
                    this.$current = this.<locAsyncOp>__0;
                    this.$PC = 4;
                    goto Label_0127;

                case 4:
                    GC.Collect();
                    goto Label_011E;

                default:
                    goto Label_0125;
            }
            this.<>f__this._loadingSceneOp = Application.LoadLevelAsync(this.nLevel);
            this.$current = this.<>f__this._loadingSceneOp;
            this.$PC = 3;
            goto Label_0127;
        Label_011E:
            this.$PC = -1;
        Label_0125:
            return false;
        Label_0127:
            return true;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        // Properties
        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <_PreloadCsvAssets>c__Iterator33 : IEnumerator, IDisposable, IEnumerator<object>
    {
        // Fields
        internal object $current;
        internal int $PC;
        internal Game <>f__this;
        internal float <INCREMENT>__0;
        internal int <lastPreloadedCSVs>__1;

        // Methods
        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    this.<INCREMENT>__0 = 1f - this.<>f__this.InitializationPercentage;
                    Debug.Log("Preload CSV UABs and assets...");
                    this.<>f__this.InitializationDescPercentage = 0f;
                    this.<>f__this.InitializationDesc = ConstString.InitializationDescLoadingCsv;
                    this.<>f__this.StartCoroutine(CsvManager.PreloadAssets());
                    this.<lastPreloadedCSVs>__1 = CsvManager.PreloadedCSVs;
                    break;

                case 1:
                    if (CsvManager.PreloadedCSVs != this.<lastPreloadedCSVs>__1)
                    {
                        this.<lastPreloadedCSVs>__1 = CsvManager.PreloadedCSVs;
                        this.<>f__this.InitializationPercentage += this.<INCREMENT>__0 / 144f;
                        this.<>f__this.InitializationDescPercentage += 0.006944444f;
                    }
                    break;

                default:
                    goto Label_010F;
            }
            if (CsvManager.PreloadedCSVs < 0x90)
            {
                this.$current = null;
                this.$PC = 1;
                return true;
            }
            this.<>f__this._pendingInitializations--;
            this.$PC = -1;
        Label_010F:
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        // Properties
        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <_PreloadUtf8StringsAndInitialization>c__Iterator34 : IEnumerator, IDisposable, IEnumerator<object>
    {
        // Fields
        internal object $current;
        internal int $PC;
        internal Game <>f__this;

        // Methods
        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    Debug.Log("Start to load and initialise utf8strings...");
                    this.<>f__this.StartCoroutine(ConstString.Initialise());
                    break;

                case 1:
                    break;

                default:
                    goto Label_0082;
            }
            if (!ConstString.Initialized)
            {
                this.$current = null;
                this.$PC = 1;
                return true;
            }
            this.<>f__this._pendingInitializations--;
            Debug.Log("done utf8strings...");
            this.$PC = -1;
        Label_0082:
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        // Properties
        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <_TestObbs>c__Iterator2A : IEnumerator, IDisposable, IEnumerator<object>
    {
        // Fields
        internal object $current;
        internal int $PC;
        internal string <expPath>__0;
        internal string <mainPath>__1;

        // Methods
        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    this.<expPath>__0 = GooglePlayDownloader.GetExpansionFilePath();
                    break;

                case 1:
                    this.<mainPath>__1 = GooglePlayDownloader.GetMainOBBPath(this.<expPath>__0);
                    if (this.<mainPath>__1 == null)
                    {
                        break;
                    }
                    this.$PC = -1;
                    goto Label_006B;

                default:
                    goto Label_006B;
            }
            this.$current = new WaitForSeconds(0.5f);
            this.$PC = 1;
            return true;
        Label_006B:
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        // Properties
        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <_UpdateCriticalUabs>c__Iterator2F : IEnumerator, IDisposable, IEnumerator<object>
    {
        // Fields
        internal object $current;
        internal int $PC;
        internal Game <>f__this;
        internal UpdateUabsInListAsyncOperation <updateUabsAsyncOp>__0;

        // Methods
        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    Debug.Log(string.Format("start to update critical uabs", new object[0]));
                    this.<>f__this.StartCoroutine(Singleton<UabManager>.Instance().DownloadUabInfoLists(new UabInfoListType[1], null));
                    this.<updateUabsAsyncOp>__0 = Singleton<UabManager>.Instance().DownloadUabsInList(UabInfoListType.Critical);
                    break;

                case 1:
                    break;

                default:
                    goto Label_00D1;
            }
            if (this.<updateUabsAsyncOp>__0.IsUpdating)
            {
                this.$current = null;
                this.$PC = 1;
                return true;
            }
            this.<>f__this._updateUabSuccessfully = this.<updateUabsAsyncOp>__0.IsDone;
            this.<>f__this._pendingInitializations--;
            Debug.Log(string.Format("done updating critical uabs", new object[0]));
            this.$PC = -1;
        Label_00D1:
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        // Properties
        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <_UpdateDeferredUabs>c__Iterator32 : IEnumerator, IDisposable, IEnumerator<object>
    {
        // Fields
        internal object $current;
        internal int $PC;
        internal UpdateUabsInListAsyncOperation <updateUabsAsyncOp>__0;

        // Methods
        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    Debug.Log("Update Deferred UABs...");
                    this.<updateUabsAsyncOp>__0 = Singleton<UabManager>.Instance().DownloadUabsInList(UabInfoListType.Deferred);
                    break;

                case 1:
                    break;

                default:
                    goto Label_006B;
            }
            if (this.<updateUabsAsyncOp>__0.IsUpdating)
            {
                this.$current = null;
                this.$PC = 1;
                return true;
            }
            this.$PC = -1;
        Label_006B:
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        // Properties
        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <_UpdateEssentialUabs>c__Iterator31 : IEnumerator, IDisposable, IEnumerator<object>
    {
        // Fields
        internal object $current;
        internal int $PC;
        internal Game <>f__this;
        internal float <INCREMENT>__1;
        internal float <INIT_PERCENTAGE>__0;
        internal UpdateUabsInListAsyncOperation <updateUabsAsyncOp>__2;

        // Methods
        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    this.<INIT_PERCENTAGE>__0 = this.<>f__this.InitializationPercentage;
                    this.<INCREMENT>__1 = 0.6f - this.<>f__this.InitializationPercentage;
                    this.<updateUabsAsyncOp>__2 = Singleton<UabManager>.Instance().DownloadUabsInList(UabInfoListType.Essential);
                    break;

                case 1:
                    break;

                default:
                    goto Label_0126;
            }
            if (this.<updateUabsAsyncOp>__2.IsUpdating)
            {
                this.<>f__this.InitializationPercentage = this.<INIT_PERCENTAGE>__0 + (this.<updateUabsAsyncOp>__2.Progress * this.<INCREMENT>__1);
                this.<>f__this.InitializationDesc = this.<updateUabsAsyncOp>__2.UpdatingDescription;
                this.$current = null;
                this.$PC = 1;
                return true;
            }
            this.<>f__this.InitializationPercentage = this.<INIT_PERCENTAGE>__0 + (this.<updateUabsAsyncOp>__2.Progress * this.<INCREMENT>__1);
            this.<>f__this.InitializationDesc = this.<updateUabsAsyncOp>__2.UpdatingDescription;
            this.<>f__this._updateUabSuccessfully = this.<updateUabsAsyncOp>__2.IsDone;
            this.<>f__this._pendingInitializations--;
            this.$PC = -1;
        Label_0126:
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        // Properties
        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <PostCrashLogToPHP>c__Iterator36 : IEnumerator, IDisposable, IEnumerator<object>
    {
        // Fields
        internal object $current;
        internal int $PC;
        internal EClientLogType <$>eType;
        internal Dictionary<string, string>.Enumerator <$s_400>__3;
        internal Dictionary<string, string> <dicCrashInfo>__1;
        internal WWWForm <form>__2;
        internal KeyValuePair<string, string> <postArg>__4;
        internal string <url>__0;
        internal WWW <www>__5;
        internal EClientLogType eType;

        // Methods
        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    this.<url>__0 = Singleton<SdkInterface>.Instance().Data.CrashReportLogUrl;
                    this.<dicCrashInfo>__1 = SYSInfoSystem.Instance().GetCrashReportInfo(this.eType);
                    this.<form>__2 = new WWWForm();
                    this.<$s_400>__3 = this.<dicCrashInfo>__1.GetEnumerator();
                    try
                    {
                        while (this.<$s_400>__3.MoveNext())
                        {
                            this.<postArg>__4 = this.<$s_400>__3.Current;
                            this.<form>__2.AddField(this.<postArg>__4.Key, this.<postArg>__4.Value);
                        }
                    }
                    finally
                    {
                        this.<$s_400>__3.Dispose();
                    }
                    if (!string.IsNullOrEmpty(this.<dicCrashInfo>__1["stat_info"].Trim()))
                    {
                        this.<www>__5 = new WWW(this.<url>__0, this.<form>__2);
                        this.$current = this.<www>__5;
                        this.$PC = 2;
                    }
                    else
                    {
                        this.$current = null;
                        this.$PC = 1;
                    }
                    return true;

                case 1:
                    break;

                case 2:
                    if (this.<www>__5.error == null)
                    {
                        Debug.Log("Post crashReport is finished.");
                        break;
                    }
                    Debug.Log("Post crashReport has something wrong:" + this.<www>__5.error);
                    break;

                default:
                    goto Label_016F;
            }
            this.$PC = -1;
        Label_016F:
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        // Properties
        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <SendLogToPHP>c__Iterator35 : IEnumerator, IDisposable, IEnumerator<object>
    {
        // Fields
        internal object $current;
        internal int $PC;
        internal EClientLogType <$>eType;
        internal string <url>__0;
        internal WWW <www>__1;
        internal EClientLogType eType;

        // Methods
        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    this.<url>__0 = SYSInfoSystem.Instance().GetClientLogURL(this.eType);
                    if (string.IsNullOrEmpty(this.<url>__0))
                    {
                        break;
                    }
                    this.<url>__0 = this.<url>__0.Replace(" ", "*");
                    this.<www>__1 = new WWW(this.<url>__0);
                    this.$current = this.<www>__1;
                    this.$PC = 1;
                    return true;

                case 1:
                    break;

                default:
                    goto Label_0092;
            }
            this.$PC = -1;
        Label_0092:
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        // Properties
        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    private class SceneLoadParams
    {
        // Fields
        public bool bAutoDestroy;
        public bool bWithoutUI;
        public ELevel eLevel;
        public int nType;
    }

    public enum SdkRecordUrl
    {
        None,
        Lan,
        CnAndroid,
        CnJailBreak,
        CnAppStore,
        Tencent,
        Hmt,
        Japan,
        Korea,
        Kakao,
        Thailand
    }
}

 
Collapse Methods
 
*/
