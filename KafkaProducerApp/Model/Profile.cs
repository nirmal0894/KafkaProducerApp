using System;
using System.Collections.Generic;
using System.Text;

namespace KafkaProducerApp.Model
{
    //public class Profile
    //{
    //    private string leavingDate;
    //    private string seniorFlag;

    //    [CsvColumn(Name = "EMP_NUM")]
    //    public string EmployeeNumber { get; set; }

    //    [CsvColumn(Name = "JOB_CD_STR_DT")]
    //    public string JobCodeStartDate { get; set; }

    //    [CsvColumn(Name = "JOB_CD")]
    //    public string JobCode { get; set; }

    //    [CsvColumn(Name = "JOB_DESC")]
    //    public string JobDescription { get; set; }

    //    [CsvColumn(Name = "POS_STR_DT")]
    //    public string PositionStartDate { get; set; }

    //    [CsvColumn(Name = "POS_NUM")]
    //    public string PositionNumber { get; set; }

    //    [CsvColumn(Name = "POS_DESC")]
    //    public string PositionDescription { get; set; }

    //    [CsvColumn(Name = "STR_DT")]
    //    public string StartDate { get; set; }

    //    [CsvColumn(Name = "LEAVING_DT")]
    //    public string LeavingDate
    //    {
    //        get { return leavingDate; }
    //        set { leavingDate = value.TrimIfNotNull(); }
    //    }

    //    [CsvColumn(Name = "BRN_TRN_DT")]
    //    public string BranchTrnDate { get; set; }

    //    [CsvColumn(Name = "BRN_NUM")]
    //    public string BranchNumber { get; set; }

    //    [CsvColumn(Name = "BRN_NAME")]
    //    public string BranchName { get; set; }

    //    [CsvColumn(Name = "LEAVING_RSN_CD")]
    //    public string LeavingReasonCode { get; set; }

    //    [CsvColumn(Name = "LEAVING_RSN_DESC")]
    //    public string LeavingReasonDescription { get; set; }

    //    [CsvColumn(Name = "LATEST_STR_DT")]
    //    public string LatestStartDate { get; set; }

    //    [CsvColumn(Name = "REINSTM_CODE")]
    //    public string ReinstatementCode { get; set; }

    //    [CsvColumn(Name = "REINSTM_DESC")]
    //    public string ReinstatementDescription { get; set; }

    //    [CsvColumn(Name = "BASIC_HRS_STR_DT")]
    //    public string BasicHoursStartDate { get; set; }

    //    [CsvColumn(Name = "BASIC_HRS")]
    //    public string BasicHours { get; set; }

    //    [CsvColumn(Name = "CONT_PAY_STR_DT")]
    //    public string ContractedPayStartDate { get; set; }

    //    [CsvColumn(Name = "CONT_PAY")]
    //    public string ContractedPay { get; set; }

    //    [CsvColumn(Name = "WORK_LEVEL")]
    //    public string WorkLevel { get; set; }

    //    [CsvColumn(Name = "CONTRACT_TYPE")]
    //    public string ContractType { get; set; }

    //    [CsvColumn(Name = "DEPT")]
    //    public string Department { get; set; }

    //    [CsvColumn(Name = "SECTION")]
    //    public string Section { get; set; }

    //    [CsvColumn(Name = "PEN_SENIOR_IND")]
    //    public string IsSenior
    //    {
    //        get { return seniorFlag; }
    //        set { seniorFlag = value.TrimIfNotNull(); }
    //    }
    //}

    public class Profile
    {
        public int Id { get; set; }
        public string Productname { get; set; }
        public int Quantity { get; set; }
    }

    public enum KafkaProcesStatus
    {
        error = 0,
        completed = 1
    }
}
