using System;
using System.Collections.Generic;
using System.Linq;
using DBUtil;

namespace Models
{
    /// <summary>
    /// 平台_摄像机表
    /// </summary>
    [Serializable]
    [DBTable("PT_CAMERA_INFO")]
    public partial class PtCameraInfo
    {

        /// <summary>
        /// ID
        /// </summary>
        [DBKey]
        [DBField]
        public string Id { get; set; }

        /// <summary>
        /// 资产ID
        /// </summary>
        [DBField("ASSET_ID")]
        public string AssetId { get; set; }

        /// <summary>
        /// 20位：中心编码、 行业编码、设备类型、网络标识、设备序号，与联网平台/共享平台国标编码一致。（天网：CAMEAR_NO 摄像头编号，项目部提供的编号，点位编码+摄像机编码的组合）
        /// </summary>
        [DBField("CAMERA_NO")]
        public string CameraNo { get; set; }

        /// <summary>
        /// 点位编码
        /// </summary>
        [DBField("POSITION_CODE")]
        public string PositionCode { get; set; }

        /// <summary>
        /// (天网业务字段,与资产重复:所属点位ID）
        /// </summary>
        [DBField("POSITION_ID")]
        public string PositionId { get; set; }

        /// <summary>
        /// (天网业务字段,与资产重复:摄像头名称）
        /// </summary>
        [DBField("CAMERA_NAME")]
        public string CameraName { get; set; }

        /// <summary>
        /// (天网业务字段,与资产重复:所属机构）
        /// </summary>
        [DBField("ORG_ID")]
        public int? OrgId { get; set; }

        /// <summary>
        /// (天网业务字段,与资产重复:安装详细地址）
        /// </summary>
        [DBField]
        public string Address { get; set; }

        /// <summary>
        /// (天网业务字段,与资产重复:IP地址）
        /// </summary>
        [DBField("CAMERA_IP")]
        public string CameraIp { get; set; }

        /// <summary>
        /// (天网业务字段,与资产重复:经度）
        /// </summary>
        [DBField]
        public string Longitude { get; set; }

        /// <summary>
        /// (天网业务字段,与资产重复:纬度）
        /// </summary>
        [DBField]
        public string Latitude { get; set; }

        /// <summary>
        /// (天网业务字段,与资产重复:摄像机SN号：设备发现接口取得的）
        /// </summary>
        [DBField]
        public string Sn { get; set; }

        /// <summary>
        /// (天网业务字段,与资产重复:摄像机型号）
        /// </summary>
        [DBField("CAMERA_MODEL")]
        public string CameraModel { get; set; }

        /// <summary>
        /// (天网业务字段,与资产重复:生产厂商）
        /// </summary>
        [DBField]
        public string Manufacturer { get; set; }

        /// <summary>
        /// (天网业务字段,与资产重复:供应商）
        /// </summary>
        [DBField]
        public string Supplier { get; set; }

        /// <summary>
        /// (天网业务字段,与资产重复:摄像头状态1 在线0离线）
        /// </summary>
        [DBField("CAMERA_STATE")]
        public string CameraState { get; set; }

        /// <summary>
        /// (天网业务字段,与资产重复:添加人）
        /// </summary>
        [DBField("ADD_ID")]
        public string AddId { get; set; }

        /// <summary>
        /// (天网业务字段,与资产重复:添加时间）
        /// </summary>
        [DBField("ADD_TIME")]
        public DateTime? AddTime { get; set; }

        /// <summary>
        /// (天网业务字段,与资产重复:修改人）
        /// </summary>
        [DBField("MODIFY_ID")]
        public string ModifyId { get; set; }

        /// <summary>
        /// (天网业务字段,与资产重复:修改时间）
        /// </summary>
        [DBField("MODIFY_TIME")]
        public DateTime? ModifyTime { get; set; }

        /// <summary>
        /// (天网业务字段,与资产重复:像机用户名）
        /// </summary>
        [DBField("USER_NAME")]
        public string UserName { get; set; }

        /// <summary>
        /// (天网业务字段,与资产重复:像机密码）
        /// </summary>
        [DBField("PASS_WORD")]
        public string PassWord { get; set; }

        /// <summary>
        /// 机箱安装形式：1、立杆；2、借杆；3、壁挂；4、落地；99、其他。单选
        /// </summary>
        [DBField("CASE_INSTALL_TYPE")]
        public int? CaseInstallType { get; set; }

        /// <summary>
        /// 行政区域，按照标准(GB/T2260-2007）
        /// </summary>
        [DBField("AREA_CODE")]
        public string AreaCode { get; set; }

        /// <summary>
        /// 监控点位类型：1.一类视频监控点；2.二类视频监控点； 3.三类视频监控点； 4 公安内部视频监控点；9.其他点位。
        /// </summary>
        [DBField("MONITOR_TYPE")]
        public string MonitorType { get; set; }

        /// <summary>
        /// 点位俗称
        /// </summary>
        [DBField("POINT_NAME")]
        public string PointName { get; set; }

        /// <summary>
        /// IPV6地址
        /// </summary>
        [DBField("CAMERA_IP6")]
        public string CameraIp6 { get; set; }

        /// <summary>
        /// 子网掩码
        /// </summary>
        [DBField("SUBNET_MASK")]
        public string SubnetMask { get; set; }

        /// <summary>
        /// 网关
        /// </summary>
        [DBField]
        public string Gateway { get; set; }

        /// <summary>
        /// MAC地址
        /// </summary>
        [DBField("MAC_ADDRESS")]
        public string MacAddress { get; set; }

        /// <summary>
        /// ONU SN码
        /// </summary>
        [DBField("ONU_SN")]
        public string OnuSn { get; set; }

        /// <summary>
        /// 1.球机；3.固定枪机；5.卡口枪机；99.其他；100.高点监控；101.半高点球机（天网：CAMERA_TYPE,摄像机类型）
        /// </summary>
        [DBField("CAMERA_TYPE")]
        public string CameraType { get; set; }

        /// <summary>
        /// 1.车辆卡口；2.人员卡口；3.微卡口；99.其他；100.综合治理枪机；101.综合治理球机；102.人像识别枪机（后智能）；103.虚拟卡口；104.高空枪机；105.高空球机；106.半高空球机；107.视频结构化（后智能）；108.全景拼接；109.枪球联动（球）；110.枪球联动（枪）；111.高倍高点球机；112.高倍高点云台枪机；113.机房摄像机（天网：CAMERA_USE）
        /// </summary>
        [DBField("CAMERA_FUN_TYPE")]
        public string CameraFunType { get; set; }

        /// <summary>
        /// 补光属性：1.无补光；2.红外补光；9.其他补光；10.外置白光补光；11.内置白光补光（雪亮微卡口选这个）；12.LED频闪补光（雪亮的部分实体卡口选这个）
        /// </summary>
        [DBField("FILL_LIGTH_ATTR")]
        public int? FillLigthAttr { get; set; }

        /// <summary>
        /// 摄像机编码格式：1.MPEG-4； 2.H.264； 3.SVAC； 4.H.265?
        /// </summary>
        [DBField("CAMERA_ENCODE_TYPE")]
        public int? CameraEncodeType { get; set; }

        /// <summary>
        /// 取电方式： 1.电业局供电；2.企事业单位；3.居民用电专供；4.临街商铺专供；5.交警取电；6.其他
        /// </summary>
        [DBField("POWER_TAKE_TYPE")]
        public int? PowerTakeType { get; set; }

        /// <summary>
        /// 取电长度：单位为米，小数点后一位
        /// </summary>
        [DBField("POWER_TAKE_LENGTH")]
        public string PowerTakeLength { get; set; }

        /// <summary>
        /// 是否有拾音器，1表示是，2表示否（天网：否带语音0：不带 1：带语音告警设备）
        /// </summary>
        [DBField("SOUND_ALARM")]
        public int? SoundAlarm { get; set; }

        /// <summary>
        /// 摄像机分辨率：1.QCIF；2.CIF；3.4CIF；4.D1；5.720P；6.1080P；7.4K及以上（天网：分辨率）
        /// </summary>
        [DBField]
        public string Resolution { get; set; }

        /// <summary>
        /// 摄像机软件版本
        /// </summary>
        [DBField("SOFT_VERSION")]
        public string SoftVersion { get; set; }

        /// <summary>
        /// 镜头参数,(天网：镜头参数)
        /// </summary>
        [DBField("LENS_PARAM")]
        public string LensParam { get; set; }

        /// <summary>
        /// 是否有云台（天网：是否有云台，1 有，0无）
        /// </summary>
        [DBField("IS_HAVE_CONSOLE")]
        public int? IsHaveConsole { get; set; }

        /// <summary>
        /// 摄像机安装方式：1、立杆；2、借杆；3、壁挂；4.其他（天网：安装方式）
        /// </summary>
        [DBField("INSTALL_WAY")]
        public string InstallWay { get; set; }

        /// <summary>
        /// 走线方式：1、地埋；2、飞线；3、沿墙敷设；4、其他（天网：走线方式）
        /// </summary>
        [DBField("LINEAR_WAY")]
        public string LinearWay { get; set; }

        /// <summary>
        /// 资源存储位置：1.瑶海分局、2.庐阳分局、3.蜀山分局、4.包河分局、5.高新分局、6.新站分局、7.经开分局、8.巢湖经济开发区分局、9.庐江县公安局
        /// </summary>
        [DBField("RESOURCE_PLACE")]
        public string ResourcePlace { get; set; }

        /// <summary>
        /// 重点监控对象：1、第一道防控圈；2、第二道防控圈；3、第三道防空圈；4、第四道防控圈；5、第五道防控圈；6、第六道防控圈；99、其他（天网：重点监控对象）
        /// </summary>
        [DBField("IMPORT_WATCH")]
        public string ImportWatch { get; set; }

        /// <summary>
        /// 摄像机位置类型：1.省际检查站、2.党政机关、3.车站码头、4.中心广场、5.体育场馆、6.商业中心、7.宗教场所、8.校园周边、9.治安复杂区域、10.交通干线、11-医院周边、12-金融机构周边、13-危险物品场所周边、14-博物馆展览馆、15-重点水域、航道、96.市际公安检查站；97.涉外场所；98.边境沿线；99.旅游景区。新增：100.高速路口、101.高速路段、102.城市高点、103.拥堵路段、104.旅馆周边、105.网吧周边、106.公园周边、107.娱乐场所、108.新闻媒体单位周边、109.电信邮政单位周边、110.机场周边、111.铁路沿线、112.火车站周边、113.汽车站周边、114.港口周边、115.城市轨道交通站、116.公交车站周边、117.停车场（库）、118.地下人行通道、119.隧道、120.过街天桥、121.省/市/县（区）际道路主要出入口、122.收费站通道、123.高速公路卡口卡点、124.国道卡口卡点、125.省道上的（治安）卡口卡点、126.大型桥梁通行区域、127.隧道通行区域、128.大型能源动力设施周边、129.城市（水/电/燃气/燃油/热力）能源供应单位周边、130.文博单位（博物馆/纪念馆/展览馆/档案馆/重点文物保护）、131.国家重点建设工程工地、132.居民小区、133.高架上下匝道、134.加油站、135.人脸重点区域、136.黄标车卡点、137.采血点附近。多选各参数以“ /” 分隔
        /// </summary>
        [DBField("POSITION_TYPE")]
        public string PositionType { get; set; }

        /// <summary>
        /// 社区名称（天网：COMMUNITY 社区名称）
        /// </summary>
        [DBField]
        public string Community { get; set; }

        /// <summary>
        /// 街道（天网：STREET 街道）
        /// </summary>
        [DBField]
        public string Street { get; set; }

        /// <summary>
        /// 照射具体位置：1、出入口；2、背街小巷；3、人行道；4、非机动车道；5、主干道路段；6、交叉路口
        /// </summary>
        [DBField("WATCH_SPEC_LOCATION")]
        public string WatchSpecLocation { get; set; }

        /// <summary>
        /// 所在道路位置：**路东、**路南、**路北、**路西
        /// </summary>
        [DBField("ROAD_DIRECTION")]
        public string RoadDirection { get; set; }

        /// <summary>
        /// 辖区边界属性：属于边界资源，如**派出所与**派出所边界，**分局与**分局边界  (天网：辖区边界（多个以逗号分割）)
        /// </summary>
        [DBField("FOUL_LINE")]
        public string FoulLine { get; set; }

        /// <summary>
        /// 分局：0.市局、1.瑶海分局、2.庐阳分局、3.蜀山分局、4.包河分局、5.高新分局、6.新站分局、7.经开分局、8.巢湖经济开发区分局、9.庐江县公安局
        /// </summary>
        [DBField("FEN_JU")]
        public string FenJu { get; set; }

        /// <summary>
        /// 派出所
        /// </summary>
        [DBField("POLICE_STATION")]
        public string PoliceStation { get; set; }

        /// <summary>
        /// 监视方位：1-东、2-西、3-南、4-北、5-东南、6-东北、7-西南、8-西北、9.全向（要求厂商定位准确）（天网：CAMERA_DIRECTION）
        /// </summary>
        [DBField("CAMERA_DIRECTION")]
        public string CameraDirection { get; set; }

        /// <summary>
        /// 架设高度：1、3.5m；2、4.6m；3、5.3m；4、6m；5、6.8；6、其他（外场定义）
        /// </summary>
        [DBField("INSTALL_HEIGHT")]
        public string InstallHeight { get; set; }

        /// <summary>
        /// 横臂1：1、0.5m；2、1m；3、1.5m；4、2m；5、7m（外场定义）
        /// </summary>
        [DBField("CROSS_ARM1")]
        public string CrossArm1 { get; set; }

        /// <summary>
        /// 横臂2：1、0.5m；2、1m；3、1.5m；4、2m；5、7m（外场定义）
        /// </summary>
        [DBField("CROSS_ARM2")]
        public string CrossArm2 { get; set; }

        /// <summary>
        /// 安装位置：1.室外；2.室内
        /// </summary>
        [DBField("INDOOR_OR_NOT")]
        public int? IndoorOrNot { get; set; }

        /// <summary>
        /// 摄像机特写照片：建设好之后，拍的摄像机场景照片（照片名称需与文件夹名称一致）
        /// </summary>
        [DBField("SPECIAL_PHOTO_PATH")]
        public string SpecialPhotoPath { get; set; }

        /// <summary>
        /// 勘察照片
        /// </summary>
        [DBField("LOCATION_PHOTO_PATH")]
        public string LocationPhotoPath { get; set; }

        /// <summary>
        /// 摄像机照射照片
        /// </summary>
        [DBField("REAL_PHOTO_PATH")]
        public string RealPhotoPath { get; set; }

        /// <summary>
        /// 联网属性：0 已联网； 1 未联网
        /// </summary>
        [DBField("NETWORK_PROPERTIES")]
        public int? NetworkProperties { get; set; }

        /// <summary>
        /// 采用公安组织机构代码(由GA/T 380规定)，公安机关建设单位或者社会资源接入后的使用单位，注明到所属辖区公安机关派出所
        /// </summary>
        [DBField("POLICE_AREA_CODE")]
        public string PoliceAreaCode { get; set; }

        /// <summary>
        /// 安装负责人：外场定义
        /// </summary>
        [DBField("INSTALL_PERSION")]
        public string InstallPersion { get; set; }

        /// <summary>
        /// 年、月、日（外场定义）（上线时间)
        /// </summary>
        [DBField("INSTALL_TIME")]
        public DateTime? InstallTime { get; set; }

        /// <summary>
        /// 建设期数：1.一期；2.二期；3.三期；4.四期；5.五期；6.支网；99、其他。单选（字段可以由数据字典维护）
        /// </summary>
        [DBField("BUILD_PERIOD")]
        public int? BuildPeriod { get; set; }

        /// <summary>
        /// 项目名称：合肥雪亮工程一期
        /// </summary>
        [DBField("PROJECT_NAME")]
        public string ProjectName { get; set; }

        /// <summary>
        /// 合肥市公安局，待确认
        /// </summary>
        [DBField("MANAGER_UNIT")]
        public string ManagerUnit { get; set; }

        /// <summary>
        /// 电话号码，待确认
        /// </summary>
        [DBField("MANAGER_UNIT_TEL")]
        public string ManagerUnitTel { get; set; }

        /// <summary>
        /// 四创电子、自定义
        /// </summary>
        [DBField("MAINTAIN_UNIT")]
        public string MaintainUnit { get; set; }

        /// <summary>
        /// 四创电子运维电话
        /// </summary>
        [DBField("MAINTAIN_UNIT_TEL")]
        public string MaintainUnitTel { get; set; }

        /// <summary>
        /// 30天、90天
        /// </summary>
        [DBField("RECODE_SAVE_TYPE")]
        public int? RecodeSaveType { get; set; }

        /// <summary>
        /// 1.在用；2.维修；3.拆除默认在用
        /// </summary>
        [DBField("DEVICE_STATE")]
        public int? DeviceState { get; set; }

        /// <summary>
        /// 1.公安机关； 2.环保部门;3.文博部门;4.医疗部门;5.旅游管理;6.新闻广电;7.食品医药监督管理部门;8.教育管理部门;9.检察院;10.法院;11.金融部门;12.交通部门;13.住房和城乡建设部门;14.水利部门;15.林业部门;16.安全生产监督部门;17.市政市容委;18.国土局,可扩展， 多选各参数以“ /” 分隔
        /// </summary>
        [DBField("INDUSTRY_OWN")]
        public string IndustryOwn { get; set; }

        /// <summary>
        /// 是否已注册到汇聚平台
        /// </summary>
        [DBField("IS_REGISTER_IMOS")]
        public int? IsRegisterImos { get; set; }

        /// <summary>
        /// 是否有Wifi模块：0，否；1，是
        /// </summary>
        [DBField("IS_WIFI")]
        public int? IsWifi { get; set; }

        /// <summary>
        /// 闪光灯
        /// </summary>
        [DBField("IS_FLASH")]
        public int? IsFlash { get; set; }

        /// <summary>
        /// 天网业务字段（摄像头的字母形式编号，项目部提供的编号，如：YH-HC-）0001-1011,提供给运维系统展示使用
        /// </summary>
        [DBField("CAMERA_NO_STR")]
        public string CameraNoStr { get; set; }

        /// <summary>
        /// 天网业务字段（摄像机VCN编码：可能需要与摄像机编号对应）
        /// </summary>
        [DBField("CAMERA_VCN_CODE")]
        public string CameraVcnCode { get; set; }

        /// <summary>
        /// 天网业务字段，域编码
        /// </summary>
        [DBField("FIELD_NO")]
        public string FieldNo { get; set; }

        /// <summary>
        /// 重点监控单位，照射具体单位名称（如兴园小学）（天网业务字段，重点单位）
        /// </summary>
        [DBField("KEY_UNIT")]
        public string KeyUnit { get; set; }

        /// <summary>
        /// 天网业务字段，单位类型
        /// </summary>
        [DBField("UNIT_TYPE")]
        public string UnitType { get; set; }

        /// <summary>
        /// 天网业务字段，显示等级
        /// </summary>
        [DBField("SHOW_LEVEL")]
        public decimal? ShowLevel { get; set; }

        /// <summary>
        /// 天网业务字段，摄像机协议类型：设备发现接口取得的
        /// </summary>
        [DBField("PROTOCOL_TYPE")]
        public string ProtocolType { get; set; }

        /// <summary>
        /// 天网业务字段，摄像机端口号
        /// </summary>
        [DBField("CAMERA_PORT")]
        public string CameraPort { get; set; }

        /// <summary>
        /// 天网业务字段，接口类型
        /// </summary>
        [DBField("INTERFACE_TYPE")]
        public string InterfaceType { get; set; }

        /// <summary>
        /// 天网业务字段，通道
        /// </summary>
        [DBField]
        public string Channel { get; set; }

        /// <summary>
        /// 天网业务字段，使用对象
        /// </summary>
        [DBField("USER_OBJECT")]
        public string UserObject { get; set; }

        /// <summary>
        /// 天网业务字段，施工图URL
        /// </summary>
        [DBField("IMG_PATH")]
        public string ImgPath { get; set; }

        /// <summary>
        /// 天网业务字段，描述
        /// </summary>
        [DBField("CAMERA_DESC")]
        public string CameraDesc { get; set; }

        /// <summary>
        /// 天网业务字段，是否已注册VCN
        /// </summary>
        [DBField("IS_REGISTER_VCN")]
        public int? IsRegisterVcn { get; set; }

        /// <summary>
        /// 天网业务字段，是否删除
        /// </summary>
        [DBField("IS_DEL")]
        public int IsDel { get; set; }

        /// <summary>
        /// 天网业务字段，排序值
        /// </summary>
        [DBField("ORDER_VALUE")]
        public int? OrderValue { get; set; }

        /// <summary>
        /// 天网业务字段，检测结果:0 正常 1  黑屏  2 冻结  3  掉线   4  亮度异常  5 清晰度异常   6 偏色  7  噪声  8  抖动  9 遮挡  10  PTZ失控
        /// </summary>
        [DBField("POLLING_RESULT")]
        public int? PollingResult { get; set; }

        /// <summary>
        /// 天网业务字段，最新检测时间
        /// </summary>
        [DBField("POLLING_TIME")]
        public DateTime? PollingTime { get; set; }

        /// <summary>
        /// 天网业务字段，诊断服务器ID
        /// </summary>
        [DBField("SERVER_ID")]
        public int? ServerId { get; set; }

        /// <summary>
        /// 天网业务字段，摄像头检索条件集合
        /// </summary>
        [DBField("SHORT_MSG")]
        public string ShortMsg { get; set; }

        /// <summary>
        /// 天网业务字段，摄像机所属设备
        /// </summary>
        [DBField("CAMERA_BELONGS_ID")]
        public string CameraBelongsId { get; set; }

        /// <summary>
        /// 天网业务字段，摄像机来源，0 华为VCN3000   1 交警支队
        /// </summary>
        [DBField("RELATED_CUSTOMS")]
        public string RelatedCustoms { get; set; }

        /// <summary>
        /// 天网业务字段，是否进入空间库，1为进入，0为否
        /// </summary>
        [DBField("ADDED_TO_SDE")]
        public int? AddedToSde { get; set; }

        /// <summary>
        /// 天网业务字段，摄像机备件
        /// </summary>
        [DBField("CAMERA_BAK")]
        public string CameraBak { get; set; }

        /// <summary>
        /// 天网业务字段，摄像机所属四创虚拟卡口设备
        /// </summary>
        [DBField("CAMERA_BELONGS_PK")]
        public string CameraBelongsPk { get; set; }

        /// <summary>
        /// 天网业务字段，杆件编码
        /// </summary>
        [DBField("MEMBERBAR_CODE")]
        public string MemberbarCode { get; set; }

        /// <summary>
        /// 天网业务字段，是否是支网
        /// </summary>
        [DBField("IS_BRANCH")]
        public decimal? IsBranch { get; set; }

        /// <summary>
        /// 是否设置看守位
        /// </summary>
        [DBField("IS_WATCHPOS")]
        public int? IsWatchpos { get; set; }

        /// <summary>
        /// 监视角度，取值范围0-360度（正东方为0度，正南方为90度，正西方为180度，正北方为270度，精确到个位）
        /// </summary>
        [DBField("CAMERA_ANGLE")]
        public string CameraAngle { get; set; }

        /// <summary>
        /// 1、0.5m；2、1m；3、1.5m；4、2m；5、7m（外场定义）
        /// </summary>
        [DBField("CROSS_ARM3")]
        public string CrossArm3 { get; set; }

        /// <summary>
        /// 一机一档数据同步：0未同步 1已同步
        /// </summary>
        [DBField("IS_SYS")]
        public int? IsSys { get; set; }

        /// <summary>
        /// 摄像机存储时间
        /// </summary>
        [DBField("RECORD_TIME")]
        public int? RecordTime { get; set; }

        /// <summary>
        /// 解析平台编码
        /// </summary>
        [DBField("ANALYSIS_NO")]
        public string AnalysisNo { get; set; }

        /// <summary>
        /// WIFI 在线状态，0离线，1在线
        /// </summary>
        [DBField("WIFI_STATE")]
        public string WifiState { get; set; }

        /// <summary>
        /// 人脸任务状态：0未启动 1已启动 2锁定
        /// </summary>
        [DBField("FACE_TASK_STATUS")]
        public int? FaceTaskStatus { get; set; }

        /// <summary>
        /// 视频结构化任务状态：0未启动 1已启动 2锁定
        /// </summary>
        [DBField("VIDEO_TASK_STATUS")]
        public int? VideoTaskStatus { get; set; }

        /// <summary>
        /// 虚拟卡口任务状态：0未启动 1已启动 2锁定
        /// </summary>
        [DBField("BAYONET_TASK_STATUS")]
        public int? BayonetTaskStatus { get; set; }

        /// <summary>
        /// 视频质量诊断结果附图URL
        /// </summary>
        [DBField("VQD_URL")]
        public string VqdUrl { get; set; }

        /// <summary>
        /// 一机一档同步数据类型 1:新增 2:修改 3:删除
        /// </summary>
        [DBField("SYS_TYPE")]
        public int? SysType { get; set; }

        /// <summary>
        /// 人员卡口相机是否有抓拍数据：0无 1有
        /// </summary>
        [DBField("IS_HAVE_CAPTURE")]
        public int? IsHaveCapture { get; set; }

    }
}
