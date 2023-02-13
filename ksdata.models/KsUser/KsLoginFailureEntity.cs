namespace ksdata.models {
    public class KsLoginFailureEntity {
        public string KsUserId {get;set;} = "";
        public DateTime FailDt {get;set;}
        public KsUserEntity User {get;} = new();
    }
}