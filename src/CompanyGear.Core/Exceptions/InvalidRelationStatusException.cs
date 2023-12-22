namespace CompanyGear.Core.Exceptions;

public sealed class InvalidRelationStatusException : CustomException
{
    public string RelationStatus { get; }
    public InvalidRelationStatusException(string relationStatus) : base($"Relation status: {relationStatus} is invalid.")
    {
        RelationStatus = relationStatus;
    }
}