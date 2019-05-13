namespace EMOASApp.Entity
{
    class User
    {
        #region
        /// <summary>
        /// 员工编号
        /// </summary>
        public int YGBH { get; set; }
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string YGXM { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string BM { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string AppPwd { get; set; }
        #endregion
    }
}