namespace ksdata.models {
    public class PasswordHistoryEntity {
        public string KsUserId {get;set;} = "";
        public string Password {get;set;} = "";
        public string? PasswordSalt {get;set;}
        public DateTime CreateDt {get;set;}
        public KsUserEntity User {get;set;} = new();
    }
}