namespace Five.Bank.Domain.ValueObjects.v1;

public record Address(string ZipCode, string Street, 
    string Number, string Neighborhood, string City, string State); 

    //public override bool Equals(object? obj)
    //{
    //    if (obj == null) return false;
    //    if (ReferenceEquals(this, obj)) return true;
    //    if (obj.GetType() != this.GetType()) return false;
    //    Address other = (Address)obj;
    //    other.Street = this.Street;
    //    other.ZipCode = this.ZipCode;
    //    other.City = this.City;
    //    other.Neighborhood = this.Neighborhood;
    //    other.State = this.State;
    //    return base.Equals(obj);
    //}
