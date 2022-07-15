using System;
using System.Collections.Generic;
using System.Linq;
using DBUtil;

namespace Models
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [DBTable("CARINFO_MERGE")]
    public partial class CarinfoMerge
    {

        /// <summary>
        /// 
        /// </summary>
        [DBKey]
        [DBField]
        public int? Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("MODIFY_TIME")]
        public DateTime? ModifyTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("LICENSE_NO")]
        public string LicenseNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("CAR_PLATE_COLOR")]
        public string CarPlateColor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField]
        public string Brand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField]
        public string Model { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("CAR_TYPE")]
        public string CarType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("PASSENGER_LEVEL")]
        public string PassengerLevel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("CAR_COLOR")]
        public string CarColor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("ENG_NO")]
        public string EngNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("FRAME_NO")]
        public string FrameNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("CAR_IDENTITY_CODE")]
        public string CarIdentityCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("SEAT_NO")]
        public decimal? SeatNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("CAR_TONNAGE")]
        public decimal? CarTonnage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("FUEL_TYPE")]
        public string FuelType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("ENG_POWER")]
        public decimal? EngPower { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("LEAVE_FACTORY_TIME")]
        public DateTime? LeaveFactoryTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("BUY_CAR_TIME")]
        public DateTime? BuyCarTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("SETTLE_TIME")]
        public DateTime? SettleTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField]
        public int? Wheelbase { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("CAR_LENGTH")]
        public int? CarLength { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("CAR_HEIGHT")]
        public int? CarHeight { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("CAR_WIDTH")]
        public int? CarWidth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("DRIVING_WAY")]
        public string DrivingWay { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("TRANSFORM_LICENSE_NO")]
        public string TransformLicenseNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("OWNER_NAME")]
        public string OwnerName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("BUSINESS_LICENSE_NO")]
        public string BusinessLicenseNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("GRANT_ORG")]
        public string GrantOrg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("BEGIN_TIME")]
        public DateTime? BeginTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("END_TIME")]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("BUSINESS_SCOPE")]
        public string BusinessScope { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("CAR_OPERATE_SITUATION")]
        public string CarOperateSituation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("CAR_TECHNOLOGY_LEVEL")]
        public string CarTechnologyLevel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("DRIVE_RECORDER")]
        public int? DriveRecorder { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField]
        public int? Locator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("FUEL_EXAM_TIME")]
        public DateTime? FuelExamTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("FIRST_GRANT_TIME")]
        public DateTime? FirstGrantTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField]
        public string Anchored { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("ADMINISTRATIVE_DIVISION_CODE")]
        public string AdministrativeDivisionCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("ORG_CODE")]
        public string OrgCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("OWNER_ADDRESS")]
        public string OwnerAddress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("ECONOMIC_TYPE")]
        public string EconomicType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("LEGAL_REPRESENTATIVE")]
        public string LegalRepresentative { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("ID_CARD_NO")]
        public string IdCardNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField]
        public string Phone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField]
        public string Telephone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("OWNER_TYPE")]
        public string OwnerType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("OWNER_ABBREVIATION")]
        public string OwnerAbbreviation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("CHECK_COMPANY")]
        public string CheckCompany { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("VEHICLE_NO")]
        public string VehicleNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("CHECK_PERSON")]
        public string CheckPerson { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField]
        public string Manafacture { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("PRODUCT_NAME")]
        public string ProductName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("VHCL_COMPANY")]
        public string VhclCompany { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("VHCL_TYPE")]
        public string VhclType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("CHASSIS_TYPE")]
        public string ChassisType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("DRIVE_TYPE")]
        public string DriveType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("TYRE_SIZE")]
        public string TyreSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("ENGINE_TYPE1")]
        public string EngineType1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("TOTAL_MASS")]
        public decimal? TotalMass { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("TRALIER_MASS")]
        public decimal? TralierMass { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("WHEEL_MASS")]
        public decimal? WheelMass { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("TRUCK_VOL")]
        public decimal? TruckVol { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("SEAT_SUM")]
        public int? SeatSum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField]
        public int? Length { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField]
        public int? Width { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField]
        public int? High { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("BOX_LENGTH")]
        public int? BoxLength { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("BOX_WIDTH")]
        public int? BoxWidth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("BOX_HIGH")]
        public int? BoxHigh { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("CURB_WEIGHT")]
        public int? CurbWeight { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("SIZE_EXCEED")]
        public decimal? SizeExceed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("BOARD_EXCEED")]
        public decimal? BoardExceed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("CURB_WEIGHT_EXCEED")]
        public decimal? CurbWeightExceed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("CHECK_COM_OPTION")]
        public string CheckComOption { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("MANAGER_COM_PERSON")]
        public string ManagerComPerson { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("MANAGER_COM_OPTION")]
        public string ManagerComOption { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("TEST_DATE")]
        public DateTime? TestDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("IS_TRANS")]
        public string IsTrans { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("DISTRICT_ID")]
        public string DistrictId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("ENGINE_TYPE")]
        public string EngineType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("TELEPHONE_1")]
        public string Telephone1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("CHECK_STATE")]
        public string CheckState { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("SEAT_EXCEED")]
        public decimal? SeatExceed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DBField("VHCL_COLOR")]
        public string VhclColor { get; set; }

    }
}
