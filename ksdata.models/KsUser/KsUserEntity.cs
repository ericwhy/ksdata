namespace ksdata.models
{
    public class KsUserEntity {
        public string KsUserId {get;set;} = "";
        public string? DisplayName {get;set;}
        public string? EmailAddress {get;set;}
        public string? PasswordHints {get;set;}
        public string? Password {get;set;}
        public string? PasswordSalt {get;set;}
        public DateTime PasswordDt {get;set;}
        public string AllowAccessFlg {get;set;} = "N";
        public string IntegratedAuth {get;set;} = "N";
        public string AuthPrompt {get;set;} = "N";
        public string PwresetFlg {get;set;} = "N";  
        public byte? FailedLoginCnt {get;set;}
        public DateTime? FailedLoginDt {get;set;}
        public IList<KsLoginFailureEntity> LoginFailures {get;} = new List<KsLoginFailureEntity>();
        public IList<KsUserRoleEntity> UserRoles {get;} = new List<KsUserRoleEntity>();
        public IList<PasswordHistoryEntity> PasswordHistories {get;} = new List<PasswordHistoryEntity>();
        public IList<KsUserTokenEntity> UserTokens {get;set;} = new List<KsUserTokenEntity>();
    }
}
