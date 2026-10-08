namespace DefaultNamespace;

public class MusicalNote
{
    int semitonesFrom440Hz;

    public MusicalNote(int semitonesFrom440Hz)
    {
        this.semitonesFrom440Hz = semitonesFrom440Hz;
    }

    public static MusicalNote operator +(MusicalNote x, int semitones)
    {
        return new MusicalNote(x.semitonesFrom440Hz + semitones);
    }

    public static MusicalNote operator +(MusicalNote x, MusicalNote y)
    {
        return new MusicalNote(x.semitonesFrom440Hz + y.semitonesFrom440Hz);
    }
    
    public static MusicalNote operator checked +(MusicalNote x, int semitones)
    {
        return checked(new MusicalNote(x.semitonesFrom440Hz + semitones));
    }

    public static MusicalNote operator checked +(MusicalNote x, MusicalNote y)
    {
        return checked(new MusicalNote(x.semitonesFrom440Hz + y.semitonesFrom440Hz));
    }

    public static MusicalNote operator -(MusicalNote x, int semitones)
    {
        return new MusicalNote(x.semitonesFrom440Hz - semitones);
    }

    public static MusicalNote operator checked -(MusicalNote x, int semitones)
    {
        return checked(new MusicalNote(x.semitonesFrom440Hz - semitones));
    }

    public static MusicalNote operator -(MusicalNote x, MusicalNote y)
    {
        return new MusicalNote(x.semitonesFrom440Hz - y.semitonesFrom440Hz);
    }

    public static MusicalNote operator checked -(MusicalNote x, MusicalNote y)
    {
        return checked (new MusicalNote(x.semitonesFrom440Hz - y.semitonesFrom440Hz));
    }

    public static bool operator ==(MusicalNote x, MusicalNote y)
    {
        return (x.semitonesFrom440Hz == y.semitonesFrom440Hz);
    }

    public static bool operator !=(MusicalNote x, MusicalNote y)
    {
        return (x.semitonesFrom440Hz != y.semitonesFrom440Hz);
    }

    public static bool operator >(MusicalNote x, MusicalNote y)
    {
        return (x.semitonesFrom440Hz > y.semitonesFrom440Hz);
    }

    public static bool operator <(MusicalNote x, MusicalNote y)
    {
        return (x.semitonesFrom440Hz < y.semitonesFrom440Hz);
    }

    public static implicit operator int(MusicalNote x)
    {
        return x.semitonesFrom440Hz;
    }

    public static implicit operator double(MusicalNote x)
    {
        return 440 * Math.Pow(2, (double)x.semitonesFrom440Hz / 12);
    }
    

    public static explicit operator MusicalNote(double x)
    {
        return new MusicalNote((int)(0.5 + 12 * (Math.Log(x / 440) / Math.Log(2))));
    }
    

}