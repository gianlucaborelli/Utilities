namespace Api.IsTempMail.Model
{
    public class Domain
    {
        public string Name { get; set; } = string.Empty;

        public bool Blocked { get; set; }        

        public bool Unresolvable { get; set; }         

        public bool IsBlocked(){
            return Blocked;
        }

        public bool IsNotBlocked(){
            return !Blocked;
        }
    }    
}