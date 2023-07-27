using System;

namespace Frogge.Entities;

public abstract class FObject
{
    public Guid _id;
    public String name { get; set; }
    
    public Guid ID => _id;

    protected FObject(String name)
    {
        _id = new Guid();
        this.name = name;
    }

    public String GetName()
    {
        return name;
    }
    
    public static Boolean operator ==(FObject? a, FObject? b)
    {
        if (a is null && b is null)
            return true;
        if (a is null || b is null)
            return false;
        
        return a._id == b._id;
    }
    public static Boolean operator !=(FObject? a, FObject? b) => !(a == b);
}
