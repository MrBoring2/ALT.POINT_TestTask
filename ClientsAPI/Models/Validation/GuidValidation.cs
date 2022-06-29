namespace ClientsAPI.Models.Validation
{
    public class GuidValidation
    {
        public bool IsValid(Guid guid)
        {
            if (guid == Guid.Empty)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
