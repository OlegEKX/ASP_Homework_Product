namespace ASP_Homework_Product
{
    public class InMemoryConstants : IConstants
    {
        // убрал static
        public string interfaceUserId = "UserId";

        public string UserId
        {
            get
            {
                return interfaceUserId;
            }
        }
    }
}
