using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;


namespace AP.VAST.Control.wf
{
    /*using TLoginInfo = PlatformSDK.TLoginInfo;
    using TServerStatusInfo = PlatformSDK.TServerStatusInfo;
    using EServerType = PlatformSDK.EServerType;
    using TDeviceInfo = PlatformSDK.TDeviceInfo;
    using TStreamInfo = PlatformSDK.TStreamInfo;
    using TLocalFileInfo = PlatformSDK.TLocalFileInfo;
    using TStreamDataInfo = PlatformSDK.TStreamDataInfo;
    using TStreamStatusInfo = PlatformSDK.TStreamStatusInfo;
    using TVideoDecodeInfo = PlatformSDK.TVideoDecodeInfo;*/


    public partial class VASTNet : UserControl
    {

        #region SDK 
        internal const int MAX_DECODE_TYPE_LEN = 15;
        internal const int MAX_NODEUNIT_LEN = 40;
        internal const int MAX_REFNAME_LEN = 98;
        internal const int MAX_IPHOST_LEN = 128;
        internal const int MAX_USERNAME_LEN = 64;
        internal const int MAX_HEXPWD_LEN = 128;
        internal const int MAX_MODEL_LEN = 128;
        internal const int MAX_TUNNEL_RESPONSE_LENGTH = (10 * 1024 * 1024);
        internal const int MAX_EVENT_TIME_LEN = 31;
        internal const int MAX_EVENT_ARGS_LEN = 64;
        internal const int MAX_ALARM_DESC_LEN = 1024;
        internal const int MAX_SUBSTATION_LAYER = 7;
        internal const int MAX_SUBSTATION_PATH_LEN = MAX_NODEUNIT_LEN * MAX_SUBSTATION_LAYER;

        internal const int TUNNEL_CONNECT = 0;
        internal const int TUNNEL_DISCONNECT = 1;

        internal enum EMediaType : int
        {
            e3gp = 0,
            eAVI
        }

        internal enum EDeviceType : uint
        {
            unknown,
            camera,
            externalDevice,
            station,
            cmsStation,
        }

        internal enum EEventType : uint
        {
            unknown,
            DI,
            DO,
            motion,
            tampering,
            PIR,
            videoLoss,
        }

        internal enum EConnectionStatus : uint
        {
            unknown,
            connected,
            disconnected,
        }

        internal enum EServerType : uint
        {
            configServer,
            eventServer,
        }

        internal enum EStreamSource : uint
        {
            VAST,
            CMS,
        }

        internal enum EStreamMode : uint
        {
            normalStream,
            retrieveOneSnapshot,
        }

        internal enum EStreamTimeType : uint
        {
            recordingTime,
            cameraTime,
        }

        internal enum EStreamStatus : uint
        {
            ok,
            timeout,
            otherError,
            stopped,
            authFailed,
            exportFinish,
        }

        internal enum EVideoDecodeType : uint
        {
            JPEG,
            BMP24,
            BMP32,
            YUV,
            YV12,
        }

        internal enum ESDKPTZType : uint
        {
            physicalPTZ,
            ePTZ,
        }

        internal enum EPTZCommand : uint
        {
            right,
            left,
            up,
            down,
            home,
            leftUp,
            rightUp,
            leftDown,
            rightDown,
            focusAuto,
            focusNear,
            focusFar,
            zoomIn,
            zoomOut,
            startPan,
            startPatrol,
            stopPan,
            irisAuto,
            irisOpen,
            irisClose,
            setHome,
            defaultHome,
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4), Serializable]
        internal struct TServerStatusInfo
        {
            internal int hLoginID;
            internal EServerType serverType;
            internal EConnectionStatus status;
            internal IntPtr context;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 4), Serializable]
        internal struct TEventInfo
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_NODEUNIT_LEN + 1)]
            internal string deviceID;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_EVENT_TIME_LEN + 1)]
            internal string time;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_EVENT_ARGS_LEN + 1)]
            internal string args;
            internal EDeviceType deviceType;
            internal EEventType eventType;
            internal byte init;
            internal byte trigger;
            internal int index;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4), Serializable]
        internal struct TDeviceStatusInfo
        {
            internal EDeviceType deviceType;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_NODEUNIT_LEN + 1)]
            internal string deviceID;
            internal EConnectionStatus connectionStatus;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4), Serializable]
        internal struct TDeviceInfo
        {
            internal EDeviceType deviceType;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_NODEUNIT_LEN + 1)]
            internal string deviceID;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_REFNAME_LEN + 1)]
            internal string refName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_IPHOST_LEN + 1)]
            internal string IP;
            internal uint port;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_USERNAME_LEN + 1)]
            internal string userName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_HEXPWD_LEN + 1)]
            internal string password;
            internal int channelIndex;    //start from 1
            internal int DINum;
            internal int DONum;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 4), Serializable]
        internal struct TAlarmInfo
        {
            internal int ID;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_REFNAME_LEN + 1)]
            internal string alarmName;
            internal IntPtr content;
            internal int contentLen;
            internal bool enabled;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4), Serializable]
        internal struct TManualAlarmInfo
        {
            internal int ID;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_ALARM_DESC_LEN + 1)]
            internal byte[] szDescription;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4), Serializable]
        internal struct TAlarmNotification
        {
            internal IntPtr content;
            internal int contentLen;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4), Serializable]
        internal struct TSnapshotCBInfo
        {
            internal int responseCode;                    // 0 = request success, overwise fail
            internal IntPtr image;
            internal int imageSize;
            internal IntPtr context;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4), Serializable]
        internal struct TVideoDecodeInfo
        {
            internal int hChannel;
            internal IntPtr pBuffer;
            internal int bufSize;
            internal int height;
            internal int width;
            internal uint frameSecond;
            internal uint frameMilSec;
            internal IntPtr context;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4), Serializable]
        internal struct TStreamDataInfo
        {
            internal int hChannel;
            internal IntPtr pBuffer;
            internal int bufferSize;
            internal uint frameSecond;
            internal uint frameMilSec;
            internal IntPtr context;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4), Serializable]
        internal struct TStreamStatusInfo
        {
            internal int hChannel;
            internal EStreamStatus status;
            internal IntPtr context;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4), Serializable]
        internal struct TEventListInfo
        {
            internal IntPtr pEventList;      //pointer to array of TEventInfo
            internal uint eventNum;
            internal IntPtr rawContent;
            internal uint rawContentLen;
            internal IntPtr context;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void pfDeviceStatusCallBack(IntPtr pStatusList, int statusNum, IntPtr context);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void pfEventCallBack(IntPtr pEventListInfo);    //pEventListInfo pointer to TEventListInfo

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void pfAlarmCallBack(IntPtr pAlarmList, int alarmNum, IntPtr context);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void pfAlarmNotificationCallBack(IntPtr pAlarmList, int alarmNum, IntPtr context);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal unsafe delegate void pfExportCallBack(IntPtr pStatusInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void pfMessCallBack(IntPtr pStatusInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void pfStreamDataCallBack(IntPtr pStreamDataInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void pfYV12DataCallBack(int hChannel, IntPtr pBuffer, uint bufferSize
            , int height, int width, int dataType, IntPtr context);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void pfPCMDataCallBack(int hChannel, IntPtr pBuffer, uint bufferSize
            , uint samplingFreq, uint samplingSize, uint channelNum, IntPtr context);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void pfVideoDecodeCallBack(IntPtr pVideoDecodeInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void pfStreamStatusCallBack(IntPtr pStatusInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void pfSnapshotCallBack(IntPtr pSnapshotInfo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void pfHeartbeatCallBack(IntPtr pStatusInfo);

        [StructLayout(LayoutKind.Sequential, Pack = 4), Serializable]
        internal struct TStreamInfo
        {
            internal int hLoginID;
            internal IntPtr hDisplayWindow;
            internal EStreamSource streamSource;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_SUBSTATION_PATH_LEN + 1)]
            internal string substationPath;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_NODEUNIT_LEN + 1)]
            internal string cameraID;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_REFNAME_LEN + 1)]
            internal string cameraRefName;
            internal short streamIndex;
            internal uint startTime;
            internal uint endTime;
            internal IntPtr context;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal pfStreamDataCallBack pfStreamDataCB;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal pfYV12DataCallBack pfYV12DataCB;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal pfPCMDataCallBack pfPCMDataCB;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal pfVideoDecodeCallBack pfVideoDecodeCB;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal pfStreamStatusCallBack pfStreamStatusCB;
            internal EVideoDecodeType decodeType;
            internal EStreamMode streamMode;
            internal EStreamTimeType timeType;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4), Serializable]
        internal struct TLocalFileInfo
        {
            internal IntPtr hDisplayWindow;
            internal string filePath;
        }

        [Serializable, StructLayout(LayoutKind.Sequential)]
        internal struct TLoginInfo
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_IPHOST_LEN + 1)]
            internal string IP;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_USERNAME_LEN + 1)]
            internal string userName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_HEXPWD_LEN + 1)]
            internal string password;
            internal int port;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal pfMessCallBack pfMessCB;
            internal IntPtr context;
            internal int timeoutSeconds;
            internal bool blockLogin;          //false = non-block, true = block login until success or timeout
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4), Serializable]
        internal unsafe struct TExportFileInfo
        {
            internal EMediaType mediaType;			    // input EMediaType: 3gp, avi, ...
            internal int hLoginID;			            // login handle
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_SUBSTATION_PATH_LEN + 1)]
            internal string substationPath;               // main station = ""
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_NODEUNIT_LEN + 1)]
            internal string cameraID;
            internal short streamIndex;		            // camera stream index, start from 1
            internal int startTime;		                // start time seconds, (dt - new DateTime (1970, 1, 1)).TotalSeconds
            internal int endTime;			                // end time seconds
            internal IntPtr context;		                // user define callback context
            internal string exportDir;		            // directory of export file
            internal string exportFilename;	            // filename of export file            
            internal pfExportCallBack pfExportFileCB;     // callback function to notify export finish
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4), Serializable]
        internal unsafe struct TSnapshotRetrieveInfo
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_NODEUNIT_LEN + 1)]
            internal string cameraID;
            internal int channelIndex;		            // camera channel index, start from 1
            internal int streamIndex;		                // camera stream index, start from 1
            internal int retrieveTime;		            // total seconds of retrieve time
            [MarshalAs(UnmanagedType.FunctionPtr)]
            internal pfSnapshotCallBack pfSnapshotCB;
            internal IntPtr context;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4), Serializable]
        internal unsafe struct TSDKChannelSnapshotInfo
        {
            internal IntPtr pszOutputDir;
            internal IntPtr pszFileName;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4), Serializable]
        internal unsafe struct TSDKDeviceListRequest
        {
            internal int timeoutMillisecond;
            internal string stationID;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4), Serializable]
        internal unsafe struct TSDKDeviceListResponse
        {
            internal IntPtr pDeviceList;
            internal int deviceNum;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4), Serializable]
        internal unsafe struct TPTZRequest
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_NODEUNIT_LEN + 1)]
            internal string cameraID;
            internal uint channelIndex;   //start from 1
            internal uint streamIndex;    //start from 1
            internal ESDKPTZType PTZType;
            internal EPTZCommand command;
            internal int speed;
        }

        [DllImport("ServerControl.dll", CharSet = CharSet.Unicode, EntryPoint = "PlatformSDK_Initial")]
        static private extern unsafe int Initial();

        [DllImport("ServerControl.dll", CharSet = CharSet.Unicode, EntryPoint = "PlatformSDK_Release")]
        static private extern unsafe int Release();

        [DllImport("ServerControl.dll", CharSet = CharSet.Unicode, EntryPoint = "PlatformSDK_Login")]
        static private extern unsafe int Login(ref int phLoginID, ref TLoginInfo ptLoginOption);

        [DllImport("ServerControl.dll", CharSet = CharSet.Unicode, EntryPoint = "PlatformSDK_Logout")]
        static private extern unsafe int Logout(ref int phLoginID);

        [DllImport("ServerControl.dll", CharSet = CharSet.Unicode, EntryPoint = "PlatformSDK_GetDeviceList")]
        unsafe private static extern int GetDeviceList(int hLoginID, ref TSDKDeviceListRequest request, ref TSDKDeviceListResponse response);

        [DllImport("ServerControl.dll", CharSet = CharSet.Unicode, EntryPoint = "PlatformSDK_MonitorAlarm")]
        unsafe private static extern int MonitorAlarm(int hLoginID, pfAlarmCallBack alarmCB, IntPtr context);

        [DllImport("ServerControl.dll", CharSet = CharSet.Unicode, EntryPoint = "PlatformSDK_GetAlarmInfoList")]
        unsafe private static extern int GetAlarmInfoList(int hLoginID, ref IntPtr ppAlarmInfoList, int* pdwAlarmInfoNum);

        [DllImport("ServerControl.dll", CharSet = CharSet.Unicode, EntryPoint = "PlatformSDK_TriggerAlarm")]
        unsafe private static extern int TriggerAlarm(int hLoginID, ref TManualAlarmInfo alarmInfo);

        [DllImport("ServerControl.dll", CharSet = CharSet.Unicode, EntryPoint = "PlatformSDK_UpdateAlarm")]
        unsafe private static extern int UpdateAlarm(int hLoginID, IntPtr pszMessage);

        [DllImport("ServerControl.dll", CharSet = CharSet.Unicode, EntryPoint = "PlatformSDK_MonitorAlarmNotification")]
        unsafe private static extern int MonitorAlarmNotification(int hLoginID, pfAlarmNotificationCallBack pfAlarmNotificationCB, IntPtr context);

        [DllImport("ServerControl.dll", CharSet = CharSet.Unicode, EntryPoint = "PlatformSDK_MonitorDeviceStatus")]
        unsafe private static extern int MonitorDeviceStatus(int hLoginID, pfDeviceStatusCallBack statusCB, IntPtr context);

        [DllImport("ServerControl.dll", CharSet = CharSet.Unicode, EntryPoint = "PlatformSDK_MonitorEvent")]
        unsafe private static extern int MonitorEvent(int hLoginID, pfEventCallBack eventCB, IntPtr context);

        [DllImport("ServerControl.dll", CharSet = CharSet.Unicode, EntryPoint = "PlatformSDK_ExportMediaFile")]
        static private extern unsafe int ExportMediaFile(ref TExportFileInfo tExportFileInfo);

        [DllImport("ServerControl.dll", CharSet = CharSet.Unicode, EntryPoint = "PlatformSDK_SetDO")]
        static private extern unsafe int SetDO(int hLoginID, IntPtr deviceID, int index, int value);

        [DllImport("ServerControl.dll", CharSet = CharSet.Unicode, EntryPoint = "PlatformSDK_ClosePopupWindow")]
        static private extern unsafe int ClosePopupWindow(int hLoginID, int* camIDList, int camNum);

        [DllImport("ServerControl.dll", CharSet = CharSet.Unicode, EntryPoint = "PlatformSDK_CreateLiveChannel")]
        static private extern unsafe int CreateLiveChannel(ref int phChannel, ref TStreamInfo streamInfo);

        [DllImport("ServerControl.dll", CharSet = CharSet.Unicode, EntryPoint = "PlatformSDK_DeleteLiveChannel")]
        static private extern unsafe int DeleteLiveChannel(ref int phChannel);

        [DllImport("ServerControl.dll", CharSet = CharSet.Unicode, EntryPoint = "PlatformSDK_CreateNetFileChannel")]
        static private extern unsafe int CreateNetFileChannel(ref int phChannel, ref TStreamInfo streamInfo);

        [DllImport("ServerControl.dll", CharSet = CharSet.Unicode, EntryPoint = "PlatformSDK_DeleteNetFileChannel")]
        static private extern unsafe int DeleteNetFileChannel(ref int phChannel);

        [DllImport("ServerControl.dll", CharSet = CharSet.Unicode, EntryPoint = "PlatformSDK_CreateLocalFileChannel")]
        static private extern unsafe int CreateLocalFileChannel(ref int phChannel, ref TLocalFileInfo localFileInfo);

        [DllImport("ServerControl.dll", CharSet = CharSet.Unicode, EntryPoint = "PlatformSDK_DeleteLocalFileChannel")]
        static private extern unsafe int DeleteLocalFileChannel(ref int phChannel);

        [DllImport("ServerControl.dll", CharSet = CharSet.Unicode, EntryPoint = "PlatformSDK_Snapshot")]
        static private extern unsafe int SaveChannelSnapshot(int hChannel, ref TSDKChannelSnapshotInfo snapshotInfo);

        [DllImport("ServerControl.dll", CharSet = CharSet.Unicode, EntryPoint = "PlatformSDK_StartChannel")]
        static private extern unsafe int StartChannel(int hChannel);

        [DllImport("ServerControl.dll", CharSet = CharSet.Unicode, EntryPoint = "PlatformSDK_StopChannel")]
        static private extern unsafe int StopChannel(int hChannel);

        [DllImport("ServerControl.dll", CharSet = CharSet.Unicode, EntryPoint = "PlatformSDK_PauseChannel")]
        static private extern unsafe int PauseChannel(int hChannel);

        [DllImport("ServerControl.dll", CharSet = CharSet.Unicode, EntryPoint = "PlatformSDK_GetSnapshot")]
        static private extern unsafe int GetSnapshot(int hChannel, ref TSnapshotRetrieveInfo snapshotInfo);

        [DllImport("ServerControl.dll", CharSet = CharSet.Unicode, EntryPoint = "PlatformSDK_PTZControl")]
        static private extern unsafe int PTZControl(int hChannel, ref TPTZRequest request);

        #endregion


        #region Variables & Helpers

        int loginID = 0;

        int hChannel = 0;

        pfStreamDataCallBack streamDataCB = null;

        pfStreamStatusCallBack streamStatusCB = null;

        pfMessCallBack messCB = null;

        GCHandle gcThis;

        const int MILLISEC_PER_SECOND = 1000;

        enum ETunnelState : int
        {
            offline,           //when receive eDisconnected, we then change state to eOffLine
            online,            //when receive eTunnelConnect, we then change state to eOnLine
            connected,         //mark on tunnel establish
            disconnected,      //mark on tunnel disconnect            
        }

        int configServerState = (int)ETunnelState.offline;

        int eventServerState = (int)ETunnelState.offline;

        enum EChannelType
        {
            unknown,
            live,
            playback,
            localFile,
        }


        EChannelType channelType = EChannelType.unknown;

        private static readonly DateTime dateTime1970 = new DateTime(1970, 1, 1);

        #endregion

        #region Private Methods

        private void LoginCallBack(IntPtr pStatusInfo)
        {
            TServerStatusInfo info = (TServerStatusInfo)Marshal.PtrToStructure(pStatusInfo, typeof(TServerStatusInfo));

            Console.WriteLine("LoginCallBack: " + info.hLoginID
                + ", " + GetServerTypeString(info.serverType)
                + " " + GetConnStatusString(info.status));

            if (info.serverType == EServerType.configServer)
            {
                HandleConfigServerStatusChange(info.status);
            }
            else if (info.serverType == EServerType.eventServer)
            {
                HandleEventServerStatusChange(info.status);
            }
        }

        private void HandleConfigServerStatusChange(EConnectionStatus status)
        {
            switch (status)
            {
                case EConnectionStatus.connected:
                    Interlocked.Exchange(ref configServerState, (int)ETunnelState.connected);
                    break;

                case EConnectionStatus.disconnected:
                    Interlocked.Exchange(ref configServerState, (int)ETunnelState.disconnected);
                    break;
            }
        }

        private void HandleEventServerStatusChange(EConnectionStatus status)
        {
            switch (status)
            {
                case EConnectionStatus.connected:
                    Interlocked.Exchange(ref eventServerState, (int)ETunnelState.connected);
                    break;

                case EConnectionStatus.disconnected:
                    Interlocked.Exchange(ref eventServerState, (int)ETunnelState.disconnected);
                    break;
            }
        }

        private string GetConnStatusString(EConnectionStatus status)
        {
            if (status == EConnectionStatus.connected) return "connected";
            if (status == EConnectionStatus.disconnected) return "disconnected";
            return "unknown";
        }

        private string GetServerTypeString(EServerType type)
        {
            if (type == EServerType.configServer) return "config server";
            if (type == EServerType.eventServer) return "event server";
            return "unknown server";
        }

        unsafe private void SetLoginInfo(ref TLoginInfo loginInfo, string ip, int port, string login, string password)
        {
            loginInfo.IP = ip;
            loginInfo.userName = login;
            loginInfo.password = password;
            loginInfo.port = port;
            loginInfo.pfMessCB = messCB;
            loginInfo.context = (IntPtr)gcThis;
            loginInfo.timeoutSeconds = 60;
            loginInfo.blockLogin = false;
        }

        private void StreamDataCallBack(IntPtr pStreamDataInfo)
        {
            TStreamDataInfo info = (TStreamDataInfo)Marshal.PtrToStructure(pStreamDataInfo, typeof(TStreamDataInfo));
            System.DateTime time = new System.DateTime(1970, 1, 1).AddSeconds(info.frameSecond);
            //Console.WriteLine(time.ToString() + "." + info.frameMilSec);
        }

        private void StreamStatusCallBack(IntPtr pStatusInfo)
        {
            TStreamStatusInfo info = (TStreamStatusInfo)Marshal.PtrToStructure(pStatusInfo, typeof(TStreamStatusInfo));
            Console.WriteLine("StreamStatusCallBack: hChannel = {0:X}, Status = {1}", info.hChannel, info.status);
        }

        private void DeleteLiveChannel()
        {
            if (hChannel == 0 || channelType != EChannelType.live) return;
            int ret = DeleteLiveChannel(ref hChannel);
            Console.WriteLine("PlatformSDK.DeleteLiveChannel Ret = {0:X}", ret);
        }

        public void DeleteNetFileChannel()
        {
            if (hChannel == 0 || channelType != EChannelType.playback) return;
            int ret = DeleteNetFileChannel(ref hChannel);
            Console.WriteLine("PlatformSDK.DeleteNetFileChannel Ret = {0:X}", ret);
        }

        private void CreateLiveChannel(int hLoginID, string cameraID, int streamIndex)
        {
            DeleteLiveChannel();

            TStreamInfo streamInfo = new TStreamInfo();

            streamInfo.streamSource = EStreamSource.VAST;
            streamInfo.streamMode = EStreamMode.normalStream;
            streamInfo.hLoginID = hLoginID;
            streamInfo.cameraID = cameraID;
            streamInfo.streamIndex = (short)streamIndex;
            streamInfo.pfStreamDataCB = streamDataCB;
            streamInfo.pfPCMDataCB = null;
            streamInfo.pfYV12DataCB = null;
            streamInfo.pfVideoDecodeCB = null;
            streamInfo.pfStreamStatusCB = streamStatusCB;
            streamInfo.hDisplayWindow = this.Handle;

            int ret = CreateLiveChannel(ref hChannel, ref streamInfo);
            Console.WriteLine("PlatformSDK.CreateLiveChannel Ret = {0:X}", ret);

            if (ret != 0) return;

            //buttonOperation.Hide();
            channelType = EChannelType.live;
        }

        private void CreateNetFileChannel(int hLoginID, string cameraID, uint startTime, uint endTime, short streamIndex)
        {
            DeleteNetFileChannel();

            TStreamInfo streamInfo = new TStreamInfo();

            streamInfo.streamSource = EStreamSource.VAST;
            streamInfo.streamMode = EStreamMode.normalStream;
            streamInfo.timeType = EStreamTimeType.recordingTime;
            streamInfo.hLoginID = hLoginID;
            streamInfo.cameraID = cameraID;
            streamInfo.pfStreamDataCB = streamDataCB;
            streamInfo.pfPCMDataCB = null;
            streamInfo.pfYV12DataCB = null;
            streamInfo.pfVideoDecodeCB = null;
            streamInfo.hDisplayWindow = this.Handle;
            streamInfo.startTime = startTime;
            streamInfo.endTime = endTime;
            streamInfo.streamIndex = streamIndex;

            int ret = CreateNetFileChannel(ref hChannel, ref streamInfo);
            Console.WriteLine("PlatformSDK.CreateNetFileChannel Ret = {0:X}", ret);

            if (ret != 0) return;

            channelType = EChannelType.playback;
        }

        private uint UtcDateTime2time_t(DateTime datetime)
        {
            TimeSpan diff = datetime.ToUniversalTime() - dateTime1970;
            return (uint)(diff.TotalSeconds);
        }


        #endregion

        public VASTNet()
        {
            if (DateTime.Now > DateTime.Parse("31.12.2015 23:59:59"))
            {
                MessageBox.Show("The time is gone...");
                Application.Exit();
            }
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            
        }

        ~VASTNet()
        {
            Release();
        }

        public void Connect(string ip, int port, string login, string password)
        {
            Initial();
            gcThis = GCHandle.Alloc(this);
            messCB = new pfMessCallBack(LoginCallBack);
            streamDataCB = new pfStreamDataCallBack(StreamDataCallBack);
            streamStatusCB = new pfStreamStatusCallBack(StreamStatusCallBack);


            TLoginInfo loginInfo = new TLoginInfo();
            SetLoginInfo(ref loginInfo, ip, port, login, password);

            int ret = Login(ref loginID, ref loginInfo);

        }

        public void Live(int camera, int stream)
        {
            CreateLiveChannel(loginID, "C_" + camera.ToString(), stream);
        }

        public void Playback(int camera, int stream, DateTime startTime)
        {
            string deviceID = "C_" + camera;
            uint begin = UtcDateTime2time_t(startTime);
            uint end = UtcDateTime2time_t(DateTime.Now);
            short streamIndex = (short)stream;
            CreateNetFileChannel(loginID, deviceID, begin, end, streamIndex);
        }
    }
}
