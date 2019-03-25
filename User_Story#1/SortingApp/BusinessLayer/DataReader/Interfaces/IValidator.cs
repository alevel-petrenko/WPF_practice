namespace BusinessLayer.Interfaces
{
    /// <summary>Represents general interface for validation classes</summary>
    /// <author>Anton Petrenko</author>
    public interface IValidator
    {
        bool IsDataExist(string content);
    }
}
