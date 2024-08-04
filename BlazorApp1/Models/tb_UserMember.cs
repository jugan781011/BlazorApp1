namespace BlazorApp1.Models
{
    public class tb_UserMember
    {
        ///<summary>
        ///Id
        ///</summary>
        public int Id { get; set; }
        ///<summary>
        ///員工帳號
        ///</summary>        
        public string Account { get; set; }
        ///<summary>
        ///密碼
        ///</summary>
        public string Password { get; set; }
        ///<summary>
        ///使用者姓名
        ///</summary>
        public string UserName { get; set; }
        ///<summary>
        ///電話
        ///</summary>
        public string Tel { get; set; }
        ///<summary>
        ///Email
        ///</summary>
        public string Email { get; set; }
        ///<summary>
        ///生日
        ///</summary>
        public DateTime? BirthDay { get; set; }
        ///<summary>
        ///登入次數
        ///</summary>
        public int? LoginNumber { get; set; }
        ///<summary>
        ///新增時間
        ///</summary>
        public DateTime? CreationDate { get; set; }
        ///<summary>
        ///新增人員
        ///</summary>
        public string CreatedBy { get; set; }
        ///<summary>
        ///修改時間
        ///</summary>
        public DateTime? LastUpdateDate { get; set; }
        ///<summary>
        ///修改人員
        ///</summary>
        public string LastUpdatedBy { get; set; }
    }
}
