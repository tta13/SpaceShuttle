[System.Serializable]
public class Passenger
{
    public string name;
    public Planet destiny;

    public override bool Equals(object obj)
    {
        if (obj is Passenger && ((Passenger)obj).name.Equals(this.name))
        {
            return true;
        }
        return false;
    }

}
