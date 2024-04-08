namespace Z_Marked.Exceptions
{
    public class WrongCredentialsException : ArgumentException
    {
        public WrongCredentialsException() : base("Wrong login credentials. Try again.")
        {}

        public override string Message => base.Message;
    }
}
